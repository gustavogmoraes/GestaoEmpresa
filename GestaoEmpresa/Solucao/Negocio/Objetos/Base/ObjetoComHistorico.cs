using GS.GestaoEmpresa.Solucao.Negocio.Atributos;
using GS.GestaoEmpresa.Solucao.Negocio.Interfaces;
using System;

namespace GS.GestaoEmpresa.Solucao.Negocio.Objetos.Base
{
    public class ObjetoComHistorico : IConceitoComHistorico
    {
        [Identificacao(Descricao = "Código")]
        public int Codigo { get; set; }

        public bool Atual { get; set; }

        private DateTime _vigencia;

        public DateTime Vigencia
        {
            get => _vigencia;
            set => _vigencia = TrateDateTimeExcluindoMS(value);
        }

        protected DateTime TrateDateTimeExcluindoMS(DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second);
        }
    }
}
