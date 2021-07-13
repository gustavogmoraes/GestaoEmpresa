using GS.GestaoEmpresa.Persistence.RavenDbSupport.Objects;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Seguros.TipoDePessoa;

namespace GS.GestaoEmpresa.Solucao.Negocio.Objetos.Base
{
    public class Pessoa : RavenDbDocumentWithRevision
    {
        public string Nome { get; set; }

        public string Cpfcnpj { get; set; }

        public EnumTiposDePessoa TipoDePessoa { get; set; }
    }
}
