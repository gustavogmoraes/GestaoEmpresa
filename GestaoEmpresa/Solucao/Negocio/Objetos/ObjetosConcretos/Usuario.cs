using System;
using System.Collections.Generic;
using GS.GestaoEmpresa.Solucao.Mapeador.Mapeadores.MapeadoresConcretos;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos.Atributos;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos.ObjetosAbstratos;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores;

namespace GS.GestaoEmpresa.Solucao.Negocio.Objetos.ObjetosConcretos
{
    public class Usuario
    {
        public int Codigo { get; set; }

        public EnumStatusDoUsuario Status { get; set; }

        public string Nome { get; set; }

        public int Senha { get; set; }

        public Funcionario Funcionario { get; set; }
    }
}
