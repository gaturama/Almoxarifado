using Models;
using Controllers;
using static Views.ProdutoView;

namespace Views{

    public class ProdutoUpdate : Form{

        public Label lblNome;
        public TextBox txtNome;
        public Label lblPreco;
        public TextBox txtPreco;
        public Button btAdd;

        public ProdutoModels produto;

        private void btAdd_Click(object sender, EventArgs e){
            ProdutoModels produtoToEdit = this.produto;
            produtoToEdit.nome = this.txtNome.Text;

            ProdutoController.Update(produtoToEdit);
            MessageBox.Show("Produto modificado com sucesso");

            ListProduto listProduto = Application.OpenForms.OfType<ListProduto>().FirstOrDefault();
            if( produto != null)
            {
                listProduto.RefreshList();
            }
            this.Close();
        }

        public ProdutoUpdate(ProdutoModels produto){

            this.lblNome = new Label();
            this.lblNome.Text = "Nome";
            this.lblNome.Location = new System.Drawing.Point(10, 40);
            this.lblNome.Size = new System.Drawing.Size(50 ,20);

            this.txtNome = new TextBox();
            this.txtNome.Location = new System.Drawing.Point(80, 40);
            this.txtNome.Size = new System.Drawing.Size(150, 20);

            this.lblPreco = new Label();
            this.lblPreco.Text = "Preço";
            this.lblPreco.Location = new System.Drawing.Point(10, 80);
            this.lblPreco.Size = new System.Drawing.Size(200, 20);

            this.txtPreco = new TextBox();
            this.txtPreco.Location = new System.Drawing.Point(80, 80);
            this.txtPreco.Size = new System.Drawing.Size(250, 20);
            
            this.btAdd = new Button();
            this.btAdd.Text = "Add";
            this.btAdd.Location = new System.Drawing.Point(80, 360);
            this.btAdd.Size = new System.Drawing.Size(150, 35);
            this.btAdd.Click += new EventHandler(this.btAdd_Click);

            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lblPreco);
            this.Controls.Add(this.txtPreco);
            this.Controls.Add(this.btAdd);

        }
    }
}