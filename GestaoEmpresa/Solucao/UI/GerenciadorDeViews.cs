using System;
using System.Collections.Generic;
using System.Linq;
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
                        { new TelaMVP(typeof(frmProduto), typeof(ProdutoPresenter), false) },
                        { new TelaMVP(typeof(frmInteracao), null, true) },
                        { new TelaMVP(typeof(frmAtendimento), null, true) },
                    });

            set => _controladorDeInstancias = value;
        }

        private static List<TelaMVP> _controladorDeInstancias { get; set; }

        public static IView Crie<TView>() 
            where TView : IView
        {
            var tela = ControladorDeInstancias.Find(x => x.TipoDaView == typeof(TView));
            if (!(tela.InstanciaUnica && tela.Instancias != null))
            {
                if (tela.Instancias == null) tela.Instancias = new Dictionary<string, IPresenter>();

                var idInstancia = tela.InstanciaUnica ? "Única" : Guid.NewGuid().ToString();
                if (!tela.Instancias.ContainsKey(idInstancia))
                {
                    var instancia = Activator.CreateInstance<TView>();
                    (instancia as IView).IdInstancia = idInstancia;

                    tela.Instancias.Add(idInstancia, instancia as IPresenter);

                    return instancia;
                }
            }

            MessageBox.Show($"Essa tela já está aberta!");
            return null;
        }

        public static Form Crie<T>(IConceito conceito)
            where T : Form
        {
            var tela = ControladorDeInstancias.Find(x => x.TipoDaView == typeof(T));

            if (tela.InstanciaUnica && tela.Instancias != null)
                return null;

            if (tela.Instancias == null)
                tela.Instancias = new Dictionary<string, IPresenter>();

            
            var idInstancia = tela.InstanciaUnica ? "Única" : conceito.Codigo.ToString();
            if (!tela.Instancias.ContainsKey(idInstancia))
            {
                var instancia = Activator.CreateInstance(typeof(T), conceito);
                (instancia as IView).IdInstancia = idInstancia;

                tela.Instancias.Add(idInstancia, instancia as IPresenter);

                return instancia as Form;
            }

            MessageBox.Show($"Já existe uma tela aberta com o item {conceito.Codigo}!");

            return null;
        }

        public static T Obtenha<T>()
            where T : Form
        {
            var tela = ControladorDeInstancias.Find(x => x.TipoDaView == typeof(T));
            if (tela.Instancias != null && tela.Instancias.Count > 0)
            {
                return tela.Instancias.Values.FirstOrDefault() as T;
            }

            return null;
        }

        public static T Obtenha<T>(string codigoDaInstancia)
            where T : Form
        {
            var tela = ControladorDeInstancias.Find(x => x.TipoDaView == typeof(T));
            if (tela.Instancias != null && tela.Instancias.Count > 0)
            {
                return tela.Instancias.FirstOrDefault(x => x.Key == codigoDaInstancia).Value as T;
            }

            return null;
        }

        public static IList<T> ObtenhaLista<T>()
            where T : Form
        {
            var tela = ControladorDeInstancias.Find(x => x.TipoDaView == typeof(T));
            if (tela.Instancias != null && tela.Instancias.Count > 0)
            {
                return tela.Instancias.Values as IList<T>;
            }

            return null;
        }

        public static void Apague<T>()
            where T : IView
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

        public static void Apague<T>(string codigoDaInstancia)
            where T : Form
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
