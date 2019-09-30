using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace Practica1_SemSO
{
    public partial class ReproductorMusica : Form
    {
        WindowsMediaPlayer sonido;
        public ReproductorMusica()
        {
            InitializeComponent();
        }

        public static class GlobalPath
        {
            public static string path = "";
        }

        public void reproducir(string path)
        {
            try
            {
                if (sonido == null)
                {
                    sonido = new WindowsMediaPlayer();
                    sonido.URL = Application.StartupPath + path;
                    GlobalPath.path = path;
                    sonido.controls.play();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (sonido!=null){
                sonido.controls.pause();
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if(sonido != null)
            {
                double tiempo = sonido.controls.currentPosition;
                sonido.controls.currentPosition = tiempo;
                sonido.controls.play();
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (sonido != null)
            {
                sonido.controls.stop();
                sonido = null;
                reproducir(GlobalPath.path);
            }
        }

        private void ReproductorMusica_FormClosing(object sender, FormClosingEventArgs e)
        {
            sonido.controls.stop();
        }
    }
}
