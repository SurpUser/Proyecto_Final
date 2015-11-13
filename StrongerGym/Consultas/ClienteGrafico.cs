using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using BLL;

namespace StrongerGym.Consultas
{
    public partial class ClienteGrafico : Form
    {
        Usuarios usuario = new Usuarios();

        public ClienteGrafico()
        {
            InitializeComponent();
            CargarGrafico();
        }

        public void CargarGrafico()
        {
            /*string[] seriesArray = { "Cats", "perros" };
            int[] pointsArray = { 1, 2 };

            this.Clientechart.Palette = ChartColorPalette.SeaGreen;
            this.Clientechart.Titles.Add("Animales");

            for (int i = 0; i < seriesArray.Length; i++)
            {
                Series series = this.Clientechart.Series.Add(seriesArray[i]);
                series.Points.Add(pointsArray[i]);
            }
            */
            Clientechart.Titles.Add("Areas");
            Clientechart.Palette = ChartColorPalette.SeaGreen;
            Clientechart.Series.Add("Area");
            Clientechart.Series["Area"].XValueMember = "Area";
            Clientechart.Series["Area"].YValueMembers = "Cantidad";
           
            Clientechart.DataSource = usuario.GraficoUsuario();
            Clientechart.DataBind();
             
        }
    }
}
