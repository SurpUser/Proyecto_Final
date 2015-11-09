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
        int Convertir = 0;
        bool Resultado;

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
                Convertir = 0;

                Resultado = Int32.TryParse(TipoProteinaIdtextBox.Text, out Convertir);

                TipoProteina.TipoProteinaId = Convertir;

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
                Convertir = 0;

                Resultado = Int32.TryParse(TipoProteinaIdtextBox.Text, out Convertir);

                TipoProteina.TipoProteinaId = Convertir;

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
                Convertir = 0;

                Resultado = Int32.TryParse(TipoProteinaIdtextBox.Text, out Convertir);

                TipoProteina.TipoProteinaId = Convertir;

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
    }
}
