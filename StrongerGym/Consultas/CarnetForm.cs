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
            carnet.ClientescrystalReportViewer.ReportSource = ccr;
            carnet.ShowDialog();
        }
    }
}
