using GS.GestaoEmpresa.Solucao.Negocio.Atributos;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns;
using GS.GestaoEmpresa.Solucao.Negocio.Interfaces;
using System;
using System.Linq;

namespace GS.GestaoEmpresa.Solucao.Negocio.Objetos.Base
{
    public class ObjetoComHistorico : BaseObject, IEntityWithRevision
    {
        public string Id { get; set; }

        [ExporterMetadata(Descricao = "Código")]
        public int Codigo { get; set; }

        public bool Atual { get; set; }

        public DateTime RevisionStartTime { get; set; }
        public bool Current { get; set; }
        public EnumStatusToggle Status { get; set; }

        private DateTime _revisionStartDateTime;

        public DateTime RevisionStartDateTime
        {
            get => _revisionStartDateTime;
            set => _revisionStartDateTime = ExcludeMsFromDateTime(value);
        }

        protected DateTime ExcludeMsFromDateTime(DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second);
        }

        public ObjetoComHistorico()
        {

        }

        public ObjetoComHistorico(ObjetoComHistorico modelo) : base(modelo) { }

        public int Code { get; set; }
    }
}
