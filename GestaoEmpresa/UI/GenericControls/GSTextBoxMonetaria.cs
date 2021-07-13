using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GS.GestaoEmpresa.Solucao.Utilitarios;
using System.Globalization;

namespace GS.GestaoEmpresa.Solucao.UI.ControlesGenericos
{
    public partial class GSTextBoxMonetaria : UserControl
    {
        public GSTextBoxMonetaria()
        {
            InitializeComponent();
        }

        private CultureInfo _cultura = new CultureInfo("pt-BR");

        //private List<Inconsistencia> _listaDeInconsistencias;

        public decimal? Valor
        {
            get => string.IsNullOrEmpty(txtValor.Text) ? (decimal?) null : decimal.Parse(txtValor.Text, _cultura);

            set => this.txtValor.Text = value.HasValue ? GSUtilitarios.FormateDecimalParaStringMoedaReal(value.GetValueOrDefault()) : string.Empty;
        }

        private void txtValor_TextChanged(object sender, EventArgs e)
        {
            AjusteTextBoxMonetaria(ref txtValor);
        }

        public static void AjusteTextBoxMonetaria(ref TextBox textBox)
        {
            if (!textBox.Text.All(GSUtilitarios.EhDigitoOuPonto))
            {
                textBox.Text = string.Empty;
                return;
            }

            try
            {
                var numero = textBox.Text
                    .Replace(",", string.Empty)
                    .Replace(".", string.Empty);

                if (numero == string.Empty)
                {
                    return;
                }

                numero = numero.PadLeft(3, '0');

                if (numero.Length > 3 && numero.Substring(0, 1) == "0")
                {
                    numero = numero.Substring(1, numero.Length - 1);
                }

                var valor = Convert.ToDouble(numero) / 100;
                textBox.Text = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:N}", valor);
                textBox.SelectionStart = textBox.Text.Length;
            }
            catch (Exception)
            {
                throw new Exception("Ocorreu um erro na formatação monetária.");
            }
        }
    }
}
