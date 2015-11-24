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
            TipoProteinaerrorProvider.Clear();
            TipoProteinaIdtextBox.Clear();
            NombretextBox.Clear();
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        public bool LlenarDato()
        {
            try
            {
                TipoProteinaerrorProvider.Clear();
                if (NombretextBox.Text.Length > 0)
                {
                    TipoProteina.Nombre = NombretextBox.Text;
                }
                else
                {
                    TipoProteinaerrorProvider.SetError(NombretextBox, "Ingrese Un Nombre");
                    return false;
                }
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            if (TipoProteinaIdtextBox.Text.Length == 0)
            {
                TipoProteina.TipoProteinaId = Seguridad.ValidarIdEntero(TipoProteinaIdtextBox.Text);

                if (LlenarDato())
                {

                    if (TipoProteina.Insertar())
                    {
                        MessageBox.Show("Guardado Correctamente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("Error Al Guardar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                TipoProteina.TipoProteinaId = Seguridad.ValidarIdEntero(TipoProteinaIdtextBox.Text);

                if (LlenarDato())
                {

                    if (TipoProteina.Editar())
                    {
                        MessageBox.Show("Modificado Correctamente","Confirmacion",MessageBoxButtons.OK,MessageBoxIcon.Information);

                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("Error Al Modificado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            if (Seguridad.ValidarIdEntero(TipoProteinaIdtextBox.Text) > 0)
            {
                TipoProteina.TipoProteinaId = Seguridad.ValidarIdEntero(TipoProteinaIdtextBox.Text);

                if (TipoProteina.Eliminar())
                {
                    MessageBox.Show("Eliminado Correctamente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error Al Eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Id No Valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Limpiar();
        }

        private void Buscar_Click(object sender, EventArgs e)
        {
            if (Seguridad.ValidarIdEntero(TipoProteinaIdtextBox.Text) > 0)
            {
                if (TipoProteina.Buscar(Seguridad.ValidarIdEntero(TipoProteinaIdtextBox.Text)))
                {
                    NombretextBox.Text = TipoProteina.Nombre;
                }
                else
                {
                    MessageBox.Show("Id No Existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Id No Valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
