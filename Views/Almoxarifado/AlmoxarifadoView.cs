using Models;
using Controllers;

namespace Views{
    public class ListAlmoxarifado : Form{

        ListView listAlmoxarifado;

        private void AddListView(Models.AlmoxarifadoModels almoxarifado){

            string[]row = {
                almoxarifado.idAlmoxarifado.ToString(),
                almoxarifado.nome
            };

            ListViewItem item = new ListViewItem(row);
            listAlmoxarifado.Items.Add(item);
        }

        public void RefreshList()
        {
            listAlmoxarifado.Items.Clear();

            List<Models.AlmoxarifadoModels> list = Controllers.AlmoxarifadoController.Read();

            foreach (Models.AlmoxarifadoModels almoxarifado in list)
            {
                AddListView(almoxarifado);
            }
        }

        private void btCadt_Click(object sender, EventArgs e){

            var AlmoxarifadoCreate = new Views.AlmoxarifadoCreate();
            AlmoxarifadoCreate.Show();
        }

        private void btUpdate_Click(object sender, EventArgs e){
            try{

                AlmoxarifadoModels almoxarifado = GetSelectedAlmoxarifado(Option.Update);
                RefreshList();
                var AlmoxarifadoUpdateView = new Views.AlmoxarifadoUpdate(almoxarifado);
                if(AlmoxarifadoUpdateView.ShowDialog() == DialogResult.OK)
                {
                    RefreshList();
                    MessageBox.Show("almoxarifado editado com sucesso");
                }
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void btDelete_Click(object sender, EventArgs e){
            try{
                AlmoxarifadoModels almoxarifado = GetSelectedAlmoxarifado(Option.Delete);
                DialogResult result = MessageBox.Show("Deseja mesmo deletar esse almoxarifado?", "Confirmar exclusão", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Controllers.AlmoxarifadoController.Delete(almoxarifado);
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
        
        public AlmoxarifadoModels GetSelectedAlmoxarifado(Option option)
        {
            if(listAlmoxarifado.SelectedItems.Count > 0)
            {
                int selectedAlmoxarifadoId = int.Parse(listAlmoxarifado.SelectedItems[0].Text);
                return Controllers.AlmoxarifadoController.ReadById(selectedAlmoxarifadoId);
            }
            else{

                throw new Exception($"Selecione um almoxarifado para {(option == Option.Update ? "editar" : "deletar")}");
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public ListAlmoxarifado()
        {
            this.Text = "Almoxarifados";
            this.Size = new Size(800, 450);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = true;
            this.MinimizeBox = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;

            listAlmoxarifado = new ListView();
            listAlmoxarifado.Size = new Size(680, 260);
            listAlmoxarifado.Location = new Point(50, 50);
            listAlmoxarifado.View = View.Details;
            listAlmoxarifado.Columns.Add("Id");
            listAlmoxarifado.Columns.Add("Nome");
            listAlmoxarifado.FullRowSelect = true;
            this.Controls.Add(listAlmoxarifado);

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
            btClose.Text = "Voltar";
            btClose.Size = new Size(100, 30);
            btClose.Location = new Point(450, 330);
            btClose.Click += new EventHandler(btClose_Click);
            this.Controls.Add(btClose);
        }
    }
}