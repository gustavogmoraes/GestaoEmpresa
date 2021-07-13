using GS.GestaoEmpresa.Business.Objects.Core;
using GS.GestaoEmpresa.Persistence.RavenDbSupport.Interfaces;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns;

namespace GS.GestaoEmpresa.Solucao.Negocio.Objetos
{
    public class Usuario : IRavenDbDocument
    {
        public string Id { get; set; }

        public int Codigo { get; set; }

        public EnumStatusToggle Status { get; set; }

        public string Nome { get; set; }

        public string Senha { get; set; }

        public Employee Funcionario { get; set; }

        public UISettings UISettings { get; set; }
    }
}
