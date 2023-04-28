using Models;
using Controllers;

namespace Views{
    public class ListProduto : Form{

        ListView listProduto;

        private void AddListView(Models.ProdutoModels produto){

            string[]row = {
                produto.idProduto.ToString(),
                produto.nome,
                produto.preco.ToString()
            };

            ListViewItem item = new ListViewItem(row);
            listProduto.Items.Add(item);
        }

        public void RefreshList()
        {
            listProduto.Items.Clear();

            List<Models.ProdutoModels> list = Controllers.ProdutoController.Read();

            foreach (Models.ProdutoModels produto in list)
            {
                AddListView(produto);
            }
        }

        private void btCadt_Click(object sender, EventArgs e){

                var ProdutoCreate = new Views.ProdutoCreate();
                ProdutoCreate.Show();
        }

        private void btUpdate_Click(object sender, EventArgs e){
            try{

                ProdutoModels produto = GetSelectedProduto(Option.Update);
                RefreshList();
                var ProdutoUpdateView = new Views.ProdutoUpdate(produto);
                if(ProdutoUpdateView.ShowDialog() == DialogResult.OK)
                {
                    RefreshList();
                    MessageBox.Show("Produto editado com sucesso");
                }
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btDelete_Click(object sender, EventArgs e){
            try{
                ProdutoModels produto = GetSelectedProduto(Option.Delete);
                DialogResult result = MessageBox.Show("Deseja mesmo deletar esse Produto?", "Confirmar exclusão", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Controllers.ProdutoController.Delete(produto);
                    RefreshList();
                }
            }
            catch(Exception err)
            {
                if(err.InnerException != null)
                {
                    MessageBox.Show(err.InnerException.Message);
                }
                else
                {
                    MessageBox.Show(err.Message);
                }
            }
        }

        public ProdutoModels GetSelectedProduto(Option option)
        {
            if(listProduto.SelectedItems.Count > 0)
            {
                int selectedProdutoId = int.Parse(listProduto.SelectedItems[0].Text);
                return Controllers.ProdutoController.ReadById(selectedProdutoId);
            }
            else{

                throw new Exception($"Selecione um Produto para {(option == Option.Update ? "editar" : "deletar")}");
            }
        }

        private void btClose_Click(object sender, EventArgs e){
            Close();
        }

        public ListProduto()
        {
            this.Text = "Produtos";
            this.Size = new Size(800, 450);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;

            listProduto = new ListView();
            listProduto.Size = new Size(680, 260);
            listProduto.Location = new Point(50 ,50);
            listProduto.View = View.Details;
            listProduto.Columns.Add("Id");
            listProduto.Columns.Add("Nome");
            listProduto.Columns.Add("Preço");
            listProduto.FullRowSelect = true;
            this.Controls.Add(listProduto);

            RefreshList();

            Button btCadt = new Button();
            btCadt.Text = "Cadastrar";
            btCadt.Size = new Size(100, 30);
            btCadt.Location = new Point(50, 330);
            btCadt.Click += new EventHandler(btCadt_Click);
            this.Controls.Add(btCadt);

            Button btUpdate = new Button();
            btUpdate.Text = "Editar";
            btUpdate.Size = new Size(100, 30);
            btUpdate.Location = new Point(170, 330);
            btUpdate.Click += new EventHandler(btUpdate_Click);
            this.Controls.Add(btUpdate);

            Button btDelete = new Button();
            btDelete.Text = "Excluir";
            btDelete.Size = new Size(100, 30);
            btDelete.Location = new Point(290, 330);
            btDelete.Click += new EventHandler(btDelete_Click);
            this.Controls.Add(btDelete);

            Button btClose = new Button();
            btClose.Text = "Fechar";
            btClose.Size = new Size(100, 30);
            btClose.Location = new Point(450, 330);
            btClose.Click += new EventHandler(btClose_Click);
            this.Controls.Add(btClose);
        }
    }
}