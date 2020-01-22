using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using GS.GestaoEmpresa.Solucao.Persistencia.Repositorios.Base;

namespace GS.GestaoEmpresa.Solucao.Persistencia.Repositorios
{
    public class RepositorioDeConfiguracao : RepositorioPadrao<Configuracoes>
    {
        public Configuracoes ObtenhaUnica() => ConsulteTodos().FirstOrDefault();
    }
}
