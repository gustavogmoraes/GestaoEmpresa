using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using GS.GestaoEmpresa.Solucao.Persistencia.BancoDeDados;
using GS.GestaoEmpresa.Solucao.Persistencia.Repositorios.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using static Raven.Client.Constants;

namespace GS.GestaoEmpresa.Solucao.Persistencia.Repositorios
{
    public class RepositorioDeProdutoRaven : RepositorioHistoricoPadrao<Produto>
    {
        private Dictionary<int, int> _tabelaDeQuantidades { get; set; }

        public class TabelaDeQuantidadesDeProduto
        {
            public Dictionary<int, int> Tabela { get; set; }
        }

        public RepositorioDeProdutoRaven()
        {
            using (var sessaoRaven = _documentStore.OpenSession())
            {
                var variavel = sessaoRaven.Load<TabelaDeQuantidadesDeProduto>("TabelaDeQuantidadesDeProduto");
            }
        }

        public void InsiraNaTabelaQuantidade(int codigo)
        {
            throw new NotImplementedException();
        }

        public void AltereQuantidadeDeProduto(int codigoDoProduto, int novaQuantidade)
        {
            throw new NotImplementedException();
        }

        public void MigreProdutosParaRaven()
        {
            using (var servicoDeProduto = new RepositorioDeProduto())
            {
                var produtosConsultados = servicoDeProduto.ConsulteTodos();

                foreach (var produto in produtosConsultados)
                {
                    var todasVigencias = servicoDeProduto.ConsulteTodasVigencias(produto.Codigo).OrderBy(x => x);

                    foreach (var vigencia in todasVigencias)
                    {
                        var produtoVigencia = servicoDeProduto.Consulte(produto.Codigo, vigencia);
                        produtoVigencia.Vigencia = vigencia;

                        if (vigencia == todasVigencias.LastOrDefault())
                            produtoVigencia.Atual = true;

                        Insira(produtoVigencia);
                    }
                }
            }

            MigreTabelaQuantidade();
        }

        public void MigreTabelaQuantidade()
        {
            using (var GSBD = new GSBancoDeDados())
            using (var sessaoRaven = _documentStore.OpenSession())
            {
                var tabelaQuantidades = new Dictionary<int, int>();
                var tabelaQuantidadesSQL = GSBD.ExecuteConsulta("SELECT CODIGO_PRODUTO, QUANTIDADE FROM PRODUTOS_QUANTIDADES");

                foreach (DataRow linha in tabelaQuantidadesSQL.Rows)
                {
                    tabelaQuantidades.Add(Convert.ToInt32(linha["CODIGO_PRODUTO"]), Convert.ToInt32(linha["QUANTIDADE"]));
                }

                sessaoRaven.Store(new TabelaDeQuantidadesDeProduto { Tabela = tabelaQuantidades }, "TabelaDeQuantidadesDeProduto");
                sessaoRaven.SaveChanges();
            }
        }
    }
}
