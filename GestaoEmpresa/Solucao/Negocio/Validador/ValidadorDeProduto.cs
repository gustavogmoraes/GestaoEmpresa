using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using GS.GestaoEmpresa.Solucao.Negocio.Catalogos;
using GS.GestaoEmpresa.Solucao.Negocio.Servicos;
using GS.GestaoEmpresa.Solucao.Negocio.Validador.Base;
using GS.GestaoEmpresa.Solucao.Persistencia.Repositorios;
using KellermanSoftware.CompareNetObjects;

namespace GS.GestaoEmpresa.Solucao.Negocio.Validador
{
    public class ValidadorDeProduto : ValidadorPadrao<Produto>, IDisposable
    {
        public ValidadorDeProduto()
        {
            _listaDeInconsistencias = new List<Inconsistencia>();
        }

        private Produto _produto { get; set; }

        private Produto _produtoAnterior { get; set; }

        private List<Inconsistencia> _listaDeInconsistencias { get; set; }

        private void ValideRegraProdutoPodeSerExcluido(int codigoDoProduto)
        {
            using (var servicoDeInteracao = new ServicoDeInteracao())
            {
                var listaDeInteracoesPorProduto = servicoDeInteracao.ConsulteTodasAsInteracoesPorProduto(codigoDoProduto);

                if (listaDeInteracoesPorProduto.Count > 0)
                {
                    _listaDeInconsistencias.Add(
                        new Inconsistencia()
                        {
                            Tela = "Consulta de produtos",
                            ConceitoValidado = "Exclusão de produto",
                            Mensagem = Mensagens.X_NAO_PODE_SER_EXCLUIDO("produto")
                        });
                }
            }
        }

        public List<Inconsistencia> ValideCadastroInicial(Produto produto)
        {
            var listaDeInconsistencias = new List<Inconsistencia>();

            Produto produtoConsultado;
            using (var mapeadorDeProduto = new RepositorioDeProduto())
            {
                produtoConsultado = mapeadorDeProduto.Consulte(produto.Codigo);
            }

            if (produtoConsultado != null && (produtoConsultado.Codigo == produto.Codigo || produto.Nome == produto.Nome))
            {
                listaDeInconsistencias.Add(
                    new Inconsistencia()
                    {
                        Mensagem = Mensagens.JA_EXISTE_UM_X_COM_ESSE_Y("Produto", "código ou nome")
                    });
            }

            return listaDeInconsistencias;   
        }

        private void ValideRegraObrigatoriedades()
        {
            //Nada ainda
        }

        private void ValideRegraNaoHouveAlteracao()
        {
            var compareLogic = new CompareLogic
            {
                Config =
                {
                    MembersToIgnore = new List<string>{ "Vigencia", "QuantidadeEmEstoque", "RavenAttachments" }
                }
            };
            //// https://github.com/GregFinzer/Compare-Net-Objects/wiki/Ignoring-Members

            var result = compareLogic.Compare(_produtoAnterior, _produto);
            if (result.AreEqual)
            {
                _listaDeInconsistencias.Add(new Inconsistencia
                {
                    Modulo = "Controle de Estoque",
                    Tela = "Cadastro de Produtos",
                    ConceitoValidado = "Produto",
                    Mensagem = Mensagens.NADA_FOI_ALTERADO
                });
            }
        }

        public override IList<Inconsistencia> ValideCadastro(Produto item)
        {
            _produto = item;

            ValideRegraObrigatoriedades();

            return _listaDeInconsistencias;
        }

        public override IList<Inconsistencia> ValideEdicao(Produto item)
        {
            _produto = item;
            using (var servicoDeProduto = new ServicoDeProduto())
            {
                _produtoAnterior = servicoDeProduto.Consulte(item.Codigo, item.Vigencia.AddSeconds(-1));
            }

            ValideRegraNaoHouveAlteracao();

            return _listaDeInconsistencias;
        }

        public override IList<Inconsistencia> ValideExclusao(int codigo)
        {
            ValideRegraProdutoPodeSerExcluido(codigo);

            return _listaDeInconsistencias;
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
        // ~ValidadorDeProduto() {
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