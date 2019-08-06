﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores;
using GS.GestaoEmpresa.Solucao.Negocio.Validador;
using GS.GestaoEmpresa.Solucao.Persistencia.Repositorios;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns;
using GS.GestaoEmpresa.Solucao.Negocio.Servicos.Base;

namespace GS.GestaoEmpresa.Solucao.Negocio.Servicos
{
    public class ServicoDeInteracao : ServicoPadrao<Interacao, ValidadorDeInteracao, RepositorioDeInteracao>, IDisposable
    {
        public List<Interacao> ConsulteTodasAsInteracoes()
        {
            return Repositorio.ConsulteTodos().OrderByDescending(x => x.HorarioProgramado).ToList();
        }

        public bool VerifiqueSeNumeroDeSerieExisteNoBanco(string numeroDeSerie)
        {
            using (var repositorioDeInteracao = new RepositorioDeInteracao())
            {
                return repositorioDeInteracao.VerifiqueSeNumeroDeSerieExisteNoBanco(numeroDeSerie);
            }
        }

        public List<Interacao> ConsulteTodasAsInteracoesPorProduto(int codigoProduto)
        {
            using (var repositorioDeInteracao = new RepositorioDeInteracao())
            {
                return repositorioDeInteracao.Consulte(x => x.Produto.Codigo == codigoProduto).ToList();
            }
        }

        public List<Interacao> ConsulteTodasParaAterrissagem()
        {
            return Repositorio.ConsulteTodos(seletor: x => new Interacao
            {
                Codigo = x.Codigo,
                Observacao = x.Observacao,
                Origem = x.Origem,
                Destino = x.Destino,
                TipoDeInteracao = x.TipoDeInteracao,
                NumerosDeSerie = x.NumerosDeSerie,
                Produto = new Produto { Nome = x.Produto.Nome }
            })
            .OrderBy(x => x.Codigo)
            .ToList();
        }

        private List<Interacao> ConsultePorNumeroDeSerie(string numeroDeSerie)
        {
            using (var repositorioDeInteracao = new RepositorioDeInteracao())
            {
                return repositorioDeInteracao.Consulte(x => x.InformaNumeroDeSerie && 
                                                            x.NumerosDeSerie.Contains(numeroDeSerie))
                                             .ToList();
            }
        }
        
        public bool VerifiqueSeNumeroDeSerieEstahEmEstoque(string numeroDeSerie)
        {
            var listaDeInteracoes = ConsultePorNumeroDeSerie(numeroDeSerie);

            var numeroDeEntradas = listaDeInteracoes.Where(x => x.TipoDeInteracao == EnumTipoDeInteracao.ENTRADA).Count();
            var numeroDeSaidas = listaDeInteracoes.Where(x => x.TipoDeInteracao == EnumTipoDeInteracao.SAIDA).Count();

            return (numeroDeEntradas > numeroDeSaidas);
        }

        public new List<Inconsistencia> Exclua(int codigoDaInteracao)
        {
            using (var servicoDeProduto = new ServicoDeProduto())
            using (var validador = new ValidadorDeInteracao())
            using (var repositorioDeInteracao = new RepositorioDeInteracao())
            {
                var interacao = Consulte(codigoDaInteracao);
                var quantidadeDeProduto = servicoDeProduto.ConsulteQuantidade(interacao.Produto.Codigo);

                var inconsistencias = validador.ValideExclusao(codigoDaInteracao).ToList();
                if (inconsistencias.Count > 0)
                {
                    return inconsistencias;
                }

                int quantidadeInterada = 0;
                int quantidadeInteradaAux = 0;

                switch (interacao.TipoDeInteracao)
                {
                    case EnumTipoDeInteracao.ENTRADA:
                        quantidadeInterada = interacao.QuantidadeInterada * (-1);
                        break;

                    case EnumTipoDeInteracao.SAIDA:
                        quantidadeInterada = interacao.QuantidadeInterada;
                        break;

                    case EnumTipoDeInteracao.BASE_DE_TROCA:
                        // Entrada
                        quantidadeInterada = interacao.QuantidadeInterada * (-1);

                        // Saída
                        quantidadeInteradaAux = interacao.QuantidadeAuxiliar.GetValueOrDefault();
                        break;
                }

                var novaQuantidade = quantidadeDeProduto + quantidadeInterada + quantidadeInteradaAux;

                repositorioDeInteracao.Exclua(codigoDaInteracao);
                servicoDeProduto.AltereQuantidadeDeProduto(interacao.Produto.Codigo, novaQuantidade);

                return inconsistencias;
            }
        }

        protected override Action AcaoSucessoValidacaoDeCadastro(Interacao interacao)
        {
            return () =>
            {
                using (var servicoDeProduto = new ServicoDeProduto())
                {
                    int quantidadeInterada = 0;
                    int quantidadeInteradaAux = 0;
                    switch (interacao.TipoDeInteracao)
                    {
                        case EnumTipoDeInteracao.ENTRADA:
                            quantidadeInterada = interacao.QuantidadeInterada;
                            break;

                        case EnumTipoDeInteracao.SAIDA:
                            quantidadeInterada = interacao.QuantidadeInterada * (-1);
                            break;

                        case EnumTipoDeInteracao.BASE_DE_TROCA:
                            // Entrada
                            quantidadeInterada = interacao.QuantidadeInterada;

                            // Saída
                            quantidadeInteradaAux = interacao.QuantidadeAuxiliar.GetValueOrDefault() * (-1);
                            break;
                    }

                    var produtoConsultado = servicoDeProduto.Consulte(interacao.Produto.Codigo);

                    // Nesse caso atualizamos o produto com o novo valor
                    if (interacao.AtualizarValorDoProdutoNoCatalogo)
                    {
                        var valorDoProduto = interacao.TipoDeInteracao == EnumTipoDeInteracao.ENTRADA
                            ? produtoConsultado.PrecoDeCompra
                            : produtoConsultado.PrecoDeVenda;

                        // Só devemos criar uma nova vigência, caso o valor seja diferente, senão é desnecessário
                        if (interacao.ValorInteracao != valorDoProduto)
                        {
                            if (interacao.TipoDeInteracao == EnumTipoDeInteracao.ENTRADA)
                            {
                                produtoConsultado.PrecoDeCompra = interacao.ValorInteracao;

                                produtoConsultado.PrecoDeVenda = Math.Round(
                                    produtoConsultado.PrecoDeCompra * (1 + produtoConsultado.PorcentagemDeLucro), 2);
                            }
                            else
                            {
                                produtoConsultado.PrecoDeVenda = interacao.ValorInteracao;
                            }

                            servicoDeProduto.Salve(produtoConsultado, EnumTipoDeForm.Edicao);
                        }
                    }

                    servicoDeProduto.AltereQuantidadeDeProduto(produtoConsultado.Codigo,
                        produtoConsultado.QuantidadeEmEstoque + quantidadeInterada + quantidadeInteradaAux);
                }
            };
        }

        protected override Action AcaoSucessoValidacaoDeEdicao(Interacao item)
        {
            return () => { };
        }

        protected override Action AcaoSucessoValidacaoDeExclusao(int codigo)
        {
            return () => { };
        }
    }
}
