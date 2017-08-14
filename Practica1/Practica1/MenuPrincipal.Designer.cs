namespace Practica1
{
    partial class MenuPrincipal
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
            this.btnVerDashboard = new System.Windows.Forms.Button();
            this.btnAdminMensajes = new System.Windows.Forms.Button();
            this.btnVerReportes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnVerDashboard
            // 
            this.btnVerDashboard.Location = new System.Drawing.Point(75, 55);
            this.btnVerDashboard.Name = "btnVerDashboard";
            this.btnVerDashboard.Size = new System.Drawing.Size(133, 40);
            this.btnVerDashboard.TabIndex = 0;
            this.btnVerDashboard.Text = "Ver Dashboard";
            this.btnVerDashboard.UseVisualStyleBackColor = true;
            this.btnVerDashboard.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnAdminMensajes
            // 
            this.btnAdminMensajes.Location = new System.Drawing.Point(75, 110);
            this.btnAdminMensajes.Name = "btnAdminMensajes";
            this.btnAdminMensajes.Size = new System.Drawing.Size(133, 40);
            this.btnAdminMensajes.TabIndex = 1;
            this.btnAdminMensajes.Text = "Administrar Mensajes";
            this.btnAdminMensajes.UseVisualStyleBackColor = true;
            this.btnAdminMensajes.Click += new System.EventHandler(this.btnAdminMensajes_Click);
            // 
            // btnVerReportes
            // 
            this.btnVerReportes.Location = new System.Drawing.Point(75, 165);
            this.btnVerReportes.Name = "btnVerReportes";
            this.btnVerReportes.Size = new System.Drawing.Size(133, 40);
            this.btnVerReportes.TabIndex = 2;
            this.btnVerReportes.Text = "Ver Reportes";
            this.btnVerReportes.UseVisualStyleBackColor = true;
            this.btnVerReportes.Click += new System.EventHandler(this.btnVerReportes_Click);
            // 
            // MenuPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.btnVerReportes);
            this.Controls.Add(this.btnAdminMensajes);
            this.Controls.Add(this.btnVerDashboard);
            this.Name = "MenuPrincipal";
            this.Text = "MenuPrincipal";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnVerDashboard;
        private System.Windows.Forms.Button btnAdminMensajes;
        private System.Windows.Forms.Button btnVerReportes;
    }
}