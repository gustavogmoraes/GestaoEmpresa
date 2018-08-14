using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Reflection;
using System.Collections;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos.Atributos;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores;
using System.Windows.Forms;

namespace GS.GestaoEmpresa.Solucao.Utilitarios
{
	public static class GSUtilitarios
	{
        #region Propriedades

        public static readonly Dictionary<Type, string> DicionarioTipoDadosParaBancoDeDados;

        public static readonly CultureInfo Cultura = new CultureInfo("pt-BR");

        #endregion


        #region BancoDeDados

        static GSUtilitarios()
        {
            DicionarioTipoDadosParaBancoDeDados = new Dictionary<Type, string>()
            {
                {typeof(string), "NVARCHAR"},
                {typeof(int), "INT"},
                {typeof(DateTime), "DATETIME2"},
                {typeof(decimal), "DECIMAL"},
                {typeof(Guid), "NVARCHAR" }
            };
        }

        #endregion


        #region Utilitários p/ Banco de Dados

        /// <summary>
        /// Converte o tipo de dado para uma string informando o tipo de dado equivalente para o SGBD.
        /// </summary>
        /// <param name="tipo">Tipo de dado a ser convertido</param>
        /// <returns>Retorna uma string com o tipo de dado equivalente no SGBD.</returns>
        public static string ConvertaTipoDadosAplicacaoBanco(Type tipoDadoAplicacao)
        {
            if (ChequeSeTipoEhBuiltIn(tipoDadoAplicacao))
                return DicionarioTipoDadosParaBancoDeDados[tipoDadoAplicacao];

            return ConvertaTipoDadosAplicacaoBanco(EncontrePropriedadeChaveDoTipo(tipoDadoAplicacao).PropertyType);
        }

        /// <summary>
        /// Converte o nome do tipo de dado do SGBD para um tipo equivalente no sistema.
        /// </summary>
        /// <param name="tipoDadoBanco">Nome do tipo de dado a ser convertido</param>
        /// <returns>Retorna um tipo de dado equivalente no sistema.</returns>
        public static Type ConvertaTipoDadosAplicacaoBanco(string tipoDadoBanco)
        {
            return DicionarioTipoDadosParaBancoDeDados.FirstOrDefault(x => x.Value == tipoDadoBanco).Key;
        }

        public static bool ConvertaValorBooleano(string valorNoBanco)
        {
            return valorNoBanco == "S" ? true : false;
        }

        public static string ConvertaValorBooleano(bool booleano)
        {
            return booleano ? "S" : "N";
        }

        public static string ConvertaEnumeradorParaString(EnumTipoDeInteracao tipoDeInteracao)
        {
            return Cultura.TextInfo.ToTitleCase(tipoDeInteracao.ToString().ToLowerInvariant()
                                                                          .Replace("_", " "))
                                   .Replace(" De ", " de ");
        }

        #endregion


        #region Utilitários p/ Criação de Objetos

        /// <summary>
        /// Cria uma lista do tipo passado
        /// </summary>
        /// <param name="tipo">Tipo dos elementos da lista</param>
        /// <returns>Retorna uma lista do tipo passado.</returns>
        public static IList CrieLista(Type tipo)
        {
            Type tipoGenericoLista = typeof(List<>).MakeGenericType(tipo);

            return (IList)Activator.CreateInstance(tipoGenericoLista);
        }

        #endregion


        #region Utilitários p/ Criptografia

        /// <summary>
        /// Aplica criptografia básica, baseada no MAC e Clock da máquina local.
        /// </summary>
        /// <param name="dado">Dado em string a ser criptografado</param>
        /// <param name="tipoCriptografia">Informação para "criptografar" ou "descriptografar"</param>
        /// <returns>Retorna o dado criptografado no escopo da máquina local.</returns>
        public static string ApliqueCriptografiaBasica(string dado, EnumCriptografiaBasica tipoCriptografia)
        {
            if (tipoCriptografia == EnumCriptografiaBasica.Encriptar)
            {
                dado = Convert.ToBase64String(ProtectedData.Protect(Encoding.Unicode.GetBytes(dado), null, DataProtectionScope.LocalMachine));
            }
            if (tipoCriptografia == EnumCriptografiaBasica.Desencriptar)
            {
                dado = Encoding.Unicode.GetString(ProtectedData.Unprotect(Convert.FromBase64String(dado), null, DataProtectionScope.LocalMachine));
            }

            return dado;
        }

        #endregion


        #region Utilitários p/ Formatação

