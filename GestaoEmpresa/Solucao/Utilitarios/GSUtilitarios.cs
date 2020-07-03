using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Reflection;
using System.Collections;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns;
using GS.GestaoEmpresa.Solucao.Negocio.Atributos;

namespace GS.GestaoEmpresa.Solucao.Utilitarios
{
	public static class GSUtilitarios
	{
        #region Propriedades

        public static readonly Dictionary<Type, string> DicionarioTipoDadosParaBancoDeDados;

        public static readonly CultureInfo Cultura = new CultureInfo("pt-BR");

        #endregion

        #region Números

        public static List<int> EncontreInteirosFaltandoEmUmaSequencia(this IEnumerable<int> sequencia)
        {
            var sequenciaEnumerada = sequencia.ToList();

            const int menorValor = 1;
            var maiorValor = sequenciaEnumerada.Max();
                
            var serie = new HashSet<int>(Enumerable.Range(menorValor, maiorValor));
            serie.ExceptWith(sequenciaEnumerada);

            return serie.OrderBy(x => x).ToList();
        }

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
	
	
	// Obtém o Type dos Itens de um GenericType
	//var tipoDosElementosDaLista = propriedade.PropertyType.GetGenericArguments().SingleOrDefault();

	//// Obtém o Type através da instância de um GenericType
	//var tipoGenerico = propriedade.PropertyType;
	//var instanciaDoTipoGenerico = Activator.CreateInstance(tipoGenerico);
	//var tipoDosElementosDoTipoGenerico = ((IList)instanciaDoTipoGenerico).GetCollectionElementType();
	
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
        public static string ApliqueCriptografiaBasica(this string dado, EnumCriptografiaBasica tipoCriptografia)
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

        public static string FormateDecimalParaStringMoedaReal(decimal valor, bool castToEmptyIf0 = false)
        {
            if (castToEmptyIf0 && valor == 0)
            {
                return string.Empty;
            }

            return string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", Math.Round(valor, 2)).Replace("R$ ", String.Empty);
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
                                         .Where(x => Attribute.IsDefined(x, typeof(PropriedadeBD)))
                                         .FirstOrDefault();
            
            if(propriedadeChave != null)
            {
                var atributo = (PropriedadeBD)propriedadeChave.GetCustomAttribute(typeof(PropriedadeBD));

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
                                       .Where(x => Attribute.IsDefined(x, typeof(PropriedadeBD)))
                                       .FirstOrDefault();

            if (propriedadeChave != null)
            {
                var atributo = (PropriedadeBD)propriedadeChave.GetCustomAttribute(typeof(PropriedadeBD));

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
            return tipo.GetProperties().Where(x => Attribute.IsDefined(x, tipoDoAtributo)).ToList();
        }

        #endregion


        #region Utilitários p/ Tipos

        /// <summary>
		/// Obtem o tipo da lista.
		/// </summary>
		/// <param name="lista">Lista</param>
		/// <returns>Retorna o tipo da lista.</returns>
		public static Type ObtenhaTipoLista(IList lista)
        {
            return lista.GetType().GetProperty("Item").PropertyType;
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
            if(Attribute.IsDefined(propriedade, typeof(PropriedadeBD)))
            {
                var atributo = (PropriedadeBD)Attribute.GetCustomAttribute(propriedade, typeof(PropriedadeBD));

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
            if(Attribute.IsDefined(propriedade, typeof(PropriedadeBD)))
            {
                var atributo = (PropriedadeBD)Attribute.GetCustomAttribute(propriedade, typeof(PropriedadeBD));

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


        #region Utilitários p/ rede

        public static string ObtenhaIPLocal()
        {
            using (var socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                var ipLocal = string.Empty;
                try
                {
                    socket.Connect("8.8.8.8", 65530);
                    IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                    ipLocal = endPoint.Address.ToString();
                }
                catch
                {
                    ipLocal = "Erro ao obter...";
                }

                return ipLocal;
            }
        }

        #endregion

        public static DateTime ObtenhaDateTimeCompletoDePickers(
            DateTimePicker dateDataInicio, DateTimePicker dateHoraInicio)
        {
            var dia = dateDataInicio.Value.Day;
            var mes = dateDataInicio.Value.Month;
            var ano = dateDataInicio.Value.Year;

            var hora = dateHoraInicio.Value.Hour;
            var minuto = dateHoraInicio.Value.Minute;
            var segundo = dateHoraInicio.Value.Second;

            return new DateTime(ano, mes, dia, hora, minuto, segundo);
        }

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

	    public static IEnumerable<Type> GetAllTypesImplementingOpenGenericType(Type openGenericType, Assembly assembly)
	    {
	        return from x in assembly.GetTypes()
	            from z in x.GetInterfaces()
	            let y = x.BaseType
	            where
	                (y != null && y.IsGenericType &&
	                 openGenericType.IsAssignableFrom(y.GetGenericTypeDefinition())) ||
	                (z.IsGenericType &&
	                 openGenericType.IsAssignableFrom(z.GetGenericTypeDefinition()))
	            select x;
	    }

        public static IEnumerable<Type> GetTypesThatImplementsInteface(Type typeOfInterface)
	    {
	        var types = AppDomain.CurrentDomain.GetAssemblies()
	                             .SelectMany(s => s.GetTypes())
	                             .Where(p => typeOfInterface.IsAssignableFrom(p));

	        return types;
	    }
    }
}
