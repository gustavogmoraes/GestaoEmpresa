﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.GestaoEmpresa.Solucao.Negocio.Objetos.Base
{
    public class RavenAttachments
    {
        public List<string> AttachmentsNames { get; set; }

        [JsonIgnore]
        public Dictionary<string, Stream> FileStreams { get; set; }
    }
}
