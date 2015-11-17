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

        private void consultarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ConsultarForm c = new ConsultarForm();
            c.MdiParent = this;
            c.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            LoginForm Login = new LoginForm();
            Login.Show();
        }

        private void carnetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarnetForm carnet = new CarnetForm();
            carnet.MdiParent = this;
            carnet.Show();
        }

        private void registrarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RegistroForm registro = new RegistroForm();
            registro.MdiParent = this;
            registro.Show();
        }

        private void salirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();

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
            usuario.MdiParent = this;
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
            configuracion.MdiParent = this;
            configuracion.Show();
        }

        private void registroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CiudadRegistroForm ciudad = new CiudadRegistroForm();
            ciudad.MdiParent = this;
            ciudad.Show();
        }

        private void registroToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ProteinaRegistrosForm proteina = new ProteinaRegistrosForm();
            proteina.MdiParent = this;
            proteina.Show();
        }

        private void registroToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            TipoProteinaRegistroForm tipoProteina = new TipoProteinaRegistroForm();
            tipoProteina.MdiParent = this;
            tipoProteina.Show();
        }



        private void compraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProteinaComprasForm compra = new ProteinaComprasForm();
            compra.MdiParent = this;
            compra.Show();
        }

        private void registroToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ProveedoreRegistrosForm proveedore = new ProveedoreRegistrosForm();
            proveedore.MdiParent = this;
            proveedore.Show();
        }
    }
}
