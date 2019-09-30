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
        WindowsMediaPlayer sonido;
        public Musica()
        {
            InitializeComponent();
            plantilla();
            /*try
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
            }*/
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

                MessageBox.Show(listItem.Text);

                if(listItem.Text == "All Star - Smash Mouth [Lyrics]")
                {
                    MessageBox.Show("Hola");
                }
                //MessageBox.Show(items.SubItems[1].Text);


            }
        }
    }
}
