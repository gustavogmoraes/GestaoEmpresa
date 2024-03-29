using System;
using System.Linq;
using System.Collections.Generic;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using GS.GestaoEmpresa.Solucao.Negocio.Catalogos;
using GS.GestaoEmpresa.Solucao.Negocio.Servicos;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns;
using GS.GestaoEmpresa.Solucao.Negocio.Validador.Base;
using GS.GestaoEmpresa.Solucao.Persistencia.Repositorios;
using MoreLinq;

namespace GS.GestaoEmpresa.Solucao.Negocio.Validador
{
    public class ValidadorDeInteracao : ValidadorPadrao<Interacao>, IDisposable
    {
        #region Propriedades

        private Interacao _interacao { get; set; }

        private List<Inconsistencia> _listaDeInconsistencias { get; set; }

        private RepositorioDeProduto _mapeadorDeProduto;

        private RepositorioDeInteracao _mapeadorDeInteracao;

        private RepositorioDeProduto RepositorioDeProduto()
        {
            return _mapeadorDeProduto ?? (_mapeadorDeProduto = new RepositorioDeProduto());
        }

        private RepositorioDeInteracao RepositorioDeInteracao()
        {
            return _mapeadorDeInteracao ?? (_mapeadorDeInteracao = new RepositorioDeInteracao());
        }

        #endregion

        #region Implementação Padrão

        public override IList<Inconsistencia> ValideCadastro(Interacao item)
        {
            _interacao = item;
            _listaDeInconsistencias = new List<Inconsistencia>();

            ValideRegraObrigatoriedades();
            ValideRegrasDeNumeroDeSerie();
            ValideRegraQuantidades();

            return _listaDeInconsistencias;
        }

        // Conceito não possui edição
        public override IList<Inconsistencia> ValideEdicao(Interacao item)
        {
            return new List<Inconsistencia>();
        }

        public override IList<Inconsistencia> ValideExclusao(int codigo)
        {
            var interacao = RepositorioDeInteracao().Consulte(codigo);

            var listaDeInteracoes = RepositorioDeInteracao().Consulte(x => x.Produto.Codigo == interacao.Produto.Codigo);
            var ultimaInteracaoComEsseProduto = listaDeInteracoes.MaxBy(x => x.Horario);

            var listaDeInconsistencias = new List<Inconsistencia>();
            if (codigo != ultimaInteracaoComEsseProduto.Codigo)
            {
                listaDeInconsistencias.Add(
                    new Inconsistencia()
                    {
                        Modulo = "Controle de Estoque",
                        Tela = "Cadastro de Interações",
                        ConceitoValidado = "Interação",
                        NomeDaPropriedadeValidada = "Interação",
                        DescricaoDaPropriedadeValidada = "Interação",
                        Mensagem = $"Não é possível deletar essa interação porque ela não é a última interação com o produto {interacao.Produto.Codigo} - {interacao.Produto.Nome}."
                    });
            }

            return listaDeInconsistencias;
        }

        #endregion

        #region Regras de validação

        private void ValideRegraObrigatoriedades()
        {
            if (_interacao.Produto == null || _interacao.Produto.Codigo == 0)
            {
                _listaDeInconsistencias.Add(
                    new Inconsistencia()
                    {
                        Modulo = "Controle de Estoque",
                        Tela = "Cadastro de Interações",
                        ConceitoValidado = "Interação",
                        NomeDaPropriedadeValidada = "Produto",
                        DescricaoDaPropriedadeValidada = "Produto da entrada/saída",
                        Mensagem = Mensagens.X_DEVE_SER_SELECIONADO("Um produto")
                    });
            }

            if (_interacao.QuantidadeInterada == 0 && _interacao.TipoDeInteracao != EnumTipoDeInteracao.BASE_DE_TROCA)
            {
                _listaDeInconsistencias.Add(
                    new Inconsistencia()
                    {
                        Modulo = "Controle de Estoque",
                        Tela = "Cadastro de Interações",
                        ConceitoValidado = "Interação",
                        NomeDaPropriedadeValidada = "QuantidadeInterada",
                        DescricaoDaPropriedadeValidada = "Quantidade movimentada do produto",
                        Mensagem = Mensagens.X_DEVE_SER_INFORMADO("Uma quantidade de produto para movimentação")
                    });
            }

            if (string.IsNullOrEmpty(_interacao.Origem))
            {
                _listaDeInconsistencias.Add(
                    new Inconsistencia()
                    {
                        Modulo = "Controle de Estoque",
                        Tela = "Cadastro de Interações",
                        ConceitoValidado = "Interação",
                        NomeDaPropriedadeValidada = "Origem",
                        DescricaoDaPropriedadeValidada = "Origem",
                        Mensagem = Mensagens.X_DEVE_SER_INFORMADO("Uma origem")
                    });
            }

            if (string.IsNullOrEmpty(_interacao.Destino))
            {
                _listaDeInconsistencias.Add(
                    new Inconsistencia()
                    {
                        Modulo = "Controle de Estoque",
                        Tela = "Cadastro de Interações",
                        ConceitoValidado = "Interação",
                        NomeDaPropriedadeValidada = "Destino",
                        DescricaoDaPropriedadeValidada = "Destino",
                        Mensagem = Mensagens.X_DEVE_SER_INFORMADO("Um destino")
                    });
            }
        }

