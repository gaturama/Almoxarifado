using Models;
using Controllers;

namespace Views{

    public class ProdutoUpdate : Form{

        public Label lblNome;
        public TextBox txtNome;
        public Label lblPreco;
        public TextBox txtPreco;
        public Button btUpdate;

        public ProdutoModels produto;

        private void btUpdate_Click(object sender, EventArgs e)
        {
                ProdutoModels produtoToUpdate = this.produto;
                produtoToUpdate.nome = this.txtNome.Text;
                produtoToUpdate.preco = Convert.ToDouble(this.txtPreco.Text);

                Controllers.ProdutoController.Update(produtoToUpdate);
                
                ListProduto ProdutoList = Application.OpenForms.OfType<ListProduto>().FirstOrDefault();
                if (ProdutoList!= null)
                {
                    ProdutoList.RefreshList();
                }
                this.Close();
        }

        public ProdutoUpdate(ProdutoModels produto)
        {
            this.produto = produto;

            this.Text = "Editar produto";
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
            this.txtNome.Text = produto.nome;
            this.txtNome.Location = new System.Drawing.Point(80, 40);
            this.txtNome.Size = new System.Drawing.Size(150, 20);
            this.Controls.Add(this.txtNome);

            this.lblPreco = new Label();
            this.lblPreco.Text = "Preço";
            this.lblPreco.Location = new Point(10, 70);
            this.lblPreco.Size = new Size(50, 20);
            this.Controls.Add(this.lblPreco);

            this.txtPreco = new TextBox();
            this.txtPreco.Text = produto.preco.ToString();
            this.txtPreco.Location = new System.Drawing.Point(80, 70);
            this.txtPreco.Size = new System.Drawing.Size(150, 20);
            this.Controls.Add(this.txtPreco);

            this.btUpdate = new Button();
            this.btUpdate.Text = "Editar";
            this.btUpdate.Location = new System.Drawing.Point(80, 260);
            this.btUpdate.Size = new System.Drawing.Size(150, 35);
            this.btUpdate.Click += new EventHandler(btUpdate_Click);
            this.Controls.Add(this.btUpdate);
        }            
    }
}
