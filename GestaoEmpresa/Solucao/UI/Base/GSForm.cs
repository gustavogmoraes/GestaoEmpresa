using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using GS.GestaoEmpresa.Properties;
using GS.GestaoEmpresa.Solucao.Negocio.Atributos;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns;
using GS.GestaoEmpresa.Solucao.Negocio.Interfaces;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using GS.GestaoEmpresa.Solucao.UI.ControlesGenericos;
using GS.GestaoEmpresa.Solucao.UI.Modulos.Estoque;
using GS.GestaoEmpresa.Solucao.Utilitarios;
using MetroFramework.Controls;
using MetroFramework.Forms;
using MoreLinq;

namespace GS.GestaoEmpresa.Solucao.UI.Base
{
    public partial class GSForm: MetroForm, IView
    {
        #region Propriedades

        public EnumBotoesForm SwitchBotaoEditarSalvar { get; set; }

        public EnumBotoesForm SwitchBotaoCancelarExcluir { get; set; }

        public IPresenter Presenter { get; set; }

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

        #endregion

        #region Construtores

        public GSForm()
        {
            InitializeComponent();
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
            TipoDeForm = EnumTipoDeForm.Edicao;
            Presenter.HabiliteControles();
        }

        protected virtual void ChamadaSalvarOnClick(object sender, EventArgs e)
        {
            Presenter.CarregueModelComControles();
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
            Presenter.MinimizarView(sender, e);
        }

        public virtual void ChamadaFecharForm(object sender, EventArgs e)
        {
            Presenter.FecharView(sender, e);
        }

        #endregion
    }
}
