using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.GestaoEmpresa.Solucao.Mapeador.BancoDeDados
{
    public static class SessaoSistema
    {
        public static bool Iniciada { get; set; }

        public static int CodigoUsuario { get; set; }

        public static string NomeUsuario { get; set; }
        public static InformacoesConexaoBanco InformacoesConexao { get; internal set; }
    }
}
