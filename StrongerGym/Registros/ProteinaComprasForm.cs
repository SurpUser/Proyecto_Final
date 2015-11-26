using BLL;
using StrongerGym.R;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StrongerGym.Registros
{
    public partial class ProteinaComprasForm : Form
    {
        Configuracion configuracion = new Configuracion();
        Proteinas proteina = new Proteinas();
        Proveedores proveedor = new Proveedores();
        Usuarios usuario = new Usuarios();
        Compras compra = new Compras();

        int Cantidad = 0;
        double monto = 0.0;
        double itbis = 0.0;

        public ProteinaComprasForm()
        {
            InitializeComponent();
            CompraUsuariotextBox.Text = LoginForm.NombreUsuario;

            itbis = Seguridad.ValidarIdDouble(configuracion.Listado(" * ", " 1=1 ", "").Rows[0]["ITBIS"].ToString());
            CodigoCompratextBox.Text = compra.Listado("MAX(CompraId)+1 as CompraId", "1=1", "").Rows[0]["CompraId"].ToString();
            NCFtextBox.Text = configuracion.Listado("NCF", "1=1", "").Rows[0]["NCF"].ToString();
            ITBISlabel.Text = itbis.ToString();
        }

        public void BuscarProteina()
        {
            proteina.ProteinaId = Seguridad.ValidarIdEntero(CodigoProteinatextBox.Text);
            if (proteina.Buscar(proteina.ProteinaId))
            {
                ProteinatextBox.Text = proteina.Nombre;
            }
            else
            {
                MessageBox.Show("Codigo No Existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void BuscarCliente()
        {
            if (proveedor.Buscar(Seguridad.ValidarIdEntero(CodigoProveedortextBox.Text)))
            {
                NombreProveedortextBox.Text = proveedor.NombreRepresentante;
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
            Cantidad = Convert.ToInt32(CantidadProteinatextBox.Text);

            ComprasdataGridView.Rows.Add(proteina.ProteinaId, proteina.Nombre, proteina.Precio, Cantidad, itbis, Cantidad * proteina.Precio + (itbis * proteina.Precio));

            for (int i = 0; i < ComprasdataGridView.RowCount; i++)
            {

                monto += (double)ComprasdataGridView.Rows[i].Cells[5].Value;
            }

            Montolabel.Text = monto.ToString();
        }

        public void Limpiar()
        {
            ComprasdataGridView.Rows.Clear();
            CodigoProveedortextBox.Clear();
            CodigoProteinatextBox.Clear();
            CantidadProteinatextBox.Clear();
            CompraUsuariotextBox.Clear();
            Montolabel.Text = "0.00";
            CodigoProveedortextBox.ReadOnly = false;
        }

        public bool LlenarDatos()
        {
            if (true)
            {
                compra.UsuarioId = 1;
                compra.ProveedorId = Seguridad.ValidarIdEntero(CodigoProveedortextBox.Text);
                compra.ITBS = itbis;
                compra.Fecha = FechadateTimePicker.Text;
                compra.Monto = Convert.ToDouble(Montolabel.Text);
                compra.NCF = NCFtextBox.Text;
                compra.Fecha = FechadateTimePicker.Text;

            }
            return true;
        }


        private void ProteinaComprasForm_Load(object sender, EventArgs e)
        {

        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            if (LlenarDatos())
            {
                for (int i = 0; i < ComprasdataGridView.RowCount; i++)
                {
                    //compra.AgregarProteinas((int)ComprasdataGridView.Rows[i].Cells[0].Value, (int)ComprasdataGridView.Rows[i].Cells[3].Value);
                }
                if (compra.Insertar())
                {
                    MessageBox.Show("Guardado Correctamente", "Confirmar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                }
                else
                {
                    MessageBox.Show("Error al Guardar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Agregarbutton_Click(object sender, EventArgs e)
        {
            AgregarProducto();
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            compra.CompraId = Seguridad.ValidarIdEntero(CodigoCompratextBox.Text);
            if (compra.Eliminar())
            {
                MessageBox.Show("Eliminado Correctamente", "Confirmar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
            }
            else
            {
                MessageBox.Show("Error al Eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
