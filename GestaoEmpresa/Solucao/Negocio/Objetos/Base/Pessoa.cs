using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Seguros.TipoDePessoa;
using GS.GestaoEmpresa.Solucao.Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.GestaoEmpresa.Solucao.Negocio.Objetos.Base
{
    public class Pessoa : ObjetoComHistorico, IConceitoComHistorico
    {
        public string Nome { get; set; }

        public string Cpfcnpj { get; set; }

        public EnumTiposDePessoa TipoDePessoa { get; set; }
    }
}
