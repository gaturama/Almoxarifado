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
            this.Size = new Size(600, 420);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;

            list = new ListView();
            list.Size = new Size(500, 200);
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
            btAdd.Size = new Size(75, 23);
            btAdd.Location = new Point(50, 170);
            btAdd.Click += new EventHandler(btAdd_Click);
            this.Controls.Add(btAdd);

            Button btEdit = new Button();
            btEdit.Text = "Editar";
            btEdit.Size = new Size(75, 23);
            btEdit.Location = new Point(120, 170);
            btEdit.Click += new EventHandler(btEdit_Click);
            this.Controls.Add(btEdit);
        }
    }
}