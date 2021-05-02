using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GS.GestaoEmpresa.Properties;
using GS.GestaoEmpresa.Solucao.Negocio.Catalogos;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using GS.GestaoEmpresa.Solucao.Negocio.Servicos;
using GS.GestaoEmpresa.Solucao.Persistencia.BancoDeDados;
using GS.GestaoEmpresa.Solucao.Persistencia.Repositorios;
using GS.GestaoEmpresa.Solucao.UI.Base;
using GS.GestaoEmpresa.Solucao.UI.ControlesGenericos;
using GS.GestaoEmpresa.Solucao.UI.Modulos.Atendimento;
using GS.GestaoEmpresa.Solucao.UI.Modulos.Estoque;
using GS.GestaoEmpresa.Solucao.UI.Modulos.Tecnico;
using GS.GestaoEmpresa.Solucao.Utilitarios;
using MetroFramework.Forms;
using Microsoft.VisualBasic;
using Raven.Client.Documents.Linq;

namespace GS.GestaoEmpresa.Solucao.UI.Principal
{
    public partial class frmPrincipal : MetroForm, IView
    {
        public IPresenter Presenter { get; set; }

        public void MinimizeFormCall(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        public void CloseFormCall(object sender, EventArgs e)
        {
            Close();
        }

        public void MaximizeFormCall(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
                return;
            }

            WindowState = FormWindowState.Maximized;
        }

        public void SetBorderStyle()
        {
            BorderStyle = MetroFormBorderStyle.FixedSingle;
        }

        public EnumTipoDeForm TipoDeForm { get; set; }


        #region Constantes

        public const string DIRETORIO_LOCAL = @".\";

        public const string NOME_ARQUIVO_CONFIGURACOES_BANCO = "ConexaoBanco.txt";

        #endregion

        #region Métodos

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void AjustePosicaoControlsDinamicamente()
        {
            // Fazemos os ajustes
            // lblConfiguracoesBasicas.Location = new Point(this.ClientSize.Width - 80, 15);
            // EscondaHeadersTabControl(tabControl1);
            CentralizeTabControl(tabControl1);

            // Habilitamos a visibilidade
            tabControl1.Visible = true;
            if (!SessaoSistema.Iniciada)
            {
                lblConfiguracoesBasicas.Visible = true;
            }
        }

        private void CarregueConfiguracoesConexaoBanco()
        {
           SessaoSistema.InformacoesConexao = SessaoSistema.BusqueConfiguracoesConexaoDoArquivo(DIRETORIO_LOCAL, NOME_ARQUIVO_CONFIGURACOES_BANCO);

            if (SessaoSistema.InformacoesConexao == null)
            {
                MessageBox.Show(Mensagens.NAO_HA_CONFIGURACOES_BANCO);
                return;
            }

            txtConfigServer.Text = SessaoSistema.InformacoesConexao.Servidor;
            txtConfigDatabaseName.Text = SessaoSistema.InformacoesConexao.NomeBanco;
        }

        private void CarregueChamador()
        {
            tabControl1.SelectTab("tabChamador");
            btnTecnico.Enabled = false;

            btnCorporativo.Enabled = false;
            btnAuditoria.Enabled = false;

            using (var servicoMapeadorUsuario = new RepositorioDeUsuario())
            {
                var usuario = servicoMapeadorUsuario.Consulte(SessaoSistema.CodigoUsuario);

                txtPermissaoUsuario.Text = usuario.Nome;
                //txtPermissaoFuncao.Text = usuario.Funcionario.Funcao ?? "---";
                //txtPermissaoGrupo.Text = usuario.Grupo.Nome ?? "---";
            }
        }

        private void CarregueLogin()
        {
            tabControl1.SelectTab("tabLogin");
        }

        private void CentralizeTabControl(TabControl tabControl)
        {
            tabControl.Left = (ClientSize.Width - tabControl1.Width) / 2;
            tabControl.Top = ((ClientSize.Height - tabControl1.Height) / 2) + ((gsTopBorder1.Height / 2) - 2)  ;
        }

        private void EscondaHeadersTabControl(TabControl tabControl)
        {
            tabControl.Appearance = TabAppearance.FlatButtons;
            tabControl.ItemSize = new Size(0, 1);
            tabControl.SizeMode = TabSizeMode.Fixed;
        }

