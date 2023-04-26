using Models;
using Controllers;

namespace Views{

    public class AlmoxarifadoCreate : Form{

       public Label lblId;
       public TextBox txtId;
       public Label lblNome;
       public TextBox txtNome;

       public void btCad_Click(object sender, EventArgs e){
        if(
            txtId.Text == "" ||
            txtNome.Text == "" 

        ){
            MessageBox.Show("Preencha corretamente os campos");
            return;
        }else{

            Models.AlmoxarifadoModels almoxarifado = new AlmoxarifadoModels(
                txtId.Text,
                txtNome.Text,
                Convert.ToString(txtId.Text)
            );

            AlmoxarifadoController almoxarifadoController = new AlmoxarifadoController();
            almoxarifadoController.Create(almoxarifado);

            MessageBox.Show("Almoxarifado cadastrado com sucesso");
            ClearForm();
        }

        ListAlmoxarifado ProdutoList = Application.OpenForms.OfType<ListAlmoxarifado>().FirstOrDefault();
        if(ProdutoList!= null){
            ProdutoList.RefreshList();
        }
        this.Close();
        }

        private void ClearForm(){
            txtId.Clear();
            txtNome.Clear();
        }

        public AlmoxarifadoCreate(){
            this.lblId = new Label();
            this.lblId.Text = "Id";
            this.lblId.Location = new System.Drawing.Point(10, 40);
            this.lblId.Size = new System.Drawing.Size(50, 20);

            this.txtId = new TextBox();
            this.txtId.Location = new System.Drawing.Point(80, 40);
            this.txtId.Size = new System.Drawing.Size(150, 20);

            this.lblNome = new Label();
            this.lblNome.Text = "Nome";
            this.lblNome.Location = new System.Drawing.Point(10, 70);
            this.lblNome.Size = new System.Drawing.Size(50, 20);

            this.txtNome = new TextBox();
            this.txtNome.Location = new System.Drawing.Point(80, 70);
            this.txtNome.Size = new System.Drawing.Size(150, 20);

            this.btCad = new Button();
            this.btCad.Text = "Cadastrar";
            this.btCad.Location = new System.Drawing.Point(80, 360);
            this.btCad.Size = new System.Drawing.Size(150, 35);
            this.btCad.Click += new EventHandler(this.btCad_Click);

            this.Controls.Add(this.lblId);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.btCad);
            
        }
    }

}
