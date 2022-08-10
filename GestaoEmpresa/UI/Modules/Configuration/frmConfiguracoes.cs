using GS.GestaoEmpresa.Solucao.Persistencia.Repositorios;
using GS.GestaoEmpresa.Solucao.Negocio.Objetos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GS.GestaoEmpresa.Persistence.Repositories;

namespace GS.GestaoEmpresa.Solucao.UI.Modulos.Configuracoes
{
    public partial class frmConfiguracoes : Form
    {
        public frmConfiguracoes()
        {
            InitializeComponent();
        }

        private async void frmConfiguracoes_Load(object sender, EventArgs e)
        {
            EscondaHeadersTabControl(tabControl1);

            await CarregueUsuarios();
        }

        private async Task CarregueUsuarios()
        {
            var userRepository = new UserRepository();
            var userList = await userRepository.QueryAllAsync();

            foreach(var usuario in userList)
            {
                dgvUsuarios.Rows.Add(usuario.Name/*, usuario.Funcionario.Nome, usuario.Funcionario.Function*/);
            }
        }

        private void EscondaHeadersTabControl(TabControl tabControl)
        {
            tabControl.Appearance = TabAppearance.FlatButtons;
            tabControl.ItemSize = new Size(0, 1);
            tabControl.SizeMode = TabSizeMode.Fixed;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async Task ChameEditarUsuario(int rowIndex)
        {
            var servicoMapeadorUsuario = new UserRepository();

            var nome = dgvUsuarios.Rows[rowIndex]
                                      .Cells["NomeDeUsuario"]
                                      .Value
                                      .ToString().Trim();
            var usuario = await servicoMapeadorUsuario.QueryFirstAsync(x => x.Name == nome);

            //GerenciadorDeForms.Create<frmUsuario>().Show();
        }

        private void tabUsuarios_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        //ChameEditarUsuario(e.RowIndex);
    }
}