        /// <summary>
        /// Converte o DateTime passado para uma string compatível para ser inserida no SGBD.
        /// </summary>
        /// <param name="data">DateTime a ser convertido</param>
        /// <returns>Retorna uma string com o DateTime formatado em "yyyy-MM-dd HH:mm:SS".</returns>
        public static string FormateDateTimePtBrParaBD(DateTime data)
        {
            return String.Format("{0}-{1}-{2} {3}:{4}:{5}",
                                 data.Year,
                                 data.Month.ToString().PadLeft(2, '0'), //Garante que terá o zero à esquerda
                                 data.Day.ToString().PadLeft(2, '0'),
                                 data.Hour.ToString().PadLeft(2, '0'),
                                 data.Minute.ToString().PadLeft(2, '0'),
                                 data.Second.ToString().PadLeft(2, '0'));
        }

        /// <summary>
        /// Converte a string passada no formato "yyyy-MM-dd HH:mm:SS" para um DateTime.
        /// </summary>
        /// <param name="dataBD">String a ser convertida</param>
        /// <returns>Retorna um DateTime com as informações passadas na string.</returns>
        public static DateTime FormateDateTimePtBrParaBD(string dataBD)
        {
            DateTime data = DateTime.ParseExact(dataBD, "yyyy-MM-dd HH:mm:SS", new CultureInfo("pt-BR"));

            return data;
        }

        public static string FormateDecimalParaStringMoedaReal(decimal valor)
        {
            return string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", valor).Replace("R$ ", String.Empty);
        }
        #endregion


        #region Utilitários p/ Manipulação de Strings

        /// <summary>
        /// Obtem o valor(em string) dentro de outras duas strings.
        /// </summary>
        /// <param name="dado">String total</param>
        /// <param name="primeiraString">Primeira string delimitadora</param>
        /// <param name="ultimaString">Segunda string delimitadora</param>
        /// <returns>Retorna o dado obtido.</returns>
        public static string ObtenhaValorEntreStrings(string dado, string primeiraString, string ultimaString)
        {
            string retorno;

            int posicao1 = dado.IndexOf(primeiraString) + primeiraString.Length;
            int posicao2 = dado.IndexOf(ultimaString);

            retorno = dado.Substring(posicao1, posicao2 - posicao1);

            return retorno;
        }

        #endregion


        #region Utilitários p/ Propriedades

        /// <summary>
		/// Encontra a propriedade que é chave no tipo/objeto passado.
		/// </summary>
		/// <param name="objeto">Objeto de dado a ser avaliado</param>
		/// <returns>Retorna o tipo de dado da propriedade marcada com o atributo [Chave].</returns>
		public static PropertyInfo EncontrePropriedadeChaveDoObjeto(Object objeto)
        {
            var propriedadeChave = objeto.GetType().GetProperties()
                                         .Where(x => Attribute.IsDefined(x, typeof(BancoDeDados)))
                                         .FirstOrDefault();
            
            if(propriedadeChave != null)
            {
                var atributo = (BancoDeDados)propriedadeChave.GetCustomAttribute(typeof(BancoDeDados));

                if (atributo.EhChave)
                    return propriedadeChave;
            }

            return null;
        }

        /// <summary>
		/// Encontra a propriedade que é chave no tipo/objeto passado.
		/// </summary>
		/// <param name="tipo">Tipo de dado a ser avaliado</param>
		/// <returns>Retorna o tipo de dado da propriedade marcada com o atributo [Chave].</returns>
		public static PropertyInfo EncontrePropriedadeChaveDoTipo(Type tipo)
        {
            var propriedadeChave = tipo.GetProperties()
                                       .Where(x => Attribute.IsDefined(x, typeof(BancoDeDados)))
                                       .FirstOrDefault();

            if (propriedadeChave != null)
            {
                var atributo = (BancoDeDados)propriedadeChave.GetCustomAttribute(typeof(BancoDeDados));

                if (atributo.EhChave)
                    return propriedadeChave;
            }

            return null;
        }

        public static string FormateDecimalParaMoeda(decimal precoDeVenda)
        {
            var cultura = new CultureInfo("pt-BR");

            return string.Format(cultura, "{0:C}", precoDeVenda).Remove(0, 2);
        }

        public static List<PropertyInfo> EncontrePropriedadeMarcadaComAtributo(Type tipo, Type tipoDoAtributo)
        {
            return tipo.GetProperties()
                       .Where(x => Attribute.IsDefined(x, tipoDoAtributo)).ToList();
        }

        #endregion


        #region Utilitários p/ Tipos

        /// <summary>
		/// Obtem o tipo da lista.
		/// </summary>
		/// <param name="lista">Lista</param>
		/// <returns>Retorna o tipo da lista.</returns>
		public static Type ObtenhaTipoLista<T>(List<T> lista)
        {
            return typeof(T);
        }

