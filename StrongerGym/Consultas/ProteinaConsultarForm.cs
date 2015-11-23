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
    public partial class ProteinaConsultarForm : Form
    {
        Proteinas Proteina = new Proteinas();

        public ProteinaConsultarForm()
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
                    ConsultadataGridView.DataSource = Proteina.Listado(" * ", " Nombre like '" + BuscartextBox.Text + "%'", "");
                }
                if (BucarcomboBox.Text == "Por Id de Proteinas")
                {
                    ConsultadataGridView.DataSource = Proteina.Listado(" * ", " ProteinaId = " + BuscartextBox.Text, "");
                }
                if (ConsultadataGridView.Rows.Count == 0)
                {
                    MessageBox.Show("No hay Usuarios registradas.");
                }

            }
            if (BucarcomboBox.Text == "Todo")
            {
                ConsultadataGridView.DataSource = Proteina.Listado(" * ", " 1=1 ", "");
                if (ConsultadataGridView.Rows.Count == 0)
                {
                    MessageBox.Show("No hay Usuarios registradas.");
                }
            }
            Cantidadtextbox.Text = "Cantidad de Proteinas: " + ConsultadataGridView.RowCount.ToString();
        }
    }
}
