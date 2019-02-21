using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using GS.GestaoEmpresa.Solucao.Negocio.Servicos;
using GS.GestaoEmpresa.Solucao.Persistencia.Repositorios.RavenDB.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.GestaoEmpresa.Solucao.Persistencia.Repositorios
{
    public class RepositorioDeProdutoRaven : RepositorioComHistoricoBaseRaven<Produto>
    {
        public void MigreProdutosParaRaven()
        {
            using (var servicoDeProduto = new RepositorioDeProduto())
            {
                var produtosConsultados = servicoDeProduto.ConsulteTodos();

                foreach (var produto in produtosConsultados)
                {
                    var todasVigencias = servicoDeProduto.ConsulteTodasVigencias(produto.Codigo).OrderBy(x => x);

                    foreach(var vigencia in todasVigencias)
                    {
                        var produtoVigencia = servicoDeProduto.Consulte(produto.Codigo, vigencia);
                        produtoVigencia.Vigencia = vigencia;

                        if (vigencia == todasVigencias.LastOrDefault())
                            produtoVigencia.Atual = true;
                        
                        Insira(produtoVigencia);
                    }
                }
            }
        }
    }
}
