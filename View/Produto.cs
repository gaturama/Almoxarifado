using System;
using Models;
using Controllers;

namespace Views
{
    public class Produto : Form
    {
        ListView list;
        public int selectedAlmoxarifadoId = -1;

        public Produto()
        {
            this.Text = "Produto";
            this.Size = new Size(500, 400);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;

            list = new ListView();
            list.Size = new Size(400, 250);
            list.Location = new Point(50, 50);
            list.View = View.Details;
            list.Columns.Add("Id");
            list.Columns.Add("Nome");
            list.Columns.Add("Preço");
            list.Columns[0].Width = 30;
            list.Columns[1].Width = 80;
            list.Columns[2].Width = 100;
            list.FullRowSelect = true;
            list.SelectedIndexChanged += new EventHandler(list_SelectedIndexChanged);
            this.Controls.Add(list);

            RefreshList();

            Button btAdd = new Button();
            btAdd.Text = "Adicionar";
            btAdd.Size = new Size(100, 30);
            btAdd.Location = new Point(50, 300);
            btAdd.Click += new EventHandler(btAdd_Click);
            this.Controls.Add(btAdd);

            Button btEdit = new Button();
            btEdit.Text = "Editar";
            btEdit.Size = new Size(100, 30);
            btEdit.Location = new Point(170, 300);
            btEdit.Click += new EventHandler(btEdit_Click);
            this.Controls.Add(btEdit);

            Button btDelete = new Button();
            btDelete.Text = "Excluir";
            btDelete.Size = new Size(100, 30);
            btDelete.Location = new Point(350, 300);
            btDelete.Click += new EventHandler(btDelete_Click);
            this.Controls.Add(btDelete);

            Button btSair = new Button();
            btSair.Text = "Sair";
            btSair.Size = new Size(100, 30);
            btSair.Location = new Point(450, 300);
            btSair.Click += new EventHandler(btSair_Click);
            this.Controls.Add(btSair);

            this.ShowDialog();
        }
    }
}