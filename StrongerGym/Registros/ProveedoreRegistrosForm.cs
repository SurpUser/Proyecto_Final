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
using System.Text.RegularExpressions;
using System.Globalization;

namespace StrongerGym.Registros
{
    public partial class ProveedoreRegistrosForm : Form
    {
        Proveedores proveedor = new Proveedores();
        Ciudades ciudad = new Ciudades();

        public ProveedoreRegistrosForm()
        {
            InitializeComponent();
            InicializarCiudades();
            CiudadescomboBox.SelectedIndex = 0;
        }

        public void InicializarCiudades()
        {
            for (int i = 0; i < ciudad.Listado("Nombre","1=1","").Rows.Count; i++)
            {
                CiudadescomboBox.Items.Add(ciudad.Listado("Nombre", "1=1", "").Rows[i]["Nombre"]);
            }
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        public void Limpiar()
        {
            ProveedorIdtextBox.Clear();
            NombreEmpresatextBox.Clear();
            NombreRepresentantetextBox.Clear();
            RNCtextBox.Clear();
            CiudadescomboBox.SelectedIndex = 0;
            DirecciontextBox.Clear();
            TelefonotextBox.Clear();
            CelulartextBox.Clear();
            EmailtextBox.Clear();
        }

        public bool GuardarProveedor()
        {
            if (NombreEmpresatextBox.Text.Length > 0 && NombreRepresentantetextBox.Text.Length > 0 && RNCtextBox.Text.Length > 0 && TelefonotextBox.Text.Length > 0 && DirecciontextBox.Text.Length > 0 && CelulartextBox.Text.Length > 0 && EmailtextBox.Text.Length > 0)
            {
                Regex email = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");

                if (email.IsMatch(EmailtextBox.Text))
                {
                    int id = 0;
                    id = (int)ciudad.ObtenerCiudadId(CiudadescomboBox.Text).Rows[0]["CiudadId"];
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
                    MessageBox.Show("Email Incorrecto","Error");
                    return false;
                }
                                   
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
                if (ProveedorIdtextBox.Text.Length == 0)
                {
                    if (GuardarProveedor())
                    {
                        if (proveedor.Insertar())
                        {
                            MessageBox.Show("Guardado Correctamente.", "Correcto");
                            Limpiar();
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
                else
                {
                    int id = 0;
                    bool result = Int32.TryParse(ProveedorIdtextBox.Text, out id);
                    proveedor.ProveedorId = id;

                    if (GuardarProveedor())
                    {
                        if (proveedor.Editar())
                        {
                            MessageBox.Show("Modificado Correctamente", "Confirmar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Limpiar();
                        }
                        else
                        {
                            MessageBox.Show("Error Al Modificar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Faltan Campos","Error");
                    }
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
                if (ProveedorIdtextBox.Text.Length != 0)
                {


                    int Id = 0;
                    bool result = Int32.TryParse(ProveedorIdtextBox.Text, out Id);
                    proveedor.ProveedorId = Id;
                    if (proveedor.Eliminar())
                    {
                        MessageBox.Show("Proveedor Eliminaro", "Correcto");
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("Error al Eliminar", "Error");
                    }
                }
                else
                {
                    MessageBox.Show("Ingrese un Id", "Advertencia", MessageBoxButtons.OK,MessageBoxIcon.Warning);
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
                int ProveedorId = id;

                if (proveedor.Buscar(ProveedorId))
                {
                    NombreEmpresatextBox.Text = proveedor.NombreEmpresa;
                    NombreRepresentantetextBox.Text = proveedor.NombreRepresentante;
                    RNCtextBox.Text = proveedor.RNC;
                    DirecciontextBox.Text = proveedor.Direccion;
                    CiudadescomboBox.Text = proveedor.CiudadNombre;
                    TelefonotextBox.Text = proveedor.Telefono;
                    CelulartextBox.Text = proveedor.Celular;
                    EmailtextBox.Text = proveedor.Email;

                }
                else
                {
                    MessageBox.Show("No Existe");
                    Limpiar();
                }

            }
            else { MessageBox.Show("Ingrese un Id"); }
        }
    }
}
