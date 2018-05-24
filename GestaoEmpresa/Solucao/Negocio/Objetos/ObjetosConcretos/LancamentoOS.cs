using System;
using System.Collections.Generic;

namespace GS.GestaoEmpresa.Solucao.Negocio.Objetos.ObjetosConcretos
{
    public class LancamentoOS
    {
        public Dictionary<string, decimal> Lancamentos { get; set; }

        public decimal ValorTotal { get; set; }
    }
}
