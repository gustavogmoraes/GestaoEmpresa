﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Windows.Forms;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns;
using GS.GestaoEmpresa.Solucao.Negocio.Interfaces;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using GS.GestaoEmpresa.Solucao.Negocio.Servicos;
using GS.GestaoEmpresa.Solucao.UI.Base;
using GS.GestaoEmpresa.Solucao.UI.ControlesGenericos;

namespace GS.GestaoEmpresa.Solucao.UI.Modulos.Estoque
{
    public sealed class ProdutoPresenter : Presenter<Produto, FrmProdutoMetro>, IPresenter
    {
        public ProdutoPresenter()
        {
            MapeieControle(model => model.Codigo, view => view.txtCodigo);
            MapeieControle(model => model.Vigencia, view => view.cbVigencia);
            MapeieControle(model => model.Status, view => view.toggleStatus);
            MapeieControle(model => model.Nome, view => view.txtNome);
            MapeieControle(model => model.Observacao, view => view.txtObservacoes);
            MapeieControle(model => model.Fabricante, view => view.txtMarca);
            MapeieControle(model => model.CodigoDoFabricante, view => view.txtCodigoFabricante);
            MapeieControle(model => model.QuantidadeMinimaParaAviso, view => view.txtQuantidadeMinima);
            MapeieControle(model => model.AvisarQuantidade, view => view.chkAvisarQuantidade);
            MapeieControle(model => model.CodigoDeBarras, view => view.txtCodigoDeBarras);
            MapeieControle(model => model.PrecoDeCompra, view => view.txtMPrecoDeCompra);
            MapeieControle(model => model.PrecoDeVenda, view => view.txtMPrecoDeVenda);
            MapeieControle(model => model.PorcentagemDeLucro, view => view.txtMLucro);
            MapeieControle(model => model.Ipi, view => view.txtMPorcentagemIpi);
            MapeieControle(model => model.PrecoNaIntelbras, view => view.txtMPrecoNaIntelbras);
            MapeieControle(model => model.PrecoDistribuidor, view => view.txtMPrecoSugeridoRevenda);
            MapeieControle(model => model.PrecoSugeridoConsumidorFinal, view => view.txtMPscf);
            MapeieControle(model => model.PorcentagemDeLucroDistribuidor, view => view.txtMPorcentagemDeLucroConsumidorFinal);
            MapeieControle(model => model.RavenAttachments, view => view.gsImageAttacher1);
            MapeieControle(model => model.TambemConhecidoComo, view => view.txtTambemConhecidoComo);
            MapeieControle(model => model.LocalizacaoNoEstoque, view => view.txtLocalizacao);
        }

        public IList<Inconsistencia> Salve()
        {
            using (var servicoDeProduto = new ServicoDeProduto())
            {
                return servicoDeProduto.Salve(Model, View.TipoDeForm);
            }
        }

        public IList<Inconsistencia> Exclua(int codigo)
        {
            using (var servicoDeProduto = new ServicoDeProduto())
            {
                return servicoDeProduto.Exclua(codigo);
            }
        }

        public void RecarregueVigencia(DateTime dataVigencia)
        {
            GSWaitForm.Mostrar(
                () =>
                {
                    using var servicoDeProduto = new ServicoDeProduto();
                    var vigenciaConsultada = servicoDeProduto.Consulte(Model.Codigo, dataVigencia);
                    Model = vigenciaConsultada;

                    View.Invoke((MethodInvoker)delegate
                    {
                        View.EstahRenderizando = true;

                        View.Presenter?.CarregueControlesComModel();
                        View.EstahRenderizando = true;

                        View.cbVigencia.SelectedItem = dataVigencia.ToString("dd/MM/yyyy HH:mm:ss");
                        View.txtQuantidadeEmEstoque.Text = servicoDeProduto.ConsulteQuantidade(vigenciaConsultada.Codigo).ToString();

                        View.EstahRenderizando = false;
                    });
                });
        }

        public Produto Consulte(int codigo)
        {
            using var servicoDeProduto = new ServicoDeProduto();
            return servicoDeProduto.Consulte(codigo);
        }

        public override void CarregueControlesComModel(bool reloading = false)
        {
            base.CarregueControlesComModel(reloading);

            using var servico = new ServicoDeProduto();
            var quantidade = servico.ConsulteQuantidade(Model.Codigo);
            View.txtQuantidadeEmEstoque.Text = quantidade.ToString();
        }
    }
}
