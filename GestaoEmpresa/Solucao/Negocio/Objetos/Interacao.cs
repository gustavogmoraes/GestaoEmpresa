﻿using System;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores;
using System.Collections.Generic;
using System.Data;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns;
using GS.GestaoEmpresa.Solucao.Negocio.Interfaces;

namespace GS.GestaoEmpresa.Solucao.Negocio.Objetos
{
    public class Interacao : IConceito
    {
        public Interacao()
        {
            NumerosDeSerie = new List<string>();
        }

        public int Codigo { get; set; }

        public DateTime Horario { get; set; }

        public DateTime HorarioProgramado { get; set; }

        public EnumTipoDeInteracao TipoDeInteracao { get; set; }

        public Produto Produto { get; set; }

        public bool InformaNumeroDeSerie { get; set; }
        
        public List<string> NumerosDeSerie { get; set; }

        public int QuantidadeInterada { get; set; }

        public int? QuantidadeAuxiliar { get; set; }

        public decimal ValorInteracao { get; set; }
        
        public bool AtualizarValorDoProdutoNoCatalogo { get; set; }

        public string Origem { get; set; }

        public string Destino { get; set; }

        public string Observacao { get; set; }

        public string NumeroDaNota { get; set; }

        public string  Tecnico { get; set; }

        public string Finalidade { get; set; }

        public string Situacao { get; set; }

        public DateTime? HorarioDevolucao { get; set; }
        public string Id { get; set; }

        //public Funcionario FuncionarioResponsavel { get; set; }

        //public OrdemServico OrdemDeServico { get; set; }
    }
}
