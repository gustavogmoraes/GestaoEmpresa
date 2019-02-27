using System;
using System.Collections.Generic;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using GS.GestaoEmpresa.Solucao.Negocio.Validador;
using GS.GestaoEmpresa.Solucao.Persistencia.Repositorios;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns;
using System.Linq;

namespace GS.GestaoEmpresa.Solucao.Negocio.Servicos
{
    public class ServicoDeProduto : IDisposable
    {
        public IList<Produto> ConsulteTodosOsProdutos()
        {
            using (var repositorioDeProdutoRaven = new RepositorioDeProdutoRaven())
            {
                return repositorioDeProdutoRaven.ConsulteTodos();
            }
        }

        public List<DateTime> ConsulteTodasAsVigenciasDeUmProduto(int codigoDoProduto)
        {
            var listaDeVigencias = new List<DateTime>();
            using (var repositorioDeProdutoRaven = new RepositorioDeProdutoRaven())
            {
                listaDeVigencias = repositorioDeProdutoRaven.ConsulteVigencias(codigoDoProduto) as List<DateTime>;
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

        public int ConsulteQuantidade(int codigo)
        {
            using (var repositorioDeProduto = new RepositorioDeProdutoRaven())
            {
                return repositorioDeProduto.ConsulteQuantidade(codigo);
            }
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
            var horarioChamada = DateTime.Now;

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
                    produto.Vigencia = horarioChamada;

                    if (tipoDoForm == EnumTipoDeForm.Cadastro)
                    {
                        produto.Atual = true;
                        produto.QuantidadeEmEstoque = 0;

                        mapeadorDeProduto.Insira(produto);
                    }
                    else if (tipoDoForm == EnumTipoDeForm.Edicao)
                    {
                        mapeadorDeProduto.Atualize(produto);
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
