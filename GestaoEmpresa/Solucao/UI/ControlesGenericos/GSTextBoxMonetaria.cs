using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos.ObjetosConcretos;
using GS.GestaoEmpresa.Solucao.Utilitarios;
using GS.GestaoEmpresa.Solucao.Negocio.Catalogos;

namespace GS.GestaoEmpresa.Solucao.UI
{
    public partial class GSTextBoxMonetaria : UserControl
    {
        public GSTextBoxMonetaria()
        {
            InitializeComponent();
        }

        #region Propriedades

        private CultureInfo _cultura = new CultureInfo("pt-BR");

        private List<Inconsistencia> _listaDeInconsistencias;

        public decimal Valor
        {
            get { return decimal.Parse(string.IsNullOrEmpty(txtValor.Text) ? 0.ToString() : txtValor.Text , _cultura); }

            set { this.txtValor.Text = GSUtilitarios.FormateDecimalParaStringMoedaReal(value); }
        }

        public List<Inconsistencia> ListaDeInconsistencias
        {
            get { return _listaDeInconsistencias; }

            set
            {
                _listaDeInconsistencias = value;
                InicializeInconsistencias();
            }
        }

        #endregion

        #region Métodos

        private void InicializeInconsistencias()
        {
            if (_listaDeInconsistencias.Count == 0)
            {
                return;
            }

            this.txtLine.ForeColor = Cores.Erro;
            this.pbErro.Enabled = true;
            this.pbErro.Visible = true;

            var listaDeMensagens = new List<string>();
            foreach (var inconsistencia in _listaDeInconsistencias)
            {
                listaDeMensagens.Add(inconsistencia.Mensagem);
            }

            var mensagemDaTooltip = string.Join("\n", listaDeMensagens);

            ttErro.SetToolTip(pbErro, mensagemDaTooltip);
        }

        #endregion

        private void txtValor_TextChanged(object sender, EventArgs e)
        {
            GSUtilitarios.AjusteTextBoxMonetaria(ref txtValor);
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }
    }
}
