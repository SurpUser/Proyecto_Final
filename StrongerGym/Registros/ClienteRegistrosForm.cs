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
        
        public int ValidarEntero(string cadena)
        {
            if (cadena.Length > 0)
            {
                bool result = Int32.TryParse(cadena,out numero);
                if(result)
                return numero;
            }

            return 0;
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
                    cliente.Altura = ValidarEntero(AlturatextBox.Text);
                    cliente.Peso = ValidarEntero(PesotextBox.Text);
                    cliente.Fecha = FechaNacimientodateTimePicker.Text;

                    if (MasculinoradioButton.Checked)
                    {
                        cliente.Sexo = 1;
                    }
                    else
                    {
                        cliente.Sexo = 0;
                    }
                }
                else
                {
                    return false;
                }
                MessageBox.Show(cliente.Nombre+"\n"+cliente.Direccion+"\n"+cliente.CiudadId+"\n"+cliente.Telefono+"\n"+
                    cliente.Celular+"\n"+cliente.Altura+"\n"+cliente.Peso+"\n"+cliente.Fecha+"\n"+cliente.Sexo);
                
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }
            return true;
        }

        public void LlenarFormulario()
        {
            NombretextBox.Text = cliente.Nombre;
            DirecciontextBox.Text = cliente.Direccion;
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
           MessageBox.Show(ValidarEntero(ClienteIdtextBox.Text).ToString());
            if (cliente.Buscar(ValidarEntero(ClienteIdtextBox.Text)))
            {
                //ClienteIdtextBox.ReadOnly = false;
                Guardarbutton.Image = Resources._1442108330_Modify;
                Guardarbutton.Text = "Modificar";

                LlenarFormulario();
            }
            else
            {
                MessageBox.Show("Cliente No Existe","Comfirmar", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
