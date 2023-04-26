using Models;
using Controllers;
using System;

namespace Views{

    public class UpdateProduto : Form{

        public Label lblNome;
        public TextBox txtNome;
        public Label lblPreco;
        public TextBox txtPreco;
        public Button btAdd;

        public ProdutoModels produto;

        private void btAdd_Click(object sender, EventArgs e){
            ProdutoModels produtoToEdit = this.produto;
            
        }
    }
}