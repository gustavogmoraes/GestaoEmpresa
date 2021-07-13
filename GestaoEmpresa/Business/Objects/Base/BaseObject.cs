using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.GestaoEmpresa.Business.Objects.Base
{
    public abstract class BaseObject<T>
    {
        protected BaseObject()
        {

        }

        protected BaseObject(T modelToClone)
        {
            modelToClone.GetType().GetProperties().ToList().ForEach(prop =>
            {
                prop.SetValue(this, prop.GetValue(modelToClone, null), null);
            });
        }
    }
}
