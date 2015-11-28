namespace StrongerGym.Consultas
{
    partial class CarnetClientesForm
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
            this.ClientescrystalReportViewer = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.SuspendLayout();
            // 
            // ClientescrystalReportViewer
            // 
            this.ClientescrystalReportViewer.ActiveViewIndex = -1;
            this.ClientescrystalReportViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ClientescrystalReportViewer.Cursor = System.Windows.Forms.Cursors.Default;
            this.ClientescrystalReportViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ClientescrystalReportViewer.Location = new System.Drawing.Point(0, 0);
            this.ClientescrystalReportViewer.Name = "ClientescrystalReportViewer";
            this.ClientescrystalReportViewer.Size = new System.Drawing.Size(674, 458);
            this.ClientescrystalReportViewer.TabIndex = 0;
            // 
            // CarnetClientesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 458);
            this.Controls.Add(this.ClientescrystalReportViewer);
            this.Name = "CarnetClientesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CarnetClientes";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        public CrystalDecisions.Windows.Forms.CrystalReportViewer ClientescrystalReportViewer;
    }
}