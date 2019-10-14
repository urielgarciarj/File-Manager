namespace Practica1_SemSO
{
    partial class Descargas
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
            this.components = new System.ComponentModel.Container();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.btnDescargar = new System.Windows.Forms.Button();
            this.btnExplorador = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(70, 151);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(555, 23);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 0;
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(70, 37);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(555, 20);
            this.txtURL.TabIndex = 1;
            // 
            // btnDescargar
            // 
            this.btnDescargar.Location = new System.Drawing.Point(222, 76);
            this.btnDescargar.Name = "btnDescargar";
            this.btnDescargar.Size = new System.Drawing.Size(276, 45);
            this.btnDescargar.TabIndex = 2;
            this.btnDescargar.Text = "Descargar";
            this.btnDescargar.UseVisualStyleBackColor = true;
            this.btnDescargar.Click += new System.EventHandler(this.btnDescargar_Click);
            // 
            // btnExplorador
            // 
            this.btnExplorador.Location = new System.Drawing.Point(550, 87);
            this.btnExplorador.Name = "btnExplorador";
            this.btnExplorador.Size = new System.Drawing.Size(75, 23);
            this.btnExplorador.TabIndex = 3;
            this.btnExplorador.Text = "Explorador";
            this.btnExplorador.UseVisualStyleBackColor = true;
            this.btnExplorador.Click += new System.EventHandler(this.btnExplorador_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Descargas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 222);
            this.Controls.Add(this.btnExplorador);
            this.Controls.Add(this.btnDescargar);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.progressBar);
            this.Name = "Descargas";
            this.Text = "Descargas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnDescargar;
        private System.Windows.Forms.Button btnExplorador;
        public System.Windows.Forms.TextBox txtURL;
        public System.Windows.Forms.ProgressBar progressBar;
        public System.Windows.Forms.Timer timer1;
    }
}