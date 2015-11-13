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
using StrongerGym.Properties;

namespace StrongerGym.R
{
    public partial class RegistroForm : Form
    {
        public RegistroForm()
        {
            InitializeComponent();
        }

        public void Limpiar()
        {
            ClienteIdtextBox.Clear();
            NombretextBox.Clear();
            DirecciontextBox.Clear();
            CiudadtextBox.Clear();
            TelefonomaskedTextBox.Clear();
            CelularmaskedTextBox.Clear();
            PesotextBox.Clear();
            AlturatextBox.Clear();
            ClientepictureBox.ImageLocation = null;
            HombreradioButton.Checked = true;
        }

        private void HacerFoto_Click(object sender, EventArgs e)
        {
            HacerFotoForm foto = new HacerFotoForm();
            foto.ShowDialog();
            if (foto.Confirmar)
            {
                ClientepictureBox.ImageLocation = foto.sf.FileName;
            }
            else
            {
                ClientepictureBox.ImageLocation = null;
            }
            
        }

        private void SubirFotobutton_Click(object sender, EventArgs e)
        {
            ImagenopenFileDialog.ShowDialog();
            if (ImagenopenFileDialog.FileName != null)
            {
                ClientepictureBox.ImageLocation = ImagenopenFileDialog.FileName;
            }
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
            Guardarbutton.Image = Resources._1444608937_Save;
            Guardarbutton.Text = "Guardar";
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            ClienteIdtextBox.ReadOnly = false;
            Guardarbutton.Image = Resources._1442108330_Modify;
            Guardarbutton.Text = "Modificar";
        }
    }
}
