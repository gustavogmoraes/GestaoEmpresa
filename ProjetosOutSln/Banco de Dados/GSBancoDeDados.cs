﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using GS.GestaoEmpresa.Solucao.Utilitarios;

namespace GS.GestaoEmpresa.Solucao.Mapeador.BancoDeDados
{
	/// <summary>
	/// Representa a ponte/conexão com o banco de dados da aplicação, atuando de forma genérica, executando querys diretamente enviadas.
	/// </summary>
	public static class GSBancoDeDados
	{
		#region Informações da conexão

		/// <summary>
		/// Busca as informações de conexão com o banco de dados do arquivo no diretório especificado.
		/// </summary>
		/// <returns>As informações de conexão com o banco</returns>
		public static InformacoesConexaoBanco BusqueConfiguracoesConexaoDoArquivo(string diretorio, string nomeArquivo)
		{
            //if (File.Exists(@".\" + NOME_ARQUIVO_CONFIGURACAO_BANCO))

			if (File.Exists(diretorio + nomeArquivo))
			{
				string texto = File.ReadAllText(diretorio + nomeArquivo);
				texto = texto.Replace("\r\n", String.Empty);
				string[] textoDividido = texto.Split('|');

				return new InformacoesConexaoBanco()
				{
					Servidor = textoDividido[0],
					NomeBanco = GSUtilitarios.ApliqueCriptografiaBasica(textoDividido[1],
																		EnumCriptografiaBasica.Desencriptar),
					Usuario = GSUtilitarios.ApliqueCriptografiaBasica(textoDividido[2],
																		EnumCriptografiaBasica.Desencriptar),
					Senha = GSUtilitarios.ApliqueCriptografiaBasica(textoDividido[3],
																		EnumCriptografiaBasica.Desencriptar)
				};
			}
			return null;
		}

		/// <summary>
		/// Salva as informações de conexão com o banco de dados no arquivo no diretório especificado.
		/// </summary>
		public static void SalveConfiguracoesConexaoNoArquivo(InformacoesConexaoBanco informacoesConexaoBanco, string diretorio, string nomeArquivo)
		{
            diretorio = diretorio.Remove(diretorio.Length - 1);

            if (File.Exists(diretorio + nomeArquivo))
				File.Delete(diretorio + nomeArquivo);

			using (var writer = new StreamWriter(diretorio + nomeArquivo, true))
			{
				writer.WriteLine(String.Format("{0}|{1}|{2}|{3}",
											   informacoesConexaoBanco.Servidor,

											   GSUtilitarios.ApliqueCriptografiaBasica(informacoesConexaoBanco.NomeBanco,
																								 EnumCriptografiaBasica.Encriptar),
											   GSUtilitarios.ApliqueCriptografiaBasica(informacoesConexaoBanco.Usuario,
																								 EnumCriptografiaBasica.Encriptar),
											   GSUtilitarios.ApliqueCriptografiaBasica(informacoesConexaoBanco.Senha,
																								 EnumCriptografiaBasica.Encriptar)));
			}
		}
		
		#endregion


		#region String de conexão

		/// <value>A string de conexão com o banco de dados.</value>
		private static string stringDeConexao;

		/// <summary>
		/// Define a string de conexão com o banco de dados.
		/// </summary>
		/// <param name="urlDoServidor">A url do servidor, para local utilize '.', lembre-se de passar a string com o '@' antes para ignorar as '\'.</param>
		/// <param name="nomeDoBanco">O nome do banco.</param>
		/// <param name="login">O usuário do banco.</param>
		/// <param name="senha">A senha do banco.</param>
		public static void DefinaStringDeConexao(string urlDoServidor, string nomeDoBanco, string login, string senha)
		{
			stringDeConexao = String.Format("Server = {0}; Database = {1}; Uid = {2}; Pwd = {3};",
											urlDoServidor, nomeDoBanco, login, senha);
		}

		/// <summary>
		/// Define a string de conexão com o banco de dados para o computador do desenvolvedor
		/// </summary>
		public static void DefinaStringDeConexao()
		{
			stringDeConexao = @"Server = RAGNOS\SQLEXPRESS; Database = GestaoEmpresa; Trusted_Connection = Yes";
		}

		#endregion


		#region Métodos de query

