﻿using System;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos.Atributos;

namespace GS.GestaoEmpresa.Solucao.Negocio.Objetos.ObjetosConcretos
{
    public class Interacao
    {
        public int Codigo { get; set; }

        public DateTime Horario { get; set; }

        public EnumTipoInteracao TipoInteracao { get; set; }

        public string Descricao { get; set; }

        public Produto Produto { get; set; }
        
        public List<string> NumerosDeSerie { get; set; }

        public int QuantidadeInterada { get; set; }

        public decimal ValorInteracao { get; set; }
        
        public bool AtualizarValorDoProdutoNoCatalogo { get; set; }

        public string Origem { get; set; }

        public string Destino { get; set; }

        public string Observacao { get; set; }

        //public Funcionario FuncionarioResponsavel { get; set; }

        //public OrdemServico OrdemDeServico { get; set; }
    }
}
