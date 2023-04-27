using Controllers;
using Models;

namespace Views{

    public class ProdutoCreate : Form
    {
        public Label lblNome;
        public TextBox txtNome;
        public Label lblPreco;
        public TextBox txtPreco;
        public Button btCadt;

        public void btCadt_Click(object sender, EventArgs e)
        {
            if(
                txtNome.Text == "" ||
                txtPreco.Text == ""
            ){
                MessageBox.Show("Preencha corretamente os campos");
                return;
            }else
            {
                Models.ProdutoModels produto = new ProdutoModels(
                    txtNome.Text,
                    txtPreco.Text
                );

                ProdutoController produtoController = new ProdutoController();
                produtoController.Create(produto);

                MessageBox.Show("Produto cadastrado com sucesso");
                ClearForm();
            }

            ListProduto ProdutoList = Application.OpenForms.OfType<ListProduto>().FirstOrDefault();
            if(ProdutoList!= null)
            {
                ProdutoList.RefreshList();
            }
            this.Close();
        }

        private void ClearForm()
        {
            txtNome.Clear();
            txtPreco.Clear();
        }

        public ProdutoCreate()
        {
            this.Text = "Registrar Produto";
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

            this.lblPreco = new Label();
            this.lblPreco.Text = "Preço";
            this.lblPreco.Location = new Point(10, 70);
            this.lblPreco.Size = new Size(50, 20);

            this.txtPreco = new TextBox();
            this.txtPreco.Location = new Point(80, 70);
            this.txtPreco.Size = new Size(150, 20);

            this.btCadt = new Button();
            this.btCadt.Text = "Cadastrar";
            this.btCadt.Location = new Point(10, 130);
            this.btCadt.Size = new Size(50, 20);

            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lblPreco);
            this.Controls.Add(this.txtPreco);
            this.Controls.Add(this.btCadt);
        }
    }
}