using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestaoEmpresa.GS.GestaoEmpresa.GS.GestaoEmpresa.UI.Principal;
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
using GS.GestaoEmpresa.Solucao.Utilitarios;
using MoreLinq;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;

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
                        { new TelaMVP(typeof(frmEstoque), typeof(EstoquePresenter), true) },
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

                    instanciaPresenter.IdInstancia = idInstancia;
                    instanciaPresenter.View = instanciaView;
                    instanciaView.Presenter = instanciaPresenter;
                    instanciaPresenter.View.TipoDeForm = EnumTipoDeForm.Cadastro;
                    instanciaPresenter.HabiliteControles();

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
                instanciaPresenter.Model = conceito;
                //instanciaPresenter.IdInstancia = conceito.Codigo.ToString();

                instanciaPresenter.CarregueControlesComModel();
                instanciaPresenter.View.TipoDeForm = EnumTipoDeForm.Detalhamento;

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

        public static void Exclua(Type tipoDaView, string idDaInstancia)
        {
            var instancias = ControladorDeInstancias.Find(x => x.TipoDaView == tipoDaView).Instancias;
            instancias[idDaInstancia] = null; // Disposing Presenter
            instancias.Remove(idDaInstancia);
        }

        public static void Exclua(string idDaInstancia)
        {
            var instancias = ControladorDeInstancias.Find(x => x.Instancias.ContainsKey(idDaInstancia)).Instancias;
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
                throw new Exception("Não foi possível encontrar um serviço implementado que contemple o model informado");

            return instanciaServico;
        }

        public static IServicoPadrao ObtenhaServicoPadraoPorModel(IConceito model)
        {
            var tipos = GSUtilitarios.GetTypesThatImplementsInteface(typeof(IServicoPadrao));
            var classes = tipos.ToList().Where(x => !x.IsInterface && !x.Name.Contains("ServicoPadrao"));
            var servico = classes.FirstOrDefault(x => x.BaseType.GenericTypeArguments.First() == model.GetType());

            var instanciaServico = (IServicoPadrao)Activator.CreateInstance(servico);

            if (instanciaServico == null)
                throw new Exception("Não foi possível encontrar um serviço implementado que contemple o model informado");

            return instanciaServico;
        }
    }
}
