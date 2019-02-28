using GS.GestaoEmpresa.Solucao.Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.GestaoEmpresa.Solucao.Negocio.Objetos
{
    public class Telefone
    {
        public string Numero { get; set; }

        public string Descricao { get; set; }

        public bool Principal { get; set; }

        public string DDI { get; set; }

        public string DDD { get; set; }

       // public int Codigo { get; set; }
    }
}
