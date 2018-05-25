using System;
using System.Globalization;
using GS.GestaoEmpresa.Solucao.Mapeador.Mapeadores.MapeadoresAbstratos;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos.ObjetosConcretos;
using GS.GestaoEmpresa.Solucao.Mapeador.BancoDeDados;
using GS.GestaoEmpresa.Solucao.Utilitarios;
using System.Collections.Generic;
using System.Data;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores;

namespace GS.GestaoEmpresa.Solucao.Mapeador.Mapeadores.MapeadoresConcretos
{
    public class MapeadorDeUsuario : IDisposable
    {
        private string Tabela => "USUARIOS";

        private string Colunas => string.Join(", ", this.ColunasETiposDeDados.Keys);

        private Dictionary<string, Type> ColunasETiposDeDados
        =>
        new Dictionary<string, Type>()
        {
            {"CODIGO", typeof(int)},
            {"STATUS", typeof(bool)},
            {"NOME", typeof(string)},
            {"SENHA", typeof(int)}
        };

        private string _scriptCreate
        =>
        "CREATE TABLE USUARIOS (" +
        "CODIGO INT NOT NULL, " +
        "STATUS INT NOT NULL, " +
        "NOME NVARCHAR(30) NOT NULL, " +
        "SENHA INT NOT NULL);";

        private string _scriptDrop
        =>
        "DROP TABLE USUARIOS;";

        private Usuario MonteRetorno(DataTable tabela, int linha)
        {
            var retorno = new Usuario();

            retorno.Codigo = int.Parse(tabela.Rows[linha]["CODIGO"].ToString());
            retorno.Status = (EnumStatusDoUsuario)int.Parse(tabela.Rows[linha]["STATUS"].ToString());
            retorno.Nome = tabela.Rows[linha]["NOME"].ToString();
            retorno.Senha = int.Parse(tabela.Rows[linha]["SENHA"].ToString());

            return retorno;
        }

        private string ObtenhaValoresInsercao(Usuario usuario)
        {
            return string.Format("{0}, {1}, '{2}', {3}",
                                 usuario.Codigo,
                                 (int)usuario.Status,
                                 usuario.Nome,
                                 usuario.Senha);
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

        public void Insira(Usuario usuario)
        {
            string ComandoSQL = String.Format("INSERT INTO {0} ({1}) VALUES ({2});",
                                              Tabela,
                                              Colunas,
                                              ObtenhaValoresInsercao(usuario));

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

        public Usuario Consulte(int codigo)
        {
            string ComandoSQL = String.Format("SELECT {0} FROM {1} " +
                                              "WHERE CODIGO = {2}",
                                              Colunas,
                                              Tabela,
                                              codigo);

            DataTable tabela;
            try
            {
                using (var GSBancoDeDados = new GSBancoDeDados())
                    tabela = GSBancoDeDados.ExecuteConsulta(ComandoSQL);

                if (tabela == null)
                    return null;

                return MonteRetorno(tabela, 0);
            }
            catch (System.Exception)
            {
                return null;
                throw;
            }
        }

        public Usuario Consulte(string nome)
        {
            string ComandoSQL = String.Format("SELECT {0} FROM {1} " +
                                              "WHERE NOME = '{2}'",
                                              Colunas,
                                              Tabela,
                                              nome);

            DataTable tabela;
            try
            {
                using (var GSBancoDeDados = new GSBancoDeDados())
                    tabela = GSBancoDeDados.ExecuteConsulta(ComandoSQL);

                if (tabela == null)
                    return null;

                return MonteRetorno(tabela, 0);
            }
            catch (System.Exception)
            {
                return null;
                throw;
            }
        }

        public List<Usuario> ConsulteTodos()
        {
            string ComandoSQL = String.Format("SELECT {0} FROM {1}", Colunas, Tabela);

            DataTable tabela;
            try
            {
                using (var GSBancoDeDados = new GSBancoDeDados())
                    tabela = GSBancoDeDados.ExecuteConsulta(ComandoSQL);

                if (tabela == null)
                    return null;

                var listaRetorno = new List<Usuario>();
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
        // ~MapeadorDeUsuario() {
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
