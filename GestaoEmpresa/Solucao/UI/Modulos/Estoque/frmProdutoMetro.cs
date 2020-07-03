using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns;
using GS.GestaoEmpresa.Solucao.Negocio.Interfaces;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using GS.GestaoEmpresa.Solucao.UI.Base;
using GS.GestaoEmpresa.Solucao.UI.ControlesGenericos;
using GS.GestaoEmpresa.Solucao.Utilitarios;

namespace GS.GestaoEmpresa.Solucao.UI.Modulos.Estoque
{
    public partial class frmProdutoMetro : GSForm, IView
    {
        public frmProdutoMetro()
        {
            InitializeComponent();

            lblTitulo.BackColor = Color.Empty;
        }

        protected override void ChamadaSalvar(object sender, EventArgs e)
        {
            var result = (Presenter as ProdutoPresenter)?.Salve();
            if(result.Any())
            {
                result.ToList().ForEach(x => MessageBox.Show(x.Mensagem, "Inconsistência"));
                return;
            }

            var cadastroOuAtualizacao = TipoDeForm == EnumTipoDeForm.Cadastro ? "Cadastrado" : "Atualizado";
            MessageBox.Show($"{cadastroOuAtualizacao} com sucesso!", "Resultado");

            GSWaitForm.Mostrar(this, () =>
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
            var result = (Presenter as ProdutoPresenter)?.Exclua(Presenter.Model.Codigo);
            if (result.Any())
            {
                result.ToList().ForEach(x => MessageBox.Show(x.Mensagem, "Inconsistência"));
            }

            MessageBox.Show("Excluído com sucesso!", "Resultado");
            Presenter.FecharView(sender, e);
        }

        private void TxtCodigoDeBarras_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.IsAny(Keys.Return, Keys.Enter))
            {
                txtNome.Focus();
            }
        }

        private void cbVigencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(EstahRenderizando)
            {
                EstahRenderizando = false;
                return;
            }

            var dataVigencia = DateTime.ParseExact((string)cbVigencia.SelectedItem, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            ((ProdutoPresenter) Presenter).RecarregueVigencia(dataVigencia);
        }

        private void txtPorcentagemLucro_Leave(object sender, EventArgs e)
        {
            CalculeEPreenchaPrecoDeCompra();
        }

        private void txtPrecoDeCompra_Leave(object sender, EventArgs e)
        {
            CalculeEPreenchaPrecoDeCompra();
        }

        private void CalculeEPreenchaPrecoDeCompra()
        {
            if (!string.IsNullOrEmpty(txtPrecoDeCompra.Text) &&
                !string.IsNullOrEmpty(txtPorcentagemLucro.Text))
            {
                var precoCompra = Math.Round(Convert.ToDecimal(txtPrecoDeCompra.Text), 2);
                txtPrecoDeCompra.Text = precoCompra.ToString(CultureInfo.InvariantCulture);
                txtPrecoDeVenda.Text = Math.Round((precoCompra * Convert.ToDecimal(txtPorcentagemLucro.Text) / 100) + precoCompra, 2).ToString(CultureInfo.InvariantCulture);
            }
        }
    }
}
