using Controllers;
using Models;

namespace Views{

    public class SaldoCreate : Form
    {
        public Label lblNome;
        public TextBox txtNome;
        public Label lblAlmoxarifado;
        public TextBox txtAlmoxarifado;
        public Label lblQtd;
        public TextBox txtQtd;
        public Button btCadt;

        public void btCadt_Click(object sender, EventArgs e)
        {
            if(
                txtNome.Text == "" ||
                txtAlmoxarifado.Text == "" ||
                txtQtd.Text == "" 
            ){
                MessageBox.Show("Preencha corretamente os campos");
                return;
            }else
            {
                Models.SaldoModels saldo = new SaldoModels(
                    txtNome.Text,
                    txtAlmoxarifado.Text,
                    txtQtd.Text
                );

                SaldoController saldoController = new SaldoController();
                saldoController.Create(saldo);

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
            txtNome.Clear();
            txtAlmoxarifado.Clear();
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

            this.lblNome = new Label();
            this.lblNome.Text = "Nome";
            this.lblNome.Location = new Point(10, 40);
            this.lblNome.Size = new Size(50, 20);

            this.txtNome = new TextBox();
            this.txtNome.Location = new Point(80, 40);
            this.txtNome.Size = new Size(150, 20);

            this.lblAlmoxarifado = new Label();
            this.lblAlmoxarifado.Text = "Almoxarifado";
            this.lblAlmoxarifado.Location = new Point(10, 70);
            this.lblAlmoxarifado.Size = new Size(50, 20);

            this.txtAlmoxarifado = new TextBox();
            this.txtAlmoxarifado.Location = new Point(80, 70);
            this.txtAlmoxarifado.Size = new Size(150, 20);

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
            this.btCadt.Size = new Size(50, 20);

            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lblAlmoxarifado);
            this.Controls.Add(this.txtAlmoxarifado);
            this.Controls.Add(this.lblQtd);
            this.Controls.Add(this.txtQtd);
            this.Controls.Add(this.btCadt);
        }
    }
}