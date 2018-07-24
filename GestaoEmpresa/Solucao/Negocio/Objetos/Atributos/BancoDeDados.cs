using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores;
using System;

namespace GS.GestaoEmpresa.Solucao.Negocio.Objetos.Atributos
{
    public class BancoDeDados : Attribute
    {
        public string Coluna { get; set; }

        public bool EhChave { get; set; }

        public bool EhNumerico { get; set; }

        public int QuantidadeCaracteres { get; set; }

        public EnumTipoDeEntidadeRelacional TipoDeRelacionamento { get; set; }
    }
}
