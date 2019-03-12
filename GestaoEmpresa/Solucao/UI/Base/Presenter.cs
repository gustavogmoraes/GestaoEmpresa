using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GS.GestaoEmpresa.Solucao.Negocio.Atributos;
using GS.GestaoEmpresa.Solucao.Negocio.Interfaces;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using GS.GestaoEmpresa.Solucao.UI.ControlesGenericos;
using GS.GestaoEmpresa.Solucao.Utilitarios;
using MetroFramework.Controls;
using MoreLinq;

namespace GS.GestaoEmpresa.Solucao.UI.Base
{
    public abstract class Presenter<TView> : IPresenter
        where TView : Form, IView, new()
    {
        public string IdInstancia { get; set; }

        public IConceito Model { get; private set; }
        IConceito IPresenter.Model { get => Model; set => Model = value; }

        public TView View { get; private set; }
        IView IPresenter.View { get => View; set => View = (TView)value; }

        protected Dictionary<PropertyInfo, string> Mapeamento { get; set; }

        public Presenter()
        {
            View = new TView { Presenter = this };
        }

        protected virtual void MapeieControles<TModel>(
            Dictionary<Expression<Func<TModel, object>>, Expression<Func<TView, Control>>> mapeamento)
            where TModel : class, IConceito, new() 
        {
            Model = new TModel();
            if (mapeamento != null)
            {
                Mapeamento = new Dictionary<PropertyInfo, string>();
                mapeamento.ForEach(x =>
                    Mapeamento.Add(
                        (PropertyInfo)x.Key.GetPropertyFromExpression(),
                        x.Value.GetPropertyFromExpression().Name));
            }
        }

        public virtual void CarregueControlesComModel()
        {
            if ((Model == null) || Mapeamento == null || Mapeamento.Count == 0) return;

            var propriedades = Model.GetType().EncontrePropriedadesMarcadasComAtributo<CampoTela>();
            if (propriedades == null || propriedades.Count == 0) return;

            foreach (var propriedade in propriedades)
            {
                var map = Mapeamento.FirstOrDefault(x => x.Key.Name == propriedade.Name);
                if (map.Key == null) continue;

                var controle = View.Controls.Find(map.Value, true).FirstOrDefault();
                var tipoDoControle = controle.GetType();

                if (ConversoesControlePropriedade.ContainsKey(tipoDoControle))
                {
                    ConversoesControlePropriedade[tipoDoControle].Item1.Invoke(controle, propriedade, Model);
                }
            }

            View.Refresh();
        }

        public virtual void CarregueModelComControles()
        {
            if ((Model == null) || Mapeamento == null || Mapeamento.Count == 0) return;

            var propriedades = Model.GetType().EncontrePropriedadesMarcadasComAtributo<CampoTela>();
            if (propriedades == null || propriedades.Count == 0) return;

            foreach (var propriedade in propriedades)
            {
                var map = Mapeamento.FirstOrDefault(x => x.Key.Name == propriedade.Name);
                if (map.Key == null) continue;

                var controle = View.Controls.Find(map.Value, true).FirstOrDefault();
                var tipoDoControle = controle.GetType();

                if (ConversoesControlePropriedade.ContainsKey(tipoDoControle))
                {
                    ConversoesControlePropriedade[tipoDoControle].Item2.Invoke(controle, propriedade, Model);
                }
            }
        }

        public DialogResult ExibaPromptConfirmacao(string mensagem)
        {
            return (DialogResult) ExecuteFuncaoNaView(() => { return MessageBox.Show(mensagem, "Confirmação", MessageBoxButtons.YesNo); });
        }

        public void ExecuteAcaoNaView(Action acao)
        {
            View.Invoke((MethodInvoker) delegate { acao.Invoke(); });
        }

        public object ExecuteFuncaoNaView(Func<object> funcao)
        {
            return View.Invoke((MethodInvoker)delegate { funcao.Invoke(); });
        }

        private static Dictionary<Type, Tuple<Action<Control, PropertyInfo, object>, Action<Control, PropertyInfo, object>>> ConversoesControlePropriedade = 
            new Dictionary<Type, Tuple<Action<Control, PropertyInfo, object>, Action<Control, PropertyInfo, object>>>
            {
                {
                    typeof(MetroTextBox),
                    new Tuple<Action<Control, PropertyInfo, object>, Action<Control, PropertyInfo, object>>(
                        (controle, propriedade, model) =>
                        {
                            ((MetroTextBox) controle).Text = propriedade.GetValue(model, null).ToString();
                        },
                        (controle, propriedade, model) =>
                        {
                            propriedade.SetValue(model, Convert.ChangeType(((MetroTextBox) controle).Text, propriedade.PropertyType));
                        })
                },
                {
                    typeof(MetroComboBox),
                    new Tuple<Action<Control, PropertyInfo, object>, Action<Control, PropertyInfo, object>>(
                        (controle, propriedade, model) =>
                        {
                            ((MetroComboBox)controle).SelectedText = (string)propriedade.GetValue(model, null);
                        },
                        (controle, propriedade, model) =>
                        {
                            propriedade.SetValue(model, ((MetroComboBox)controle).SelectedText);
                        })
                },
                {
                    typeof(MetroCheckBox),
                    new Tuple<Action<Control, PropertyInfo, object>, Action<Control, PropertyInfo, object>>(
                        (controle, propriedade, model) =>
                        {
                            ((MetroCheckBox)controle).Checked = (bool)propriedade.GetValue(model, null);
                        },
                        (controle, propriedade, model) =>
                        {
                            propriedade.SetValue(model, ((MetroCheckBox)controle).Checked);
                        })
                },
                {
                    typeof(MetroDateTime),
                    new Tuple<Action<Control, PropertyInfo, object>, Action<Control, PropertyInfo, object>>(
                        (controle, propriedade, model) =>
                        {
                            ((MetroDateTime)controle).Value = (DateTime)propriedade.GetValue(model, null);
                        },
                        (controle, propriedade, model) =>
                        {
                            propriedade.SetValue(model, ((MetroDateTime)controle).Value);
                        })
                },
                {
                    typeof(GSMetroToggle),
                    new Tuple<Action<Control, PropertyInfo, object>, Action<Control, PropertyInfo, object>>(
                        (controle, propriedade, model) =>
                        {
                            ((GSMetroToggle)controle).Checked = (bool)propriedade.GetValue(model, null);
                        },
                        (controle, propriedade, model) =>
                        {
                            propriedade.SetValue(((GSMetroToggle)controle).Checked, null);
                        })
                },
                {
                    typeof(GSTextBoxMonetaria),
                    new Tuple<Action<Control, PropertyInfo, object>, Action<Control, PropertyInfo, object>>(
                        (controle, propriedade, model) =>
                        {
                            ((GSTextBoxMonetaria)controle).Valor = (decimal)propriedade.GetValue(model, null);
                        },
                        (controle, propriedade, model) =>
                        {
                            propriedade.SetValue(model, ((GSTextBoxMonetaria)controle).Valor);
                        })
                },
            };
    }
}
