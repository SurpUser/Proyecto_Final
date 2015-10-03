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
    public partial class ConsultarForm : Form
    {
        public ConsultarForm()
        {
            InitializeComponent();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void ConsultarForm_Load(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CodigotextBox.Text = "2203";

            NombretextBox.Text = "Juan Alberto Padilla";

            DirecciontextBox.Text = "Los Arroyos";

            CiudadtextBox.Text = "San Francisco de Macoris";

            TelefonotextBox.Text = "809-433-7183";

            CelulartextBox.Text = "809-720-7183";

            AlturatextBox.Text = "5.7 Pies";

            PesotextBox.Text = "150 kg";

            UltimoPtextBox.Text = "05/10/15";

            VencimientotextBox.Text = "04/11/15";


        }
    }
}
