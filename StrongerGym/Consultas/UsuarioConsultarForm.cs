using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace StrongerGym.Recursos
{
    public partial class ConsultaUsuarioForm : Form
    {
        Usuarios usuario = new Usuarios();
        public ConsultaUsuarioForm()
        {
            InitializeComponent();
            BucarcomboBox.SelectedIndex = 0;
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            if (BuscartextBox.Text.Length > 0)
            {
                string Dato = BuscartextBox.Text;
                if (BucarcomboBox.Text == "Por Nombre")
                {
                    ConsultadataGridView.DataSource = usuario.Listado(" * ", "Nombre like '" + BuscartextBox.Text + "%'", "");
                }
                if (BucarcomboBox.Text == "Por Id de Usuarios")
                {
                    ConsultadataGridView.DataSource = usuario.Listado(" * ", " UsuarioId = "+BuscartextBox.Text, "");
                }
                if (ConsultadataGridView.Rows.Count == 0)
                {
                    MessageBox.Show("No hay Usuarios registradas.");
                }

            }
            if (BucarcomboBox.Text == "Todo")
            {
                ConsultadataGridView.DataSource = usuario.Listado(" * ", " 1=1 ","");
                if (ConsultadataGridView.Rows.Count == 0)
                {
                    MessageBox.Show("No hay Usuarios registradas.");
                }
            }
            Cantidadtextbox.Text = "Cantidad de Usuario: "+ConsultadataGridView.RowCount.ToString();
        }
    }
}
