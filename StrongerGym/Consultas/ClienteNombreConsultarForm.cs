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
    public partial class ClienteNombreConsultarForm : Form
    {
        Clientes Cliente = new Clientes();

        public ClienteNombreConsultarForm()
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
                    ConsultadataGridView.DataSource = Cliente.Listado(" * ", "Nombre like '" + BuscartextBox.Text + "%'", "");
                }
                if (BucarcomboBox.Text == "Por Id de Clientes")
                {
                    ConsultadataGridView.DataSource = Cliente.Listado(" * ", " ClienteId = " + BuscartextBox.Text, "");
                }
                if (ConsultadataGridView.Rows.Count == 0)
                {
                    MessageBox.Show("No hay Clientes registradas.");
                }

            }
            if (BucarcomboBox.Text == "Todo")
            {
                ConsultadataGridView.DataSource = Cliente.Listado(" * ", " 1=1 ", "");
                if (ConsultadataGridView.Rows.Count == 0)
                {
                    MessageBox.Show("No hay Clientes registradas.");
                }
            }
            Cantidadlabelbox.Text = "Cantidad de Clientes: " + ConsultadataGridView.RowCount.ToString();
        }
    }
}
