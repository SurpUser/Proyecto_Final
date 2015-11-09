using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StrongerGym.R;
using StrongerGym.Recursos;
using StrongerGym.Registros;

namespace StrongerGym
{
    public partial class StrongerGymForms : Form
    {
        public StrongerGymForms()
        {
            InitializeComponent();
        }

        private void registrarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void consultarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void consultarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ConsultarForm c = new ConsultarForm();
            c.MdiParent = this;
            c.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            LoginForm Login = new LoginForm();
            Login.Show();
        }

        private void configuracionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void carnetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarnetForm carnet = new CarnetForm();
            carnet.MdiParent = this;
            carnet.Show();
        }

        private void registrarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RegistroForm rf = new RegistroForm();
            rf.MdiParent = this;
            rf.Show();
        }

        private void informacionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void salirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void registroUsuarioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RegistroUsuarioForm registro = new RegistroUsuarioForm();
            registro.MdiParent = this;
            registro.Show();
        }

        private void consultaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultaUsuarioForm usuario = new ConsultaUsuarioForm();
            usuario.Show();
        }

        protected override void OnClosed(EventArgs e)
        {
            DialogResult rs2 = MessageBox.Show("Desea Salir", "Mensaje", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (rs2 == DialogResult.Yes)
            {
                Application.Exit();
            }

        }

        private void generalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfiguracoinForm configuracion = new ConfiguracoinForm();
            configuracion.Show();
        }

        private void proteinasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProteinaRegistrosForm proteina = new ProteinaRegistrosForm();

            proteina.Show();
        }

        private void proveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProveedoreRegistrosForm proveedore = new ProveedoreRegistrosForm();

            proveedore.Show();
        }

        private void StrongerGymForms_Load(object sender, EventArgs e)
        {

        }

        private void registroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CiudadRegistroForm ciudad = new CiudadRegistroForm();
            ciudad.Show();
        }
    }
}
