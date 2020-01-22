using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


namespace GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Seguros.Base
{
    public abstract class TypeSafeEnum<TEntidade, TIndicador>
        where TEntidade : class
        where TIndicador : Enum, IComparable
    {
        public string Nome { get; set; }
        public int Indicador { get; set; }

        protected TypeSafeEnum()
        {
        }

        protected TypeSafeEnum(int indicador, string nome)
        {
            Indicador = (int)indicador;
            Nome = nome;
        }

        public override string ToString()
        {
            return Nome;
        }

        public static IEnumerable<TEntidade> ObtenhaTodos()
        {
            return typeof(TEntidade).GetProperties(BindingFlags.Public | BindingFlags.Static)
                .Select(x => x.GetValue(typeof(TEntidade), null) as TEntidade);
        }

        public static List<TEntidade> ObtenhaLista()
        {
            return ObtenhaTodos().ToList();
        }

        //public override bool Equals(TEntidade outro)
        //{
        //    var outroEnumerador = outro as TypeSafeEnum<TEntidade, TIndicador>;
        //    if (outro == null)
        //    {
        //        return false;
        //    }

        //    var tipoEhIgual = this.GetType().Equals(outroEnumerador.GetType());
        //    var valorEhIgual = this.Indicador.Equals(outroEnumerador.Indicador);

        //    return tipoEhIgual && valorEhIgual;
        //}

        public int CompareTo(TEntidade outro)
        {
            var outroEnumerador = outro as TypeSafeEnum<TEntidade, TIndicador>;

            return this.Indicador.CompareTo(outroEnumerador.Indicador);
        }
    }
}