		/// <summary>
		/// Executa diretamente a query SQL enviada.
		/// </summary>
		/// <param name="comandoSQL">A query SQL que será executada.</param>
		public static void ExecuteComando(string comandoSQL)
		{
			try
			{
				using (var conexao = new SqlConnection(stringDeConexao))
				{
					//Cria e define a query
					SqlCommand cmd = new SqlCommand();

					cmd.CommandText = comandoSQL;
					cmd.CommandType = CommandType.Text;
					cmd.Connection = conexao;

					//Abre a conexão
					conexao.Open();

					//Executa a query
					cmd.ExecuteReader();

					//Fecha a conexão
					conexao.Close();
				}
			}

			catch (Exception ex)
			{
				Console.WriteLine(ex);
				throw;
			}
		}

		/// <summary>
		/// Executa diretamente a query SQL enviada e retorna o resultado retorno tupla única.
		/// </summary>
		/// <param name="comandoSQL">A query SQL que será executada.</param>
		/// <returns>
		/// DataReader com o resultado da query.
		/// </returns>
		public static dynamic ExecuteConsultaRetornoUnico(string comandoSQL, Type tipoRetorno)
		{
			try
			{
				string resultadoConsulta = string.Empty;

				using(var conexao = new SqlConnection(stringDeConexao))
				{
					//Cria e define a query
					SqlCommand cmd = new SqlCommand();

					cmd.CommandText = comandoSQL;
					cmd.CommandType = CommandType.Text;
					cmd.Connection = conexao;

					//Abre a conexão
					conexao.Open();

					//Executa a query
					resultadoConsulta = (string)cmd.ExecuteScalar();

					//Fecha conexão
					conexao.Close();
				}

				if (String.IsNullOrEmpty(resultadoConsulta))
					return null;

				return tipoRetorno.GetMethod("Parse", new Type[] { typeof(string) })
								  .Invoke(null, new object[] { resultadoConsulta });
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
				return null;
			}
		}

		/// <summary>
		/// Executa diretamente a query SQL enviada e retorna o resultado.
		/// </summary>
		/// <param name="comandoSQL">A query SQL que será executada.</param>
		/// <returns>
		/// DataReader com o resultado da query.
		/// </returns>
		public static DataTable ExecuteConsulta(string comandoSQL)
		{
			try
			{
				var dataTable = new DataTable();

				using(var conexao = new SqlConnection(stringDeConexao))
				{
					//Cria e define a query
					SqlCommand cmd = new SqlCommand();

					//Cria o reader
					SqlDataReader reader;

					cmd.CommandText = comandoSQL;
					cmd.CommandType = CommandType.Text;
					cmd.Connection = conexao;

					//Abre a conexão
					conexao.Open();

					//Executa a query
					reader = cmd.ExecuteReader();

					dataTable.Load(reader);

					//Fecha conexão
					conexao.Close();
				}

				return dataTable;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex);
				return null;
			}
		}

		#endregion


		#region Métodos auxiliares

		/// <summary>
		/// Executa diretamente a query SQL enviada e retorna o resultado.
		/// </summary>
		/// <param name="comandoSQL">A query SQL que será executada.</param>
		/// <returns>
		/// DataReader com o resultado da query.
		/// </returns>
		public static bool VerifiqueStatusDaConexao()
		{
			try
			{
				//Cria a conexão
				var conexao = new SqlConnection(stringDeConexao);

				//Cria e define a query
				SqlCommand cmd = new SqlCommand();

				cmd.CommandText = "SELECT 1";
				cmd.CommandType = CommandType.Text;
				cmd.Connection = conexao;

				//Abre a conexão
				conexao.Open();

				//Executa a query
				var retorno = cmd.ExecuteScalar();

				//Fecha conexão
				conexao.Close();

				if ((int)retorno == 1)
					return true;
				else
					return false;
			}

			catch (Exception ex)
			{
				Console.WriteLine(ex);
				return false;
			}
		}

		/// <summary>
		/// Obtém o próximo código inteiro que estiver disponível na tabela desejada.
		/// </summary>
		/// <param name="tabela">A tabela desejada</param>
		/// <param name="colunaChave">A coluna chave dessa tabela</param>
		/// <returns>
		/// Inteiro com o próximo código disponível
		/// </returns>
		public static int ObtenhaProximoCodigoDisponivel(string tabela, string colunaChave)
		{
			string comandoSQL = String.Format("SELECT TOP 1 {0} + 1 FROM {1} MO WHERE NOT EXISTS" +
											  "(SELECT NULL FROM {1} MI WHERE MI.{0} = MO.{0} + 1) ORDER BY {0}",
											  colunaChave,
											  tabela);

			return ExecuteConsultaRetornoUnico(comandoSQL, typeof(int));
		}

		#endregion
	}
}
