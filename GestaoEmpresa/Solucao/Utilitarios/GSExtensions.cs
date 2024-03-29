﻿using GS.GestaoEmpresa.Solucao.Negocio.Atributos;
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
using GS.GestaoEmpresa.Solucao.UI.Modulos.Estoque;
using LinqToExcel;
using MoreLinq;
using Newtonsoft.Json;
using Raven.Client.Documents;
using Raven.Client.Documents.Operations;
using Raven.Client.Documents.Operations.Indexes;
using Raven.Client.ServerWide;
using Raven.Client.ServerWide.Operations;
using Remotion.Mixins.Definitions;
using Raven.Client.Documents.Session;
using Raven.Client.Documents.Commands.Batches;
using MetroFramework.Controls;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using OfficeOpenXml;
using System.Data;

namespace GS.GestaoEmpresa.Solucao.Utilitarios
{
    public static class GSExtensions
    {
        public static bool IsEven(this int number)
        {
            return number % 2 == 0;
        }

        public static IList<string> ObtenhaLabels(this IList<PropertyInfo> listaDePropriedades)
        {
            return listaDePropriedades.Select(x => ((ExporterMetadata)x.GetCustomAttributes(typeof(ExporterMetadata), false).FirstOrDefault())?.Descricao).ToList();
        }

        public static Dictionary<PropertyInfo, string> ObtenhaPropriedadesELabels(this IList<PropertyInfo> listaDePropriedades)
        {
            return listaDePropriedades.ToDictionary(x => x, x => ((ExporterMetadata)x.GetCustomAttributes(typeof(ExporterMetadata), false).FirstOrDefault())?.Descricao);
        }

        public static string FormateParaStringMoedaReal(this decimal valor)
        {
            return string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", valor).Replace("R$ ", string.Empty);
        }

        public static bool ConvertaValorBooleano(this string valorNoBanco)
        {
            return valorNoBanco == "S";
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
                case TypeCode.Decimal:
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

        public static void Focar(this IView view, Form invoker = null, FormWindowState? state = null)
        {
            var form = (view as Form);

            if (invoker == null)
            {
                invoker = GerenciadorDeViews.ObtenhaPrincipal();
            }

            invoker.Invoke((MethodInvoker)delegate
            {
                form.Show();
                form.Visible = true;

                if(!state.HasValue)
                {
                    form.WindowState = FormWindowState.Normal;
                }
                else
                {
                    form.WindowState = state.GetValueOrDefault();
                }
                
                form.Activate();
                form.Select();
                form.Focus();
            });
        }

        public static object GetDefault(this Type type)
        {
            if (type.IsValueType)
            {
                return Activator.CreateInstance(type);
            }
            return null;
        }

        public static bool IsAny<T>(this T target, params T[] possibleValues)
        {
            return ((IEnumerable<T>)possibleValues).Contains<T>(target);
        }

        public static bool IsNotAny<T>(this T target, params T[] possibleValues)
        {
            return !target.IsAny<T>(possibleValues);
        }

        public static DateTime RemoveMs(this DateTime dt)
        {
            return new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second);
        }

        public static Expression<Func<T, bool>> AndAlso<T>(this Expression<Func<T, bool>> expression1, Expression<Func<T, bool>> expression2)
            where T : class
        {
            var body = Expression.AndAlso(expression1.Body, expression2.Body);
            var lambda = Expression.Lambda<Func<T, bool>>(body, expression1.Parameters);

            return lambda;
        }

        public static void SetTextWithoutFiringEvents(this TextBoxBase textBox, string text)
        {
            var view = (IView)textBox.FindForm();

            view.EstahRenderizando = true;

            textBox.Text = text;

            view.EstahRenderizando = false;
        }

        public static void SetTextWithoutFiringEvents(this MetroTextBox textBox, string text)
        {
            var view = (IView)textBox.FindForm();

            view.EstahRenderizando = true;

            textBox.Text = text;

            view.EstahRenderizando = false;
        }

        public static int GetDeterministicHashCode(this string str)
        {
            unchecked
            {
                int hash1 = (5381 << 16) + 5381;
                int hash2 = hash1;

                for (int i = 0; i < str.Length; i += 2)
                {
                    hash1 = ((hash1 << 5) + hash1) ^ str[i];
                    if (i == str.Length - 1)
                        break;
                    hash2 = ((hash2 << 5) + hash2) ^ str[i + 1];
                }

                return hash1 + (hash2 * 1566083941);
            }
        }

        private static readonly Dictionary<string, string> CustomTitleCaseReplacements = new Dictionary<string, string>
        {
            { "De", "de" },
            { "Do", "do" }
        };


