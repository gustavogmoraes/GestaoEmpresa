using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos.ObjetosConcretos;
using GS.GestaoEmpresa.Solucao.Mapeador.Mapeadores.MapeadoresConcretos;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores;
using GS.GestaoEmpresa.Solucao.Negocio.Validador;

namespace GS.GestaoEmpresa.Solucao.Negocio.Servicos
{
    public class ServicoDeInteracao : IDisposable
    {
        public List<Interacao> ConsulteTodasAsInteracoes()
        {
            var listaDeInteracoes = new List<Interacao>();
            using (var mapeadorDeInteracao = new MapeadorDeInteracao())
            using (var mapeadorDeNumeroDeSerie = new MapeadorDeNumeroDeSerie())
            {
                listaDeInteracoes = mapeadorDeInteracao.ConsulteTodasAsInteracoes();
                
                foreach (var interacao in listaDeInteracoes)
                {
                    interacao.NumerosDeSerie = mapeadorDeNumeroDeSerie.ConsulteTodosPorInteracao(interacao.Codigo);
                }
            }

            return listaDeInteracoes;
        }

        public List<Interacao> ConsulteTodasAsInteracoesPorProduto(int codigoProduto)
        {
            var listaDeInteracoes = new List<Interacao>();
            using (var mapeadorDeInteracao = new MapeadorDeInteracao())
            using (var mapeadorDeNumeroDeSerie = new MapeadorDeNumeroDeSerie())
            {
                listaDeInteracoes = mapeadorDeInteracao.ConsulteTodasInteracoesPorProduto(codigoProduto);
                
                foreach (var interacao in listaDeInteracoes)
                {
                    interacao.NumerosDeSerie = mapeadorDeNumeroDeSerie.ConsulteTodosPorInteracao(interacao.Codigo);
                }
            }

            return listaDeInteracoes;
        }

        public Interacao Consulte(int codigoDaInteracao)
        {
            var interacao = new Interacao();
            using (var mapeadorDeInteracao = new MapeadorDeInteracao())
            using (var mapeadorDeNumeroDeSerie = new MapeadorDeNumeroDeSerie())
            {
                interacao = mapeadorDeInteracao.Consulte(codigoDaInteracao);
                interacao.NumerosDeSerie = mapeadorDeNumeroDeSerie.ConsulteTodosPorInteracao(codigoDaInteracao);
            }

            return interacao;
        }

        public List<Inconsistencia> Salve(Interacao interacao, EnumTipoDeForm tipoDoForm, DateTime horario)
        {
            var listaDeInconsistencias = new List<Inconsistencia>();

            using (var validadorDeInteracao = new ValidadorDeInteracao())
            {
                listaDeInconsistencias = validadorDeInteracao.Valide(interacao);
            }

            if (listaDeInconsistencias.Count == 0)
            {
                using (var mapeadorDeInteracao = new MapeadorDeInteracao())
                using (var mapeadorDeNumeroDeSerie = new MapeadorDeNumeroDeSerie())
                using (var servicoDeProduto = new ServicoDeProduto())
                {
                    interacao.Horario = horario;
                    interacao.Codigo = mapeadorDeInteracao.ObtenhaProximoCodigoDisponivel();
                    mapeadorDeInteracao.Insira(interacao);

                    foreach (var numeroDeSerie in interacao.NumerosDeSerie)
                    {
                        mapeadorDeNumeroDeSerie.Insira(numeroDeSerie, interacao.Codigo, interacao.Produto.Codigo);
                    }

                    int quantidadeInterada = 0;
                    int quantidadeInteradaAux = 0;
                    switch (interacao.TipoDeInteracao)
                    {
                        case EnumTipoDeInteracao.ENTRADA:
                            quantidadeInterada = interacao.QuantidadeInterada;
                            break;

                        case EnumTipoDeInteracao.SAIDA:
                            quantidadeInterada = interacao.QuantidadeInterada * (-1);
                            break;

                        case EnumTipoDeInteracao.BASE_DE_TROCA:
                            // Entrada
                            quantidadeInterada = interacao.QuantidadeInterada;

                            // Saída
                            quantidadeInteradaAux = interacao.QuantidadeAuxiliar.GetValueOrDefault() * (-1);
                            break;
                    }

                    var produtoConsultado = servicoDeProduto.Consulte(interacao.Produto.Codigo);

                    // Nesse caso atualizamos o produto com o novo valor
                    if (interacao.AtualizarValorDoProdutoNoCatalogo)
                    {
                        var valorDoProduto = interacao.TipoDeInteracao == EnumTipoDeInteracao.ENTRADA
                                           ? produtoConsultado.PrecoDeCompra
                                           : produtoConsultado.PrecoDeVenda;
                        
                        // Só devemos criar uma nova vigência, caso o valor seja diferente, senão é desnecessário
                        if (interacao.ValorInteracao != valorDoProduto)
                        {
                            if (interacao.TipoDeInteracao == EnumTipoDeInteracao.ENTRADA)
                            {
                                produtoConsultado.PrecoDeCompra = interacao.ValorInteracao;
                            }
                            else
                            {
                                produtoConsultado.PrecoDeVenda = interacao.ValorInteracao;
                            }

                            servicoDeProduto.Salve(produtoConsultado, EnumTipoDeForm.Edicao);
                        }
                    }

                    servicoDeProduto.AltereQuantidadeDeProduto(produtoConsultado.Codigo,
                                                               produtoConsultado.QuantidadeEmEstoque + quantidadeInterada + quantidadeInteradaAux);
                }
            }

            return listaDeInconsistencias;
        }
        
        private List<Interacao> ConsultePorNumeroDeSerie(string numeroDeSerie)
        {
            var listaDeRetorno = new List<Interacao>();
            List<int> codigosDasInteracoes;
            using (var mapeadorDeNumeroDeSerie = new MapeadorDeNumeroDeSerie())
            {
                codigosDasInteracoes = mapeadorDeNumeroDeSerie.ConsulteTodosOsCodigosDeInteracoesDeUmNumero(numeroDeSerie);
            }
            
            foreach (var codigo in codigosDasInteracoes)
            {
                listaDeRetorno.Add(Consulte(codigo));
            }
            
            return listaDeRetorno;
        }
        
        public bool VerifiqueSeNumeroDeSerieEstahEmEstoque(string numeroDeSerie)
        {
            var listaDeInteracoes = ConsultePorNumeroDeSerie(numeroDeSerie);

            var numeroDeEntradas = listaDeInteracoes.Where(x => x.TipoDeInteracao == EnumTipoDeInteracao.ENTRADA).Count();
            var numeroDeSaidas = listaDeInteracoes.Where(x => x.TipoDeInteracao == EnumTipoDeInteracao.SAIDA).Count();

            return (numeroDeEntradas > numeroDeSaidas);
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~ServicoDeInteracao() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }

        #endregion
    }
}
