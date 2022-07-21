#region Usings

#region Core

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

#endregion

#region Ours

using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Seguros.TipoDePessoa;
using GS.GestaoEmpresa.Solucao.Negocio.Interfaces;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos.Base;
using GS.GestaoEmpresa.Solucao.Persistencia.BancoDeDados;
using GS.GestaoEmpresa.Solucao.Persistencia.Interfaces;
using GS.GestaoEmpresa.Solucao.UI.ControlesGenericos;
using GS.GestaoEmpresa.Solucao.Utilitarios;

#endregion

#region Third-party

using MetroFramework.Controls;

#endregion

#endregion

namespace GS.GestaoEmpresa.Solucao.UI.Base
{
    public abstract class Presenter<TModel, TView> : IPresenter
        where TModel : class, IConceito, new()
        where TView : Form, IView, new()
    {
        #region Properties

        public string IdInstancia { get; set; }

        public bool CodeFiredChange { get; set; }

        #region Generics

        public TModel Model { get; set; }
        IConceito IPresenter.Model
        {
            get => Model;
            set => Model = (TModel)value;
        }

        public TView View { get; set; }
        IView IPresenter.View
        {
            get => View;
            set => View = (TView)value;
        }

        protected List<MapeamentoDeControle<TModel, TView>> MapeamentoDeControles { get; set; }

        #endregion

        #endregion

        #region Constructor

        protected Presenter()
        {
            View = new TView { Presenter = this };
        }

        #endregion

        #region Protected Methods

        protected virtual void MapeieControle(
            Expression<Func<TModel, object>> propriedade,
            Expression<Func<TView, Control>> controle,
            Action<object, Control, PropertyInfo, object> conversaoPropriedadeControle = null,
            Action<Control, PropertyInfo, object, IPresenter> conversaoControlePropriedade = null)
        {
            if (propriedade == null || controle == null) return;
            if (Model == null) Model = new TModel();
            if (MapeamentoDeControles == null) MapeamentoDeControles = new List<MapeamentoDeControle<TModel, TView>>();

            MapeamentoDeControles.Add(new MapeamentoDeControle<TModel, TView>(
                propriedade, controle, conversaoPropriedadeControle, conversaoControlePropriedade));
        }

        protected virtual void MapeieControle(
            Expression<Func<TModel, object>> propriedade,
            Expression<Func<TView, IComponent>> controle,
            Action<object, Control> conversaoPropriedadeControle = null,
            Action<Control, object> conversaoControlePropriedade = null)
        {
            if (propriedade == null || controle == null) return;
            if (Model == null) Model = new TModel();
            if (MapeamentoDeControles == null) MapeamentoDeControles = new List<MapeamentoDeControle<TModel, TView>>();

            //MapeamentoDeControles.Add(new MapeamentoDeControle<TModel, TView>(
            //    propriedade, controle, conversaoPropriedadeControle, conversaoControlePropriedade));
        }

        #endregion

        #region Public Methods


        #endregion

        public virtual void CarregueControlesComModel(bool reloading = false)
        {
            //if(View.EstahRenderizando && !reloading)
            //{
            //    return;
            //}

            View.EstahRenderizando = true;
            if (Model == null || MapeamentoDeControles == null || MapeamentoDeControles.Count == 0) return;

            if (MapeamentoDeControles.Any(x => x.PropriedadeObjeto.Name.ToLowerInvariant().Contains("vigencia")))
            {
                var controle = (MetroComboBox)View.Controls.Find("cbVigencia", false).FirstOrDefault();
                CarregueComboDeVigencias(controle, Model.Codigo);
            }

            MapeamentoDeControles.ForEach(mapeamento =>
            {
                if (mapeamento.PropriedadeObjeto.GetValue(Model) == null && !reloading)
                {
                    return;
                }

                var controle = View.Controls.Find(mapeamento.NomeControle, true).FirstOrDefault();
                var tipoDoControle = controle?.GetType();

                if (ConversoesControlePropriedade.ContainsKey(tipoDoControle ?? throw new InvalidOperationException()))
                {
                    ConversoesControlePropriedade[tipoDoControle].Item1.Invoke(controle, mapeamento.PropriedadeObjeto, Model, this);
                }
            });

            View.Refresh();
            View.EstahRenderizando = false;
        }

        public virtual void CarregueModelComControles()
        {
            if (Model == null || MapeamentoDeControles == null || MapeamentoDeControles.Count == 0) return;

            foreach(var mapeamento in MapeamentoDeControles)
            {
                var controle = View.Controls.Find(mapeamento.NomeControle, true).FirstOrDefault();
                var tipoDoControle = controle?.GetType();

                if (tipoDoControle == null) 
                {
                    throw new InvalidOperationException();
                }

                if(mapeamento.ConversaoControlePropriedade != null)
                {
                    mapeamento.ConversaoControlePropriedade.Invoke(controle, mapeamento.PropriedadeObjeto, Model, this);
                    continue;
                }

                if (ConversoesControlePropriedade.ContainsKey(tipoDoControle))
                {
                    ConversoesControlePropriedade[tipoDoControle].Item2.Invoke(controle, mapeamento.PropriedadeObjeto, Model, this);
                }
            }
        }

        public DialogResult ExibaPromptConfirmacao(string mensagem)
        {
            return (DialogResult) ExecuteFuncaoNaView(() => MessageBox.Show(mensagem, "Confirmação", MessageBoxButtons.YesNo));
        }

        public void MinimizarView(object sender, EventArgs eventArgs)
        {
            View.WindowState = FormWindowState.Minimized;
        }

        public void FecharView(object sender, EventArgs eventArgs)
        {
            View.Close();
            GerenciadorDeViews.Exclua(View.GetType(), IdInstancia);
        }

        public void HabiliteControles(IList<string> excecoes = null)
        {
            SwitchControles(true, excecoes);

            if(View.EstahRenderizando)
            {
                var imageAttachers = View.Controls.OfType<GSImageAttacher>().ToList();
                foreach (var attacher in imageAttachers)
                {
                    attacher.Switch(true);
                }
            }

            var comboVigencia = View.Controls.OfType<Control>().FirstOrDefault(x => x.Name == "cbVigencia");
            if (comboVigencia == null)
            {
                return;
            }

            switch (View.TipoDeForm)
            {
                case EnumTipoDeForm.Cadastro:
                    ExecuteAcaoNaView(() => comboVigencia.Enabled = false);
                    break;
                case EnumTipoDeForm.Detalhamento:
                    break;
                case EnumTipoDeForm.Edicao:
                    ExecuteAcaoNaView(() => comboVigencia.Enabled = false);
                    break;
            }
        }

        public void DesabiliteControles(IList<string> excecoes = null)
        {
            SwitchControles(false, excecoes);

            var imageAttachers = View.Controls.OfType<GSImageAttacher>().ToList();
            foreach(var attacher in imageAttachers)
            {
                attacher.Switch(false);
            }

            var comboVigencia = View.Controls.OfType<Control>().FirstOrDefault(x => x.Name == "cbVigencia");
            if (comboVigencia == null) return;

            switch (View.TipoDeForm)
            {
                case EnumTipoDeForm.Cadastro:
                    ExecuteAcaoNaView(() =>
                    {
                        comboVigencia.Enabled = false;
                    });
                    break;
                case EnumTipoDeForm.Detalhamento:
                    ExecuteAcaoNaView(() => 
                    {
                        comboVigencia.Enabled = true;
                        foreach(var attacher in imageAttachers)
                        {
                            attacher.Enabled = true;
                            attacher.tabControl.Enabled = true;
                        }
                    }
                    );
                    break;
                case EnumTipoDeForm.Edicao:
                    ExecuteAcaoNaView(() =>
                    {
                        comboVigencia.Enabled = true;
                    });
                    break;
            }
        }

        public virtual void ViewCarregada()
        {
            switch (View.TipoDeForm)
            {
                case EnumTipoDeForm.Cadastro:
                    HabiliteControles();
                    break;
                case EnumTipoDeForm.Detalhamento:
                    CarregueControlesComModel();
                    DesabiliteControles(new [] { "cbVigencia" });
                    break;
                case EnumTipoDeForm.Edicao:
                    HabiliteControles();
                    break;
            }
        }

        private void SwitchControles(bool opcao, IList<string> excecoes)
        {
            var listaDeExcecao = (excecoes ?? new List<string>()).ToList();

            var listaControles = View.Controls.Cast<Control>().ToList();

            var topBorder = listaControles.Find(x => x.GetType() == typeof(Panel) || x.GetType() == typeof(MetroPanel));
            if (topBorder != null)
                listaDeExcecao.Add(topBorder.Name);

            listaDeExcecao.Add(string.Empty);
            var listaNomesControles = listaControles.Select(x => x.Name)
                                                    .Except(listaDeExcecao)
                                                    .ToList();
            

            listaNomesControles.ForEach(x => View.Controls.Find(x, true).FirstOrDefault().Enabled = opcao);
        }

        public void ExecuteAcaoNaView(Action acao)
        {
            Task.Run(() =>
            {
                while (!View.CanSelect) { }
                View.Invoke((MethodInvoker)delegate { acao.Invoke(); });
            });
        }

        public object ExecuteFuncaoNaView(Func<object> funcao)
        {
            object result = null;
            View.Invoke((MethodInvoker)delegate { result = funcao.Invoke(); });

            return result;
        }

        private static Dictionary<Type, Tuple<Action<Control, PropertyInfo, object, IPresenter>, Action<Control, PropertyInfo, object, IPresenter>>> ConversoesControlePropriedade = new()
        {
            {
                typeof(MetroTextBox),
                new Tuple<Action<Control, PropertyInfo, object, IPresenter>, Action<Control, PropertyInfo, object, IPresenter>>(

                    // Objeto --> Controle
                    (controle, propriedade, model, presenter) =>
                    {
                        var valor = propriedade.GetValue(model, null);
                        if (propriedade.PropertyType.IsAny(typeof(decimal), typeof(decimal?)))
                        {
                            valor = Math.Round(Convert.ToDecimal(valor), 2);
                        }

                        ((MetroTextBox) controle).Text = (valor ?? string.Empty).ToString();
                    },

                    // Controle --> Objeto
                    (controle, propriedade, model, presenter) =>
                    {
                        var valor = ((MetroTextBox) controle).Text;
                        if (propriedade.PropertyType.IsNumericType() && string.IsNullOrEmpty(valor))
                        {
                            valor = 0.ToString();
                        }

                        // This worksaround nullable types
                        var safeType = Nullable.GetUnderlyingType(propriedade.PropertyType) ?? propriedade.PropertyType;
                        var safeValue = string.IsNullOrEmpty(valor) ? null : Convert.ChangeType(valor, safeType);

                        propriedade.SetValue(model, safeValue);
                    })
            },
            {
                typeof(MetroComboBox),
                new Tuple<Action<Control, PropertyInfo, object, IPresenter>, Action<Control, PropertyInfo, object, IPresenter>>(
                    (controle, propriedade, model, presenter) =>
                    {
                        var valorProp = propriedade.GetValue(model, null);
                        var ehCbVigencia = controle.Name == "cbVigencia";

                        if (ehCbVigencia)
                        {
                            presenter.View.EstahRenderizando = true;
                            if(((MetroComboBox) controle).Items.Count > 0)
                            {
                                ((MetroComboBox) controle).SelectedIndex = 0;
                            }
                        }
                        else ((MetroComboBox) controle).SelectedText = valorProp.ToString();
                    },
                    (controle, propriedade, model, presenter) =>
                    {
                        var ehCbVigencia = controle.Name == "cbVigencia";
                        var valorControle = (ehCbVigencia
                                                ? ((MetroComboBox) controle).SelectedText
                                                : ((MetroComboBox) controle).SelectedItem).ToString();

                        if (ehCbVigencia && string.IsNullOrEmpty(valorControle))
                        {
                            valorControle = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                        }

                        var value = ehCbVigencia
                            ? (object)valorControle.ConvertaParaDateTime(EnumFormatacaoDateTime.DD_MM_YYYY_HH_MM_SS, '/')
                            : valorControle;

                        if(propriedade.PropertyType.IsEnum)
                        {
                            value = Enum.Parse(typeof(EnumTiposDePessoa), value.ToString().RemoveDiacritics(), true);
                        }

                        propriedade.SetValue(model, value);
                    })
            },
            {
                typeof(MetroCheckBox),
                new Tuple<Action<Control, PropertyInfo, object, IPresenter>, Action<Control, PropertyInfo, object, IPresenter>>(
                    (controle, propriedade, model, presenter) =>
                    {
                        ((MetroCheckBox)controle).Checked = (bool)propriedade.GetValue(model, null);
                    },
                    (controle, propriedade, model, presenter) =>
                    {
                        propriedade.SetValue(model, ((MetroCheckBox)controle).Checked);
                    })
            },
            {
                typeof(MetroDateTime),
                new Tuple<Action<Control, PropertyInfo, object, IPresenter>, Action<Control, PropertyInfo, object, IPresenter>>(
                    (controle, propriedade, model, presenter) =>
                    {
                        ((MetroDateTime)controle).Value = (DateTime)propriedade.GetValue(model, null);
                    },
                    (controle, propriedade, model, presenter) =>
                    {
                        propriedade.SetValue(model, ((MetroDateTime)controle).Value);
                    })
            },
            {
                typeof(GSMetroToggle),
                new Tuple<Action<Control, PropertyInfo, object, IPresenter>, Action<Control, PropertyInfo, object, IPresenter>>(
                    (controle, propriedade, model, presenter) =>
                    {
                        ((GSMetroToggle)controle).Checked = (EnumStatusToggle)propriedade.GetValue(model, null) == EnumStatusToggle.Ativo;
                    },
                    (controle, propriedade, model, presenter) =>
                    {
                        if(propriedade.PropertyType == typeof(EnumStatusToggle))
                        {
                            var valorToggle = ((GSMetroToggle)controle).Checked ? EnumStatusToggle.Ativo : EnumStatusToggle.Inativo;
                            propriedade.SetValue(model, valorToggle);
                        }
                        else
                        {
                            var valor = ((GSMetroToggle)controle).Checked;
                            propriedade.SetValue(model, valor);
                        }
                    })
            },
            {
                typeof(GSMetroMonetary),
                new Tuple<Action<Control, PropertyInfo, object, IPresenter>, Action<Control, PropertyInfo, object, IPresenter>>(
                    (controle, propriedade, model, presenter) =>
                    {
                        var value = ((decimal?)propriedade.GetValue(model, null)).GetValueOrDefault();
                        var control = (GSMetroMonetary)controle;

                        control.Value = Math.Round(value, 2);
                    },
                    (controle, propriedade, model, presenter) =>
                    {
                        var control = (GSMetroMonetary)controle;
                        propriedade.SetValue(model, control.Value);
                    })
            },
            {
                typeof(GSImageAttacher),
                new Tuple<Action<Control, PropertyInfo, object, IPresenter>, Action<Control, PropertyInfo, object, IPresenter>>(
                    // Object --> Control
                    (controle, propriedade, model, presenter) =>
                    {
                        var imageAttacher = ((GSImageAttacher)controle);
                        imageAttacher.tabControl.TabPages.Clear();

                        var attachments = (RavenAttachments)propriedade.GetValue(model);
                        if(attachments == null)
                        {
                            return;
                        }

                        foreach(var attachment in attachments.FileStreams.Where(x => x.Key.StartsWith("Image")))
                        {
                            var tabPage = imageAttacher.AddTabPageExternal(
                                imageAttacher.tabControl,
                                imageAttacher.tabControl.SelectedTab, 
                                Image.FromStream(attachment.Value),
                                addInsteadOfInsert: true);
                        }

                        if (imageAttacher.tabControl.TabPages.OfType<TabPage>().Any())
                        {
                            imageAttacher.tabControl.SelectedTab = imageAttacher.tabControl.TabPages.OfType<TabPage>().FirstOrDefault();
                        }
                    },
                    // Control --> Object
                    (controle, propriedade, model, presenter) =>
                    {
                        var imageAttacher = ((GSImageAttacher)controle);
                        var imageList = imageAttacher.tabControl.TabPages.OfType<TabPage>()
                            .Where(x => x.Name != "tabAdd")
                            .Select(x => x.BackgroundImage)
                            .ToList();

                        var count = 1;
                        var dictionary = new Dictionary<string, Stream>();

                        foreach(var image in imageList)
                        {
                            if(image != null)
                            {
                                dictionary.Add("Image-" + count.ToString(), image.ToStream(ImageFormat.Png));
                            }

                            count++;
                        }

                        var ravenAttachments = new RavenAttachments 
                        { 
                            FileStreams = dictionary,
                            AttachmentsNames = dictionary.Keys.ToList() 
                        };

                        propriedade.SetValue(model, ravenAttachments);
                    })
            }
        };

        protected void CarregueComboDeVigencias(MetroComboBox cbVigencia, int codigo)
        {
            cbVigencia.Items.Clear();

            var listaDeVigencias = new List<DateTime>();
            using (var servico = GerenciadorDeViews.ObtenhaServicoHistoricoPadraoPorModel(Model))
            {
                if (servico == null) return;
                listaDeVigencias = servico.ConsulteVigencias(codigo).ToList();
            }

            foreach (var vigencia in listaDeVigencias)
            {
                cbVigencia.Items.Add(vigencia.ToString(CultureInfo.GetCultureInfo("pt-BR")));
            }

            // A última vigência é selecionada no delegate do método CarregueControlesComModel
        }
    }
}
