using Models;
using Controllers;

namespace Views{

    public class SaldoUpdate : Form{

        public Label lblNome;
        public TextBox txtNome;
        public Label lblAlmoxarifado;
        public TextBox txtAlmoxarifado;
        public Label lblQtd;
        public TextBox txtQtd;
        public Button btUpdate;


        public SaldoModels saldo;

        private void btUpdate_Click(object sender, EventArgs e)
        {
            SaldoModels saldoToUpdate = this.saldo;
            saldoToUpdate.nome = this.txtNome.Text;
            saldoToUpdate.almoxarifado = this.txtAlmoxarifado.Text;
            saldoToUpdate.qtd = this.txtQtd.Text;

            if
            (
                saldoToUpdate.nome == "" ||
                saldoToUpdate.almoxarifado == "" ||
                saldoToUpdate.qtd == ""
            )
                {
                    MessageBox.Show("Preencha corretamente os campos");
                    return;
                }
                else
                {
                    SaldoController.Update(saldoToUpdate);
                    MessageBox.Show("Saldo foi editado com sucesso");
                }

                ListSaldo SaldoList = Application.OpenForms.OfType<ListSaldo>().FirstOrDefault();
                if (SaldoList!= null)
                {
                    SaldoList.RefreshList();
                }
                this.Close();
        }

        public SaldoUpdate(SaldoModels saldo)
        {
            this.saldo = saldo;

            this.Text = "Editar Saldo";
            this.Size = new System.Drawing.Size(280, 360);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowIcon = false;

            this.lblNome = new Label();
            this.lblNome.Text = "Nome";
            this.lblNome.Location = new Point(10, 40);
            this.lblNome.Size = new Size(50, 20);
            this.Controls.Add(this.lblNome);

            this.txtNome = new TextBox();
            this.txtNome.Text = saldo.nome;
            this.txtNome.Location = new System.Drawing.Point(80, 40);
            this.txtNome.Size = new System.Drawing.Size(150, 20);
            this.Controls.Add(this.txtNome);

            this.lblAlmoxarifado = new Label();
            this.lblAlmoxarifado.Text = "Almoxarifado";
            this.lblAlmoxarifado.Location = new Point(10, 70);
            this.lblAlmoxarifado.Size = new Size(50, 20);
            this.Controls.Add(this.lblAlmoxarifado);

            this.txtAlmoxarifado = new TextBox();
            this.txtAlmoxarifado.Text = saldo.almoxarifado;
            this.txtAlmoxarifado.Location = new System.Drawing.Point(80, 70);
            this.txtAlmoxarifado.Size = new System.Drawing.Size(150, 20);
            this.Controls.Add(this.txtAlmoxarifado);

            this.lblQtd = new Label();
            this.lblQtd.Text = "Quantidade";
            this.lblQtd.Location = new Point(10, 100);
            this.lblQtd.Size = new Size(50, 20);
            this.Controls.Add(this.lblQtd);

            this.txtQtd = new TextBox();
            this.txtQtd.Text = saldo.qtd;
            this.txtQtd.Location = new System.Drawing.Point(80, 100);
            this.txtQtd.Size = new System.Drawing.Size(150, 20);
            this.Controls.Add(this.txtQtd);

            this.btUpdate = new Button();
            this.btUpdate.Text = "Editar";
            this.btUpdate.Location = new System.Drawing.Point(80, 260);
            this.btUpdate.Size = new System.Drawing.Size(150, 35);
            this.btUpdate.Click += new EventHandler(btUpdate_Click);
            this.Controls.Add(this.btUpdate);
        }
    }
}