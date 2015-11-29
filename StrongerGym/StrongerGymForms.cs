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
using StrongerGym.Consultas;

namespace StrongerGym
{
    public partial class StrongerGymForms : Form
    {
        public StrongerGymForms()
        {
            InitializeComponent();
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
            usuario.MdiParent = this;
            usuario.Show();
        }

        protected override void OnClosed(EventArgs e)
        {
             Application.Exit();
        }

        private void strongerGymToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AcercaDe acerca = new AcercaDe();
            acerca.ShowDialog();
        }

        //----------------------------------------------------------------------------
        private void RegistroProteinastoolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProteinaRegistrosForm proteina = new ProteinaRegistrosForm();
            proteina.MdiParent = this;
            proteina.Show();
        }

        private void ConsultaProteinastoolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProteinaConsultarForm Proteinaconsultar = new ProteinaConsultarForm();
            Proteinaconsultar.MdiParent = this;
            Proteinaconsultar.Show();
        }

        private void RegistroTipotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            TipoProteinaRegistroForm tipoProteina = new TipoProteinaRegistroForm();
            tipoProteina.MdiParent = this;
            tipoProteina.Show();
        }

        private void ConsultaTipotoolStripMenuItem_Click(object sender, EventArgs e)
        {
            TipoProteinaConsultarForm TiposProteinaconsultar = new TipoProteinaConsultarForm();
            TiposProteinaconsultar.MdiParent = this;
            TiposProteinaconsultar.Show();
        }

        private void RegistroProveedorestoolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProveedoreRegistrosForm proveedore = new ProveedoreRegistrosForm();
            proveedore.MdiParent = this;
            proveedore.Show();
        }

        private void ConsultaProveedorestoolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProveedoreConsultarForm Proveedorconsultar = new ProveedoreConsultarForm();
            Proveedorconsultar.MdiParent = this;
            Proveedorconsultar.Show();
        }

        private void RegistroCiudadestoolStripMenuItem_Click(object sender, EventArgs e)
        {
            CiudadRegistroForm ciudad = new CiudadRegistroForm();
            ciudad.MdiParent = this;
            ciudad.Show();
        }

        private void ConsultaCiudadestoolStripMenuItem_Click(object sender, EventArgs e)
        {
            CiudadConsultarForm Ciudadconsultar = new CiudadConsultarForm();
            Ciudadconsultar.MdiParent = this;
            Ciudadconsultar.Show();
        }

        private void CompratoolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ProteinaComprasForm compra = new ProteinaComprasForm();
            compra.MdiParent = this;
            compra.Show();
        }

        private void VentatoolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ProteinaVentaForm venta = new ProteinaVentaForm();
            venta.MdiParent = this;
            venta.Show();
        }

        private void registrarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RegistroForm usuario = new RegistroForm();
            usuario.MdiParent = this;
            usuario.Show();
        }

        private void consultarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ConsultarForm usuario = new ConsultarForm();
            usuario.MdiParent = this;
            usuario.Show();
        }

        private void configuracionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfiguracoinForm configuracion = new ConfiguracoinForm();
            configuracion.MdiParent = this;
            configuracion.Show();
        }
    }
}
