using System;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns;

namespace GS.GestaoEmpresa.Solucao.Negocio.Interfaces
{
    public interface IConceitoComHistorico : IConceito
    {
        DateTime Vigencia { get; set; }

        bool Atual { get; set; }

        EnumStatusToggle Status { get; set; }
    }
}
