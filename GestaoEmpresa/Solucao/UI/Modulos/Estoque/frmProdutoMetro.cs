using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GS.GestaoEmpresa.Solucao.Negocio.Interfaces;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using GS.GestaoEmpresa.Solucao.UI.Base;
using GS.GestaoEmpresa.Solucao.Utilitarios;

namespace GS.GestaoEmpresa.Solucao.UI.Modulos.Estoque
{
    public partial class frmProdutoMetro : GSForm
    {
        public frmProdutoMetro()
        {
            InitializeComponent();
        }

        protected override void ChamadaSalvar(object sender, EventArgs e)
        {
            (Presenter as ProdutoPresenter)?.Salve();
        }

        protected override void ChamadaExclusao(object sender, EventArgs e)
        {
            (Presenter as ProdutoPresenter)?.Exclua(Presenter.Model.Codigo);
        }

        private void TxtCodigoDeBarras_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.IsAny(Keys.Return, Keys.Enter))
            {
                txtNome.Focus();
            }
        }
    }
}
