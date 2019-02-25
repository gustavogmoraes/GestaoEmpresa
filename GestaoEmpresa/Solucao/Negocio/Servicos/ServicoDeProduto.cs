using System;
using System.Collections.Generic;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using GS.GestaoEmpresa.Solucao.Negocio.Validador;
using GS.GestaoEmpresa.Solucao.Persistencia.Repositorios;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns;

namespace GS.GestaoEmpresa.Solucao.Negocio.Servicos
{
    public class ServicoDeProduto : IDisposable
    {
        public IList<Produto> ConsulteTodosOsProdutos()
        {
            using (var RepositorioDeProdutoRaven = new RepositorioDeProdutoRaven())
            {
                return RepositorioDeProdutoRaven.ConsulteTodos();
            }
        }

        public List<DateTime> ConsulteTodasAsVigenciasDeUmProduto(int codigoDoProduto)
        {
            var listaDeVigencias = new List<DateTime>();
            using (var RepositorioDeProdutoRaven = new RepositorioDeProdutoRaven())
            {
                listaDeVigencias = RepositorioDeProdutoRaven.ConsulteVigencias(codigoDoProduto) as List<DateTime>;
            }

            return listaDeVigencias;
        }

        public int ObtenhaQuantidadeDeRegistros()
        {
            using (var RepositorioDeProdutoRaven = new RepositorioDeProdutoRaven())
                return RepositorioDeProdutoRaven.ConsulteTodos().Count;
        }

        public Produto Consulte(int codigo, DateTime data)
        {
            using (var mapeadorDeProduto = new RepositorioDeProdutoRaven())
                return mapeadorDeProduto.Consulte(codigo, data);
        }

        public Produto Consulte(int codigo)
        {
            using (var mapeadorDeProduto = new RepositorioDeProdutoRaven())
                return mapeadorDeProduto.Consulte(codigo);
        }

        public int ObtenhaProximoCodigoDisponivel()
        {
            int codigo;
            using (var mapeadorDeProduto = new RepositorioDeProdutoRaven())
            {
                codigo = mapeadorDeProduto.ObtenhaProximoCodigoDisponivel();
            }

            return codigo;
        }

        public List<Inconsistencia> Exclua(int codigoDoProduto)
        {
            var listaDeInconsistenciasExclusao = new List<Inconsistencia>();
            using (var validadorDeProduto = new ValidadorDeProduto())
            {
                listaDeInconsistenciasExclusao = validadorDeProduto.ValideExcluir(codigoDoProduto);
            }

            if (listaDeInconsistenciasExclusao.Count == 0)
            {
                using (var mapeadorDeProduto = new RepositorioDeProdutoRaven())
                {
                    mapeadorDeProduto.Exclua(codigoDoProduto);
                }
            }

            return listaDeInconsistenciasExclusao;
        }

        public List<Inconsistencia> Salve(Produto produto, EnumTipoDeForm tipoDoForm)
        {
            var listaDeInconsistencias = new List<Inconsistencia>();

            if (tipoDoForm == EnumTipoDeForm.Cadastro)
            {
                using (var validadorDeProduto = new ValidadorDeProduto())
                {
                    listaDeInconsistencias = validadorDeProduto.ValideCadastroInicial(produto);
                }

                if (listaDeInconsistencias.Count > 0)
                {
                    return listaDeInconsistencias;
                }
            }

            using (var validadorDeProduto = new ValidadorDeProduto())
            {
                listaDeInconsistencias = validadorDeProduto.ValideSalvar(produto);
            }

            if (listaDeInconsistencias.Count == 0)
            {
                using (var mapeadorDeProduto = new RepositorioDeProdutoRaven())
                {
                    mapeadorDeProduto.Insira(produto);

                    if (tipoDoForm == EnumTipoDeForm.Cadastro)
                    {
                        mapeadorDeProduto.InsiraNaTabelaQuantidade(produto.Codigo);
                    }

                    if (tipoDoForm == EnumTipoDeForm.Edicao)
                    {
                        AltereQuantidadeDeProduto(produto.Codigo, produto.QuantidadeEmEstoque);
                    }
                }
            }

            return listaDeInconsistencias;
        }

        public void AltereQuantidadeDeProduto(int codigoDoProduto, int novaQuantidade)
        {
            using (var mapeadorDeProduto = new RepositorioDeProdutoRaven())
            {
                mapeadorDeProduto.AltereQuantidadeDeProduto(codigoDoProduto, novaQuantidade);
            }
        }

        public void Dispose() { }
    }
}       
