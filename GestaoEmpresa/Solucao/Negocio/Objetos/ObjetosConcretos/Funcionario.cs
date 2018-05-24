using GS.GestaoEmpresa.Solucao.Negocio.Objetos.Atributos;
using System.Collections.Generic;

namespace GS.GestaoEmpresa.Solucao.Negocio.Objetos.ObjetosConcretos
{
    public class Funcionario
    {
        public int Codigo { get; set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public string CPF { get; set; }

        public string RG { get; set; }

        public List<Telefone> Telefones { get; set; }

        public List<Email> Emails { get; set; }

        public List<Endereco> Enderecos { get; set; }

        public string Cargo { get; set; }

        public string Funcao { get; set; }
    }
}
