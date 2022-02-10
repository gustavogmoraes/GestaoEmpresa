using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Forms;
using GS.GestaoEmpresa.Solucao.UI.Base;
using GS.GestaoEmpresa.Solucao.UI.Modulos.Estoque;
using GS.GestaoEmpresa.Business.Objects.Storage;
using GS.GestaoEmpresa.Business.Services;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns.Estoque;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using GS.GestaoEmpresa.Solucao.Utilitarios;
using GS.GestaoEmpresa.UI.Base;
using GS.GestaoEmpresa.UI.Modules.Storage.Storage;
using MetroFramework.Controls;
using Control = System.Windows.Forms.Control;

namespace GS.GestaoEmpresa.UI.Modules.Storage.Interaction
{
    public sealed class InteractionPresenter : Presenter<Business.Objects.Storage.Interaction, InteractionView>
    {
        public Dictionary<int, List<string>> ProductSerialNumberBinder { get; set; }

        public ProductService ProductService { get; set; }

        public InteractionPresenter()
        {
            MapControl(x => x.Code, x => x.txtCodigo);
            MapControl(x => x.InteractionType, x => x.cbTipo, InteractionTypePropertyControlConversion, InteractionTypeControlPropertyConversion);
            MapControl(x => x.Time, x => x.dtpHorario);
            MapControl(x => x.Situation, x => x.cbSituacao);
            MapControl(x => x.ReturnTime, x => x.dtpHorarioDevolucao);
            MapControl(x => x.InvoiceNumber, x => x.txtNF);
            MapControl(x => x.Technician, x => x.txtColaborador);
            MapControl(x => x.Goal, x => x.cbFinalidade);
            MapControl(x => x.OrderOfServiceNumber, x => x.txtOS);
            MapControl(x => x.Origin, x => x.txtOrigem);
            MapControl(x => x.Destination, x => x.txtDestino);
            MapControl(x => x.Notes, x => x.txtObservacao);
            MapControl(x => x.SubInteractions, x => x.gridProdutos, SubInteractionsPropertyControlConversion, SubInteractionsControlPropertyConversion);

            ProductSerialNumberBinder = new Dictionary<int, List<string>>();
            ProductService = new ProductService();
        }

        public override IList<Error> Save()
        {
            using var interactionService = new InteractionService();
            return interactionService.Save(Model, View.FormType);
        }

        public Action<object, Control, PropertyInfo, object> InteractionTypePropertyControlConversion => (model, control, prop, _) =>
        {
            ((MetroComboBox)control).SelectedItem = ResolveInteractionType((InteractionType)prop.GetValue(model));
        };

        private Action<Control, PropertyInfo, object, IPresenter> InteractionTypeControlPropertyConversion => (control, prop, model, presenter) =>
        {
            var ptValue = ((MetroComboBox) control).SelectedItem?.ToString();
            var interactionType = ResolveInteractionType(ptValue);

            prop.SetValue(model, interactionType);
        };

        private static string ResolveInteractionType(InteractionType interactionType)
        {
            return interactionType switch
            {
                InteractionType.Input => "Entrada",
                InteractionType.Output => "Saída",
                InteractionType.ExchangeBase => "Base de troca",
                _ => null
            };
        }

        private static InteractionType? ResolveInteractionType(string interactionTypeString)
        {
            return interactionTypeString switch
            {
                "Entrada" => InteractionType.Input,
                "Saída" => InteractionType.Output,
                "Base de troca" => InteractionType.ExchangeBase,
                null => null
            };
        }

        private object[] SubInteractionToRowObject(SubInteraction sub, InteractionType type)
        {
            var qty = sub.InteractedQuantity;
            var price = type == InteractionType.Input
                ? sub.Product.PurchasePrice.GetValueOrDefault()
                : sub.Product.SalePrice;

            var total = Convert.ToDecimal(qty) * price.GetValueOrDefault();

            return new object[]
            {
                sub.Product.Code,
                sub.Product.Manufacturer,
                sub.Product.ManufacturerCode,
                sub.Product.Name,
                type == InteractionType.Input ? sub.Product.PurchasePrice : sub.Product.SalePrice,
                qty,
                total
            };
        }

        private SubInteraction RowObjectToSubInteraction(DataGridViewRow row)
        {
            var product = ProductService.QueryFirst(x => x.Code == (int) row.Cells["colunaCodigo"].Value);  
            if (product == null)
            {
                throw new Exception("Product could not be found by interaction");

            }

            var informsSerialNumber = ProductSerialNumberBinder.ContainsKey(product.Code);

            var subInteraction = new SubInteraction
            {
                Product = product,
                InteractedQuantity = (int)row.Cells["colunaQuantidade"].Value,
                UnitaryPrice = ((string)row.Cells["colunaValor"].Value).ToDecimal(),
                TotalPrice = ((string)row.Cells["colunaTotal"].Value).ToDecimal(),
                InformsSerialNumber = informsSerialNumber,
                SerialNumbers = informsSerialNumber ? ProductSerialNumberBinder[product.Code] : null
            };

            return subInteraction;
        }

        public Action<Business.Objects.Storage.Interaction, Control, PropertyInfo, Business.Objects.Storage.Interaction> SubInteractionsPropertyControlConversion => (interaction, control, prop, _) =>
        {
            var productsGrid = (MetroGrid)control;
            var listOfSubs = (List<SubInteraction>)prop.GetValue(interaction);
            if (listOfSubs == null || !listOfSubs.Any())
            {
                return;
            }

            foreach (var sub in listOfSubs)
            {
                productsGrid.Rows.Add(SubInteractionToRowObject(sub, interaction.InteractionType.GetValueOrDefault()));
                if (!sub.InformsSerialNumber)
                {
                    continue;
                }

                if (!ProductSerialNumberBinder.ContainsKey(sub.Product.Code))
                {
                    ProductSerialNumberBinder.Add(sub.Product.Code, new List<string>());
                }
                
                ProductSerialNumberBinder[sub.Product.Code].AddRange(sub.SerialNumbers);
            }
        };

        private Action<Control, PropertyInfo, Business.Objects.Storage.Interaction, IPresenter> SubInteractionsControlPropertyConversion => (control, prop, interaction, _) =>
        {
            var productsGrid = (MetroGrid)control;
            var listOfSubs = new List<SubInteraction>();

            for (var i = 0; i < productsGrid.RowCount; i++)
            {
                var sub = RowObjectToSubInteraction(productsGrid.Rows[i]);
                if(sub.InformsSerialNumber && ProductSerialNumberBinder.ContainsKey(sub.Product.Code))
                {
                    sub.SerialNumbers.AddRange(ProductSerialNumberBinder[sub.Product.Code]);
                }

                listOfSubs.Add(sub);
            }

            prop.SetValue(interaction, listOfSubs);
        };
    }
}
