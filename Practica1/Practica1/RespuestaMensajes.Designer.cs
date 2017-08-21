namespace Practica1
{
    partial class RespuestaMensajes
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
            this.dataRespuestas = new System.Windows.Forms.DataGridView();
            this.carnet = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inorden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.postorden = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resultado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataRespuestas)).BeginInit();
            this.SuspendLayout();
            // 
            // dataRespuestas
            // 
            this.dataRespuestas.AllowUserToAddRows = false;
            this.dataRespuestas.AllowUserToDeleteRows = false;
            this.dataRespuestas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataRespuestas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.carnet,
            this.ip,
            this.inorden,
            this.postorden,
            this.resultado});
            this.dataRespuestas.Location = new System.Drawing.Point(1, 1);
            this.dataRespuestas.Name = "dataRespuestas";
            this.dataRespuestas.ReadOnly = true;
            this.dataRespuestas.Size = new System.Drawing.Size(548, 197);
            this.dataRespuestas.TabIndex = 0;
            // 
            // carnet
            // 
            this.carnet.HeaderText = "Carnet que opero";
            this.carnet.Name = "carnet";
            this.carnet.ReadOnly = true;
            // 
            // ip
            // 
            this.ip.HeaderText = "Ip que opero";
            this.ip.Name = "ip";
            this.ip.ReadOnly = true;
            // 
            // inorden
            // 
            this.inorden.HeaderText = "Inorden";
            this.inorden.Name = "inorden";
            this.inorden.ReadOnly = true;
            // 
            // postorden
            // 
            this.postorden.HeaderText = "Postorden";
            this.postorden.Name = "postorden";
            this.postorden.ReadOnly = true;
            // 
            // resultado
            // 
            this.resultado.HeaderText = "Resultado";
            this.resultado.Name = "resultado";
            this.resultado.ReadOnly = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(53, 220);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(227, 41);
            this.button1.TabIndex = 1;
            this.button1.Text = "Mostrar empezando por las mas antiguas";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(286, 220);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(218, 41);
            this.button2.TabIndex = 2;
            this.button2.Text = "Mostrar empezando por las mas recientes";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(83, 267);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(385, 36);
            this.button3.TabIndex = 3;
            this.button3.Text = "Regresar";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // RespuestaMensajes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 331);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataRespuestas);
            this.Name = "RespuestaMensajes";
            this.Text = "RespuestaMensajes";
            ((System.ComponentModel.ISupportInitialize)(this.dataRespuestas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataRespuestas;
        private System.Windows.Forms.DataGridViewTextBoxColumn carnet;
        private System.Windows.Forms.DataGridViewTextBoxColumn ip;
        private System.Windows.Forms.DataGridViewTextBoxColumn inorden;
        private System.Windows.Forms.DataGridViewTextBoxColumn postorden;
        private System.Windows.Forms.DataGridViewTextBoxColumn resultado;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}