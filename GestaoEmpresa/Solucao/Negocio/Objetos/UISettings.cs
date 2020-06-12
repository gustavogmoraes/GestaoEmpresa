using GS.GestaoEmpresa.Solucao.Negocio.Servicos;
using GS.GestaoEmpresa.Solucao.Persistencia.BancoDeDados;
using GS.GestaoEmpresa.Solucao.UI.Base;
using Raven.Client.Documents.Operations.CompareExchange;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GS.GestaoEmpresa.Solucao.Negocio.Objetos
{
    public class UISettings
    {
        private Dictionary <Type, object> ViewSettings { get; set; }
        public Dictionary<string, int> GridProdutos { get; set; }

        public dynamic GetUISettings(Type viewType)
        {
            return ViewSettings.ContainsKey(viewType) 
                ? (dynamic)ViewSettings[viewType] 
                : (dynamic)null;
        }

        public void SaveUISettings(Type viewType, dynamic setting)
        {
            if(ViewSettings.ContainsKey(viewType))
            {
                ViewSettings[viewType] = setting;
                SaveOnDatabase(this);

                return;
            }

            ViewSettings.Add(viewType, setting);
            SaveOnDatabase(this);
        }

        void SaveOnDatabase(UISettings setting)
        {
            using (var servicoDeUsuario = new ServicoDeUsuario())
            {
                servicoDeUsuario.AtualizeUISetting(SessaoSistema.CodigoUsuario, setting);
            }
        }

        public UISettings()
        {
            if(ViewSettings == null)
            {
                ViewSettings = new Dictionary<Type, object>();
            }
        }
    }
}
