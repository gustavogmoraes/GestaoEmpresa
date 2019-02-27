using GS.GestaoEmpresa.Solucao.Negocio.Objetos.Base;
using System.Collections.Generic;

namespace GS.GestaoEmpresa.Solucao.Negocio.Objetos
{
    public class Colaborador : Pessoa
    {
        public string Sobrenome { get; set; }

        public string CPF { get; set; }

        public string RG { get; set; }

        public List<Email> Emails { get; set; }

        public string Cargo { get; set; }

        public string Funcao { get; set; }
    }
}
