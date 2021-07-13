using GS.GestaoEmpresa.Persistence.RavenDbSupport.Objects;

namespace GS.GestaoEmpresa.Business.Objects.Core
{
    public class User : RavenDbDocumentWithRevision
    {
        public string Name { get; set; }

        public int Password { get; set; }

        public UISettings UISettings { get; set; }
    }
}