        public static string ToCustomTitleCase(this string text)
        {
            var textInfo = CultureInfo.GetCultureInfo("pt-BR").TextInfo;

            text = text.Trim().ToLowerInvariant();
            var tempText = textInfo.ToTitleCase(text);

            CustomTitleCaseReplacements.ForEach(x => tempText = tempText.Replace(x.Key, x.Value));

            return tempText;
        }

        public static decimal ObtenhaMonetario(this string value)
        {
            if (value == "R$-" || value == "R$ -" || value.Contains("#")) return 0M;
            return Convert.ToDecimal(value.Replace("R$ ", string.Empty));
        }

        public static bool AnyPropertyIsNull(this object obj) =>
            obj.GetType().GetProperties().ToList().All(prop => string.IsNullOrEmpty(prop.GetValue(obj).ToString()));

        public static decimal ToDecimal(this string value) => Convert.ToDecimal(value);

        public static decimal DivideBy(this decimal value, decimal by) => value / by;

        /// <summary>
        /// a == b
        /// <para> c == ?</para>
        /// </summary>
        public static double RuleOfThree(double a, double b, double c)
        {
            return b * c / a;
        }

        public static int[] GetProgressRange(int total)
        {
            var values = new List<int>();
            var x = 0;
            for (int i = 1; i <= 100; i++)
            {
                var val = RuleOfThree(100, total, x += 1);
                values.Add(Convert.ToInt32(val));
            }

            return values.Distinct().ToArray();
        }

        public static int CountRows(this ExcelWorksheet sheet)
        {
            if (sheet.Dimension == null) { return 0; } // In case of a blank sheet
            var row = sheet.Dimension.End.Row;
            while (row >= 1)
            {
                var range = sheet.Cells[row, 1, row, sheet.Dimension.End.Column];
                if (range.Any(c => !string.IsNullOrEmpty(c.Text)))
                {
                    break;
                }
                row--;
            }

            return row;
        }

        public static bool IsNullOrEmpty(this string str) => string.IsNullOrEmpty(str);

        public static string ToMonetaryString(this decimal value) => GSUtilitarios.FormateDecimalParaStringMoedaReal(value);

        public static int ToInt32(this object value) => Convert.ToInt32(value);

        public static DateTime MergeValue(this DateTimePicker dtpDate, DateTimePicker dtpTime) => GSUtilitarios.ObtenhaDateTimeCompletoDePickers(dtpDate, dtpTime);

        public static void RemovePropertyFromDatabaseDocument(this IDocumentSession session, string documentId, string propertyToDelete)
        {
            session.Advanced.Defer(new PatchCommandData(
                id: documentId,
                changeVector: null,
                patch: new PatchRequest
                {
                    Script = $@"delete this.{propertyToDelete}"
                },
                patchIfMissing: null));
        }

        public static IEnumerable<bool> IterateUntilFalse(Func<bool> condition)
        {
            while (condition()) yield return true;
        }

        public static ParallelLoopResult ParallelWhile(Func<bool> condition, Action body, ParallelOptions parallelOptions = null) =>
            Parallel.ForEach(IterateUntilFalse(condition), parallelOptions ?? new ParallelOptions(), ignored => body());

        public static ParallelLoopResult ParallelWhile(bool condition, Action body, ParallelOptions parallelOptions = null) =>
            ParallelWhile(() => condition, body, parallelOptions);

        public static Dictionary<string, TValue> ToDictionary<TValue>(this object obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            var dictionary = JsonConvert.DeserializeObject<Dictionary<string, TValue>>(json);

            return dictionary;
        }

        public static void TriggerMonetaryFormat(this TextBox textBox)
        {
            if (!textBox.Text.All(GSUtilitarios.EhDigitoOuPonto))
            {
                textBox.Text = string.Empty;
                return;
            }

            try
            {
                var numero = textBox.Text
                    .Replace(",", string.Empty)
                    .Replace(".", string.Empty);

                if (numero == string.Empty)
                {
                    return;
                }

                numero = numero.PadLeft(3, '0');

                if (numero.Length > 3 && numero.Substring(0, 1) == "0")
                {
                    numero = numero.Substring(1, numero.Length - 1);
                }

                var valor = Convert.ToDouble(numero) / 100;
                textBox.Text = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:N}", valor);
                textBox.SelectionStart = textBox.Text.Length;
            }
            catch (Exception)
            {
                throw new Exception("Ocorreu um erro na formatação monetária.");
            }
        }

