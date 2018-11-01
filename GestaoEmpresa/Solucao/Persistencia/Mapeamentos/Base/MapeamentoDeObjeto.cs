using GS.GestaoEmpresa.Solucao.Persistencia.Repositorios.Base;
using GS.GestaoEmpresa.Solucao.Negocio.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace GS.GestaoEmpresa.Solucao.Persistencia.Mapeamentos.Base
{
    public abstract class MapeamentoDeObjeto<TObjeto>
        where TObjeto : class, new()
    {
        #region Públicos

        public string Tabela { get; protected set; }

        public string Colunas
        {
            get
            {
                var concatenacao = string.Join(", ", MapeamentoDePropriedades.Where(x => x.TipoDeMapeamento != EnumTipoDeMapeamento.CONTEM)
                    .Select(x => x.Coluna));
                return concatenacao;
            }
        }

        public string ObtenhaColunasComAlias(string alias)
        {
            return alias + Colunas.Replace(", ", ", " + alias + ".");
        }

        public List<MapeamentoDePropriedade> MapeamentoDePropriedades
        {
            get { return _mapeamentoDePropriedades ?? (_mapeamentoDePropriedades = new List<MapeamentoDePropriedade>()); }
        }

        public virtual TObjeto MonteConceito(ref DataTable tabela, int linha)
        {
            if (tabela == null)
            {
                return null;
            }

            var conceito = new TObjeto();

            foreach (var mapeamento in this.MapeamentoDePropriedades)
            {
                object valorColuna = null;

                if (mapeamento.TipoDeMapeamento != EnumTipoDeMapeamento.CONTEM)
                {
                    valorColuna = tabela.Rows[linha][mapeamento.Coluna];
                }

                var valor = new object();
                switch (mapeamento.TipoDeMapeamento)
                {
                    case EnumTipoDeMapeamento.MAPEIA:
                        if (valorColuna == null)
                        {
                            valor = null;
                            break;
                        }
                        valor = mapeamento.Propriedade.PropertyType == typeof(string)
                              ? valorColuna.ToString()
                              : mapeamento.Propriedade.PropertyType.GetMethod("Parse", new[] { typeof(string) }).Invoke(null, new object[] { valorColuna.ToString() });
                        break;

                    case EnumTipoDeMapeamento.REFERENCIA:
                        if (valorColuna == null)
                        {
                            valor = null;
                            break;
                        }

                        var tipoDaChave = mapeamento.MetodoParaObtencao.GetParameters().FirstOrDefault().ParameterType;
                        var chave = tipoDaChave.GetMethod("Parse", new Type[] { typeof(string) }).Invoke(null, new object[] { valorColuna.ToString() });

                        var instanciaDeRepositorio = Activator.CreateInstance(mapeamento.Repositorio);
                        valor = mapeamento.MetodoParaObtencao.Invoke(instanciaDeRepositorio, new object[] { chave });
                        break;

                    case EnumTipoDeMapeamento.CONTEM:
                        var parametrosPorReflexao = mapeamento.ParametrosParaObtencaoOuExclusao.Where(x => x.GetType().Name == "RuntimePropertyInfo");

                        foreach (var parametro in parametrosPorReflexao)
                        {
                            var mapeamentoDePropriedade = this.MapeamentoDePropriedades.Find(x => x.Propriedade == (parametro as PropertyInfo));
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

        #endregion

        #region Privados

        private Type _tipoObjeto = typeof(TObjeto);

        private List<MapeamentoDePropriedade> _mapeamentoDePropriedades { get; set; }

        protected void Mapeia(
            Expression<Func<TObjeto, object>> propriedade, string coluna)
        {
            var prop = (PropertyInfo)ExtraiaMembro(propriedade);
            MapeamentoDePropriedades.Add(
                new MapeamentoDePropriedade()
                {
                    Coluna = coluna,
                    Propriedade = prop,
                    TipoDeMapeamento = EnumTipoDeMapeamento.MAPEIA
                });
        }

        protected void Referencia(Expression<Func<TObjeto, object>> propriedade,
            string coluna,
            Type tipoDoRepositorio,
            Expression<Func<IRepositorio<IConceito>, object, object>> metodoDeObtencao)
        {
            var prop = (PropertyInfo)ExtraiaMembro(propriedade);
            var methObtencao = (MethodInfo)ExtraiaMethodFunc(metodoDeObtencao);
            var repositorio = tipoDoRepositorio;

            MapeamentoDePropriedades.Add(
                new MapeamentoDePropriedade()
                {
                    Coluna = coluna,
                    Propriedade = prop,
                    MetodoParaObtencao = methObtencao,
                    Repositorio = repositorio,
                    TipoDeMapeamento = EnumTipoDeMapeamento.REFERENCIA
                });
        }

        protected void Contem(
            Expression<Func<TObjeto, object>> propriedade,
            Type tipoDoRepositorio,
            Expression<Action<IRepositorioConceitoComPortador<object>, TObjeto>> metodoDeDefinicao,
            Expression<Func<IRepositorioConceitoComPortador<object>, TObjeto, object>> metodoDeObtencao,
            Expression<Action<IRepositorioConceitoComPortador<object>, TObjeto>> metodoDeExclusao)
        {
            var prop = (PropertyInfo)ExtraiaMembro(propriedade);
            var methObtencao = (MethodInfo)ExtraiaMethodFunc(metodoDeObtencao);
            var paramObtencao = ExtraiaParametrosFunc(metodoDeObtencao);
            var methDefinicao = (MethodInfo)ExtraiaMethodAction(metodoDeDefinicao);
            var methExclusao = (MethodInfo)ExtraiaMethodAction(metodoDeExclusao);
            var repositorio = (Type)ExtraiaRepositorioFunc(metodoDeObtencao);

            MapeamentoDePropriedades.Add(
                new MapeamentoDePropriedade()
                {
                    TipoDeMapeamento = EnumTipoDeMapeamento.CONTEM,
                    Propriedade = prop,
                    MetodoParaDefinicao = methDefinicao,
                    MetodoParaObtencao = methObtencao,
                    ParametrosParaObtencaoOuExclusao = paramObtencao,
                    MetodoParaExclusao = methExclusao,
                    Repositorio = repositorio
                });
        }

        #endregion

        #region Auxiliares

        private static object ExtraiaMembro(Expression<Func<TObjeto, object>> propriedade)
        {
            if (propriedade.Body is MemberExpression)
            {
                return ((MemberExpression)propriedade.Body).Member;
            }
            else
            {
                var operand = ((UnaryExpression)propriedade.Body).Operand;
                return ((MemberExpression)operand).Member;
            }
        }

        private static object ExtraiaMembro(Expression expression)
        {
            if (expression is MemberExpression)
            {
                return ((MemberExpression)expression).Member;
            }
            else
            {
                var operand = ((UnaryExpression)expression).Operand;
                return ((MemberExpression)operand).Member;
            }
        }

        private static object ExtraiaRepositorioFunc(
            Expression<Func<IRepositorioConceitoComPortador<object>, TObjeto, object>> metodo)
        {
            var operand = ((UnaryExpression)metodo.Body).Operand;
            return ((MethodCallExpression)operand).Object.Type;
        }

        private static object ExtraiaRepositorioFunc(
            Expression<Func<IRepositorio<IConceito>, object, object>> metodo)
        {
            var body = (MethodCallExpression)metodo.Body;
            return body.Object.Type;
        }

        private static object ExtraiaMethodFunc(
            Expression<Func<IRepositorio<IConceito>, object, object>> metodo)
        {
            return ((MethodCallExpression)metodo.Body).Method;
        }

        private static object ExtraiaMethodFunc(
            Expression<Func<IRepositorioConceitoComPortador<object>, TObjeto, object>> metodo)
        {
            var operand = ((UnaryExpression)metodo.Body).Operand;
            return ((MethodCallExpression)operand).Method;
        }

        private static object ExtraiaMethodAction(
            Expression<Action<IRepositorioConceitoComPortador<object>, TObjeto>> metodo)
        {
            return ((MethodCallExpression)metodo.Body).Method;
        }

        private static object[] ExtraiaParametrosFunc(
            Expression<Func<IRepositorioConceitoComPortador<object>, TObjeto, object>> metodo)
        {
            var operand = ((UnaryExpression)metodo.Body).Operand;
            var args = ((MethodCallExpression)operand).Arguments;

            var listaRetorno = new List<object>();
            listaRetorno.AddRange(args.Where(x => x.NodeType == ExpressionType.Constant)
                                      .Select(x => (x as ConstantExpression).Value));
            listaRetorno.AddRange(args.Where(x => x.NodeType != ExpressionType.Constant)
                                      .Select(x => (PropertyInfo)ExtraiaMembro(x)));

            return listaRetorno.ToArray();
        }

        #endregion
    }
}
