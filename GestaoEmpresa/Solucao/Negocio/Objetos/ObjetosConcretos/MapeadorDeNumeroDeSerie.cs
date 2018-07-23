using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using GS.GestaoEmpresa.Solucao.Negocio.Catalogos;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using GS.GestaoEmpresa.Solucao.Mapeador.BancoDeDados;
using GS.GestaoEmpresa.Solucao.Utilitarios;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores;

namespace GS.GestaoEmpresa.Solucao.Mapeador.Mapeadores.MapeadoresConcretos
{
    public class MapeadorDeNumeroDeSerie
    {
        #region Propriedades

        public string Tabela => "NUMEROS_DE_SERIE";

        private string Colunas => "NUMERO, CODIGO_INTERACAO";

        #endregion

        #region Métodos Públicos

        public void Insira(string numeroDeSerie, int codigoDaInteracao)
        {
            var comandoSQL = string.Format("INSERT INTO {0} ({1}) VALUES ({2})",
                                           Tabela,
                                           Colunas,
                                           "'" + numeroDeSerie + "'" + ", " codigoDaInteracao);

            using (var GSBancoDeDados = new GSBancoDeDados())
			{
				GSBancoDeDados.ExecuteComando(ComandoSQL);
			}
        }

        public List<string> ConsulteTodos()
        {
            string ComandoSQL = String.Format("SELECT {0} FROM {1}", Colunas, Tabela);

			DataTable tabela;
			using (var GSBancoDeDados = new GSBancoDeDados())
			{
			   tabela = GSBancoDeDados.ExecuteConsulta(ComandoSQL);
            }

            if (tabela == null)
                return null;

			return ObtenhaListaDeNumerosConsultados(tabela);
        }

        public List<String> ConsulteTodosPorInteracao(int codigoDaInteracao)
        {
            string ComandoSQL = String.Format("SELECT {0} FROM {1} WHERE CODIGO_INTERACAO = {2}",
                                              Colunas,
                                              Tabela,
                                              codigoDaInteracao);

			DataTable tabela;
			using (var GSBancoDeDados = new GSBancoDeDados())
			{
			   tabela = GSBancoDeDados.ExecuteConsulta(ComandoSQL);
            }

            if (tabela == null)
                return null;

			return ObtenhaListaDeNumerosConsultados(tabela);
        }

        public void Modifique(string numeroDeSerie, int codigoDaInteracao)
        {
			string ComandoSQL = String.Format("UPDATE {0} SET {1} WHERE NUMERO = '{2}' AND CODIGO_INTERACAO = {3}",
											  Tabela,
											  ObtenhaValoresModificacao(numeroDeSerie, codigoDaInteracao),
											  numeroDeSerie,
											  codigoDaInteracao);

			using (var GSBancoDeDados = new GSBancoDeDados())
			{
				GSBancoDeDados.ExecuteComando(ComandoSQL);
			}
        }

        public void Exclua(string numeroDeSerie, int codigoDaInteracao)
        {
            string ComandoSQL = String.Format("DELETE FROM {0} WHERE NUMERO = '{1}' AND CODIGO_INTERACAO = {2}",
											  Tabela,
											  numeroDeSerie,
											  codigoDaInteracao);

			using (var GSBancoDeDados = new GSBancoDeDados())
			{
				GSBancoDeDados.ExecuteComando(ComandoSQL);
			}
        }

        #endregion

        #region Métodos Privados

        private List<string> ObtenhaListaDeNumerosConsultados(DataTable tabela)
		{
			var listaRetorno = new List<string>();
			for (int linha = 0; linha < tabela.Rows.Count; linha++)
			{
				listaRetorno.Add(tabela.Rows[linha]["NUMERO"];);
			}

			return listaRetorno;
        }

        private string ObtenhaValoresModificacao(string numeroDeSerie, int codigoDaInteracao)
        {
            return string.Format("NUMERO = '{0}', CODIGO_INTERACAO = {1}", numeroDeSerie, codigoDaInteracao);
        }

        #endregion
    }
}