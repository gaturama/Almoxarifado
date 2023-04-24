namespace Views
{
    public class Almoxarifado 
    {
        public static void index()
        {
            Form almoxarifado = new Form();

            almoxarifado.Text = "Almoxarifado";
            almoxarifado.Size = new Size(400, 400);
            almoxarifado.StartPosition = FormStartPosition.CenterScreen;
            almoxarifado.FormBorderStyle = FormBorderStyle.FixedSingle;
            almoxarifado.MaximizeBox = false;
            almoxarifado.MinimizeBox = false;
            almoxarifado.ShowIcon = false;
            almoxarifado.ShowInTaskbar = false;

            Button btPdt = new Button();
            btPdt.Text = "Produto";
            btPdt.Size = new Size(100, 30);
            btPdt.Location = new Point(100, 100);
            btPdt.Click += new EventHandler(btPdt_Click);
            almoxarifado.Controls.Add(btPdt);
            
            Button sair = new Button();
            sair.Text = "Sair";
            sair.Size = new Size(100, 30);
            sair.Location = new Point(100, 150);
            sair.Click += new EventHandler(btSair_Click);
            almoxarifado.Controls.Add(sair);
             
            almoxarifado.ShowDialog();
        }
    }
}