using GS.GestaoEmpresa.Solucao.Negocio.Atributos;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GS.GestaoEmpresa.Solucao.Persistencia.BancoDeDados;
using GS.GestaoEmpresa.Solucao.UI;
using Raven.Client.Documents;
using Raven.Client.Documents.Operations;
using Raven.Client.Documents.Operations.Indexes;
using Raven.Client.ServerWide;
using Raven.Client.ServerWide.Operations;

namespace GS.GestaoEmpresa.Solucao.Utilitarios
{
    public static class GSExtensions
    {
        public static IList<string> ObtenhaLabels(this IList<PropertyInfo> listaDePropriedades)
        {
            return listaDePropriedades.Select(x => ((Identificacao)x.GetCustomAttributes(typeof(Identificacao), false).FirstOrDefault()).Descricao).ToList();
        }

        public static Dictionary<PropertyInfo, string> ObtenhaPropriedadesELabels(this IList<PropertyInfo> listaDePropriedades)
        {
            return listaDePropriedades.ToDictionary(x => x, x => ((Identificacao)x.GetCustomAttributes(typeof(Identificacao), false).FirstOrDefault()).Descricao);
        }

        public static string FormateParaStringMoedaReal(this decimal valor)
        {
            return string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", valor).Replace("R$ ", string.Empty);
        }

        public static bool ConvertaValorBooleano(this string valorNoBanco)
        {
            return valorNoBanco == "S" ? true : false;
        }

        public static string ConvertaValorBooleano(this bool booleano)
        {
            return booleano ? "S" : "N";
        }

        public static string ConvertaValorBooleanoDescritivo(this bool booleano)
        {
            return booleano ? "Sim" : "Não";
        }

        public static bool IsNumericType(this Type o)
        {
            switch (Type.GetTypeCode(o))
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                //case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    return true;
                default:
                    return false;
            }
        }

        public static bool IsNumericTypeExceptDecimal(this Type o)
        {
            switch (Type.GetTypeCode(o))
            {
                case TypeCode.Byte:
                case TypeCode.SByte:
                case TypeCode.UInt16:
                case TypeCode.UInt32:
                case TypeCode.UInt64:
                case TypeCode.Int16:
                case TypeCode.Int32:
                case TypeCode.Int64:
                //case TypeCode.Decimal:
                case TypeCode.Double:
                case TypeCode.Single:
                    return true;
                default:
                    return false;
            }
        }

        public static DateTime ConvertaParaDateTime(this string dado, EnumFormatacaoDateTime formatacaoDateTime, char separadorData, char separadorHora = ':')
        {
            string formato = null;
            switch (formatacaoDateTime)
            {
                case EnumFormatacaoDateTime.DD_MM_YYYY:
                    formato = $@"dd{separadorData}MM{separadorData}yyyy";
                    break;
                case EnumFormatacaoDateTime.MM_DD_YYYY:
                    formato = $@"mm{separadorData}DD{separadorData}yyyy";
                    break;
                case EnumFormatacaoDateTime.DD_MM_YYYY_HH_MM_SS:
                    formato = $@"dd{separadorData}MM{separadorData}yyyy HH{separadorHora}mm{separadorHora}ss";
                    break;
            }

            return DateTime.ParseExact(dado, formato, CultureInfo.InvariantCulture);
        }

        public static int? EncontreIndiceNaGrid(this DataGridView dataGrid, string coluna, string valorNaColuna)
        {
            var quantidade = dataGrid.RowCount;
            for (int i = 0; i < quantidade; i++)
            {
                if (dataGrid[coluna, i].Value.ToString().Trim() == valorNaColuna.Trim())
                    return i;
            }

            return null;
        }

        public static MemberInfo GetPropertyFromExpression(this LambdaExpression GetPropertyLambda)
        {
            MemberExpression Exp = null;

            //this line is necessary, because sometimes the expression comes in as Convert(originalexpression)
            if (GetPropertyLambda.Body is UnaryExpression)
            {
                var UnExp = (UnaryExpression)GetPropertyLambda.Body;
                if (UnExp.Operand is MemberExpression)
                {
                    Exp = (MemberExpression)UnExp.Operand;
                }
                else
                    throw new ArgumentException();
            }
            else if (GetPropertyLambda.Body is MemberExpression)
            {
                Exp = (MemberExpression)GetPropertyLambda.Body;
            }
            else
            {
                throw new ArgumentException();
            }

            return Exp.Member;
        }

        public static IList<PropertyInfo> EncontrePropriedadesMarcadasComAtributo<T>(this Type tipo)
            where T : Attribute
        {
            return tipo.GetProperties().Where(x => Attribute.IsDefined(x, typeof(T))).ToList();
        }

        public static void Focar(this IView view, Form invoker)
        {
            var form = (view as Form);

            invoker.Invoke((MethodInvoker)delegate
           {
               form.TopMost = true;
                form.Visible = true;
                form.WindowState = FormWindowState.Normal;
                form.Show();
                form.Activate();
                form.Select();
                form.Focus();
            });
        }
        
    }
    
}
