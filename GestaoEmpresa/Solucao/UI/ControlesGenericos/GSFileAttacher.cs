using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;
using System.Security;
using MetroFramework;

namespace GS.GestaoEmpresa.Solucao.UI.ControlesGenericos
{
    public partial class GSFileAttacher : UserControl
    {
        public GSFileAttacher()
        {
            InitializeComponent();
            _addTabPage = tabControl.TabPages["tabAdd"];
        }

        public void Switch(bool enable)
        {
            if (!enable)
            {
                RemoveTabPage(tabControl);
            }
            else
            {
                AddTabPage(tabControl);
            }

            foreach (TabPage tab in tabControl.TabPages)
            {
                var buttons = tab.Controls
                    .OfType<MetroButton>()
                    .Where(x => x.Name != "btnDownload")
                    .ToList();

                foreach (var button in buttons)
                {
                    if (button != null)
                    {
                        button.Visible = enable;
                    }
                }
            }
        }

        public TabPage AddTabPageExternal(TabControl tabControl, TabPage selectedTab, Image image = null, bool addInsteadOfInsert = false)
        {
            var tabName = GetTabName(tabControl);
            var tabPage = GetTabPage(tabName);

            AddAttachButton(tabPage);
            AddDeleteButton(tabPage);
            AddDownloadButton(tabPage);

            AddOrInsertTabPageIntoTabControl(tabControl, selectedTab, tabPage, addInsteadOfInsert);

            tabControl.SelectTab(tabPage);
            tabPage.Focus();

            if (image != null)
            {
                AttachImageToTabPage(tabPage, image);
            }

            return tabPage;
        }

        public void AttachImageToTabPage(TabPage tabPage, Image image)
        {
            var btnAttach = (MetroButton)tabPage.Controls.Find("btnAttach", true).FirstOrDefault();

            btnAttach.Location = new Point(116, 115); //To Do: Make this dynamic for each screen size

            tabPage.BackgroundImageLayout = ImageLayout.Zoom;
            tabPage.BackgroundImage = image;

            tabPage.Focus();
            tabPage.DoubleClick += (sender, e) => tabPage_DoubleClick(sender, e);
        }

        private TabPage _addTabPage { get; set; }

        private void AddTabPage(TabControl tabControl)
        {
            Invoke((MethodInvoker)delegate
            {
                tabControl.TabPages.Add(_addTabPage);
            });
        }

        private void RemoveTabPage(TabControl tabControl)
        {
            var tabPages = tabControl.TabPages.OfType<TabPage>().Where(x => x.Name == "tabAdd");
            foreach (var tabPage in tabPages)
            {
                tabControl.TabPages.Remove(tabPage);
            }
        }

        private void btnAttach_Click(object sender, EventArgs e)
        {
            var dialogResult = openFileDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                // File dialog configured to accept only one file
                foreach (var fileName in openFileDialog.FileNames)
                {
                    try
                    {
                        var image = Image.FromFile(fileName);
                        var btnAttach = (MetroButton)sender;

                        btnAttach.Location = new Point(116, 115); //To Do: Make this dynamic for each screen size
                        var tabPage = (TabPage)btnAttach.Parent;

                        tabPage.BackgroundImageLayout = ImageLayout.Zoom;
                        tabPage.BackgroundImage = image;

                        tabPage.Focus();
                        tabPage.DoubleClick += (sender, e) => tabPage_DoubleClick(sender, e);
                    }
                    catch (SecurityException ex)
                    {
                        // O usuário  não possui permissão para ler arquivos
                        MessageBox.Show("Erro de segurança Contate o administrador de segurança da rede.\n\n" +
                                                    "Mensagem : " + ex.Message + "\n\n" +
                                                    "Detalhes (enviar ao suporte):\n\n" + ex.StackTrace);
                    }
                    catch (Exception ex)
                    {
                        // Não pode carregar a imagem (problemas de permissão)
                        MessageBox.Show("Não é possível exibir a imagem : " + fileName.Substring(fileName.LastIndexOf('\\'))
                                                   + ". Você pode não ter permissão para ler o arquivo , ou " +
                                                   " ele pode estar corrompido.\n\nErro reportado : " + ex.Message);
                    }
                }
            }
        }

