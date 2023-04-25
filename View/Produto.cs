using System;
using Models;
using Controllers;

namespace Views
{
    public class Produto : Form
    {
        public enum Option { Update, Delete}

        public class List : Form{
            ListView list;

            private void AddToListView(Models.Produto produto){
                string[] row = {
                    produto.idProduto.ToString(),
                    produto.nome,
                    produto.preco
                };

                ListViewItem item = new ListViewItem(row);
                list.Items.Add(item);
            }

            public void RefreshList(){
                list.Items.Clear();

                List<Models.Produto> produtos = Controllers.ProdutoController.Read();

                foreach(Models.Produto produto in produtos){
                    AddToListView(produto);
                }
            }

            private void btAdd_Click(object sender, EventArgs e){
                var CadastrarProduto = new Views.Produto();
                CadastrarProduto.Show();
            }

            private void btEdit_Click(object sender, EventArgs e){
                try{
                    Produto produto = GetSelectedProduto(Option.Update);
                    RefreshList();
                    var UpdateProduto = new Views.Produto(produto);
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
                    Produto produto = GetSelectedProduto(Option.Delete);
                    DialogResult result = MessageBox("Deseja deletar este produto?", "Confirmar exclusão", MessageBoxButtons.YesNo);
                    if(result == DialogResult.Yes){
                        Controllers.ProdutoController.Delete(produto);
                        RefreshList();
                    }
                }catch(SystemException e){
                    MessageBox.Show(e.Message);
                }
            }

            public Produto GetSelectedProduto(Option option){
                if(list.SelectedItems.Count > 0){
                    int selectedProdutoId = int.Parse(list.SelectedItems[0].Text);
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

        public Produto()
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
            // list.Columns[0].Width = 30;
            // list.Columns[1].Width = 80;
            // list.Columns[2].Width = 100;
            // list.FullRowSelect = true;
            // list.SelectedIndexChanged += new EventHandler(list_SelectedIndexChanged);
            // this.Controls.Add(list);

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