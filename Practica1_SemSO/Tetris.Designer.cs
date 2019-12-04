namespace Practica1_SemSO
{
    partial class Tetris
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Tetris));
            this.btnStart = new System.Windows.Forms.Button();
            this.tetrisPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.sigPictureBox = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.puntuacionLabel = new System.Windows.Forms.Label();
            this.tetrisTC = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tetrisTimer = new System.Windows.Forms.Timer(this.components);
            this.tetrisImagenes = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.sigPictureBox)).BeginInit();
            this.tetrisTC.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(281, 458);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Empezar";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // tetrisPanel
            // 
            this.tetrisPanel.BackColor = System.Drawing.Color.Black;
            this.tetrisPanel.Location = new System.Drawing.Point(0, 0);
            this.tetrisPanel.Name = "tetrisPanel";
            this.tetrisPanel.Size = new System.Drawing.Size(253, 500);
            this.tetrisPanel.TabIndex = 2;
            // 
            // sigPictureBox
            // 
            this.sigPictureBox.BackColor = System.Drawing.Color.Black;
            this.sigPictureBox.Location = new System.Drawing.Point(256, 46);
            this.sigPictureBox.Name = "sigPictureBox";
            this.sigPictureBox.Size = new System.Drawing.Size(100, 100);
            this.sigPictureBox.TabIndex = 3;
            this.sigPictureBox.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(256, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(54, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Siguiente:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(259, 188);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Puntuacion:";
            // 
            // puntuacionLabel
            // 
            this.puntuacionLabel.AutoSize = true;
            this.puntuacionLabel.ForeColor = System.Drawing.Color.White;
            this.puntuacionLabel.Location = new System.Drawing.Point(262, 216);
            this.puntuacionLabel.Name = "puntuacionLabel";
            this.puntuacionLabel.Size = new System.Drawing.Size(61, 13);
            this.puntuacionLabel.TabIndex = 6;
            this.puntuacionLabel.Text = "000000000";
            // 
            // tetrisTC
            // 
            this.tetrisTC.Controls.Add(this.tabPage1);
            this.tetrisTC.Controls.Add(this.tabPage2);
            this.tetrisTC.Location = new System.Drawing.Point(646, 34);
            this.tetrisTC.Name = "tetrisTC";
            this.tetrisTC.SelectedIndex = 0;
            this.tetrisTC.Size = new System.Drawing.Size(384, 532);
            this.tetrisTC.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Black;
            this.tabPage1.Controls.Add(this.tetrisPanel);
            this.tabPage1.Controls.Add(this.btnStart);
            this.tabPage1.Controls.Add(this.puntuacionLabel);
            this.tabPage1.Controls.Add(this.sigPictureBox);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(376, 506);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Tetris!";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(376, 506);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tetrisTimer
            // 
            this.tetrisTimer.Interval = 1000;
            // 
            // tetrisImagenes
            // 
            this.tetrisImagenes.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("tetrisImagenes.ImageStream")));
            this.tetrisImagenes.TransparentColor = System.Drawing.Color.Transparent;
            this.tetrisImagenes.Images.SetKeyName(0, "I.png");
            this.tetrisImagenes.Images.SetKeyName(1, "J.png");
            this.tetrisImagenes.Images.SetKeyName(2, "L.png");
            this.tetrisImagenes.Images.SetKeyName(3, "O.png");
            this.tetrisImagenes.Images.SetKeyName(4, "T.png");
            this.tetrisImagenes.Images.SetKeyName(5, "Z1.png");
            this.tetrisImagenes.Images.SetKeyName(6, "Z2.png");
            // 
            // Tetris
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 681);
            this.Controls.Add(this.tetrisTC);
            this.Name = "Tetris";
            this.Text = "Tetris";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Tetris_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.sigPictureBox)).EndInit();
            this.tetrisTC.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.FlowLayoutPanel tetrisPanel;
        private System.Windows.Forms.PictureBox sigPictureBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label puntuacionLabel;
        private System.Windows.Forms.TabControl tetrisTC;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Timer tetrisTimer;
        private System.Windows.Forms.ImageList tetrisImagenes;
    }
}