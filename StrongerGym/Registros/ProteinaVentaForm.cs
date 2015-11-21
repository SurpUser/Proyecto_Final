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
using StrongerGym.R;

namespace StrongerGym.Registros
{
    public partial class ProteinaVentaForm : Form
    {
        Configuracion configuracion = new Configuracion();
        Proteinas proteina = new Proteinas();
        Clientes cliente = new Clientes();
        Usuarios usuario = new Usuarios();
        Ventas venta = new Ventas();


        int Cantida = 0;
        double monto = 0.0;
        double itbis = 0.0;

        public ProteinaVentaForm()
        {
            InitializeComponent();
            VentaUsuariotextBox.Text = LoginForm.NombreUsuario;

            itbis = Convert.ToDouble(configuracion.Listado(" * ", " 1=1 ", "").Rows[0]["ITBIS"]);
            CodigoVentatextBox.Text = venta.Listado("MAX(VentaId)+1 as VentaId", "1=1", "").Rows[0]["VentaId"].ToString();
            ITBISlabel.Text = itbis.ToString();
        }

        private void VentasdataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void BuscarProteina()
        {
            proteina.ProteinaId = Seguridad.ValidarId(CodigoProteinatextBox.Text);
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
            monto = 0.0;
            Cantida = Convert.ToInt32(CantidadProteinatextBox.Text);

            VentasdataGridView.Rows.Add(proteina.ProteinaId, proteina.Nombre,proteina.Precio,Cantida,itbis, Cantida * proteina.Precio + (itbis*proteina.Precio));

            for (int i = 0; i < VentasdataGridView.RowCount; i++)
            {

                monto += (double)VentasdataGridView.Rows[i].Cells[5].Value;
            }
           
            Montolabel.Text = monto.ToString();
        }

        private void AgregarProductobutton_Click(object sender, EventArgs e)
        {
            AgregarProducto();
        }

        public void Limpiar()
        {
            VentasdataGridView.Rows.Clear();
            CodigoClientetextBox.Clear();
            CodigoProteinatextBox.Clear();
            CantidadProteinatextBox.Clear();
            VentaUsuariotextBox.Clear();
            Montolabel.Text = "0.00";
            CodigoClientetextBox.ReadOnly = false;
        }

        public bool LlenarDatos()
        {
            if (true)
            {
                venta.UsuarioId = 1;
                venta.ClienteId = Seguridad.ValidarId(CodigoClientetextBox.Text);
                venta.ITBS = itbis;
                venta.Fecha = FechadateTimePicker.Text;
                venta.TotalVenta = Convert.ToDouble(Montolabel.Text);
                venta.NCF = "12121212";
            }
            return true;
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void BuscarClientebutton_Click(object sender, EventArgs e)
        {
            BuscarCliente();
            CodigoClientetextBox.ReadOnly = true;
        }

        private void BuscarProductobutton_Click(object sender, EventArgs e)
        {
            BuscarProteina();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            if (LlenarDatos())
            {
                for (int i = 0; i < VentasdataGridView.RowCount; i++)
                {
                    venta.AgregarProteinas((int)VentasdataGridView.Rows[i].Cells[0].Value, (int)VentasdataGridView.Rows[i].Cells[3].Value);
                }
                if (venta.Insertar())
                {
                    MessageBox.Show("Guardado Correctamente","Confirmar",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    Limpiar();
                }
                else
                {
                    MessageBox.Show("Error al Guardar","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            venta.VentaId = Seguridad.ValidarId(CodigoVentatextBox.Text);
            if (venta.Eliminar())
            {
                MessageBox.Show("Eliminado Correctamente", "Confirmar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
            }
            else
            {
                MessageBox.Show("Error al Eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BuscarVentabutton_Click(object sender, EventArgs e)
        {
            CodigoVentatextBox.ReadOnly = false;
        }
    }
}
