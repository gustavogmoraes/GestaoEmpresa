using System;
using System.Drawing;
using System.Windows.Forms;
using GS.GestaoEmpresa.Properties;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns;
using GS.GestaoEmpresa.Solucao.Negocio.Interfaces;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using MetroFramework.Drawing;
using MetroFramework.Forms;

namespace GS.GestaoEmpresa.Solucao.UI.Base
{
    public partial class GSForm: MetroForm, IView
    {
        #region Propriedades
        
        protected Color CustomBackColor = Color.FromArgb(240, 240, 240);

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
                InitializeButtons(_tipoDeForm);
            }
        }

        public bool IsRendering { get; set; }

        public string InstanceId { get; set; }

        #endregion

        #region Construtores

        public GSForm()
        {
            InitializeComponent();

            SetBorderStyle();

            lblTitulo.BringToFront();
        }

        #endregion

        #region Métodos

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.Clear(CustomBackColor);
        }

        public void SetBorderStyle()
        {
            BorderStyle = MetroFormBorderStyle.FixedSingle;
        }

        protected void InitializeButtons(EnumTipoDeForm formType)
        {
            switch (formType)
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
            IsRendering = true;
            TipoDeForm = EnumTipoDeForm.Edicao;
            Presenter.EnableControls();
            IsRendering = false;
        }

        protected virtual void ChamadaSalvarOnClick(object sender, EventArgs e)
        {
            Presenter.FillModelWithControls();
            ChamadaSalvar(sender, e);
        }

        protected virtual void ChamadaCancelarOnClick(object sender, EventArgs e)
        {
            TipoDeForm = EnumTipoDeForm.Detalhamento;
            Presenter.DisableControls();
        }

        protected virtual void ChamadaExcluirOnClick(object sender, EventArgs e)
        {
            var dialogResult = Presenter.DisplayConfirmationPrompt("Tem certeza que deseja excluir?");
            if (dialogResult == DialogResult.Yes) ChamadaExclusao(sender, e);
        }

        protected virtual void ChamadaExclusao(object sender, EventArgs e)
        {
            
        }

        protected virtual void ChamadaSalvar(object sender, EventArgs e)
        {
            
        }

        public void MaximizeFormCall(object sender, EventArgs e)
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
                    CloseFormCall(sender, e);
                    break;
                case EnumTipoDeForm.Detalhamento:
                    ChamadaExcluirOnClick(sender, e);
                    break;
                case EnumTipoDeForm.Edicao:
                    ChamadaCancelarOnClick(sender, e);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public virtual void MinimizeFormCall(object sender, EventArgs e)
        {
            Presenter.MinimizeView(sender, e);
        }
        
        public virtual void CloseFormCall(object sender, EventArgs e)
        {
            Presenter.CloseView(sender, e);
        }

        #endregion

        private void GSForm_Load(object sender, EventArgs e)
        {
            // Don't remove this, VS WinForm designer complains
            Presenter?.ViewDidLoad();
        }
    }
}
