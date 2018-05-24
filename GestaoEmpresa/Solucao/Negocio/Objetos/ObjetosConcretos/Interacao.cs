using System;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos.Atributos;

namespace GS.GestaoEmpresa.Solucao.Negocio.Objetos.ObjetosConcretos
{
    public class Interacao
    {
        public int Codigo { get; set; }

        public DateTime Horario { get; set; }

        public EnumTipoInteracao TipoInteracao { get; set; }

        //Compra, Venda, Empréstimo, etc...
        public string Motivo { get; set; }

        public string Descricao { get; set; }

        public Produto Produto { get; set; }

        public int QuantidadeInterada { get; set; }

        public decimal ValorInteracao { get; set; }

        public string OrigemDestino { get; set; }

        public string Observacao { get; set; }

        public Funcionario FuncionarioResponsavel { get; set; }

        public OrdemServico OrdemDeServico { get; set; }
    }
}
