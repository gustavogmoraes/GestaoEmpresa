﻿using System;
using System.Windows.Forms;
using GS.GestaoEmpresa.Properties;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns;
using MetroFramework.Forms;

namespace GS.GestaoEmpresa.Solucao.UI.Base
{
    public partial class GSForm: MetroForm, IView
    {
        #region Propriedades

        public EnumBotoesForm SwitchBotaoEditarSalvar { get; set; }

        public EnumBotoesForm SwitchBotaoCancelarExcluir { get; set; }

        public  IPresenter Presenter { get; set; }

        private EnumTipoDeForm _tipoDeForm { get; set; }

        public EnumTipoDeForm TipoDeForm
        {
            get => _tipoDeForm;
            set
            {
                _tipoDeForm = value;
                InicializeBotoes(_tipoDeForm);
            }
        }

        public bool EstahRenderizando { get; set; }

        public string IdInstancia { get; set; }

        #endregion

        #region Construtores

        public GSForm()
        {
            InitializeComponent();

            lblTitulo.BringToFront();
        }

        #endregion

        #region Métodos

        protected void InicializeBotoes(EnumTipoDeForm tipoDeForm)
        {
            switch (tipoDeForm)
            {
                case EnumTipoDeForm.Cadastro:
                    btnCancelarExcluir.Enabled = false;
                    btnCancelarExcluir.Visible = false;

                    btnEditarSalvar.Image = Resources.floppy_icon;
                    SwitchBotaoEditarSalvar = EnumBotoesForm.Salvar;
                    break;

                case EnumTipoDeForm.Edicao:
                    btnCancelarExcluir.Enabled = true;
                    btnCancelarExcluir.Visible = true;
                    btnCancelarExcluir.Image = Resources.cancel_icon;
                    SwitchBotaoCancelarExcluir = EnumBotoesForm.Cancelar;

                    btnEditarSalvar.Image = Resources.floppy_icon;
                    SwitchBotaoEditarSalvar = EnumBotoesForm.Salvar;

                    break;

                case EnumTipoDeForm.Detalhamento:
                    btnCancelarExcluir.Enabled = true;
                    btnCancelarExcluir.Visible = true;
                    btnCancelarExcluir.Image = Resources.delete;
                    SwitchBotaoCancelarExcluir = EnumBotoesForm.Excluir;

                    btnEditarSalvar.Image = Resources.edit_512;
                    SwitchBotaoEditarSalvar = EnumBotoesForm.Editar;
                    break;
            }

            btnEditarSalvar.Refresh();
            btnCancelarExcluir.Refresh();
        }

        #endregion

        #region Chamadas p/ Presenter

        protected virtual void ChamadaEditarOnClick(object sender, EventArgs e)
        {
            EstahRenderizando = true;
            TipoDeForm = EnumTipoDeForm.Edicao;
            Presenter.HabiliteControles();
            EstahRenderizando = false;
        }

        protected virtual void ChamadaSalvarOnClick(object sender, EventArgs e)
        {
            Presenter.CarregueModelComControles();
            ChamadaSalvar(sender, e);
        }

        protected virtual void ChamadaCancelarOnClick(object sender, EventArgs e)
        {
            TipoDeForm = EnumTipoDeForm.Detalhamento;
            Presenter.DesabiliteControles();
        }

        protected virtual void ChamadaExcluirOnClick(object sender, EventArgs e)
        {
            var dialogResult = Presenter.ExibaPromptConfirmacao("Tem certeza que deseja excluir?");
            if (dialogResult == DialogResult.Yes) ChamadaExclusao(sender, e);
        }

        protected virtual void ChamadaExclusao(object sender, EventArgs e)
        {
            
        }

        protected virtual void ChamadaSalvar(object sender, EventArgs e)
        {
            
        }

        public void ChamadaMaximizarForm(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
                return;
            }

            WindowState = FormWindowState.Maximized;
        }

        #endregion

        #region Eventos

        private void btnEditarSalvar_Click(object sender, EventArgs e)
        {
            switch (TipoDeForm)
            {
                case EnumTipoDeForm.Cadastro:
                    ChamadaSalvarOnClick(sender, e);
                    break;
                case EnumTipoDeForm.Detalhamento:
                    ChamadaEditarOnClick(sender, e);
                    break;
                case EnumTipoDeForm.Edicao:
                    ChamadaSalvarOnClick(sender, e);
                    break;
            }
        }

        private void btnCancelarExcluir_Click(object sender, EventArgs e)
        {
            switch (TipoDeForm)
            {
                case EnumTipoDeForm.Cadastro:
                    ChamadaFecharForm(sender, e);
                    break;
                case EnumTipoDeForm.Detalhamento:
                    ChamadaExcluirOnClick(sender, e);
                    break;
                case EnumTipoDeForm.Edicao:
                    ChamadaCancelarOnClick(sender, e);
                    break;
            }
        }

        public virtual void ChamadaMinimizarForm(object sender, EventArgs e)
        {
            if (Presenter == null)
            {
                ((Control)sender).FindForm().WindowState = FormWindowState.Minimized;
                return;
            }

            Presenter.MinimizarView(sender, e);
        }
        
        public virtual void ChamadaFecharForm(object sender, EventArgs e)
        {
            if(Presenter == null)
            {
                ((Control)sender).FindForm().Hide();
                return;
            }

            Presenter.FecharView(sender, e);
        }

        #endregion

        private void GSForm_Load(object sender, EventArgs e)
        {
            // Se tirar isso o Designer do VS pifa
            Presenter?.ViewCarregada();
        }
    }
}
