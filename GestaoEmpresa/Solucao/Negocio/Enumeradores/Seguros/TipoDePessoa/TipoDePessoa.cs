

using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Seguros.Base;

namespace GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Seguros.TipoDePessoa
{
    public class TipoDePessoa : TypeSafeEnum<TipoDePessoa, EnumTiposDePessoa>
    {
        public static readonly TipoDePessoa Fisica = new TipoDePessoa(EnumTiposDePessoa.FISICA, "Física");
        public static readonly TipoDePessoa Juridica = new TipoDePessoa(EnumTiposDePessoa.JURIDICA, "Jurídica");

        public TipoDePessoa(EnumTiposDePessoa indicador, string nome)
            : base((int)indicador, nome)
        {
        }
    }
}
