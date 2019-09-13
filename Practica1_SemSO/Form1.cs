using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica1_SemSO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label2.Hide();
            label3.Hide();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            cmd cmd = new cmd();
            cmd.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            ExploradorArchivos explorador = new ExploradorArchivos();
            explorador.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SystemInformation.PowerStatus(); // INVESTIGAR METODO PARA CREAR LA BATERIA EN EL SISTEMA 
            pictureBox1.Image = Image.FromFile("C:/Users/Negra/Desktop/Archivos_SO/Windowschido.JPG");
            string propname = this.label4.Text;
            Type t = typeof(System.Windows.Forms.PowerStatus);
            for(int i = 0; i<pictureBox1.Size)

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            this.label1.Text = DateTime.Now.ToLongTimeString();
            //this.label2.Text = DateTime.Now.ToShortTimeString();
            //this.label3.Text = DateTime.Now.ToString("dddd");
        }
    }
}
