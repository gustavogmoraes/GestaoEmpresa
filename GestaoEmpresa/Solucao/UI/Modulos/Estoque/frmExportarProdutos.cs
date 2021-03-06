﻿using GS.GestaoEmpresa.Solucao.Negocio.Atributos;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using GS.GestaoEmpresa.Solucao.Negocio.Servicos;
using GS.GestaoEmpresa.Solucao.Persistencia.BancoDeDados;
using GS.GestaoEmpresa.Solucao.Persistencia.Repositorios;
using GS.GestaoEmpresa.Solucao.Utilitarios;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LicenseContext = OfficeOpenXml.LicenseContext;

namespace GS.GestaoEmpresa.Solucao.UI.Modulos.Estoque
{
    public partial class frmExportarProdutos : Form
    {
        private int? _columnIndex = null;

        private List<PropertyInfo> _properties { get; set; }

        public frmExportarProdutos()
        {
            InitializeComponent();
        }

        private void frmExportarProdutos_Load(object sender, EventArgs e)
        {
            CarregueGrid();
        }

        private void CarregueGrid()
        {
            using var servicoDeProduto = new ServicoDeProduto();
            var propriedades = GSUtilitarios.EncontrePropriedadeMarcadaComAtributo(typeof(Produto), typeof(ExporterMetadata));
            var propCodigo = propriedades.FirstOrDefault(x => x.Name == "Codigo");
            propriedades.RemoveAll(x => x.Name == "Codigo");

            propriedades.Insert(0, propCodigo);

            var propsAndLabels = propriedades.ObtenhaPropriedadesELabels().ToList();

            propsAndLabels.ForEach(x => gridExportacao.Columns.Add(x.Key.Name, x.Value));
            gridExportacao.Columns.Add("Quantidade", "Quantidade");

            foreach (DataGridViewColumn column in gridExportacao.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }

            AjusteEstilo();
            AjusteContextMenu();

            var allCodes = RavenHelper.OpenSession().Query<Produto>()
                .Where(x => x.Atual &&
                            x.PrecoDeCompra != null &&
                            x.PrecoDeVenda != null)
                .OrderBy(x => x.Codigo)
                .Select(x => x.Codigo)
                .ToList();

            var rng = new Random();
            var listaProdutos = new List<Produto>();

            for (int i = 0; i < 3; i++)
            {
                int numeroAleatorio = rng.Next(1, allCodes.Count);
                var productCode = allCodes[numeroAleatorio];

                listaProdutos.Add(servicoDeProduto.Consulte(productCode));
            }

            listaProdutos.Sort((x, y) => x.Codigo.CompareTo(y.Codigo));

            var quantidades = servicoDeProduto.ConsulteQuantidade(listaProdutos.Select(x => x.Codigo).ToList());

            listaProdutos.ForEach(x => gridExportacao.Rows.Add(GetValues(propsAndLabels, x, quantidades)));
            _properties = propsAndLabels
                .Select(x => x.Key)
                .Where(x => x.Name != "Quantidade")
                .ToList();
        }

        private object[] GetValues(
            List<KeyValuePair<PropertyInfo, string>> propsAndLabels, Produto produto, Dictionary<int, int> quantidades)
        {
            var valueList = new List<object>();

            propsAndLabels.Where(x => x.Key.Name != "Quantidade")
                .Select(x => x.Key.GetValue(produto) ?? string.Empty)
                .ToList()
                .ForEach(x => valueList.Add(x));

            valueList.Add(quantidades[produto.Codigo]);

            return valueList.ToArray();
        }

        private void InicieForm()
        {
            gridExportacao.Columns.Clear();
            gridExportacao.Rows.Clear();

            CarregueGrid();
        }

        private void AjusteContextMenu()
        {
            foreach (DataGridViewColumn gridViewColumn in gridExportacao.Columns)
            {
                gridViewColumn.HeaderCell.ContextMenuStrip = contextMenuStrip;
            }
        }

        private void AjusteEstilo()
        {
            gridExportacao.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            gridExportacao.AutoResizeColumnHeadersHeight();
        }

        private void AltereHeaderText(string novoTexto)
        {
            var coluna = gridExportacao.Columns[_columnIndex.GetValueOrDefault()];

            coluna.HeaderText = novoTexto;
            txtBox.Hide();
        }

