using Models;
using Controllers;

namespace Views
{
    public class Saldo : Form
    {
      
      public enum Option {Update, Delete}

      public class List : Form
      {
        ListView list;

            private void AddToListView(Models.Saldo saldo){
                string[] row = {
                    saldo.idSaldo.ToString(),
                    saldo.nome,
                    saldo.almoxarifado,
                    saldo.qtd
                };

                ListViewItem item = new ListViewItem(row);
                list.Items.Add(item);
            }

            public void RefreshList(){
                list.Items.Clear();

                List<Models.Saldo> saldos = Controllers.SaldoController.Read();

                foreach(Models.Saldo saldo in saldos){
                    AddToListView(saldo);
                }
            }

            private void btCadt_Click(object sender, EventArgs e){
                var CadastrarSaldo = new Views.Saldo();
                CadastrarSaldo.Show();
            }

            private void btEdit_Click(object sender, EventArgs e){
                try{
                    Saldo saldo = GetSelectedSaldo(Option.Update);
                    RefreshList();
                    var UpdateSaldo = new Views.Saldo(saldo);
                    if(UpdateSaldo.ShowDialog() == DialogResult.OK){
                        RefreshList();
                        MessageBox.Show("Saldo editado!");
                    }
                }catch(Exception e){
                    MessageBox.Show(e.Message);
                }
            }

            private void btExc_Click(object sender, EventArgs e){
                try{
                    Saldo saldo = GetSelectedSaldo(Option.Delete);
                    DialogResult result = MessageBox.Show("Deseja Delete este carro?", "Confirmar exclusão", MessageBoxButtons.YesNo);
                    if(result == DialogResult.Yes){
                        Controllers.SaldoController.Delete(saldo);
                        RefreshList();
                        }
                    }catch(System.Exception e){
                        MessageBox.Show(e.Message);
                    }
                }

            public Saldo GetSelectedSaldo(Option option){
                if(list.SelectedItems.Count > 0){
                    int selectedSaldoId = int.Parse(list.SelectedItems[0].Text);
                    return Controllers.SaldoController.ReadById(selectedSaldoId);
                }
                else{
                    throw new System.Exception($"Por favor, selecione o saldo para {(option == Option.Update ? "Update" : "Delete")}");
                }
            }

            private void btSair_Click(object sender, EventArgs e){
                this.Close();
            }      
      }
      
       public Saldo(){
           this.Text = "Saldo";
           this.Size = new Size(300, 300);
           this.StartPosition = FormStartPosition.CenterScreen;
           this.FormBorderStyle = FormBorderStyle.FixedSingle;
           this.MinimizeBox = false;
           this.MaximizeBox = false;
           this.ShowIcon = false;
           this.ShowInTaskbar = false;

           list = new ListView();
           list.Size = new Size(300, 150);
           list.Location = new Point(100, 100);
           list.View = View.Details;
           list.Columns.Add("Id");
           list.Columns.Add("Nome");
           list.Columns.Add("Almoxarifado");
           list.Columns.Add("Quantidade");

           this.RefreshList();
        
           Button btCadt = new Button();
           btCadt.Text = "Cadastrar";
           btCadt.Size = new Size(100, 30);
           btCadt.Location = new Point(100, 100);
           btCadt.Click += new EventHandler(btCadt_Click);
           this.Controls.Add(btCadt);

           Button btEdit = new Button();
           btEdit.Text = "Update";
           btEdit.Size = new Size(100, 30);
           btEdit.Location = new Point(100, 150);
           btEdit.Click += new EventHandler(btEdit_Click);
           this.Controls.Add(btEdit);

           Button btExc = new Button();
           btExc.Text = "Excluir";
           btExc.Size = new Size(100, 30);
           btExc.Location = new Point(100, 200);
           btExc.Click += new EventHandler(btExc_Click);
           this.Controls.Add(btExc);

           Button btSair = new Button();
           btSair.Text = "Sair";
           btSair.Size = new Size(100, 30);
           btSair.Location = new Point(100, 250);
           btSair.Click += new EventHandler(btSair_Click);
           this.Controls.Add(btSair);
       }
    }
}