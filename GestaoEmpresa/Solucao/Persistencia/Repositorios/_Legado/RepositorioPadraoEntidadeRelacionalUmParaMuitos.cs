using System;
using System.Collections.Generic;
using System.Linq;
using GS.GestaoEmpresa.Solucao.Persistencia.BancoDeDados;
using GS.GestaoEmpresa.Solucao.Utilitarios;
using GS.GestaoEmpresa.Solucao.Negocio.Catalogos;
using System.Data;

namespace GS.GestaoEmpresa.Solucao.Persistencia.Repositorios.RepositoriosAbstratos
{
	public abstract class RepositorioPadraoEntidadeRelacionalUmParaMuitos<TEntidade> : RepositorioPadrao<TEntidade>
		where TEntidade : class, new()
	{
		#region Inserir

		public override void Insira(TEntidade entidade)
		{
			string ComandoSQL = String.Format("INSERT INTO {0} (PORTADOR, {1}) VALUES ({2})",
											  Tabela.ToUpper(),
											  String.Join(", ", this.Colunas.Keys),
											  "'"+ entidade.GetType().Name.ToUpper() + "', " + ObtenhaValoresInsercao(entidade));
			
			using (var GSBancoDeDados = new GSBancoDeDados())
			{
				GSBancoDeDados.ExecuteComando(ComandoSQL);
			}
		}

		#endregion

		#region Consultar

		//Retorna todas as chaves diferentes de um portador
		public List<TEntidade> Consulte(Type portador, dynamic chavePortador)
		{
			var tipoPortador = portador.Name;

			string ComandoSQL = String.Format("SELECT {0} FROM {1} WHERE TIPO_PORTADOR = '{2}' AND CODIGO_PORTADOR = '{3}'",
											  String.Join(", ", Colunas.Keys),
											  Tabela,
											  tipoPortador,
											  chavePortador);

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

		#region Modificar

		public override void Modifique(TEntidade entidade)
		{
			var chave = entidade.GetType().GetProperties().First();

			string ComandoSQL = String.Format("UPDATE {0} SET {1} WHERE CODIGO_PORTADOR = {2} AND PORTADOR = '{3}'",
											  Tabela.ToUpper(),
											  ObtenhaValoresModificacao(entidade),
											  chave.GetValue(chave, null),
											  entidade.GetType().Name);

			using (var GSBancoDeDados = new GSBancoDeDados())
			{
				GSBancoDeDados.ExecuteComando(ComandoSQL);
			}	
		}

		#endregion

		#region Excluir

		public void Exclua(Type portador, dynamic chavePortador)
		{
			string ComandoSQL = String.Format("DELETE FROM {0} WHERE CODIGO_PORTADOR = {1} AND PORTADOR = '{2}'",
											  Tabela.ToUpper(),
											  chavePortador.GetType().Equals(typeof(int)) ? chavePortador : "'" + chavePortador + "'",
											  portador.Name);

			using (var GSBancoDeDados = new GSBancoDeDados())
			{
				GSBancoDeDados.ExecuteComando(ComandoSQL);
			}
		}
		
		#endregion
	}
}
