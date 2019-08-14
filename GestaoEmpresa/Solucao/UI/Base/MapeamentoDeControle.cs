using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GS.GestaoEmpresa.Solucao.Negocio.Interfaces;
using GS.GestaoEmpresa.Solucao.Utilitarios;

namespace GS.GestaoEmpresa.Solucao.UI.Base
{
    public class MapeamentoDeControle<TModel, TView>
        where TModel : class, IConceito, new()
        where TView : Form, IView, new()
    {
        public MapeamentoDeControle(
            Expression<Func<TModel, object>> propriedade,
            Expression<Func<TView, Control>> control,
            Action<object, Control> conversaoPropriedadeControle = null,
            Action<Control, object> conversaoControlePropriedade = null)
        {
            PropriedadeObjeto = (PropertyInfo) propriedade.GetPropertyFromExpression();
            NomeControle = control.GetPropertyFromExpression().Name;
        }

        public PropertyInfo PropriedadeObjeto { get; set; }

        public string NomeControle { get; set; }
    }
}
