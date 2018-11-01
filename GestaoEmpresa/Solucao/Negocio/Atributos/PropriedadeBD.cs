using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns;
using System;
using System.Data;

namespace GS.GestaoEmpresa.Solucao.Negocio.Atributos
{
    public class PropriedadeBD : Attribute
    {
        public string Coluna { get; set; }

        public bool EhChave { get; set; }

        public int QuantidadeCaracteres { get; set; }

        public DbType TipoDeDadoBanco { get; set; }

        public EnumTipoDeEntidadeRelacional TipoDeRelacionamento { get; set; }
    }
}
