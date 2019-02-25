using System;

namespace GS.GestaoEmpresa.Solucao.Negocio.Interfaces
{
    public interface IConceitoComHistorico : IConceito
    {
        DateTime Vigencia { get; set; }

        bool Atual { get; set; }
    }
}
