using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GS.GestaoEmpresa.Solucao.Negocio.Objetos.ObjetosConcretos
{
    public class Inconsistencia
    {
        public string Modulo { get; set; }

        public string Tela { get; set; }

        public Object ConceitoValidado { get; set; }

        public PropertyInfo PropriedadeValidada { get; set; }

        public string Mensagem { get; set; }
    }
}
