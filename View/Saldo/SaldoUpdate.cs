using Models;
using Controllers;
using static Views.SaldoView;

namespace Views{

    public class SaldoUpdate : Form{

        public Label lblNome;
        public TextBox txtNome;
        public Label lblAlmoxarifado;
        public TextBox txtAlmoxarifado;
        public Label lblQuantidade;
        public TextBox txtQuantidade;
        public Button btCadt;

        private void btCadt_Click(object sender, EventArgs e){

            SaldoModels saldoToEdit = this.saldo;
            saldoToEdit.nome = this.txtNome.Text;

            SaldoController.Update(saldoToEdit);
            MessageBox.Show("Saldo foi modificado com sucesso!");

            ListSaldo listSaldo = Application.OpenForms.OfType<ListSaldo>().FirstOrDefault();
            if(saldo != null)
            {
                saldo.RefreshList();
            }
            this.Close();
        }

        public SaldoUpdate(SaldoModels saldo){

            this.lblNome = new Label();
            this.lblNome.Text = "Nome";
            this.lblNome.Location = new System.Drawing.Point(10, 40);
            this.lblNome.Size = new System.Drawing.Size(50, 20);

            this.txtNome = new TextBox();
            this.txtNome.Location = new System.Drawing.Point(80, 40);
            this.txtNome.Size = new System.Drawing.Size(150, 20);

            this.lblAlmoxarifado = new Label();
            this.lblAlmoxarifado.Text = "Almoxarifado";
            this.lblAlmoxarifado.Location = new System.Drawing.Point(10, 80);
            this.lblAlmoxarifado.Size = new System.Drawing.Size(50, 20);

            this.txtAlmoxarifado = new TextBox();
            this.txtAlmoxarifado.Location = new System.Drawing.Point(80, 80);
            this.txtAlmoxarifado.Size = new System.Drawing.Size(150, 20);

            this.lblQuantidade = new Label();
            this.lblQuantidade.Text = "Quantidade";
            this.lblQuantidade.Location = new System.Drawing.Point(10, 120);
            this.lblQuantidade.Size = new System.Drawing.Size(50, 20);

            this.txtQuantidade = new TextBox();
            this.txtQuantidade.Location = new System.Drawing.Point(80, 120);
            this.txtQuantidade.Size = new System.Drawing.Size(150, 20);

            this.btCadt = new Button();
            this.btCadt.Location = new System.Drawing.Point(10, 160);
            this.btCadt.Size = new System.Drawing.Size(75, 23);
            this.btCadt.Click += new EventHandler(this.btCadt_Click);

            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lblAlmoxarifado);
            this.Controls.Add(this.txtAlmoxarifado);
            this.Controls.Add(this.lblQuantidade);
            this.Controls.Add(this.txtQuantidade);
            this.Controls.Add(this.btCadt);

        }
    }
}