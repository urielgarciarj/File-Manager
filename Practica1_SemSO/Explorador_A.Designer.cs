namespace Practica1_SemSO
{
    partial class Explorador_A
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
            this.tvFile = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // tvFile
            // 
            this.tvFile.Location = new System.Drawing.Point(12, 12);
            this.tvFile.Name = "tvFile";
            this.tvFile.Size = new System.Drawing.Size(209, 390);
            this.tvFile.TabIndex = 0;
            // 
            // Explorador_A
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 428);
            this.Controls.Add(this.tvFile);
            this.Name = "Explorador_A";
            this.Text = "Explorador_A";
            this.Load += new System.EventHandler(this.Explorador_A_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvFile;
    }
}