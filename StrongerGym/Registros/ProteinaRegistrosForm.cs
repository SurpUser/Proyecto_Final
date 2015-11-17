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
            ITBStextBox.Clear();
            CostotextBox.Clear();
            CantidadtextBox.Clear();
            TipoProteinaIdcomboBox.SelectedIndex = 0;
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        public int ConvertirEntero(string Textbox)
        {
            int Convertir = 0;

            bool Resultado = Int32.TryParse(Textbox, out Convertir);

            return Convertir;
        }

        public double ConvertirDouble(string Textbox)
        {
            double Convertir = 0.0;

            bool Resultado = Double.TryParse(Textbox, out Convertir);

            return Convertir;
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            
            if (ProteinaIdtextBox.Text.Length == 0)
            {
                proteina.ProteinaId = ConvertirEntero(ProteinaIdtextBox.Text);

                proteina.Nombre = NombretextBox.Text;

                proteina.Precio = ConvertirDouble(PreciotextBox.Text);

                proteina.ITBS = ConvertirDouble(ITBStextBox.Text);

                proteina.Cantidad = ConvertirEntero(CantidadtextBox.Text);

                proteina.TiposProteinaId = ConvertirEntero(TipoProteinaIdcomboBox.Text);

                proteina.Costo = ConvertirDouble(CostotextBox.Text);

                proteina.TiposProteinaId = (int)Tipoproteina.ObtenerTipoProteinaId(TipoProteinaIdcomboBox.Text).Rows[0]["TipoProteinaId"];

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
                proteina.ProteinaId = ConvertirEntero(ProteinaIdtextBox.Text);

                proteina.Nombre = NombretextBox.Text;

                proteina.Precio = ConvertirDouble(PreciotextBox.Text);

                proteina.ITBS = ConvertirDouble(ITBStextBox.Text);

                proteina.Cantidad = ConvertirEntero(CantidadtextBox.Text);

                proteina.Costo = ConvertirEntero(CostotextBox.Text);

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
                proteina.ProteinaId = ConvertirEntero(ProteinaIdtextBox.Text);

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
                if (proteina.Buscar(ConvertirEntero(ProteinaIdtextBox.Text)))
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
