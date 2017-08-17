namespace Practica1
{
    partial class Mensajes
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
            this.btnEnviarMensaje = new System.Windows.Forms.Button();
            this.btnVerCola = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // btnEnviarMensaje
            // 
            this.btnEnviarMensaje.Location = new System.Drawing.Point(80, 37);
            this.btnEnviarMensaje.Name = "btnEnviarMensaje";
            this.btnEnviarMensaje.Size = new System.Drawing.Size(114, 35);
            this.btnEnviarMensaje.TabIndex = 0;
            this.btnEnviarMensaje.Text = "Enviar Mensajes";
            this.btnEnviarMensaje.UseVisualStyleBackColor = true;
            this.btnEnviarMensaje.Click += new System.EventHandler(this.btnEnviarMensaje_Click);
            // 
            // btnVerCola
            // 
            this.btnVerCola.Location = new System.Drawing.Point(80, 100);
            this.btnVerCola.Name = "btnVerCola";
            this.btnVerCola.Size = new System.Drawing.Size(114, 42);
            this.btnVerCola.TabIndex = 1;
            this.btnVerCola.Text = "Ver Cola de Mensajes";
            this.btnVerCola.UseVisualStyleBackColor = true;
            this.btnVerCola.Click += new System.EventHandler(this.btnVerCola_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(80, 162);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 42);
            this.button1.TabIndex = 2;
            this.button1.Text = "Ver Respuesta de Mensajes";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Mensajes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 288);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnVerCola);
            this.Controls.Add(this.btnEnviarMensaje);
            this.Name = "Mensajes";
            this.Text = "Mensajes";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEnviarMensaje;
        private System.Windows.Forms.Button btnVerCola;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}