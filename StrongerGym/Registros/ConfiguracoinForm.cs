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
    public partial class ConfiguracoinForm : Form
    {
        Configuracion Configurar;

        public ConfiguracoinForm()
        {
            InitializeComponent();
            Configurar = new Configuracion();
            LLenarForm();
        }

        public void LLenarForm()
        {
            DataTable dt = new DataTable();

            try
            {

                dt = Configurar.Listado(" * ", " 1=1 ", " ");

                if (Configurar.Listado(" * ", " 1=1 ", " ").Rows.Count > 0)
                {
                    DiatextBox.Text = dt.Rows[0]["Dia"].ToString();
                    SemanatextBox.Text = dt.Rows[0]["Semana"].ToString();
                    MestextBox.Text = dt.Rows[0]["Mes"].ToString();
                    AnotextBox.Text = dt.Rows[0]["Ano"].ToString();
                    ITBIStextBox.Text = dt.Rows[0]["ITBIS"].ToString();
                    NCFtextBox.Text = dt.Rows[0]["NCF"].ToString();
                }
                else
                {
                    MessageBox.Show("Agrege una Configuracion", "Confirmar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public bool LLenarDatos()
        {
            ConfiguracionerrorProvider.Clear();
            bool retorno = true;

            if (Seguridad.ValidarIdEntero(DiatextBox.Text) > 0)
            {
                Configurar.Dia = Seguridad.ValidarIdEntero(DiatextBox.Text);
            }
            else
            {
                ConfiguracionerrorProvider.SetError(DiatextBox,"Ingrese el Precio");
                retorno = false;
            }

            if (Seguridad.ValidarIdEntero(SemanatextBox.Text) > 0)
            {
                Configurar.Semana = Seguridad.ValidarIdEntero(SemanatextBox.Text);
            }
            else
            {
                ConfiguracionerrorProvider.SetError(SemanatextBox, "Ingrese el Precio");
                retorno = false;
            }

            if (Seguridad.ValidarIdEntero(MestextBox.Text) > 0)
            {
                Configurar.Mes = Seguridad.ValidarIdEntero(MestextBox.Text);
            }
            else
            {
                ConfiguracionerrorProvider.SetError(MestextBox, "Ingrese el Precio");
                retorno = false;
            }

            if (Seguridad.ValidarIdEntero(AnotextBox.Text) > 0)
            {
                Configurar.Ano = Seguridad.ValidarIdEntero(AnotextBox.Text);
            }
            else
            {
                ConfiguracionerrorProvider.SetError(AnotextBox, "Ingrese el Precio");
                retorno = false;
            }

            if (Seguridad.ValidarIdDouble(ITBIStextBox.Text) > 0)
            {

                Configurar.ITBIS = Seguridad.ValidarIdDouble(ITBIStextBox.Text);
            }
            else
            {
                ConfiguracionerrorProvider.SetError(ITBIStextBox, "Ingrese el Precio");
                retorno = false;
            }

            if (NCFtextBox.Text.Length > 0)
            {
                Configurar.NCF = NCFtextBox.Text;
            }
            else
            {
                ConfiguracionerrorProvider.SetError(NCFtextBox, "Ingrese el NCF");
                retorno = false;
            }

            return retorno;
        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            if (Configurar.Listado(" * ", " 1=1 ", " ").Rows.Count > 0)
            {
                if (LLenarDatos())
                {
                    if (Configurar.Editar())
                    {
                        MessageBox.Show("Modificado Correctamente","Confirmacion",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error Al Modificar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Faltan Datos","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
            else
            {
                LLenarDatos();

                if (Configurar.Insertar())
                {
                    MessageBox.Show("Se guardo correctamente");
                }
                else
                {
                    MessageBox.Show("No se guardo");
                }
            }

        }

        private void Cancelarbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
