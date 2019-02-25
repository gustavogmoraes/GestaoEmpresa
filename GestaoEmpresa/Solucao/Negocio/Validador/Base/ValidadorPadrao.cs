using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Seguros.Conceito;
using GS.GestaoEmpresa.Solucao.Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.GestaoEmpresa.Solucao.Negocio.Validador.Base
{
    public class ValidadorPadrao<TConceito>
        where TConceito : IConceito, new()
    {

    }
}
