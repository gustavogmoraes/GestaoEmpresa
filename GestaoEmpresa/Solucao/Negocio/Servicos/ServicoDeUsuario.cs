using GS.GestaoEmpresa.Solucao.Mapeador.Mapeadores.MapeadoresConcretos;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos.ObjetosConcretos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.GestaoEmpresa.Solucao.Negocio.Servicos
{
    public class ServicoDeUsuario : IDisposable
    {
        public void CrieUsuarioAdministrador()
        {
            using (var mapeadorDeUsuario = new MapeadorDeUsuario())
            {
                mapeadorDeUsuario.Insira(
                    new Usuario
                    {
                        Codigo = 1,
                        Status = EnumStatusDoUsuario.Ativo,
                        Nome = "admin",
                        Senha = "admin".GetHashCode(),
                    });
            }
        }

        public Usuario Consulte(string nome)
        {
            Usuario usuario;

            using (var mapeadorDeUsuario = new MapeadorDeUsuario())
            {
                usuario = mapeadorDeUsuario.Consulte(nome);
            }

            return usuario;
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
