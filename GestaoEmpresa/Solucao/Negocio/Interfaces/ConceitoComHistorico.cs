using GS.GestaoEmpresa.Solucao.Negocio.Atributos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.GestaoEmpresa.Solucao.Negocio.Interfaces
{
    public class ConceitoComHistorico : IConceito
    {
        [Identificacao(Descricao = "Código")]
        public int Codigo { get; set; }

        public DateTime Vigencia { get; set; }

        public bool Atual { get; set; }
    }
}
