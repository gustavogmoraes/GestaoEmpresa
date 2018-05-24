using System;
namespace GS.GestaoEmpresa.Solucao.Negocio.Objetos.Atributos
{
    public class ValidacaoBasica : Attribute
    {
        public bool Obrigatorio { get; set; }

        public int TamanhoMinimo { get; set; }

        public int TamanhoMaximo { get; set; }

        public decimal ValorMinimo { get; set; }

        public decimal ValorMaximo { get; set; }

        public string[] Dominio { get; set; }

        public ValidacaoBasica()
        {
        }
    }
}