        private void ValideRegrasDeNumeroDeSerie()
        {
            // Números incompativeis com a quantidade
            if (_interacao.InformaNumeroDeSerie && _interacao.NumerosDeSerie.Count != _interacao.QuantidadeInterada)
            {
                _listaDeInconsistencias.Add(
                    new Inconsistencia()
                    {
                        Modulo = "Controle de Estoque",
                        Tela = "Cadastro de Interações",
                        ConceitoValidado = "Interação",
                        NomeDaPropriedadeValidada = "NumerosDeSerie",
                        DescricaoDaPropriedadeValidada = "Lista de números de série",
                        Mensagem = Mensagens.DEVE_SER_INFORMADOS_NS_PARA_TODOS_OS_PRODUTOS(_interacao.NumerosDeSerie.Count, _interacao.QuantidadeInterada)
                    });
            }

            // Primeiro validamos se existe algum número de série na lista para evitar gastar processamento
            if (_interacao.NumerosDeSerie == null || _interacao.NumerosDeSerie.Count == 0)
            {
                return;
            }

            using (var servicoDeInteracao = new ServicoDeInteracao())
            {
                foreach (var numeroDeSerie in _interacao.NumerosDeSerie)
                {
                    // Consultamos se o número de série existe para evitar gastar processamento
                    if (!servicoDeInteracao.VerifiqueSeNumeroDeSerieExisteNoBanco(numeroDeSerie))
                        continue;

                    var estahEmEstoque = servicoDeInteracao.VerifiqueSeNumeroDeSerieEstahEmEstoque(numeroDeSerie);

                    if (_interacao.TipoDeInteracao == EnumTipoDeInteracao.ENTRADA && estahEmEstoque)
                    {
                        _listaDeInconsistencias.Add(
                            new Inconsistencia()
                            {
                                Modulo = "Controle de Estoque",
                                Tela = "Cadastro de Interações",
                                ConceitoValidado = "Interação",
                                NomeDaPropriedadeValidada = "NumerosDeSerie",
                                DescricaoDaPropriedadeValidada = "Lista de números de série",
                                Mensagem = Mensagens.UM_PRODUTO_COM_O_NUMERO_DE_SERIE_X_JA_ESTA_EM_ESTOQUE(numeroDeSerie)
                            });
                    }

                    if (_interacao.TipoDeInteracao == EnumTipoDeInteracao.SAIDA && !estahEmEstoque)
                    {
                        _listaDeInconsistencias.Add(
                            new Inconsistencia()
                            {
                                Modulo = "Controle de Estoque",
                                Tela = "Cadastro de Interações",
                                ConceitoValidado = "Interação",
                                NomeDaPropriedadeValidada = "NumerosDeSerie",
                                DescricaoDaPropriedadeValidada = "Lista de números de série",
                                Mensagem = Mensagens.NAO_E_POSSIVEL_DAR_SAIDA_DO_NUMERO_DE_SERIE_X(numeroDeSerie)
                            });
                    }
                }
            }
        }

        private void ValideRegraQuantidades()
        {
            if (_interacao.Produto == null)
            {
                return;
            }

            var quantidadeAtual = RepositorioDeProduto().ConsulteQuantidade(_interacao.Produto.Codigo);
            var quantidadeInterada = _interacao.TipoDeInteracao == EnumTipoDeInteracao.SAIDA ? _interacao.QuantidadeInterada * -1 : _interacao.QuantidadeInterada;
            var quantidadeAuxiliar = (_interacao.QuantidadeAuxiliar ?? 0) * -1;

            if ((quantidadeAtual.GetValueOrDefault() + quantidadeInterada + quantidadeAuxiliar) < 0)
            {
                _listaDeInconsistencias.Add(
                    new Inconsistencia()
                    {
                        Modulo = "Controle de Estoque",
                        Tela = "Cadastro de Interações",
                        ConceitoValidado = "Interação",
                        NomeDaPropriedadeValidada = "Produto",
                        DescricaoDaPropriedadeValidada = "Produto da entrada/saída",
                        Mensagem = "Essa interação deixaria o produto com quantidade abaixo de 0!"
                    });
            }
        }

        #endregion

        #region Suporte à IDisposable
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
        // ~ValidadorDeinteracao() {
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
