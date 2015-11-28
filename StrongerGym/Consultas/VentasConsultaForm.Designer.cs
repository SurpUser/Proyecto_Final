namespace StrongerGym.Consultas
{
    partial class VentasConsultaForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.VentascrystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // VentascrystalReportViewer
            // 
            this.VentascrystalReportViewer.ActiveViewIndex = -1;
            this.VentascrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.VentascrystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.VentascrystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VentascrystalReportViewer.Location = new System.Drawing.Point(0, 0);
            this.VentascrystalReportViewer.Name = "VentascrystalReportViewer";
            this.VentascrystalReportViewer.Size = new System.Drawing.Size(821, 443);
            this.VentascrystalReportViewer.TabIndex = 0;
            // 
            // VentasConsultaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 443);
            this.Controls.Add(this.VentascrystalReportViewer);
            this.Name = "VentasConsultaForm";
            this.Text = "VentasConsultaForm";
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer VentascrystalReportViewer;
    }
}