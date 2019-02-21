using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Seguros.Conceito;
using GS.GestaoEmpresa.Solucao.Negocio.Validador.Base;
using GS.GestaoEmpresa.Solucao.Persistencia.Repositorios.RepositoriosAbstratos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.GestaoEmpresa.Solucao.Negocio.Servicos.Base
{
    public abstract class ServicoPadrao<TConceito, TValidador, TRepositorio> : IDisposable
        where TConceito : Conceito, new()
        where TValidador : ValidadorPadrao<TConceito>, IDisposable, new()
        where TRepositorio : RepositorioPadrao<TConceito>, IDisposable, new()
    {
        protected TValidador _validador { get; set; }

        protected TRepositorio _repositorio { get; set; }

        public ServicoPadrao()
        {
            _validador = new TValidador();
            _repositorio = new TRepositorio();
        }

        public void Salve(TConceito item)
        {

        }

        public void Exclua(int codigo)
        {

        }

        public void Dispose()
        {
            _validador.Dispose();
            _repositorio.Dispose();
        }
    }
}
