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
            ProteinaerrorProvider.Clear();
            ProteinaIdtextBox.Clear();
            NombretextBox.Clear();
            PreciotextBox.Clear();
            CostotextBox.Clear();
            TipoProteinaIdcomboBox.SelectedIndex = 0;
        }

        private void Nuevobutton_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        public bool LlenarDatos()
        {
            bool retorno = true;
            ProteinaerrorProvider.Clear();

            if (NombretextBox.Text.Length > 0)
            {
                proteina.Nombre = NombretextBox.Text;
            }
            else
            {
                ProteinaerrorProvider.SetError(NombretextBox, "Ingrese un Nombre");
                retorno = false;
            }

            if (Seguridad.ValidarIdEntero(PreciotextBox.Text) > 0)
            {
                proteina.Precio = Seguridad.ValidarIdDouble(PreciotextBox.Text);
            }
            else
            {
                ProteinaerrorProvider.SetError(PreciotextBox, "Ingrese un Precio");
                retorno = false;
            }
            
            proteina.TiposProteinaId = (int)TipoProteinaIdcomboBox.SelectedValue;

            if (Seguridad.ValidarIdEntero(CostotextBox.Text) > 0)
            {
                proteina.Costo = Seguridad.ValidarIdDouble(CostotextBox.Text);
            }
            else
            {
                ProteinaerrorProvider.SetError(CostotextBox, "Ingrese un Costo");
                retorno = false;
            }           
            return retorno;
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            
            if (ProteinaIdtextBox.Text.Length == 0)
            {
                if (LlenarDatos())
                {
                    if (proteina.Insertar())
                    {
                        MessageBox.Show("Guardado Correctamente","Confirmar",MessageBoxButtons.OK,MessageBoxIcon.Information);

                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("Error Al Guardar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Faltan Datos","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            else
            {
                if (LlenarDatos())
                {
                    if (proteina.Editar())
                    {
                        MessageBox.Show("Modificado Correctamente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Limpiar();
                    }
                    else
                    {
                        MessageBox.Show("Error Al Modificar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Faltan Datos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        private void Eliminarbutton_Click(object sender, EventArgs e)
        {
            if (Seguridad.ValidarIdEntero(ProteinaIdtextBox.Text) > 0)
            {
                proteina.ProteinaId = Seguridad.ValidarIdEntero(ProteinaIdtextBox.Text);
                if (proteina.Eliminar())
                {
                    MessageBox.Show("Eliminado Correctamente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                }
                else
                {
                    MessageBox.Show("Error Al Eliminar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                ProteinaerrorProvider.SetError(ProteinaIdtextBox, "Ingrese un Id Valido");
            }
        }

        private void Buscar_Click(object sender, EventArgs e)
        {
            if (Seguridad.ValidarIdEntero(ProteinaIdtextBox.Text) > 0)
            {       
                if (proteina.Buscar(Seguridad.ValidarIdEntero(ProteinaIdtextBox.Text)))
                {
                    NombretextBox.Text = proteina.Nombre;
                    PreciotextBox.Text = proteina.Precio.ToString();
                    CostotextBox.Text = proteina.Costo.ToString();
                    TipoProteinaIdcomboBox.Text = proteina.NombreProteina.ToString();
                }
                else
                {
                    MessageBox.Show("Id No Existe", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Ingrese un Id", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
