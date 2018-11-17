using System;

namespace GS.GestaoEmpresa.Solucao.Negocio.Atributos
{
    public class Validacao : Attribute
    {
        public bool Obrigatorio { get; set; }

        public int ValorMinimo { get; set; }

        public int ValorMaximo { get; set; }

        public int TamanhoMinimo { get; set; }

        public int TamanhoMaximo { get; set; }

        public string Dominio { get; set; }

        public Validacao()
        {
        }
    }
}
