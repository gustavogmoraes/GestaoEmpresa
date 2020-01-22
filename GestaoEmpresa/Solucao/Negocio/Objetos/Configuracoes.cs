using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GS.GestaoEmpresa.Solucao.Negocio.Interfaces;

namespace GS.GestaoEmpresa.Solucao.Negocio.Objetos
{
    public class Configuracoes : IConceito
    {
        public int Codigo { get; set; }

        public decimal PorcentagemImpostoProtege { get; set; }

        public decimal PorcentagemDeLucroPadrao { get; set; }
    }
}
