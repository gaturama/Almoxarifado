using Models;
using Controllers;
using static Views.ProdutoView;

namespace Views{

    public class ProdutoCreate : Form{

        public Label lblNome;
        public TextBox txtNome;
        public Label lblPreco;
        public TextBox txtPreco;
        public Button btAdd;

        public void btAdd_Click(object sender, EventArgs e){
            if(
                txtNome.Text == "" ||
                txtPreco.Text == ""
            ){
                MessageBox.Show("Preencha o nome deve ser informado");
                return;
            }else{
                Models.ProdutoModels produto = new ProdutoModels(
                    txtNome.Text,
                    txtPreco.Text
                );

                ProdutoController produtoController = new ProdutoController();
                produtoController.Create(produto);

                MessageBox.Show("Produto criado com sucesso");
                ClearForm();
            }

            ListProduto listProduto = Application.OpenForms.OfType<ListProduto>().FirstOrDefault();
            if(listProduto!= null)
            {
                listProduto.RefreshList();
            }

            this.Close();
        }

        private void ClearForm(){
            txtNome.Clear();
            txtPreco.Clear();
        }

        public ProdutoCreate(){
            this.lblNome = new Label();
            this.lblNome.Text = "Nome";
            this.lblNome.Location = new System.Drawing.Point(10, 40);
            this.lblNome.Size = new System.Drawing.Size(50, 20);

            this.txtNome = new TextBox();
            this.txtNome.Location = new System.Drawing.Point(80, 40);
            this.txtNome.Size = new System.Drawing.Size(150, 20);

            this.lblPreco = new Label();
            this.lblPreco.Text = "Preco";
            this.lblPreco.Location = new System.Drawing.Point(10, 70);
            this.lblPreco.Size = new System.Drawing.Size(50, 20);

            this.txtPreco = new TextBox();
            this.txtPreco.Location = new System.Drawing.Point(80, 70);
            this.txtPreco.Size = new System.Drawing.Size(150, 20);
 
            this.btAdd = new Button();
            this.btAdd.Text = "Adicionar";
            this.btAdd.Location = new System.Drawing.Point(80, 260);
            this.btAdd.Size = new System.Drawing.Size(150, 35);
            this.btAdd.Click += new EventHandler(this.btAdd_Click);
        }
    }
}