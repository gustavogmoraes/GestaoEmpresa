using System;
using System.Collections.Generic;
using System.Data;
using GS.GestaoEmpresa.Solucao.Persistencia.BancoDeDados;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using GS.GestaoEmpresa.Solucao.Utilitarios;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores;
using System.Globalization;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns;

namespace GS.GestaoEmpresa.Solucao.Persistencia.Repositorios
{
    public class RepositorioDeProdutoSql : IDisposable
    {
        private string Tabela => "PRODUTOS";

        private string Colunas => string.Join(", ", this.ColunasETiposDeDados.Keys);

        private Dictionary<string, Type> ColunasETiposDeDados => 
		new Dictionary<string, Type>()
		{
		    { "CODIGO", typeof(int) },
		    { "STATUS", typeof(bool) },
		    { "NOME", typeof(string) },
		    { "FABRICANTE", typeof(string) },
		    { "CODIGOFABRICANTE", typeof(string) },
		    { "PRECOCOMPRA", typeof(decimal) },
		    { "PRECOVENDA", typeof(decimal) },
		    { "PORCENTAGEMLUCRO", typeof(float) },
            //{ "QUANTIDADEESTOQUE", typeof(int) },
		    { "AVISARQUANTIDADE", typeof(bool) },
		    { "QUANTIDADEMINIMAAVISO", typeof(int) },
            { "OBSERVACAO", typeof(string) }
        };

        private string _scriptCreate =>
		"CREATE TABLE PRODUTOS (" +
		"CODIGO INT NOT NULL, " +
		"VIGENCIA DATETIME2 NOT NULL, " +
		"STATUS INT NOT NULL, " +
		"NOME NVARCHAR(50) NOT NULL, " +
		"OBSERVACAO NVARCHAR(3000), " +
		"FABRICANTE NVARCHAR(50), " +
		"CODIGOFABRICANTE NVARCHAR(50), " +
		"PRECOCOMPRA DECIMAL, " +
		"PRECOVENDA DECIMAL, " +
		"PORCENTAGEMLUCRO FLOAT, " +
		"QUANTIDADEESTOQUE INT, " +
		"QUANTIDADEMINIMAAVISO INT);";

        public int ObtenhaQuantidadeDeRegistros()
        {
            var colunas = Colunas.Replace(", ", ", T1.")
                                 .Replace("CODIGO, ", string.Empty);
            var consultaDerivada =
                $"SELECT T1.CODIGO, {colunas}, PRODUTOS_QUANTIDADES.QUANTIDADE AS QUANTIDADEESTOQUE FROM {Tabela} AS T1 " +
                $"INNER JOIN(SELECT MAX(VIGENCIA) VIGENCIA, CODIGO FROM {Tabela} GROUP BY CODIGO) AS T2 " +
                $"ON T1.CODIGO = T2.CODIGO AND T1.VIGENCIA = T2.VIGENCIA INNER JOIN PRODUTOS_QUANTIDADES ON T1.CODIGO = PRODUTOS_QUANTIDADES.CODIGO_PRODUTO";

            var consulta = $"SELECT COUNT(1) FROM ({consultaDerivada}) AS DERIVADA";

            using (var GSBD = new GSBancoDeDados())
            {
                var result = GSBD.ExecuteConsultaRetornoUnico(consulta, typeof(int));
                return result ?? 0;
            }
        }

        private string _scriptDrop =>
		"DROP TABLE PRODUTOS;";

