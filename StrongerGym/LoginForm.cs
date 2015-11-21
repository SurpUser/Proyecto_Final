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

namespace StrongerGym.R
{
    //Login y usuario
    public partial class LoginForm : Form
    {
        int intentos = 0;
        Usuarios usuario = new Usuarios();
        public static string NombreUsuario { get; set; }
        public LoginForm()
        {
            InitializeComponent();
        }

        public void IniciarSesion()
        {
            if (UsuariotextBox.Text.Length > 0 && ContrasenatextBox.Text.Length > 0)
            {
                usuario.Nombre = UsuariotextBox.Text;
                usuario.Contrasena = Seguridad.Encriptar(ContrasenatextBox.Text);
                if (usuario.InicioSesion())
                {
                    this.Visible = false;
                    StrongerGymForms sgf = new StrongerGymForms();
                    usuario.Permisos();
                    if (usuario.Area != "Administrativa")
                    {
                        sgf.registroUsuarioToolStripMenuItem.Visible = false;
                    }
                    sgf.Text = "StrongerGym [" + usuario.Nombre + "]";
                    NombreUsuario = usuario.Nombre;
                    sgf.Show();
                }
                else
                {
                    intentos++;
                    if (intentos >= 3)
                        this.Close();
                    MessageBox.Show("Usuario Incorrecto \n" + intentos + " Intentos Incorrectos.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Faltan Campos.","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void IniciarButton_Click(object sender, EventArgs e)
        {
            IniciarSesion();         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ContrasenatextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                IniciarSesion();
            }
        }

    }
}
