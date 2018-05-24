using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using GS.GestaoEmpresa.Solucao.Utilitarios;
using GS.GestaoEmpresa.Solucao.Mapeador.BancoDeDados;
using GS.GestaoEmpresa.Solucao.Negocio.Catalogos;

namespace GS.GestaoEmpresa.Solucao.Mapeador.Mapeadores.MapeadoresAbstratos
{
	public abstract class MapeadorPadraoVigencia<TEntidade> : MapeadorPadrao<TEntidade>
		where TEntidade : class, new()
	{

		#region Inserir

		public override void Insira(TEntidade entidade)
		{
			var vigencia = DateTime.UtcNow;

			string ComandoSQL = String.Format("INSERT INTO {0} (VIGENCIA, {1}) VALUES (CAST ('{2}' AS DATE), {3})",
											  Tabela.ToUpper(),
											  String.Join(", ", this.Colunas.Keys),
											  GSUtilitarios.FormateDateTimePtBrParaBD(vigencia),
											  ObtenhaValoresInsercao(entidade));

			using (var GSBancoDeDados = new GSBancoDeDados())
			{
				GSBancoDeDados.ExecuteComando(ComandoSQL);
			}
		}

		private string ObtenhaValoresInsercao(TEntidade entidade, DateTime vigencia)
		{
			string valores = string.Empty;
			string dado = string.Empty;
			string tipoBD = string.Empty;
			bool propriedadeEhLista;
			bool entreApostrofos;

			foreach (var propriedade in entidade.GetType().GetProperties())
			{
				if (propriedade.GetValue(entidade, null) == null && !GSUtilitarios.VerifiqueSePropriedadeEhEntidadeRelacionalUmParaMuitos(propriedade))
				{
					valores += "NULL, ";
					continue;
				}

				Type tipoSistema = propriedade.PropertyType;
				propriedadeEhLista = GSUtilitarios.VerifiqueSeTipoEhLista(propriedade.PropertyType);

				if (!propriedadeEhLista)
				{
					tipoBD = GSUtilitarios.ConvertaTipoDadosAplicacaoBanco(propriedade.GetValue(entidade, null).GetType());
					dado = propriedade.GetValue(entidade, null).ToString();

					entreApostrofos = (tipoBD != "INT" && tipoBD != "DECIMAL") ? true : false;
					valores += String.Format("{0}{1}{2}, ",
											entreApostrofos ? "'" : String.Empty,
											!tipoSistema.Equals(typeof(Guid)) ? dado : dado.ToUpper(),
											entreApostrofos ? "'" : String.Empty);
				}
				else
				{
					if (propriedade.GetValue(entidade, null) == null || (propriedade.GetValue(entidade, null) as IList<dynamic>).Count == 0)
						continue;

					Type tipoElementos = GSUtilitarios.ObtenhaTipoLista(propriedade.GetValue(entidade, null) as List<dynamic>);
					Type tipoChaveElementos = GSUtilitarios.EncontrePropriedadeChaveDoTipo(tipoElementos).PropertyType;

					var servicoMapeadorElementosLista = Activator.CreateInstance(null, Namespaces.MAPEADORES_CONCRETOS + ".Mapeador" + tipoElementos.Name).Unwrap() as IDisposable;

					foreach (var elemento in propriedade.GetValue(entidade, null) as List<dynamic>)
					{
						servicoMapeadorElementosLista.GetType()
													 .GetMethod("Insira", new Type[] { tipoElementos })
													 .Invoke(servicoMapeadorElementosLista, new object[] { elemento, vigencia });
					}

					servicoMapeadorElementosLista.Dispose();
				}
			}

			//Remove a última vírgula
			valores = valores.Trim();
			valores = valores.Remove(valores.Length - 1);

			return valores;
		}

		#endregion

		#region Consultar

		//Retorna a última vigência de uma chave específica
		public override TEntidade Consulte(dynamic chave)
		{
			string ComandoSQL = String.Format("SELECT {0} FROM {1} WHERE {2} = {3} AND VIGENCIA = (SELECT MAX(VIGENCIA) FROM {1})",
											  String.Join(", ", Colunas.Keys),
											  Tabela.ToUpper(),
											  GSUtilitarios.EncontrePropriedadeChaveDoObjeto(typeof(TEntidade)).Name,
											  chave.GetType().Equals(typeof(int)) ? chave : "'" + chave + "'");

			DataTable tabela;

			using (var GSBancoDeDados = new GSBancoDeDados())
			{
				tabela = GSBancoDeDados.ExecuteConsulta(ComandoSQL);
			}
			
			return ObtenhaObjetoConsultado(tabela);
		}

		//Retorna a vigência específica ou vigente no DateTime de uma chave específica
		public virtual TEntidade Consulte(dynamic chave, DateTime vigencia)
		{
			string ComandoSQL = String.Format("SELECT {0} FROM {1} WHERE CODIGO = {2} AND VIGENCIA = SELECT MAX(VIGENCIA) FROM {1} WHERE VIGENCIA <= CAST ('{3}' AS DATE)",
											  String.Join(", ", Colunas.Keys),
											  Tabela.ToUpper(),
											  chave.GetType().Equals(typeof(int)) ? chave : "'" + chave + "'",
											  GSUtilitarios.FormateDateTimePtBrParaBD(vigencia));

			DataTable tabela;
			using (var GSBancoDeDados = new GSBancoDeDados())
			{
				tabela = GSBancoDeDados.ExecuteConsulta(ComandoSQL);
			}

			return ObtenhaObjetoConsultadoVigencia(tabela, vigencia);
		}

		//Retorna o objeto consultado na vigência
		protected TEntidade ObtenhaObjetoConsultadoVigencia(DataTable tabela, DateTime vigencia)
		{
			return MonteRetorno(tabela, 0, vigencia);
		}

		//Retorna a última vigência de todas as chaves diferentes
		public override List<TEntidade> ConsulteTodos()
		{
			string colunaChave = GSUtilitarios.EncontrePropriedadeChaveDoObjeto(typeof(TEntidade)).Name;

			//{0} = Propriedade/Coluna chave
			//{1} = Propriedades/Colunas com prefixo T1.
			//{2} = Tabela
			string ComandoSQL = String.Format("SELECT T1.{0}, {1} FROM {2} AS T1 " +
											  "INNER JOIN(SELECT MAX(VIGENCIA) VIGENCIA, {0} FROM {2} GROUP BY {0}) AS T2 " +
											  "ON T1.{0} = T2.{0} AND T1.VIGENCIA = T2.VIGENCIA ORDER BY {0}",
											  colunaChave,
											  String.Join(",T1.", Colunas.Keys)
													.Replace(colunaChave + ",", String.Empty)
													.Replace(Colunas.Keys.Last() + ",T1.", String.Empty),
											  Tabela);

            var tabela = new DataTable();

			using (var GSBancoDeDados = new GSBancoDeDados())
			{
				tabela = GSBancoDeDados.ExecuteConsulta(ComandoSQL);
			}

			return ObtenhaListaObjetosConsultados(tabela);
		}

		//Retorna a vigência específica vigente no DateTime de todas as chaves diferentes
		public List<TEntidade> ConsulteTodos(DateTime vigencia)
		{
			string colunaChave = GSUtilitarios.EncontrePropriedadeChaveDoObjeto(typeof(TEntidade)).Name;

			//{0} = Propriedade/Coluna chave
			//{1} = Propriedades/Colunas com prefixo T1.
			//{2} = Tabela
			string ComandoSQL = String.Format("SELECT T1.{0}, {1} FROM {2} AS T1 " +
											  "INNER JOIN(SELECT MAX(VIGENCIA) VIGENCIA, {0} FROM {2} WHERE VIGENCIA <= CAST ('{4}' AS DATE) GROUP BY {0}) AS T2 " +
											  "ON T1.{0} = T2.{0} AND T1.VIGENCIA = T2.VIGENCIA ORDER BY {0}",
											  colunaChave,
											  String.Join(",T1.", Colunas.Keys)
													.Replace(colunaChave + ",", String.Empty)
													.Replace(Colunas.Keys.Last() + ",T1.", String.Empty),
											  Tabela,
											  GSUtilitarios.FormateDateTimePtBrParaBD(vigencia));

			DataTable tabela;
			using (var GSBancoDeDados = new GSBancoDeDados())
			{
				tabela = GSBancoDeDados.ExecuteConsulta(ComandoSQL);
			}

			return ObtenhaListaObjetosConsultadosVigencia(tabela, vigencia);
		}

		//Retorna uma lista de objetos montados a partir de uma DataTable
		protected List<TEntidade> ObtenhaListaObjetosConsultadosVigencia(DataTable tabela, DateTime vigencia)
		{
			List<TEntidade> listaRetorno = new List<TEntidade>();

			for (int linha = 0; linha < tabela.Rows.Count; linha++)
			{
				listaRetorno.Add(MonteRetorno(tabela, linha, vigencia));
			}

			return listaRetorno;
		}

		//Retorna uma lista de todas as vigências existentes para uma chave
		public List<DateTime> ConsulteTodasVigencias(dynamic chave)
		{
			string ComandoSQL = String.Format("SELECT VIGENCIA FROM {0} WHERE {1} = {2} ORDER BY VIGENCIA DESC",
											  Tabela.ToUpper(),
											  GSUtilitarios.EncontrePropriedadeChaveDoObjeto(typeof(TEntidade)).Name,
											  chave.GetType().Equals(typeof(int)) ? chave : "'" + chave + "'");

			DataTable tabela;
			using (var GSBancoDeDados = new GSBancoDeDados())
			{
				tabela = GSBancoDeDados.ExecuteConsulta(ComandoSQL);
			}

			var listaRetorno = new List<DateTime>();

			for (int linha = 0; linha < tabela.Rows.Count; linha++)
			{
				var dado = tabela.Rows[linha]["VIGENCIA"];
				listaRetorno.Add(GSUtilitarios.FormateDateTimePtBrParaBD(dado.ToString()));
			}

			return listaRetorno;
		}

		protected TEntidade MonteRetorno(DataTable tabela, int linha, DateTime vigencia)
		{
			var retorno = new TEntidade();
			foreach (var propriedade in retorno.GetType().GetProperties())
			{
				if (GSUtilitarios.VerifiqueSePropriedadeEhEntidadeRelacionalUmParaMuitos(propriedade))
				{
					Type tipoElementos = GSUtilitarios.ObtenhaTipoListaPropriedade(propriedade);

					var listaElementos = GSUtilitarios.CrieLista(tipoElementos);

					var servicoMapeadorLista = Activator.CreateInstance(null, Namespaces.MAPEADORES_CONCRETOS + ".Mapeador" + tipoElementos.Name).Unwrap() as IDisposable;

					var valorChave = retorno.GetType()
											.GetProperty(GSUtilitarios.EncontrePropriedadeChaveDoObjeto(retorno).Name)
											.GetValue(retorno, null);

					listaElementos = servicoMapeadorLista.GetType()
														 .GetMethod("Consulte", new Type[] { typeof(Type), typeof(int), typeof(DateTime) })
														 .Invoke(servicoMapeadorLista, new object[] { retorno.GetType(), valorChave, vigencia }) as List<dynamic>;

					servicoMapeadorLista.Dispose();
					propriedade.SetValue(retorno, listaElementos);
				}

				else
				{
					var dado = tabela.Rows[0][propriedade.Name.ToUpper()];

					if (propriedade.PropertyType.Equals(typeof(string)))
					{
						propriedade.SetValue(retorno, dado != DBNull.Value ? dado : null);
					}
					else if (GSUtilitarios.ChequeSeTipoEhBuiltIn(propriedade.PropertyType) && !GSUtilitarios.VerifiqueSeTipoEhLista(propriedade.PropertyType))
					{
						propriedade.SetValue(retorno, propriedade.PropertyType
																 .GetMethod("Parse", new Type[] { typeof(string) })
																 .Invoke(null, new object[] { dado != DBNull.Value ? dado.ToString() : null }));
					}
					else
					{
						if (!GSUtilitarios.VerifiqueSeTipoEhLista(propriedade.PropertyType))
						{
							Type tipoChave = GSUtilitarios.EncontrePropriedadeChaveDoTipo(propriedade.PropertyType).PropertyType;
							dynamic valor;
							if (propriedade.PropertyType.Equals(typeof(string)))
							{
								valor = dado != DBNull.Value ? dado : null;
							}
							else
							{
								if (dado == DBNull.Value)
								{
									valor = null;
									continue;
								}

								valor = tipoChave.GetMethod("Parse", new Type[] { typeof(string) })
												 .Invoke(null, new object[] { dado.ToString() });

								var servicoMapeadorPropriedadeComplexa = Activator.CreateInstance(null, Namespaces.MAPEADORES_CONCRETOS + ".Mapeador" + propriedade.Name).Unwrap() as IDisposable;

								valor = servicoMapeadorPropriedadeComplexa.GetType()
																		  .GetMethod("Consulte", new Type[] { tipoChave, typeof(DateTime) })
																		  .Invoke(servicoMapeadorPropriedadeComplexa, new object[] { valor, vigencia });

								servicoMapeadorPropriedadeComplexa.Dispose();
							}

							propriedade.SetValue(retorno, valor);
						}
					}
				}
			}

			return retorno;
		}

		#endregion

		#region Modificar

		public override void Modifique(TEntidade entidade)
		{
			// Faz nada
		}

		#endregion
		
	}
}
