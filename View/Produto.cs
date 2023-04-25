using Models;
using Controllers;

namespace Views
{
    public class ProdutoView : Form
    {
        public enum Option { Update, Delete}

        public class ListProduto : Form{
            ListView listProduto;

            private void AddToListView(Models.ProdutoModels produto){
                string[] row = {
                    produto.idProduto.ToString(),
                    produto.nome,
                    produto.preco
                };

                ListViewItem item = new ListViewItem(row);
                listProduto.Items.Add(item);
            }

            public void RefreshList(){
                listProduto.Items.Clear();

                List<Models.ProdutoModels> produtos = Controllers.ProdutoController.Read();

                foreach(Models.ProdutoModels produto in produtos){
                    AddToListView(produto);
                }
            }

            private void btAdd_Click(object sender, EventArgs e){
                var CadastrarProduto = new Views.ProdutoView();
                CadastrarProduto.Show();
            }

            private void btEdit_Click(object sender, EventArgs e){
                try{
                    ProdutoModels produto = GetSelectedProduto(Option.Update);
                    RefreshList();
                    var UpdateProduto = new Views.ProdutoView();
                    if(UpdateProduto.ShowDialog() == DialogResult.OK){
                        RefreshList();
                        MessageBox.Show("Produto editado!");
                    }
                }catch(Exception e){
                    MessageBox.Show(e.Message);
                }
            }

            private void btDelete_Click(object sender, EventArgs e){
                try{
                    ProdutoModels produto = GetSelectedProduto(Option.Delete);
                    DialogResult result = MessageBox("Deseja deletar este produto?", "Confirmar exclusão", MessageBoxButtons.YesNo);
                    if(result == DialogResult.Yes){
                        Controllers.ProdutoController.Delete(produto);
                        RefreshList();
                    }
                }catch(System.Exception err){
                    MessageBox.Show(err.Message);
                }
            }

            public ProdutoModels GetSelectedProduto(Option option){
                if(listProduto.SelectedItems.Count > 0){
                    int selectedProdutoId = int.Parse(listProduto.SelectedItems[0].Text);
                    return Controllers.ProdutoController.ReadById(selectedProdutoId);
                }
                else{
                    throw new System.Exception($"Por favor, selecione o produto para {(option == Option.Update ? "Update" : "deletar")}");
                }
            }

            private void btSair_Click(object sender, EventArgs e){
                this.Close();
            }
        }

        public ProdutoView()
        {
            this.Text = "Produto";
            this.Size = new Size(500, 400);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;

            list = new ListView();
            list.Size = new Size(400, 250);
            list.Location = new Point(50, 50);
            list.View = View.Details;
            list.Columns.Add("Id");
            list.Columns.Add("Nome");
            list.Columns.Add("Preço");
           
            RefreshList();

            Button btAdd = new Button();
            btAdd.Text = "Adicionar";
            btAdd.Size = new Size(100, 30);
            btAdd.Location = new Point(50, 300);
            btAdd.Click += new EventHandler(btAdd_Click);
            this.Controls.Add(btAdd);

            Button btEdit = new Button();
            btEdit.Text = "Update";
            btEdit.Size = new Size(100, 30);
            btEdit.Location = new Point(170, 300);
            btEdit.Click += new EventHandler(btEdit_Click);
            this.Controls.Add(btEdit);

            Button btDelete = new Button();
            btDelete.Text = "Excluir";
            btDelete.Size = new Size(100, 30);
            btDelete.Location = new Point(350, 300);
            btDelete.Click += new EventHandler(btDelete_Click);
            this.Controls.Add(btDelete);

            Button btSair = new Button();
            btSair.Text = "Sair";
            btSair.Size = new Size(100, 30);
            btSair.Location = new Point(450, 300);
            btSair.Click += new EventHandler(btSair_Click);
            this.Controls.Add(btSair);

        }
    }
}