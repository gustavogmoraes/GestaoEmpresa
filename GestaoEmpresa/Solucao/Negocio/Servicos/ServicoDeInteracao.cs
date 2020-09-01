using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using GS.GestaoEmpresa.Solucao.Negocio.Validador;
using GS.GestaoEmpresa.Solucao.Persistencia.Repositorios;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns;
using GS.GestaoEmpresa.Solucao.Negocio.Servicos.Base;
using GS.GestaoEmpresa.Solucao.UI;
using GS.GestaoEmpresa.Solucao.UI.Modulos.Estoque;
using GS.GestaoEmpresa.Solucao.Utilitarios;

namespace GS.GestaoEmpresa.Solucao.Negocio.Servicos
{
    public class ServicoDeInteracao : ServicoPadrao<Interacao, ValidadorDeInteracao, RepositorioDeInteracao>, IDisposable
    {
        private static Expression<Func<Interacao, object>> SeletorInteracaoAterrissagem => x => new Interacao
        {
            Codigo = x.Codigo,
            TipoDeInteracao = x.TipoDeInteracao,
            Produto = new Produto
            {
                Codigo = x.Codigo, 
                Nome = x.Produto.Nome
            },
            QuantidadeInterada = x.QuantidadeInterada,
            Origem = x.Origem,
            Destino = x.Destino,
            Finalidade = x.Finalidade,
            Situacao = x.Situacao,
            NumerosDeSerie = x.NumerosDeSerie,
            HorarioProgramado = x.HorarioProgramado,
            ValorInteracao = x.ValorInteracao,
        };

        private static Expression<Func<Interacao, object>>[] PropriedadesParaPesquisa => new Expression<Func<Interacao, object>>[] 
        {
            x => x.Produto.Nome, x => x.Produto.CodigoDoFabricante, x => x.Produto.Codigo, x => x.Produto.CodigoDeBarras,
            x => x.Destino, x => x.Origem, x => x.NumerosDeSerie
        };

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

        public List<Interacao> ConsulteTodasParaAterrissagem(string pesquisa = null)
        {
            if (pesquisa.IsNullOrEmpty())
            {
                return Repositorio.ConsulteTodos(SeletorInteracaoAterrissagem, pesquisa, int.MaxValue)
                    .OrderByDescending(x => x.HorarioProgramado)
                    .ToList();
            }

            return Repositorio.ConsulteTodos(SeletorInteracaoAterrissagem, pesquisa, 500, PropriedadesParaPesquisa)
                .OrderByDescending(x => x.HorarioProgramado)
                .ToList();
        }

        private List<Interacao> ConsultePorNumeroDeSerie(string numeroDeSerie)
        {
            using (var repositorioDeInteracao = new RepositorioDeInteracao())
            {
                return repositorioDeInteracao.Consulte(x =>
                    x.InformaNumeroDeSerie &&
                    x.NumerosDeSerie.Contains(numeroDeSerie))
                .ToList();
            }
        }
        
        public bool VerifiqueSeNumeroDeSerieEstahEmEstoque(string numeroDeSerie)
        {
            var listaDeInteracoes = ConsultePorNumeroDeSerie(numeroDeSerie);

            var numeroDeEntradas = listaDeInteracoes.Count(x => x.TipoDeInteracao == EnumTipoDeInteracao.ENTRADA);
            var numeroDeSaidas = listaDeInteracoes.Count(x => x.TipoDeInteracao == EnumTipoDeInteracao.SAIDA);

            return (numeroDeEntradas > numeroDeSaidas);
        }

        public new List<Inconsistencia> Exclua(int codigoDaInteracao)
        {
            using (var servicoDeProduto = new ServicoDeProduto())
            using (var validador = new ValidadorDeInteracao())
            using (var repositorioDeInteracao = new RepositorioDeInteracao())
            {
                var interacao = Consulte(codigoDaInteracao);
                var quantidadeDeProduto = servicoDeProduto.ConsulteQuantidade(interacao.Produto.Codigo).GetValueOrDefault();

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
                        if (interacao.ValorInteracao != valorDoProduto.GetValueOrDefault())
                        {
                            if (interacao.TipoDeInteracao == EnumTipoDeInteracao.ENTRADA)
                            {
                                produtoConsultado.PrecoDeCompra = interacao.ValorInteracao;
                                produtoConsultado.CalculePrecoDeVenda();
                            }
                            else
                            {
                                produtoConsultado.PrecoDeVenda = interacao.ValorInteracao;
                            }

                            servicoDeProduto.Salve(produtoConsultado, EnumTipoDeForm.Edicao);
                        }
                    }

                    servicoDeProduto.AltereQuantidadeDeProduto(produtoConsultado.Codigo, produtoConsultado.QuantidadeEmEstoque + quantidadeInterada + quantidadeInteradaAux);
                }
            };
        }

        protected override Action AcaoSucessoValidacaoDeEdicao(Interacao item)
        {
            return () => 
            {
                if(item.Situacao == "Devolvido")
                {
                    var servicoDeProduto = new ServicoDeProduto();
                    var produtoConsultado = servicoDeProduto.Consulte(item.Produto.Codigo);
                    servicoDeProduto.AltereQuantidadeDeProduto(produtoConsultado.Codigo, produtoConsultado.QuantidadeEmEstoque + item.QuantidadeInterada);
                    servicoDeProduto.Dispose();

                    item.TipoDeInteracao = EnumTipoDeInteracao.BASE_DE_TROCA;
                }
            };
        }

        protected override Action AcaoSucessoValidacaoDeExclusao(int codigo)
        {
            return () => { };
        }
    }
}
