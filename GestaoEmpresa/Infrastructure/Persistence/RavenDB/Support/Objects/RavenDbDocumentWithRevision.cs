using GS.GestaoEmpresa.Business.Interfaces;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns;
using System;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos.Base;
using Newtonsoft.Json;

namespace GS.GestaoEmpresa.Persistence.RavenDbSupport.Objects
{
    public class RavenDbDocumentWithRevision : IEntityWithRevision
    {
        public string Id { get; set; }

        public int Code { get; set; }

        [JsonIgnore]
        public DateTime RevisionStartTime { get; set; }

        [JsonIgnore]
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

        public RavenAttachments RavenAttachments { get; set; }
    }
}
