using System;
using System.Collections.Generic;
using System.Data;
using GS.GestaoEmpresa.Solucao.Persistencia.BancoDeDados;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using GS.GestaoEmpresa.Solucao.Utilitarios;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores;
using GS.GestaoEmpresa.Solucao.UI.Modulos.Estoque;
using System.Runtime.InteropServices;
using GS.GestaoEmpresa.Solucao.Negocio.Validador;
using GS.GestaoEmpresa.Solucao.Persistencia.Repositorios;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns;

namespace GS.GestaoEmpresa.Solucao.Negocio.Servicos
{
    public class ServicoDeProduto : IDisposable
    {
        public List<Produto> ConsulteTodosOsProdutos()
        {
            using (var mapeadorDeProduto = new RepositorioDeProduto())
            {
                return mapeadorDeProduto.ConsulteTodos();
            }
        }

        public List<DateTime> ConsulteTodasAsVigenciasDeUmProduto(int codigoDoProduto)
        {
            var listaDeVigencias = new List<DateTime>();

            using (var mapeadorDeProduto = new RepositorioDeProduto())
            {
                listaDeVigencias = mapeadorDeProduto.ConsulteTodasVigencias(codigoDoProduto);
            }

            return listaDeVigencias;
        }

        public Produto Consulte(int codigo, DateTime data)
        {
            using (var mapeadorDeProduto = new RepositorioDeProduto())
                return mapeadorDeProduto.Consulte(codigo, data);
        }

        public Produto Consulte(int codigo)
        {
            using (var mapeadorDeProduto = new RepositorioDeProduto())
                return mapeadorDeProduto.Consulte(codigo);
        }

        public int ObtenhaProximoCodigoDisponivel()
        {
            int codigo;
            using (var mapeadorDeProduto = new RepositorioDeProduto())
            {
                codigo = mapeadorDeProduto.ObtenhaProximoCodigoDisponivel();
            }

            return codigo;
        }

        public List<Inconsistencia> Exclua(int codigoDoProduto)
        {
            var listaDeInconsistenciasExclusao = new List<Inconsistencia>();
            using (var validadorDeProduto = new ValidadorDeProduto())
            {
                listaDeInconsistenciasExclusao = validadorDeProduto.ValideExcluir(codigoDoProduto);
            }

            if (listaDeInconsistenciasExclusao.Count == 0)
            {
                using (var mapeadorDeProduto = new RepositorioDeProduto())
                {
                    mapeadorDeProduto.Exclua(codigoDoProduto);
                }
            }

            return listaDeInconsistenciasExclusao;
        }

        public List<Inconsistencia> Salve(Produto produto, EnumTipoDeForm tipoDoForm)
        {
            var listaDeInconsistencias = new List<Inconsistencia>();

            if (tipoDoForm == EnumTipoDeForm.Cadastro)
            {
                using (var validadorDeProduto = new ValidadorDeProduto())
                {
                    listaDeInconsistencias = validadorDeProduto.ValideCadastroInicial(produto);
                }

                if (listaDeInconsistencias.Count > 0)
                {
                    return listaDeInconsistencias;
                }
            }

            using (var validadorDeProduto = new ValidadorDeProduto())
            {
                listaDeInconsistencias = validadorDeProduto.ValideSalvar(produto);
            }

            if (listaDeInconsistencias.Count == 0)
            {
                using (var mapeadorDeProduto = new RepositorioDeProduto())
                {
                    mapeadorDeProduto.Insira(produto);

                    if(tipoDoForm == EnumTipoDeForm.Cadastro)
                    {
                        mapeadorDeProduto.InsiraNaTabelaQuantidade(produto.Codigo);
                    }
                }
            }

            return listaDeInconsistencias;
        }

        public void AltereQuantidadeDeProduto(int codigoDoProduto, int novaQuantidade)
        {
            using (var mapeadorDeProduto = new RepositorioDeProduto())
            {
                mapeadorDeProduto.AltereQuantidadeDeProduto(codigoDoProduto, novaQuantidade);
            }
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
        // ~ServicoDeProduto() {
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