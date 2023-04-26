using Models;
using Controllers;
using System;
using static Views.AlmoxarifadoView;

namespace Views{

    public class AlmoxarifadoUpdate : Form{

        public Label lblNome;
        public TextBox txtNome;
        public Button btCad;

        public AlmoxarifadoModels almoxarifado;
        
                
        private void btEdit_Click(object sender, EventArgs e){

            AlmoxarifadoModels almoxarifadoToEdit = this.almoxarifado;
            almoxarifadoToEdit.nome = this.txtNome.Text;
            
            AlmoxarifadoController.Update(almoxarifadoToEdit);
            MessageBox.Show("Almoxarifado foi modificado com sucesso!");

            ListAlmoxarifado listAlmoxarifado = Application.OpenForms.OfType<ListAlmoxarifado>().FirstOrDefault();
            if (almoxarifado != null)
            {
                almoxarifado.RefreshList();
            }
            this.Close();            
        }

        public AlmoxarifadoUpdate(AlmoxarifadoModels almoxarifado){

            this.lblNome = new Label();
            this.lblNome.Text = "Nome";
            this.lblNome.Location = new System.Drawing.Point(10, 40);
            this.lblNome.Size = new System.Drawing.Size(50, 20);

            this.txtNome = new TextBox();
            this.txtNome.Location = new System.Drawing.Point(80, 40);
            this.txtNome.Size = new System.Drawing.Size(150, 20);

            this.btCad = new Button();
            this.btCad.Text = "Cadastrar";
            this.btCad.Location = new System.Drawing.Point(80, 360);
            this.btCad.Size = new System.Drawing.Size(150, 35);
            this.btCad.Click += new EventHandler(this.btEdit_Click);

            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.btCad);
        }
    }
}