using System;
using System.Collections.Generic;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos.Atributos;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores;

namespace GS.GestaoEmpresa.Solucao.Negocio.Objetos.ObjetosConcretos
{
    public class OrdemServico
    {
        [BancoDeDados(EhChave = true)]
        public int Codigo { get; set; }

        [BancoDeDados(QuantidadeCaracteres = 1000)]
        public string Descricao { get; set; }

        [BancoDeDados(TipoDeRelacionamento = EnumTipoDeEntidadeRelacional.UmParaUm)]
        public Chamado Chamado { get; set; }

        [BancoDeDados(TipoDeRelacionamento = EnumTipoDeEntidadeRelacional.UmParaUm)]
        public Cliente Cliente { get; set; }

        [BancoDeDados(QuantidadeCaracteres = 100)]
        public string Contato { get; set; }

        [BancoDeDados(TipoDeRelacionamento = EnumTipoDeEntidadeRelacional.UmParaUm)]
        public Funcionario Funcionario { get; set; }

        public DateTime HorarioChegada { get; set; }

        public DateTime HorarioSaida { get; set; }

        [BancoDeDados(QuantidadeCaracteres = 5000)]
        public string Observacao { get; set; }

        [BancoDeDados(TipoDeRelacionamento = EnumTipoDeEntidadeRelacional.UmParaMuitos)]
        public List<LancamentoOS> Lancamentos { get; set; }

        public decimal Valor { get; set; }
    }
}
