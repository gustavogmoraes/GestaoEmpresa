using GS.GestaoEmpresa.Solucao.Persistencia.Repositorios;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using System;
using System.Linq;
using GS.GestaoEmpresa.Solucao.Utilitarios;

namespace GS.GestaoEmpresa.Solucao.Negocio.Servicos
{
    public class ServicoDeUsuario : IDisposable
    {
        public void CrieUsuarioAdministrador()
        {
            using (var repositorioDeUsuario = new RepositorioDeUsuario())
            {
                repositorioDeUsuario.Insira(
                    new Usuario
                    {
                        Codigo = 1,
                        Status = EnumStatusDoUsuario.Ativo,
                        Nome = "admin",
                        Senha = "admin".GetDeterministicHashCode(),
                    });
            }
        }

        public Usuario Consulte(int codigo)
        {
            using (var repositorioDeUsuario = new RepositorioDeUsuario())
                return repositorioDeUsuario.Consulte(codigo);
        }

        public Usuario Consulte(string nome)
        {
            using (var repositorioDeUsuario = new RepositorioDeUsuario())
                return repositorioDeUsuario.Consulte(x => x.Nome.Contains(nome)).FirstOrDefault();
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
        // ~ServicoDeUsuario() {
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
