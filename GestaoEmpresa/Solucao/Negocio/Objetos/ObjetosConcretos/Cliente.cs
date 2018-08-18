using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos.Atributos;
using System.Collections.Generic;

namespace GS.GestaoEmpresa.Solucao.Negocio.Objetos.ObjetosConcretos
{
    public class Cliente
    {
        [PropriedadeBD(EhChave = true)]
		public int Codigo {get; set;}
		
        [PropriedadeBD(QuantidadeCaracteres = 1)]
		public bool Status {get; set;}
		
        [PropriedadeBD(QuantidadeCaracteres = 100)]
		public string Nome {get; set;}

        [PropriedadeBD(QuantidadeCaracteres = 100)]
		public string NomeFantasia { get; set; }

        [PropriedadeBD(QuantidadeCaracteres = 1000)]
        public string Descricao { get; set; }

        [PropriedadeBD(QuantidadeCaracteres = 1)]
        public bool PessoaJuridica {get; set;}

        [PropriedadeBD(QuantidadeCaracteres = 16)]
        public string CPFCNPJ {get; set;}

        [PropriedadeBD(QuantidadeCaracteres = 16)]
        public string RG {get; set;}

        [PropriedadeBD(QuantidadeCaracteres = 10)]
        public string InscricaoEstadual {get; set;}

        [PropriedadeBD(QuantidadeCaracteres = 10)]
        public string InscricaoMunicipal { get; set; }
		
        public int Grupo {get; set;}

        [PropriedadeBD(QuantidadeCaracteres = 1)]
        public bool Contrato {get; set;}

        [PropriedadeBD(QuantidadeCaracteres = 5000)]
        public string Observacao {get; set;}
		
        [PropriedadeBD(TipoDeRelacionamento = EnumTipoDeEntidadeRelacional.UmParaMuitos)]
		public List<Endereco> Enderecos {get; set;}

        [PropriedadeBD(TipoDeRelacionamento = EnumTipoDeEntidadeRelacional.UmParaMuitos)]
        public List<Telefone> Telefones {get; set;}

        [PropriedadeBD(TipoDeRelacionamento = EnumTipoDeEntidadeRelacional.UmParaMuitos)]
        public List<Email> Emails { get; set; }
    }
}
