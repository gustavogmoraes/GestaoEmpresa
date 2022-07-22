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
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using GS.GestaoEmpresa.Solucao.Negocio.Servicos;
using GS.GestaoEmpresa.Solucao.Persistencia.BancoDeDados;
using GS.GestaoEmpresa.Solucao.Persistencia.Repositorios;
using GS.GestaoEmpresa.Solucao.UI.Base;
using GS.GestaoEmpresa.Solucao.UI.ControlesGenericos;
using GS.GestaoEmpresa.Solucao.Utilitarios;
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
            ApplyUpdates();
        }

        private void BulkUpdateProductsModal_Load(object sender, EventArgs e)
        {
            FillManufacturerCombo();
        }

        private void FillManufacturerCombo()
        {
            using var productService = new ServicoDeProduto();
            var manufacturers = productService.ObtenhaFabricantes();

            comboManufacturer.Items.AddRange(manufacturers.ToArray());
        }

        private BulkUpdateFilter GetFilterData() => new BulkUpdateFilter
        {
            SellingProfitPercentage = chkFilterSell.Checked ? txtFilterSell.Value.GetValueOrDefault() : null,
            FinalConsumerProfitPercentage = chkFilterConsumer.Checked ? txtFilterFinalConsumer.Value.GetValueOrDefault() : null,
            Manufacturer = chkManufacturer.Checked ? comboManufacturer.SelectedText : null
        };

        private BulkUpdateCommand GetCommandData() => new BulkUpdateCommand
        {
            Filter = GetFilterData(),
            SellingProfitPercentage = chkPorcentagemDeLucroCompraParaVenda.Checked
                ? txtPctLucroVenda.Value.GetValueOrDefault()
                : null,
            FinalConsumerProfitPercentage = chkPorcentagemDeLucroDistribuidorParaConsumidor.Checked
                ? txtPctLucroConsFinal.Value.GetValueOrDefault()
                : null
        };

        private void ApplyUpdates()
        {
            using var service = new ServicoDeProduto();
            var command = GetCommandData();
            
            GSWaitForm.Mostrar(() => service.BulkUpdateProducts(command), () => MessageBox.Show("Concluído com sucesso!"));
        }
    }
}
