using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Seguros.Base;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Seguros.TipoDePessoa;

namespace GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Seguros.UnidadeIntelbras
{
    public class UnidadeIntelbras : TypeSafeEnum<UnidadeIntelbras, EnumUnidadeIntelbras>
    {
        public static readonly UnidadeIntelbras Comunicacao         = new UnidadeIntelbras(EnumUnidadeIntelbras.COMUNICACAO, "COMUNICACAO");
        public static readonly UnidadeIntelbras ControleDeAcesso    = new UnidadeIntelbras(EnumUnidadeIntelbras.CONTROLE_DE_ACESSO, "CONTROLE DE ACESSO");
        public static readonly UnidadeIntelbras Energia             = new UnidadeIntelbras(EnumUnidadeIntelbras.ENERGIA, "ENERGIA");
        public static readonly UnidadeIntelbras Incendio            = new UnidadeIntelbras(EnumUnidadeIntelbras.INCENDIO, "INCENDIO");
        public static readonly UnidadeIntelbras Redes               = new UnidadeIntelbras(EnumUnidadeIntelbras.REDES, "REDES");
        public static readonly UnidadeIntelbras SegurancaEletronica = new UnidadeIntelbras(EnumUnidadeIntelbras.SEGURANCA_ELETRONICA, "SEGURANÇA ELETRONICA");

        public UnidadeIntelbras(EnumUnidadeIntelbras indicador, string nome) : base((int)indicador, nome) { }

        public static UnidadeIntelbras ObtenhaPorNome(string nome) => Lista.FirstOrDefault(x => x.Nome == nome);

        public static List<UnidadeIntelbras> Lista => new List<UnidadeIntelbras>
        {
            Comunicacao, 
            ControleDeAcesso,
            Energia,
            Incendio, 
            Redes, 
            SegurancaEletronica
        };
    }
}
