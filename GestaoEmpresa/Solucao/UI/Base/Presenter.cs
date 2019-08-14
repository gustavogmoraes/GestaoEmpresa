﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GS.GestaoEmpresa.Solucao.Negocio.Atributos;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns;
using GS.GestaoEmpresa.Solucao.Negocio.Interfaces;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using GS.GestaoEmpresa.Solucao.Negocio.Servicos;
using GS.GestaoEmpresa.Solucao.UI.ControlesGenericos;
using GS.GestaoEmpresa.Solucao.Utilitarios;
using MetroFramework.Controls;
using MoreLinq;
using OfficeOpenXml.FormulaParsing.Utilities;

namespace GS.GestaoEmpresa.Solucao.UI.Base
{
    public abstract class Presenter<TModel, TView> : IPresenter
        where TModel : class, IConceito, new()
        where TView : Form, IView, new()
    {
        public string IdInstancia { get; set; }

        public IConceito Model { get; set; }

        //TModel IPresenter.Model { get => Model; set => Model = value; }

        public TView View { get; private set; }
        IView IPresenter.View { get => View; set => View = (TView)value; }

        protected List<MapeamentoDeControle<TModel, TView>> MapeamentoDeControles { get; set; }

        //protected Dictionary<PropertyInfo, string> Mapeamento { get; set; }

        protected Presenter()
        {
            View = new TView { Presenter = this };
        }

        protected virtual void MapeieControles(
            Dictionary<Expression<Func<TModel, object>>, Expression<Func<TView, Control>>> mapeamento)
        {
            //Model = new TModel();
            //if (mapeamento == null) return;

            //Mapeamento = new Dictionary<PropertyInfo, string>();
            //mapeamento.ForEach(x =>
            //    Mapeamento.Add(
            //        (PropertyInfo)x.Key.GetPropertyFromExpression(),
            //        x.Value.GetPropertyFromExpression().Name));
        }

        protected virtual void MapeieControle(
            Expression<Func<TModel, object>> propriedade,
            Expression<Func<TView, Control>> controle,
            Action<object, Control> conversaoPropriedadeControle = null,
            Action<Control, object> conversaoControlePropriedade = null)
        {
            if (propriedade == null || controle == null) return;
            if (Model == null) Model = new TModel();
            if(MapeamentoDeControles == null) MapeamentoDeControles = new List<MapeamentoDeControle<TModel, TView>>();
            
            MapeamentoDeControles.Add(new MapeamentoDeControle<TModel, TView>(
                propriedade, controle, conversaoPropriedadeControle, conversaoControlePropriedade));
        }

        public virtual void CarregueControlesComModel()
        {
            if (Model == null || MapeamentoDeControles == null || MapeamentoDeControles.Count == 0) return;

            if (MapeamentoDeControles.Any(x => x.PropriedadeObjeto.Name.ToLowerInvariant().Contains("vigencia")))
            {
                var controle = (MetroComboBox)View.Controls.Find("cbVigencia", false).FirstOrDefault();
                CarregueComboDeVigencias(controle, Model.Codigo);
            }

            MapeamentoDeControles.ForEach(mapeamento =>
            {
                var controle = View.Controls.Find(mapeamento.NomeControle, true).FirstOrDefault();
                var tipoDoControle = controle?.GetType();

                if (ConversoesControlePropriedade.ContainsKey(tipoDoControle ?? throw new InvalidOperationException()))
                {
                    ConversoesControlePropriedade[tipoDoControle].Item1.Invoke(controle, mapeamento.PropriedadeObjeto, Model);
                }
            });

            View.Refresh();
        }

        public virtual void CarregueModelComControles()
        {
            if (Model == null || MapeamentoDeControles == null || MapeamentoDeControles.Count == 0) return;

            MapeamentoDeControles.ForEach(mapeamento =>
            {
                var controle = View.Controls.Find(mapeamento.NomeControle, true).FirstOrDefault();
                var tipoDoControle = controle?.GetType();

                if (ConversoesControlePropriedade.ContainsKey(tipoDoControle ?? throw new InvalidOperationException()))
                {
                    ConversoesControlePropriedade[tipoDoControle].Item2.Invoke(controle, mapeamento.PropriedadeObjeto, Model);
                }
            });
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
        }

        public void DesabiliteControles(IList<string> excecoes = null)
        {
            SwitchControles(false, excecoes);
        }

        private void SwitchControles(bool opcao, IList<string> excecoes)
        {
            if (excecoes == null) excecoes = new List<string>();
            
            var listaControles = View.Controls.Cast<Control>().ToList();

            var topBorder = listaControles.Find(x => x.GetType() == typeof(Panel) || x.GetType() == typeof(MetroPanel));
            if (topBorder != null)
                excecoes.Add(topBorder.Name);

            excecoes.Add(string.Empty);
            var listaNomesControles = listaControles.Select(x => x.Name)
                                                    .Except(excecoes)
                                                    .ToList();
            

            listaNomesControles.ForEach(x => View.Controls.Find(x, true).FirstOrDefault().Enabled = opcao);
        }

        public void ExecuteAcaoNaView(Action acao)
        {
            View.Invoke((MethodInvoker) delegate { acao.Invoke(); });
        }

        public object ExecuteFuncaoNaView(Func<object> funcao)
        {
            object result = null;
            View.Invoke((MethodInvoker)delegate { result = funcao.Invoke(); });

            return result;
        }

        private static Dictionary<Type, Tuple<Action<Control, PropertyInfo, object>, Action<Control, PropertyInfo, object>>> ConversoesControlePropriedade = 
            new Dictionary<Type, Tuple<Action<Control, PropertyInfo, object>, Action<Control, PropertyInfo, object>>>
            {
                {
                    typeof(MetroTextBox),
                    new Tuple<Action<Control, PropertyInfo, object>, Action<Control, PropertyInfo, object>>(

                        // Objeto --> Controle
                        (controle, propriedade, model) =>
                        {
                            var valor = propriedade.GetValue(model, null);
                            ((MetroTextBox) controle).Text = (valor ?? string.Empty).ToString();
                        },

                        // Controle --> Objeto
                        (controle, propriedade, model) =>
                        {
                            var valor = ((MetroTextBox) controle).Text;
                            if (propriedade.PropertyType.IsNumericType() && valor == string.Empty)
                            {
                                valor = 0.ToString();
                            }

                            propriedade.SetValue(model, Convert.ChangeType(valor, propriedade.PropertyType));
                        })
                },
                {
                    typeof(MetroComboBox),
                    new Tuple<Action<Control, PropertyInfo, object>, Action<Control, PropertyInfo, object>>(
                        (controle, propriedade, model) =>
                        {
                            var valorProp = propriedade.GetValue(model, null);
                            var ehCbVigencia = controle.Name == "cbVigencia";
                            if (ehCbVigencia)
                                ((MetroComboBox) controle).SelectedItem = ((MetroComboBox) controle).Items.Cast<string>().ToList().FirstOrDefault();
                            else ((MetroComboBox) controle).SelectedText = valorProp.ToString();
                        },
                        (controle, propriedade, model) =>
                        {
                            var ehCbVigencia = controle.Name == "cbVigencia";
                            var valorControle = ((MetroComboBox) controle).SelectedText;

                            if (valorControle == string.Empty)
                                valorControle = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

                            propriedade.SetValue(model, ehCbVigencia 
                                                            ? (object)valorControle.ConvertaParaDateTime(EnumFormatacaoDateTime.DD_MM_YYYY_HH_MM_SS, '/')
                                                            : valorControle);
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
                            ((GSMetroToggle)controle).Checked = (EnumStatusToggle)propriedade.GetValue(model, null) == EnumStatusToggle.Ativo;
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
