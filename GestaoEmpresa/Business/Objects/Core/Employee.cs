using System.Collections.Generic;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos.Base;

namespace GS.GestaoEmpresa.Business.Objects.Core
{
    public class Employee : Pessoa
    {
        public string Surname { get; set; }

        public string CPF { get; set; }

        public string RG { get; set; }

        public List<Email> Emails { get; set; }

        public string Position { get; set; }

        public string Function { get; set; }
    }
}
