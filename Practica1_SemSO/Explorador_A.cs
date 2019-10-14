using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Practica1_SemSO
{
    public partial class Explorador_A : Form
    {
        public Explorador_A()
        {
            InitializeComponent();
        }

        private TreeNode crearArbol(DirectoryInfo directoryInfo)
        {
            
            TreeNode treeNode = new TreeNode(directoryInfo.Name);
            try
            {
                foreach (var item in directoryInfo.GetDirectories())
                {
                    treeNode.Nodes.Add(crearArbol(item));
                }

                foreach (var item in directoryInfo.GetFiles())
                {
                    treeNode.Nodes.Add(new TreeNode(item.Name));
                }
            }
            catch(Exception ex)
            {

            }
              
            return treeNode;
        }

        private void Explorador_A_Load(object sender, EventArgs e)
        {
            string rutaBase = "D:";
            
            tvFile.Nodes.Clear();

            DirectoryInfo directoryInfo = new DirectoryInfo(rutaBase);

            tvFile.Nodes.Add(crearArbol(directoryInfo));
        }

        private void tvFile_DoubleClick(object sender, EventArgs e)
        {
            listView1.Clear();
            string ruta = tvFile.SelectedNode.FullPath;
            textBox1.Text = ruta;
            MessageBox.Show(ruta);
            
            DirectoryInfo di = new DirectoryInfo(ruta);
            foreach (var item in di.GetFiles())
            {
                listView1.Items.Add(item.Name);
            }
            foreach (var item in di.GetDirectories())
            {
                listView1.Items.Add(item.Name);
            }
            
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Descargas dc = new Descargas();
            string ruta = this.tvFile.SelectedNode.FullPath;
            string nombre = ruta + "/" + txtNombreArchivo;
            string url = dc.txtURL.Text;
            MessageBox.Show(url);
            dc.descarga(url, nombre);
        }
    }
}
