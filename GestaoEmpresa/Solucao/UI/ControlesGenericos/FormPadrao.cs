using GS.GestaoEmpresa.Solucao.Negocio.Catalogos;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores;
using GS.GestaoEmpresa.Solucao.Negocio.Interfaces;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos.ObjetosConcretos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GS.GestaoEmpresa.Solucao.UI
{
    public partial class FormPadrao : Form
    {
        public FormPadrao()
        {
            InitializeComponent();
        }

        #region Utilizáveis no futuro

        //private List<Control> _listaDeControles
        //{
        //    get
        //    {

        //        var listaDeControles = new List<Control>();
        //        EncontreControles(this, listaDeControles, "_Text");

        //        return listaDeControles;
        //    }
        //}

        //public void EncontreControles(Control owner, List<Control> list, string name)
        //{
        //    foreach (Control c in owner.Controls)
        //    {
        //        if (c.Name.Contains(name))
        //        {
        //            list.Add(c);
        //        }
        //        if (c.HasChildren) EncontreControles(c, list, name);
        //    }
        //}

        #endregion


        protected CultureInfo Cultura = new CultureInfo("pt-BR");

        protected EnumBotoesForm _switchBotaoEditarSalvar;

        protected EnumBotoesForm _switchBotaoCancelarExcluir;

        protected EnumTipoDeForm _tipoDoForm;

        protected List<Inconsistencia> _listaDeInconsistencias { get; set; }

        protected virtual void HabiliteControles()
        {
            foreach (Control controle in (this as Form).Controls)
            {
                controle.Enabled = true;
            }
        }

        protected virtual void DesabiliteControles()
        {
            foreach (Control controle in (this as Form).Controls)
            {
                controle.Enabled = false;
            }
        }

        protected void InicializeBotoes(EnumTipoDeForm tipoDeForm,
                                        ref PictureBox btnEditarSalvar,
                                        ref PictureBox btnCancelarExcluir,
                                        ref EnumBotoesForm switchBotaoEditarSalvar,
                                        ref EnumBotoesForm switchBotaoCancelarExcluir)
        {
            switch (tipoDeForm)
            {
                case EnumTipoDeForm.Cadastro:
                    btnCancelarExcluir.Enabled = false;
                    btnCancelarExcluir.Visible = false;

                    btnEditarSalvar.Image = Properties.Resources.floppy_icon;
                    switchBotaoEditarSalvar = EnumBotoesForm.Salvar;
                    break;

                case EnumTipoDeForm.Edicao:
                    btnCancelarExcluir.Enabled = true;
                    btnCancelarExcluir.Visible = true;
                    btnCancelarExcluir.Image = Properties.Resources.cancel_icon;
                    switchBotaoCancelarExcluir = EnumBotoesForm.Cancelar;

                    btnEditarSalvar.Image = Properties.Resources.floppy_icon;
                    switchBotaoEditarSalvar = EnumBotoesForm.Salvar;
                    break;

                case EnumTipoDeForm.Detalhamento:
                    btnCancelarExcluir.Enabled = true;
                    btnCancelarExcluir.Visible = true;
                    btnCancelarExcluir.Image = Properties.Resources.delete;
                    switchBotaoCancelarExcluir = EnumBotoesForm.Excluir;

                    btnEditarSalvar.Image = Properties.Resources.edit_512;
                    switchBotaoEditarSalvar = EnumBotoesForm.Editar;
                    break;
            }

            btnEditarSalvar.Refresh();
            btnCancelarExcluir.Refresh();
        }

        private void FormPadrao_Load(object sender, EventArgs e)
        {

        }

        //protected void InicializeInconsistencias()
        //{
        //    //Despintar os controles
        //    //foreach (Control controle in (this as Form).Controls)
        //    //{
        //    //    controle.ForeColor = Color.Silver;
        //    //}

        //    if (_listaDeInconsistencias == null)
        //    {
        //        _listaDeInconsistencias = new List<Inconsistencia>();
        //    }

        //    if (_listaDeInconsistencias.Count == 0)
        //    {
        //        return;
        //    }

        //    if (_listaDeInconsistencias.Count > 0)
        //    {
        //        foreach (var inconsistencia in _listaDeInconsistencias)
        //        {
        //            //FlowLayoutPanel.Add(
        //            //    new Label()
        //            //    {
        //            //        Text = string.Format("{0}, ", inconsistencia.Mensagem)
        //            //    });

        //             [inconsistencia.NomeDaPropriedadeValidada].ForeColor = Color.Red;
        //        }
        //    }
        //}

    }
}
