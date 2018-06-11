using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos.Atributos;
using System.Collections.Generic;

namespace GS.GestaoEmpresa.Solucao.Negocio.Objetos.ObjetosConcretos
{
    public class Cliente
    {
        [BancoDeDados(EhChave = true)]
		public int Codigo {get; set;}
		
        [BancoDeDados(QuantidadeCaracteres = 1)]
		public bool Status {get; set;}
		
        [BancoDeDados(QuantidadeCaracteres = 100)]
		public string Nome {get; set;}

        [BancoDeDados(QuantidadeCaracteres = 100)]
		public string NomeFantasia { get; set; }

        [BancoDeDados(QuantidadeCaracteres = 1000)]
        public string Descricao { get; set; }

        [BancoDeDados(QuantidadeCaracteres = 1)]
        public bool PessoaJuridica {get; set;}

        [BancoDeDados(QuantidadeCaracteres = 16)]
        public string CPFCNPJ {get; set;}

        [BancoDeDados(QuantidadeCaracteres = 16)]
        public string RG {get; set;}

        [BancoDeDados(QuantidadeCaracteres = 10)]
        public string InscricaoEstadual {get; set;}

        [BancoDeDados(QuantidadeCaracteres = 10)]
        public string InscricaoMunicipal { get; set; }
		
        public int Grupo {get; set;}

        [BancoDeDados(QuantidadeCaracteres = 1)]
        public bool Contrato {get; set;}

        [BancoDeDados(QuantidadeCaracteres = 5000)]
        public string Observacao {get; set;}
		
        [BancoDeDados(TipoDeRelacionamento = EnumTipoDeEntidadeRelacional.UmParaMuitos)]
		public List<Endereco> Enderecos {get; set;}

        [BancoDeDados(TipoDeRelacionamento = EnumTipoDeEntidadeRelacional.UmParaMuitos)]
        public List<Telefone> Telefones {get; set;}

        [BancoDeDados(TipoDeRelacionamento = EnumTipoDeEntidadeRelacional.UmParaMuitos)]
        public List<Email> Emails { get; set; }
    }
}
