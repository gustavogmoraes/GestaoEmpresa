﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns;
using GS.GestaoEmpresa.Solucao.Negocio.Interfaces;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using GS.GestaoEmpresa.Solucao.UI.Base;
using GS.GestaoEmpresa.Solucao.Utilitarios;

namespace GS.GestaoEmpresa.Solucao.UI.Modulos.Estoque
{
    public partial class frmProdutoMetro : GSForm, IView
    {
        public frmProdutoMetro()
        {
            InitializeComponent();
        }

        protected override void ChamadaSalvar(object sender, EventArgs e)
        {
            var result = (Presenter as ProdutoPresenter)?.Salve();
            if(!result.Any())
            {
                MessageBox.Show("Cadastrado com sucesso!", "Resultado");
            }

            TipoDeForm = EnumTipoDeForm.Detalhamento;
        }

        protected override void ChamadaExclusao(object sender, EventArgs e)
        {
            (Presenter as ProdutoPresenter)?.Exclua(Presenter.Model.Codigo);
        }

        private void TxtCodigoDeBarras_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.IsAny(Keys.Return, Keys.Enter))
            {
                txtNome.Focus();
            }
        }

        private void cbVigencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(EstahRenderizando)
            {
                EstahRenderizando = false;
                return;
            }

            var dataVigencia = DateTime.ParseExact((string)cbVigencia.SelectedItem, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            (Presenter as ProdutoPresenter).RecarregueVigencia(dataVigencia);
        }
    }
}
