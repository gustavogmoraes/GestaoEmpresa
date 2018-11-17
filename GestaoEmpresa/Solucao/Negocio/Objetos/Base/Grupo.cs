using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns;
using System;
using System.Collections.Generic;

namespace GS.GestaoEmpresa.Solucao.Negocio.Objetos.Base
{
    public class Grupo<TEntidade>
    {
        public int Codigo;

        public string Nome;

        public string Descricao;

        public List<TEntidade> lista;
    }
}
