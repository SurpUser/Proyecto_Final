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
using StrongerGym.Consultas;
using StrongerGym.Reportes;

namespace StrongerGym.R
{
    public partial class CarnetForm : Form
    {
        Clientes cliente;
        public CarnetForm()
        {
            cliente = new Clientes();
            InitializeComponent();
        }

        public void LlenarForm()
        {
            NombretextBox.Text = cliente.Nombre;
            DirecciontextBox.Text = cliente.Direccion;
            TelefonostextBox.Text = cliente.Telefono;
            CarnetpictureBox.ImageLocation = cliente.Imagen;
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            if (cliente.Buscar(Seguridad.ValidarIdEntero(CodigotextBox.Text)))
            {
                LlenarForm();
            }
            else
            {
                MessageBox.Show("Cliente No Existe","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void Imprimirbutton_Click(object sender, EventArgs e)
        {
            CarnetClientesForm carnet = new CarnetClientesForm();
            CarnetClientesCrystalReport ccr = new CarnetClientesCrystalReport();
            if (Seguridad.ValidarIdEntero(CodigotextBox.Text) > 0)
            {
                ccr.SetParameterValue("Codigo", Seguridad.ValidarIdEntero(CodigotextBox.Text));
                ccr.SetParameterValue("Imagen", cliente.Imagen);
                ccr.SetParameterValue("Nombre",cliente.Nombre);
                ccr.SetParameterValue("Direccion",cliente.Direccion);
                ccr.SetParameterValue("Telefono",cliente.Telefono);
                carnet.ClientescrystalReportViewer.ReportSource = ccr;
                carnet.ShowDialog();
            }
            else
            {
                MessageBox.Show("Id No Valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
    }
}
