using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Seguros.Conceito;
using GS.GestaoEmpresa.Solucao.Negocio.Interfaces;
using GS.GestaoEmpresa.Solucao.Persistencia.BancoDeDados;
using GS.GestaoEmpresa.Solucao.Persistencia.Mapeamentos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GS.GestaoEmpresa.Solucao.Persistencia.Repositorios.Base
{
    public abstract class BaseRepositorios<TConceito, TMapeamento>
        where TConceito : class, new()
        where TMapeamento : MapeamentoDeObjeto<TConceito>
    {
        #region Privados

        private TMapeamento _mapeamento;
        protected TMapeamento Mapeamento
        {
            get { return _mapeamento ?? (_mapeamento = Activator.CreateInstance<TMapeamento>()); }
            private set { _mapeamento = value; }
        }

        protected bool EntreAspas(Type tipo)
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

        protected virtual string ObtenhaValoresInsercao(ref TConceito objeto)
        {
            var retorno = string.Empty;

            foreach (var mapeamento in Mapeamento.MapeamentoDePropriedades.Where(x => x.TipoDeMapeamento != EnumTipoDeMapeamento.CONTEM))
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
                        var chave = tipoDaChave.GetMethod("Parse", new Type[] { typeof(string) })
                                               .Invoke(null, new object[] { valor.GetType().GetProperty("Codigo").GetValue(valor, null).ToString() });

                        retorno += EntreAspas(tipoDaChave)
                            ? "'" + chave + "'"
                            : chave;
                        break;
                }
                retorno += ", ";
            }

            var indice = retorno.Length;
            retorno = retorno.Remove(indice - 2);

            return retorno;
        }

        protected virtual void SalveConceitosVinculados(TConceito conceito)
        {
            foreach (var mapeamento in Mapeamento.MapeamentoDePropriedades
                                                 .Where(x => x.TipoDeMapeamento == EnumTipoDeMapeamento.CONTEM &&
                            x.MetodoParaDefinicao.DeclaringType.Name.Contains("RepositorioConceitoComPortador")))
            {
                var repositorio = Activator.CreateInstance(mapeamento.Repositorio);
                var concept = mapeamento.ParametrosParaObtencaoOuExclusao.Where(x => x.GetType() == typeof(EnumConceitos))
                    .FirstOrDefault();
                var codigo = (conceito as IConceitoComCodigo).Codigo;
                var valor = mapeamento.Propriedade.GetValue(conceito, null);

                mapeamento.Repositorio.GetMethod("Salve").Invoke(
                    repositorio,
                    new object[]
                    {
                        concept,
                        codigo,
                        valor
                    });
            }
        }

        protected virtual void ExcluaConceitosVinculados(int codigo)
        {
            var conceito = Consulte(codigo);
            if (conceito == null)
            {
                return;
            }

            foreach (var mapeamento in Mapeamento.MapeamentoDePropriedades)
            {
                if (mapeamento.TipoDeMapeamento == EnumTipoDeMapeamento.CONTEM)
                {
                    var parametrosPorReflexao =
                        mapeamento.ParametrosParaObtencaoOuExclusao.Where(x => x.GetType().Name == "RuntimePropertyInfo");

                    foreach (var parametro in parametrosPorReflexao)
                    {
                        var mapeamentoDePropriedade =
                            Mapeamento.MapeamentoDePropriedades.Find(x => x.Propriedade == (parametro as PropertyInfo));
                        var novoParametro = mapeamentoDePropriedade.Propriedade.GetValue(conceito, null);

                        var listaDeParametros = mapeamento.ParametrosParaObtencaoOuExclusao.ToList();
                        listaDeParametros.Remove(parametro);
                        listaDeParametros.Add(novoParametro);

                        mapeamento.ParametrosParaObtencaoOuExclusao = listaDeParametros.ToArray();
                    }

                    var instanciaDeRepo = Activator.CreateInstance(mapeamento.Repositorio);
                    mapeamento.MetodoParaObtencao.Invoke(instanciaDeRepo, mapeamento.ParametrosParaObtencaoOuExclusao);
                }
            }
        }

        #endregion

        #region Publicos

        public virtual TConceito Consulte(int codigo)
        {
            var sql =
                $"SELECT {Mapeamento.Colunas} " +
                $"FROM {Mapeamento.Tabela} " +
                $"WHERE CODIGO = {codigo};";

            var persistencia = new GSBancoDeDados();
            var tabela = persistencia.ExecuteConsulta(sql);

            var conceito = Mapeamento.MonteConceito(ref tabela, 0);
            return conceito;
        }

        public virtual IList<TConceito> ConsulteTodos()
        {
            var sql =
                $"SELECT {Mapeamento.Colunas} " +
                $"FROM {Mapeamento.Tabela}";

            var persistencia = new GSBancoDeDados();

            var tabela = persistencia.ExecuteConsulta(sql);
            var contagem = tabela.Rows.Count;

            var lista = new List<TConceito>();
            for (int i = 0; i < contagem; i++)
            {
                lista.Add(Mapeamento.MonteConceito(ref tabela, i));
            }

            return lista;
        }

        public virtual void Exclua(int codigo)
        {
            ExcluaConceitosVinculados(codigo);

            var sql =
                $"DELETE FROM {Mapeamento.Tabela} " +
                $"WHERE CODIGO = {codigo}";

            using (var persistencia = new GSBancoDeDados())
            {
                persistencia.ExecuteComando(sql);
            }
        }

        public virtual int ObtenhaProximoCodigoDisponivel()
        {
            using (var GSBD = new GSBancoDeDados())
            {
                return GSBD.ObtenhaProximoCodigoDisponivel(Mapeamento.Tabela, "CODIGO");
            }
        }

        #endregion
    }
}
