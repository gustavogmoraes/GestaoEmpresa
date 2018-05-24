using System;
using System.Collections.Generic;
using System.Data;
using GS.GestaoEmpresa.Solucao.Mapeador.BancoDeDados;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos.ObjetosConcretos;
using GS.GestaoEmpresa.Solucao.Utilitarios;
using GS.GestaoEmpresa.Solucao.Mapeador.Mapeadores.MapeadoresConcretos;
using GS.GestaoEmpresa.Solucao.Negocio.Catalogos;

namespace GS.GestaoEmpresa.Solucao.Negocio.Validador
{
    public class ValidadorDeProduto : IDisposable
    {
        private Produto _produto { get; set; }

        private Produto _produtoAnterior { get; set; }

        private List<Inconsistencia> _listaDeInconsistencias { get; set; }

        public List<Inconsistencia> ValideSalvar(Produto produto)
        {
            _produto = produto;
            _listaDeInconsistencias = new List<Inconsistencia>();

            if (EhCadastro(produto.Codigo))
            {
                ValideRegraObrigatoriedades();
            }
            else
            {
                ValideRegraNaoHouveAlteracao();
            }

            return _listaDeInconsistencias;
        }

        private void ValideRegraObrigatoriedades()
        {
            //Nada ainda
        }

        private void ValideRegraNaoHouveAlteracao()
        {
            if (_produtoAnterior.HashCode == _produto.HashCode)
            {
                _listaDeInconsistencias.Add(
                    new Inconsistencia()
                    {
                        Modulo = "Controle de Estoque",
                        Tela = "Cadastro de Produtos",
                        ConceitoValidado = "Produto",
                        Mensagem = Mensagens.NADA_FOI_ALTERADO
                    });
            }
        }

        private bool EhCadastro(int codigoDoProduto)
        {
            Produto produtoConsultado;
            using (var mapeadorDeProduto = new MapeadorDeProduto())
            {
                produtoConsultado = mapeadorDeProduto.Consulte(codigoDoProduto);
            }

            if (produtoConsultado == null)
            {
                return true;
            }

            _produtoAnterior = produtoConsultado;
            return false;
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