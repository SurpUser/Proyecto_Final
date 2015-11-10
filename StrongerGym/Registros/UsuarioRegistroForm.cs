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

namespace StrongerGym.Recursos
{
    public partial class RegistroUsuarioForm : Form
    {
        Usuarios usuario = new Usuarios();

        public RegistroUsuarioForm()
        {
            InitializeComponent();
            //FechaIniciomaskedTextBox.Text = String.Format("{0:dd/MM/yyyy}",DateTime.Now);
            AreacomboBox.SelectedIndex = 0;
        }

        void Limpiar()
        {
            NombretextBox.Clear();
            ContrasenatextBox.Clear();
            FechaIniciomaskedTextBox.Clear();
            AreacomboBox.SelectedIndex = 0;
        }

        public bool GuardarUsuario()
        {
            try
            {
                if (NombretextBox.Text.Length > 0 && ContrasenatextBox.Text.Length > 0)
                {
                    usuario.Nombre = NombretextBox.Text;
                    usuario.Contrasena = Seguridad.Encriptar(ContrasenatextBox.Text);
                    MessageBox.Show(usuario.Contrasena + "\n" + Seguridad.DesEncriptar(usuario.Contrasena));
                    usuario.FechaInicio = FechaIniciomaskedTextBox.Text;
                    usuario.Area = AreacomboBox.Text;
                }
                else
                {
                    return false;
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
            if (IdUsuariotextBox.Text.Length == 0)
            {

                if (GuardarUsuario())
                {
                    if (usuario.Insertar())
                    {
                        MessageBox.Show("Guardado correctamente");
                        Limpiar();
                    }
                }
                else
                {
                    MessageBox.Show("Faltan Campos","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            else
            {
                if (GuardarUsuario())
                {
                    int id = 0;
                    bool result = Int32.TryParse(IdUsuariotextBox.Text, out id);
                    usuario.IdUsuario = id;

                    if (usuario.Editar())
                    {
                        MessageBox.Show("Editado Correctamente.","Confirmar",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error al Modificar.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Faltan Campos");
                }
            }
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            
            if (IdUsuariotextBox.Text.Length > 0)
            {
                int Id = 0;
                bool result = Int32.TryParse(IdUsuariotextBox.Text, out Id);

                if (usuario.Buscar(Id))
                {
                    NombretextBox.Text = usuario.Nombre;
                    FechaIniciomaskedTextBox.Text = usuario.FechaInicio;
                    AreacomboBox.Text = usuario.Area;
                }
                else
                {
                    MessageBox.Show("Usuario no Existe");
                }
            }
            else
            {
                MessageBox.Show("Ingrese un Id.");
            }
        }

        private void Eliminarbutton_Click_1(object sender, EventArgs e)
        {
            try
            {
                usuario.IdUsuario = Convert.ToInt32(IdUsuariotextBox.Text);
                if (usuario.Eliminar())
                {
                    MessageBox.Show("Eliminado Correctamente.", "Eliminar");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Error al Eliminar", "Eliminar");
            }
        }
    }
}
