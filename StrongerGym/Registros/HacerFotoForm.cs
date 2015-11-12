using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;

namespace StrongerGym.Registros
{
    public partial class HacerFotoForm : Form
    {
        private FilterInfoCollection Dispositivos;
        private VideoCaptureDevice FuenteDeVideo;
        public bool Confirmar = false;
        public SaveFileDialog sf;

        public HacerFotoForm()
        {
            InitializeComponent();
        }

        private void HacerFotoForm_Load(object sender, EventArgs e)
        {
            Dispositivos = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            foreach (FilterInfo x in Dispositivos)
            {
                CamarascomboBox.Items.Add(x.Name);
            }
            if (CamarascomboBox.Items.Count > 0)
            {
                CamarascomboBox.SelectedIndex = 0;
                Confirmar = true;
            }
            else
            {
                MessageBox.Show("No Hay Camara Disponible","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            if (Confirmar)
            {
                FuenteDeVideo = new VideoCaptureDevice(Dispositivos[CamarascomboBox.SelectedIndex].MonikerString);
                videoSourcePlayer1.VideoSource = FuenteDeVideo;
                videoSourcePlayer1.Start();
            }
            Confirmar = false;
        }

        private void HacerFotobutton_Click(object sender, EventArgs e)
        {
            sf = new SaveFileDialog();
            sf.Filter = "Imagenes JPG | *.jpg";
            sf.ShowDialog();

            if (sf.FileName != null)
            {
                Bitmap img = videoSourcePlayer1.GetCurrentVideoFrame();
                img.Save(sf.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                img.Dispose();
                Confirmar = true;
            }
            if (Confirmar)
            {
                videoSourcePlayer1.SignalToStop();
                this.Close();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FuenteDeVideo = new VideoCaptureDevice(Dispositivos[CamarascomboBox.SelectedIndex].MonikerString);
            videoSourcePlayer1.VideoSource = FuenteDeVideo;
            videoSourcePlayer1.Start();
        }
    }
}
