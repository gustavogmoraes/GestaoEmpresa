﻿using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos.Atributos;
using System;
using System.Collections.Generic;

namespace GS.GestaoEmpresa.Solucao.Negocio.Objetos.ObjetosAbstratos
{
    public class Grupo<TEntidade>
    {
        [PropriedadeBD(EhChave = true)]
        public int Codigo;

        [PropriedadeBD(QuantidadeCaracteres = 100)]
        public string Nome;

        [PropriedadeBD(QuantidadeCaracteres = 1000)]
        public string Descricao;

        [PropriedadeBD(TipoDeRelacionamento = EnumTipoDeEntidadeRelacional.UmParaMuitos)]
        public List<TEntidade> lista;
    }
}
