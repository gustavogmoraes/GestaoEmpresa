using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestaoEmpresa.GS.GestaoEmpresa.GS.GestaoEmpresa.UI.Principal;
using GS.GestaoEmpresa.Solucao.Negocio.Interfaces;
using GS.GestaoEmpresa.Solucao.UI.Base;
using GS.GestaoEmpresa.Solucao.UI.Modulos.Atendimento;
using GS.GestaoEmpresa.Solucao.UI.Modulos.Estoque;
using GS.GestaoEmpresa.Solucao.UI.Modulos.Tecnico;
using MoreLinq;

namespace GS.GestaoEmpresa.Solucao.UI
{
    public static class GerenciadorDeViews
    {
        /// <summary>
        /// Tela Model-View-Presenter
        /// </summary>
        public class TelaMVP
        {
            public TelaMVP(Type tipoDaView, Type tipoDoPresenter, bool instanciaUnica)
            {
                TipoDaView = tipoDaView;
                TipoDoPresenter = tipoDoPresenter;
                InstanciaUnica = instanciaUnica;
            }

            public Type TipoDoModel { get; set; }

            public Type TipoDaView { get; set; }

            public Type TipoDoPresenter { get; set; }

            public bool InstanciaUnica { get; set; }

            public Dictionary<string, IPresenter> Instancias { get; set; }
        }

        private static List<TelaMVP> ControladorDeInstancias
        {
            get =>
                _controladorDeInstancias ??
                (_controladorDeInstancias =
                    new List<TelaMVP>
                    {
                        { new TelaMVP(typeof(frmPrincipal), null, true) },
                        { new TelaMVP(typeof(frmEstoque), null, true) },
                        { new TelaMVP(typeof(frmProdutoMetro), typeof(ProdutoPresenter), false) },
                        { new TelaMVP(typeof(frmInteracao), null, true) },
                        { new TelaMVP(typeof(frmAtendimento), null, true) },
                    });

            set => _controladorDeInstancias = value;
        }

        private static List<TelaMVP> _controladorDeInstancias { get; set; }

        public static TPresenter Crie<TPresenter>()
            where TPresenter : class, IPresenter, new()
        {
            var tela = ControladorDeInstancias.Find(x => x.TipoDoPresenter == typeof(TPresenter));
            if (tela == null) throw new Exception("View não encontrada pelo gerenciador!");

            if (!(tela.InstanciaUnica && tela.Instancias != null))
            {
                if (tela.Instancias == null) tela.Instancias = new Dictionary<string, IPresenter>();

                var idInstancia = tela.InstanciaUnica ? "Única" : Guid.NewGuid().ToString();
                if (!tela.Instancias.ContainsKey(idInstancia))
                {
                    var instanciaPresenter = (TPresenter)Activator.CreateInstance(tela.TipoDoPresenter);
                    var instanciaView = (IView)Activator.CreateInstance(tela.TipoDaView);
                    instanciaPresenter.View = instanciaView;

                    tela.Instancias.Add(idInstancia, instanciaPresenter);

                    return instanciaPresenter;
                }
            }

            MessageBox.Show($"Essa tela já está aberta!");
            return null;
        }

        public static TPresenter Crie<TPresenter>(IConceito conceito)
            where TPresenter : class, IPresenter, new()
        {
            var instanciaPresenter = Crie<TPresenter>();
            instanciaPresenter.Model = conceito.GetType();

            instanciaPresenter.CarregueControlesComModel();

            return instanciaPresenter;
        }

        public static TPresenter Obtenha<TPresenter>()
            //where TModel : class, IConceito, new()
            //where TView : Form, IView, new()
            where TPresenter : class, IPresenter, new()
        {
            var tela = ControladorDeInstancias.Find(x => x.TipoDoPresenter == typeof(TPresenter));
            if (tela.Instancias != null && tela.Instancias.Count > 0)
            {
                return tela.Instancias.Values.FirstOrDefault() as TPresenter;
            }

            return null;
        }

        public static void Exclua<T>()
            where T : Form, IView
        {
            var instancias = ControladorDeInstancias.Find(x => x.TipoDaView == typeof(T)).Instancias.Values;
            if (instancias != null && instancias.Count > 0)
            {
                instancias.ForEach(x => (x.View as Form).Invoke((MethodInvoker) delegate
                {
                    (x as Form).Dispose();
                }));

                instancias = null;
            }
        }

        public static void Exclua<T>(string codigoDaInstancia)
            where T : Form, IView
        {
            var instancias = ControladorDeInstancias.Find(x => x.TipoDaView == typeof(T)).Instancias;
            
            if(instancias.ContainsKey(codigoDaInstancia))
                (instancias[codigoDaInstancia].View as Form).Dispose();

            instancias.Remove(codigoDaInstancia);

            if (instancias.Count == 0)
                instancias = null;
        }
    }
}
