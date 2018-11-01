using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using GS.GestaoEmpresa.Solucao.Persistencia.BancoDeDados;
using GS.GestaoEmpresa.Solucao.Persistencia.Mapeamentos.Base;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Seguros.Conceito;

namespace GS.GestaoEmpresa.Solucao.Persistencia.Repositorios.Base
{
    public class RepositorioConceitoComPortador<TConceito, TMapeamento> : IRepositorioConceitoComPortador<TConceito>
        where TConceito : class, new()
        where TMapeamento : MapeamentoDeObjeto<TConceito>, new()
    {
        #region Público

        public virtual void Salve(Conceito conceito, int codigoPortador, IList<TConceito> listaDeConceito)
        {
            Exclua(conceito, codigoPortador);
            listaDeConceito.ToList().ForEach(x => Insira(conceito, codigoPortador, x));
        }

        public virtual IList<TConceito> Consulte(Conceito conceito, int codigoPortador)
        {
            var sql =
                string.Format(
                    "SELECT {0} " +
                    "FROM {1} " +
                    "WHERE CONCEITO = {2} " +
                    "   AND CODIGO_PORTADOR = {3}",
                    Mapeamento.Colunas,
                    Mapeamento.Tabela,
                    conceito.Indicador,
                    codigoPortador);

            var persistencia = new GSBancoDeDados();

            var tabela = persistencia.ExecuteConsulta(sql);
            var contagem = tabela.Rows.Count;

            var lista = new List<TConceito>();
            for (int i = 0; i < contagem; i++)
            {
                lista.Add(MonteConceito(ref tabela, i));
            }

            return lista;
        }

        public virtual void Exclua(Conceito conceito, int codigoPortador)
        {
            var sql =
                string.Format(
                    "DELETE FROM {0} " +
                    "WHERE CONCEITO = {1} " +
                    "   AND CODIGO_PORTADOR = {2};",
                    Mapeamento.Tabela,
                    conceito.Indicador,
                    codigoPortador);

            var persistencia = new GSBancoDeDados();
            persistencia.ExecuteComando(sql);
        }

        #endregion

        #region Privado

        private TMapeamento _mapeamento;
        protected TMapeamento Mapeamento
        {
            get { return _mapeamento ?? (_mapeamento = Activator.CreateInstance<TMapeamento>()); }
            private set { _mapeamento = value; }
        }

        private bool EntreAspas(Type tipo)
        {
            switch (Type.GetTypeCode(tipo))
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    return false;
                default:
                    return true;
            }
        }

        public virtual TConceito MonteConceito(ref DataTable tabela, int linha)
        {
            if (tabela == null)
            {
                return null;
            }

            var conceito = new TConceito();

            foreach (var mapeamento in Mapeamento.MapeamentoDePropriedades)
            {
                var valorColuna = tabela.Rows[linha][mapeamento.Coluna];
                var valor = new object();
                switch (mapeamento.TipoDeMapeamento)
                {
                    case EnumTipoDeMapeamento.MAPEIA:
                        if (valorColuna == null)
                        {
                            valor = null;
                            break;
                        }

                        if (mapeamento.Propriedade.PropertyType == typeof(bool))
                        {
                            valor = (string)valorColuna == "S"
                                  ? true
                                  : false;
                        }
                        else
                        {
                            valor = mapeamento.Propriedade.PropertyType == typeof(string)
                                  ? valorColuna.ToString()
                                  : mapeamento.Propriedade.PropertyType.GetMethod("Parse", new[] { typeof(string) }).Invoke(null, new object[] { valorColuna.ToString() });
                        }
                        break;

                    case EnumTipoDeMapeamento.REFERENCIA:
                        if (valorColuna == null)
                        {
                            valor = null;
                            break;
                        }

                        var tipoDaChave = mapeamento.MetodoParaObtencao.GetParameters().FirstOrDefault().GetType();
                        var chave = tipoDaChave.GetMethod("Parse").Invoke(null, new object[] { valorColuna.ToString() });

                        var instanciaDeRepositorio = Activator.CreateInstance(mapeamento.MetodoParaObtencao.DeclaringType);
                        valor = mapeamento.MetodoParaObtencao.Invoke(instanciaDeRepositorio, new object[] { chave });
                        break;

                    case EnumTipoDeMapeamento.CONTEM:
                        var parametrosPorReflexao = mapeamento.ParametrosParaObtencaoOuExclusao.Where(x => x.GetType().Name == "RuntimePropertyInfo");

                        foreach (var parametro in parametrosPorReflexao)
                        {
                            var mapeamentoDePropriedade = Mapeamento.MapeamentoDePropriedades.Find(x => x.Propriedade == (parametro as PropertyInfo));
                            var novoParametro = mapeamentoDePropriedade.Propriedade.GetValue(conceito, null);

                            var listaDeParametros = mapeamento.ParametrosParaObtencaoOuExclusao.ToList();
                            listaDeParametros.Remove(parametro);
                            listaDeParametros.Add(novoParametro);

                            mapeamento.ParametrosParaObtencaoOuExclusao = listaDeParametros.ToArray();
                        }

                        var instanciaDeRepo = Activator.CreateInstance(mapeamento.Repositorio);
                        valor = mapeamento.MetodoParaObtencao.Invoke(instanciaDeRepo, mapeamento.ParametrosParaObtencaoOuExclusao);
                        break;
                }

                mapeamento.Propriedade.SetValue(conceito, valor, null);
            }

            return conceito;
        }

        protected virtual string ObtenhaValoresInsercao(ref TConceito objeto)
        {
            var retorno = string.Empty;

            foreach (var mapeamento in Mapeamento.MapeamentoDePropriedades)
            {
                var valor = mapeamento.Propriedade.GetValue(objeto, null);
                switch (mapeamento.TipoDeMapeamento)
                {
                    case EnumTipoDeMapeamento.MAPEIA:
                        if (valor == null)
                        {
                            retorno += "NULL";
                            break;
                        }

                        if (valor.GetType() == typeof(bool))
                            valor = (bool)valor == true
                                  ? "S"
                                  : "N";

                        retorno += EntreAspas(valor.GetType())
                                 ? "'" + valor + "'"
                                 : valor;
                        break;

                    case EnumTipoDeMapeamento.REFERENCIA:
                        if (valor == null)
                        {
                            retorno += "NULL";
                            break;
                        }

                        var tipoDaChave = mapeamento.MetodoParaObtencao.GetParameters().FirstOrDefault().ParameterType;
                        var chave = tipoDaChave.GetMethod("Parse", new Type[] { typeof(string) }).Invoke(null, new object[] { valor.ToString() });

                        retorno += EntreAspas(tipoDaChave)
                                 ? "'" + chave + "'"
                                 : chave;
                        break;
                }
                retorno += ", ";
            }

            var indice = retorno.LastIndexOf(", ");

            return retorno.Remove(indice);
        }

        protected virtual void Insira(Conceito conceito, int codigoPortador, TConceito objeto)
        {
            var sql =
                string.Format(
                    "INSERT INTO {0} (CONCEITO, CODIGO_PORTADOR, {1}) " +
                    "VALUES ({2}, {3}, {4});",
                    Mapeamento.Tabela,
                    Mapeamento.Colunas,
                    conceito.Indicador,
                    codigoPortador,
                    ObtenhaValoresInsercao(ref objeto));

            var persistencia = new GSBancoDeDados();
            persistencia.ExecuteComando(sql);
        }

        #endregion
    }
}
