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
    public partial class Musica : Form
    {
        WindowsMediaPlayer sonido;
        public Musica()
        {
            InitializeComponent();
            try
            {
                if(sonido == null)
                {
                    sonido = new WindowsMediaPlayer();
                    sonido.URL = Application.StartupPath + @"/All Star - Smash Mouth.mp3";
                    sonido.controls.play();
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }
    }
}
