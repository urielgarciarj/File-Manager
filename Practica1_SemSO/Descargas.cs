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

namespace Practica1_SemSO
{
    public partial class Descargas : Form
    {
        public Descargas()
        {
            InitializeComponent();
        }

        private void btnDescargar_Click(object sender, EventArgs e)
        {
            //Sincrona
            WebClient wc = new WebClient();
            wc.DownloadFile(txtURL.Text, "BRODYQUEST2.mp3");
            MessageBox.Show("Descarga Completada!");
        }

        private void btnExplorador_Click(object sender, EventArgs e)
        {
            Explorador_A explorador = new Explorador_A();
            explorador.Show();
        }
    }
}

//Link de descargahttps://drive.google.com/uc?export=download&id=1aWwzeN36BxrPrEOsy1i_XDWbtqVIgmjs