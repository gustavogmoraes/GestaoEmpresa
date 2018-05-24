using System;
namespace GS.GestaoEmpresa.Solucao.Negocio.Objetos.Atributos
{
    public enum TipoDeEntidadeRelacional
    {
        UmParaUm,

        UmParaMuitos
    }

    public class BancoDeDados : Attribute
    {
        public string Coluna { get; set; }

        public bool EhChave { get; set; }

        public bool EhNumerico { get; set; }

        public int QuantidadeCaracteres { get; set; }

        public TipoDeEntidadeRelacional TipoDeRelacionamento { get; set; }

        public BancoDeDados()
        {
            
        }

    }
}
