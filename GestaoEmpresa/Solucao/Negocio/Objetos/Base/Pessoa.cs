using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Seguros.TipoDePessoa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.GestaoEmpresa.Solucao.Negocio.Objetos.Base
{
    public class Pessoa : ObjetoComHistorico
    {
        public string Nome { get; set; }

        public string Cpfcnpj { get; set; }

        public TipoDePessoa TipoDePessoa { get; set; }

        public Endereco Enderecos { get; set; }

        public List<Telefone> Telefones { get; set; }
    }
}
