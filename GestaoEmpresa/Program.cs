﻿using GestaoEmpresa.GS.GestaoEmpresa.GS.GestaoEmpresa.UI.Principal;
using GS.GestaoEmpresa.Solucao.UI.Modulos.Estoque;
using GS.GestaoEmpresa.Solucao.UI.Modulos.Tecnico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using GS.GestaoEmpresa.Solucao.UI;
using GS.GestaoEmpresa.Solucao.UI.Base;
using GS.GestaoEmpresa.Solucao.UI.Modulos.Atendimento;

namespace GestaoEmpresa
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var produto = new Produto
            {
                Codigo = 1,
                Vigencia = DateTime.Now,
                Nome = "Teste"
            };

            Application.Run(GerenciadorDeViews.Crie<ProdutoPresenter>(produto).View);
            //Application.Run(new frmPrincipal());
        }

        // Remove and reinstall all references
        // Open NuGet Package Manager Console 
        // Type "Update-Package -Reinstall" and hit enter
    }
}