        private void tabPage_DoubleClick(object sender, EventArgs e)
        {
            var tabPage = (TabPage)sender;
            if (tabPage.BackgroundImage != null)
            {
                new GSImageVisualizer(tabPage.BackgroundImage).Show();
            }
        }

        private Size _btnDeleteDefaultSize = new Size(21, 23);
        private Point _btnDeleteDefaultPoint = new Point(168, 4);
        private string _btnDeleteDefaultText = "x";

        private Size _btnDownloadDefaultSize = new Size(21, 23);
        private Point _btnDownloadDefaultPoint = new Point(168, 40);
        private string _btnDownloadDefaultText = char.ConvertFromUtf32(0x2193); // Arrow-down key

        private Size _btnAttachDefaultSize = new Size(74, 23);
        private Point _btnAttachDefaultPoint = new Point(54, 58);
        private string _btnAttachDefaultText = "Anexar";

        private void tabControl_Click(object sender, EventArgs e)
        {
            var selectedTab = tabControl.SelectedTab;
            if (selectedTab.Text == "+")
            {
                _ = AddTabPageExternal(tabControl, selectedTab);
            }
        }

        private void AddAttachButton(TabPage tabPage)
        {
            var attachButton = new MetroButton
            {
                Size = _btnAttachDefaultSize,
                Location = _btnAttachDefaultPoint,
                Text = _btnAttachDefaultText,
                Name = "btnAttach"
            };

            attachButton.Click += (sender, e) => btnAttach_Click(sender, e);
            tabPage.Controls.Add(attachButton);
        }

        private void AddDeleteButton(TabPage tabPage)
        {
            var btnDelete = new MetroButton
            {
                Size = _btnDeleteDefaultSize,
                Location = _btnDeleteDefaultPoint,
                Text = _btnDeleteDefaultText,
                Name = "btnDelete"
            };

            btnDelete.Click += (sender, e) =>
            {
                var thisTabCount = Convert.ToInt32(tabPage.Name);
                var tabControl = (TabControl)tabPage.Parent;

                tabControl.TabPages.Remove(tabPage);

                var tabAfterCollection = tabControl.TabPages
                    .OfType<TabPage>()
                    .Where(x => x.Name != "tabAdd")
                    .OrderBy(x => Convert.ToInt32(x.Name));

                var count = 1;
                foreach (var tabPageAfter in tabAfterCollection)
                {
                    tabPageAfter.Name = count.ToString();
                    tabPageAfter.Text = count.ToString();
                    count++;
                }
            };
            tabPage.Controls.Add(btnDelete);
        }

        private void AddDownloadButton(TabPage tabPage)
        {
            var btnDownload = new MetroButton
            {
                Size = _btnDownloadDefaultSize,
                Location = _btnDownloadDefaultPoint,
                Text = _btnDownloadDefaultText,
                FontSize = MetroButtonSize.Tall,
                Name = "btnDownload"
            };

            btnDownload.Click += (sender, e) =>
            {
                var savefile = new SaveFileDialog
                {
                    FileName = $"{tabPage.Name}.png",
                    Filter = "Image files (*.png)|*.png"
                };

                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    tabPage.BackgroundImage.Save(savefile.FileName);
                }
            };

            tabPage.Controls.Add(btnDownload);
        }

        private string GetTabName(TabControl tabControl)
        {
            string tabName = null;
            if (tabControl.TabPages.Count == 0)
            {
                tabName = 1.ToString();
            }
            else
            {
                if (tabControl.TabPages.OfType<TabPage>().Any(x => x.Name == "tabAdd"))
                {
                    tabName = tabControl.TabPages.Count.ToString();
                }
                else
                {
                    tabName = (tabControl.TabPages.Count + 1).ToString();
                }
            }

            return tabName;
        }

        private TabPage GetTabPage(string tabName)
        {
            return new TabPage
            {
                Text = tabName,
                Name = tabName
            };
        }

        private void AddOrInsertTabPageIntoTabControl(TabControl tabControl, TabPage selectedTab, TabPage tabPage, bool addInsteadOfInsert)
        {
            if (selectedTab == null || addInsteadOfInsert)
            {
                tabControl.TabPages.Add(tabPage);
            }
            else
            {
                tabControl.TabPages.Insert(tabControl.TabPages.IndexOf((selectedTab)), tabPage);
            }
        }
    }
}
