using GS.GestaoEmpresa.Solucao.Negocio.Interfaces;

namespace GS.GestaoEmpresa.Solucao.Negocio.Objetos
{
    public class Endereco
    {
        public int Codigo { get; set; }

        public string Logradouro { get; set; }

        public string Complemento { get; set; }

        public string Bairro { get; set; }

        public string CEP { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        public string Pais { get; set; }
        public string Numero { get; internal set; }
        public string Localizacao { get; internal set; }
    }
}
