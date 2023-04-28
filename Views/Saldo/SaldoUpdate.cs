using Models;
using Controllers;

namespace Views{

    public class SaldoUpdate : Form{

        public Label lblIdProduto;
        public TextBox txtIdProduto;
        public Label lblIdAlmoxarifado;
        public TextBox txtIdAlmoxarifado;
        public Label lblQtd;
        public TextBox txtQtd;
        public Button btUpdate;


        public SaldoModels saldo;

        private void btUpdate_Click(object sender, EventArgs e)
        {
            SaldoModels saldoToUpdate = this.saldo;
            saldoToUpdate.idProduto = Convert.ToInt32(this.txtIdProduto.Text);
            saldoToUpdate.idAlmoxarifado = Convert.ToInt32(this.txtIdAlmoxarifado.Text);
            saldoToUpdate.qtd = Convert.ToInt32(this.txtQtd.Text);

            if
            (
                saldoToUpdate.idProduto.ToString() == "" ||
                saldoToUpdate.idAlmoxarifado.ToString() == "" ||
                saldoToUpdate.qtd.ToString() == ""
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
                if (SaldoList != null)
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

            this.lblIdProduto = new Label();
            this.lblIdProduto.Text = "Id do Produto";
            this.lblIdProduto.Location = new Point(10, 40);
            this.lblIdProduto.Size = new Size(50, 20);
            this.Controls.Add(this.lblIdProduto);

            this.txtIdProduto = new TextBox();
            this.txtIdProduto.Text = saldo.idProduto.ToString();
            this.txtIdProduto.Location = new System.Drawing.Point(80, 40);
            this.txtIdProduto.Size = new System.Drawing.Size(150, 20);
            this.Controls.Add(this.txtIdProduto);

            this.lblIdAlmoxarifado = new Label();
            this.lblIdAlmoxarifado.Text = "Almoxarifado";
            this.lblIdAlmoxarifado.Location = new Point(10, 70);
            this.lblIdAlmoxarifado.Size = new Size(50, 20);
            this.Controls.Add(this.lblIdAlmoxarifado);

            this.txtIdAlmoxarifado = new TextBox();
            this.txtIdAlmoxarifado.Text = saldo.idAlmoxarifado.ToString();
            this.txtIdAlmoxarifado.Location = new System.Drawing.Point(80, 70);
            this.txtIdAlmoxarifado.Size = new System.Drawing.Size(150, 20);
            this.Controls.Add(this.txtIdAlmoxarifado);

            this.lblQtd = new Label();
            this.lblQtd.Text = "Quantidade";
            this.lblQtd.Location = new Point(10, 100);
            this.lblQtd.Size = new Size(50, 20);
            this.Controls.Add(this.lblQtd);

            this.txtQtd = new TextBox();
            this.txtQtd.Text = saldo.qtd.ToString();
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