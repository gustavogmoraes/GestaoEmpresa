﻿using GS.GestaoEmpresa.Solucao.Negocio.Objetos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.GestaoEmpresa.Solucao.Negocio.Interfaces
{
    public interface IObjectWithRavenAttachments
    {
        RavenAttachments RavenAttachments { get; set; }
    }
}