        private Produto MonteRetorno(DataTable tabela, int linha)
        {
            var retorno = new Produto();

                retorno.Codigo = int.Parse(tabela.Rows[linha]["CODIGO"].ToString());
                retorno.Status = (EnumStatusDoProduto) int.Parse(tabela.Rows[linha]["STATUS"].ToString());
                retorno.Nome = tabela.Rows[linha]["NOME"].ToString();
                retorno.Fabricante = tabela.Rows[linha]["FABRICANTE"] != DBNull.Value
                                   ? tabela.Rows[linha]["FABRICANTE"].ToString()
                                   : null;
                retorno.CodigoDoFabricante = tabela.Rows[linha]["CODIGOFABRICANTE"] != DBNull.Value
					                       ? tabela.Rows[linha]["CODIGOFABRICANTE"].ToString()
					                       : null;
                retorno.PrecoDeCompra = decimal.Parse(tabela.Rows[linha]["PRECOCOMPRA"].ToString());
                retorno.PrecoDeVenda = decimal.Parse(tabela.Rows[linha]["PRECOVENDA"].ToString());
                retorno.PorcentagemDeLucro = decimal.Parse(tabela.Rows[linha]["PORCENTAGEMLUCRO"].ToString());
                retorno.QuantidadeEmEstoque = tabela.Rows[linha]["QUANTIDADEESTOQUE"] != DBNull.Value
                                            ? int.Parse(tabela.Rows[linha]["QUANTIDADEESTOQUE"].ToString())
                                            : 0;
                retorno.AvisarQuantidade = GSUtilitarios.ConvertaValorBooleano(tabela.Rows[linha]["AVISARQUANTIDADE"].ToString());
                retorno.QuantidadeMinimaParaAviso = int.Parse(tabela.Rows[linha]["QUANTIDADEMINIMAAVISO"].ToString());
                retorno.Observacao = tabela.Rows[linha]["OBSERVACAO"] != DBNull.Value
                                   ? tabela.Rows[linha]["OBSERVACAO"].ToString()
                                   : null;

            return retorno;
        }

        private string ObtenhaValoresInsercao(Produto produto)
        {
            return $"{produto.Codigo}, " +
                   $"{(int)produto.Status}, " +
                   $"'{produto.Nome}', " +
                   $"'{produto.Fabricante ?? "NULL"}', " +
                   $"'{produto.CodigoDoFabricante ?? "NULL"}', " +
                   $"{produto.PrecoDeCompra.ToString(CultureInfo.InvariantCulture)}, " +
                   $"{produto.PrecoDeVenda.ToString(CultureInfo.InvariantCulture)}, " +
                   $"{produto.PorcentagemDeLucro.ToString(CultureInfo.InvariantCulture)}, " +
                   $"'{GSUtilitarios.ConvertaValorBooleano(produto.AvisarQuantidade)}', " +
                   $"{produto.QuantidadeMinimaParaAviso}, " +
                   $"'{produto.Observacao ?? "NULL"}'";
        }

        public void AltereQuantidadeDeProduto(int codigoDoProduto, int novaQuantidade)
        {
            var comandoSQL = $"UPDATE PRODUTOS_QUANTIDADES " +
                             $"SET QUANTIDADE = {novaQuantidade} " +
                             $"WHERE CODIGO_PRODUTO = {codigoDoProduto};";

            using (var BancoDeDados = new GSBancoDeDados())
            {
                BancoDeDados.ExecuteComando(comandoSQL);
            }
        }

        public void CrieTabela()
        {
            using (var GSBancoDeDados = new GSBancoDeDados())
                GSBancoDeDados.ExecuteComando(_scriptCreate);
        }

        public void DeleteTabela()
        {
            using (var GSBancoDeDados = new GSBancoDeDados())
                GSBancoDeDados.ExecuteComando(_scriptDrop);
        }

        public void InsiraNaTabelaQuantidade(int codigoProduto)
        {
            var sql = $"INSERT INTO PRODUTOS_QUANTIDADES VALUES({codigoProduto}, 0);";

            using (var GSBancoDeDados = new GSBancoDeDados())
            {
                GSBancoDeDados.ExecuteComando(sql);
            }
        }

        public void Insira(Produto produto)
        {
            var vigencia = DateTime.Now;

            string ComandoSQL = String.Format("INSERT INTO {0} (VIGENCIA, {1}) VALUES (CAST ('{2}' AS DATETIME2), {3})",
                                              Tabela,
                                              Colunas.Replace("QUANTIDADEESTOQUE, ", string.Empty),
                                              GSUtilitarios.FormateDateTimePtBrParaBD(vigencia),
                                              ObtenhaValoresInsercao(produto));

            using (var GSBancoDeDados = new GSBancoDeDados())
            {
                GSBancoDeDados.ExecuteComando(ComandoSQL);
            }   
        }

        public int ObtenhaProximoCodigoDisponivel()
        {
            int codigo;
            using (var GSBancoDeDados = new GSBancoDeDados())
                codigo = GSBancoDeDados.ObtenhaProximoCodigoDisponivel(Tabela, "CODIGO");

            return codigo;
        }

