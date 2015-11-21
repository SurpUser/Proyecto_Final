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

namespace StrongerGym.R
{
    public partial class ConsultarForm : Form
    {
        Clientes cliente;
        public ConsultarForm()
        {
            InitializeComponent();
            cliente = new Clientes();

            BuscarcomboBox.SelectedIndex = 0;
            ModalidadcomboBox.SelectedIndex = 0;
            TiempocomboBox.SelectedIndex = 0;
        }

        public void LlenarFormulario()
        {
            NombretextBox.Text = cliente.Nombre;
            DirecciontextBox.Text = cliente.Direccion;
            TelefonomaskedTextBox.Text = cliente.Telefono;
            CelularmaskedTextBox.Text = cliente.Celular;
            PesotextBox.Text = cliente.Peso.ToString();
            AlturatextBox.Text = cliente.Altura.ToString();
            CiudadtextBox.Text = cliente.CiudadNombre;
            FechaNacimientodateTimePicker.Text = cliente.Fecha;
            ClientepictureBox.ImageLocation = cliente.Imagen;
            MasculinoradioButton.Checked = cliente.Sexo;
           
        }

        public int IntervaloFecha(int Dia, int Mes, int Ano)
        {
            DateTime fechaPago = new DateTime(Ano, Mes, Dia);
            DateTime fecha = DateTime.Now;
            TimeSpan ts = fecha - fechaPago;

            return ts.Days;
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            if (cliente.Buscar(Seguridad.ValidarIdEntero(BuscartextBox.Text)))
            {
                LlenarFormulario();

                int Dias;
                String[] resultado = cliente.Fecha.Split(new char[] { '/' });
                Dias = IntervaloFecha(Seguridad.ValidarIdEntero(resultado[0]), Seguridad.ValidarIdEntero(resultado[1]), Seguridad.ValidarIdEntero(resultado[2]));
                if (Dias > 0)
                {
                    MessageBox.Show(Dias + " Dias inactivo");
                }
                else
                {
                    MessageBox.Show("Se Vence en : " + -1 * Dias + " Dias");
                }
            }
            else
            {
                MessageBox.Show("Cliente No existe","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
        }
    }
}
