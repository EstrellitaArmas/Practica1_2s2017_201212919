namespace Practica1
{
    partial class ColaMensajes
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
            this.btnOperar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCarnet = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtIp = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtResultado = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtInorden = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPost = new System.Windows.Forms.Label();
            this.txtCola = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOperar
            // 
            this.btnOperar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOperar.Location = new System.Drawing.Point(292, 28);
            this.btnOperar.Name = "btnOperar";
            this.btnOperar.Size = new System.Drawing.Size(127, 39);
            this.btnOperar.TabIndex = 0;
            this.btnOperar.Text = "Operar";
            this.btnOperar.UseVisualStyleBackColor = true;
            this.btnOperar.Click += new System.EventHandler(this.btnOperar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Operaciones en Cola";
            // 
            // txtCantidad
            // 
            this.txtCantidad.AutoSize = true;
            this.txtCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidad.Location = new System.Drawing.Point(210, 35);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(16, 16);
            this.txtCantidad.TabIndex = 2;
            this.txtCantidad.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(34, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(195, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Carnet que hizo el mensaje";
            // 
            // txtCarnet
            // 
            this.txtCarnet.AutoSize = true;
            this.txtCarnet.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtCarnet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCarnet.Location = new System.Drawing.Point(34, 116);
            this.txtCarnet.Name = "txtCarnet";
            this.txtCarnet.Size = new System.Drawing.Size(33, 16);
            this.txtCarnet.TabIndex = 5;
            this.txtCarnet.Text = "-----";
            this.txtCarnet.Click += new System.EventHandler(this.txtCarnet_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(34, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(164, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "IP que hizo el mensaje";
            // 
            // txtIp
            // 
            this.txtIp.AutoSize = true;
            this.txtIp.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtIp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIp.Location = new System.Drawing.Point(34, 186);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(33, 16);
            this.txtIp.TabIndex = 7;
            this.txtIp.Text = "-----";
            this.txtIp.Click += new System.EventHandler(this.txtIp_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(34, 221);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(192, 16);
            this.label7.TabIndex = 8;
            this.label7.Text = "Resultado de la operacion";
            // 
            // txtResultado
            // 
            this.txtResultado.AutoSize = true;
            this.txtResultado.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtResultado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResultado.Location = new System.Drawing.Point(34, 264);
            this.txtResultado.Name = "txtResultado";
            this.txtResultado.Size = new System.Drawing.Size(28, 16);
            this.txtResultado.TabIndex = 9;
            this.txtResultado.Text = "----";
            this.txtResultado.Click += new System.EventHandler(this.txtResultado_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(34, 302);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(157, 16);
            this.label9.TabIndex = 10;
            this.label9.Text = "Operacion en inorden";
            // 
            // txtInorden
            // 
            this.txtInorden.AutoSize = true;
            this.txtInorden.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtInorden.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInorden.Location = new System.Drawing.Point(34, 342);
            this.txtInorden.Name = "txtInorden";
            this.txtInorden.Size = new System.Drawing.Size(33, 16);
            this.txtInorden.TabIndex = 11;
            this.txtInorden.Text = "-----";
            this.txtInorden.Click += new System.EventHandler(this.txtInorden_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(34, 377);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(175, 16);
            this.label11.TabIndex = 12;
            this.label11.Text = "Operacion en postorden";
            // 
            // txtPost
            // 
            this.txtPost.AutoSize = true;
            this.txtPost.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtPost.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPost.Location = new System.Drawing.Point(34, 409);
            this.txtPost.Name = "txtPost";
            this.txtPost.Size = new System.Drawing.Size(33, 16);
            this.txtPost.TabIndex = 13;
            this.txtPost.Text = "-----";
            this.txtPost.Click += new System.EventHandler(this.txtPost_Click);
            // 
            // txtCola
            // 
            this.txtCola.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCola.Location = new System.Drawing.Point(458, 69);
            this.txtCola.Name = "txtCola";
            this.txtCola.Size = new System.Drawing.Size(223, 384);
            this.txtCola.TabIndex = 14;
            this.txtCola.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(485, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "COLA DE EJECUCION";
            // 
            // ColaMensajes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 465);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCola);
            this.Controls.Add(this.txtPost);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtInorden);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtResultado);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtIp);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtCarnet);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOperar);
            this.Name = "ColaMensajes";
            this.Text = "ColaMensajes";
            this.Load += new System.EventHandler(this.ColaMensajes_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOperar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txtCantidad;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label txtCarnet;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label txtIp;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label txtResultado;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label txtInorden;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label txtPost;
        private System.Windows.Forms.RichTextBox txtCola;
        private System.Windows.Forms.Label label2;
    }
}