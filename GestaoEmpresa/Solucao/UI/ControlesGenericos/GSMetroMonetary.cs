using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;
using System.Globalization;
using GS.GestaoEmpresa.Solucao.Utilitarios;

namespace GS.GestaoEmpresa.Solucao.UI.ControlesGenericos
{
    public partial class GSMetroMonetary : MetroUserControl
    {
        public GSMetroMonetary()
        {
            InitializeComponent();
        }

        private CultureInfo _culture = new CultureInfo("pt-BR");

        private int _boxSize { get; set; }
        private readonly int _defaultBoxSize = 128;

        public int BoxWidth 
        { 
            get => _boxSize;
            set
            {
                _boxSize = value;
                Width = _boxSize + 7;

                txtValue.Width = _boxSize;

                Refresh();
            }
        }

        public decimal? Value
        {
            get => string.IsNullOrEmpty(txtValue.Text) ? (decimal?)null : decimal.Parse(txtValue.Text, _culture);

            set => txtValue.Text = value.HasValue ? GSUtilitarios.FormateDecimalParaStringMoedaReal(value.GetValueOrDefault()) : string.Empty;
        }

        private void txtValue_TextChanged(object sender, EventArgs e)
        {
            txtValue.TriggerMonetaryFormat();
        }
    }
}
