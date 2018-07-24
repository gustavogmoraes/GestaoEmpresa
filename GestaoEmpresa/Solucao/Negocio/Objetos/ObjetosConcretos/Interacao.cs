using System;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos.Atributos;
using System.Collections.Generic;

namespace GS.GestaoEmpresa.Solucao.Negocio.Objetos.ObjetosConcretos
{
    public class Interacao
    {
        public Interacao()
        {
            NumerosDeSerie = new List<string>();
        }

        public int Codigo { get; set; }

        public DateTime Horario { get; set; }

        public EnumTipoDeInteracao TipoDeInteracao { get; set; }

        public string Descricao { get; set; }

        public Produto Produto { get; set; }
        
        public List<string> NumerosDeSerie { get; set; }

        public int QuantidadeInterada { get; set; }

        public decimal ValorInteracao { get; set; }
        
        public bool AtualizarValorDoProdutoNoCatalogo { get; set; }

        public string Origem { get; set; }

        public string Destino { get; set; }

        public string Observacao { get; set; }

        public string NumeroDaNota { get; set; }

        //public Funcionario FuncionarioResponsavel { get; set; }

        //public OrdemServico OrdemDeServico { get; set; }
    }
}
