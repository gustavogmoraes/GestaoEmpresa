using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using GS.GestaoEmpresa.Solucao.Negocio.Catalogos;
using GS.GestaoEmpresa.Solucao.Mapeador.BancoDeDados;
using GS.GestaoEmpresa.Solucao.Utilitarios;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores;

namespace GS.GestaoEmpresa.Solucao.Mapeador.Mapeadores.MapeadoresAbstratos
{
	public abstract class MapeadorPadrao<TEntidade> : IDisposable
		where TEntidade : class, new()
	{
		#region Atributos

		public Dictionary<string, PropertyInfo> Colunas
		{
            get
            {
                Dictionary<string, PropertyInfo> campos = new Dictionary<string, PropertyInfo>();

                foreach (var propriedade in typeof(TEntidade).GetProperties()
															 .Where(x => GSUtilitarios.ObtenhaTipoDeEntidadeRelacional(x) != EnumTipoDeEntidadeRelacional.UmParaMuitos ))
                {
                    campos.Add(propriedade.Name.ToUpper(), propriedade);
                }

                return campos;
            }
        }

        /// <summary>
        /// Tabela do banco de dados.
        /// Implemente o get de cada conceito para retornar o nome da tabela do mesmo no banco de dados.
        /// Exemplo: "USUARIO"
        /// </summary>
        public abstract string Tabela { get;}

		#endregion

		#region Métodos Banco de dados

		public void OperacaoBDCreateTabela()
		{
			string ComandoSQL = String.Format("CREATE TABLE {0} ({1})",
											  Tabela,
											  ObtenhaStringColunasETiposDadosBD());

            using (var GSBancoDeDados = new GSBancoDeDados())
            {
                GSBancoDeDados.ExecuteComando(ComandoSQL);
            }
		}

		public void OperacaoBDDropTabela()
		{
			string ComandoSQL = String.Format("DROP TABLE {0}",
											  Tabela);

            using (var GSBancoDeDados = new GSBancoDeDados())
            {
                GSBancoDeDados.ExecuteComando(ComandoSQL);
            }
		}

		private string ObtenhaStringColunasETiposDadosBD()
		{
			string retorno = String.Empty;

			foreach (var propriedade in Colunas)
			{
				retorno += String.Format("{0} {1}{2}{3}",
										 propriedade.Key,
										 GSUtilitarios.ConvertaTipoDadosAplicacaoBanco(propriedade.Value.PropertyType),
										 propriedade.Value.PropertyType.Equals(typeof(string)) ? "(255)" : String.Empty,
										 !propriedade.Equals(Colunas.Last()) ? ", " : String.Empty);
			}

			return retorno;
		}

		#endregion

		#region CRUD

		#region Inserir

		public virtual void Insira(TEntidade entidade)
		{
			string ComandoSQL = String.Format("INSERT INTO {0} ({1}) VALUES ({2})",
											  Tabela.ToUpper(),
											  String.Join(", ", this.Colunas.Keys),
											  ObtenhaValoresInsercao(entidade));
			using (var GSBancoDeDados = new GSBancoDeDados())
			{
				GSBancoDeDados.ExecuteComando(ComandoSQL);
			}
		}

        

		protected string ObtenhaValoresInsercao(TEntidade entidade)
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
													 .Invoke(servicoMapeadorElementosLista, new object[] { elemento });
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

		public virtual TEntidade Consulte(dynamic chave)
		{
			var colunaChave = GSUtilitarios.EncontrePropriedadeChaveDoTipo(typeof(TEntidade)).Name.ToUpper();

			string ComandoSQL = String.Format("SELECT {0} FROM {1} WHERE {2} = {3}",
											  String.Join(", ", Colunas.Keys),
											  Tabela.ToUpper(),
											  colunaChave,
											  chave.GetType().Equals(typeof(int)) ? chave : "'" + chave + "'");

			DataTable tabela;

			using (var GSBancoDeDados = new GSBancoDeDados())
			{
                tabela = GSBancoDeDados.ExecuteConsulta(ComandoSQL);
			}

			return ObtenhaObjetoConsultado(tabela);
		}

		protected TEntidade ObtenhaObjetoConsultado(DataTable tabela)
		{
			return MonteRetorno(tabela, 0);
		}

		public virtual List<TEntidade> ConsulteTodos()
		{
			string ComandoSQL = String.Format("SELECT {0} FROM {1}",
											  String.Join(", ", Colunas.Keys),
											  Tabela.ToUpper());

			DataTable tabela;

			using (var GSBancoDeDados = new GSBancoDeDados())
			{
			   tabela = GSBancoDeDados.ExecuteConsulta(ComandoSQL);
			}

			return ObtenhaListaObjetosConsultados(tabela);
		}

		protected List<TEntidade> ObtenhaListaObjetosConsultados(DataTable tabela)
		{
			List<TEntidade> listaRetorno = new List<TEntidade>();

			for (int linha = 0; linha < tabela.Rows.Count; linha++)
			{
				listaRetorno.Add(MonteRetorno(tabela, linha));
			}

			return listaRetorno;
		}

		protected TEntidade MonteRetorno(DataTable tabela, int linha)
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
														 .GetMethod("Consulte", new Type[] { typeof(Type), typeof(int) })
														 .Invoke(servicoMapeadorLista, new object[] { retorno.GetType(), valorChave }) as List<dynamic>;

					servicoMapeadorLista.Dispose();
					propriedade.SetValue(retorno, listaElementos);
				}
				else
				{
					var dado = tabela.Rows[linha][propriedade.Name.ToUpper()];

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
																		  .GetMethod("Consulte", new Type[] { tipoChave })
																		  .Invoke(servicoMapeadorPropriedadeComplexa, new object[] { valor });

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

		public virtual void Modifique(TEntidade entidade)
		{
			var chave = entidade.GetType().GetProperties().First();

			string ComandoSQL = String.Format("UPDATE {0} SET {1} WHERE {2} = {3}",
											  Tabela.ToUpper(),
											  ObtenhaValoresModificacao(entidade),
											  chave.Name.ToUpper(),
											  chave.GetValue(chave, null));

			using (var GSBancoDeDados = new GSBancoDeDados())
			{
				GSBancoDeDados.ExecuteComando(ComandoSQL);
			}
		}

		protected string ObtenhaValoresModificacao(TEntidade entidade)
		{
			List<string> valores = this.Colunas.Keys.ToList();
			int auxiliar = 0;

			string dado = string.Empty;
			string tipoBD = string.Empty;
			bool propriedadeEhLista;
			bool entreApostrofos;

			foreach (var propriedade in entidade.GetType().GetProperties())
			{
				Type tipoSistema = propriedade.PropertyType;
				propriedadeEhLista = GSUtilitarios.VerifiqueSeTipoEhLista(tipoSistema);

				if (!propriedadeEhLista)
				{
					tipoBD = GSUtilitarios.ConvertaTipoDadosAplicacaoBanco(propriedade.GetValue(entidade, null).GetType());
					dado = propriedade.GetValue(entidade, null).ToString();
					entreApostrofos = (tipoBD != "INT" && tipoBD != "DECIMAL") ? true : false;

					valores[auxiliar] = valores[auxiliar] + String.Format(" = {0}{1}{2}",
																		  entreApostrofos ? "'" : String.Empty,
																		  dado,
																		  entreApostrofos ? "'" : String.Empty);
				}
				else
				{
					Type tipoElementos = GSUtilitarios.ObtenhaTipoLista(propriedade.GetValue(entidade, null) as List<dynamic>);
					Type tipoChaveElementos = GSUtilitarios.EncontrePropriedadeChaveDoTipo(tipoElementos).PropertyType;

					var servicoMapeadorElementosLista = Activator.CreateInstance(null, Namespaces.MAPEADORES_CONCRETOS + ".Mapeador" + tipoElementos.Name).Unwrap() as IDisposable;

					foreach (var elemento in dado)
					{
						servicoMapeadorElementosLista.GetType()
													 .GetMethod("Modifique", new Type[] { tipoElementos })
													 .Invoke(servicoMapeadorElementosLista, new object[] { elemento });
					}

					servicoMapeadorElementosLista.Dispose();
				}

				auxiliar++;
			}

			return String.Join(", ", valores);
		}

		#endregion

		#region Excluir

		public void Exclua(dynamic chave)
		{
			string ComandoSQL = string.Empty;
			string tabelaConceitoComPortador = string.Empty;

			foreach (var conceito in ObtenhaConceitosComPortadorVinculados())
			{
				var servicoMapeadorConceitoComPortador = 
					Activator.CreateInstance(null, Namespaces.MAPEADORES_CONCRETOS + ".Mapeador" + conceito.GetType().Name).Unwrap() as IDisposable;

				tabelaConceitoComPortador = servicoMapeadorConceitoComPortador.GetType()
																			  .GetProperty("Tabela")
																			  .GetValue(conceito).ToString();

				servicoMapeadorConceitoComPortador.Dispose();
				
				ComandoSQL += String.Format("DELETE FROM {0} WHERE PORTADOR = {1} AND CODIGO_PORTADOR = {2}; ",
											tabelaConceitoComPortador,
											typeof(TEntidade).Name,
											chave.ToString());
			}
			
			ComandoSQL += String.Format("DELETE FROM {0} WHERE {1} = {2};",
											  Tabela.ToUpper(),
											  typeof(TEntidade).GetProperties().First().Name.ToUpper(),
											  chave.GetType().Equals(typeof(int)) ? chave : "'" + chave + "'");

			using (var GSBancoDeDados = new GSBancoDeDados())
			{
				GSBancoDeDados.ExecuteComando(ComandoSQL);
			}
		}

		public List<string> ObtenhaConceitosComPortadorVinculados()
		{
			var conceitosComPortador = typeof(TEntidade).GetProperties()
														.Where(x => GSUtilitarios.VerifiqueSePropriedadeEhEntidadeRelacionalUmParaMuitos(x));

			var listaRetorno = new List<string>();

			foreach (var conceito in conceitosComPortador)
			{
				Type tipoElementos = GSUtilitarios.ObtenhaTipoLista(conceito.GetValue(conceito, null) as List<dynamic>);
				Type tipoChaveElementos = GSUtilitarios.EncontrePropriedadeChaveDoTipo(tipoElementos).PropertyType;

				var servicoMapeadorElementosLista = Activator.CreateInstance(null, Namespaces.MAPEADORES_CONCRETOS + ".Mapeador" + tipoElementos.Name).Unwrap() as IDisposable;

				var listaElementos = GSUtilitarios.CrieLista(tipoElementos);

				listaElementos = servicoMapeadorElementosLista.GetType()
															  .GetMethod("Consulte", new Type[] { tipoElementos, tipoChaveElementos })
															  .Invoke(servicoMapeadorElementosLista, new object[] { tipoElementos, tipoChaveElementos }) as List<dynamic>;

				servicoMapeadorElementosLista.Dispose();

				if (listaElementos.Count > 0)
					listaRetorno.Add(tipoElementos.Name);
			}

			return listaRetorno;
		}

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~MapeadorPadrao() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion

        #endregion

        #endregion
    }
}
