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
    public partial class ProveedoreRegistrosForm : Form
    {
        Proveedores proveedor = new Proveedores();
        Ciudades ciudad = new Ciudades();

        public ProveedoreRegistrosForm()
        {
            InitializeComponent();
            Ciudades();
            CiudadescomboBox.SelectedIndex = 0;
        }

        public void Ciudades()
        {
            for (int i = 0; i < ciudad.Listado("Nombre","1=1","").Rows.Count; i++)
            {
                CiudadescomboBox.Items.Add(ciudad.Listado("Nombre", "1=1", "").Rows[0]["Nombre"]);
            }
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        public void Limpiar()
        {
            NombreEmpresatextBox.Clear();
            NombreRepresentantetextBox.Clear();
            RNCtextBox.Clear();
            DirecciontextBox.Clear();
            TelefonotextBox.Clear();
            CelulartextBox.Clear();
            EmailtextBox.Clear();
        }

        public bool GuardarProveedor()
        {
            if (NombreEmpresatextBox.Text.Length > 0 && NombreRepresentantetextBox.Text.Length > 0 && RNCtextBox.Text.Length > 0 && TelefonotextBox.Text.Length > 0)
            {
                int id = 1;
                id = (int)ciudad.ObtenerCiudadId("Tenares").Rows[0]["CiudadId"];
                proveedor.CiudadId = id;
                proveedor.NombreEmpresa = NombreEmpresatextBox.Text;
                proveedor.NombreRepresentante = NombreRepresentantetextBox.Text;
                proveedor.RNC = RNCtextBox.Text;
                proveedor.Direccion = DirecciontextBox.Text;
                proveedor.Telefono = TelefonotextBox.Text;
                proveedor.Celular = CelulartextBox.Text;
                proveedor.Email = EmailtextBox.Text;
                return true;
            }
            else
            {
                return false;
            }
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            try
            {
                if (GuardarProveedor())
                {
                    if (proveedor.Insertar())
                    {
                        MessageBox.Show("Guardado Correctamente.", "Correcto");
                    }
                    else
                    {
                        MessageBox.Show("Error al Guardar", "Error");
                    }

                }
                else
                {
                    MessageBox.Show("Faltan Campos", "Error");
                }
                
                
            }
            catch (Exception)
            {

                MessageBox.Show("Error inesperado","Error");
            }
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            try
            {
                int Id = 0;
                bool result = Int32.TryParse(ProveedorIdtextBox.Text,out Id); 
                proveedor.ProveedorId = Id;
                if (proveedor.Eliminar())
                {
                    MessageBox.Show("Proveedor Eliminaro","Correcto");
                    Limpiar();
                }
                else
                {
                    MessageBox.Show("Error al Eliminar", "Error");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Error inesperado", "Error");
            }
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            if (ProveedorIdtextBox.Text.Length > 0)
            {
                int id = 1;
                bool result = Int32.TryParse(ProveedorIdtextBox.Text,out id);
                int PeliculaId = id;
                if (proveedor.Buscar(PeliculaId))
                {
                    Limpiar();
                    NombreEmpresatextBox.Text = proveedor.NombreEmpresa;
                    NombreRepresentantetextBox.Text = proveedor.NombreRepresentante;
                    RNCtextBox.Text = proveedor.RNC;
                    DirecciontextBox.Text = proveedor.Direccion;
                    CiudadescomboBox.Text = ciudad.Nombre;
                    TelefonotextBox.Text = proveedor.Telefono;
                    CelulartextBox.Text = proveedor.Celular;
                    EmailtextBox.Text = proveedor.Email;

                }
                else
                {
                    MessageBox.Show("No Existe");
                }

            }
            else { MessageBox.Show("Seleccione un Id"); }
        }
    }
}