        /// <summary>
        /// Obtem o tipo da lista.
        /// </summary>
        /// <param name="lista">Lista</param>
        /// <returns>Retorna o tipo da lista.</returns>
        public static Type ObtenhaTipoListaPropriedade(PropertyInfo propriedade)
        {
            //return propriedade.PropertyType.GenericTypeArguments[0]; --> Esse também funciona, dá na mesma, doido

            return propriedade.PropertyType.GetProperty("Item").PropertyType;
        }

        /// <summary>
        /// Obtem o tipo de um tipo enumerado
        /// </summary>
        /// <param name="Enumeravel">Tipo enumerado</param>
        /// <returns>Retorna o tipo do tipo enumerado.</returns>
        public static Type ObtenhaTipoEnumerado<T>(IEnumerable<T> Enumeravel)
        {
            return typeof(T);
        }
		
		/// <summary>
        /// Verifica se o tipo de dado passado está marcado com o atributo "EntidadeComPortador".
        /// </summary>
        /// <returns>Retorna um booleano da validação feita.</returns>
        public static EnumTipoDeEntidadeRelacional ObtenhaTipoDeEntidadeRelacional(PropertyInfo propriedade)
        {
            if(Attribute.IsDefined(propriedade, typeof(BancoDeDados)))
            {
                var atributo = (BancoDeDados)Attribute.GetCustomAttribute(propriedade, typeof(BancoDeDados));

                return atributo.TipoDeRelacionamento;
            }

            return EnumTipoDeEntidadeRelacional.UmParaUm;
        }

        #endregion


        #region Utilitários p/ Verificação

        /// <summary>
        /// Verifica se o tipo passado é "BuiltIn", em outras palavras, se ele é "primitivo" no .NET, não foi criado pelo programador.
        /// </summary>
        /// <param name="tipo">Tipo de dado a ser avaliado</param>
        /// <returns>Retorna um valor booleano respondendo se o tipo é "BuiltIn."</returns>
        public static bool ChequeSeTipoEhBuiltIn(Type tipo)
        {
            if (tipo.Namespace == "System" || tipo.Namespace.StartsWith("System") || tipo.Module.ScopeName == "CommonLanguageRuntimeLibrary")
                return true;
            else
                return false;
        }

        /// <summary>
		/// Verifica se o tipo de dado passado é uma lista de qualquer tipo.
		/// </summary>
		/// <param name="tipo">Tipo de dado a ser avaliado</param>
		/// <returns>Retorna um booleano da validação feita.</returns>
		public static bool VerifiqueSeTipoEhLista(Type tipo)
        {
            return (tipo.IsGenericType && (tipo.GetGenericTypeDefinition() == typeof(List<>)));
        }

        /// <summary>
        /// Verifica se o tipo de dado passado está marcado com o atributo "EntidadeComPortador".
        /// </summary>
        /// <returns>Retorna um booleano da validação feita.</returns>
        public static bool VerifiqueSePropriedadeEhEntidadeRelacionalUmParaMuitos(PropertyInfo propriedade)
        {
            if(Attribute.IsDefined(propriedade, typeof(BancoDeDados)))
            {
                var atributo = (BancoDeDados)Attribute.GetCustomAttribute(propriedade, typeof(BancoDeDados));

                return (atributo.TipoDeRelacionamento == EnumTipoDeEntidadeRelacional.UmParaMuitos);
            }

            return false;
        }

        public static bool EhDigitoOuPonto(char caracter)
        {
            if (char.IsDigit(caracter) || char.IsPunctuation(caracter))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        #endregion


        #region TextBox Monetaria

        public static void AjusteTextBoxMonetaria(ref TextBox textBox)
        {
            if (!textBox.Text.All(x => EhDigitoOuPonto(x)))
            {
                textBox.Text = string.Empty;
                return;
            }

            string numero = string.Empty;
            double valor = 0;

            try
            {
                numero = textBox.Text.Replace(",", string.Empty)
                                     .Replace(".", string.Empty);

                if (numero == string.Empty)
                {
                    return;
                }

                numero.PadLeft(3, '0');

                if (numero.Length > 3 && numero.Substring(0, 1) == "0")
                {
                    numero = numero.Substring(1, numero.Length - 1);
                }

                valor = Convert.ToDouble(numero) / 100;
                textBox.Text = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:N}", valor);
                textBox.SelectionStart = textBox.Text.Length;
            }
            catch (Exception)
            {
                throw new Exception("Ocorreu um erro na formatação monetária.");
            }
        }

        #endregion


        //Todos comentados, ainda pensando se vou usar
        #region Multivalor

