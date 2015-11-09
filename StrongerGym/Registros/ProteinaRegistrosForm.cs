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
            for (int i = 0; i < proteina.Listado("Nombre", "1=1", "").Rows.Count; i++)
            {
                TipoProteinaIdcomboBox.Items.Add(proteina.Listado("Nombre", "1=1", "").Rows[0]["Nombre"]);
            }
        }

        public void Limpiar()
        {
            ProteinaIdtextBox.Clear();
            NombretextBox.Clear();
            PreciotextBox.Clear();
            ITBStextBox.Clear();
            CostotextBox.Clear();
            CantidadtextBox.Clear();
            TipoProteinaIdcomboBox.SelectedIndex = 0;
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            
            if (ProteinaIdtextBox.Text.Length == 0)
            {
                Convertir = 0;

                Resultado = Int32.TryParse(ProteinaIdtextBox.Text, out Convertir);

                proteina.ProteinaId = Convertir;

                proteina.Nombre = NombretextBox.Text;

                Convertir2 = 0;

                Resultado = Double.TryParse(PreciotextBox.Text, out Convertir2);

                proteina.Precio = Convertir2;

                Convertir2 = 0;

                Resultado = Double.TryParse(ITBStextBox.Text, out Convertir2);

                proteina.ITBS = Convertir2;

                Convertir2 = 0;

                Resultado = Int32.TryParse(CantidadtextBox.Text, out Convertir);

                proteina.Cantidad = Convertir;

                Convertir = 0;

                Resultado = Int32.TryParse(TipoProteinaIdcomboBox.Text, out Convertir);

                proteina.TiposProteinaId = Convertir;

                Convertir2 = 0;

                Resultado = Double.TryParse(CostotextBox.Text, out Convertir2);

                proteina.Costo = Convertir2;

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
                Convertir = 0;

                Resultado = Int32.TryParse(ProteinaIdtextBox.Text, out Convertir);

                proteina.ProteinaId = Convertir;

                proteina.Nombre = NombretextBox.Text;

                Convertir2 = 0;

                Resultado = Double.TryParse(PreciotextBox.Text, out Convertir2);

                proteina.Precio = Convertir2;

                Convertir2 = 0;

                Resultado = Double.TryParse(ITBStextBox.Text, out Convertir2);

                proteina.ITBS = Convertir2;

                Convertir2 = 0;

                Resultado = Int32.TryParse(CantidadtextBox.Text, out Convertir);

                proteina.Cantidad = Convertir;

                Convertir2 = 0;

                Resultado = Double.TryParse(CostotextBox.Text, out Convertir2);

                proteina.Costo = Convertir2;

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
                Convertir = 0;

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
            catch (Exception ex)
            {

                throw ex;
            }

            Limpiar();
        }

        private void Agregarbutton_Click(object sender, EventArgs e){}

        private void Buscar_Click(object sender, EventArgs e)
        {
            Convertir = 0;

            if (ProteinaIdtextBox.Text.Length > 0)
            {       
                Resultado = Int32.TryParse(ProteinaIdtextBox.Text, out Convertir);

                if (proteina.Buscar(Convertir))
                {
                    NombretextBox.Text = proteina.Nombre;

                    PreciotextBox.Text = proteina.Precio.ToString();

                    ITBStextBox.Text = proteina.ITBS.ToString();

                    CantidadtextBox.Text = proteina.Cantidad.ToString();

                    CostotextBox.Text = proteina.Costo.ToString();
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