        private void renomearToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (_columnIndex != null)
            {
                var coluna = gridExportacao.Columns[_columnIndex.GetValueOrDefault()];

                var fonte = gridExportacao.ColumnHeadersDefaultCellStyle.Font;

                var newFont = new Font(fonte.FontFamily, fonte.Size - 2f);

                txtBox.Font = newFont;
                txtBox.Size = new Size(coluna.Width - 2, 0);

                var soma = 0;
                foreach (DataGridViewColumn column in gridExportacao.Columns)
                {
                    if (column.Index < _columnIndex)
                    {
                        soma += column.Width;
                    }
                }

                var location = gridExportacao.Location;
                location.X += soma + 3;
                location.Y += 2;

                txtBox.Text = coluna.HeaderText;
                txtBox.Location = location; //PointToClient(MousePosition)
                txtBox.BringToFront();
                txtBox.Show();
                txtBox.Focus();
            }
        }

        private void deletarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (_columnIndex != null)
            {
                gridExportacao.Columns.RemoveAt(_columnIndex.GetValueOrDefault());
            }
        }

        private void txtBox_Leave_1(object sender, EventArgs e)
        {
            AltereHeaderText(txtBox.Text);
        }

        private void txtBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AltereHeaderText(txtBox.Text);
            }
        }

        private void gridExportacao_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridView view = (DataGridView)sender;

                if (e.Button == MouseButtons.Right && e.RowIndex == -1)
                {
                    Console.WriteLine($"Clicked column {e.ColumnIndex} + row {e.RowIndex} of DataGridView {view.Name} +  at {Cursor.Position}");

                    _columnIndex = e.ColumnIndex;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message + Environment.NewLine + ex.StackTrace);
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            saveFileDialog = new SaveFileDialog
            {
                Filter = "Planilha do Excel|*.xlsx",
                Title = "Escolha o caminho",
                FileName = $"Produtos sistema Mega {DateTime.Now.ToString("dd MM yyyy hh mm")}"
            };
            saveFileDialog.ShowDialog();

            if (!string.IsNullOrEmpty(saveFileDialog.FileName))
            {
                Exporte(saveFileDialog.FileName);
                MessageBox.Show("Exportado com sucesso", "Sucesso!");
                this.Dispose();
            }
        }

        private Task Exporte(string caminho)
        {
            var colunas = 
                gridExportacao.Columns.Cast<DataGridViewColumn>()
                .Where(x => x.HeaderText != "Quantidade")
                .ToDictionary( x => typeof(Produto).GetProperty(x.Name), x => x.HeaderText);

            var dataSet = new DataSet();
            dataSet.Tables.Add("Produtos");

            foreach(var coluna in colunas)
            {
                var column = dataSet.Tables["Produtos"].Columns.Add(coluna.Value);
                column.DataType = coluna.Key.PropertyType.IsNullable()
                    ? coluna.Key.PropertyType.GenericTypeArguments.First()
                    : coluna.Key.PropertyType;
            }

            dataSet.Tables["Produtos"].Columns.Add("Quantidade");
            dataSet.Tables["Produtos"].Columns.Cast<DataColumn>().LastOrDefault().DataType = typeof(int);

            using var repositorioDeProduto = new RepositorioDeProduto();
            var listaDeProdutos = repositorioDeProduto.ConsulteTodos(takeQuantity: int.MaxValue).ToList();
            var quantidades = repositorioDeProduto.ConsulteQuantidade(listaDeProdutos.Select(x => x.Codigo).ToList());

            if (listaDeProdutos.Count <= 0)
            {
                return null;
            }

            foreach (var produto in listaDeProdutos)
            {
                var linha = dataSet.Tables["Produtos"].NewRow();
                foreach (var propriedade in colunas)
                {
                    linha[propriedade.Value] = propriedade.Key.GetValue(produto) ?? DBNull.Value;
                }

                if(!quantidades.ContainsKey(produto.Codigo))
                {
                    using var session = RavenHelper.OpenSession();
                    var prdQty = new ProdutoQuantidade
                    {
                        Codigo = produto.Codigo,
                        Quantidade = 0
                    };

                    session.Store(prdQty);
                    session.SaveChanges();

                    quantidades.Add(produto.Codigo, 0);
                }

                linha["Quantidade"] = quantidades[produto.Codigo];

                dataSet.Tables["Produtos"].Rows.Add(linha);
            }

            ExportarDataSetParaExcelEPPlus(dataSet, caminho);

            return null;
        }

        // Desativei o interop porque precisa do Excel instalado pra funcionar e isso é bad
        #region Desativado

        //private void ExportarDataSetParaExcelInterop(DataSet ds, string path)
        //{
        //    var excelApp = new Excel.Application();
        //    var excelWorkBook = excelApp.Workbooks.Add();

        //    foreach (DataTable table in ds.Tables)
        //    {
        //        Excel.Worksheet excelWorkSheet = excelWorkBook.Sheets.Add();
        //        excelWorkSheet.Name = table.TableName;

        //        for (int i = 1; i < table.Columns.Count + 1; i++)
        //        {
        //            excelWorkSheet.Cells[1, i] = table.Columns[i - 1].ColumnName;
        //        }

        //        for (int j = 0; j < table.Rows.Count; j++)
        //        {
        //            for (int k = 0; k < table.Columns.Count; k++)
        //            {
        //                excelWorkSheet.Cells[j + 2, k + 1] = table.Rows[j].ItemArray[k].ToString();
        //            }
        //        }
        //    }

        //    excelWorkBook.SaveAs(path);
        //    excelWorkBook.Close();
        //    excelApp.Quit();
        //}

        #endregion

        private void ExportarDataSetParaExcelEPPlus(DataSet dataSet, string caminho)
        {
            #region Formatar colunas se necessário

            // Sette os DataTypes das colunas no dataSet e tudo vai sair como o esperado

            ////integer (not really needed unless you need to round numbers, Excel will use default cell properties)
            //ws.Cells["A1:A25"].Style.Numberformat.Format = "0";

            ////integer without displaying the number 0 in the cell
            //ws.Cells["A1:A25"].Style.Numberformat.Format = "#";

            ////number with 1 decimal place
            //ws.Cells["A1:A25"].Style.Numberformat.Format = "0.0";

            ////number with 2 decimal places
            //ws.Cells["A1:A25"].Style.Numberformat.Format = "0.00";

            ////number with 2 decimal places and thousand separator
            //ws.Cells["A1:A25"].Style.Numberformat.Format = "#,##0.00";

            ////number with 2 decimal places and thousand separator and money symbol
            //ws.Cells["A1:A25"].Style.Numberformat.Format = "€#,##0.00";

            ////percentage (1 = 100%, 0.01 = 1%)
            //ws.Cells["A1:A25"].Style.Numberformat.Format = "0%";

            ////accounting number format
            //ws.Cells["A1:A25"].Style.Numberformat.Format = "_-$* #,##0.00_-;-$* #,##0.00_-;_-$* \"-\"??_-;_-@_-";

            #endregion

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using var pacoteExcel = new ExcelPackage();
            foreach (DataTable tabela in dataSet.Tables)
            {
                var planilha = pacoteExcel.Workbook.Worksheets.Add(tabela.TableName);

                // Setta as colunas
                for (int i = 1; i < tabela.Columns.Count + 1; i++)
                {
                    planilha.Cells[1, i].Value = tabela.Columns[i - 1].ColumnName;
                    planilha.Cells[1, i].Style.Font.Bold = true;

                    var dataType = tabela.Columns[i - 1].DataType;
                    if (dataType.IsNumericType())
                    {
                        planilha.Column(i).Style.Numberformat.Format = "#,##0";
                    }

                    var valorCelula = planilha.Cells[1, i].Value.ToString();
                    if (valorCelula.Contains("nome") || valorCelula.Contains("NOME") || valorCelula.Contains("Nome"))
                    {
                        planilha.Column(i).Width = 35;
                    }
                    else if (valorCelula.Contains("bservações") || valorCelula.Contains("bservação"))
                    {
                        planilha.Column(i).Width = 40;
                    }
                    else
                    {
                        planilha.Column(i).AutoFit();
                    }
                }

                // Setta as linhas
                for (int j = 0; j < tabela.Rows.Count; j++)
                {
                    for (int k = 0; k < tabela.Columns.Count; k++)
                    {
                        planilha.Cells[j + 2, k + 1].Value = tabela.Columns[k].DataType == typeof(bool)
                                                           ? Convert.ToBoolean(tabela.Rows[j].ItemArray[k]).ConvertaValorBooleanoDescritivo()
                                                           : tabela.Rows[j].ItemArray[k];
                    }
                }
            }

            pacoteExcel.SaveAs(new FileInfo(caminho));
        }

        private void gridExportacao_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            if(e.Column.Name == "Nome")
            {
                e.Column.Width = 200;
            }
        }
    }
}
