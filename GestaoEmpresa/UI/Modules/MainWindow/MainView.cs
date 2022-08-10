using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GS.GestaoEmpresa.Business.Enumerators.Default;
using GS.GestaoEmpresa.Business.Objects.Base;
using GS.GestaoEmpresa.Business.Objects.Core;
using GS.GestaoEmpresa.Business.Services;
using GS.GestaoEmpresa.Persistence.Repositories;
using GS.GestaoEmpresa.Properties;
using GS.GestaoEmpresa.Solucao.Negocio.Catalogos;
using GS.GestaoEmpresa.Solucao.Negocio.Enumeradores.Comuns;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using GS.GestaoEmpresa.Solucao.Persistencia.BancoDeDados;
using GS.GestaoEmpresa.Solucao.UI;
using GS.GestaoEmpresa.Solucao.UI.Base;
using GS.GestaoEmpresa.Solucao.UI.ControlesGenericos;
using GS.GestaoEmpresa.Solucao.UI.Modulos.Atendimento;
using GS.GestaoEmpresa.Solucao.UI.Modulos.Estoque;
using GS.GestaoEmpresa.Solucao.UI.Modulos.Tecnico;
using GS.GestaoEmpresa.Solucao.Utilitarios;
using GS.GestaoEmpresa.UI.Base;
using GS.GestaoEmpresa.UI.GenericControls;
using GS.GestaoEmpresa.UI.Modules.Storage.Interaction;
using GS.GestaoEmpresa.UI.Modules.Storage.Storage;
using MetroFramework.Forms;

namespace GS.GestaoEmpresa.UI.Modules.MainWindow
{
    public partial class MainView : MetroForm, IView
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

        public FormType FormType { get; set; }


        #region Constantes

        public const string DiretorioLocal = @".\";

        public const string NomeArquivoConfiguracoesBanco = "ConexaoBanco.txt";

        #endregion

        #region Métodos

        public MainView()
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
           SessaoSistema.InformacoesConexao = SessaoSistema.BusqueConfiguracoesConexaoDoArquivo(DiretorioLocal, NomeArquivoConfiguracoesBanco);

            if (SessaoSistema.InformacoesConexao == null)
            {
                MessageBox.Show(Mensagens.NAO_HA_CONFIGURACOES_BANCO);
                return;
            }

