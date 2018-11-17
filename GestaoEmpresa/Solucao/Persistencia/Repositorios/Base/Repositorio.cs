using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using GS.GestaoEmpresa.Solucao.Persistencia.BancoDeDados;
using GS.GestaoEmpresa.Solucao.Persistencia.Mapeamentos.Base;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Seguros.Conceito;
using GS.GestaoEmpresa.Solucao.Negocio.Interfaces;

namespace GS.GestaoEmpresa.Solucao.Persistencia.Repositorios.Base
{
    public abstract class Repositorio<TConceito, TMapeamento> : BaseRepositorios<TConceito, TMapeamento>
        where TConceito : class, new()
        where TMapeamento : MapeamentoDeObjeto<TConceito>
    {
        #region Privado

        protected virtual string ObtenhaValoresAtualizacao(ref TConceito objeto)
        {
            var retorno = "SET ";
            foreach (var mapeamento in Mapeamento.MapeamentoDePropriedades)
            {
                if (mapeamento != null)
                {
                    var valor = mapeamento.Propriedade.GetValue(objeto, null);

                    retorno +=
                        string.Format(
                            "{0} = {1}, ",
                            mapeamento.Coluna,
                            EntreAspas(valor.GetType())
                                ? "'" + valor + "'"
                                : valor);
                }
            }

            var indice = retorno.Length;
            retorno = retorno.Remove(indice - 2);

            return retorno;
        }

        private static IEnumerable<object> RealizeCastingDeObjetoParaEnumeravelDeObjetos(object objeto)
        {
            var enumeravel = (IEnumerable)objeto;
            var enumeravelDeObjetos = enumeravel.Cast<object>();

            return enumeravelDeObjetos;
        }

        #endregion

        #region Público

        public virtual void Insira(TConceito conceito)
        {
            SalveConceitosVinculados(conceito);

            var sql =
                $"INSERT INTO {Mapeamento.Tabela} ({Mapeamento.Colunas}) " +
                $"VALUES ({ObtenhaValoresInsercao(ref conceito)});";

            var persistencia = new GSBancoDeDados();
            persistencia.ExecuteComando(sql);
        }

        public virtual void Atualize(TConceito conceito)
        {
            SalveConceitosVinculados(conceito);

            var sql =
                $"UPDATE {Mapeamento.Tabela} " +
                $"{ObtenhaValoresAtualizacao(ref conceito)} " +
                $"WHERE CODIGO = {Convert.ToInt32(conceito.GetType().GetProperty("Codigo").GetValue(conceito, null))}";

            var persistencia = new GSBancoDeDados();
            persistencia.ExecuteComando(sql);
        }

        #endregion
    }
}
