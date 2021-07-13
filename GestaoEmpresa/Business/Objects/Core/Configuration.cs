using GS.GestaoEmpresa.Persistence.RavenDbSupport.Objects;

namespace GS.GestaoEmpresa.Business.Objects.Core
{
    public class Configuration : RavenDbDocumentWithRevision
    {
        public decimal ProtegeTaxPercentage { get; set; }

        public decimal DefaultSaleProfitPercentage { get; set; }
    }
}
