using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using GS.GestaoEmpresa.Solucao.Persistencia.Repositorios.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.GestaoEmpresa.Solucao.Persistencia.Repositorios
{
    public class RepositorioDeInteracaoRaven : RepositorioPadrao<Interacao>
    {
        public void MigreInteracaoParaRaven()
        {
            using (var repositorioDeInteracao = new RepositorioDeInteracao())
            {
                var interacoes = repositorioDeInteracao.ConsulteTodasAsInteracoes().OrderBy(x => x.Codigo).ToList();
                interacoes.ForEach(x => Insira(x));
            }
        }
    }
}
