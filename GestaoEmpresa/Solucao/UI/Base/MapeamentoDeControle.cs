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
            Action<object, Control, PropertyInfo, object> conversaoPropriedadeControle = null,
            Action<Control, PropertyInfo, object, IPresenter> conversaoControlePropriedade = null)
        {
            PropriedadeObjeto = (PropertyInfo)propriedade.GetPropertyFromExpression();
            NomeControle = control.GetPropertyFromExpression().Name;

            ConversaoPropriedadeControle = conversaoPropriedadeControle;
            ConversaoControlePropriedade = conversaoControlePropriedade;
        }

        public PropertyInfo PropriedadeObjeto { get; set; }

        public string NomeControle { get; set; }

        public Action<object, Control, PropertyInfo, object> ConversaoPropriedadeControle { get; set; }

        public Action<Control, PropertyInfo, object, IPresenter> ConversaoControlePropriedade { get; set; }
    }
}
