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
        public string Descricao { get; set; }

        public string Numero { get; set; }

        public string RangeDDR { get; set; }

        public bool EhWhatsApp { get; set; }
    }
}
