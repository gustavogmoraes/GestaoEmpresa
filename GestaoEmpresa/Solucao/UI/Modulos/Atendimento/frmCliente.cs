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
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns;
using GS.GestaoEmpresa.Solucao.UI.Base;
using GS.GestaoEmpresa.Solucao.UI.ControlesGenericos;

namespace GS.GestaoEmpresa.Solucao.UI.Modulos.Atendimento
{
    public partial class FrmCliente : GSForm, IView
    {
        public FrmCliente()
        {
            InitializeComponent();
        }

        protected override void ChamadaSalvar(object sender, EventArgs e)
        {
            var result = (Presenter as ClientePresenter)?.Salve();
            if (result.Any())
            {
                result.ToList().ForEach(x => MessageBox.Show(x.Mensagem, "Inconsistência"));
                return;
            }

            var cadastroOuAtualizacao = TipoDeForm == EnumTipoDeForm.Cadastro ? "Cadastrado" : "Atualizado";
            MessageBox.Show($"{cadastroOuAtualizacao} com sucesso!", "Resultado");

            GSWaitForm.Mostrar(() =>
            {
                Invoke((MethodInvoker)delegate
                {
                    TipoDeForm = EnumTipoDeForm.Detalhamento;
                    Presenter.ViewCarregada();
                });
            });
        }

        protected override void ChamadaExclusao(object sender, EventArgs e)
        {
            //var result = (Presenter as ClientePresenter)?.Exclua(Presenter.Model.Codigo);
            //if (result.Any())
            //{
            //    result.ToList().ForEach(x => MessageBox.Show(x.Mensagem, "Inconsistência"));

            //}

            MessageBox.Show("Excluído com sucesso!", "Resultado");
            Presenter.FecharView(sender, e);
        }

        protected override void ChamadaEditarOnClick(object sender, EventArgs e)
        {
            EstahRenderizando = true;
            TipoDeForm = EnumTipoDeForm.Edicao;
            Presenter.HabiliteControles();
            EstahRenderizando = false;
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
