﻿using GS.GestaoEmpresa.Solucao.Negocio.Atributos;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
    }
}