using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using GS.GestaoEmpresa.Solucao.Persistencia.BancoDeDados;
using GS.GestaoEmpresa.Solucao.Persistencia.Repositorios;
using MoreLinq;
using static System.Decimal;

namespace GS.GestaoEmpresa.Solucao.UI.Base
{
    public partial class DevPlayground : Form
    {
        public DevPlayground()
        {
            InitializeComponent();

            //using var rSession = RavenHelper.OpenSession();
            //var pqs = rSession.Query<ProdutoQuantidade>(collectionName: "ProdutosQuantidades")
            //    .Where(x => x.Quantidade < 0)
            //    .ToList();


            //foreach (var pq in pqs)
            //{
            //    pq.Quantidade = 0;
            //}
            //rSession.SaveChanges();

            //var repositorioDeProduto = new RepositorioDeProduto();
            //var allProds = repositorioDeProduto.ConsulteTodos(false, x => x.PrecoDeCompra == 0M, takeQuantity: int.MaxValue);
            //foreach (var prod in allProds)
            //{
            //    var vigs = repositorioDeProduto.ConsulteVigencias(prod.Codigo).OrderByDescending(x => x).ToList();
            //    var vigDict = vigs.ToDictionary(x => x, x => repositorioDeProduto.Consulte(prod.Codigo, x));
            //    if (vigDict.All(x => Round(x.Value.PrecoDeCompra.GetValueOrDefault(), 2) == 0M))
            //    {
            //        continue;
            //    }

            //    var max = vigDict.MaxBy(x => x.Value.PrecoDeCompra);
            //    var maxPrd = max.Value;
            //    var id = vigDict.First().Value.Id;

            //    using var rSession = RavenHelper.OpenSession();
            //    var prd = rSession.Load<Produto>(id);
            //    prd.PrecoDeCompra = maxPrd.PrecoDeCompra;
            //    prd.Ipi = maxPrd.Ipi;
            //    prd.PrecoDistribuidor = maxPrd.PrecoDistribuidor;
            //    prd.PorcentagemDeLucro = maxPrd.PorcentagemDeLucro;
            //    prd.PorcentagemDeLucroDistribuidor = maxPrd.PorcentagemDeLucroDistribuidor;
            //    prd.PrecoNaIntelbras = maxPrd.PrecoNaIntelbras;
            //    prd.PrecoDeVenda = maxPrd.PrecoDeVenda;
            //    prd.PrecoDeVendaDoDistribuidor = maxPrd.PrecoDeVendaDoDistribuidor;
            //    prd.PrecoSugeridoConsumidorFinal = maxPrd.PrecoSugeridoConsumidorFinal;

            //    rSession.SaveChanges();
            //}
        }
    }
}
