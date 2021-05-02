using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using GS.GestaoEmpresa.Solucao.UI.Base;
using GS.GestaoEmpresa.Solucao.UI.ControlesGenericos;
using GS.GestaoEmpresa.Solucao.Utilitarios;
using MetroFramework.Controls;

namespace GS.GestaoEmpresa.Solucao.UI.Modulos.Atendimento
{
    public class ClientePresenter : Presenter<Cliente, FrmCliente>
    {
        public ClientePresenter()
        {
            MapControl(x => x.Codigo, x => x.txtCodigo);
            MapControl(x => x.Status, x => x.toggleStatus);
            MapControl(x => x.CadastroPendente, x => x.toggleCadastroPendente);

            MapControl(x => x.Nome, x => x.txtNomeDoCliente);
            MapControl(x => x.TipoDePessoa, x => x.cbTipoDePessoa);
            MapControl(x => x.RG, x => x.txtRG);
            MapControl(x => x.InscricaoEstadual, x => x.txtInscricaoEstadual);
            MapControl(x => x.InscricaoMunicipal, x => x.txtInscricaoMunicipal);
            MapControl(x => x.RazaoSocial, x => x.txtRazaoSocial);
            MapControl(x => x.RamoDoNegocio, x => x.txtRazaoSocial);
            MapControl(x => x.Observacao, x => x.txtObservacoes);

            MapControl(x => x.Unidades, x => x.tabUnidades, ConversaoPropriedadeControleUnidades, ConversaoControlePropriedadeUnidades);
        }

        public List<Inconsistencia> Salve()
        {
            return new List<Inconsistencia>();
        }

        private Action<object, Control, PropertyInfo, object> ConversaoPropriedadeControleUnidades => (model, control, prop, presenter) =>
        {
            var listOfUnities = (List<Unidade>)prop.GetValue(model);
            if (listOfUnities == null || !listOfUnities.Any())
            {
                return;
            }

            var tabUnities = (TabPage)control;
            var form = (FrmCliente)control.Parent;


            //foreach(var unity in listOfUnities)
            //{
            //    tabUnities.Controls.OfType<>
            //}
        };

        private Action<Control, PropertyInfo, object, IPresenter> ConversaoControlePropriedadeUnidades => (control, prop, model, presenter) =>
        {
            var tabPageUnities = (TabPage)control;
            var listOfUnities = new List<Unidade>();

            foreach(var tabPage in tabPageUnities.Controls["tabControlUnidades"].Controls.OfType<TabPage>())
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

        public void Load()
        {
            View.tabControl.SelectedTab = View.tabDadosCadastrais;

            View.tabControlUnidades.Click += (a, b) =>
            {
                var selectedTab = View.tabControl.SelectedTab;
                if (selectedTab.Text == "+")
                {
                    //_ = AddTabPageExternal(View.tabControlUnidades, selectedTab);
                }
            };

            switch (View.TipoDeForm)
            {
                case Negocio.Enumeradores.Comuns.EnumTipoDeForm.Cadastro:
                    View.tabUnidades.Controls.OfType<Control>().ToList().ForEach(x => x.Visible = false);
                    break;
                case Negocio.Enumeradores.Comuns.EnumTipoDeForm.Detalhamento:
                    break;
                case Negocio.Enumeradores.Comuns.EnumTipoDeForm.Edicao:
                    break;
            }
        }

        //public TabPage AddTabPageExternal(TabControl tabControl, TabPage selectedTab, Image image = null, bool addInsteadOfInsert = false)
        //{
        //    var tabName = GetTabName(tabControl);
        //    var tabPage = GetTabPage(tabName);

        //    AddAttachButton(tabPage);
        //    AddDeleteButton(tabPage);
        //    AddDownloadButton(tabPage);

        //    AddOrInsertTabPageIntoTabControl(tabControl, selectedTab, tabPage, addInsteadOfInsert);

        //    tabControl.SelectTab(tabPage);
        //    tabPage.Focus();

        //    if (image != null)
        //    {
        //        AttachImageToTabPage(tabPage, image);
        //    }

        //    return tabPage;
        //}

        private List<Telefone> GetPhones(MetroGrid metroGrid)
        {
            var phones = new List<Telefone>();

            foreach(DataGridViewRow row in metroGrid.Rows)
            {
                phones.Add(new Telefone
                {
                    Descricao = row.Cells["colunaDescricao"].Value?.ToString(),
                    Numero = row.Cells["colunaNumero"].Value?.ToString(),
                    RangeDDR = row.Cells["colunaRangeDDR"].Value?.ToString(),
                    EhWhatsApp = Convert.ToBoolean(row.Cells["colunaEhWhatsApp"].Value)
                }) ;
            }

            return phones;
        }

        private string GetLocationFromAttacher(GSLocationAttacher gSLocationAttacher)
        {
            return string.Empty;
        }
    }
}
