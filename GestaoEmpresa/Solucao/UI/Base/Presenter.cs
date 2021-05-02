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

        protected List<MapeamentoDeControle<TModel, TView>> ControlsMappings { get; set; }

        #endregion

        #endregion

        #region Constructor

        protected Presenter()
        {
            View = new TView { Presenter = this };
        }

        #endregion

        #region Protected Methods

        protected virtual void MapControl(
            Expression<Func<TModel, object>> objectProperty,
            Expression<Func<TView, Control>> viewControl,
            Action<object, Control, PropertyInfo, object> propertyToControlConversion = null,
            Action<Control, PropertyInfo, object, IPresenter> controlToPropertyConversion = null)
        {
            if (objectProperty == null || viewControl == null) return;
            Model ??= new TModel();
            ControlsMappings ??= new List<MapeamentoDeControle<TModel, TView>>();

            ControlsMappings.Add(new MapeamentoDeControle<TModel, TView>(
                objectProperty, viewControl, propertyToControlConversion, controlToPropertyConversion));
        }

        #endregion

        #region Public Methods


        #endregion

        public virtual void FillControlsWithModel(bool reloading = false)
        {
            View.IsRendering = true;
            if (Model == null || ControlsMappings == null || ControlsMappings.Count == 0) return;

            var validityControls = ControlsMappings.Any(x => x.PropriedadeObjeto.Name.ToLowerInvariant().Contains("validity"));
            if (validityControls)
            {
                var control = (MetroComboBox)View.Controls.Find("cbValidity", false).FirstOrDefault();
                LoadValidityComboBox(control, Model.Codigo);
            }

            ControlsMappings.ForEach(mapping =>
            {
                if (mapping.PropriedadeObjeto.GetValue(Model) == null)
                {
                    return;
                }

                var control = View.Controls.Find(mapping.NomeControle, true).FirstOrDefault();
                var controlType = control?.GetType();

                if (_controlPropertyConversions.ContainsKey(controlType ?? throw new InvalidOperationException()))
                {
                    _controlPropertyConversions[controlType].Item1.Invoke(control, mapping.PropriedadeObjeto, Model, this);
                }
            });

            View.Refresh();
            View.IsRendering = false;
        }

        public virtual void FillModelWithControls()
        {
            if (Model == null || ControlsMappings == null || ControlsMappings.Count == 0) return;

            foreach(var mapping in ControlsMappings)
            {
                var control = View.Controls.Find(mapping.NomeControle, true).FirstOrDefault();
                var controlType = control?.GetType();

                if (controlType == null) 
                {
                    throw new InvalidOperationException();
                }

                if(mapping.ConversaoControlePropriedade != null)
                {
                    mapping.ConversaoControlePropriedade.Invoke(control, mapping.PropriedadeObjeto, Model, this);
                    continue;
                }

                if (_controlPropertyConversions.ContainsKey(controlType))
                {
                    _controlPropertyConversions[controlType].Item2.Invoke(control, mapping.PropriedadeObjeto, Model, this);
                }
            }
        }

        public DialogResult DisplayConfirmationPrompt(string message)
        {
            return (DialogResult) ExecuteOnView(() => MessageBox.Show(message, "Confirmação", MessageBoxButtons.YesNo));
        }

        public void MinimizeView(object sender, EventArgs eventArgs)
        {
            View.WindowState = FormWindowState.Minimized;
        }

        public void CloseView(object sender, EventArgs eventArgs)
        {
            View.Close();
            GerenciadorDeViews.Exclua(View.GetType(), IdInstancia);
        }

        public void EnableControls(IList<string> exceptions = null)
        {
            SwitchControls(true, exceptions);

            if(View.IsRendering)
            {
                var imageAttachers = View.Controls.OfType<GSImageAttacher>().ToList();
                foreach (var attacher in imageAttachers)
                {
                    attacher.Switch(true);
                }
            }

            var validityCombo = View.Controls.OfType<Control>().FirstOrDefault(x => x.Name == "cbValidity");
            if (validityCombo == null)
            {
                return;
            }

            switch (View.TipoDeForm)
            {
                case EnumTipoDeForm.Cadastro:
                    ExecuteOnView((Action) (() => validityCombo.Enabled = false));
                    break;
                case EnumTipoDeForm.Detalhamento:
                    break;
                case EnumTipoDeForm.Edicao:
                    ExecuteOnView((Action) (() => validityCombo.Enabled = false));
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void DisableControls(IList<string> exceptions = null)
        {
            SwitchControls(false, exceptions);

            var imageAttachers = View.Controls.OfType<GSImageAttacher>().ToList();
            foreach(var attacher in imageAttachers)
            {
                attacher.Switch(false);
            }

            var validityComboBox = View.Controls.OfType<Control>().FirstOrDefault(x => x.Name == "cbValidity");
            if (validityComboBox == null) return;

            switch (View.TipoDeForm)
            {
                case EnumTipoDeForm.Cadastro:
                    ExecuteOnView(() =>
                    {
                        validityComboBox.Enabled = false;
                    });
                    break;
                case EnumTipoDeForm.Detalhamento:
                    ExecuteOnView(() => 
                    {
                        validityComboBox.Enabled = true;
                        foreach(var attacher in imageAttachers)
                        {
                            attacher.Enabled = true;
                            attacher.tabControl.Enabled = true;
                        }
                    }
                    );
                    break;
                case EnumTipoDeForm.Edicao:
                    ExecuteOnView(() =>
                    {
                        validityComboBox.Enabled = true;
                    });
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public virtual void ViewDidLoad()
        {
            switch (View.TipoDeForm)
            {
                case EnumTipoDeForm.Cadastro:
                    EnableControls();
                    break;
                case EnumTipoDeForm.Detalhamento:
                    FillControlsWithModel();
                    DisableControls(new [] { "cbValidity" });
                    break;
                case EnumTipoDeForm.Edicao:
                    EnableControls();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void SwitchControls(bool option, IList<string> exceptions)
        {
            var exceptionList = (exceptions ?? new List<string>()).ToList();
            var controlList = View.Controls.Cast<Control>().ToList();

            var topBorder = controlList.Find(x => x.GetType() == typeof(Panel) || x.GetType() == typeof(MetroPanel));
            if (topBorder != null)
                exceptionList.Add(topBorder.Name);

            exceptionList.Add(string.Empty);
            var controlNameList = controlList
                .Select(x => x.Name)
                .Except(exceptionList)
                .ToList();
            

            controlNameList.ForEach(x =>
            {
                var foundControl = View.Controls.Find(x, true);
                if (!foundControl.Any()) return;

                foundControl[0].Enabled = option;
            });
        }

        public void ExecuteOnView(Action action)
        {
            Task.Run(() =>
            {
                while (!View.CanSelect) { }
                View.Invoke((MethodInvoker)action.Invoke);
            });
        }

        public object ExecuteOnView(Func<object> function)
        {
            object result = null;
            View.Invoke((MethodInvoker)delegate { result = function.Invoke(); });

            return result;
        }

        private readonly Dictionary<Type, Tuple<Action<Control, PropertyInfo, object, IPresenter>, Action<Control, PropertyInfo, object, IPresenter>>> _controlPropertyConversions =
            new Dictionary<Type, Tuple<Action<Control, PropertyInfo, object, IPresenter>, Action<Control, PropertyInfo, object, IPresenter>>>
            {
                {
                    typeof(MetroTextBox),
                    new Tuple<Action<Control, PropertyInfo, object, IPresenter>, Action<Control, PropertyInfo, object, IPresenter>>(

                        // Object --> Control
                        (control, property, model, presenter) =>
                        {
                            var valor = property.GetValue(model, null);
                            if (property.PropertyType.IsAny(typeof(decimal), typeof(decimal?)))
                            {
                                valor = Math.Round(Convert.ToDecimal(valor), 2);
                            }

                            ((MetroTextBox) control).Text = (valor ?? string.Empty).ToString();
                        },

                        // Control --> Object
                        (control, property, model, presenter) =>
                        {
                            var valor = ((MetroTextBox)control).Text.Trim();
                            if (property.PropertyType.IsNumericType() && string.IsNullOrEmpty(valor))
                            {
                                valor = 0.ToString();
                            }

                            // This works around nullable types
                            var safeType = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
                            var safeValue = string.IsNullOrEmpty(valor) ? null : Convert.ChangeType(valor, safeType);

                            property.SetValue(model, safeValue);
                        })
                },
                {
                    typeof(MetroComboBox),
                    new Tuple<Action<Control, PropertyInfo, object, IPresenter>, Action<Control, PropertyInfo, object, IPresenter>>(
                        (controle, propriedade, model, presenter) =>
                        {
                            var valorProp = propriedade.GetValue(model, null);
                            var ehCbVigencia = controle.Name == "cbValidity";

                            if (ehCbVigencia)
                            {
                                presenter.View.IsRendering = true;
                                if(((MetroComboBox) controle).Items.Count > 0)
                                {
                                    ((MetroComboBox) controle).SelectedIndex = 0;
                                }
                            }
                            else ((MetroComboBox) controle).SelectedText = valorProp.ToString();
                        },
                        (controle, propriedade, model, presenter) =>
                        {
                            var ehCbVigencia = controle.Name == "cbValidity";
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
                            ((GSMetroMonetary)controle).Value = Math.Round((decimal)propriedade.GetValue(model, null), 2);
                        },
                        (controle, propriedade, model, presenter) =>
                        {
                            propriedade.SetValue(model, ((GSMetroMonetary)controle).Value);
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

        protected void LoadValidityComboBox(MetroComboBox cbValidity, int code)
        {
            cbValidity.Items.Clear();

            using var service = GerenciadorDeViews.ObtenhaServicoHistoricoPadraoPorModel(Model);
            if (service == null) return;

            var validityList = service.ConsulteVigencias(code).ToList();
            foreach (var validity in validityList)
            {
                cbValidity.Items.Add(validity.ToString(CultureInfo.GetCultureInfo("pt-BR")));
            }

            // A última vigência é selecionada no delegate do método FillControlsWithModel
        }
    }
}
