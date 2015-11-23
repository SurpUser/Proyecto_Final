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

namespace StrongerGym.Consultas
{
    public partial class ProveedoreConsultarForm : Form
    {
        Proveedores Proveedore = new Proveedores();

        public ProveedoreConsultarForm()
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
                    ConsultadataGridView.DataSource = Proveedore.Listado(" * ", " NombreEmpresa like '" + BuscartextBox.Text + "%'", "");
                }
                if (BucarcomboBox.Text == "Por Id de Proveedores")
                {
                    ConsultadataGridView.DataSource = Proveedore.Listado(" * ", " ProveedorId = " + BuscartextBox.Text, "");
                }
                if (ConsultadataGridView.Rows.Count == 0)
                {
                    MessageBox.Show("No hay Usuarios registradas.");
                }

            }
            if (BucarcomboBox.Text == "Todo")
            {
                ConsultadataGridView.DataSource = Proveedore.Listado(" * ", " 1=1 ", "");
                if (ConsultadataGridView.Rows.Count == 0)
                {
                    MessageBox.Show("No hay Usuarios registradas.");
                }
            }
            Cantidadtextbox.Text = "Cantidad de Proveedores: " + ConsultadataGridView.RowCount.ToString();
        }
    }
}