        /// <summary>
        /// Verifica se o dado é Multivalor(salva multiplos dados na mesma tupla num formato personalizado).
        /// </summary>
        /// <param name="dado">Dado(em string) a ser avaliado.</param>
        /// <returns>Retorna um booleano validando a informação.</returns>
        public static bool VerifiqueSeDadoEhMultivalor(string dado)
        {
            if (dado.Trim().StartsWith("Multivalor("))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Verifica se a propriedade é Multivalor(marcada com o atributo [Multivalor]).
        /// A nível de banco de dados, ser Multivalor significa que salva multiplos dados na mesma tupla num formato personalizado)
        /// </summary>
        /// <param name="propriedade">Propriedade a ser avaliada.</param>
        /// <returns>Retorna um booleano validando a informação.</returns>
        public static bool VerifiqueSePropriedadeEhMultivalor(PropertyInfo propriedade)
        {
            return Attribute.IsDefined(propriedade, typeof(Multivalor));
        }

        /// <summary>
        /// Converte dado (em string) Multivalor numa lista de dados específica para aquele valor.
        /// </summary>
        /// <param name="dado">Dado(em string) a ser convertido.</param>
        /// <returns>Retorna uma lista dos dados da string Multivalor</returns>
        public static List<dynamic> ConvertaDadoMultivalorLista(string dado)
        {
            const string NAMESPACE_OBJETOS_CONCRETOS = "GestaoEmpresa.GS.GestaoEmpresa.GS.GestaoEmpresa.Negocio.Objetos.ObjetosConcretos";

            var nomeTipoMultivalor = ObtenhaValorEntreStrings(dado, "Multivalor(", ")");
            Object tipoMultivalor = Activator.CreateInstance(null,
                                                             NAMESPACE_OBJETOS_CONCRETOS + nomeTipoMultivalor).Unwrap();
            var construtor = tipoMultivalor.GetType().GetConstructor(new Type[] { typeof(string) });

            var listaMultivalor = new List<dynamic>();
            var valores = ObtenhaValorEntreStrings(dado, "){", "}").Split('|');

            foreach (var valor in valores)
            {
                var parametros = valor.Split('#');
                listaMultivalor.Add(construtor.Invoke(tipoMultivalor, parametros));
            }

            return listaMultivalor;
        }

        //public static string ConvertaDadoMultivalorLista(string dado, bool semLista)
        //{
        //	const string NAMESPACE_OBJETOS_CONCRETOS = "GestaoEmpresa.GS.GestaoEmpresa.GS.GestaoEmpresa.Negocio.Objetos.ObjetosConcretos";

        //	var nomeTipoMultivalor = ObtenhaValorEntreStrings(dado, "MultivalorSemLista(", ")");
        //	Object tipoMultivalor = Activator.CreateInstance(null,
        //													 NAMESPACE_OBJETOS_CONCRETOS + nomeTipoMultivalor).Unwrap();
        //	var construtor = tipoMultivalor.GetType().GetConstructor(new Type[] { typeof(string) });

        //	var listaMultivalor = new List<dynamic>();
        //	var valores = ObtenhaValorEntreStrings(dado, "){", "}").Split('|');

        //	string[] propriedades;
        //	foreach (var valor in valores)
        //	{
        //		propriedades = valor.Split('#');
        //	}

        //	valor = tipoChave.GetMethod("Parse", new Type[] { typeof(string) })
        //								 .Invoke(null, new object[] { dado.ToString() });

        //	Object servicoMapeadorPropriedadeComplexa = Activator.CreateInstance(null, "GestaoEmpresa.GS.GestaoEmpresa.GS.GestaoEmpresa.ServicoMapeador.ServicosMapeadores.ServicosMapeadoresConcretos.Mapeador" + propriedade.Name).Unwrap();

        //	valor = servicoMapeadorPropriedadeComplexa.GetType()
        //											  .GetMethod("Consulte", new Type[] { tipoChave })
        //											  .Invoke(servicoMapeadorPropriedadeComplexa, propriedades);
        //}

        /// <summary>
        /// Converte lista Multivalor para uma string Multivalor.
        /// </summary>
        /// <param name="listaMultivalor">Lista a ser convertida.</param>
        /// <returns>Retorna uma string da lista lista Multivalor</returns>
        //public static string ConvertaDadoMultivalorLista(List<Object> listaMultivalor)
        //{
        //	var tipoMultivalor = listaMultivalor.FirstOrDefault().GetType();
        //	string valoresInsercaoMultivalor = string.Empty;

        //	foreach (var valor in listaMultivalor)
        //	{
        //		foreach (var propriedade in valor.GetType().GetProperties())
        //		{
        //			valoresInsercaoMultivalor += propriedade.GetValue(valor, null).ToString() + "#";
        //		}

        //		valoresInsercaoMultivalor += "|";
        //	}

        //	string retorno = string.Format("Multivalor({0}{{1}}",
        //								   tipoMultivalor.Name.ToString(),
        //								   valoresInsercaoMultivalor);

        //	return retorno;
        //}

        #endregion

    }
}
