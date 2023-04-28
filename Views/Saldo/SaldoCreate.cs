using Controllers;
using Models;

namespace Views{

    public class SaldoCreate : Form
    {
        public Label lblIdProduto;
        public TextBox txtIdProduto;
        public Label lblIdAlmoxarifado;
        public TextBox txtIdAlmoxarifado;
        public Label lblQtd;
        public TextBox txtQtd;
        public Button btCadt;

        public void btCadt_Click(object sender, EventArgs e)
        {
            if(
                txtIdProduto.Text == "" ||
                txtIdAlmoxarifado.Text == "" ||
                txtQtd.Text == "" 
            ){
                MessageBox.Show("Preencha corretamente os campos");
                return;
            }else
            {
                Models.SaldoModels saldo = new SaldoModels(
                    Convert.ToInt32(txtIdProduto.Text),
                    Convert.ToInt32(txtIdAlmoxarifado.Text),
                    Convert.ToInt32(txtQtd.Text)
                );

                SaldoController saldoController = new SaldoController();
                Controllers.SaldoController.Create(saldo);

                MessageBox.Show("Saldo cadastrado com sucesso");
                ClearForm();
            }

            ListSaldo SaldoList = Application.OpenForms.OfType<ListSaldo>().FirstOrDefault();
            if(SaldoList!= null)
            {
                SaldoList.RefreshList();
            }
            this.Close();
        }

        private void ClearForm()
        {
            txtIdProduto.Clear();
            txtIdAlmoxarifado.Clear();
            txtQtd.Clear();
        }

        public SaldoCreate()
        {
            this.Text = "Registrar Saldo";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Size = new System.Drawing.Size(280, 360);

            this.lblIdProduto = new Label();
            this.lblIdProduto.Text = "Id do Produto";
            this.lblIdProduto.Location = new Point(10, 40);
            this.lblIdProduto.Size = new Size(50, 20);

            this.txtIdProduto = new TextBox();
            this.txtIdProduto.Location = new Point(80, 40);
            this.txtIdProduto.Size = new Size(150, 20);

            this.lblIdAlmoxarifado = new Label();
            this.lblIdAlmoxarifado.Text = "Id do Almoxarifado";
            this.lblIdAlmoxarifado.Location = new Point(10, 70);
            this.lblIdAlmoxarifado.Size = new Size(50, 20);

            this.txtIdAlmoxarifado = new TextBox();
            this.txtIdAlmoxarifado.Location = new Point(80, 70);
            this.txtIdAlmoxarifado.Size = new Size(150, 20);

            this.lblQtd = new Label();
            this.lblQtd.Text = "Quantidade";
            this.lblQtd.Location = new Point(10, 100);
            this.lblQtd.Size = new Size(50, 20);

            this.txtQtd = new TextBox();
            this.txtQtd.Location = new Point(80, 100);
            this.txtQtd.Size = new Size(70, 20);

            this.btCadt = new Button();
            this.btCadt.Text = "Cadastrar";
            this.btCadt.Location = new Point(10, 130);
            this.btCadt.Size = new Size(100, 20);
            this.btCadt.Click += btCadt_Click;

            this.Controls.Add(this.lblIdProduto);
            this.Controls.Add(this.txtIdProduto);
            this.Controls.Add(this.lblIdAlmoxarifado);
            this.Controls.Add(this.txtIdAlmoxarifado);
            this.Controls.Add(this.lblQtd);
            this.Controls.Add(this.txtQtd);
            this.Controls.Add(this.btCadt);
        }
    }
}