        public Produto Consulte(int codigo)
        {
            string ComandoSQL = String.Format("SELECT {0}, PRODUTOS_QUANTIDADES.QUANTIDADE AS QUANTIDADEESTOQUE FROM {1} " +
                                              "INNER JOIN PRODUTOS_QUANTIDADES ON PRODUTOS.CODIGO = PRODUTOS_QUANTIDADES.CODIGO_PRODUTO " +
                                              "WHERE CODIGO = {2} " +
                                              "AND VIGENCIA = (SELECT MAX(VIGENCIA) FROM PRODUTOS WHERE CODIGO = {2})",
                                              Colunas,
                                              Tabela,
                                              codigo);

            DataTable tabela;
            try
            {
                using (var GSBancoDeDados = new GSBancoDeDados())
                    tabela = GSBancoDeDados.ExecuteConsulta(ComandoSQL);

                if(tabela == null)
                    return null;

                return MonteRetorno(tabela, 0);
            }
            catch (System.Exception)
            {
                return null;
                throw;
            }
        }

        public Produto Consulte(int Codigo, DateTime vigencia)
        {
            string ComandoSQL = String.Format("SELECT {0}, PRODUTOS_QUANTIDADES.QUANTIDADE AS QUANTIDADEESTOQUE FROM {1} " +
                                              "INNER JOIN PRODUTOS_QUANTIDADES ON PRODUTOS.CODIGO = PRODUTOS_QUANTIDADES.CODIGO_PRODUTO "+
                                              "WHERE CODIGO = {2} " +
                                              "AND VIGENCIA = (SELECT MAX(VIGENCIA) FROM PRODUTOS WHERE VIGENCIA <= CAST ('{3}' AS DATETIME2))",
                                              Colunas,
                                              Tabela,
                                              Codigo,
                                              GSUtilitarios.FormateDateTimePtBrParaBD(vigencia));

            DataTable tabela;
            try
            {
                using (var GSBancoDeDados = new GSBancoDeDados())
                    tabela = GSBancoDeDados.ExecuteConsulta(ComandoSQL);

                if(tabela == null)
                    return null;

                return MonteRetorno(tabela, 0);
            }
            catch (System.Exception)
            {
                return null;
                throw;
            }
        }

        public List<Produto> ConsultePorFiltroNome(string nome)
        {
            var consultaSQL = $"SELECT {Colunas}, QUANTIDADE AS QUANTIDADEESTOQUE FROM {Tabela} " +
                              $"INNER JOIN PRODUTOS_QUANTIDADES ON PRODUTOS.CODIGO = PRODUTOS_QUANTIDADES.CODIGO_PRODUTO " +
                              $"WHERE NOME LIKE '%{nome.ToUpper()}%';";

            DataTable tabela;
            using (var persistencia = new GSBancoDeDados())
            {
                tabela = persistencia.ExecuteConsulta(consultaSQL);
            }

            if(tabela == null)
            {
                return null;
            }

            var listaRetorno = new List<Produto>();
            for (int linha = 0; linha < tabela.Rows.Count; linha++)
            {
                listaRetorno.Add(MonteRetorno(tabela, linha));
            }

            return listaRetorno;
        }

