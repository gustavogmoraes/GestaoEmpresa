using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns;
using System;
using System.Linq;
using System.Linq.Expressions;
using GS.GestaoEmpresa.Business.Objects.Core;
using GS.GestaoEmpresa.Solucao.Utilitarios;
using GS.GestaoEmpresa.Persistence.Repositories;
using System.Threading.Tasks;

namespace GS.GestaoEmpresa.Business.Services
{
    public class UserService : IDisposable
    {
        private static Expression<Func<User, object>>[] DefaultPropertiesToSearch => new Expression<Func<User, object>>[]
        {
            x => x.Name, x => x.Code
        };

        private static Expression<Func<User, object>> DefaultSelector => x => new User
        {
            Code = x.Code,
            Id = x.Id,
            Name = x.Name,
            Password = x.Password,
            UISettings = x.UISettings
        };

        public async Task CreateAdminUser()
        {
            var userRepository = new UserRepository();
            await userRepository.InsertAsync(new User
            {
                Code = 1,
                Status = EnumStatusToggle.Active,
                Name = "admin",
                Password = "admin".GetDeterministicHashCode(),
            });
        }

        public async Task InsertAsync(string nome, string senha)
        {
            var userRepository = new UserRepository();
            await userRepository.InsertAsync(new User
            {
                Code = await userRepository.GetNextAvailableCodeAsync(),
                Status = EnumStatusToggle.Active,
                Name = nome,
                Password = senha.GetDeterministicHashCode(),
            });
        }

        public async Task UpdateUiSettings(int codigoUsuario, UISettings setting)
        {
            var repositorioDeUsuario = new UserRepository();
            var usuario = await repositorioDeUsuario.QueryFirstAsync(codigoUsuario);
            usuario.UISettings = setting;

            Task.Run(async () => await repositorioDeUsuario.UpdateAsync(usuario)).Wait();
        }

        public async Task<User> Query(int code)
        {
            var repositorioDeUsuario = new UserRepository();
            return await repositorioDeUsuario.QueryFirstAsync(code);
        }

        public async Task<User> Query(string nome)
        {
            var userRepository = new UserRepository();
            return (await userRepository.QueryAsync(nome, DefaultPropertiesToSearch, DefaultSelector)).FirstOrDefault();
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
