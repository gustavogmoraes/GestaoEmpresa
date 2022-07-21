using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GS.GestaoEmpresa.Solucao.Negocio.Servicos;
using GS.GestaoEmpresa.Solucao.UI.Base;
using GS.GestaoEmpresa.Solucao.UI.ControlesGenericos;
using MetroFramework.Controls;
using MetroFramework.Forms;

namespace GS.GestaoEmpresa.Solucao.UI.Modulos.Estoque
{
    public partial class BulkUpdateProductsModal : GSForm
    {
        public BulkUpdateProductsModal()
        {
            InitializeComponent();
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            using var service = new ServicoDeProduto();
            var pctLucroVenda = chkPorcentagemDeLucroCompraParaVenda.Checked
                ? (decimal?)txtPctLucroVenda.Value.GetValueOrDefault()
                : null;
            var pctLucroConsumidor = chkPorcentagemDeLucroDistribuidorParaConsumidor.Checked
                ? (decimal?)txtPctLucroConsFinal.Value.GetValueOrDefault()
                : null;

            GSWaitForm.Mostrar(() => service.BulkUpdateProducts(pctLucroVenda, pctLucroConsumidor), () => MessageBox.Show("Concluído com sucesso!"));
        }
    }
}
