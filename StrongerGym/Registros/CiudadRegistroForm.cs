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
    public partial class CiudadRegistroForm : Form
    {
        Ciudades ciudad = new Ciudades();
        public CiudadRegistroForm()
        {
            InitializeComponent();
        }

        public void Limpiar()
        {
            CiudadIdtextBox.Clear();
            NombretextBox.Clear();
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        public bool GuardarCiudades()
        {
            try
            {
                if (NombretextBox.Text.Length > 0)
                {
                    ciudad.Nombre = NombretextBox.Text;
                }
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            try
            {
                if (GuardarCiudades())
                {
                    if (ciudad.Insertar())
                    {
                        MessageBox.Show("Guardado Correctamente","Correcto",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error Al Guardar","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Faltan Campos");
            }
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            try
            {
                if (ciudad.Eliminar())
                {
                    MessageBox.Show("Eliminado Correctamente", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error Al Eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Error Al Eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            try
            {
                int id = 0;
                bool DialogResult = Int32.TryParse(CiudadIdtextBox.Text,out id);
                if (ciudad.Buscar(id))
                {
                    NombretextBox.Text = ciudad.Nombre;
                }
                else
                {
                    MessageBox.Show("Id no Existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Id no Existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
