using System;
using System.Collections.Generic;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns;
using GS.GestaoEmpresa.Solucao.Negocio.Interfaces;

namespace GS.GestaoEmpresa.Solucao.Negocio.Objetos
{
    public class Usuario : IConceito
    {
        public int Codigo { get; set; }

        public EnumStatusDoUsuario Status { get; set; }

        public string Nome { get; set; }

        public int Senha { get; set; }

        public Colaborador Funcionario { get; set; }
    }
}
