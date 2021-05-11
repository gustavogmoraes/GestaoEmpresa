using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.GestaoEmpresa.Solucao.Negocio.Objetos.Base
{
    public abstract class BaseObject
    {
        protected BaseObject()
        {

        }

        protected BaseObject(object modelToClone)
        {
            modelToClone.GetType().GetProperties().ToList().ForEach(prop =>
            {
                prop.SetValue(this, prop.GetValue(modelToClone, null), null);
            });
        }
    }
}
