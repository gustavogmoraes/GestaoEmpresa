using System;
using System.Collections.Generic;
using GS.GestaoEmpresa.Business.Services;
using GS.GestaoEmpresa.Solucao.Persistencia.BancoDeDados;

namespace GS.GestaoEmpresa.Business.Objects.Core
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
            using var servicoDeUsuario = new UserService();
            servicoDeUsuario.UpdateUiSettings(SessaoSistema.CodigoUsuario, setting);
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
