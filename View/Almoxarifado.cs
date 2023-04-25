using System;
using Models;
using Controllers;

namespace Views
{
    public class AlmoxarifadoView : Form
    {
        public enum Option {Update, Delete}

        public class List : Form{
            ListView listAlmoxarifado;

            private void AddToListView(Models.AlmoxarifadoModels almoxarifado){
                string[] row = {
                    almoxarifado.idAlmoxarifado.ToString(),
                    almoxarifado.nome
                };

                ListViewItem item = new ListViewItem(row);
                listAlmoxarifado.Items.Add(item);
            }

            public void RefreshList(){
                list.Items.Clear();

                List<Models.AlmoxarifadoModels> almoxarifados = Controllers.AlmoxarifadoController.Read();

                foreach(Models.AlmoxarifadoModels almoxarifado in almoxarifados){
                    AddToListView(almoxarifado);
                }
            }

            private void btCad_Click(object sender, EventArgs e){
                var CadastrarAlmoxarifado = new Views.AlmoxarifadoView();
                CadastrarAlmoxarifado.Show();
            }

            private void btEdit_Click(object sender, EventArgs e){
                try{
                    Almoxarifado almoxarifado = GetSelectedAlmoxarifado(Option.Update);
                    RefreshList();
                    var UpdateAlmoxarifado = new Views.AlmoxarifadoView(almoxarifado);
                    if(UpdateAlmoxarifado.ShowDialog() == DialogResult.OK){
                        RefreshList();
                        MessageBox.Show("Almoxarifado editado!");
                    }
                }catch(Exception e){
                    MessageBox.Show(e.Message);
                }
            }
            private void btDelete_Click(object sender, EventArgs e){
                try{
                    Almoxarifado almoxarifado = GetSelectedAlmoxarifado(Option.Delete);
                    DialogResult result = MessageBox("Deseja Delete este almoxarifado?", "Confirmar exclusão", MessageBoxButtons.YesNo);
                    if(result == DialogResult.Yes){
                        Controllers.AlmoxarifadoController.Delete(almoxarifado);
                        RefreshList();
                    }
                }catch(SystemException e){
                    MessageBox.Show(e.Message);
                }
            }

            public AlmoxarifadoModels GetSelectedAlmoxarifado(Option option){
                if(list.SelectedItems.Count > 0){
                    int selectedAlmoxarifadoId = int.Parse(list.SelectedItems[0].Text);
                    return Controllers.AlmoxarifadoController.ReadById(selectedAlmoxarifadoId);
                }
                else{
                    throw new System.Exception($"Por favor, selecione o almoxarifado para {(option == Option.Update ? "Update" : "Delete")}");
                }
            }

            private void btSair_Click(object sender, EventArgs e){
                this.Close();
            }
        }

        public AlmoxarifadoView(){
            this.Text = "Almoxarifado";
            this.Size = new Size(500, 400);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;

            list = new ListView();
            list.Size = new Size(400, 250);
            list.Location = new Point(50, 50);
            list.View = View.Details;
            list.Columns.Add("Id");
            list.Columns.Add("Nome");

            this.RefreshList();

            Button btCad = new Button();
            btCad.Text = "Cadastrar";
            btCad.Size = new Size(100, 50);
            btCad.Location = new Point(50, 300);
            btCad.Click += new EventHandler(btCad_Click);
            this.Controls.Add(btCad);    

            Button btEdit = new Button();
            btEdit.Text = "Update";
            btEdit.Size = new Size(100, 50);
            btEdit.Location = new Point(170, 300);
            btEdit.Click += new EventHandler(btEdit_Click);
            this.Controls.Add(btEdit);

            Button btExcluir = new Button();
            btExcluir.Text = "Excluir";
            btExcluir.Size = new Size(100, 50);
            btExcluir.Location = new Point(350, 300);
            btExcluir.Click += new EventHandler(btExcluir_Click);
            this.Controls.Add(btExcluir);
                
            Button btSair = new Button();
            btSair.Text = "Sair";
            btSair.Size = new Size(100, 30);
            btSair.Location = new Point(530, 300);
            btSair.Click += new EventHandler(btSair_Click);
            this.Controls.Add(btSair);                
        }    
    }
}