using GS.GestaoEmpresa.Solucao.Utilitarios;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GS.GestaoEmpresa.Solucao.Mapeador.BancoDeDados
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
            //diretorio = diretorio.Remove(diretorio.Length - 1);

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

        public static bool VerificarStatusDaConexao { get; set; }

        public static bool ConexaoAtiva { get; set; }

        public static void InicieVerificacaoDeConexao()
        {
            VerificarStatusDaConexao = true;

            Action acao = () =>
            {
                while (VerificarStatusDaConexao)
                {
                    using (var persistencia = new GSBancoDeDados())
                    {
                        ConexaoAtiva = persistencia.VerifiqueStatusDaConexao();
                    }

                    Thread.Sleep(300);
                }

                return;
            };

            GSTarefasAssincronas.ExecuteTarefaAssincrona(acao);
        }
    }
}
