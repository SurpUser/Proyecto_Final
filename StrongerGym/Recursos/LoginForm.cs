using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StrongerGym.R
{
    public partial class LoginForm : Form
    {
        int intentos = 0;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (UsuariotextBox.Text == "Admin" && ContrasenatextBox.Text == "1234")
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
                MessageBox.Show("Usuario Incorrecto");
            }           

            
        }
    }
}
