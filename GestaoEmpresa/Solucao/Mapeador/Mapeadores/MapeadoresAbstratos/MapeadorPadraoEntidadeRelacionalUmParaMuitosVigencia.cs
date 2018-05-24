using GS.GestaoEmpresa.Solucao.Mapeador.BancoDeDados;
using GS.GestaoEmpresa.Solucao.Utilitarios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.GestaoEmpresa.Solucao.Mapeador.Mapeadores.MapeadoresAbstratos
{
    public abstract class MapeadorPadraoEntidadeRelacionalUmParaMuitosVigencia<TEntidade> : MapeadorPadraoVigencia<TEntidade>
        where TEntidade : class, new()
    {
        #region Inserir

        public override void Insira(TEntidade entidade)
        {
            var vigencia = DateTime.UtcNow;

            string ComandoSQL = String.Format("INSERT INTO {0} (PORTADOR, VIGENCIA, {1}) VALUES ('{2}', CAST ('{3}' AS DATE), {4})",
                                              Tabela.ToUpper(),
                                              String.Join(", ", this.Colunas.Keys),
                                              entidade.GetType().Name.ToUpper(),
                                              GSUtilitarios.FormateDateTimePtBrParaBD(vigencia),
                                              ObtenhaValoresInsercao(entidade));

            using (var GSBancoDeDados = new GSBancoDeDados())
            {
                GSBancoDeDados.ExecuteComando(ComandoSQL);
            }
        }

        #endregion

        #region Consultar

        //Retorna a última vigência de todas as chaves diferentes de um portador
        public List<TEntidade> Consulte(Type portador, dynamic chavePortador)
        {
            var tipoPortador = portador.Name;
            var colunaChave = GSUtilitarios.EncontrePropriedadeChaveDoTipo(typeof(TEntidade));
            var colunasConsultadas = String.Join(",T1.", Colunas.Keys)
                                           .Replace(chavePortador + ",", String.Empty)
                                           .Replace(Colunas.Keys.Last() + ",T1.", String.Empty);

            //{0} = Tabela
            //{1} = Propriedade/Coluna chave
            //{2} = Tipo portador
            //{3} = Chave portador
            //{4} = Propriedades/Colunas consultadas com prefixo T1.
            string ComandoSQL = String.Format("SELECT {4} FROM ENDERECOS AS T1 " +
                                              "INNER JOIN(SELECT MAX(VIGENCIA) VIGENCIA, {1} FROM {0} GROUP BY {1}, TIPO_PORTADOR) AS T2 " +
                                              "ON T1.{1} = T2.{1} AND T1.VIGENCIA = T2.VIGENCIA " +
                                              "WHERE T1.TIPO_PORTADOR = '{2}' AND T1.CODIGO_PORTADOR = '{3}' " +
                                              "ORDER BY CODIGO_PORTADOR, CODIGO",
                                              Tabela,
                                              colunaChave,
                                              tipoPortador,
                                              chavePortador,
                                              colunasConsultadas);

            DataTable tabela;

            using (var GSBancoDeDados = new GSBancoDeDados())
            {
                tabela = GSBancoDeDados.ExecuteConsulta(ComandoSQL);
            }

            if (tabela == null)
                return null;

            return ObtenhaListaObjetosConsultados(tabela);
        }

        //Retorna a vigência vigente na data específica de todas as chaves diferentes de um portador
        public List<TEntidade> Consulte(Type portador, dynamic chavePortador, DateTime vigencia)
        {
            var tipoPortador = portador.Name;
            var colunaChave = GSUtilitarios.EncontrePropriedadeChaveDoTipo(typeof(TEntidade));
            var colunasConsultadas = String.Join(",T1.", Colunas.Keys)
                                           .Replace(chavePortador + ",", String.Empty)
                                           .Replace(Colunas.Keys.Last() + ",T1.", String.Empty);

            
            //{0} = Tabela
            //{1} = Propriedade/Coluna chave
            //{2} = Tipo portador
            //{3} = Chave portador
            //{4} = Propriedades/Colunas consultadas com prefixo T1
            //{5} = Vigência
            string ComandoSQL = String.Format("SELECT {4} FROM ENDERECOS AS T1 " +
                                              "INNER JOIN(SELECT MAX(VIGENCIA) VIGENCIA, {1} FROM {0} WHERE VIGENCIA <= CAST ('{5}' AS DATE) GROUP BY {1}, TIPO_PORTADOR) AS T2 " +
                                              "ON T1.{1} = T2.{1} AND T1.VIGENCIA = T2.VIGENCIA " +
                                              "WHERE T1.TIPO_PORTADOR = '{2}' AND T1.CODIGO_PORTADOR = '{3}' " +
                                              "ORDER BY CODIGO_PORTADOR, CODIGO",
                                              Tabela,
                                              colunaChave,
                                              tipoPortador,
                                              chavePortador,
                                              colunasConsultadas,
                                              vigencia);

            DataTable tabela;

            using (var GSBancoDeDados = new GSBancoDeDados())
            {
                tabela = GSBancoDeDados.ExecuteConsulta(ComandoSQL);
            }

            if (tabela == null)
                return null;

            return ObtenhaListaObjetosConsultados(tabela);
        }

        #endregion
    }
}
