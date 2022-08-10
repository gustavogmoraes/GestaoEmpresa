#region Usings

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using GS.GestaoEmpresa.Business.Enumerators.Default;
using GS.GestaoEmpresa.Infrastructure.Persistence.RavenDB.Support.Interfaces;
using GS.GestaoEmpresa.Persistence.RavenDbSupport.Objects;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Seguros.TipoDePessoa;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using GS.GestaoEmpresa.Solucao.UI.Base;
using GS.GestaoEmpresa.Solucao.UI.ControlesGenericos;
using GS.GestaoEmpresa.Solucao.Utilitarios;
using MetroFramework.Controls;

#region Core

#endregion

#region Ours

#endregion

#region Third-party

#endregion

#endregion

namespace GS.GestaoEmpresa.UI.Base
{
    public abstract class Presenter<TModel, TView> : IPresenter
        where TModel : class, IEntity, new()
        where TView : Form, IView, new()
    {
        #region Properties

        public string InstanceId { get; set; }

        #region Generics

        public TModel Model { get; set; }
        IEntity IPresenter.Model
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

        protected List<ControlMapping<TModel, TView>> ControlsMappings { get; set; }

        #endregion

        #endregion

        #region Constructor

        protected Presenter()
        {
            View = new TView { Presenter = this };
            Model = new TModel();
        }

        #endregion

        #region Protected Methods

        protected virtual void MapControl(
            Expression<Func<TModel, object>> objectProperty,
            Expression<Func<TView, Control>> viewControl,
            Action<TModel, Control, PropertyInfo, TModel> propertyToControlConversion = null,
            Action<Control, PropertyInfo, TModel, IPresenter> controlToPropertyConversion = null)
        {
            if (objectProperty == null || viewControl == null) return;
            Model ??= new TModel();
            ControlsMappings ??= new List<ControlMapping<TModel, TView>>();

            ControlsMappings.Add(new ControlMapping<TModel, TView>(objectProperty, viewControl, propertyToControlConversion, controlToPropertyConversion));
        }

        #endregion

        #region Public Methods


        #endregion

        public virtual void FillControlsWithModel(bool reloading = false)
        {
            View.IsRendering = true;
            if (Model == null || ControlsMappings == null || ControlsMappings.Count == 0) return;

            var validityControls = ControlsMappings.Any(x => x.ControlName.ToLowerInvariant().Contains("validity"));
            if (validityControls)
            {
                var control = (MetroComboBox)View.Controls.Find("cbValidity", false).FirstOrDefault();
                LoadValidityComboBox(control, Model.Id);
            }

            ControlsMappings.ForEach(mapping =>
            {
                var control = View.Controls.Find(mapping.ControlName, true).FirstOrDefault();
                var controlType = control?.GetType();

                if (_controlPropertyConversions.ContainsKey(controlType ?? throw new InvalidOperationException()))
                {
                    _controlPropertyConversions[controlType].Item1.Invoke(control, mapping.ObjectProperty, Model, this);
                }

                if (mapping.PropertyControlConversion != null)
                {
                    mapping.PropertyControlConversion.Invoke(Model, control, mapping.ObjectProperty, null);
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
                var control = View.Controls.Find(mapping.ControlName, true).FirstOrDefault();
                var controlType = control?.GetType();

                if (controlType == null) 
                {
                    throw new InvalidOperationException();
                }

                if(mapping.ControlPropertyConversion != null)
                {
                    mapping.ControlPropertyConversion.Invoke(control, mapping.ObjectProperty, Model, this);
                    continue;
                }

                if (_controlPropertyConversions.ContainsKey(controlType))
                {
                    _controlPropertyConversions[controlType].Item2.Invoke(control, mapping.ObjectProperty, Model, this);
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
            ViewManager.Delete(View.GetType(), InstanceId);
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

            switch (View.FormType)
            {
                case FormType.Insert:
                    ExecuteOnView((Action) (() => validityCombo.Enabled = false));
                    break;
                case FormType.Detail:
                    break;
                case FormType.Update:
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

            switch (View.FormType)
            {
                case FormType.Insert:
                    ExecuteOnView(() =>
                    {
                        validityComboBox.Enabled = false;
                    });
                    break;
                case FormType.Detail:
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
                case FormType.Update:
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
            switch (View.FormType)
            {
                case FormType.Insert:
                    EnableControls();
                    break;
                case FormType.Detail:
                    FillControlsWithModel();
                    DisableControls(new [] { "cbValidity" });
                    break;
                case FormType.Update:
                    EnableControls();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public virtual async Task<IList<Error>> SaveAsync()
        {
            return null;
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

        private readonly Dictionary<Type, Tuple<Action<Control, PropertyInfo, TModel, IPresenter>, Action<Control, PropertyInfo, TModel, IPresenter>>> _controlPropertyConversions = new()
        {
            {
                typeof(MetroTextBox),
                new Tuple<Action<Control, PropertyInfo, TModel, IPresenter>, Action<Control, PropertyInfo, TModel, IPresenter>>(

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
                new Tuple<Action<Control, PropertyInfo, TModel, IPresenter>, Action<Control, PropertyInfo, TModel, IPresenter>>(
                    (control, property, model, presenter) =>
                    {
                        var valorProp = property.GetValue(model, null);
                        var isValidityComboBox = control.Name == "cbValidity";

                        if (isValidityComboBox)
                        {
                            presenter.View.IsRendering = true;
                            if(((MetroComboBox) control).Items.Count > 0)
                            {
                                ((MetroComboBox) control).SelectedIndex = 0;
                            }
                        }
                        else ((MetroComboBox) control).SelectedText = valorProp.ToString();
                    },
                    (control, property, model, presenter) =>
                    {
                        var isValidityComboBox = control.Name == "cbValidity";
                        var controlValue = (isValidityComboBox 
                                                ? ((MetroComboBox) control).SelectedText
                                                : ((MetroComboBox) control).SelectedItem??string.Empty).ToString();

                        if (isValidityComboBox && string.IsNullOrEmpty(controlValue))
                        {
                            controlValue = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
                        }

                        var value = isValidityComboBox
                            ? (object)controlValue.ConvertaParaDateTime(EnumFormatacaoDateTime.DD_MM_YYYY_HH_MM_SS, '/')
                            : controlValue;

                        if(property.PropertyType.IsEnum)
                        {
                            value = Enum.Parse(typeof(EnumTiposDePessoa), value.ToString().RemoveDiacritics(), true);
                        }

                        property.SetValue(model, value);
                    })
            },
            {
                typeof(MetroCheckBox),
                new Tuple<Action<Control, PropertyInfo, TModel, IPresenter>, Action<Control, PropertyInfo, TModel, IPresenter>>(
                    (control, property, model, presenter) =>
                    {
                        ((MetroCheckBox)control).Checked = (bool)property.GetValue(model, null);
                    },
                    (control, property, model, presenter) =>
                    {
                        property.SetValue(model, ((MetroCheckBox)control).Checked);
                    })
            },
            {
                typeof(MetroDateTime),
                new Tuple<Action<Control, PropertyInfo, TModel, IPresenter>, Action<Control, PropertyInfo, TModel, IPresenter>>(
                    (control, property, model, presenter) =>
                    {
                        ((MetroDateTime)control).Value = (DateTime)property.GetValue(model, null);
                    },
                    (control, property, model, presenter) =>
                    {
                        property.SetValue(model, ((MetroDateTime)control).Value);
                    })
            },
            {
                typeof(GSMetroToggle),
                new Tuple<Action<Control, PropertyInfo, TModel, IPresenter>, Action<Control, PropertyInfo, TModel, IPresenter>>(
                    (control, property, model, presenter) =>
                    {
                        ((GSMetroToggle)control).Checked = (EnumStatusToggle)property.GetValue(model, null) == EnumStatusToggle.Active;
                    },
                    (control, property, model, presenter) =>
                    {
                        if(property.PropertyType == typeof(EnumStatusToggle))
                        {
                            var valorToggle = ((GSMetroToggle)control).Checked ? EnumStatusToggle.Active : EnumStatusToggle.Inactive;
                            property.SetValue(model, valorToggle);
                        }
                        else
                        {
                            var valor = ((GSMetroToggle)control).Checked;
                            property.SetValue(model, valor);
                        }
                    })
            },
            {
                typeof(GSMetroMonetary),
                new Tuple<Action<Control, PropertyInfo, TModel, IPresenter>, Action<Control, PropertyInfo, TModel, IPresenter>>(
                    (control, property, model, presenter) =>
                    {
                        ((GSMetroMonetary)control).Value = Math.Round((decimal)property.GetValue(model, null), 2);
                    },
                    (control, property, model, presenter) =>
                    {
                        property.SetValue(model, ((GSMetroMonetary)control).Value);
                    })
            },
            {
                typeof(GSImageAttacher),
                new Tuple<Action<Control, PropertyInfo, TModel, IPresenter>, Action<Control, PropertyInfo, TModel, IPresenter>>(
                    (control, property, model, presenter) =>
                    {
                        var imageAttacher = ((GSImageAttacher)control);
                        imageAttacher.tabControl.TabPages.Clear();

                        var attachments = (RavenAttachments)property.GetValue(model);
                        if(attachments == null)
                        {
                            return;
                        }

                        foreach(var attachment in attachments.FileStreams?.Where(x => x.Key.StartsWith("Image")))
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
                    (control, property, model, presenter) =>
                    {
                        var imageAttacher = ((GSImageAttacher)control);
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
                                dictionary.Add("Image-" + count, image.ToStream(ImageFormat.Png));
                            }

                            count++;
                        }

                        var ravenAttachments = new RavenAttachments 
                        { 
                            FileStreams = dictionary,
                            AttachmentsNames = dictionary.Keys.ToList() 
                        };

                        property.SetValue(model, ravenAttachments);
                    })
            }
        };

        protected async Task LoadValidityComboBox(MetroComboBox cbValidity, string id)
        {
            cbValidity.Items.Clear();

            using var service = ViewManager.GetDefaultHistoricServiceByModel(Model);
            if (service == null) return;

            var validityList = (await service.QueryRevisionsAsync(id)).ToList();
            foreach (var validity in validityList)
            {
                cbValidity.Items.Add(validity.ToString(CultureInfo.GetCultureInfo("pt-BR")));
            }

            //// The last validity is selected on the FillControlsWithModel delegate
        }
    }
}
