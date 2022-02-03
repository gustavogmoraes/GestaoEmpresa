using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GS.GestaoEmpresa.Business.Enumerators.Default;
using GS.GestaoEmpresa.Business.Interfaces;
using GS.GestaoEmpresa.Infrastructure.Persistence.RavenDB.Support.Interfaces;
using GS.GestaoEmpresa.Solucao.UI.Base;
using GS.GestaoEmpresa.Solucao.UI.Modulos.Atendimento;
using GS.GestaoEmpresa.Solucao.UI.Modulos.Estoque;
using GS.GestaoEmpresa.Solucao.Utilitarios;
using GS.GestaoEmpresa.UI.Modules.Attendance;
using GS.GestaoEmpresa.UI.Modules.MainWindow;
using GS.GestaoEmpresa.UI.Modules.Storage.Interaction;
using GS.GestaoEmpresa.UI.Modules.Storage.Product;
using MoreLinq;

namespace GS.GestaoEmpresa.UI.Base
{
    public static class ViewManager
    {
        /// <summary>
        /// Tela Model-View-Presenter
        /// </summary>
        /// 
        public class MvpView
        {
            public static MvpView Of<TView, TPresenter>(bool singleInstance = false)
            {
                return new MvpView(typeof(TView), typeof(TPresenter), singleInstance);
            }

            public MvpView(Type viewType, Type presenterType = null, bool singleInstance = false)
            {
                ViewType = viewType;
                PresenterType = presenterType;
                SingleInstance = singleInstance;
            }

            public Type ModelType { get; set; }

            public Type ViewType { get; set; }

            public Type PresenterType { get; set; }

            public bool SingleInstance { get; set; }

            public Dictionary<string, IPresenter> Instances { get; set; }
        }

        private static List<MvpView> _instanceController;
        private static List<MvpView> InstanceController => _instanceController ??= new List<MvpView>
        {
            MvpView.Of<FrmProdutoMetro, ProductPresenter>(),
            MvpView.Of<FrmInteracaoMetro, InteractionPresenter>(),
            MvpView.Of<FrmOrcamento, OrcamentoPresenter>(),
            MvpView.Of<FrmCliente, ClientePresenter>(),
            MvpView.Of<FrmAtendimento, object>(true),
            MvpView.Of<FrmEstoque, object>(true),
            MvpView.Of<frmInteracao, object>(true)
        };

        private static Form _mainInstance;
        public static TPresenter Create<TPresenter>()
            where TPresenter : class, IPresenter, new()
        {
            var view = InstanceController.Find(x => x.PresenterType == typeof(TPresenter));
            if (view == null) throw new Exception("View não encontrada pelo gerenciador!");

            if (!(view.SingleInstance && view.Instances != null))
            {
                if (view.Instances == null) view.Instances = new Dictionary<string, IPresenter>();

                var idInstancia = view.SingleInstance ? "Única" : Guid.NewGuid().ToString();
                if (!view.Instances.ContainsKey(idInstancia))
                {
                    var instanciaPresenter = (TPresenter)Activator.CreateInstance(view.PresenterType);

                    IView instanciaView = null;
                    InvokeOnMain(delegate { instanciaView = (IView)Activator.CreateInstance(view.ViewType); });

                    instanciaPresenter.InstanceId = idInstancia;
                    instanciaPresenter.View = instanciaView;
                    instanciaView.Presenter = instanciaPresenter;
                    instanciaPresenter.View.FormType = FormType.Insert;
                    instanciaPresenter.EnableControls();

                    view.Instances.Add(idInstancia, instanciaPresenter);

                    return instanciaPresenter;
                }
            }

            MessageBox.Show($"Essa tela já está aberta!");
            return null;
        }

        private static void InvokeOnMain(Action action)
        {
            GetMain().Invoke(action);
        }

        public static Form GetMain()
        {
            return _mainInstance ??= new MainView();
        }

        public static TPresenter Crie<TPresenter>(IEntity conceito)
            where TPresenter : class, IPresenter, new()
        {
            var instanciaPresenter = Create<TPresenter>();
            instanciaPresenter.Model = conceito;
            instanciaPresenter.View.FormType = FormType.Detail;
            //GetMain().Invoke((MethodInvoker) delegate
            //{
                
            //});

            return instanciaPresenter;
        }

        public static TPresenter Obtenha<TPresenter>()
            where TPresenter : class, IPresenter, new()
        {
            var tela = InstanceController.Find(x => x.PresenterType == typeof(TPresenter));
            if (tela.Instances != null && tela.Instances.Count > 0)
            {
                return tela.Instances.Values.FirstOrDefault() as TPresenter;
            }

            return null;
        }

