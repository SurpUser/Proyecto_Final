﻿namespace StrongerGym.Recursos
{
    partial class RegistroUsuarioForm
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
            this.NombretextBox = new System.Windows.Forms.TextBox();
            this.LoginportadapictureBox = new System.Windows.Forms.PictureBox();
            this.ContrasenatextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.AreacomboBox = new System.Windows.Forms.ComboBox();
            this.Guardarbutton = new System.Windows.Forms.Button();
            this.Buscarbutton = new System.Windows.Forms.Button();
            this.Nuevobutton = new System.Windows.Forms.Button();
            this.IdUsuariotextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.FechaIniciomaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.LoginportadapictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // NombretextBox
            // 
            this.NombretextBox.Location = new System.Drawing.Point(179, 75);
            this.NombretextBox.Name = "NombretextBox";
            this.NombretextBox.Size = new System.Drawing.Size(241, 20);
            this.NombretextBox.TabIndex = 0;
            // 
            // LoginportadapictureBox
            // 
            this.LoginportadapictureBox.BackgroundImage = global::StrongerGym.Properties.Resources.user_icon;
            this.LoginportadapictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.LoginportadapictureBox.InitialImage = null;
            this.LoginportadapictureBox.Location = new System.Drawing.Point(22, 49);
            this.LoginportadapictureBox.Name = "LoginportadapictureBox";
            this.LoginportadapictureBox.Size = new System.Drawing.Size(133, 158);
            this.LoginportadapictureBox.TabIndex = 1;
            this.LoginportadapictureBox.TabStop = false;
            // 
            // ContrasenatextBox
            // 
            this.ContrasenatextBox.Location = new System.Drawing.Point(179, 113);
            this.ContrasenatextBox.Name = "ContrasenatextBox";
            this.ContrasenatextBox.Size = new System.Drawing.Size(241, 20);
            this.ContrasenatextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(179, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(179, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Contraseña";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(179, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Fecha de Inicio";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(179, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Area";
            // 
            // AreacomboBox
            // 
            this.AreacomboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AreacomboBox.FormattingEnabled = true;
            this.AreacomboBox.Items.AddRange(new object[] {
            "Administrativo",
            "Limitado"});
            this.AreacomboBox.Location = new System.Drawing.Point(179, 190);
            this.AreacomboBox.Name = "AreacomboBox";
            this.AreacomboBox.Size = new System.Drawing.Size(241, 21);
            this.AreacomboBox.TabIndex = 4;
            // 
            // Guardarbutton
            // 
            this.Guardarbutton.Image = global::StrongerGym.Properties.Resources._1443916247_Check;
            this.Guardarbutton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Guardarbutton.Location = new System.Drawing.Point(254, 228);
            this.Guardarbutton.Name = "Guardarbutton";
            this.Guardarbutton.Size = new System.Drawing.Size(85, 33);
            this.Guardarbutton.TabIndex = 5;
            this.Guardarbutton.Text = "Guardar";
            this.Guardarbutton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Guardarbutton.UseVisualStyleBackColor = true;
            this.Guardarbutton.Click += new System.EventHandler(this.Guardarbutton_Click);
            // 
            // Buscarbutton
            // 
            this.Buscarbutton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Buscarbutton.Location = new System.Drawing.Point(345, 228);
            this.Buscarbutton.Name = "Buscarbutton";
            this.Buscarbutton.Size = new System.Drawing.Size(85, 33);
            this.Buscarbutton.TabIndex = 5;
            this.Buscarbutton.Text = "Buscar";
            this.Buscarbutton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Buscarbutton.UseVisualStyleBackColor = true;
            this.Buscarbutton.Click += new System.EventHandler(this.Buscarbutton_Click);
            // 
            // Nuevobutton
            // 
            this.Nuevobutton.Image = global::StrongerGym.Properties.Resources._1442108115_Add;
            this.Nuevobutton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Nuevobutton.Location = new System.Drawing.Point(163, 228);
            this.Nuevobutton.Name = "Nuevobutton";
            this.Nuevobutton.Size = new System.Drawing.Size(85, 33);
            this.Nuevobutton.TabIndex = 5;
            this.Nuevobutton.Text = "Nuevo";
            this.Nuevobutton.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Nuevobutton.UseVisualStyleBackColor = true;
            this.Nuevobutton.Click += new System.EventHandler(this.Nuevobutton_Click);
            // 
            // IdUsuariotextBox
            // 
            this.IdUsuariotextBox.Location = new System.Drawing.Point(179, 36);
            this.IdUsuariotextBox.Name = "IdUsuariotextBox";
            this.IdUsuariotextBox.Size = new System.Drawing.Size(80, 20);
            this.IdUsuariotextBox.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(179, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Id";
            // 
            // FechaIniciomaskedTextBox
            // 
            this.FechaIniciomaskedTextBox.Location = new System.Drawing.Point(179, 150);
            this.FechaIniciomaskedTextBox.Mask = "00/00/0000";
            this.FechaIniciomaskedTextBox.Name = "FechaIniciomaskedTextBox";
            this.FechaIniciomaskedTextBox.ReadOnly = true;
            this.FechaIniciomaskedTextBox.Size = new System.Drawing.Size(241, 20);
            this.FechaIniciomaskedTextBox.TabIndex = 7;
            this.FechaIniciomaskedTextBox.ValidatingType = typeof(System.DateTime);
            // 
            // RegistroUsuarioForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 276);
            this.Controls.Add(this.FechaIniciomaskedTextBox);
            this.Controls.Add(this.IdUsuariotextBox);
            this.Controls.Add(this.Buscarbutton);
            this.Controls.Add(this.Nuevobutton);
            this.Controls.Add(this.Guardarbutton);
            this.Controls.Add(this.AreacomboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LoginportadapictureBox);
            this.Controls.Add(this.ContrasenatextBox);
            this.Controls.Add(this.NombretextBox);
            this.Name = "RegistroUsuarioForm";
            this.Text = "RegistroUsuarioForm";
            ((System.ComponentModel.ISupportInitialize)(this.LoginportadapictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox NombretextBox;
        private System.Windows.Forms.PictureBox LoginportadapictureBox;
        private System.Windows.Forms.TextBox ContrasenatextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox AreacomboBox;
        private System.Windows.Forms.Button Guardarbutton;
        private System.Windows.Forms.Button Buscarbutton;
        private System.Windows.Forms.Button Nuevobutton;
        private System.Windows.Forms.TextBox IdUsuariotextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox FechaIniciomaskedTextBox;
    }
}