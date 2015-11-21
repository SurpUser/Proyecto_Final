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
    public partial class TipoProteinaRegistroForm : Form
    {
        TiposProteinas TipoProteina;

        public TipoProteinaRegistroForm()
        {
            InitializeComponent();
            TipoProteina = new TiposProteinas();
        }

        public void Limpiar()
        {
            TipoProteinaIdtextBox.Clear();
            NombretextBox.Clear();
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            if (TipoProteinaIdtextBox.Text.Length == 0)
            {
                TipoProteina.TipoProteinaId = Seguridad.ValidarIdEntero(TipoProteinaIdtextBox.Text);

                TipoProteina.Nombre = NombretextBox.Text;

                if (TipoProteina.Insertar())
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
                TipoProteina.TipoProteinaId = Seguridad.ValidarIdEntero(TipoProteinaIdtextBox.Text);

                TipoProteina.Nombre = NombretextBox.Text;

                if (TipoProteina.Editar())
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
                TipoProteina.TipoProteinaId = Seguridad.ValidarIdEntero(TipoProteinaIdtextBox.Text);

                if (TipoProteina.Eliminar())
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

        private void Buscar_Click(object sender, EventArgs e)
        {
            if (TipoProteinaIdtextBox.Text.Length > 0)
            {
                if (TipoProteina.Buscar(Seguridad.ValidarIdEntero(TipoProteinaIdtextBox.Text)))
                {
                    NombretextBox.Text = TipoProteina.Nombre;
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
