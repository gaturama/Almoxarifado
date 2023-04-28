using Controllers;
using Models;

namespace Views{

    public class AlmoxarifadoCreate : Form
    {
        public Label lblNome;
        public TextBox txtNome;
        public Button btCadt;

        public void btCadt_Click(object sender, EventArgs e)
        {
            if(

                txtNome.Text == ""
            ){
                MessageBox.Show("Preencha o campo corretamente");
                return;
            }else
            {
                Models.AlmoxarifadoModels almoxarifado = new AlmoxarifadoModels(
                    txtNome.Text
                );

                AlmoxarifadoController almoxarifadoController = new AlmoxarifadoController();
                almoxarifadoController.Create(almoxarifado);

                MessageBox.Show("Almoxarifado cadastrado com sucesso");
            }
            
            ListAlmoxarifado AlmoxarifadoList = Application.OpenForms.OfType<ListAlmoxarifado>().FirstOrDefault();
            if(AlmoxarifadoList != null)
            {
                AlmoxarifadoList.RefreshList();
            }
            this.Close();
        }

        private void ClearForm()
        {
            txtNome.Clear();
        }

        public AlmoxarifadoCreate()
        {
            this.Text = "Registrar Almoxarifado";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Size = new System.Drawing.Size(280, 360);

            this.lblNome = new Label();
            this.lblNome.Text = "Nome";
            this.lblNome.Location = new Point(10, 40);
            this.lblNome.Size = new Size(50, 20);

            this.txtNome = new TextBox();
            this.txtNome.Location = new Point(80, 40);
            this.txtNome.Size = new Size(150, 20);

            this.btCadt = new Button();
            this.btCadt.Text = "Cadastrar";
            this.btCadt.Location = new Point(10, 130);
            this.btCadt.Size = new Size(50, 20);
            this.btCadt.Click += btCadt_Click;

            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.btCadt);
        }
    }
}