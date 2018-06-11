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
            {
                listaDeInteracoes = mapeadorDeInteracao.ConsulteTodasAsInteracoes();
            }

            return listaDeInteracoes;
        }

        public List<Interacao> ConsulteTodasAsInteracoesPorProduto(int codigoProduto)
        {
            var listaDeInteracoes = new List<Interacao>();
            using (var mapeadorDeInteracao = new MapeadorDeInteracao())
            {
                listaDeInteracoes = mapeadorDeInteracao.ConsulteTodasInteracoesPorProduto(codigoProduto);
            }

            return listaDeInteracoes;
        }

        public Interacao Consulte(int codigoInteracao)
        {
            var interacao = new Interacao();
            using (var mapeadorDeInteracao = new MapeadorDeInteracao())
            {
                interacao = mapeadorDeInteracao.Consulte(codigoInteracao);
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
                {
                    interacao.Horario = horario;
                    interacao.Codigo = mapeadorDeInteracao.ObtenhaProximoCodigoDisponivel();
                    mapeadorDeInteracao.Insira(interacao);
                }

                var quantidadeInterada = interacao.TipoInteracao == EnumTipoInteracao.Entrada
                                       ? interacao.QuantidadeInterada
                                       : interacao.QuantidadeInterada * (-1);

                var produto = interacao.Produto;
                produto.QuantidadeEmEstoque = produto.QuantidadeEmEstoque + quantidadeInterada;

                using (var servicoDeProduto = new ServicoDeProduto())
                {
                    servicoDeProduto.Salve(produto, EnumTipoDeForm.Edicao);
                }
            }

            return listaDeInconsistencias;
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
