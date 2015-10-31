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
        public LoginForm()
        {
            InitializeComponent();
        }

        private void IniciarButton_Click(object sender, EventArgs e)
        {
            if (UsuariotextBox.Text.Length > 0 && ContrasenatextBox.Text.Length > 0)
            {
                usuario.Nombre = UsuariotextBox.Text;
                usuario.Contrasena = ContrasenatextBox.Text;
                if (usuario.InicioSesion())
                {
                    this.Visible = false;
                    StrongerGymForms sgf = new StrongerGymForms();
                    sgf.Show();
                }
                else
                {
                    intentos++;
                    if (intentos >= 3)
                        this.Close();
                    MessageBox.Show("Usuario Incorrecto " + intentos + "\n Intentos Incorrectos.");
                }
            }
            else
            {
                MessageBox.Show("Faltan Campos.");
            }
                    
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
