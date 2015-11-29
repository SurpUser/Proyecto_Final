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
        bool retorno = false;

        public ProteinaComprasForm()
        {
            InitializeComponent();
            CompraUsuariotextBox.Text = LoginForm.NombreUsuario;

            itbis = Seguridad.ValidarIdDouble(configuracion.Listado(" * ", " 1=1 ", "").Rows[0]["ITBIS"].ToString());           
            ITBISlabel.Text = itbis.ToString();
        }

        public void BuscarProteina()
        {
            CompraerrorProvider.Clear();

            if (CodigoProteinatextBox.Text.Length > 0)
            {
                proteina.ProteinaId = Seguridad.ValidarIdEntero(CodigoProteinatextBox.Text);
            }
            else
            {
                CompraerrorProvider.SetError(CodigoProteinatextBox, "Ingrese Un Codigo de Proteina");
                retorno = false;
            }

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
            int Convertido = 0;
            CompraerrorProvider.Clear();

            if (CodigoProveedortextBox.Text.Length > 0)
            {
                Convertido = Seguridad.ValidarIdEntero(CodigoProveedortextBox.Text);
            }
            else
            {
                CompraerrorProvider.SetError(CodigoProveedortextBox, "Ingrese Un Codigo de Proveedor");
                retorno = false;
            }

            if (proveedor.Buscar(Convertido))
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
            CompraerrorProvider.Clear();

            if (CantidadProteinatextBox.Text.Length > 0)
            {
                Cantidad = Convert.ToInt32(CantidadProteinatextBox.Text);
                ComprasdataGridView.Rows.Add(proteina.ProteinaId, proteina.Nombre, proteina.Costo, proteina.Precio, Cantidad, Cantidad * proteina.Costo + (itbis * proteina.Costo));
                CalcularMonto();
            }
            else
            {
                CompraerrorProvider.SetError(CantidadProteinatextBox, "Ingrese Una Cantidad");
                retorno = false;
            }        
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
            CodigoCompratextBox.Clear();
            ComprasdataGridView.Rows.Clear();
            NombreProveedortextBox.Clear();
            ProteinatextBox.Clear();
            CodigoProveedortextBox.Clear();
            CodigoProteinatextBox.Clear();
            CantidadProteinatextBox.Clear();
            Montolabel.Text = "0.00";
            CompraerrorProvider.Clear();
            NCFtextBox.Clear();
            compra.LimpiarList();
        }

        public bool LlenarDatos()
        {
            if (true)
            {
                CompraerrorProvider.Clear();
                retorno = true;
                compra.UsuarioId = LoginForm.UsuarioId;

                if (CodigoProveedortextBox.Text.Length > 0)
                {
                    compra.ProveedorId = Seguridad.ValidarIdEntero(CodigoProveedortextBox.Text);
                }
                else
                {
                    CompraerrorProvider.SetError(CodigoProveedortextBox, "Ingrese Un Codigo de Proveedor");
                    retorno = false;
                }
                
                compra.ITBS = itbis;
                compra.Fecha = FechadateTimePicker.Text;
                compra.Monto = Seguridad.ValidarIdDouble(Montolabel.Text);
                compra.NCF = NCFtextBox.Text;
                compra.Fecha = FechadateTimePicker.Text;
                compra.LimpiarList();

                for (int i = 0; i < ComprasdataGridView.RowCount; i++)
                {
                    compra.AgregarProteinas((int)ComprasdataGridView.Rows[i].Cells[0].Value, (int)ComprasdataGridView.Rows[i].Cells[4].Value, (double)ComprasdataGridView.Rows[i].Cells[5].Value);
                }
            }
            return retorno;
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
                        CompraerrorProvider.Clear();

                        if (CodigoCompratextBox.Text.Length > 0)
                        {
                            compra.CompraId = Seguridad.ValidarIdEntero(CodigoCompratextBox.Text);
                        }
                        else
                        {
                            CompraerrorProvider.SetError(CodigoCompratextBox, "Ingrese Un Codigo de Compra");
                            retorno = false;
                        }

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
                if (ComprasdataGridView.CurrentRow.Index >= 0)
                {
                    ComprasdataGridView.Rows.RemoveAt(ComprasdataGridView.CurrentRow.Index);
                    CalcularMonto();
                }
                else
                {
                    MessageBox.Show("Seleccione un Producto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            else
            {
                AgregarProducto();
                CodigoProteinatextBox.Clear();
                ProteinatextBox.Clear();
                CantidadProteinatextBox.Clear();
            }
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            CompraerrorProvider.Clear();

            if (Seguridad.ValidarIdEntero(CodigoCompratextBox.Text) > 0)
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
            else
            {
                CompraerrorProvider.SetError(CodigoCompratextBox, "Ingrese Un Codigo de Compra");
                retorno = false;
            }
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
            Guardarbutton.Image = Resources._1444608937_Save;
            Guardarbutton.Text = "Guardar";

            Agregarbutton.Image = Resources.Shopping_cart_add;
            Agregarbutton.Text = "Agregar";
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
            CompraerrorProvider.Clear();
            if (CodigoCompratextBox.Text.Length > 0)
            {
                compra.CompraId = Seguridad.ValidarIdEntero(CodigoCompratextBox.Text);
            }
            else
            {
                CompraerrorProvider.SetError(CodigoCompratextBox, "Ingrese Un Codigo de Compra");
                retorno = false;
            }

            CompraerrorProvider.Clear();
            compra.LimpiarList();
            ComprasdataGridView.Rows.Clear();
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
                    Guardarbutton.Image = Resources._1442108330_Modify;
                    Guardarbutton.Text = "Modificar";
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
            LlenarForm();          
        }

        private void ComprasdataGridView_Click(object sender, EventArgs e)
        {
            Mode = true;
            Agregarbutton.Image = Resources.basket___32;
            Agregarbutton.Text = "Eliminar";
        }
    }
}
