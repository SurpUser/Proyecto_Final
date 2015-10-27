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
        }

        void Limpiar()
        {
            NombretextBox.Clear();
            ContrasenatextBox.Clear();
            FechaIniciomaskedTextBox.Clear();
            AreacomboBox.SelectedIndex = 0;
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            if (NombretextBox.Text.Length > 0 && ContrasenatextBox.Text.Length > 0)
            {
                usuario.Nombre = NombretextBox.Text;
                usuario.Contrasena = ContrasenatextBox.Text;
                usuario.FechaInicio = FechaIniciomaskedTextBox.Text;
                usuario.Area = AreacomboBox.Text;

                if(usuario.Insertar())
                {
                    MessageBox.Show("Se guardo correctamente");
                    Limpiar();
                }
            }
            else
            {
                MessageBox.Show("Error al registrar");
            }
            
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt32(IdUsuariotextBox.Text);

            usuario.Buscar(Id);


        }
    }
}
