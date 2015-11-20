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

            dt = Configurar.Listado(" * ", " 1=1 ", " ");

            if (Configurar.Listado(" * ", " 1=1 ", " ").Rows.Count > 0)
            {
                DiatextBox.Text = dt.Rows[0]["Dia"].ToString();
                SemanatextBox.Text = dt.Rows[0]["Semana"].ToString();
                MestextBox.Text = dt.Rows[0]["Mes"].ToString();
                AnotextBox.Text = dt.Rows[0]["Ano"].ToString();
                ITBIStextBox.Text = dt.Rows[0]["ITBIS"].ToString();
            }
            else
            {
                MessageBox.Show("Agrege una Configuracion", "Confirmar", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

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

        public bool LLenarDatos()
        {
            Configurar.Dia = ConvertirEntero(DiatextBox.Text);
            Configurar.Semana = ConvertirEntero(SemanatextBox.Text);
            Configurar.Mes = ConvertirEntero(MestextBox.Text);
            Configurar.Ano = ConvertirEntero(AnotextBox.Text);
            Configurar.ITBIS = ConvertirDouble(ITBIStextBox.Text);
            return true;
        }

        private void Configuracoin_Load(object sender, EventArgs e)
        {

        }

        private void Guardarbutton_Click(object sender, EventArgs e)
        {
            if (Configurar.Listado(" * ", " 1=1 ", " ").Rows.Count > 0)
            {
                LLenarDatos();

                if (Configurar.Editar())
                {
                    MessageBox.Show("Se Modifico correctamente");
                }
                else
                {
                    MessageBox.Show("No se modifico");
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
