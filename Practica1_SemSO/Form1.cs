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
        static Image pila100 = Image.FromFile("C:/Users/Uriel/Pictures/Pila100chido.PNG");
        static Image pila75 = Image.FromFile("C:/Users/Uriel/Pictures/Pila75chido.PNG");
        static Image pila50 = Image.FromFile("C:/Users/Uriel/Pictures/Pila50chido.PNG");
        static Image pila25 = Image.FromFile("C:/Users/Uriel/Pictures/Pila25chido.PNG");

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
           pictureBox1.Image = Image.FromFile("C:/Users/Uriel/Pictures/Windowschido.JPG");
           pictureBox2.Image = pila100;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            this.label1.Text = DateTime.Now.ToLongTimeString();
            //this.label2.Text = DateTime.Now.ToShortTimeString();
            //this.label3.Text = DateTime.Now.ToString("dddd");

            PowerStatus pwr = SystemInformation.PowerStatus;
            this.label4.Text = pwr.BatteryLifePercent.ToString();
            this.label5.Text = string.Format("{0} hr {1} min remaining",
                pwr.BatteryLifeRemaining / 3600, (pwr.BatteryLifeRemaining % 3600) / 60);
            if(pwr.BatteryLifePercent <= 89)
            {
                pictureBox2.Image = pila50;
            }
        }

        private void BtnReproductor_Click(object sender, EventArgs e)
        {
            Musica reproductor = new Musica();
            reproductor.Show();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {

        }
    }
}
