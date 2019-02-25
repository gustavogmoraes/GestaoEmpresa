using GS.GestaoEmpresa.Solucao.Negocio.Atributos;
using GS.GestaoEmpresa.Solucao.Negocio.Interfaces;
using System;

namespace GS.GestaoEmpresa.Solucao.Negocio.Objetos.Base
{
    public class ObjetoComHistorico : IConceitoComHistorico
    {
        [Identificacao(Descricao = "Código")]
        public int Codigo { get; set; }

        public DateTime Vigencia { get; set; }

        public bool Atual { get; set; }
    }
}
