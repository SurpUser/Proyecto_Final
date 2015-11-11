using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StrongerGym.Registros;

namespace StrongerGym.R
{
    public partial class RegistroForm : Form
    {
        public RegistroForm()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            HacerFotoForm foto = new HacerFotoForm();
            foto.ShowDialog();
            if (foto.Confirmar)
            {
                ClientepictureBox.ImageLocation = foto.sf.FileName;
            }
            
        }

        private void HacerFotobutton_Click(object sender, EventArgs e)
        {
            ImagenopenFileDialog.ShowDialog();
            if (ImagenopenFileDialog.FileName != null)
            {
                ClientepictureBox.ImageLocation = ImagenopenFileDialog.FileName;
            }
        }
    }
}
