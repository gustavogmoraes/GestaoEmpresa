
using GS.GestaoEmpresa.Solucao.Persistencia.Mapeamentos.Base;
using GS.GestaoEmpresa.Solucao.Persistencia.Repositorios;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Seguros.Conceito;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;

namespace GS.GestaoEmpresa.Solucao.Persistencia.Mapeamentos
{
    public class MapeamentoDeColaborador : MapeamentoDeObjeto<Colaborador>
    {
        public MapeamentoDeColaborador()
        {
            Tabela = "COLABORADORES";

            Mapeia(x => x.Codigo, "CODIGO");
            Mapeia(x => x.Nome, "NOME");

            Contem(
                x => x.Telefones,
                typeof(RepositorioDeTelefone),
                (repositorio, x) => (repositorio as RepositorioDeTelefone).Salve(Conceito.Colaborador, x.Codigo, x.Telefones),
                (repositorio, x) => repositorio.Consulte(Conceito.Colaborador, x.Codigo),
                (repositorio, x) => repositorio.Exclua(Conceito.Colaborador, x.Codigo));
        }
    }
}
