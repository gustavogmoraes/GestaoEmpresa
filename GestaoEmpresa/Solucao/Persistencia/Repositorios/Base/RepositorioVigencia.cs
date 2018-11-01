using GS.GestaoEmpresa.Solucao.Persistencia.BancoDeDados;
using GS.GestaoEmpresa.Solucao.Persistencia.Mapeamentos.Base;
using GS.GestaoEmpresa.Solucao.Utilitarios;
using System;
using System.Collections.Generic;
using System.Data;

namespace GS.GestaoEmpresa.Solucao.Persistencia.Repositorios.Base
{
    public abstract class RepositorioVigencia<TConceito, TMapeamento> : BaseRepositorios<TConceito, TMapeamento>
        where TConceito : class, new()
        where TMapeamento : MapeamentoDeObjeto<TConceito>
    {
        public void Insira(TConceito conceito, DateTime vigencia)
        {
            var comandoSQL =
                $"INSERT INTO {Mapeamento.Tabela} " +
                $"(VIGENCIA, {Mapeamento.Colunas}) " +
                $"VALUES (" +
                $"CAST ('{GSUtilitarios.FormateDateTimePtBrParaBD(vigencia)}' AS DATETIME2)," +
                $"{ObtenhaValoresInsercao(ref conceito)}" +
                $");";

            using (var GSBancoDeDados = new GSBancoDeDados())
            {
                GSBancoDeDados.ExecuteComando(comandoSQL);
            }
        }

        public TConceito Consulte(int codigo)
        {
            var consultaSQL =
                $"SELECT {Mapeamento.Colunas} " +
                $"FROM {Mapeamento.Tabela} " +
                $"WHERE CODIGO = {codigo} " +
                $"  AND VIGENCIA = (SELECT MAX(VIGENCIA) " +
                $"                  FROM {Mapeamento.Tabela} " +
                $"                  WHERE CODIGO = {codigo})";

            using (var persistencia = new GSBancoDeDados())
            {
                var tabela = persistencia.ExecuteConsulta(consultaSQL);
                if (tabela == null)
                {
                    return null;
                }

                return Mapeamento.MonteConceito(ref tabela, 0);
            }
        }

        public TConceito Consulte(int codigo, DateTime vigencia)
        {
            var comandoSQL =
                $"SELECT {Mapeamento.Colunas} " +
                $"FROM {Mapeamento.Tabela} " +
                $"WHERE CODIGO = {codigo} " +
                $"  AND VIGENCIA = (SELECT MAX(VIGENCIA) " +
                $"                  FROM {Mapeamento.Tabela} " +
                $"                  WHERE VIGENCIA <= CAST ('{GSUtilitarios.FormateDateTimePtBrParaBD(vigencia)}' AS DATETIME2))";

            using (var persistencia = new GSBancoDeDados())
            {
                var tabela = persistencia.ExecuteConsulta(comandoSQL);
                if (tabela == null)
                {
                    return null;
                }

                return Mapeamento.MonteConceito(ref tabela, 0);
            }
        }

        public IList<TConceito> ConsulteTodos()
        {
            var colunasReplaced = Mapeamento.Colunas
                                            .Replace(", ", ", T1.")
                                            .Replace("CODIGO, ", string.Empty);


            var consultaSQL =
                $"SELECT T1.CODIGO, {colunasReplaced} " +
                $"FROM {Mapeamento.Tabela} AS T1 " +
                $"  INNER JOIN(SELECT MAX(VIGENCIA) VIGENCIA, CODIGO " +
                $"             FROM {Mapeamento.Tabela} " +
                $"             GROUP BY CODIGO) AS T2 " +
                $"      ON T1.CODIGO = T2.CODIGO " +
                $"          AND T1.VIGENCIA = T2.VIGENCIA " +
                $"ORDER BY CODIGO";

            using (var GSBancoDeDados = new GSBancoDeDados())
            {
                var tabela = GSBancoDeDados.ExecuteConsulta(consultaSQL);
                if (tabela == null)
                {
                    return null;
                }

                var listaRetorno = new List<TConceito>();
                for (int linha = 0; linha < tabela.Rows.Count; linha++)
                {
                    listaRetorno.Add(Mapeamento.MonteConceito(ref tabela, linha));
                }

                return listaRetorno;
            }
        }
    }
}
