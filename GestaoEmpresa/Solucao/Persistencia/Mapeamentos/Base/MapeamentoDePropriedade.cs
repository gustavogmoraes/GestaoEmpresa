using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Seguros.Conceito;
using System;
using System.Reflection;

namespace GS.GestaoEmpresa.Solucao.Persistencia.Mapeamentos.Base
{
    public class MapeamentoDePropriedade
    {
        public PropertyInfo Propriedade { get; set; }

        public string Coluna { get; set; }

        public Type Repositorio { get; set; }

        public MethodInfo MetodoParaObtencao { get; set; }

        public object[] ParametrosParaObtencaoOuExclusao { get; set; }

        public MethodInfo MetodoParaDefinicao { get; set; }

        public MethodInfo MetodoParaExclusao { get; set; }

        public MethodInfo MetodoParaAtualizacao { get; set; }

        public EnumTipoDeMapeamento? TipoDeMapeamento { get; set; }

        public EnumConceitos? Conceito { get; set; }


    }
}
