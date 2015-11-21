using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StrongerGym.Registros;
using StrongerGym.Properties;
using BLL;

namespace StrongerGym.R
{
    public partial class RegistroForm : Form
    {
        Clientes cliente = new Clientes();
        Ciudades ciudad = new Ciudades();
        int numero = 0;

        public RegistroForm()
        {
            InitializeComponent();
            InicializarCiudades();
        }

        public void Limpiar()
        {
            ClienteIdtextBox.Clear();
            NombretextBox.Clear();
            DirecciontextBox.Clear();
            CiudadcomboBox.SelectedIndex = 0;
            TelefonomaskedTextBox.Clear();
            CelularmaskedTextBox.Clear();
            PesotextBox.Clear();
            AlturatextBox.Clear();
            ClientepictureBox.ImageLocation = null;
            MasculinoradioButton.Checked = true;
        }

        public void InicializarCiudades()
        {
            CiudadcomboBox.DataSource = ciudad.Listado(" * ", " 1=1 ", "");
            CiudadcomboBox.DisplayMember = "Nombre";
            CiudadcomboBox.ValueMember = "CiudadId";

            if (CiudadcomboBox.Items.Count > 0)
            {
                CiudadcomboBox.SelectedIndex = 0;
            }
            
        }
        

        public bool LlenarDatos()
        {
            try
            {
                if (NombretextBox.Text.Length > 0 && DirecciontextBox.Text.Length > 0 && TelefonomaskedTextBox.Text.Length > 0)
                {
                    cliente.Imagen = ClientepictureBox.ImageLocation.ToString();
                    cliente.Nombre = NombretextBox.Text;
                    cliente.Direccion = DirecciontextBox.Text;
                    cliente.CiudadId = (int)CiudadcomboBox.SelectedValue;
                    cliente.Telefono = TelefonomaskedTextBox.Text;
                    cliente.Celular = CelularmaskedTextBox.Text;
                    cliente.Altura = Convert.ToDouble(AlturatextBox.Text);
                    cliente.Peso = Convert.ToDouble(PesotextBox.Text);
                    cliente.Fecha = FechaNacimientodateTimePicker.Text;
                    cliente.Sexo = MasculinoradioButton.Checked;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Faltan Datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return true;
        }

        public void LlenarFormulario()
        {
            NombretextBox.Text = cliente.Nombre;
            DirecciontextBox.Text = cliente.Direccion;
            TelefonomaskedTextBox.Text = cliente.Telefono;
            CelularmaskedTextBox.Text = cliente.Celular;
            PesotextBox.Text = cliente.Peso.ToString();
            AlturatextBox.Text = cliente.Altura.ToString();
            CiudadcomboBox.Text = cliente.CiudadNombre;
            FechaNacimientodateTimePicker.Text = cliente.Fecha;
            ClientepictureBox.ImageLocation = cliente.Imagen;
        }

        public int IntervaloFecha(int Dia,int Mes,int Ano)
        {
            DateTime oldDate = new DateTime(Ano, Mes, Dia);
            DateTime newDate = DateTime.Now;
            
            TimeSpan ts = newDate - oldDate;
            return ts.Days;
        }

        private void HacerFoto_Click(object sender, EventArgs e)
        {
            HacerFotoForm foto = new HacerFotoForm();
            foto.ShowDialog();
            if (foto.Confirmar)
            {
                ClientepictureBox.ImageLocation = foto.sf.FileName;
            }
            else
            {
                ClientepictureBox.ImageLocation = null;
            }
            
        }

        private void SubirFotobutton_Click(object sender, EventArgs e)
        {
            ImagenopenFileDialog.ShowDialog();
            if (ImagenopenFileDialog.FileName != null)
            {
                ClientepictureBox.ImageLocation = ImagenopenFileDialog.FileName;
            }
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
            Guardarbutton.Image = Resources._1444608937_Save;
            Guardarbutton.Text = "Guardar";
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            if (Seguridad.ValidarIdEntero(ClienteIdtextBox.Text) > 0)
            {

                if (cliente.Buscar(Seguridad.ValidarIdEntero(ClienteIdtextBox.Text)))
                {
                    Guardarbutton.Image = Resources._1442108330_Modify;
                    Guardarbutton.Text = "Modificar";
                    LlenarFormulario();
                    //--------------------------------
                    int Dias;
                    String [] resultado = cliente.Fecha.Split(new char[] {'/'});
                    Dias = IntervaloFecha(Convert.ToInt32(resultado[0]), Convert.ToInt32(resultado[1]), Convert.ToInt32(resultado[2]));
                    if (Dias > 0)
                    {
                        MessageBox.Show(Dias + " Dias inactivo");
                    }
                    else
                    {
                        MessageBox.Show("Se Vence en :"+Dias +" Dias");
                    }
                    
            }
                else
                {
                    MessageBox.Show("Cliente No Existe", "Comfirmar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Id Incorrecto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            try
            {
                if (LlenarDatos())
                {
                    if (cliente.Insertar())
                    {
                        MessageBox.Show("Guardado Correctamente","Comfirmar",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("Error Al Guardar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Faltan Datos","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Inesperado"+ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            try
            {
                cliente.ClienteId = Seguridad.ValidarIdEntero(ClienteIdtextBox.Text);
                if (cliente.Eliminar())
                {
                    MessageBox.Show("Eliminado Correctamente", "Comfirmar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                }
                else
                {
                    MessageBox.Show("Error Al Eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error Al Eliminar","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
