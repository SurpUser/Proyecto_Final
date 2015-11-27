using BLL;
using StrongerGym.Properties;
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
        bool Mode = false;

        public ProteinaComprasForm()
        {
            InitializeComponent();
            CompraUsuariotextBox.Text = LoginForm.NombreUsuario;

            itbis = Seguridad.ValidarIdDouble(configuracion.Listado(" * ", " 1=1 ", "").Rows[0]["ITBIS"].ToString());
            CodigoCompratextBox.Text = compra.Listado("MAX(CompraId)+1 as CompraId", "1=1", "").Rows[0]["CompraId"].ToString();
           
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

        public void BuscarProveedor()
        {
            if (proveedor.Buscar(Seguridad.ValidarIdEntero(CodigoProveedortextBox.Text)))
            {
                NombreProveedortextBox.Text = proveedor.NombreRepresentante;
                NCFtextBox.Text = proveedor.RNC;
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

            ComprasdataGridView.Rows.Add(proteina.ProteinaId, proteina.Nombre, proteina.Costo, proteina.Precio, Cantidad, Cantidad * proteina.Costo + (itbis * proteina.Costo));
            CalcularMonto();
            
        }

        public void CalcularMonto()
        {
            Montolabel.Text = "";
            monto = 0.0;
            for (int i = 0; i < ComprasdataGridView.RowCount; i++)
            {

                monto += (double)ComprasdataGridView.Rows[i].Cells[5].Value;
            }

            Montolabel.Text = monto.ToString();
        }

        public void Limpiar()
        {
            ComprasdataGridView.Rows.Clear();
            NombreProveedortextBox.Clear();
            ProteinatextBox.Clear();
            CodigoProveedortextBox.Clear();
            CodigoProteinatextBox.Clear();
            CantidadProteinatextBox.Clear();
            Montolabel.Text = "0.00";
            CodigoProveedortextBox.ReadOnly = false;
            CompraerrorProvider.Clear();
            NCFtextBox.Clear();
            compra.LimpiarList();
        }

        public bool LlenarDatos()
        {
            if (true)
            {
                compra.UsuarioId = LoginForm.UsuarioId;
                compra.ProveedorId = Seguridad.ValidarIdEntero(CodigoProveedortextBox.Text);
                compra.ITBS = itbis;
                compra.Fecha = FechadateTimePicker.Text;
                compra.Monto = Convert.ToDouble(Montolabel.Text);
                compra.NCF = NCFtextBox.Text;
                compra.Fecha = FechadateTimePicker.Text;
                compra.LimpiarList();

                for (int i = 0; i < ComprasdataGridView.RowCount; i++)
                {
                    compra.AgregarProteinas((int)ComprasdataGridView.Rows[i].Cells[0].Value, (int)ComprasdataGridView.Rows[i].Cells[4].Value, (double)ComprasdataGridView.Rows[i].Cells[5].Value);
                }
            }
            return true;
        }


        private void ProteinaComprasForm_Load(object sender, EventArgs e)
        {

        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            CompraerrorProvider.Clear();
            if (LlenarDatos())
            {
                if (CodigoCompratextBox.Text.Length == 0)
                {
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
                else
                {
                    if (Seguridad.ValidarIdEntero(CodigoCompratextBox.Text) > 0)
                    {
                        compra.CompraId = Seguridad.ValidarIdEntero(CodigoCompratextBox.Text);
                        if (compra.Editar())
                        {
                            MessageBox.Show("Modificado Correctamente", "Confirmar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Limpiar();
                        }
                        else
                        {
                            MessageBox.Show("Error al Modificar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        CompraerrorProvider.SetError(CodigoCompratextBox, "Codifo No Valido");
                    }
                }
            }
        }

        private void Agregarbutton_Click(object sender, EventArgs e)
        {
            if (Mode)
            {
                ComprasdataGridView.Rows.RemoveAt(ComprasdataGridView.CurrentRow.Index);
                CalcularMonto();
            }
            else
            {
                AgregarProducto();
            }
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
            Guardarbutton.Image = Resources._1444608937_Save;
            Guardarbutton.Text = "Guardar";
        }

        private void BuscarProveedorbutton_Click(object sender, EventArgs e)
        {
            BuscarProveedor();
        }

        private void BuscarProteinabutton_Click(object sender, EventArgs e)
        {
            BuscarProteina();
            Agregarbutton.Image = Resources.Shopping_cart_add;
            Agregarbutton.Text = "Agregar";
            Mode = false;
        }

        public void LlenarForm()
        {
            compra.CompraId = Seguridad.ValidarIdEntero(CodigoCompratextBox.Text);
            CompraerrorProvider.Clear();
            compra.LimpiarList();
            if (compra.CompraId > 0)
            {
                if (compra.Buscar(compra.CompraId))
                {
                    CodigoProveedortextBox.Text = compra.ProveedorId.ToString();
                    NombreProveedortextBox.Text = compra.NombreProveedor;
                    CompraUsuariotextBox.Text = compra.NombreUsuario;
                    NCFtextBox.Text = compra.NCF;
                    FechadateTimePicker.Text = compra.Fecha;
                    itbis = compra.ITBS;
                    Montolabel.Text = compra.Monto.ToString();
                    foreach (var compras in compra.proteina)
                    {
                        ComprasdataGridView.Rows.Add(compras.ProteinaId,compras.Nombre,compras.Costo,compras.Precio,compras.Cantidad,compras.Importe);
                    }

                }
                else
                {
                    MessageBox.Show("La Compra No Existe", "Comfirmacion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                CompraerrorProvider.SetError(CodigoCompratextBox, "Codigo No Valido");
            }
        }

        private void BuscarComprabutton_Click(object sender, EventArgs e)
        {
            Guardarbutton.Image = Resources._1442108330_Modify;
            Guardarbutton.Text = "Modificar";
            LlenarForm();          
        }

        private void ComprasdataGridView_Click(object sender, EventArgs e)
        {
            Mode = true;
            Agregarbutton.Image = Resources._1442108658_trash;
            Agregarbutton.Text = "Eliminar";
        }
    }
}
