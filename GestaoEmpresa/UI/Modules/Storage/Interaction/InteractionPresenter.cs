using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using GS.GestaoEmpresa.Solucao.UI.Base;
using GS.GestaoEmpresa.Solucao.UI.Modulos.Estoque;
using GS.GestaoEmpresa.Business;
using GS.GestaoEmpresa.Business.Objects.Storage;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns.Estoque;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using GS.GestaoEmpresa.Solucao.UI.ControlesGenericos;
using GS.GestaoEmpresa.Solucao.UI.Modulos.Atendimento;
using GS.GestaoEmpresa.Solucao.Utilitarios;
using MetroFramework.Controls;

namespace GS.GestaoEmpresa.UI.Modules.Storage.Interaction
{
    public sealed class InteractionPresenter : Presenter<Business.Objects.Storage.Interaction, FrmInteracaoMetro>
    {
        public Dictionary<int, List<string>> ProductSerialNumberBinder { get; set; }

        public InteractionPresenter()
        {
            MapControl(x => x.Code, x => x.txtCodigo);
            MapControl(x => x.InteractionType, x => x.cbTipo);
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
        }

        private object[] SubInteractionToRowObject(SubInteraction sub, InteractionType type) => new object[]
        {
            sub.Product.Code,
            sub.Product.Manufacturer,
            sub.Product.Name,
            type == InteractionType.Input ? sub.Product.PurchasePrice : sub.Product.SalePrice,
            sub.Quantity,
            sub.TotalPrice
        };

        public Action<object, Control, PropertyInfo, object> SubInteractionsPropertyControlConversion => (model, control, prop, _) =>
        {
            var interaction = (Business.Objects.Storage.Interaction)model;
            var productsGrid = (MetroGrid)control;
            var listOfSubs = (List<SubInteraction>)prop.GetValue(model);
            if (listOfSubs == null || !listOfSubs.Any())
            {
                return;
            }

            foreach (var sub in listOfSubs)
            {
                productsGrid.Rows.Add(SubInteractionToRowObject(sub, interaction.InteractionType));
                if (sub.InformsSerialNumber)
                {
                    ProductSerialNumberBinder.Add(sub.Product.Code, new List<string>());
                    ProductSerialNumberBinder[sub.Product.Code].AddRange(sub.SerialNumbers);
                }
            }
        };

        private Action<Control, PropertyInfo, object, IPresenter> SubInteractionsControlPropertyConversion => (control, prop, model, presenter) =>
        {
            var tabPageUnities = (TabPage)control;
            var listOfUnities = new List<Unidade>();

            foreach (var tabPage in tabPageUnities.Controls["tabControlUnidades"].Controls.OfType<TabPage>())
            {
                var gbAddress = tabPage.Controls["gbEndereco"];
                var gbPhones = tabPage.Controls["gbTelefones"];

                var unity = new Unidade
                {
                    Nome = tabPage.Name,
                    Endereco = new Endereco
                    {
                        Logradouro = gbAddress.GetControl("txtLogradouro")?.Text.GetValueOrNull(),
                        Numero = gbAddress.GetControl("txtNumero")?.Text.GetValueOrNull(),
                        Complemento = gbAddress.GetControl("txtComplemento")?.Text.GetValueOrNull(),
                        Bairro = gbAddress.GetControl("txtBairro")?.Text.GetValueOrNull(),
                        CEP = gbAddress.GetControl("txtCep")?.Text.GetValueOrNull(),
                        Cidade = gbAddress.GetControl("txtCidade")?.Text.GetValueOrNull(),
                        Estado = gbAddress.GetControl("cbEstado")?.Text.GetValueOrNull(),
                        Localizacao = GetLocationFromAttacher((GSLocationAttacher)gbAddress.GetControl("gsLocation"))
                    },
                    Telefones = GetPhones((MetroGrid)gbPhones.GetControl("gridTelefones"))
                };
            }
        };

    }
}
