using GS.GestaoEmpresa.Solucao.Negocio.Interfaces;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos.Base;
using System;
using System.Collections.Generic;

namespace GS.GestaoEmpresa.Solucao.Negocio.Objetos
{
    public class Colaborador : Pessoa, IConceitoComHistorico
    {
        public int Codigo { get; set; }

        public string Sobrenome { get; set; }

        public string CPF { get; set; }

        public string RG { get; set; }

        //public List<Email> Emails { get; set; }

        public string Cargo { get; set; }

        public string Funcao { get; set; }

        public DateTime Vigencia { get; set; }

        public bool Atual { get; set; }
    }
}
