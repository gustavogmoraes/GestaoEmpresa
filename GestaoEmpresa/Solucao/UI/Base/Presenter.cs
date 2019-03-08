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
using GS.GestaoEmpresa.Solucao.UI.ControlesGenericos;
using GS.GestaoEmpresa.Solucao.Utilitarios;
using MetroFramework.Controls;
using MoreLinq;

namespace GS.GestaoEmpresa.Solucao.UI.Base
{
    public abstract class Presenter<TModel, TView>
        where TModel : class, IConceito, new()
        where TView : Form, IView, new()
    {
        public TModel Model { get; set; }

        public TView View { get; set; }

        protected abstract Dictionary<Expression<Func<TModel, object>>, Expression<Func<TView, Control>>> MapeamentoDeControles { get; }

        private Dictionary<PropertyInfo, Control> Mapeamento
        {
            get
            {
                var dicionario = new Dictionary<PropertyInfo, Control>();
                MapeamentoDeControles.ForEach(x => 
                    dicionario.Add(
                        (PropertyInfo)x.Key.GetPropertyFromExpression(),
                        View.Controls.Find(x.Value.GetPropertyFromExpression().Name, false).FirstOrDefault()));

                return dicionario;
            }
        }

        public virtual void CarregueControlesComModel()
        {
            if (Mapeamento != null && Mapeamento.Count > 0)
            {
                var propriedades = Model.GetType().EncontrePropriedadesMarcadasComAtributo<CampoTela>();

                if (propriedades != null && propriedades.Count > 0)
                {
                    foreach (var propriedade in propriedades)
                    {
                        //Controls.Find(MapeamentoDeControles[propriedade].Name, false).FirstOrDefault();
                        var map = Mapeamento.FirstOrDefault(x => x.Key.Name == propriedade.Name);
                        if (map.Key == null) continue;

                        var controle = map.Value;
                        var tipo = controle.GetType();

                        if (tipo == typeof(MetroTextBox))
                        {
                            ((MetroTextBox)controle).Text = propriedade.GetValue(Model, null).ToString();
                        }
                        else if (tipo == typeof(MetroComboBox))
                        {
                            ((MetroComboBox)controle).SelectedText = (string)propriedade.GetValue(Model, null);
                        }
                        else if (tipo == typeof(MetroCheckBox))
                        {
                            ((MetroCheckBox)controle).Checked = (bool)propriedade.GetValue(Model, null);
                        }
                        else if (tipo == typeof(MetroDateTime))
                        {
                            ((MetroDateTime)controle).Value = (DateTime)propriedade.GetValue(Model, null);
                        }
                        else if (tipo == typeof(GSMetroToggle))
                        {
                            ((GSMetroToggle)controle).Checked = (bool)propriedade.GetValue(Model, null);
                        }
                        else if (tipo == typeof(GSTextBoxMonetaria))
                        {
                            ((GSTextBoxMonetaria)controle).Valor = (decimal)propriedade.GetValue(Model, null);
                        }
                    }
                }
            }
        }

        public virtual void CarregueModelComControles()
        {
            Model = new TModel();
            
            
        }
    }
}
