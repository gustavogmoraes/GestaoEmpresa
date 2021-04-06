using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.GestaoEmpresa.Solucao.Negocio.Objetos
{
    public class Unidade
    {
        public string Nome { get; set; }

        public Endereco Endereco { get; set; }

        public string Localizacao { get; set; }

        public List<Telefone> Telefones { get; set; }

        public List<Email> Emails { get; set; }
    }
}
