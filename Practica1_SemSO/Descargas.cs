using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;//Libreria para internet 
using System.IO;

namespace Practica1_SemSO
{
    public partial class Descargas : Form
    {
        public Descargas()
        {
            InitializeComponent();
        }

        Explorador_A explorador = new Explorador_A();

        public static class Global
        {
            public static string URL; 
        }
            

        private void btnDescargar_Click(object sender, EventArgs e)
        {
            //ASincrona
            WebClient wc = new WebClient();
            MessageBox.Show(txtURL.Text);
            Global.URL = txtURL.Text;
            Explorador_A explorador = new Explorador_A();
            explorador.Show();
        }

        public void descarga(string url, string directorio)
        {
            WebClient wc = new WebClient();
            wc.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
            wc.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChanged);
            wc.DownloadFileAsync(new Uri(url), @"" + directorio);
        }


        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("Descarga Finalizada!");
        }

        private void btnExplorador_Click(object sender, EventArgs e)
        {
            Explorador_A explorador = new Explorador_A();
            explorador.Show();
        }
    }
}

//Link de descarga https://drive.google.com/uc?export=download&id=1aWwzeN36BxrPrEOsy1i_XDWbtqVIgmjs
//https://drive.google.com/uc?export=download&id=1aWwzeN36BxrPrEOsy1i_XDWbtqVIgmjs