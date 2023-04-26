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

        public void btAdd_Click(Object sender, EventArgs e){
            if(
                txtNome.Text == "" ||
                txtPreco.Text == ""
            ){
                MessageBox.Show("Preencha corretamente os campos");
                return;
            }else{

                Models.ProdutoModels produto = new ProdutoModels(
                    txtNome.Text,
                    txtPreco.Text
                );

                ProdutoController produtoController = new ProdutoController();
                produtoController.Create(produto);

                MessageBox.Show("Produto cadastrado com sucesso");
                ClearForm();
            }

            ListProduto listProduto = Application.OpenForms.OfType<ListProduto>().FirstOrDefault();
            if(listProduto!= null){
            listProduto.RefreshList();
            }
                this.Close();
            }

        private void ClearForm(){
            txtNome.Clear();
        }

         public ProdutoCreate(){

            this.lblNome = new Label();
            this.lblNome.Text = "Nome";
            this.lblNome.Location = new System.Drawing.Point(10, 70);
            this.lblNome.Size = new System.Drawing.Size(50, 20);

            this.txtNome = new TextBox();
            this.txtNome.Location = new System.Drawing.Point(80, 70);
            this.txtNome.Size = new System.Drawing.Size(150, 20);

            this.lblPreco = new Label();
            this.lblPreco.Text = "Preço";
            this.lblPreco.Location = new System.Drawing.Point(10, 110);
            this.lblPreco.Size = new System.Drawing.Size(50, 20);

            this.txtPreco = new TextBox();
            this.txtPreco.Location = new System.Drawing.Point(80, 110);
            this.txtPreco.Size = new System.Drawing.Size(150, 20);

            this.btAdd = new Button();
            this.btAdd.Text = "Cadastrar";
            this.btAdd.Location = new System.Drawing.Point(80, 360);
            this.btAdd.Size = new System.Drawing.Size(150, 35);
            this.btAdd.Click += new EventHandler(this.btAdd_Click);

            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.btAdd);
        }
    }
}