        public static void TriggerMonetaryFormat(this MetroTextBox textBox)
        {
            if (!textBox.Text.All(GSUtilitarios.EhDigitoOuPonto))
            {
                textBox.Text = string.Empty;
                return;
            }

            try
            {
                var numero = textBox.Text
                    .Replace(",", string.Empty)
                    .Replace(".", string.Empty);

                if (numero == string.Empty)
                {
                    return;
                }

                numero = numero.PadLeft(3, '0');

                if (numero.Length > 3 && numero.Substring(0, 1) == "0")
                {
                    numero = numero.Substring(1, numero.Length - 1);
                }

                var valor = Convert.ToDouble(numero) / 100;
                textBox.Text = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:N}", valor);
                textBox.SelectionStart = textBox.Text.Length;
            }
            catch (Exception)
            {
                throw new Exception("Ocorreu um erro na formatação monetária.");
            }
        }

        public static Stream ToStream(this Image image, ImageFormat imageFormat)
        {
            var stream = new MemoryStream();
            image.Save(stream, imageFormat);
            stream.Position = 0;
            return stream;
        }

        public static void SaveAs(this Stream stream, string path)
        {
            var directoryInfo = new DirectoryInfo(Path.GetDirectoryName(path));
            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }

            using (var outputFileStream = new FileStream(path, FileMode.OpenOrCreate))
            {
                stream.CopyTo(outputFileStream);
            }
        }

        public static byte[] ReadFully(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

        public static FileStream GetFileStream(this string filePath)
        {
            return File.OpenRead(filePath);
        }

        public static Point GetCenter(this Control control)
        {
            return new Point(control.Size.Width / 2, control.Size.Height / 2);
        }

        public static void LoadDataGrid<T>(
            this DataGridView dataGrid,
            IList<T> dataList,
            Expression<Func<T, object[]>> objectSelector,
            bool useRowColorIntercalation = true,
            Tuple<Color, Color> colors = null)
            where T : new()
        {
            dataGrid.Rows.Clear();

            var selector = objectSelector.Compile();
            foreach (T item in dataList)
            {
                var evenColor = colors?.Item1 ?? Color.White;
                var oddColor = colors?.Item2 ?? ColorTranslator.FromHtml("#e6f2ff");

                var rowIndex = dataGrid.Rows.Add(selector.Invoke(item));
                var color = useRowColorIntercalation
                    ? (rowIndex.IsEven()
                        ? evenColor
                        : oddColor)
                    : Color.White;

                //// https://www.w3schools.com/colors/colors_picker.asp

                //dataGrid.Rows[rowIndex].HeaderCell.Style.ForeColor = color;
                dataGrid.Rows[rowIndex].DefaultCellStyle.BackColor = color;
            }

            dataGrid.Refresh();
        }

        public static bool IsDigit(this char caracter)
        {
            if (char.IsDigit(caracter))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsNullable(this Type type)
        {
            var isIt = Nullable.GetUnderlyingType(type);

            return isIt != null;
        }

        public static string RemoveDiacritics(this string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }

        public static string GetValueOrNull(this string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return null;
            }

            return str;
        }

        public static Control GetControl(this Control control, string controlName)
        {
            return control.Controls.ContainsKey(controlName)
                ? control.Controls[controlName]
                : null;
        }

        public static bool IsFileLocked(FileInfo file)
        {
            try
            {
                using (FileStream stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    stream.Close();
                }
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }

            //file is not locked
            return false;
        }

        public static DataTable GetDataTableFromExcel(ExcelWorksheet ws, bool hasHeader = true)
        {
            var tbl = new DataTable();
            foreach (var firstRowCell in ws.Cells[1, 1, 1, ws.Dimension.End.Column])
            {
                tbl.Columns.Add(hasHeader ? firstRowCell.Text : string.Format("Column {0}", firstRowCell.Start.Column));
            }

            var startRow = hasHeader ? 2 : 1;
            for (int rowNum = startRow; rowNum <= ws.Dimension.End.Row; rowNum++)
            {
                var wsRow = ws.Cells[rowNum, 1, rowNum, ws.Dimension.End.Column];
                DataRow row = tbl.Rows.Add();
                foreach (var cell in wsRow)
                {
                    row[cell.Start.Column - 1] = cell.Text;
                }
            }
            return tbl;
        }

        public static Color ColorFromHexCode(string hexCode)
        {
            return (Color)new ColorConverter().ConvertFromString($"#{hexCode}");
        }

        public static string TreatPercentage(this decimal? value)
        {
            if (!value.HasValue)
            {
                return string.Empty;
            }

            var rounded = Math.Round(value.Value, 2);
            var decimalPart = rounded - Math.Truncate(rounded);
            var decimalStr = decimalPart == 0
                ? "0"
                : decimalPart.ToString();

            var integerStr = ((int)rounded).ToString();

            return $"{integerStr},{decimalStr} %";
        }

        public static string ToRealMonetaryString(
            this decimal? value,
            bool returnEmptyIf0 = false,
            bool useSymbol = true,
            int decimalPrecision = 2,
            int? padLeftQty = null,
            char? paddingChar = null)
        {
            if (!value.HasValue)
            {
                return returnEmptyIf0
                    ? string.Empty
                    : "0";
            }

            var roundedDecimal = Math.Round(value.Value, decimalPrecision);
            var val = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", roundedDecimal)
                .Replace("R$", string.Empty)
                .Trim();

            if (padLeftQty.HasValue && paddingChar.HasValue)
            {
                val = val.Trim().PadLeft(padLeftQty.Value, paddingChar.Value);
            }

            if (useSymbol)
            {
                val = $"R$ {val}".Trim();
            }

            return val;
        }

        public static List<bool> GetHash(this Bitmap bmpSource)
        {
            List<bool> lResult = new List<bool>();
            //create new image with 16x16 pixel
            Bitmap bmpMin = new Bitmap(bmpSource, new Size(16, 16));
            for (int j = 0; j < bmpMin.Height; j++)
            {
                for (int i = 0; i < bmpMin.Width; i++)
                {
                    //reduce colors to true / false                
                    lResult.Add(bmpMin.GetPixel(i, j).GetBrightness() < 0.5f);
                }
            }
            return lResult;
        }

        public static List<bool> GetHash(this Image imageSource)
        {
            return GetHash(new Bitmap(imageSource));
        }

        public static void TreatMonetaryCellValue(this DataGridViewCell cell)
        {
            if (!((string)cell.Value).All(GSUtilitarios.EhDigitoOuPonto))
            {
                cell.Value = string.Empty;
                return;
            }

            try
            {
                var numero = ((string)cell.Value)
                    .Replace(",", string.Empty)
                    .Replace(".", string.Empty);

                if (numero == string.Empty)
                {
                    return; 
                }

                numero = numero.PadLeft(3, '0');

                if (numero.Length > 3 && numero.Substring(0, 1) == "0")
                {
                    numero = numero.Substring(1, numero.Length - 1);
                }

                var valor = Convert.ToDouble(numero) / 100;
                cell.Value = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:N}", valor);
                //textBox.SelectionStart = ((string)cell.Value).Length;
            }
            catch (Exception)
            {
                throw new Exception("Ocorreu um erro na formatação monetária.");
            }
        }

        public static void PaintImageAsButton(this Bitmap image, DataGridViewCellPaintingEventArgs e)
        {
            e.Paint(e.CellBounds, DataGridViewPaintParts.All);

            var w = image.Width;
            var h = image.Height;
            var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
            var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

            e.Graphics.DrawImage(image, new Rectangle(x, y, w, h));
            e.Handled = true;
        }

        //public static void RepaintImageAsButton(this Bitmap image, )
        //{
        //    e.Paint(e.CellBounds, DataGridViewPaintParts.All);

        //    var w = image.Width;
        //    var h = image.Height;
        //    var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
        //    var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

        //    e.Graphics.DrawImage(image, new Rectangle(x, y, w, h));
        //    e.Handled = true;
        //}

        public static IEnumerable<int> AllIndexesOf(this string str, string searchstring)
        {
            int minIndex = str.IndexOf(searchstring);
            while (minIndex != -1)
            {
                yield return minIndex;
                minIndex = str.IndexOf(searchstring, minIndex + searchstring.Length);
            }
        }

        public static string Swap(this string stringValue, char charA, char charB)
        {
            var charAPositions = stringValue.AllIndexesOf(charA.ToString());
            var charBPositions = stringValue.AllIndexesOf(charB.ToString());

            var newString = string.Empty;

            for (var i = 0; i < stringValue.Length; i++)
            {
                var appendChar = stringValue[i];
                if (charAPositions.Contains(i))
                {
                    appendChar = charB;
                }

                if (charBPositions.Contains(i))
                {
                    appendChar = charA;
                }

                newString += appendChar;
            }

            return newString;
        }

        public static int FinalSum(this IList<Interacao> interacoes)
        {
            var somalFinal = 0;

            foreach (var interacao in interacoes)
            {
                switch (interacao.TipoDeInteracao)
                {
                    case EnumTipoDeInteracao.ENTRADA:
                        somalFinal += interacao.QuantidadeInterada;
                        break;
                    case EnumTipoDeInteracao.SAIDA:
                        somalFinal -= interacao.QuantidadeInterada;
                        break;
                    case EnumTipoDeInteracao.BASE_DE_TROCA:
                        somalFinal += interacao.QuantidadeInterada;
                        somalFinal -= interacao.QuantidadeInterada;
                        break;
                }

            }

            return somalFinal;
        }
    }
}
