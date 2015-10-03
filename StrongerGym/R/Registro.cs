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
    public partial class RegistroForm : Form
    {
        public RegistroForm()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }


        private void openFileDialog1_FileOk_1(object sender, CancelEventArgs e)
        {
            pictureBox1.ImageLocation = openFileDialog1.FileName;
        }
    }
}
