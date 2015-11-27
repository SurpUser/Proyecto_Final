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
using StrongerGym.Properties;
using StrongerGym.Consultas;
using StrongerGym.Reportes;

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
        bool Mode = false;

        public ProteinaVentaForm()
        {
            InitializeComponent();
            VentaUsuariotextBox.Text = LoginForm.NombreUsuario;

            itbis = Seguridad.ValidarIdDouble(configuracion.Listado(" * ", " 1=1 ", "").Rows[0]["ITBIS"].ToString());
            //CodigoVentatextBox.Text = venta.Listado("MAX(VentaId)+1 as VentaId", "1=1", "").Rows[0]["VentaId"].ToString();
            NCFtextBox.Text = configuracion.Listado("NCF","1=1","").Rows[0]["NCF"].ToString();
            ITBISlabel.Text = itbis.ToString();
        }

        private void VentasdataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
                MessageBox.Show("Codigo No Existe","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        public void BuscarCliente()
        {
            if (cliente.Buscar(Seguridad.ValidarIdEntero(CodigoClientetextBox.Text)))
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
            CodigoProteinatextBox.Clear();
            CantidadProteinatextBox.Clear();
            ProteinatextBox.Clear();
            Montolabel.Text = monto.ToString();
        }

        private void AgregarProductobutton_Click(object sender, EventArgs e)
        {
            if (Mode)
            {
                VentasdataGridView.Rows.RemoveAt(VentasdataGridView.CurrentRow.Index);
            }
            else
            {
                AgregarProducto();
            }
            
        }

        public void Limpiar()
        {
            VentaerrorProvider.Clear();
            VentasdataGridView.Rows.Clear();
            CodigoClientetextBox.Clear();
            CodigoProteinatextBox.Clear();
            NombreClientetextBox.Clear();
            ProteinatextBox.Clear();
            CantidadProteinatextBox.Clear();
            Montolabel.Text = "0.00";
            CodigoClientetextBox.ReadOnly = false;
            venta.LimpiarList();
        }

        public bool LlenarDatos()
        {
            if (true)
            {
                venta.UsuarioId = 1;
                venta.ClienteId = Seguridad.ValidarIdEntero(CodigoClientetextBox.Text);
                venta.ITBS = itbis;
                venta.Fecha = FechadateTimePicker.Text;
                venta.TotalVenta = Convert.ToDouble(Montolabel.Text);
                venta.NCF = NCFtextBox.Text;
                venta.LimpiarList();
                for (int i = 0; i < VentasdataGridView.RowCount; i++)
                {
                    venta.AgregarProteinas((int)VentasdataGridView.Rows[i].Cells[0].Value, (int)VentasdataGridView.Rows[i].Cells[3].Value, (double)VentasdataGridView.Rows[i].Cells[5].Value);
                }
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
            AgregarProteinabutton.Image = Resources.Shopping_cart_add;
            AgregarProteinabutton.Text = "Agregar";
            Mode = false;
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            if (LlenarDatos())
            {
                if (CodigoVentatextBox.Text.Length == 0)
                {
                    if (venta.Insertar())
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
                    if (Seguridad.ValidarIdEntero(CodigoVentatextBox.Text) > 0)
                    {
                        venta.VentaId = Seguridad.ValidarIdEntero(CodigoVentatextBox.Text);
                        if (venta.Editar())
                        {
                            MessageBox.Show("Modificado Correctamente", "Confirmar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Error al Modificar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        VentaerrorProvider.SetError(CodigoVentatextBox,"Codifo No Valido");
                    }
                }
            }
            
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            venta.VentaId = Seguridad.ValidarIdEntero(CodigoVentatextBox.Text);
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

        public void LlenarForm()
        {
            venta.VentaId = Seguridad.ValidarIdEntero(CodigoVentatextBox.Text);
            VentaerrorProvider.Clear();
            if (venta.VentaId > 0)
            {
                if (venta.Buscar(venta.VentaId))
                {
                    CodigoClientetextBox.Text = venta.ClienteId.ToString();
                    NombreClientetextBox.Text = venta.NombreCliente;
                    VentaUsuariotextBox.Text = venta.NombreUsuario;
                    NCFtextBox.Text = venta.NCF;
                    FechadateTimePicker.Text = venta.Fecha;
                    itbis = venta.ITBS;
                    Montolabel.Text = venta.TotalVenta.ToString();
                    foreach (var venta in venta.proteina)
                    {
                        VentasdataGridView.Rows.Add(venta.ProteinaId,venta.Nombre,venta.Precio,venta.Cantidad, itbis,venta.Importe);
                    }

                }
                else
                {
                    MessageBox.Show("La Venta No Existe","Comfirmacion",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
            }
            else
            {
                VentaerrorProvider.SetError(CodigoVentatextBox,"Codigo No Valido");
            }
        }
        private void BuscarVentabutton_Click(object sender, EventArgs e)
        {
            if (!CodigoVentatextBox.ReadOnly)
            {
                Guardarbutton.Image = Resources._1442108330_Modify;
                Guardarbutton.Text = "Modificar";
                Limpiar();
                LlenarForm();
            }
            
            CodigoVentatextBox.ReadOnly = false;
        }

        private void Facturarbutton_Click(object sender, EventArgs e)
        {
            VentasConsultaForm ventas = new VentasConsultaForm();
            VentasCrystalReport rpt = new VentasCrystalReport();
            rpt.SetParameterValue("VentaId",3);
            ventas.VentascrystalReportViewer.ReportSource = rpt;
            ventas.ShowDialog();
        }

        private void VentasdataGridView_Click(object sender, EventArgs e)
        {
            AgregarProteinabutton.Image = Resources._1442108658_trash;
            AgregarProteinabutton.Text = "Eliminar";
            Mode = true;
        }
    }
}