        public void DefinaLabelsIPs()
        {
            if (SessaoSistema.InformacoesConexao == null)
            {
                SessaoSistema.BusqueConfiguracoesConexaoDoArquivo(DIRETORIO_LOCAL, NOME_ARQUIVO_CONFIGURACOES_BANCO);
            }

            lblIpApp.Text = GSUtilitarios.ObtenhaIPLocal();

            if (SessaoSistema.InformacoesConexao != null)
            {
                lblIpBanco.Text = SessaoSistema.InformacoesConexao.Servidor;
            }
        }

        public void InicieVerificacaoParaAtualizarStatusDeConexao()
        {
            DefinaLabelsIPs();

            void Acao()
            {
                while (SessaoSistema.VerificarStatusDaConexao)
                {
                    if (SessaoSistema.ConexaoAtiva)
                    {
                        pictureBox5.Invoke((MethodInvoker) delegate
                        {
                            pictureBox5.BackgroundImage = Resources.Conexao;
                            btnEntrar.Enabled = true;
                        });
                    }
                    else
                    {
                        pictureBox5.Invoke((MethodInvoker) delegate
                        {
                            pictureBox5.BackgroundImage = Resources.SemConexao;
                            btnEntrar.Enabled = false;
                        });
                    }

                    Thread.Sleep(350);
                }
            }

            GSTarefasAssincronas.ExecuteTarefaAssincrona(Acao);
        }

        #endregion

        #region Eventos

        //Evento Load
        private void GestaoEmpresa_Load(object sender, EventArgs e)
        {
            AjustePosicaoControlsDinamicamente();

            if (SessaoSistema.Iniciada)
            {
                CarregueChamador();
            }
            else
            {
                CarregueLogin();
            }

            txtUsuario.Select();

            CarregueConfiguracoesConexaoBanco();
            SessaoSistema.InicieVerificacaoDeConexao();

            InicieVerificacaoParaAtualizarStatusDeConexao();
        }

        // TODO: Creio eu que esses não são mais usados, confirmar e excluir
        private void label13_Click(object sender, EventArgs e)
        {
            lblConfiguracoesBasicas.Visible = true;
            gbConfiguracoesBasicas.Visible = false;

            panelConexao.Location = new Point(557, 22);

            CarregueConfiguracoesConexaoBanco();
        }

        private void btnSalvarConfiguracaoBasica_Click(object sender, EventArgs e)
        {
            var informacoesConexaoBanco = new InformacoesConexaoBanco()
            {
                Servidor = txtConfigServer.Text.Trim(),
                NomeBanco = txtConfigDatabaseName.Text.Trim()
            };


            SessaoSistema.SalveConfiguracoesConexaoNoArquivo(
                informacoesConexaoBanco, DIRETORIO_LOCAL, NOME_ARQUIVO_CONFIGURACOES_BANCO);

            CarregueConfiguracoesConexaoBanco();
            DefinaLabelsIPs();
        }

        private void lblConfiguracoesBasicas_Click(object sender, EventArgs e)
        {
            lblConfiguracoesBasicas.Visible = false;
            gbConfiguracoesBasicas.Location = new Point(this.ClientSize.Width - 230, 30);
            gbConfiguracoesBasicas.Visible = true;
        }

        private void btnEstoque_Click(object sender, EventArgs e)
        {
            
        }
        //------------------------------------------------------------

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            //GerenciadorAbas.ChamadorAtivo = false;
        }

        private void btnConfiguracoes_Click(object sender, EventArgs e)
        {

        }

        private void lblConfiguracoesBasicas_Click_1(object sender, EventArgs e)
        {
            lblConfiguracoesBasicas.Visible = false;
            //gbConfiguracoesBasicas.Location = new Point(this.ClientSize.Width - 230, 30);
            gbConfiguracoesBasicas.Location = new Point(557, 30);
            gbConfiguracoesBasicas.Visible = true;

            panelConexao.Location = new Point(557, 315);
        }

        private void label13_Click_1(object sender, EventArgs e)
        {
            lblConfiguracoesBasicas.Visible = true;
            gbConfiguracoesBasicas.Visible = false;

            this.CarregueConfiguracoesConexaoBanco();
        }

