using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos.Atributos;
using System;
using System.Collections.Generic;

namespace GS.GestaoEmpresa.Solucao.Negocio.Objetos.ObjetosAbstratos
{
    public class Grupo<TEntidade>
    {
        [BancoDeDados(EhChave = true)]
        public int Codigo;

        [BancoDeDados(QuantidadeCaracteres = 100)]
        public string Nome;

        [BancoDeDados(QuantidadeCaracteres = 1000)]
        public string Descricao;

        [BancoDeDados(TipoDeRelacionamento = EnumTipoDeEntidadeRelacional.UmParaMuitos)]
        public List<TEntidade> lista;
    }
}