        public static IPresenter Obtenha(string idInstancia)
        {
            var tela = InstanceController.Find(x => x.Instances.ContainsKey(idInstancia));
            if (tela.Instances != null && tela.Instances.Count > 0)
            {
                return tela.Instances.Values.FirstOrDefault(x => x.InstanceId == idInstancia) as IPresenter;
            }

            return null;
        }

        public static void Exclua<T>(string idDaInstancia = null)
            where T : Form, IView
        {
            if (idDaInstancia.IsNullOrEmpty())
            {
                if (ControladorDeInstanciasIndependentes.ContainsKey(typeof(T)))
                {
                    var instance = ControladorDeInstanciasIndependentes[typeof(T)];
                    instance.Close();

                    ControladorDeInstanciasIndependentes[typeof(T)] = null;

                    return;
                }
            }

            var instancias = InstanceController.Find(x => x.ViewType == typeof(T)).Instances.Values;
            if (instancias != null && instancias.Count > 0)
            {
                instancias.ForEach(x => (x.View as Form).Invoke((MethodInvoker)delegate
                {
                    (x as Form).Dispose();
                }));

                instancias = null;
            }
        }

        public static void Exclua(Type tipoDaView, string idDaInstancia)
        {
            var instancias = InstanceController.Find(x => x.ViewType == tipoDaView).Instances;
            instancias[idDaInstancia] = null; // Disposing Presenter
            instancias.Remove(idDaInstancia);
        }

        public static IServicoHistoricoPadrao ObtenhaServicoHistoricoPadraoPorModel(IEntity model)
        {
            var types = GSUtilitarios.GetTypesThatImplementsInteface(typeof(IServicoHistoricoPadrao));
            var classes = types.ToList().Where(x => !x.IsInterface && !x.Name.Contains("BaseServiceWithRevision"));

            var serviceType = classes.FirstOrDefault(x => x.BaseType != null && x.BaseType.GenericTypeArguments.First() == model.GetType());
            if (serviceType == null)
            {
                throw new Exception("Service type not found");
            }

            var serviceInstance = (IServicoHistoricoPadrao)Activator.CreateInstance(serviceType);
            if (serviceInstance == null)
            {
                throw new Exception("Não foi possível encontrar um serviço implementado que contemple o model informado");
            }

            return serviceInstance;
        }

        public static IBaseService ObtenhaServicoPadraoPorModel(IEntity model)
        {
            var tipos = GSUtilitarios.GetTypesThatImplementsInteface(typeof(IBaseService));
            var classes = tipos.ToList().Where(x => !x.IsInterface && !x.Name.Contains("ServicoPadrao"));
            var servico = classes.FirstOrDefault(x => x.BaseType.GenericTypeArguments.First() == model.GetType());

            var instanciaServico = (IBaseService)Activator.CreateInstance(servico);

            if (instanciaServico == null)
            {
                throw new Exception("Não foi possível encontrar um serviço implementado que contemple o model informado");
            }

            return instanciaServico;
        }

        public static T ObtenhaIndependente<T>()
            where T : Form, new()
        {
            return (T)((T)ControladorDeInstanciasIndependentes[typeof(T)] != null
                ? ControladorDeInstanciasIndependentes[typeof(T)]
                : null);
        }

        public static T CrieIndependente<T>(params object[] args)
            where T : Form, IView, new()
        {
            if (ControladorDeInstanciasIndependentes == null)
            {
                ControladorDeInstanciasIndependentes = new Dictionary<Type, Form>();
            }

            if (ControladorDeInstanciasIndependentes.ContainsKey(typeof(T)) && 
                ControladorDeInstanciasIndependentes[typeof(T)] != null)
            {
                return (T)ControladorDeInstanciasIndependentes[typeof(T)];
            }

            T instanciaForm = null;
            GetMain().Invoke((MethodInvoker)delegate
            {
                instanciaForm = (T)Activator.CreateInstance(typeof(T), args);
            });

            ControladorDeInstanciasIndependentes[typeof(T)] = instanciaForm;
            return instanciaForm;
        }

        private static Dictionary<Type, Form> _controladorDeInstanciasIndependentes;
        private static Dictionary<Type, Form> ControladorDeInstanciasIndependentes
        {
            get => _controladorDeInstanciasIndependentes ?? (_controladorDeInstanciasIndependentes = new Dictionary<Type, Form>
            {
                { typeof(FrmEstoque), null },
                { typeof(FrmAtendimento), null }
            });

            set => _controladorDeInstanciasIndependentes = value;
        }
    }
}
