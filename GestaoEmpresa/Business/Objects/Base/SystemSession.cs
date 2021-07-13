using GS.GestaoEmpresa.Solucao.Utilitarios;
using System;
using System.IO;
using System.Threading;
using GS.GestaoEmpresa.Business.Objects.Base;
using GS.GestaoEmpresa.Business.Objects.Core;
using GS.GestaoEmpresa.Persistence.RavenDB;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;

namespace GS.GestaoEmpresa.Solucao.Persistencia.BancoDeDados
{
    public static class SessaoSistema
    {
        public static bool Iniciada { get; set; }

        public static int CodigoUsuario { get; set; }

        public static string NomeUsuario { get; set; }

        public static DatabaseConnection InformacoesConexao { get; set; }

        public static bool WorkTestMode { get; set; }

        public static UISettings UISettings { get; set; }

        /// <summary>
		/// Busca as informações de conexão com o banco de dados do arquivo no diretório especificado.
		/// </summary>
		/// <returns>As informações de conexão com o banco</returns>
		public static DatabaseConnection BusqueConfiguracoesConexaoDoArquivo(string diretorio, string nomeArquivo)
        {
            if (File.Exists(diretorio + nomeArquivo))
            {
                var texto = File.ReadAllText(diretorio + nomeArquivo);
                texto = texto.Replace("\r\n", string.Empty);

                var textoDividido = texto.Split('|');

                return new DatabaseConnection
                {
                    Server = textoDividido[0],
                    DatabaseName = textoDividido[1]
                };
            }

            return null;
        }

        /// <summary>
        /// Salva as informações de conexão com o banco de dados no arquivo no diretório especificado.
        /// </summary>
        public static void SalveConfiguracoesConexaoNoArquivo(DatabaseConnection informacoesConexaoBanco, string diretorio, string nomeArquivo)
        {
            if (File.Exists(diretorio + nomeArquivo))
            {
                File.Delete(diretorio + nomeArquivo);
            }

            using var writer = new StreamWriter(diretorio + nomeArquivo, true);
            writer.WriteLine($"{informacoesConexaoBanco.Server}|{informacoesConexaoBanco.DatabaseName}");
        }

        public static bool VerificarStatusDaConexao { get; set; }

        public static bool ConexaoAtiva { get; set; }
        public static bool IsMain { get; set; }

        public static void InicieVerificacaoDeConexao()
        {
            VerificarStatusDaConexao = true;
            GSTarefasAssincronas.ExecuteTarefaAssincrona(VerifyConnectionAction);
        }

        private static Action VerifyConnectionAction
        {
            get
            {
                Action action = () =>
                {
                    while (VerificarStatusDaConexao)
                    {
                        if (InformacoesConexao != null)
                        {
                            ConexaoAtiva = RavenHelper.VerifiqueSeServidorEstahOnline();
                        }

                        Thread.Sleep(300);
                    }
                };

                return action;
            }
        }
    }
}
