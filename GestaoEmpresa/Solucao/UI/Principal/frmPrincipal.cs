using GS.GestaoEmpresa.Properties;
using GS.GestaoEmpresa.Solucao.Persistencia.BancoDeDados;
using GS.GestaoEmpresa.Solucao.Persistencia.Repositorios;
using GS.GestaoEmpresa.Solucao.Negocio.Catalogos;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using GS.GestaoEmpresa.Solucao.Negocio.Servicos;
using GS.GestaoEmpresa.Solucao.UI.Modulos.Configuracoes;
using GS.GestaoEmpresa.Solucao.UI.Modulos.Estoque;
using GS.GestaoEmpresa.Solucao.Utilitarios;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using GS.GestaoEmpresa.Solucao.UI.Modulos.Tecnico;

namespace GestaoEmpresa.GS.GestaoEmpresa.GS.GestaoEmpresa.UI.Principal
{
    public partial class frmPrincipal : Form
    {

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
            //lblConfiguracoesBasicas.Location = new Point(this.ClientSize.Width - 80, 15);
            this.EscondaHeadersTabControl(tabControl1);
            this.CentralizeTabControl(tabControl1);

            // Habilitamos a visibilidade
            tabControl1.Visible = true;
            if (!SessaoSistema.Iniciada)
                lblConfiguracoesBasicas.Visible = true;

        }

        private void CarregueConfiguracoesConexaoBanco()
        {
           SessaoSistema.InformacoesConexao = SessaoSistema.BusqueConfiguracoesConexaoDoArquivo(DIRETORIO_LOCAL, NOME_ARQUIVO_CONFIGURACOES_BANCO);

            if (SessaoSistema.InformacoesConexao == null)
            {
                MessageBox.Show(Mensagens.NAO_HA_CONFIGURACOES_BANCO());
                return;
            }

            txtServidorConfiguracao.Text = SessaoSistema.InformacoesConexao.Servidor;
            txtNomeBancoConfiguracoes.Text = SessaoSistema.InformacoesConexao.NomeBanco;
            txtUsuarioConfiguracao.Text = SessaoSistema.InformacoesConexao.Usuario;
            txtSenhaConfiguracao.Text = SessaoSistema.InformacoesConexao.Senha;
        }

        private void CarregueChamador()
        {
            tabControl1.SelectTab("tabChamador");

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
            tabControl.Left = (this.ClientSize.Width - tabControl1.Width) / 2;
            tabControl.Top = (this.ClientSize.Height - tabControl1.Height) / 2;
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

            Action acao =
                () =>
                {
                    while (SessaoSistema.VerificarStatusDaConexao)
                    {
                        if (SessaoSistema.ConexaoAtiva)
                        {
                            pictureBox5.Invoke((MethodInvoker)delegate
                            {
                                pictureBox5.BackgroundImage = Resources.Conexao;
                                btnEntrar.Enabled = true;
                            });
                        }
                        else
                        {
                            pictureBox5.Invoke((MethodInvoker)delegate
                            {
                                pictureBox5.BackgroundImage = Resources.SemConexao;
                                btnEntrar.Enabled = false;
                            });
                        }

                        Thread.Sleep(350);
                    }

                    return;
                };

            GSTarefasAssincronas.ExecuteTarefaAssincrona(acao);
        }

        #endregion


        #region Eventos

        //Evento Load
        private void GestaoEmpresa_Load(object sender, EventArgs e)
        {
            AjustePosicaoControlsDinamicamente();

            if (SessaoSistema.Iniciada)
                CarregueChamador();
            else
                CarregueLogin();

            txtUsuario.Select();

            CarregueConfiguracoesConexaoBanco();
            SessaoSistema.InicieVerificacaoDeConexao();

            InicieVerificacaoParaAtualizarStatusDeConexao();
        }

        //Creio eu que esses não são mais usados, confirmar e excluir
        private void label13_Click(object sender, EventArgs e)
        {
            lblConfiguracoesBasicas.Visible = true;
            gbConfiguracoesBasicas.Visible = false;

            panelConexao.Location = new Point(557, 22);

            this.CarregueConfiguracoesConexaoBanco();
        }

        private void btnSalvarConfiguracaoBasica_Click(object sender, EventArgs e)
        {
            var informacoesConexaoBanco = new InformacoesConexaoBanco()
            {
                Servidor = txtServidorConfiguracao.Text.Trim(),
                NomeBanco = txtNomeBancoConfiguracoes.Text.Trim(),
                Usuario = txtUsuarioConfiguracao.Text.Trim(),
                Senha = txtSenhaConfiguracao.Text.Trim()
            };


            SessaoSistema.SalveConfiguracoesConexaoNoArquivo(informacoesConexaoBanco,
                                                                  DIRETORIO_LOCAL,
                                                                  NOME_ARQUIVO_CONFIGURACOES_BANCO);

            this.CarregueConfiguracoesConexaoBanco();
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
                    if (usuario.Senha == txtSenha.Text.Trim().GetHashCode())
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
            new frmEstoque().Show();
        }

        private void txtSenha_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.Equals('\r') || e.KeyChar.Equals(Keys.Return) || e.KeyChar.Equals(Keys.Return))
            {
                btnEntrar_Click_1(sender, e);
            }
        }

        private void btnTecnico_Click(object sender, EventArgs e)
        {
            new frmTecnico().Show();
        }
    }
}
