using Models;
using Controllers;

namespace Views{

    public enum Option {Update, Delete}

    public class ListSaldo : Form{

        ListView listSaldo;

        private void AddLIstView(Models.SaldoModels saldo){

            string[]row = {

                saldo.nome,
                saldo.almoxarifado,
                saldo.qtd
            };

            ListViewItem item = new ListViewItem(row);
            listSaldo.Items.Add(item);
        }

        public void RefreshList()
        {
            listSaldo.Items.Clear();

            List<Models.SaldoModels> list = Controllers.SaldoController.Read();

            foreach (Models.SaldoModels saldo in list)
            {
                AddLIstView(saldo);
            }
        }

        private void btCadt_Click(object sender, EventArgs e){

            var SaldoCreate = new Views.SaldoCreate();
            SaldoCreate.Show();
        }

        private void btUpdate_Click(object sender, EventArgs e){
            try{

                SaldoModels saldo = GetSelectedSaldo(Option.Update);
                RefreshList();
                var SaldoUpdateView = new View.SaldoUpdate(saldo);
                if(SaldoUpdateView.ShowDialog() == DialogResult.OK)
                {
                    RefreshList();
                    MessageBox.Show("Carro editado com sucesso");
                }
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btDelete_Click(object sender, EventArgs e){
            try{
                SaldoModels saldo = GetSelectedSaldo(Option.Delete);
                DialogResult result = MessageBox.Show("Deseja mesmo deletar esse carro?", "Confirmar exclusão", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Controllers.SaldoController.Delete(saldo);
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
        
        public SaldoModels GetSelectedSaldo(Option option)
        {
            if(listSaldo.SelectedItems.Count > 0)
            {
                int selectedSaldoId = int.Parse(listSaldo.SelectedItems[0].Text);
                return Controllers.SaldoController.ReadById(selectedSaldoId);
            }
            else{

                throw new Exception($"Selecione um carro para {(option == Option.Update ? "editar" : "deletar")}");
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public ListSaldo()
        {
            this.Text = "Saldos";
            this.Size = new Size(800, 450);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;

            listSaldo = new ListView();
            listSaldo.Size = new Size(680, 260);
            listSaldo.Location = new Point(50, 50);
            listSaldo.View = View.Details;
            listSaldo.Columns.Add("Nome");
            listSaldo.Columns.Add("Almoxarifado");
            listSaldo.Columns.Add("Quantidade");
            this.Controls.Add(listSaldo);

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