        //Ultima vigência de todos os produtos
        public List<Produto> ConsulteTodos()
        {
            //string ComandoSQL = String.Format("SELECT T1.{0}, {1} FROM {2} AS T1 " +
            //                                  "INNER JOIN(SELECT MAX(VIGENCIA) VIGENCIA, {0} FROM {2} GROUP BY {0}) AS T2 " +
            //                                  "ON T1.{0} = T2.{0} AND T1.VIGENCIA = T2.VIGENCIA ORDER BY {0}",
            //                                  "CODIGO",
            //                                  Colunas.Replace(", ", ", T1.")
            //                                         .Replace("CODIGO, ", string.Empty),
            //                                  Tabela);

            var colunas = Colunas.Replace(", ", ", T1.")
                                 .Replace("CODIGO, ", string.Empty);

            var comandoSQL =
                $"SELECT T1.CODIGO, {colunas}, PRODUTOS_QUANTIDADES.QUANTIDADE AS QUANTIDADEESTOQUE FROM {Tabela} AS T1 " +
                $"INNER JOIN(SELECT MAX(VIGENCIA) VIGENCIA, CODIGO FROM {Tabela} GROUP BY CODIGO) AS T2 " +
                $"ON T1.CODIGO = T2.CODIGO AND T1.VIGENCIA = T2.VIGENCIA INNER JOIN PRODUTOS_QUANTIDADES ON T1.CODIGO = PRODUTOS_QUANTIDADES.CODIGO_PRODUTO ORDER BY CODIGO";

            DataTable tabela;
            try
            {
                using (var GSBancoDeDados = new GSBancoDeDados())
                    tabela = GSBancoDeDados.ExecuteConsulta(comandoSQL);

                if(tabela == null)
                    return null;

                var listaRetorno = new List<Produto>();
                for (int linha = 0; linha < tabela.Rows.Count; linha++)
                {
                    listaRetorno.Add(MonteRetorno(tabela, linha));
                }

                return listaRetorno;
            }
            catch (System.Exception)
            {
                return null;
                throw;
            }
        }
        
        //Todos os produtos em uma vigência específica
        public List<Produto> ConsulteTodos(DateTime vigencia)
		{
			string ComandoSQL = String.Format("SELECT T1.{0}, {1} FROM {2} AS T1 " +
											  "INNER JOIN(SELECT MAX(VIGENCIA) VIGENCIA, {0} FROM {2} WHERE VIGENCIA <= CAST ('{4}' AS DATETIME2) GROUP BY {0}) AS T2 " +
											  "ON T1.{0} = T2.{0} AND T1.VIGENCIA = T2.VIGENCIA ORDER BY {0}",
											  "CODIGO",
											  Colunas.Replace(", ", ", T1.")
                                                     .Replace("CODIGO, ", string.Empty),
											  Tabela,
                                              GSUtilitarios.FormateDateTimePtBrParaBD(vigencia));

			DataTable tabela;
            try
            {
                using (var GSBancoDeDados = new GSBancoDeDados())
                    tabela = GSBancoDeDados.ExecuteConsulta(ComandoSQL);

                if(tabela == null)
                    return null;

                var listaRetorno = new List<Produto>();
                for (int linha = 0; linha < tabela.Rows.Count; linha++)
                {
                    listaRetorno.Add(MonteRetorno(tabela, linha));
                }

                return listaRetorno;
            }
            catch (System.Exception)
            {
                return null;
                throw;
            }
		}

        //Retorna uma lista de todas as vigências existentes para uma chave
		public List<DateTime> ConsulteTodasVigencias(int Codigo)
		{
			string ComandoSQL = String.Format("SELECT VIGENCIA FROM {0} WHERE {1} = {2} ORDER BY VIGENCIA DESC",
											  Tabela,
											  "CODIGO",
											  Codigo);

			DataTable tabela;
            try
            {
                using (var GSBancoDeDados = new GSBancoDeDados())
				    tabela = GSBancoDeDados.ExecuteConsulta(ComandoSQL);

                if(tabela == null )
                    return null;

                var listaRetorno = new List<DateTime>();

                for (int linha = 0; linha < tabela.Rows.Count; linha++)
                {
                    var dado = tabela.Rows[linha]["VIGENCIA"];
                    //listaRetorno.Add(GSUtilitarios.FormateDateTimePtBrParaBD(dado.ToString()));
                    listaRetorno.Add((DateTime)dado);
                }

                return listaRetorno;
            }
            catch (System.Exception)

            {
                return null;
                throw;
            }
		}

        public void Exclua(int codigoDoProduto)
        {
            var sql = $"DELETE FROM PRODUTOS_QUANTIDADES WHERE CODIGO_PRODUTO = {codigoDoProduto}";

            using (var GSBancoDeDados = new GSBancoDeDados())
            {
                GSBancoDeDados.ExecuteComando(sql);
            }

            string comandoSQL = String.Format("DELETE FROM {0} WHERE {1} = {2}",
                                              Tabela,
                                              "CODIGO",
                                              codigoDoProduto);

            using (var GSBancoDeDados = new GSBancoDeDados())
            {
                GSBancoDeDados.ExecuteComando(comandoSQL);
            }
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
        // ~MapeadorDeProduto() {
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
    }
}
