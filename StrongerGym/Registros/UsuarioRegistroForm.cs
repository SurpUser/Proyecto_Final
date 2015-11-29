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
using System.Windows.Forms.DataVisualization.Charting;

namespace StrongerGym.Recursos
{
    public partial class RegistroUsuarioForm : Form
    {
        Usuarios usuario = new Usuarios();

        public RegistroUsuarioForm()
        {
            InitializeComponent();
            CargarGrafico();
            AreacomboBox.SelectedIndex = 0;
        }

        public void CargarGrafico()
        {
            Usuariochart.Titles.Add("Areas");
            Usuariochart.Palette = ChartColorPalette.SeaGreen;
            Usuariochart.Series.Add("Area");
            Usuariochart.Series["Area"].XValueMember = "Area";
            Usuariochart.Series["Area"].YValueMembers = "Cantidad";

            Usuariochart.DataSource = usuario.GraficoUsuario();
            Usuariochart.DataBind();
        }

        void Limpiar()
        {
            NombretextBox.Clear();
            ContrasenatextBox.Clear();
            FechaIniciomaskedTextBox.Clear();
            AreacomboBox.SelectedIndex = 0;
            UsuarioerrorProvider.Clear();
        }

        public bool LLenarDatos()
        {
            UsuarioerrorProvider.Clear();
            bool retorno = true;

            if (NombretextBox.Text.Length > 0)
            {
                usuario.Nombre = NombretextBox.Text;
            }
            else
            {
                UsuarioerrorProvider.SetError(NombretextBox,"Ingrese un Nombre");
                retorno = false;
            }
            if (ContrasenatextBox.Text.Length > 6)
            {
                usuario.Contrasena = Seguridad.Encriptar(ContrasenatextBox.Text);
            }
            else
            {
                UsuarioerrorProvider.SetError(ContrasenatextBox, "Ingrese un Contrasena Valida");
                retorno = false;
            }
            
            usuario.FechaInicio = FechaIniciomaskedTextBox.Text;
            usuario.Area = AreacomboBox.Text;
            return retorno;
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            if (IdUsuariotextBox.Text.Length == 0)
            {

                if (LLenarDatos())
                {
                    if (usuario.Insertar())
                    {
                        MessageBox.Show("Guardado Correctamente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Usuariochart.Refresh();
                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("Error Al Guardar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Faltan Campos","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            else
            {
                if (LLenarDatos())
                {
                    usuario.IdUsuario = Seguridad.ValidarIdEntero(IdUsuariotextBox.Text);

                    if (usuario.Editar())
                    {
                        MessageBox.Show("Editado Correctamente.","Confirmar",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error al Modificar.","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Faltan Campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Buscarbutton_Click(object sender, EventArgs e)
        {
            
            if (Seguridad.ValidarIdEntero(IdUsuariotextBox.Text) > 0)
            {
                if (usuario.Buscar(Seguridad.ValidarIdEntero(IdUsuariotextBox.Text)))
                {
                    NombretextBox.Text = usuario.Nombre;
                    FechaIniciomaskedTextBox.Text = usuario.FechaInicio;
                    AreacomboBox.Text = usuario.Area;
                }
                else
                {
                    
                    MessageBox.Show("Usuario no Existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Ingrese un Id Valido","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Eliminarbutton_Click_1(object sender, EventArgs e)
        {
            if (Seguridad.ValidarIdEntero(IdUsuariotextBox.Text) > 0)
            {
                usuario.IdUsuario = Seguridad.ValidarIdEntero(IdUsuariotextBox.Text);
                if (usuario.Eliminar())
                {
                    MessageBox.Show("Eliminado Correctamente.", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error al Eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Ingrese un Id Valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            
        }
    }
}