        private void btnEntrar_Click_1(object sender, EventArgs e)
        {
            using (var servicoDeUsuario = new ServicoDeUsuario())
            {
                var usuario = servicoDeUsuario.Consulte((txtUsuario.Text.Trim()));
                if (usuario != null)
                {
                    if (usuario.Senha == txtSenha.Text.Trim().GetDeterministicHashCode())
                    {
                        tabControl1.SelectTab("tabChamador");
                        //GerenciadorAbas.ChamadorAtivo = true;
                        lblConfiguracoesBasicas.Visible = false;

                        //Dados da sessão do sistema
                        SessaoSistema.Iniciada = true;
                        SessaoSistema.CodigoUsuario = usuario.Codigo;
                        SessaoSistema.NomeUsuario = usuario.Nome;

                        txtPermissaoUsuario.Text = usuario.Nome;
                        //txtPermissaoFuncao.Text = usuario.Funcionario.Funcao ?? "---";
                        //txtPermissaoGrupo.Text = usuario.GrupoUsuario == null ? "---" : usuario.GrupoUsuario.Nome;

                        SessaoSistema.VerificarStatusDaConexao = false;
                        SessaoSistema.UISettings = usuario.UISettings ?? new UISettings();
                        return;
                    }
                }

                txtSenha.Clear();
                MessageBox.Show("Usuário ou senha incorretos");
            }
        }

        private void lblConfiguracoesBasicas_Click_2(object sender, EventArgs e)
        {

        }

        private void btnConfiguracoes_Click_1(object sender, EventArgs e)
        {
        }

        #endregion

        private void tabLogin_Click(object sender, EventArgs e)
        {

        }

