using GS.GestaoEmpresa.Persistence.RavenDbSupport.Interfaces;

namespace GS.GestaoEmpresa.Solucao.Negocio.Objetos
{
    public class ProdutoQuantidade : IRavenDbDocument
    {
        public int Codigo { get; set; }

        public int Quantidade { get; set; }

        public string Id { get; set; }
    }
}

