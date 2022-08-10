using System;
using System.IO;
using System.Windows.Forms;
using GS.GestaoEmpresa.Solucao.Persistencia.BancoDeDados;
using GS.GestaoEmpresa.Solucao.UI;
using GS.GestaoEmpresa.Solucao.UI.ControlesGenericos;
using GS.GestaoEmpresa.Solucao.UI.Modulos.Atendimento;
using GS.GestaoEmpresa.Solucao.UI.Modulos.Estoque;
using GS.GestaoEmpresa.Solucao.Utilitarios;
using GS.GestaoEmpresa.UI.Base;

namespace GestaoEmpresa
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var isMainFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "IsMain.txt");
            SessaoSistema.IsMain = File.Exists(isMainFilePath);
            //SessaoSistema.WorkTestMode = true;

            Application.Run(ViewManager.GetMain());
        }

        // Remove and reinstall all references
        // Open NuGet Package Manager Console 
        // Type "Update-Package -Reinstall" and hit enter
    }
}
