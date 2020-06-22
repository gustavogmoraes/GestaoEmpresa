using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using GS.GestaoEmpresa.Solucao.Persistencia.Repositorios.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GS.GestaoEmpresa.Solucao.Persistencia.BancoDeDados;

namespace GS.GestaoEmpresa.Solucao.Persistencia.Repositorios
{
    public class RepositorioDeInteracao : RepositorioPadrao<Interacao>
    {
        public bool VerifiqueSeNumeroDeSerieExisteNoBanco(string numeroDeSerie)
        {
            using (var sessaoRaven = RavenHelper.OpenSession())
            {
                return sessaoRaven.Query<Interacao>()
                    .Where(x => x.InformaNumeroDeSerie && x.NumerosDeSerie.Any())
                    .Any(x => x.NumerosDeSerie.Contains(numeroDeSerie));
            }
        }
    }
}
