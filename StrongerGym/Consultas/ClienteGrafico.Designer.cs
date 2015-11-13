namespace StrongerGym.Consultas
{
    partial class ClienteGrafico
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.Clientechart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.Clientechart)).BeginInit();
            this.SuspendLayout();
            // 
            // Clientechart
            // 
            chartArea1.Name = "ChartArea1";
            this.Clientechart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.Clientechart.Legends.Add(legend1);
            this.Clientechart.Location = new System.Drawing.Point(0, 0);
            this.Clientechart.Name = "Clientechart";
            this.Clientechart.Size = new System.Drawing.Size(497, 343);
            this.Clientechart.TabIndex = 2;
            this.Clientechart.Text = "chart1";
            // 
            // ClienteGrafico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 343);
            this.Controls.Add(this.Clientechart);
            this.Name = "ClienteGrafico";
            this.Text = "ClienteGrafico";
            ((System.ComponentModel.ISupportInitialize)(this.Clientechart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataVisualization.Charting.Chart Clientechart;
    }
}