using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestaoEmpresa.GS.GestaoEmpresa.GS.GestaoEmpresa.UI.Principal;
using GS.GestaoEmpresa.Solucao.Negocio.Interfaces;
using GS.GestaoEmpresa.Solucao.UI.Modulos.Atendimento;
using GS.GestaoEmpresa.Solucao.UI.Modulos.Estoque;
using GS.GestaoEmpresa.Solucao.UI.Modulos.Tecnico;
using MoreLinq;

namespace GS.GestaoEmpresa.Solucao.UI
{
    public static class GerenciadorDeForms
    {
        public class Tela
        {
            public Tela(Type tipo, bool instanciaUnica)
            {
                TipoDoForm = tipo;
                InstanciaUnica = instanciaUnica;
            }

            public Type TipoDoForm { get; set; }

            public Dictionary<string, Form> Instancias { get; set; }

            public bool InstanciaUnica { get; set; }
        }

        private static List<Tela> ControladorDeInstancias
        {
            get =>
                _controladorDeInstancias ??
                (_controladorDeInstancias =
                    new List<Tela>
                    {
                        { new Tela(typeof(frmPrincipal), true) },
                        { new Tela(typeof(frmEstoque), true) },
                        { new Tela(typeof(frmProduto), false) },
                        { new Tela(typeof(frmInteracao), true) },
                        { new Tela(typeof(frmAtendimento), true) },
                    });

            set => _controladorDeInstancias = value;
        }

        private static List<Tela> _controladorDeInstancias { get; set; }

        public static Form Crie<T>()
            where T : Form
        {
            var tela = ControladorDeInstancias.Find(x => x.TipoDoForm == typeof(T));
            if (!(tela.InstanciaUnica && tela.Instancias != null))
            {
                if (tela.Instancias == null)
                    tela.Instancias = new Dictionary<string, Form>();

                var idInstancia = tela.InstanciaUnica ? "Única" : Guid.NewGuid().ToString();
                if (!tela.Instancias.ContainsKey(idInstancia))
                {
                    var instancia = Activator.CreateInstance<T>();
                    (instancia as IFormGerenciado).IdInstancia = idInstancia;

                    tela.Instancias.Add(idInstancia, instancia as Form);

                    return instancia as Form;
                }
            }

            MessageBox.Show($"Essa tela já está aberta!");
            return null;
        }

        public static Form Crie<T>(IConceito conceito)
            where T : Form
        {
            var tela = ControladorDeInstancias.Find(x => x.TipoDoForm == typeof(T));

            if (tela.InstanciaUnica && tela.Instancias != null)
                return null;

            if (tela.Instancias == null)
                tela.Instancias = new Dictionary<string, Form>();

            
            var idInstancia = tela.InstanciaUnica ? "Única" : conceito.Codigo.ToString();
            if (!tela.Instancias.ContainsKey(idInstancia))
            {
                var instancia = Activator.CreateInstance(typeof(T), conceito);
                (instancia as IFormGerenciado).IdInstancia = idInstancia;

                tela.Instancias.Add(idInstancia, instancia as Form);

                return instancia as Form;
            }

            MessageBox.Show($"Já existe uma tela aberta com o item {conceito.Codigo}!");

            return null;
        }

        public static T Obtenha<T>()
            where T : Form
        {
            var tela = ControladorDeInstancias.Find(x => x.TipoDoForm == typeof(T));
            if (tela.Instancias != null && tela.Instancias.Count > 0)
            {
                return tela.Instancias.Values.FirstOrDefault() as T;
            }

            return null;
        }

        public static T Obtenha<T>(string codigoDaInstancia)
            where T : Form
        {
            var tela = ControladorDeInstancias.Find(x => x.TipoDoForm == typeof(T));
            if (tela.Instancias != null && tela.Instancias.Count > 0)
            {
                return tela.Instancias.FirstOrDefault(x => x.Key == codigoDaInstancia).Value as T;
            }

            return null;
        }

        public static IList<T> ObtenhaLista<T>()
            where T : Form
        {
            var tela = ControladorDeInstancias.Find(x => x.TipoDoForm == typeof(T));
            if (tela.Instancias != null && tela.Instancias.Count > 0)
            {
                return tela.Instancias.Values as IList<T>;
            }

            return null;
        }

        public static void Apague<T>()
            where T : Form
        {
            var instancias = ControladorDeInstancias.Find(x => x.TipoDoForm == typeof(T)).Instancias.Values;
            if (instancias != null && instancias.Count > 0)
            {
                instancias.ForEach(x => x.Invoke((MethodInvoker) delegate
                {
                    x.Dispose();
                }));

                instancias = null;
            }
        }

        public static void Apague<T>(string codigoDaInstancia)
            where T : Form
        {
            var instancias = ControladorDeInstancias.Find(x => x.TipoDoForm == typeof(T)).Instancias;
            
            if(instancias.ContainsKey(codigoDaInstancia))
                instancias[codigoDaInstancia].Dispose();

            instancias.Remove(codigoDaInstancia);

            if (instancias.Count == 0)
                instancias = null;
        }
    }
}
