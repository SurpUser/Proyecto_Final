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
        int Convertir = 0;
        double Convertir2 = 0.0;
        bool Resultado;

        public ProteinaRegistrosForm()
        {
            InitializeComponent();
            proteina = new Proteinas();
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            ProteinaIdtextBox.Clear();
            NombretextBox.Clear();
            PreciotextBox.Clear();
            ITBStextBox.Clear();
            CostotextBox.Clear();
            CantidadtextBox.Clear();
            TiposProteinacomboBox.SelectedIndex = 0;
            TiposProteinalistBox.Items.Clear();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            
            if (ProteinaIdtextBox.Text.Length == 0)
            {        
                Resultado = Int32.TryParse(ProteinaIdtextBox.Text, out Convertir);

                proteina.ProteinaId = Convertir;

                proteina.Nombre = NombretextBox.Text;

                Resultado = Double.TryParse(PreciotextBox.Text, out Convertir2);

                proteina.Precio = Convertir2;

                Resultado = Double.TryParse(ITBStextBox.Text, out Convertir2);

                proteina.ITBS = Convertir2;

                Resultado = Int32.TryParse(CantidadtextBox.Text, out Convertir);

                proteina.Cantidad = Convertir;

                Resultado = Double.TryParse(CostotextBox.Text, out Convertir2);

                proteina.Costo = Convertir2;

                if (proteina.Insertar())
                {
                    MessageBox.Show("Se guardo correctamente");
                }
                else
                {
                    MessageBox.Show("No se guardo");
                }
            }
            else
            {
                Resultado = Int32.TryParse(ProteinaIdtextBox.Text, out Convertir);

                proteina.ProteinaId = Convertir;

                proteina.Nombre = NombretextBox.Text;

                Resultado = Double.TryParse(PreciotextBox.Text, out Convertir2);

                proteina.Precio = Convertir2;

                Resultado = Double.TryParse(ITBStextBox.Text, out Convertir2);

                proteina.ITBS = Convertir2;

                Resultado = Int32.TryParse(CantidadtextBox.Text, out Convertir);

                proteina.Cantidad = Convertir;

                Resultado = Double.TryParse(CostotextBox.Text, out Convertir2);

                proteina.Costo = Convertir2;

                if (proteina.Editar())
                {
                    MessageBox.Show("Se edito correctamente");
                }
                else
                {
                    MessageBox.Show("No se edito");
                }
            }
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            Resultado = Int32.TryParse(ProteinaIdtextBox.Text, out Convertir);

            proteina.ProteinaId = Convertir;

            if (proteina.Eliminar())
            {
                MessageBox.Show("Se elimino correctamente");
            }
            else
            {
                MessageBox.Show("No se elimino");
            }
        }

        private void Agregarbutton_Click(object sender, EventArgs e)
        {
            TiposProteinalistBox.Items.Add(TiposProteinacomboBox.Text);
        }
    }
}