            txtConfigServer.Text = SessaoSistema.InformacoesConexao.Server;
            txtConfigDatabaseName.Text = SessaoSistema.InformacoesConexao.DatabaseName;
        }

        private async Task CarregueChamador()
        {
            tabControl1.SelectTab("tabChamador");
            btnTecnico.Enabled = false;

            btnCorporativo.Enabled = false;
            btnAuditoria.Enabled = false;

            var userRepository = new UserRepository();
            var user = await userRepository.QueryFirstAsync(SessaoSistema.CodigoUsuario);

            txtPermissaoUsuario.Text = user.Name;
            //txtPermissaoFuncao.Text = usuario.Funcionario.Function ?? "---";
            //txtPermissaoGrupo.Text = usuario.Grupo.Nome ?? "---";
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
                SessaoSistema.BusqueConfiguracoesConexaoDoArquivo(DiretorioLocal, NomeArquivoConfiguracoesBanco);
            }

            lblIpApp.Text = GSUtils.ObtenhaIPLocal();

            if (SessaoSistema.InformacoesConexao != null)
            {
                lblIpBanco.Text = SessaoSistema.InformacoesConexao.Server;
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

        // Evento Load
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
            var informacoesConexaoBanco = new DatabaseConnection()
            {
                Server = txtConfigServer.Text.Trim(),
                DatabaseName = txtConfigDatabaseName.Text.Trim()
            };

            SessaoSistema.SalveConfiguracoesConexaoNoArquivo(informacoesConexaoBanco, DiretorioLocal, NomeArquivoConfiguracoesBanco);

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

        private async void btnEntrar_Click_1(object sender, EventArgs e)
        {
            using var servicoDeUsuario = new UserService();

            var usuario = await servicoDeUsuario.Query(txtUsuario.Text.Trim());
            if (usuario != null)
            {
                if (usuario.Password == txtSenha.Text.Trim().GetDeterministicHashCode())
                {
                    tabControl1.SelectTab("tabChamador");
                    //GerenciadorAbas.ChamadorAtivo = true;
                    lblConfiguracoesBasicas.Visible = false;

                    //Dados da sessão do sistema
                    SessaoSistema.Iniciada = true;
                    SessaoSistema.CodigoUsuario = usuario.Code;
                    SessaoSistema.NomeUsuario = usuario.Name;

                    txtPermissaoUsuario.Text = usuario.Name;
                    //txtPermissaoFuncao.Text = usuario.Funcionario.Function ?? "---";
                    //txtPermissaoGrupo.Text = usuario.GrupoUsuario == null ? "---" : usuario.GrupoUsuario.Nome;

                    SessaoSistema.VerificarStatusDaConexao = false;
                    SessaoSistema.UISettings = usuario.UISettings ?? new UISettings();
                    return;
                }
            }

            txtSenha.Clear();
            MessageBox.Show("Usuário ou senha incorretos");
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
                    view = ViewManager.CreateIndependent<StorageView>();
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
            //ViewManager.Delete<frmPrincipal>(InstanceId);
        }

        #region Migração

        //private void Label15_Click(object sender, EventArgs e)
        //{
        //    var serverRaven = SessaoSistema.InformacoesConexao.Server;
        //    var nomeBancoRaven = SessaoSistema.InformacoesConexao.DatabaseName;

        //    var informacoesConexaoBancoSQL = new InformacoesConexaoBanco
        //    {
        //        //Server = Interaction.InputBox("Endereço BD SQL", "Migração de dados", ""),
        //        //DatabaseName = Interaction.InputBox("Nome banco", "Migração de dados", ""),
        //        //Usuario = Interaction.InputBox("Usuario", "Migração de dados", ""),
        //        //Senha = Interaction.InputBox("Senha", "Migração de dados", ""),
        //        //TipoDeBanco = EnumTipoDeBanco.SQLSERVER
        //    };

        //    SessaoSistema.InformacoesConexao = informacoesConexaoBancoSQL;

        //    MessageBox.Show("Consultando...");

        //    var listaProdutosRaven = new List<Produto>();
        //    var listaUsuariosRaven = new List<User>();
        //    var listaInteracoesRaven = new List<Interaction>();

        //    var ultimasVigenciasDeProduto = ConsulteTodosProdutosSql();

        //    Parallel.ForEach(ultimasVigenciasDeProduto, ultimaVigencia =>
        //    {
        //        var todasVigencias = ConsulteTodasVigenciasProduto(ultimaVigencia.Codigo);
                
        //        todasVigencias = todasVigencias.OrderBy(x => x).ToList();

        //        foreach (var vigencia in todasVigencias)
        //        {
        //            var produtoConsultado = ConsulteProduto(ultimaVigencia.Codigo, vigencia);
        //            produtoConsultado.RevisionStartDateTime = vigencia;

        //            if (vigencia == todasVigencias.LastOrDefault())
        //            {
        //                produtoConsultado.Atual = true;
        //            }

        //            listaProdutosRaven.Add(produtoConsultado);
        //        }
        //    });

        //    listaUsuariosRaven.AddRange(ConsulteTodosUsuarios());

        //    var informacoesConexaoBancoRaven = new InformacoesConexaoBanco
        //    {
        //        Server = serverRaven,
        //        DatabaseName = nomeBancoRaven,
        //        TipoDeBanco = EnumTipoDeBanco.RAVENDB
        //    };

        //    SessaoSistema.InformacoesConexao = informacoesConexaoBancoRaven;

        //    MessageBox.Show("Salvando...");

        //    var userRepository = new UserRepository();
        //    var productRepository = new RepositorioDeProduto();

        //    listaUsuariosRaven.ForEach(x => userRepository.Insert(x));
        //    //listaInteracoesRaven.ForEach(x => repoInteracao.Insira(x));

        //    listaProdutosRaven.GroupBy(x => x.Codigo).ToList().ForEach(grupo =>
        //    {
        //        var lista = grupo.OrderBy(x => x.RevisionStartDateTime).ToList();

        //        productRepository.Insira(lista.FirstOrDefault());

        //        lista.Remove(lista.FirstOrDefault());
        //        lista.ForEach(x => productRepository.Atualize(x));
        //    });

        //    SessaoSistema.InformacoesConexao = informacoesConexaoBancoSQL;
        //    var listaInteracoes = ConsulteTodasAsInteracoes();
        //    listaInteracoesRaven.AddRange(listaInteracoes.OrderBy(x => x.ScheduledTime));

        //    SessaoSistema.InformacoesConexao = informacoesConexaoBancoRaven;

        //    var repoInteracao = new InteractionRepository();
        //    listaInteracoesRaven.ForEach(x => repoInteracao.Insert(x));

        //    MessageBox.Show("Concluído!");
        //}

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
            retorno.AvisarQuantidade = GSUtils.ConvertaValorBooleano(tabela.Rows[linha]["AVISARQUANTIDADE"].ToString());
            retorno.QuantidadeMinimaParaAviso = int.Parse(tabela.Rows[linha]["QUANTIDADEMINIMAAVISO"].ToString());
            retorno.Observacao = tabela.Rows[linha]["OBSERVACAO"] != DBNull.Value
                               ? tabela.Rows[linha]["OBSERVACAO"].ToString()
                               : null;

            return retorno;
        }


        public bool IsRendering { get; set; }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (SessaoSistema.IsMain)
            {
                txtUsuario.Text = "junio.moraes";
                txtSenha.Text = "Mega280271@";

                btnEntrar_Click_1(btnEntrar, e);

                WindowState = FormWindowState.Minimized;

                var estoque = new StorageView { WindowState = FormWindowState.Maximized };
                estoque.Show();
            }
            else if (SessaoSistema.WorkTestMode)
            {
                txtUsuario.Text = "admin";
                txtSenha.Text = "admin";

                btnEntrar_Click_1(btnEntrar, e);

                WindowState = FormWindowState.Minimized;

                var estoque = new StorageView { WindowState = FormWindowState.Maximized };
                estoque.Show();

                //ViewManager.GetMain().WindowState = FormWindowState.Minimized;
                //new frmInteracao().Show();
                //ViewManager.Create<InteractionPresenter>().View.Show();

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
                //    newProd.RevisionStartDateTime = DateTime.Now;
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
                //    servico.ImportIntelbrasSpreadsheet(@"C:\Users\gusta\Documents\Tabela.xlsb").ContinueWithTask(() =>
                //    {
                //        Console.WriteLine("Completado com sucesso");
                //        return Task.CompletedTask;
                //    });
                //}

                //var estoque = new StorageView { WindowState = FormWindowState.Maximized };
                //estoque.Show();

                #endregion
            }
        }

        #endregion

    }
}
