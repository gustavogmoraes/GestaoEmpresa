using System;
using System.Collections.Generic;
using GS.GestaoEmpresa.Solucao.Mapeador.Mapeadores.MapeadoresConcretos;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos.Atributos;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos.ObjetosAbstratos;

namespace GS.GestaoEmpresa.Solucao.Negocio.Objetos.ObjetosConcretos
{
    public class Usuario
    {   
        public int Codigo { get; set; }

        public string NomeUsuario { get; set; }

        public string Senha { get; set; }

        public int Grupo { get; set; }

        //public Funcionario Funcionario { get; set; }
    }
}