        private void btnEstoque_Click_1(object sender, EventArgs e)
        {
            IView view = null;
            GSWaitForm.Mostrar(
                () =>
                {
                    view = GerenciadorDeViews.CrieIndependente<FrmEstoque>();
                },
                () =>
                {
                    view.Show();
                    view.Focar(state: FormWindowState.Maximized);
                });
        }

        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r') || e.KeyChar.Equals(Keys.Return) || e.KeyChar.Equals(Keys.Return))
            {
                if(btnEntrar.Enabled)
                    btnEntrar_Click_1(sender, e);
            }
        }

        private void btnTecnico_Click(object sender, EventArgs e)
        {
            new frmTecnico().Show();
        }

        private void btnAtendimento_Click(object sender, EventArgs e)
        {
            new FrmAtendimento().Show();
        }

        public string InstanceId { get; set; }

        public void ApagueInstancia()
        {
            //GerenciadorDeViews.Exclua<frmPrincipal>(IdInstancia);
        }

        #region Migração

        private void Label15_Click(object sender, EventArgs e)
        {
            var serverRaven = SessaoSistema.InformacoesConexao.Servidor;
            var nomeBancoRaven = SessaoSistema.InformacoesConexao.NomeBanco;

            var informacoesConexaoBancoSQL = new InformacoesConexaoBanco
            {
                Servidor = Interaction.InputBox("Endereço BD SQL", "Migração de dados", ""),
                NomeBanco = Interaction.InputBox("Nome banco", "Migração de dados", ""),
                Usuario = Interaction.InputBox("Usuario", "Migração de dados", ""),
                Senha = Interaction.InputBox("Senha", "Migração de dados", ""),
                TipoDeBanco = EnumTipoDeBanco.SQLSERVER
            };

            SessaoSistema.InformacoesConexao = informacoesConexaoBancoSQL;

            MessageBox.Show("Consultando...");

            var listaProdutosRaven = new List<Produto>();
            var listaUsuariosRaven = new List<Usuario>();
            var listaInteracoesRaven = new List<Interacao>();

            var ultimasVigenciasDeProduto = ConsulteTodosProdutosSql();

            Parallel.ForEach(ultimasVigenciasDeProduto, ultimaVigencia =>
            {
                var todasVigencias = ConsulteTodasVigenciasProduto(ultimaVigencia.Codigo);
                
                todasVigencias = todasVigencias.OrderBy(x => x).ToList();

                foreach (var vigencia in todasVigencias)
                {
                    var produtoConsultado = ConsulteProduto(ultimaVigencia.Codigo, vigencia);
                    produtoConsultado.Vigencia = vigencia;

                    if (vigencia == todasVigencias.LastOrDefault())
                    {
                        produtoConsultado.Atual = true;
                    }

                    listaProdutosRaven.Add(produtoConsultado);
                }
            });

            listaUsuariosRaven.AddRange(ConsulteTodosUsuarios());

            var informacoesConexaoBancoRaven = new InformacoesConexaoBanco
            {
                Servidor = serverRaven,
                NomeBanco = nomeBancoRaven,
                TipoDeBanco = EnumTipoDeBanco.RAVENDB
            };

            SessaoSistema.InformacoesConexao = informacoesConexaoBancoRaven;

            MessageBox.Show("Salvando...");

            using (var repoUser = new RepositorioDeUsuario())
            using (var repoProduto = new RepositorioDeProduto())
            //using (var repoInteracao = new RepositorioDeInteracao())
            {
                listaUsuariosRaven.ForEach(x => repoUser.Insira(x));
                //listaInteracoesRaven.ForEach(x => repoInteracao.Insira(x));

                listaProdutosRaven.GroupBy(x => x.Codigo).ToList().ForEach(grupo =>
                {
                    var lista = grupo.OrderBy(x => x.Vigencia).ToList();

                    repoProduto.Insira(lista.FirstOrDefault());

                    lista.Remove(lista.FirstOrDefault());
                    lista.ForEach(x => repoProduto.Atualize(x));
                });
            }

            SessaoSistema.InformacoesConexao = informacoesConexaoBancoSQL;
            var listaInteracoes = ConsulteTodasAsInteracoes();
            listaInteracoesRaven.AddRange(listaInteracoes.OrderBy(x => x.HorarioProgramado));

            SessaoSistema.InformacoesConexao = informacoesConexaoBancoRaven;

            using (var repoInteracao = new RepositorioDeInteracao())
                listaInteracoesRaven.ForEach(x => repoInteracao.Insira(x));

            MessageBox.Show("Concluído!");
        }

        private string ColunasProduto => string.Join(", ", this.ColunasETiposDeDadosProduto.Keys);

        private Dictionary<string, Type> ColunasETiposDeDadosProduto =>
            new Dictionary<string, Type>()
            {
                { "CODIGO", typeof(int) },
                { "STATUS", typeof(bool) },
                { "NOME", typeof(string) },
                { "FABRICANTE", typeof(string) },
                { "CODIGOFABRICANTE", typeof(string) },
                { "PRECOCOMPRA", typeof(decimal) },
                { "PRECOVENDA", typeof(decimal) },
                { "PORCENTAGEMLUCRO", typeof(float) },
		        { "AVISARQUANTIDADE", typeof(bool) },
                { "QUANTIDADEMINIMAAVISO", typeof(int) },
                { "OBSERVACAO", typeof(string) }
            };

        private Produto MonteRetornoProduto(DataTable tabela, int linha)
        {
            var retorno = new Produto();

            retorno.Codigo = int.Parse(tabela.Rows[linha]["CODIGO"].ToString());
            retorno.Status = (EnumStatusToggle)int.Parse(tabela.Rows[linha]["STATUS"].ToString());
            retorno.Nome = tabela.Rows[linha]["NOME"].ToString();
            retorno.Fabricante = tabela.Rows[linha]["FABRICANTE"] != DBNull.Value
                               ? tabela.Rows[linha]["FABRICANTE"].ToString()
                               : null;
            retorno.CodigoDoFabricante = tabela.Rows[linha]["CODIGOFABRICANTE"] != DBNull.Value
                                       ? tabela.Rows[linha]["CODIGOFABRICANTE"].ToString()
                                       : null;
            retorno.PrecoDeCompra = decimal.Parse(tabela.Rows[linha]["PRECOCOMPRA"].ToString());
            retorno.PrecoDeVenda = decimal.Parse(tabela.Rows[linha]["PRECOVENDA"].ToString());
            retorno.PorcentagemDeLucro = decimal.Parse(tabela.Rows[linha]["PORCENTAGEMLUCRO"].ToString());
            //retorno.QuantidadeEmEstoque = tabela.Rows[linha]["QUANTIDADEESTOQUE"] != DBNull.Value
            //                            ? int.Parse(tabela.Rows[linha]["QUANTIDADEESTOQUE"].ToString())
            //                            : 0;
            retorno.AvisarQuantidade = GSUtilitarios.ConvertaValorBooleano(tabela.Rows[linha]["AVISARQUANTIDADE"].ToString());
            retorno.QuantidadeMinimaParaAviso = int.Parse(tabela.Rows[linha]["QUANTIDADEMINIMAAVISO"].ToString());
            retorno.Observacao = tabela.Rows[linha]["OBSERVACAO"] != DBNull.Value
                               ? tabela.Rows[linha]["OBSERVACAO"].ToString()
                               : null;

            return retorno;
        }

        private List<Produto> ConsulteTodosProdutosSql()
        {
            var Tabela = "PRODUTOS";

            var colunas = ColunasProduto.Replace(", ", ", T1.")
                                        .Replace("CODIGO, ", string.Empty);

            var comandoSQL =
                $"SELECT T1.CODIGO, {colunas}, PRODUTOS_QUANTIDADES.QUANTIDADE AS QUANTIDADEESTOQUE FROM {Tabela} AS T1 " +
                $"INNER JOIN(SELECT MAX(VIGENCIA) VIGENCIA, CODIGO FROM {Tabela} GROUP BY CODIGO) AS T2 " +
                $"ON T1.CODIGO = T2.CODIGO AND T1.VIGENCIA = T2.VIGENCIA INNER JOIN PRODUTOS_QUANTIDADES ON T1.CODIGO = PRODUTOS_QUANTIDADES.CODIGO_PRODUTO ORDER BY CODIGO";

            DataTable tabela;
            try
            {
                using (var GSBancoDeDados = new GSBancoDeDados())
                    tabela = GSBancoDeDados.ExecuteConsulta(comandoSQL);

                if (tabela == null)
                    return null;

                var listaRetorno = new List<Produto>();
                for (int linha = 0; linha < tabela.Rows.Count; linha++)
                {
                    listaRetorno.Add(MonteRetornoProduto(tabela, linha));
                }

                return listaRetorno;
            }
            catch (System.Exception)
            {
                return null;
                throw;
            }
        }

        public List<DateTime> ConsulteTodasVigenciasProduto(int Codigo)
        {
            string ComandoSQL = String.Format("SELECT VIGENCIA FROM {0} WHERE {1} = {2} ORDER BY VIGENCIA DESC",
                                              "PRODUTOS",
                                              "CODIGO",
                                              Codigo);

            DataTable tabela;
            try
            {
                using (var GSBancoDeDados = new GSBancoDeDados())
                    tabela = GSBancoDeDados.ExecuteConsulta(ComandoSQL);

                if (tabela == null)
                    return null;

                var listaRetorno = new List<DateTime>();

                for (int linha = 0; linha < tabela.Rows.Count; linha++)
                {
                    var dado = tabela.Rows[linha]["VIGENCIA"];
                    //listaRetorno.Add(GSUtilitarios.FormateDateTimePtBrParaBD(dado.ToString()));
                    listaRetorno.Add((DateTime)dado);
                }

                return listaRetorno;
            }
            catch (System.Exception)

            {
                return null;
                throw;
            }
        }

        public Produto ConsulteProduto(int Codigo, DateTime vigencia)
        {
            vigencia = new DateTime(vigencia.Year, vigencia.Month, vigencia.Day, vigencia.Hour, vigencia.Minute, 59);
            string ComandoSQL = String.Format("SELECT {0}, PRODUTOS_QUANTIDADES.QUANTIDADE AS QUANTIDADEESTOQUE FROM {1} " +
                                              "INNER JOIN PRODUTOS_QUANTIDADES ON PRODUTOS.CODIGO = PRODUTOS_QUANTIDADES.CODIGO_PRODUTO " +
                                              "WHERE CODIGO = {2} " +
                                              "AND VIGENCIA = (SELECT MAX(VIGENCIA) FROM PRODUTOS WHERE CODIGO = {2} AND VIGENCIA <= CAST ('{3}' AS DATETIME2))",
                                              ColunasProduto,
                                              "PRODUTOS",
                                              Codigo,
                                              GSUtilitarios.FormateDateTimePtBrParaBD(vigencia));

            DataTable tabela;
            try
            {
                using (var GSBancoDeDados = new GSBancoDeDados())
                    tabela = GSBancoDeDados.ExecuteConsulta(ComandoSQL);

                if (tabela.Rows.Count == 0)
                {
                    var primeiraData = ConsulteTodasVigenciasProduto(Codigo).OrderBy(x => x).First();
                    return ConsulteProduto(Codigo, primeiraData);
                }

                if (tabela == null)
                    return null;

                return MonteRetornoProduto(tabela, 0);
            }
            catch (System.Exception)
            {
                return null;
                throw;
            }
        }

        

        private string ColunasUsuario => string.Join(", ", this.ColunasETiposDeDadosUsuario.Keys);

        private Dictionary<string, Type> ColunasETiposDeDadosUsuario
        =>
        new Dictionary<string, Type>()
        {
            {"CODIGO", typeof(int)},
            {"STATUS", typeof(bool)},
            {"NOME", typeof(string)},
            {"SENHA", typeof(int)}
        };

        private Usuario MonteRetornoUsuario(DataTable tabela, int linha)
        {
            var retorno = new Usuario();

            retorno.Codigo = int.Parse(tabela.Rows[linha]["CODIGO"].ToString());
            retorno.Status = (EnumStatusDoUsuario)int.Parse(tabela.Rows[linha]["STATUS"].ToString());
            retorno.Nome = tabela.Rows[linha]["NOME"].ToString();
            retorno.Senha = int.Parse(tabela.Rows[linha]["SENHA"].ToString());

            return retorno;
        }

        public List<Usuario> ConsulteTodosUsuarios()
        {
            string ComandoSQL = String.Format("SELECT {0} FROM {1}", ColunasUsuario, "USUARIOS");

            DataTable tabela;
            try
            {
                using (var GSBancoDeDados = new GSBancoDeDados())
                    tabela = GSBancoDeDados.ExecuteConsulta(ComandoSQL);

                if (tabela == null)
                    return null;

                var listaRetorno = new List<Usuario>();
                for (int linha = 0; linha < tabela.Rows.Count; linha++)
                {
                    listaRetorno.Add(MonteRetornoUsuario(tabela, linha));
                }

                return listaRetorno;
            }
            catch (System.Exception)
            {
                return null;
                throw;
            }
        }

        private string ColunasInteracoes => string.Join(", ", this.ColunasETiposDeDadosInteracoes.Keys);

        private Dictionary<string, Type> ColunasETiposDeDadosInteracoes
        =>
        new Dictionary<string, Type>()
        {
            { "CODIGO", typeof(int)},
            { "HORARIO", typeof(DateTime)},
            { "TIPO", typeof(bool)},
            { "OBSERVACOES", typeof(string)},
            { "CODIGO_PRODUTO", typeof(int) },
            { "QUANTIDADE", typeof(int) },
            { "VALOR", typeof(decimal) },
            { "ATUALIZARVALORNOCATALOGO", typeof(bool)},
            { "ORIGEM", typeof(string) },
            { "DESTINO", typeof(string) },
            { "NUMERODANOTAFISCAL", typeof(string) },
            { "INFORMA_NUMERO_DE_SERIE", typeof(bool) },
            { "QUANTIDADE_AUX", typeof(int) },
            { "HORARIO_PROGRAMADO", typeof(DateTime) }
        };

        public bool IsRendering { get; set; }

        private Interacao MonteRetornoInteracoes(DataTable tabela, int linha)
        {
            var retorno = new Interacao();

            retorno.Codigo = int.Parse(tabela.Rows[linha]["CODIGO"].ToString());
            retorno.TipoDeInteracao = (EnumTipoDeInteracao)int.Parse(tabela.Rows[linha]["TIPO"].ToString());
            retorno.Observacao = tabela.Rows[linha]["OBSERVACOES"] != DBNull.Value
                               ? tabela.Rows[linha]["OBSERVACOES"].ToString()
                               : null;
            retorno.QuantidadeInterada = int.Parse(tabela.Rows[linha]["QUANTIDADE"].ToString());
            retorno.QuantidadeAuxiliar = tabela.Rows[linha]["QUANTIDADE_AUX"] != DBNull.Value
                                       ? int.Parse(tabela.Rows[linha]["QUANTIDADE_AUX"].ToString())
                                      : new int?();
            retorno.ValorInteracao = decimal.Parse(tabela.Rows[linha]["VALOR"].ToString());
            retorno.AtualizarValorDoProdutoNoCatalogo = GSUtilitarios.ConvertaValorBooleano(tabela.Rows[linha]["ATUALIZARVALORNOCATALOGO"].ToString());
            retorno.Origem = tabela.Rows[linha]["ORIGEM"] != DBNull.Value
                           ? tabela.Rows[linha]["ORIGEM"].ToString()
                           : null;
            retorno.Destino = tabela.Rows[linha]["DESTINO"] != DBNull.Value
                            ? tabela.Rows[linha]["DESTINO"].ToString()
                            : null;
            retorno.Horario = (DateTime)tabela.Rows[linha]["HORARIO"];
            retorno.NumeroDaNota = tabela.Rows[linha]["NUMERODANOTAFISCAL"].ToString() != "NULL"
                                 ? tabela.Rows[linha]["NUMERODANOTAFISCAL"].ToString()
                                 : null;
            retorno.InformaNumeroDeSerie = GSUtilitarios.ConvertaValorBooleano(tabela.Rows[linha]["INFORMA_NUMERO_DE_SERIE"].ToString());
            retorno.HorarioProgramado = (DateTime)tabela.Rows[linha]["HORARIO"];

            retorno.Produto = ConsulteProduto(int.Parse(tabela.Rows[linha]["CODIGO_PRODUTO"].ToString()), retorno.HorarioProgramado);

            return retorno;
        }

        public List<Interacao> ConsulteTodasAsInteracoes()
        {
            string ComandoSQL = $"SELECT {ColunasInteracoes} " +
                                "FROM INTERACOES " + 
                                "ORDER BY HORARIO DESC";

            try
            {
                DataTable tabela;
                using (var GSBancoDeDados = new GSBancoDeDados())
                    tabela = GSBancoDeDados.ExecuteConsulta(ComandoSQL);

                if (tabela == null)
                    return null;


                var listaRetorno = new List<Interacao>();
                for (int linha = 0; linha < tabela.Rows.Count; linha++)
                {
                    listaRetorno.Add(MonteRetornoInteracoes(tabela, linha));
                }

                return listaRetorno;
            }
            catch (Exception)
            {
                return null;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (SessaoSistema.IsMain)
            {
                txtUsuario.Text = "junio.moraes";
                txtSenha.Text = "Mega280271@";

                btnEntrar_Click_1(btnEntrar, e);

                WindowState = FormWindowState.Minimized;

                var estoque = new FrmEstoque { WindowState = FormWindowState.Maximized };
                estoque.Show();
            }
            else if (SessaoSistema.WorkTestMode)
            {
                txtUsuario.Text = "admin";
                txtSenha.Text = "admin";

                btnEntrar_Click_1(btnEntrar, e);

                GerenciadorDeViews.ObtenhaPrincipal().WindowState = FormWindowState.Minimized;
                GerenciadorDeViews.Crie<InteracaoPresenter>().View.Show();

                #region Usable

                //using (var servicoDeUsuario = new ServicoDeUsuario())
                //{
                //    servicoDeUsuario.Insira("ana.paula", "M4044");
                //}

                //var i = 0;
                //Parallel.ForEach(prods, x =>
                //{
                //    i++;
                //    var newProd = new Produto(x);
                //    newProd.Vigencia = DateTime.Now;
                //    repoProd.Atualize(newProd);
                //});
                //var repoCfg = new RepositorioDeConfiguracao();
                //var cfg = repoCfg.ObtenhaUnica();
                //if (cfg == null)
                //{
                //    repoCfg.Insira(new Configuracoes
                //    {
                //        Codigo = 1,
                //        PorcentagemDeLucroPadrao = (decimal)0.4,
                //        PorcentagemImpostoProtege = (decimal)0.0449
                //    });
                //}

                //using (var ds = new GSDocumentStore())
                //{
                //    ds.Initialize();
                //    using (var sessao = ds.OpenSession("GestaoEmpresa"))
                //    {
                //        var todosOsProdutos = sessao.Query<Interacao>().ToList();
                //        foreach (var t in todosOsProdutos)
                //        {
                //            t.Produto.Nome = t.Produto.Nome.ToCustomTitleCase();
                //        }

                //        sessao.SaveChanges();
                //    }
                //}

                //using (var servico = new ServicoDeProduto())
                //{
                //    servico.ImportePlanilhaIntelbras(@"C:\Users\gusta\Documents\Tabela.xlsb").ContinueWithTask(() =>
                //    {
                //        Console.WriteLine("Completado com sucesso");
                //        return Task.CompletedTask;
                //    });
                //}

                //var estoque = new FrmEstoque { WindowState = FormWindowState.Maximized };
                //estoque.Show();

                #endregion
            }
        }

        #endregion

    }
}
