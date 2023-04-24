namespace Views
{
    public class Saldo : Form
    {
       public Saldo()
       {
           this.Text = "Saldo";
           this.Size = new Size(300, 300);
           this.StartPosition = FormStartPosition.CenterScreen;
           this.FormBorderStyle = FormBorderStyle.FixedSingle;
           this.MinimizeBox = false;
           this.MaximizeBox = false;
           this.ShowIcon = false;
           this.ShowInTaskbar = false;

           Button btCons = new Button();
           btCons.Text = "Consultar";
           btCons.Size = new Size(100, 30);
           btCons.Location = new Point(100, 100);
           btCons.Click += new EventHandler(btCons_Click);
           this.Controls.Add(btCons);

           Button btSair = new Button();
           btSair.Text = "Sair";
           btSair.Size = new Size(100, 30);
           btSair.Location = new Point(100, 150);
           btSair.Click += new EventHandler(btSair_Click);
           this.Controls.Add(btSair);

           this.ShowDialog();
       }
    }
}