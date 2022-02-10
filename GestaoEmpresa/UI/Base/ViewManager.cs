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
using GS.GestaoEmpresa.UI.Modules.Storage.Storage;
using MoreLinq;

namespace GS.GestaoEmpresa.UI.Base
{
    public static class ViewManager
    {
        /// <summary>
        /// Model-View-Presenter View
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
            MvpView.Of<InteractionView, InteractionPresenter>(),
            MvpView.Of<FrmOrcamento, OrcamentoPresenter>(),
            MvpView.Of<FrmCliente, ClientePresenter>(),
            MvpView.Of<FrmAtendimento, object>(true),
            MvpView.Of<StorageView, object>(true),
            MvpView.Of<frmInteracao, object>(true)
        };

        private static Form _mainInstance;
        public static TPresenter Create<TPresenter>()
            where TPresenter : class, IPresenter, new()
        {
            var view = InstanceController.Find(x => x.PresenterType == typeof(TPresenter));
            if (view == null) throw new Exception("View not found at manager");

            if (!(view.SingleInstance && view.Instances != null))
            {
                view.Instances ??= new Dictionary<string, IPresenter>();

                var instanceId = view.SingleInstance ? "Unique" : Guid.NewGuid().ToString();
                if (!view.Instances.ContainsKey(instanceId))
                {
                    var presenterInstance = (TPresenter)Activator.CreateInstance(view.PresenterType);

                    IView instanceView = null;
                    InvokeOnMain(delegate { instanceView = (IView)Activator.CreateInstance(view.ViewType); });

                    presenterInstance.InstanceId = instanceId;
                    presenterInstance.View = instanceView;
                    instanceView.Presenter = presenterInstance;
                    presenterInstance.View.FormType = FormType.Insert;
                    presenterInstance.EnableControls();

                    view.Instances.Add(instanceId, presenterInstance);

                    return presenterInstance;
                }
            }

            MessageBox.Show(@"This view is already opened");
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

        public static TPresenter Create<TPresenter>(IEntity model)
            where TPresenter : class, IPresenter, new()
        {
            var presenterInstance = Create<TPresenter>();
            presenterInstance.Model = model;
            presenterInstance.View.FormType = FormType.Detail;

            return presenterInstance;
        }

        public static TPresenter Get<TPresenter>()
            where TPresenter : class, IPresenter, new()
        {
            var view = InstanceController.Find(x => x.PresenterType == typeof(TPresenter));
            if (view.Instances != null && view.Instances.Count > 0)
            {
                return view.Instances.Values.FirstOrDefault() as TPresenter;
            }

            return null;
        }

        public static IPresenter Get(string instanceId)
        {
            var view = InstanceController.Find(x => x.Instances.ContainsKey(instanceId));
            return view.Instances is {Count: > 0} 
                ? view.Instances.Values.FirstOrDefault(x => x.InstanceId == instanceId) 
                : null;
        }

        public static void Delete<T>(string instanceId = null)
            where T : Form, IView
        {
            if (instanceId.IsNullOrEmpty())
            {
                if (IndependentInstanceController.ContainsKey(typeof(T)))
                {
                    var instance = IndependentInstanceController[typeof(T)];
                    instance.Close();

                    IndependentInstanceController[typeof(T)] = null;

                    return;
                }
            }

            var instances = InstanceController.Find(x => x.ViewType == typeof(T)).Instances.Values;
            if (instances is not {Count: > 0})
            {
                return;
            }

            instances.ForEach(x => ((Form) x.View).Invoke((MethodInvoker)delegate
            {
                ((Form) x)?.Dispose();
            }));

            instances = null;
        }

        public static void Delete(Type viewType, string instanceId)
        {
            var instances = InstanceController.Find(x => x.ViewType == viewType).Instances;
            instances[instanceId] = null;
            instances.Remove(instanceId);
        }

        public static IServicoHistoricoPadrao GetDefaultHistoricServiceByModel(IEntity model)
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
                throw new Exception("Could not find an implemented service for this model");
            }

            return serviceInstance;
        }

        public static IBaseService GetDefaultServiceByModel(IEntity model)
        {
            var types = GSUtilitarios.GetTypesThatImplementsInteface(typeof(IBaseService));
            var classes = types.ToList().Where(x => !x.IsInterface && !x.Name.Contains("BaseService"));
            var service = classes.FirstOrDefault(x => x.BaseType?.GenericTypeArguments.First() == model.GetType());
            if (service == null)
            {
                return null;
            }

            var serviceInstance = (IBaseService)Activator.CreateInstance(service);
            if (serviceInstance == null)
            {
                throw new Exception("Could not find an implemented service for this model");
            }

            return serviceInstance;
        }

        public static T GetIndependent<T>()
            where T : Form, new()
        {
            return (T)((T)IndependentInstanceController[typeof(T)] != null
                ? IndependentInstanceController[typeof(T)]
                : null);
        }

        public static T CreateIndependent<T>(params object[] args)
            where T : Form, IView, new()
        {
            IndependentInstanceController ??= new Dictionary<Type, Form>();

            if (IndependentInstanceController.ContainsKey(typeof(T)) && 
                IndependentInstanceController[typeof(T)] != null)
            {
                return (T)IndependentInstanceController[typeof(T)];
            }

            T formInstance = null;
            GetMain().Invoke((MethodInvoker)delegate
            {
                formInstance = (T)Activator.CreateInstance(typeof(T), args);
            });

            IndependentInstanceController[typeof(T)] = formInstance;
            return formInstance;
        }

        private static Dictionary<Type, Form> _independentInstanceController;
        private static Dictionary<Type, Form> IndependentInstanceController
        {
            get => _independentInstanceController ??= new Dictionary<Type, Form>
            {
                { typeof(StorageView), null },
                { typeof(FrmAtendimento), null }
            };

            set => _independentInstanceController = value;
        }
    }
}
