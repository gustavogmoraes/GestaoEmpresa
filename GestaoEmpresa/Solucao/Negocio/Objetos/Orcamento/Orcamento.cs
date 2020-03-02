using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GS.GestaoEmpresa.Solucao.Negocio.Interfaces;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos.Base;

namespace GS.GestaoEmpresa.Solucao.Negocio.Objetos.Orcamento
{
    public class Orcamento : ObjetoComHistorico
    {
        public string Id { get; set; }

        public int Sequencial { get; set; }

        public string Descricao { get; set; }

        public Cliente Cliente { get; set; }

        public List<ItemOrcamento> Itens { get; set; }
    }
}
