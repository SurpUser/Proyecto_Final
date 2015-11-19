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

namespace StrongerGym.Registros
{
    public partial class ProteinaVentaForm : Form
    {
        Proteinas proteina = new Proteinas();
        Ventas venta = new Ventas();
        Clientes cliente = new Clientes();

        int Cantida = 0;
        double monto = 0.0;
        double subtotal = 0.0;

        public ProteinaVentaForm()
        {
            InitializeComponent();
        }

        private void VentasdataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void BuscarProteina()
        {
            proteina.ProteinaId = Seguridad.ValidarId(CodigoProductotextBox.Text);
            if (proteina.Buscar(proteina.ProteinaId))
            {
                ProteinatextBox.Text = proteina.Nombre;
            }
            else
            {
                MessageBox.Show("Codigo No Existe","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        public void BuscarCliente()
        {
            if (cliente.Buscar(Seguridad.ValidarId(CodigoClientetextBox.Text)))
            {
                NombreClientetextBox.Text = cliente.Nombre;
            }
            else
            {
                MessageBox.Show("Codigo No Existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void AgregarProducto()
        {
            Montolabel.Text = "";
            Subtotallabel.Text = "";
            monto = 0.0;
            subtotal = 0.0;
            Cantida = Convert.ToInt32(CantidadProteinatextBox.Text);

            VentasdataGridView.Rows.Add(proteina.ProteinaId, proteina.Nombre,proteina.Precio,Cantida,0.18, Cantida * proteina.Precio * 0.18,Cantida * proteina.Precio);

            for (int i = 0; i < VentasdataGridView.RowCount; i++)
            {
                monto += (double)VentasdataGridView.Rows[i].Cells[6].Value;
                subtotal += (double)VentasdataGridView.Rows[i].Cells[5].Value;
            }
           
            Montolabel.Text = monto.ToString();
            Subtotallabel.Text = subtotal.ToString();
        }

        private void AgregarProductobutton_Click(object sender, EventArgs e)
        {
            AgregarProducto();
        }

        public void Limpiar()
        {
            VentasdataGridView.Rows.Clear();
            CodigoClientetextBox.Clear();
            CodigoProductotextBox.Clear();
            CantidadProteinatextBox.Clear();
            UsuariotextBox.Clear();
            Montolabel.Text = "0.00";
            Subtotallabel.Text = "0.00";
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void BuscarClientebutton_Click(object sender, EventArgs e)
        {
            BuscarCliente();
        }

        private void BuscarProductobutton_Click(object sender, EventArgs e)
        {
            BuscarProteina();
        }
    }
}
