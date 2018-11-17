using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GS.GestaoEmpresa.Solucao.Persistencia.BancoDeDados;
using System.Data;

namespace GS.GestaoEmpresa.Solucao.Persistencia.Repositorios
{
    public class RepositorioDeNumeroDeSerie : IDisposable
    {
        #region Propriedades

        public string Tabela => "NUMEROS_DE_SERIE";

        public string Colunas => "NUMERO, CODIGO_INTERACAO, CODIGO_PRODUTO";

        #endregion

        #region Métodos Públicos

        public void Insira(string numeroDeSerie, int codigoDaInteracao, int codigoDoProduto)
        {
            string ComandoSQL = String.Format("INSERT INTO {0} ({1}) VALUES ('{2}', {3}, {4})",
                                              Tabela,
                                              Colunas,
                                              numeroDeSerie,
                                              codigoDaInteracao,
                                              codigoDoProduto);

            using (var GSBancoDeDados = new GSBancoDeDados())
            {
                GSBancoDeDados.ExecuteComando(ComandoSQL);
            }
        }

        public bool VerifiqueSeExisteEmBanco(string numeroDeSerie)
        {
            string ComandoSQL = String.Format("SELECT {0} FROM {1} WHERE NUMERO = '{2}'",
                                              Colunas,
                                              Tabela,
                                              numeroDeSerie);

            DataTable tabela;
            using (var GSBancoDeDados = new GSBancoDeDados())
            {
                tabela = GSBancoDeDados.ExecuteConsulta(ComandoSQL);
            }

            return tabela.Rows.Count != 0;
        }

        public List<string> ConsulteTodos()
        {
            string ComandoSQL = String.Format("SELECT DISTINCT (NUMERO), CODIGO_INTERACAO FROM {0}", Tabela);

            DataTable tabela;
            using (var GSBancoDeDados = new GSBancoDeDados())
            {
                tabela = GSBancoDeDados.ExecuteConsulta(ComandoSQL);
            }

            return ObtenhaListaDeRetorno(tabela);
        }

        public List<string> ConsulteTodosPorInteracao(int codigo)
        {
            string ComandoSQL = String.Format("SELECT {0} FROM {1} WHERE CODIGO_INTERACAO = {2}",
                                              Colunas,
                                              Tabela,
                                              codigo);

            DataTable tabela;
            using (var GSBancoDeDados = new GSBancoDeDados())
            {
                tabela = GSBancoDeDados.ExecuteConsulta(ComandoSQL);
            }
            
            return tabela != null 
                    ? ObtenhaListaDeRetorno(tabela)
                    : new List<string>();
        }

        public List<int> ConsulteTodosOsCodigosDeInteracoesDeUmNumero(string numeroDeSerie)
        {
            string ComandoSQL = String.Format("SELECT {0} FROM {1} WHERE NUMERO = '{2}'",
                                              Colunas,
                                              Tabela,
                                              numeroDeSerie);

            DataTable tabela;
            using (var GSBancoDeDados = new GSBancoDeDados())
            {
                tabela = GSBancoDeDados.ExecuteConsulta(ComandoSQL);
            }

            return ObtenhaListaDeRetornoInteracaoes(tabela);
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

        private List<string> ObtenhaListaDeRetorno(DataTable tabela)
        {
            var listaRetorno = new List<string>();

            for (int linha = 0; linha < tabela.Rows.Count; linha++)
            {
                listaRetorno.Add(tabela.Rows[linha]["NUMERO"].ToString());
            }

            return listaRetorno;
        }

        private List<int> ObtenhaListaDeRetornoInteracaoes(DataTable tabela)
        {
            var listaRetorno = new List<int>();

            for (int linha = 0; linha < tabela.Rows.Count; linha++)
            {
                listaRetorno.Add(int.Parse(tabela.Rows[linha]["CODIGO_INTERACAO"].ToString()));
            }

            return listaRetorno;
        }

        #endregion

        #region IDisposable
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
        // ~MapeadorDeNumeroDeSerie() {
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
