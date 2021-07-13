using System;
using GS.GestaoEmpresa.Persistence.RavenDbSupport.Interfaces;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns;

namespace GS.GestaoEmpresa.Solucao.Negocio.Objetos.Base
{
    public class Old : IRavenDbDocument
    {
        public string Id { get; set; }

        public EnumStatusToggle Status { get; set; }

        public int Codigo { get; set; }

        public bool Atual { get; set; }

        public DateTime Vigencia { get; set; }

    }
}
