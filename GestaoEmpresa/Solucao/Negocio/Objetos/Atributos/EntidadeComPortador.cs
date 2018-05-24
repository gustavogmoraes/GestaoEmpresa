using System;
namespace GS.GestaoEmpresa.Solucao.Negocio.Objetos.Atributos
{
    public class EntidadeComPortador : Attribute
    {
        public Type Portador { get; set; }

        public EntidadeComPortador(Type portador)
        {
            this.Portador = Portador;
        }
    }
}
