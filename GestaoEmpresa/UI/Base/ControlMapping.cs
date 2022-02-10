using System;
using System.Linq.Expressions;
using System.Reflection;
using System.Windows.Forms;
using GS.GestaoEmpresa.Solucao.Utilitarios;
using GS.GestaoEmpresa.UI.Base;

namespace GS.GestaoEmpresa.Solucao.UI.Base
{
    public class ControlMapping<TModel, TView>
        where TModel : class, new()
        where TView : Form, IView, new()
    {
        public ControlMapping(
            Expression<Func<TModel, object>> property,
            Expression<Func<TView, Control>> control,
            Action<TModel, Control, PropertyInfo, TModel> propertyControlConversion = null,
            Action<Control, PropertyInfo, TModel, IPresenter> controlPropertyConversion = null)
        {
            ObjectProperty = (PropertyInfo)property.GetPropertyFromExpression();
            ControlName = control.GetPropertyFromExpression().Name;

            PropertyControlConversion = propertyControlConversion;
            ControlPropertyConversion = controlPropertyConversion;
        }

        public PropertyInfo ObjectProperty { get; set; }

        public string ControlName { get; set; }

        public Action<TModel, Control, PropertyInfo, TModel> PropertyControlConversion { get; set; }

        public Action<Control, PropertyInfo, TModel, IPresenter> ControlPropertyConversion { get; set; }
    }
}
