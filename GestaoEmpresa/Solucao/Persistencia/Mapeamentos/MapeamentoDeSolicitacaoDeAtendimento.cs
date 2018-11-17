using GS.GestaoEmpresa.Solucao.Persistencia.Mapeamentos.Base;
using GS.GestaoEmpresa.Solucao.Persistencia.Repositorios;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using System;

namespace GS.GestaoEmpresa.Solucao.Persistencia.Mapeamentos
{
    public class MapeamentoDeSolicitacaoDeAtendimento : MapeamentoDeObjeto<SolicitacaoDeAtendimento>
    {
        public MapeamentoDeSolicitacaoDeAtendimento()
        {
            Tabela = "SOLICITACOES_DE_ATENDIMENTO";

            Mapeia(x => x.Codigo, "CODIGO");
            Mapeia(x => x.Descricao, "DESCRICAO");

            Referencia(
                x => x.Cliente,
                "CODIGO_CLIENTE",
                typeof(RepositorioDeCliente),
                (repositorio, valorColuna) => repositorio.Consulte(Convert.ToInt32(valorColuna)));

            Referencia(
                x => x.TecnicoResponsavel,
                "CODIGO_COLABORADOR",
                typeof(RepositorioDeColaborador),
                (repositorio, valorColuna) => repositorio.Consulte(Convert.ToInt32(valorColuna)));
        }
    }
}
