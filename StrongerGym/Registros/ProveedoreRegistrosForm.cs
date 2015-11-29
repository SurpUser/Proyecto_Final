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
            CiudadescomboBox.DataSource = ciudad.Listado(" * ", "1=1", "");
            CiudadescomboBox.DisplayMember = "Nombre";
            CiudadescomboBox.ValueMember = "CiudadId";           
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
            TelefonomaskedTextBox.Clear();
            CelularmaskedTextBox.Clear();
            EmailtextBox.Clear();
            ProveedorerrorProvider.Clear();
        }

        public bool LlenarDatos()
        {
            bool retorno = true;
            Regex email = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
            ProveedorerrorProvider.Clear();

            if (email.IsMatch(EmailtextBox.Text))
            {
                proveedor.Email = EmailtextBox.Text;
            }
            else
            {
                ProveedorerrorProvider.SetError(EmailtextBox, "Email Incorrecto");
                retorno = false;
            }
            if (NombreEmpresatextBox.Text.Length > 0)
            {
                proveedor.NombreEmpresa = NombreEmpresatextBox.Text;
            }
            else
            {
                ProveedorerrorProvider.SetError(NombreEmpresatextBox, "Ingrese Un Nombre");
                retorno = false;
            }
            if (NombreRepresentantetextBox.Text.Length > 0)
            {
                proveedor.NombreRepresentante = NombreRepresentantetextBox.Text;
            }
            else
            {
                ProveedorerrorProvider.SetError(NombreRepresentantetextBox, "Ingrese Un Nombre");
                retorno = false;
            }
            if (RNCtextBox.Text.Length > 0)
            {
                proveedor.RNC = RNCtextBox.Text;
            }
            else
            {
                ProveedorerrorProvider.SetError(RNCtextBox, "Ingrese Un RNC");
                retorno = false;
            }
            if (DirecciontextBox.Text.Length > 0)
            {
                proveedor.Direccion = DirecciontextBox.Text;
            }
            else
            {
                ProveedorerrorProvider.SetError(DirecciontextBox, "Ingrese Una Direccion");
                retorno = false;
            }
            if (TelefonomaskedTextBox.Text.Length >= 14)
            {
                proveedor.Telefono = TelefonomaskedTextBox.Text;
            }
            else
            {
                ProveedorerrorProvider.SetError(TelefonomaskedTextBox, "Ingrese Un Telefono");
                retorno = false;
            }
            if (CelularmaskedTextBox.Text.Length >= 14)
            {
                proveedor.Celular = CelularmaskedTextBox.Text;
            }
            else
            {
                ProveedorerrorProvider.SetError(CelularmaskedTextBox, "Ingrese Un Celular");
                retorno = false;
            }
            proveedor.CiudadId = (int)CiudadescomboBox.SelectedValue;
            return retorno;
        }
        

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            try
            {
                if (ProveedorIdtextBox.Text.Length == 0)
                {
                    if (LlenarDatos())
                    {
                        if (proveedor.Insertar())
                        {
                            MessageBox.Show("Guardado Correctamente.", "Confirmacion",MessageBoxButtons.OK,MessageBoxIcon.Information);
                            Limpiar();
                        }
                        else
                        {
                            MessageBox.Show("Error al Guardar", "Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Faltan Campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    proveedor.ProveedorId = Seguridad.ValidarIdEntero(ProveedorIdtextBox.Text);

                    if (LlenarDatos())
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
                        MessageBox.Show("Faltan Campos","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (Seguridad.ValidarIdEntero(ProveedorIdtextBox.Text) > 0)
            {
                proveedor.ProveedorId = Seguridad.ValidarIdEntero(ProveedorIdtextBox.Text);
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

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            if (Seguridad.ValidarIdEntero(ProveedorIdtextBox.Text) > 0)
            {
                int ProveedorId = Seguridad.ValidarIdEntero(ProveedorIdtextBox.Text);

                if (proveedor.Buscar(ProveedorId))
                {
                    NombreEmpresatextBox.Text = proveedor.NombreEmpresa;
                    NombreRepresentantetextBox.Text = proveedor.NombreRepresentante;
                    RNCtextBox.Text = proveedor.RNC;
                    DirecciontextBox.Text = proveedor.Direccion;
                    CiudadescomboBox.Text = proveedor.CiudadNombre;
                    TelefonomaskedTextBox.Text = proveedor.Telefono;
                    CelularmaskedTextBox.Text = proveedor.Celular;
                    EmailtextBox.Text = proveedor.Email;

                }
                else
                {
                    MessageBox.Show("Id No Existe","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    Limpiar();
                }

            }
            else { MessageBox.Show("Ingrese un Id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
    }
}
