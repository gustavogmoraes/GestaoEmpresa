﻿using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using GS.GestaoEmpresa.Business.Enumerators.Default;
using GS.GestaoEmpresa.Properties;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns;
using GS.GestaoEmpresa.Solucao.Utilitarios;
using GS.GestaoEmpresa.UI.GenericControls;
using MetroFramework.Forms;

namespace GS.GestaoEmpresa.UI.Base
{
    public partial class GSForm: MetroForm, IView
    {
        #region Propriedades
        
        protected Color CustomBackColor = Color.FromArgb(240, 240, 240);

        public EnumBotoesForm SwitchBotaoEditarSalvar { get; set; }

        public EnumBotoesForm SwitchBotaoCancelarExcluir { get; set; }

        public  IPresenter Presenter { get; set; }

        private FormType _formType { get; set; }

        public FormType FormType
        {
            get => _formType;
            set
            {
                _formType = value;
                InitializeButtons(_formType);
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

        protected void InitializeButtons(FormType formTypeType)
        {
            switch (formTypeType)
            {
                case FormType.Insert:
                    btnCancelarExcluir.Enabled = false;
                    btnCancelarExcluir.Visible = false;

                    btnEditarSalvar.Image = Resources.floppy_icon;
                    SwitchBotaoEditarSalvar = EnumBotoesForm.Salvar;
                    break;

                case FormType.Update:
                    btnCancelarExcluir.Enabled = true;
                    btnCancelarExcluir.Visible = true;
                    btnCancelarExcluir.Image = Resources.cancel_icon;
                    SwitchBotaoCancelarExcluir = EnumBotoesForm.Cancelar;

                    btnEditarSalvar.Image = Resources.floppy_icon;
                    SwitchBotaoEditarSalvar = EnumBotoesForm.Salvar;

                    break;

                case FormType.Detail:
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
            FormType = FormType.Update;
            Presenter.EnableControls();
            IsRendering = false;
        }

        protected virtual async Task ChamadaSalvarOnClick(object sender, EventArgs e)
        {
            Presenter.FillModelWithControls();
            await SaveCall(sender, e);
        }

        protected virtual void ChamadaCancelarOnClick(object sender, EventArgs e)
        {
            FormType = FormType.Detail;
            Presenter.DisableControls();
        }

        protected virtual void ChamadaExcluirOnClick(object sender, EventArgs e)
        {
            var dialogResult = Presenter.DisplayConfirmationPrompt("Tem certeza que deseja excluir?");
            if (dialogResult == DialogResult.Yes) DeleteCall(sender, e);
        }

        protected virtual void DeleteCall(object sender, EventArgs e)
        {
            
        }

        protected virtual async Task SaveCall(object sender, EventArgs e)
        {
            var result = await Presenter.SaveAsync();
            if (result.IsNotNull() && result!.Any())
            {
                var messages = string.Join("\n", result.Select(x => "- " + x.Message).ToList());
                MessageBox.Show(messages, "Inconsistência");

                return;
            }

            var insertionOrUpdate = FormType == FormType.Insert ? "Cadastrado" : "Atualizado";
            MessageBox.Show($"{insertionOrUpdate} com sucesso!", "Resultado");

            GSWaitForm.Mostrar(() =>
            {
                Invoke((MethodInvoker)delegate
                {
                    FormType = FormType.Detail;
                    Presenter.ViewDidLoad();
                });
            });
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

        private async void btnEditarSalvar_Click(object sender, EventArgs e)
        {
            switch (FormType)
            {
                case FormType.Insert:
                    await ChamadaSalvarOnClick(sender, e);
                    break;
                case FormType.Detail:
                    ChamadaEditarOnClick(sender, e);
                    break;
                case FormType.Update:
                    await ChamadaSalvarOnClick(sender, e);
                    break;
            }
        }

        private void btnCancelarExcluir_Click(object sender, EventArgs e)
        {
            switch (FormType)
            {
                case FormType.Insert:
                    CloseFormCall(sender, e);
                    break;
                case FormType.Detail:
                    ChamadaExcluirOnClick(sender, e);
                    break;
                case FormType.Update:
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