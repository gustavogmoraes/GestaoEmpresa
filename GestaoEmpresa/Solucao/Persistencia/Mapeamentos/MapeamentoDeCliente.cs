
using GS.GestaoEmpresa.Solucao.Persistencia.Mapeamentos.Base;
using GS.GestaoEmpresa.Solucao.Persistencia.Repositorios;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Seguros.Conceito;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;

namespace GS.GestaoEmpresa.Solucao.Persistencia.Mapeamentos
{ 
    public class MapeamentoDeCliente : MapeamentoDeObjeto<Cliente>
    {
        public MapeamentoDeCliente()
        {
            Tabela = "CLIENTES";

            Mapeia(x => x.Codigo, "CODIGO");
            Mapeia(x => x.Nome, "NOME");
            Mapeia(x => x.CPFCNPJ, "CPFCNPJ");

            Contem(
                x => x.Telefones,
                typeof(RepositorioDeTelefone),
                (repositorio, x) => (repositorio as RepositorioDeTelefone).Salve(Conceito.Cliente, x.Codigo, x.Telefones),
                (repositorio, x) => repositorio.Consulte(Conceito.Cliente, x.Codigo),
                (repositorio, x) => repositorio.Exclua(Conceito.Cliente, x.Codigo));
        }
    }
}
