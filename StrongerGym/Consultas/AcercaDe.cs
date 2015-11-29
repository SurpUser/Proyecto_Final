using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StrongerGym.Consultas
{
    public partial class AcercaDe : Form
    {
        public AcercaDe()
        {
            InitializeComponent();
        }

        private void Okbutton_Click(object sender, EventArgs e)
        {
            this.Close();
            System.Diagnostics.Process.Start("http://fcprograms.somee.com");
        }
    }
}
