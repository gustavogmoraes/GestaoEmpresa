#region Usings

using GS.GestaoEmpresa.UI.Base;

#region Core

using System;
using System.Drawing;
using System.Windows.Forms;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;

#endregion

#region Ours

using GS.GestaoEmpresa.Solucao.UI.Base;
using GS.GestaoEmpresa.Solucao.UI.ControlesGenericos;
using GS.GestaoEmpresa.Solucao.Utilitarios;

#endregion

#endregion

namespace GS.GestaoEmpresa.Solucao.UI.Modulos.Atendimento
{
    public partial class FrmOrcamento : GSForm
    {
        //#region Fields

        //private GsTypingAssistant _txtPesquisaTypingAssistant;
        //private string _txtPesquisaPreviousSearch;

        //#endregion

        //#region Properties

        //public new OrcamentoPresenter Presenter => (OrcamentoPresenter)base.Presenter;

        //#endregion

        //#region Constructors

        public FrmOrcamento()
        {
            InitializeComponent();
            //InicializeAssistentesDigitacao();
        }

        //#endregion

        //#region Events

        //#region TxtPesquisa

        //private void _txtPesquisaTypingAssistant_Idle(object obj, EventArgs args)
        //{
        //    var searchTerm = txtPesquisa.Text.Trim().ToLowerInvariant();
        //    if (searchTerm.IsNullOrEmpty())
        //    {
        //        if (_txtPesquisaPreviousSearch.IsNullOrEmpty() || searchTerm == _txtPesquisaPreviousSearch)
        //        {
        //            //_didSearch = false;
        //            return;
        //        }
        //    }

        //    GSWaitForm.Mostrar(this,
        //        () =>
        //        {
        //            Presenter.ConsulteEPreenchaGridDeProdutos(searchTerm);
        //            _txtPesquisaPreviousSearch = searchTerm;
        //            //_didSearch = true;
        //        });
        //}

        //private void txtPesquisa_TextChanged(object sender, EventArgs e) => _txtPesquisaTypingAssistant.TextChanged();

        //private void txtPesquisa_Enter(object sender, EventArgs e)
        //{
        //    if (txtPesquisa.Text != "Pesquisar...") return;

        //    txtPesquisa.Text = string.Empty;
        //    txtPesquisa.ForeColor = Color.Black;
        //}

        //private void txtPesquisa_Leave(object sender, EventArgs e)
        //{
        //    if (!txtPesquisa.Text.IsNullOrEmpty()) return;

        //    txtPesquisa.ForeColor = Color.Silver;
        //    txtPesquisa.SetTextWithoutFiringEvents("Pesquisar...");
        //}

        //#endregion

        //#region BtnAdicionarProduto

        //private void BtnAdicionarProduto_Click(object sender, EventArgs e)
        //{
        //    txtPesquisa.Visible = true;
        //    pictureBox3.Visible = true;

        //    txtPesquisa.Focus();
        //}

        //#endregion

        //#region DgvItensPesquisa

        //private void dgvItensPesquisa_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    var senderGrid = (DataGridView)sender;

        //    if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
        //        e.RowIndex >= 0 &&
        //        senderGrid.Columns[e.ColumnIndex] == colunaOrcaSelecionar)
        //    {
        //        Presenter.AdicioneProdutoOrcado(Convert.ToInt32(senderGrid[colunaOrcaCodigo.Index, e.RowIndex].Value));
        //    }
        //}

        //#endregion

        //#region DgvProdutosOrcados

        //private void dgvProdutosOrcados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    var senderGrid = (DataGridView)sender;

        //    if (e.RowIndex >= 0 &&
        //        senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
        //        senderGrid.Columns[e.ColumnIndex] == colunaProdutosOrcadosRemover)
        //    {
        //        Presenter.RemovaProdutoOrcado(senderGrid[colunaProdutosOrcadosSequencial.Index, e.RowIndex].Value.ToInt32());
        //    }
        //}

        //#endregion

        //#endregion

        //#region Private Methods

        //private void InicializeAssistentesDigitacao()
        //{
        //    _txtPesquisaTypingAssistant = new GsTypingAssistant();
        //    _txtPesquisaTypingAssistant.Idled += _txtPesquisaTypingAssistant_Idle;
        //}

        //#endregion

        //#region Public Methods


        //#endregion

        //private void dgvProdutosOrcados_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        //{
        //    if(e.ColumnIndex.IsAny(colunaProdutosOrcadosSequencial.Index, colunaOrcaValorUnitario.Index))
        //    {
        //        Presenter.RecalculeProdutoOrcado(e.RowIndex);
        //    }
        //}
    }
}
