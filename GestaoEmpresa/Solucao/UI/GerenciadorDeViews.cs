using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns;
using GS.GestaoEmpresa.Solucao.Negocio.Interfaces;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos.Base;
using GS.GestaoEmpresa.Solucao.Negocio.Servicos.Base;
using GS.GestaoEmpresa.Solucao.Negocio.Validador.Base;
using GS.GestaoEmpresa.Solucao.Persistencia.Repositorios.Base;
using GS.GestaoEmpresa.Solucao.UI.Base;
using GS.GestaoEmpresa.Solucao.UI.Modulos.Atendimento;
using GS.GestaoEmpresa.Solucao.UI.Modulos.Estoque;
using GS.GestaoEmpresa.Solucao.UI.Modulos.Tecnico;
using GS.GestaoEmpresa.Solucao.UI.Principal;
using GS.GestaoEmpresa.Solucao.Utilitarios;
using MoreLinq;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;
using OfficeOpenXml.FormulaParsing.ExpressionGraph;
using Remotion.Data.Linq.Clauses;

namespace GS.GestaoEmpresa.Solucao.UI
{
    public static class GerenciadorDeViews
    {
        /// <summary>
        /// Tela Model-View-Presenter
        /// </summary>
        /// 
        public class TelaMVP
        {
            public static TelaMVP Of<TView, TPresenter>(bool instanciaUnica = false)
            {
                return new TelaMVP(typeof(TView), typeof(TPresenter), instanciaUnica);
            }

            public TelaMVP(Type view, Type presenter = null, bool instanciaUnica = false)
            {
                TipoDaView = view;
                TipoDoPresenter = presenter;
                InstanciaUnica = instanciaUnica;
            }

            public Type TipoDoModel { get; set; }

            public Type TipoDaView { get; set; }

            public Type TipoDoPresenter { get; set; }

            public bool InstanciaUnica { get; set; }

            public Dictionary<string, IPresenter> Instancias { get; set; }
        }

        private static List<TelaMVP> _controladorDeInstancias;
        private static List<TelaMVP> ControladorDeInstancias => _controladorDeInstancias ??= new List<TelaMVP>
        {
            TelaMVP.Of<FrmProdutoMetro, ProdutoPresenter>(),
            TelaMVP.Of<FrmInteracaoMetro, InteracaoPresenter>(),
            TelaMVP.Of<FrmOrcamento, OrcamentoPresenter>(),
            TelaMVP.Of<FrmCliente, ClientePresenter>(),
            TelaMVP.Of<FrmAtendimento, object>(true),
            TelaMVP.Of<FrmEstoque, object>(true),
            TelaMVP.Of<frmInteracao, object>(true)
        };

        private static Form _instanciaPrincipal;
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

                    IView instanciaView = null;
                    ObtenhaPrincipal().Invoke((MethodInvoker) delegate
                    {
                        instanciaView = (IView)Activator.CreateInstance(tela.TipoDaView);

                        instanciaPresenter.IdInstancia = idInstancia;
                        instanciaPresenter.View = instanciaView;
                        instanciaView.Presenter = instanciaPresenter;
                        instanciaPresenter.View.TipoDeForm = EnumTipoDeForm.Cadastro;
                        instanciaPresenter.HabiliteControles();
                    });

                    tela.Instancias.Add(idInstancia, instanciaPresenter);

                    return instanciaPresenter;
                }
            }

            MessageBox.Show($"Essa tela já está aberta!");
            return null;
        }

        public static Form ObtenhaPrincipal()
        {
            return _instanciaPrincipal ??= new frmPrincipal();
        }

        public static TPresenter Crie<TPresenter>(IConceito conceito)
            where TPresenter : class, IPresenter, new()
        {
            var instanciaPresenter = Crie<TPresenter>();

            ObtenhaPrincipal().Invoke((MethodInvoker) delegate
            {
                instanciaPresenter.Model = conceito;
                //instanciaPresenter.IdInstancia = conceito.Codigo.ToString();
                //instanciaPresenter.CarregueControlesComModel();
                instanciaPresenter.View.TipoDeForm = EnumTipoDeForm.Detalhamento;
            });

            return instanciaPresenter;
        }

        public static TPresenter Obtenha<TPresenter>()
            where TPresenter : class, IPresenter, new()
        {
            var tela = ControladorDeInstancias.Find(x => x.TipoDoPresenter == typeof(TPresenter));
            if (tela.Instancias != null && tela.Instancias.Count > 0)
            {
                return tela.Instancias.Values.FirstOrDefault() as TPresenter;
            }

            return null;
        }

        public static IPresenter Obtenha(string idInstancia)
        {
            var tela = ControladorDeInstancias.Find(x => x.Instancias.ContainsKey(idInstancia));
            if (tela.Instancias != null && tela.Instancias.Count > 0)
            {
                return tela.Instancias.Values.FirstOrDefault(x => x.IdInstancia == idInstancia) as IPresenter;
            }

            return null;
        }

        public static void Exclua<T>(string idDaInstancia = null)
            where T : Form, IView
        {
            if(idDaInstancia.IsNullOrEmpty())
            {
                if(ControladorDeInstanciasIndependentes.ContainsKey(typeof(T)))
                {
                    var instance = ControladorDeInstanciasIndependentes[typeof(T)];
                    instance.Close();
                    instance.Dispose();
                    instance = null;
                }

                return;
            }

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

        public static void Exclua(Type tipoDaView, string idDaInstancia)
        {
            var instancias = ControladorDeInstancias.Find(x => x.TipoDaView == tipoDaView).Instancias;
            instancias[idDaInstancia] = null; // Disposing Presenter
            instancias.Remove(idDaInstancia);
        }

        public static IServicoHistoricoPadrao ObtenhaServicoHistoricoPadraoPorModel(IConceito model)
        {
            var tipos = GSUtilitarios.GetTypesThatImplementsInteface(typeof(IServicoHistoricoPadrao));
            var classes = tipos.ToList().Where(x => !x.IsInterface && !x.Name.Contains("ServicoHistoricoPadrao"));
            var servico = classes.FirstOrDefault(x => x.BaseType.GenericTypeArguments.First() == model.GetType());

            var instanciaServico = (IServicoHistoricoPadrao)Activator.CreateInstance(servico);

            if (instanciaServico == null)
            {
                throw new Exception("Não foi possível encontrar um serviço implementado que contemple o model informado");
            }

            return instanciaServico;
        }

        public static IServicoPadrao ObtenhaServicoPadraoPorModel(IConceito model)
        {
            var tipos = GSUtilitarios.GetTypesThatImplementsInteface(typeof(IServicoPadrao));
            var classes = tipos.ToList().Where(x => !x.IsInterface && !x.Name.Contains("ServicoPadrao"));
            var servico = classes.FirstOrDefault(x => x.BaseType.GenericTypeArguments.First() == model.GetType());

            var instanciaServico = (IServicoPadrao)Activator.CreateInstance(servico);

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

            T instanciaForm = null;
            ObtenhaPrincipal().Invoke((MethodInvoker)delegate
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
