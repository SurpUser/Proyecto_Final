namespace StrongerGym.Recursos
{
    partial class ConsultaUsuarioForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConsultaUsuarioForm));
            this.label1 = new System.Windows.Forms.Label();
            this.BucarcomboBox = new System.Windows.Forms.ComboBox();
            this.BuscartextBox = new System.Windows.Forms.TextBox();
            this.ConsultadataGridView = new System.Windows.Forms.DataGridView();
            this.Cantidadlabelbox = new System.Windows.Forms.Label();
            this.Buscarbutton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ConsultadataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(207, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(181, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Consulta de Usuarios";
            // 
            // BucarcomboBox
            // 
            this.BucarcomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BucarcomboBox.FormattingEnabled = true;
            this.BucarcomboBox.Items.AddRange(new object[] {
            "Todo",
            "Por Nombre",
            "Por Id de Usuarios"});
            this.BucarcomboBox.Location = new System.Drawing.Point(85, 65);
            this.BucarcomboBox.Name = "BucarcomboBox";
            this.BucarcomboBox.Size = new System.Drawing.Size(116, 21);
            this.BucarcomboBox.TabIndex = 1;
            // 
            // BuscartextBox
            // 
            this.BuscartextBox.Location = new System.Drawing.Point(223, 65);
            this.BuscartextBox.Name = "BuscartextBox";
            this.BuscartextBox.Size = new System.Drawing.Size(181, 20);
            this.BuscartextBox.TabIndex = 2;
            // 
            // ConsultadataGridView
            // 
            this.ConsultadataGridView.AllowUserToAddRows = false;
            this.ConsultadataGridView.AllowUserToDeleteRows = false;
            this.ConsultadataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ConsultadataGridView.Location = new System.Drawing.Point(14, 118);
            this.ConsultadataGridView.Name = "ConsultadataGridView";
            this.ConsultadataGridView.ReadOnly = true;
            this.ConsultadataGridView.Size = new System.Drawing.Size(542, 244);
            this.ConsultadataGridView.TabIndex = 4;
            // 
            // Cantidadlabelbox
            // 
            this.Cantidadlabelbox.AutoSize = true;
            this.Cantidadlabelbox.Location = new System.Drawing.Point(424, 371);
            this.Cantidadlabelbox.Name = "Cantidadlabelbox";
            this.Cantidadlabelbox.Size = new System.Drawing.Size(106, 13);
            this.Cantidadlabelbox.TabIndex = 5;
            this.Cantidadlabelbox.Text = "Cantidad de Usuario:";
            // 
            // Buscarbutton
            // 
            this.Buscarbutton.Image = global::StrongerGym.Properties.Resources._1445977332_search_magnifying_glass_find;
            this.Buscarbutton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Buscarbutton.Location = new System.Drawing.Point(427, 59);
            this.Buscarbutton.Name = "Buscarbutton";
            this.Buscarbutton.Size = new System.Drawing.Size(68, 29);
            this.Buscarbutton.TabIndex = 3;
            this.Buscarbutton.Text = "Buscar";
            this.Buscarbutton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Buscarbutton.UseVisualStyleBackColor = true;
            this.Buscarbutton.Click += new System.EventHandler(this.Buscarbutton_Click);
            // 
            // ConsultaUsuarioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 393);
            this.Controls.Add(this.Cantidadlabelbox);
            this.Controls.Add(this.ConsultadataGridView);
            this.Controls.Add(this.Buscarbutton);
            this.Controls.Add(this.BuscartextBox);
            this.Controls.Add(this.BucarcomboBox);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConsultaUsuarioForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ConsultaUsuarioForm";
            ((System.ComponentModel.ISupportInitialize)(this.ConsultadataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox BucarcomboBox;
        private System.Windows.Forms.TextBox BuscartextBox;
        private System.Windows.Forms.Button Buscarbutton;
        private System.Windows.Forms.DataGridView ConsultadataGridView;
        private System.Windows.Forms.Label Cantidadlabelbox;
    }
}