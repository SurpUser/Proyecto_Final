using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StrongerGym.Consultas;
using BLL;

namespace StrongerGym.R
{
    public partial class ConsultarForm : Form
    {
        Clientes cliente;
        Cuotas cuota;
        Configuracion configuracion;
        DataTable dtconf;
        int ContoDia;
        int CoatoSemana;
        int CostoMes;
        int CostoAno;

        public ConsultarForm()
        {
            InitializeComponent();
            cliente = new Clientes();
            cuota = new Cuotas();
            configuracion = new Configuracion();
            dtconf = new DataTable();

            ModalidadcomboBox.SelectedIndex = 0;
            TiempocomboBox.SelectedIndex = 0;
            CargarModalidad();
        }

        public void CargarModalidad()
        {
            dtconf = configuracion.Listado(" * ","1=1","");
            ContoDia = (int)dtconf.Rows[0]["Dia"];
            CoatoSemana = (int)dtconf.Rows[0]["Semana"];
            CostoMes = (int)dtconf.Rows[0]["Mes"];
            CostoAno = (int)dtconf.Rows[0]["Ano"];
        }

        public void LlenarFormulario()
        {
            DataTable dtFecha = new DataTable();
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

        public void Limpiar()
        {
            NombretextBox.Clear();
            DirecciontextBox.Clear();
            TelefonomaskedTextBox.Clear();
            CelularmaskedTextBox.Clear();
            PesotextBox.Clear();
            AlturatextBox.Clear();
            CiudadtextBox.Clear();
            FechaNacimientodateTimePicker.Value = DateTime.Now;
            FechaMontodateTimePicker.Value = DateTime.Now;
            VencedateTimePicker.Value = DateTime.Now;
            ClientepictureBox.ImageLocation = null;
            MasculinoradioButton.Checked = true;
            ModalidadcomboBox.SelectedIndex = 0;
            TiempocomboBox.SelectedIndex = 0;
            UltimoPagotextBox.Clear();
            CantidadtextBox.Clear();
            Montolabel.Text = "0.00";
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            int Dias;
            if (cliente.Buscar(Seguridad.ValidarIdEntero(ClienteIdtextBox.Text)))
            {
                LlenarFormulario();
                
                if (cuota.Buscar(Seguridad.ValidarIdEntero(ClienteIdtextBox.Text)))
                {
                    VencedateTimePicker.Text = cuota.FechaVencimiento;
                    UltimoPagotextBox.Text = cuota.FechaCuota;
                    String[] resultado = cuota.FechaVencimiento.Split(new char[] { '/' });//cuota.FechaVencimiento
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
               
                
            }
            else
            {
                MessageBox.Show("Cliente No existe","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
        }

        public bool LlenarCuota()
        {
            try
            {
                cuota.FechaCuota = FechaMontodateTimePicker.Text;
                cuota.ClienteId = Seguridad.ValidarIdEntero(ClienteIdtextBox.Text);
                cuota.MontoCuota = Seguridad.ValidarIdDouble(Montolabel.Text);
                cuota.FechaVencimiento = VencedateTimePicker.Text;
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            if (LlenarCuota())
            {
                if (cuota.Buscar(Seguridad.ValidarIdEntero(ClienteIdtextBox.Text)) != true)
                {
                    if (cuota.Insertar())
                    {
                        MessageBox.Show("Guardado Correctamente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error al Guardar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    cuota.ClienteId = Seguridad.ValidarIdEntero(ClienteIdtextBox.Text);
                    if (cuota.Editar())
                    {
                        MessageBox.Show("Modificado Correctamente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error al Modificar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void ModalidadcomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ModalidadcomboBox.SelectedIndex == 0)
            {
                TiempocomboBox.SelectedIndex = 0;
            }
            if (ModalidadcomboBox.SelectedIndex == 1)
            {
                TiempocomboBox.SelectedIndex = 1;
            }
            if (ModalidadcomboBox.SelectedIndex == 2)
            {
                TiempocomboBox.SelectedIndex = 2;
            }
            if (ModalidadcomboBox.SelectedIndex == 3)
            {
                TiempocomboBox.SelectedIndex = 3;
            }
        }

        private void Aceptarbutton_Click(object sender, EventArgs e)
        {
            int cantidad = Seguridad.ValidarIdEntero(CantidadtextBox.Text);
            if (TiempocomboBox.SelectedIndex == 0)
            {
                Montolabel.Text = (ContoDia * cantidad).ToString();
                DateTime fecha = DateTime.Now.AddDays(cantidad);
                VencedateTimePicker.Text = fecha.ToString();
            }
            if (TiempocomboBox.SelectedIndex == 1)
            {
                Montolabel.Text = (CoatoSemana * cantidad).ToString();
                DateTime fecha = DateTime.Now.AddDays(7*cantidad);
                VencedateTimePicker.Text = fecha.ToString();
            }
            if (TiempocomboBox.SelectedIndex == 2)
            {
                Montolabel.Text = (CostoMes * cantidad).ToString();
                DateTime fecha = DateTime.Now.AddMonths(cantidad);
                VencedateTimePicker.Text = fecha.ToString();
            }
            if (TiempocomboBox.SelectedIndex == 3)
            {
                Montolabel.Text = (CostoAno * cantidad).ToString();
                DateTime fecha = DateTime.Now.AddYears(cantidad);
                VencedateTimePicker.Text = fecha.ToString();
            }
        }

        private void ClienteIdtextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                ClienteNombreConsultarForm consulta = new ClienteNombreConsultarForm();
                consulta.ShowDialog();
            }
        }

        private void Cancelarbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
