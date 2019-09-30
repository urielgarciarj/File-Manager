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
using System.IO;

namespace Practica1_SemSO
{
    public partial class Musica : Form
    {
        public Musica()
        {
            InitializeComponent();
            plantilla();
        }

        private void plantilla()
        {
            DirectoryInfo ci = new DirectoryInfo(@"C:\Users\Uriel\Music");
            listView1.Items.Clear();
            foreach (var elem in ci.GetFiles())
            {
                listView1.Items.Add(Path.GetFileNameWithoutExtension(elem.Name));
            }
        }

        private void ListView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem listItem = listView1.SelectedItems[0];


                if(listItem.Text == "All Star - Smash Mouth [Lyrics]")
                {
                    ReproductorMusica reproductor = new ReproductorMusica();
                    reproductor.Show();
                    string path = @"/All Star - Smash Mouth.mp3";
                    reproductor.reproducir(path);
                }

                if (listItem.Text == "BRODYQUEST")
                {
                    ReproductorMusica reproductor = new ReproductorMusica();
                    reproductor.Show();
                    string path = @"/BRODYQUEST.mp3";
                    reproductor.reproducir(path);
                }

            }
        }
    }
}
