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

        public ProveedoreRegistrosForm()
        {
            InitializeComponent();
        }

        public void Ciudades()
        {
            for (int i = 0; i < 1; i++)
            {

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
            DirecciontextBox.Clear();
            TelefonotextBox.Clear();
            CelulartextBox.Clear();
            EmailtextBox.Clear();
        }

        public bool GuardarProveedore()
        {
            if (NombreEmpresatextBox.Text.Length > 0 && NombreRepresentantetextBox.Text.Length > 0 && RNCtextBox.Text.Length > 0 && TelefonotextBox.Text.Length > 0)
            {
                int id = 0;
                //id = Convert.ToInt32(proveedor.Listado("ProveedorId","Nombre =",""));
                proveedor.CiudadId = 1;
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
                GuardarProveedore();
                if (proveedor.Insertar())
                {
                    MessageBox.Show("Guardado Correctamente.","Correcto");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Eror al Guardar","Error");
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

                }
            }
            catch (Exception)
            {

                MessageBox.Show("Error al Eliminar","Error"); ;
            }
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {

        }
    }
}
