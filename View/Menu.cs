using Models;
using Controllers;

namespace Views
{
    public class Menu{
        
        public static void index(){
            Form menu = new Form();
            
            menu.Text = "Menu";
            menu.Size = new Size(300, 300);
            menu.StartPosition = FormStartPosition.CenterScreen;
            menu.FormBorderStyle = FormBorderStyle.FixedSingle;
            menu.MaximizeBox = false;
            menu.MinimizeBox = false;
            menu.ShowIcon = false;
            menu.ShowInTaskbar = false;

            Button btPrt = new Button();
            btPrt.Text = "Produto";
            btPrt.Size = new Size(100, 30);
            btPrt.Location = new Point(100, 100);
            btPrt.Click += (sender, e) => {
                menu.Hide();
                var listProduto = new ListProduto();
                menu.Show();
            };

            Button btAlm = new Button();
            btAlm.Text = "Almoxarifado";
            btAlm.Size = new Size(100, 30);
            btAlm.Location = new Point(100, 150);
            btAlm.Click += (sender, e) => {
                menu.Hide();
                var listAlmoxarifado = new ListAlmoxarifado();
                listAlmoxarifado.ShowDialog();
                menu.Show();
            };

            Button btSd = new Button();
            btSd.Text = "Saldo";
            btSd.Size = new Size(100, 30);
            btSd.Location = new Point(100, 200);
            btSd.Click += (sender, e) => {
                menu.Hide();
                var listSaldo = new ListSaldo();
                menu.Show();
            };

            Button sair = new Button();
            sair.Text = "Sair";
            sair.Size = new Size(100, 30);
            sair.Location = new Point(100, 250);
            sair.Click += (sender, e) => {
                menu.Close();
            };

            menu.Controls.Add(btPrt);
            menu.Controls.Add(btAlm);
            menu.Controls.Add(btSd);
            menu.Controls.Add(sair);
            menu.ShowDialog();
        }
    }
}