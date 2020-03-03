using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GS.GestaoEmpresa.Solucao.UI.Modulos.Atendimento;
using MetroFramework.Controls;

namespace GS.GestaoEmpresa.Solucao.UI.ControlesGenericos
{
    public partial class GSPesquisaDeProduto : MetroUserControl
    {
        private OrcamentoPresenter _bindedPresenter;

        public GSPesquisaDeProduto(OrcamentoPresenter presenter)
        {
            _bindedPresenter = presenter;
            InitializeComponent();
        }

        private void dgvItensPesquisa_Leave(object sender, EventArgs e)
        {
            Dispose();
        }

        private void dgvItensPesquisa_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            //dgvItensPesquisa["colunaOrcaNome", e.RowIndex].Value.ToString();
        }

        private void dgvItensPesquisa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                senderGrid.Columns[e.ColumnIndex] == colunaOrcaSelecionar &&
                e.RowIndex >= 0)
            {
                var codigoProduto = (int)senderGrid[colunaOrcaCodigo.Name, e.RowIndex].Value;

                _bindedPresenter.AdicioneProdutoOrcado(codigoProduto);
            }
        }
    }
}
