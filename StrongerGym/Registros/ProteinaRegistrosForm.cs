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

namespace StrongerGym.Registros
{
    public partial class ProteinaRegistrosForm : Form
    {
        Proteinas proteina;
        TiposProteinas Tipoproteina;

        public ProteinaRegistrosForm()
        {
            InitializeComponent();
            proteina = new Proteinas();
            Tipoproteina = new TiposProteinas();

            TipoProteinaIdcomboBox.DataSource = Tipoproteina.Listado(" * ", "1=1", " ");
            TipoProteinaIdcomboBox.DisplayMember = "Nombre";
            TipoProteinaIdcomboBox.ValueMember = "TipoProteinaId";
        }

        public void Limpiar()
        {
            ProteinaIdtextBox.Clear();
            NombretextBox.Clear();
            PreciotextBox.Clear();
            CostotextBox.Clear();
            TipoProteinaIdcomboBox.SelectedIndex = 0;
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        public bool LlenarDatos()
        {
            proteina.ProteinaId = Seguridad.ValidarIdEntero(ProteinaIdtextBox.Text);

            proteina.Nombre = NombretextBox.Text;

            proteina.Precio = Seguridad.ValidarIdDouble(PreciotextBox.Text);

            proteina.TiposProteinaId = (int)TipoProteinaIdcomboBox.SelectedValue;

            proteina.Costo = Seguridad.ValidarIdDouble(CostotextBox.Text);
            return true;
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            
            if (ProteinaIdtextBox.Text.Length == 0)
            {
                LlenarDatos();

                if (proteina.Insertar())
                {
                    MessageBox.Show("Se guardo correctamente");

                    Limpiar();
                }
                else
                {
                    MessageBox.Show("No se guardo");
                }
            }
            else
            {
                LlenarDatos();

                if (proteina.Editar())
                {
                    MessageBox.Show("Se edito correctamente");

                    Limpiar();
                }
                else
                {
                    MessageBox.Show("No se edito");
                }
            }
            
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            try
            {
                proteina.ProteinaId = Seguridad.ValidarIdEntero(ProteinaIdtextBox.Text);

                if (proteina.Eliminar())
                {
                    MessageBox.Show("Se elimino correctamente");
                }
                else
                {
                    MessageBox.Show("No se elimino");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            Limpiar();
        }

        private void Agregarbutton_Click(object sender, EventArgs e){}

        private void Buscar_Click(object sender, EventArgs e)
        {
            if (ProteinaIdtextBox.Text.Length > 0)
            {       
                if (proteina.Buscar(Seguridad.ValidarIdEntero(ProteinaIdtextBox.Text)))
                {
                    NombretextBox.Text = proteina.Nombre;

                    PreciotextBox.Text = proteina.Precio.ToString();

                    CostotextBox.Text = proteina.Costo.ToString();

                    TipoProteinaIdcomboBox.Text = proteina.NombreProteina.ToString();
                }
                else
                {
                    MessageBox.Show("No encontro ese Id");
                }
            }
            else
            {
                MessageBox.Show("Ingrese un Id");
            }
        }
    }
}
