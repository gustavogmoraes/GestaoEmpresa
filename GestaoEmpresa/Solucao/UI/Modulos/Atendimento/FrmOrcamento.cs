﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GS.GestaoEmpresa.Solucao.UI.Base;
using GS.GestaoEmpresa.Solucao.UI.ControlesGenericos;
using GS.GestaoEmpresa.Solucao.Utilitarios;

namespace GS.GestaoEmpresa.Solucao.UI.Modulos.Atendimento
{
    public partial class FrmOrcamento : GSForm
    {
        public new OrcamentoPresenter Presenter => (OrcamentoPresenter)base.Presenter; 

        public FrmOrcamento()
        {
            InitializeComponent();

            InicializeAssistentesDigitacao();
        }

        private void InicializeAssistentesDigitacao()
        {
            _txtPesquisaTypingAssistant = new GsTypingAssistant();
            _txtPesquisaTypingAssistant.Idled += _txtPesquisaTypingAssistant_Idle;
        }

        private GsTypingAssistant _txtPesquisaTypingAssistant;
        private string _txtPesquisaPreviousSearch;

        #region Events

        #region TxtPesquisa

        private void _txtPesquisaTypingAssistant_Idle(object obj, EventArgs args)
        {
            GSWaitForm.Mostrar(this,
                () =>
                {
                    var searchTerm = txtPesquisa.Text.Trim().ToLowerInvariant();
                    if (searchTerm.IsNullOrEmpty())
                    {
                        if (_txtPesquisaPreviousSearch.IsNullOrEmpty() || searchTerm == _txtPesquisaPreviousSearch)
                        {
                            //_didSearch = false;
                            return;
                        }
                    }

                    Presenter.ConsulteEPreenchaGridDeProdutos(searchTerm);
                    _txtPesquisaPreviousSearch = searchTerm;
                    //_didSearch = true;
                });
        }

        private void txtPesquisa_TextChanged(object sender, EventArgs e) => _txtPesquisaTypingAssistant.TextChanged();

        private void txtPesquisa_Enter(object sender, EventArgs e)
        {
            if (txtPesquisa.Text != "Pesquisar...") return;

            txtPesquisa.Text = string.Empty;
            txtPesquisa.ForeColor = Color.Black;
        }

        private void txtPesquisa_Leave(object sender, EventArgs e)
        {
            if (!txtPesquisa.Text.IsNullOrEmpty()) return;

            txtPesquisa.ForeColor = Color.Silver;
            txtPesquisa.SetTextWithoutFiringEvents("Pesquisar...");
        }

        #endregion

        #endregion

        private void BtnAdicionarProduto_Click(object sender, EventArgs e)
        {
            txtPesquisa.Visible = true;
            pictureBox3.Visible = true;

            txtPesquisa.Focus();
        }
    }
}