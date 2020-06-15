using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GS.GestaoEmpresa.Solucao.Negocio.Interfaces;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos.Base;

namespace GS.GestaoEmpresa.Solucao.Negocio.Objetos
{
    class ClienteAntigo : IConceito
    {
        public string Id { get; set; }

        public int Codigo { get; set; }

        public string DataDoAntigoCadastro { get; set; }

        public string Nome { get; set; }

        public string DataNascimento { get; set; }

        public string NomePai { get; set; }

        public string Sexo { get; set; }

        public string NomeMae { get; set; }

        public string Conjuge { get; set; }

        public string Escolaridade { get; set; }

        public string CNPJ { get; set; }

        public string Naturalidade { get; set; }

        public string InscricaoEstadual { get; set; }

        public string Telefone1 { get; set; }

        public string CPF { get; set; }

        public string Telefone2 { get; set; }

        public string Identidade { get; set; }

        public string FoneContato { get; set; }

        public string CEP { get; set; }

        public string Contato { get; set; }

        public string Estado { get; set; }

        public string Endereco { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string PontoDeReferencia { get; set; }

        public string Email { get; set; }

        public string Site { get; set; }

        public string Observacoes { get; set; }
    }
}
