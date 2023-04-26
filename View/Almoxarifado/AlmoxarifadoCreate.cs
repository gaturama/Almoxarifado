using Models;
using Controllers;
using static Views.ProdutoView;

namespace Views{

    public class AlmoxarifadoCreate : Form{
       public Label lblNome;
       public TextBox txtNome;
       public Button btCad;

        public void btCad_Click(object sender, EventArgs e){
        if(
            txtNome.Text == "" 
        ){
            MessageBox.Show("Preencha corretamente os campos");
            return;
        }else{

            Models.AlmoxarifadoModels almoxarifado = new AlmoxarifadoModels(
                txtNome.Text
            );

            AlmoxarifadoController almoxarifadoController = new AlmoxarifadoController();
            almoxarifadoController.Create(almoxarifado);

            MessageBox.Show("Almoxarifado cadastrado com sucesso");
            ClearForm();
        }

        ListProduto listProduto = Application.OpenForms.OfType<ListProduto>().FirstOrDefault();
        if(listProduto!= null){
            listProduto.RefreshList();
        }
        this.Close();
        }

        private void ClearForm(){
            txtNome.Clear();
        }

        public AlmoxarifadoCreate(){
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

            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.btCad);
            
        }
    }

}
