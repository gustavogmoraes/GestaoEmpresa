using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using GS.GestaoEmpresa.Properties;
using GS.GestaoEmpresa.Solucao.Negocio.Atributos;
using GS.GestaoEmpresa.Solucao.Negocio.Interfaces;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using GS.GestaoEmpresa.Solucao.UI.ControlesGenericos;
using GS.GestaoEmpresa.Solucao.Utilitarios;
using MetroFramework.Controls;
using MetroFramework.Forms;
using MoreLinq;

namespace GS.GestaoEmpresa.Solucao.UI.Base
{
    public partial class GSForm: MetroForm
    {
        public GSForm()
        {
            InitializeComponent();
        }

        protected virtual void btnEditarSalvarOnClick(object sender, EventArgs e)
        {

        }

        protected virtual void btnCancelarExcluirOnClick(object sender, EventArgs e)
        {

        }

        private void btnEditarSalvar_Click(object sender, EventArgs e)
        {
            btnEditarSalvarOnClick(sender, e);
        }

        private void btnCancelarExcluir_Click(object sender, EventArgs e)
        {
            btnEditarSalvarOnClick(sender, e);
        }
    }
}
