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
    public partial class CiudadConsultarForm : Form
    {
        Ciudades Ciudad = new Ciudades();

        public CiudadConsultarForm()
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
                    ConsultadataGridView.DataSource = Ciudad.Listado(" * ", "Nombre like '" + BuscartextBox.Text + "%'", "");
                }
                if (BucarcomboBox.Text == "Por Id de Ciudad")
                {
                    ConsultadataGridView.DataSource = Ciudad.Listado(" * ", " CiudadId = " + BuscartextBox.Text, "");
                }
                if (ConsultadataGridView.Rows.Count == 0)
                {
                    MessageBox.Show("No hay Ciudades registradas.");
                }

            }
            if (BucarcomboBox.Text == "Todo")
            {
                ConsultadataGridView.DataSource = Ciudad.Listado(" * ", " 1=1 ", "");
                if (ConsultadataGridView.Rows.Count == 0)
                {
                    MessageBox.Show("No hay Ciudades registradas.");
                }
            }
            Cantidadlabelbox.Text = "Cantidad de Ciudad: " + ConsultadataGridView.RowCount.ToString();
        }
    }
}
