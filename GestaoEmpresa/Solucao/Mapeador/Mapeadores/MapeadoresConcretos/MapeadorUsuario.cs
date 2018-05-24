using System;
using System.Globalization;
using GS.GestaoEmpresa.Solucao.Mapeador.Mapeadores.MapeadoresAbstratos;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos.ObjetosConcretos;
using GS.GestaoEmpresa.Solucao.Mapeador.BancoDeDados;
using GS.GestaoEmpresa.Solucao.Utilitarios;

namespace GS.GestaoEmpresa.Solucao.Mapeador.Mapeadores.MapeadoresConcretos
{
    public class MapeadorUsuario : MapeadorPadrao<Usuario>
    {
        TextInfo textInfo = new CultureInfo("pt-BR", false).TextInfo;

        public override string Tabela => "USUARIOS";


    }
}
