using GS.GestaoEmpresa.Solucao.Utilitarios;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GS.GestaoEmpresa.Solucao.Persistencia.BancoDeDados
{
    public static class SessaoSistema
    {
        public static bool Iniciada { get; set; }

        public static int CodigoUsuario { get; set; }

        public static string NomeUsuario { get; set; }

        public static InformacoesConexaoBanco InformacoesConexao { get; internal set; }

        /// <summary>
		/// Busca as informações de conexão com o banco de dados do arquivo no diretório especificado.
		/// </summary>
		/// <returns>As informações de conexão com o banco</returns>
		public static InformacoesConexaoBanco BusqueConfiguracoesConexaoDoArquivo(string diretorio, string nomeArquivo)
        {
            if (File.Exists(diretorio + nomeArquivo))
            {
                var texto = File.ReadAllText(diretorio + nomeArquivo);
                texto = texto.Replace("\r\n", string.Empty);

                var textoDividido = texto.Split('|');

                return new InformacoesConexaoBanco()
                {
                    Servidor = textoDividido[0],
                    NomeBanco = textoDividido[1].ApliqueCriptografiaBasica(EnumCriptografiaBasica.Desencriptar),
                    Usuario = textoDividido[2].ApliqueCriptografiaBasica(EnumCriptografiaBasica.Desencriptar),
                    Senha = textoDividido[3].ApliqueCriptografiaBasica(EnumCriptografiaBasica.Desencriptar)
                };
            }

            return null;
        }

        /// <summary>
        /// Salva as informações de conexão com o banco de dados no arquivo no diretório especificado.
        /// </summary>
        public static void SalveConfiguracoesConexaoNoArquivo(InformacoesConexaoBanco informacoesConexaoBanco, string diretorio, string nomeArquivo)
        {
            //diretorio = diretorio.Remove(diretorio.Length - 1);

            if (File.Exists(diretorio + nomeArquivo))
                File.Delete(diretorio + nomeArquivo);

            using (var writer = new StreamWriter(diretorio + nomeArquivo, true))
            {
                writer.WriteLine(
                    $"{informacoesConexaoBanco.Servidor}|" +
                    $"{informacoesConexaoBanco.NomeBanco.ApliqueCriptografiaBasica(EnumCriptografiaBasica.Encriptar)}|" +
                    $"{informacoesConexaoBanco.Usuario.ApliqueCriptografiaBasica(EnumCriptografiaBasica.Encriptar)}|" +
                    $"{informacoesConexaoBanco.Senha.ApliqueCriptografiaBasica(EnumCriptografiaBasica.Encriptar)}");
            }
        }

        public static bool VerificarStatusDaConexao { get; set; }

        public static bool ConexaoAtiva { get; set; }

        public static void InicieVerificacaoDeConexao()
        {
            VerificarStatusDaConexao = true;

            Action acao = () =>
            {
                while (VerificarStatusDaConexao)
                {
                    if (InformacoesConexao != null)
                    {
                        switch (InformacoesConexao.TipoDeBanco)
                        {
                            case EnumTipoDeBanco.SQLSERVER:
                                using (var persistencia = new GSBancoDeDados())
                                {
                                    ConexaoAtiva = persistencia.VerifiqueStatusDaConexao();
                                }
                                break;

                            case EnumTipoDeBanco.RAVENDB:
                                using (var documentStore = new GSDocumentStore())
                                {
                                    ConexaoAtiva = documentStore.IsServerOnline();
                                }
                                break;
                        }
                    }

                    Thread.Sleep(300);
                }

                return;
            };

            GSTarefasAssincronas.ExecuteTarefaAssincrona(acao);
        }
    }
}
