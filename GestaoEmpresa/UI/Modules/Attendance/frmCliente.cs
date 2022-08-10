using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GS.GestaoEmpresa.Business.Enumerators.Default;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns;
using GS.GestaoEmpresa.Solucao.UI.Base;
using GS.GestaoEmpresa.Solucao.UI.ControlesGenericos;
using GS.GestaoEmpresa.UI.Base;
using GS.GestaoEmpresa.UI.GenericControls;
using GS.GestaoEmpresa.UI.Modules.Attendance;

namespace GS.GestaoEmpresa.Solucao.UI.Modulos.Atendimento
{
    public partial class FrmCliente : GSForm, IView
    {
        public FrmCliente()
        {
            InitializeComponent();
        }

        protected override async Task SaveCall(object sender, EventArgs e)
        {
            var result = await (Presenter as ClientePresenter)?.Salve();
            if (result.Any())
            {
                result.ToList().ForEach(x => MessageBox.Show(x.Message, "Inconsistência"));
                return;
            }

            var cadastroOuAtualizacao = FormType == FormType.Insert ? "Cadastrado" : "Atualizado";
            MessageBox.Show($"{cadastroOuAtualizacao} com sucesso!", "Resultado");

            GSWaitForm.Mostrar(() =>
            {
                Invoke((MethodInvoker)delegate
                {
                    FormType = FormType.Detail;
                    Presenter.ViewDidLoad();
                });
            });
        }

        protected override void DeleteCall(object sender, EventArgs e)
        {
            //var result = (Presenter as ClientePresenter)?.Delete(Presenter.Model.Codigo);
            //if (result.Any())
            //{
            //    result.ToList().ForEach(x => MessageBox.Show(x.Message, "Inconsistência"));

            //}

            MessageBox.Show("Excluído com sucesso!", "Resultado");
            Presenter.CloseView(sender, e);
        }

        protected override void ChamadaEditarOnClick(object sender, EventArgs e)
        {
            IsRendering = true;
            FormType = FormType.Update;
            Presenter.EnableControls();
            IsRendering = false;
        }

        private void TabPage3_Click(object sender, EventArgs e)
        {

        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            ((ClientePresenter)Presenter).Load();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            Process.Start("https://goo.gl/maps/whuXchW9SUKgWhSa9");
        }

        private void CbTipoDePessoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbTipoDePessoa.SelectedText == "Física")
            {
                txtRazaoSocial.Text = string.Empty;
                txtRazaoSocial.Enabled = false;
            }
            else if(cbTipoDePessoa.SelectedText == "Jurídica")
            {
                txtRazaoSocial.Enabled = true;
            }
        }
    }
}
