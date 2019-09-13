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
using System.Management;

namespace Practica1_SemSO
{
    public partial class ExploradorArchivos : Form
    {
        static Image reinaImg = Image.FromFile("C:/Users/Negra/Desktop/Archivos_SO/txtchido.PNG");

        public ExploradorArchivos()
        {
            InitializeComponent();
        }

        private void ExploradorArchivos_Load(object sender, EventArgs e)
        {
            pictureBox1.Hide();
            pictureBox2.Hide();
            pictureBox3.Hide();
            pictureBox4.Hide();
            pictureBox5.Hide();
            label1.Hide();
            label2.Hide();
            label3.Hide();
            label4.Hide();
            label5.Hide();
            listBox1.Hide();
            listBox2.Hide();
            cargarArchivos();
            textBox1.Hide();
            textBox2.Hide();
            this.textBox3.Text = "C:/Users/Negra/Desktop/Archivos";
            loadFolder(treeView1.Nodes, new DirectoryInfo(@"C:\"));
        }

        private void loadFolder(TreeNodeCollection nodes, DirectoryInfo folder)
        {
            var newNode = nodes.Add(folder.Name);
            bool isHidden = (folder.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden;
            if (isHidden)
            {
                try {
                    foreach (var childFolder in folder.EnumerateDirectories())
                    {
                        loadFolder(newNode.Nodes, childFolder);
                    }
                    foreach (FileInfo file in folder.EnumerateFiles())
                    {
                        newNode.Nodes.Add(file.Name);
                    }
                }
                catch (Exception ex)
                {

                }

            }
        }

        private void ExploradorArchivos_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void ExploradorArchivos_MouseDown(object sender, MouseEventArgs e)
        {
            listBox1.Location = new System.Drawing.Point(Cursor.Position.X, Cursor.Position.Y);
            listBox1.Show();
        }

        private void ListBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //Método para crear un nuevo archivo
            if (listBox1.SelectedItem != null) //Sirve para que a la fuerza se seleccione un elemento si no, no entra
            {
                if(listBox1.SelectedItem.ToString() == "Crear Nuevo archivo")
                {
                    string rutaCompleta = @"C:\Users\Negra\Desktop\Archivos\ .txt";//Ruta en la que se guardara el archivo, además de agregarle el nombre
                    using (StreamWriter mylogs = File.AppendText(rutaCompleta)) ; //Creación del archivo en la ruta que se le indico
                    listBox1.Hide();
                    cargarArchivos();
                }

                if (listBox1.SelectedItem.ToString() == "Actualizar")
                {
                    listBox1.Hide();
                    cargarArchivos();
                }

                if(listBox1.SelectedItem.ToString() == "Crear carpeta")
                {
                    crearCarpetas(label1.Text);
                }
            }
        }

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            listBox2.Location = new System.Drawing.Point(208, 26);
            listBox2.Show();
        }

        private void PictureBox2_MouseDown(object sender, MouseEventArgs e)
        {
            listBox2.Location = new System.Drawing.Point(308, 26);
            listBox2.Show();
        }

        private void PictureBox3_MouseDown(object sender, MouseEventArgs e)
        {
            listBox2.Location = new System.Drawing.Point(408, 26);
            listBox2.Show();
        }

        private void PictureBox4_MouseDown(object sender, MouseEventArgs e)
        {
            listBox2.Location = new System.Drawing.Point(508, 26);
            listBox2.Show();
        }

        private void PictureBox5_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            listBox2.Location = new System.Drawing.Point(608, 26);
            listBox2.Show();
        }

        private void ListBox2_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //RENOMBRAR ARCHIVOS
            if (listBox2.SelectedItem !=null)
            {
                if (listBox2.SelectedItem.ToString() == "Renombrar")
                {
                    if (listBox2.Location.X.Equals(208))
                    {
                        textBox1.Location = new System.Drawing.Point(179, 125);
                        textBox1.Show();
                        listBox2.Hide();
                    }
                    else if (listBox2.Location.X.Equals(308))
                    {
                        textBox2.Show();
                        listBox2.Hide();
                    }
                    else if (listBox2.Location.X.Equals(408))
                    {
                        textBox1.Location = new System.Drawing.Point(411, 125);
                        textBox1.Show();
                        listBox2.Hide();
                    }
                    else if (listBox2.Location.X.Equals(508))
                    {
                        textBox1.Location = new System.Drawing.Point(511, 125);
                        textBox2.Show();
                        listBox2.Hide();
                    }
                    else if (listBox2.Location.X.Equals(608))
                    {
                        textBox1.Location = new System.Drawing.Point(611, 125);
                        textBox2.Show();
                        listBox2.Hide();
                    }
                }
            }

            //ELIMINAR ARCHIVOS
            if (listBox2.SelectedItem.ToString() == "Eliminar")
            {
                if (listBox2.Location.X.Equals(208))
                {
                    eliminarArchivos(label1.Text);
                }
                else if (listBox2.Location.X.Equals(308))
                {
                    eliminarArchivos(label2.Text);
                }
                else if (listBox2.Location.X.Equals(408))
                {
                    eliminarArchivos(label3.Text);
                }
                else if (listBox2.Location.X.Equals(508))
                {
                    eliminarArchivos(label4.Text);
                }
                else if (listBox2.Location.X.Equals(608))
                {
                    eliminarArchivos(label5.Text);
                }
                cargarArchivos();
            }

            if (listBox2.SelectedItem.ToString() == "Copiar")
            {
                if (listBox2.Location.X.Equals(208))
                {
                    copiarArchivos(label1.Text);
                }
                else if (listBox2.Location.X.Equals(308))
                {
                    copiarArchivos(label2.Text);
                }
                else if (listBox2.Location.X.Equals(408))
                {
                    copiarArchivos(label3.Text);
                }
                else if (listBox2.Location.X.Equals(508))
                {
                    copiarArchivos(label4.Text);
                }
                else if (listBox2.Location.X.Equals(608))
                {
                    copiarArchivos(label5.Text);
                }
            }
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
           
            if (e.KeyData == Keys.Enter)
            {   
                if (textBox1.Location.X.Equals(179))
                {
                    listBox2.Hide();
                    renombrarArchivos(label1.Text, this.textBox1.Text);
                }
                else if(textBox1.Location.X.Equals(411))
                {
                    listBox2.Hide();
                    renombrarArchivos(label3.Text, this.textBox1.Text);
                }
                else if (textBox1.Location.X.Equals(411))
                {
                    listBox2.Hide();
                    renombrarArchivos(label4.Text, this.textBox1.Text);
                }
                else if (textBox1.Location.X.Equals(411))
                {
                    listBox2.Hide();
                    renombrarArchivos(label5.Text, this.textBox1.Text);
                }
                cargarArchivos();
            }
        }

        public void cargarArchivos()
        {
            DirectoryInfo di = new DirectoryInfo(@"C:\Users\Negra\Desktop\Archivos");
            DirectoryInfo ci = new DirectoryInfo(@"C:\Users\Negra\Desktop\Archivos");
            int i = 0;
            //Metodo para seleccionar todos los archivos que contenga la carpeta que le especifique
            foreach (DirectoryInfo subdir in ci.GetDirectories())
            {
                if (i == 0)
                {
                    pictureBox1.Show();
                    pictureBox1.Image = reinaImg;
                    label1.Show();
                    label1.Text = ci.Name;
                }
                if (i == 1)
                {
                    pictureBox2.Show();
                    pictureBox2.Image = reinaImg;
                    label2.Text = ci.Name;
                    label2.Show();
                }
                if (i == 2)
                {
                    pictureBox3.Show();
                    pictureBox3.Image = reinaImg;
                    label3.Text = ci.Name;
                    label3.Show();
                }
                if (i == 3)
                {
                    pictureBox4.Show();
                    pictureBox4.Image = reinaImg;
                    label4.Text = ci.Name;
                    label4.Show();
                }
                if (i == 4)
                {
                    pictureBox5.Show();
                    pictureBox5.Image = reinaImg;
                    label5.Text = ci.Name;
                    label5.Show();
                }
                i++;
            }
            foreach (var fi in di.GetFiles())
            {
                if (i == 0)
                {
                    pictureBox1.Show();
                    pictureBox1.Image = reinaImg;
                    label1.Show();
                    label1.Text = fi.Name;
                }
                if (i == 1)
                {
                    pictureBox2.Show();
                    pictureBox2.Image = reinaImg;
                    label2.Text = fi.Name;
                    label2.Show();
                }
                if (i == 2)
                {
                    pictureBox3.Show();
                    pictureBox3.Image = reinaImg;
                    label3.Text = fi.Name;
                    label3.Show();
                }
                if (i == 3)
                {
                    pictureBox4.Show();
                    pictureBox4.Image = reinaImg;
                    label4.Text = fi.Name;
                    label4.Show();
                }
                if (i == 4)
                {
                    pictureBox5.Show();
                    pictureBox5.Image = reinaImg;
                    label5.Text = fi.Name;
                    label5.Show();
                }
                i++;
            }
        }

        public string renombrarArchivos(string label, string nombreArchivo)
        {
            string nombreLabel = label;
            string nuevoNombreArchivo = nombreArchivo;
            System.IO.File.Delete(@"C:\Users\Negra\Desktop\Archivos\" + nombreLabel);
            string rutaCompleta = @"C:\Users\Negra\Desktop\Archivos\" + nuevoNombreArchivo.ToString();//Ruta en la que se guardara el archivo, además de agregarle el nombre
            using (StreamWriter mylogs = File.AppendText(rutaCompleta)) ; //Creación del archivo en la ruta que se le indico
            textBox1.Hide();
            cargarArchivos();
            return nombreArchivo;
        }

        public string eliminarArchivos(string label)
        {
            string archivoEliminar = label; //Metodo para pasar la cadena al texto a un string 
            if (System.IO.File.Exists(@"C:\Users\Negra\Desktop\Archivos\" + archivoEliminar)) ;
            {
                try
                {
                    System.IO.File.Delete(@"C:\Users\Negra\Desktop\Archivos\" + archivoEliminar);
                }
                catch (System.IO.IOException d)
                {
                    MessageBox.Show(d.Message);
                }
            }
            listBox2.Hide();
            ExploradorArchivos explorador = new ExploradorArchivos();
            explorador.Show();
            return label;
        }

        public string copiarArchivos(string label)
        {
            string archivoCopiar = label; //Metodo para pasar la cadena al texto a un string
            if (System.IO.File.Exists(@"C:\Users\Negra\Desktop\Archivos\" + archivoCopiar))
            {
                int n = 2;
                archivoCopiar = archivoCopiar + "(" + n + ")";
                string rutaCompleta = @"C:\Users\Negra\Desktop\Archivos\" + archivoCopiar;//Ruta en la que se guardara el archivo, además de agregarle el nombre
                using (StreamWriter mylogs = File.AppendText(rutaCompleta)) ; //Creación del archivo en la ruta que se le indico
                MessageBox.Show("Archivo copiado con exito");
                n++;
            }
            listBox2.Hide();
            cargarArchivos();
            return label;
        }

        public string crearCarpetas(string label)
        {
            string crearCarpeta = label;
            string path = @"C:\Users\Negra\Desktop\Archivos\";
            DirectoryInfo di = Directory.CreateDirectory(path);
            return label;
        }

        private void TextBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                string nuevoNombreArchivo = this.textBox2.Text;
                System.IO.File.Delete(@"C:\Users\Negra\Desktop\Archivos\" + label2.Text);
                string rutaCompleta = @"C:\Users\Negra\Desktop\Archivos\" + nuevoNombreArchivo.ToString();//Ruta en la que se guardara el archivo, además de agregarle el nombre
                using (StreamWriter mylogs = File.AppendText(rutaCompleta)) ; //Creación del archivo en la ruta que se le indico
                textBox2.Hide();
                cargarArchivos();
            }
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void PictureBox1_DoubleClick(object sender, EventArgs e)
        {
            this.textBox3.Text = "C:/Users/Negra/Desktop/Archivos/" + label1.Text;
            listBox1.Hide();
            DirectoryInfo di = new DirectoryInfo(@"C:\Users\Negra\Desktop\Archivos\" + label1.Text);
            int i = 0;
            //Metodo para seleccionar todos los archivos que contenga la carpeta que le especifique
            foreach (var fi in di.GetFiles())
            {
                if (i == 0)
                {
                    pictureBox1.Show();
                    pictureBox1.Image = reinaImg;
                    label1.Show();
                    label1.Text = fi.Name;
                }
                if (i == 1)
                {
                    pictureBox2.Show();
                    pictureBox2.Image = reinaImg;
                    label2.Text = fi.Name;
                    label2.Show();
                }
                if (i == 2)
                {
                    pictureBox3.Show();
                    pictureBox3.Image = reinaImg;
                    label3.Text = fi.Name;
                    label3.Show();
                }
                if (i == 3)
                {
                    pictureBox4.Show();
                    pictureBox4.Image = reinaImg;
                    label4.Text = fi.Name;
                    label4.Show();
                }
                if (i == 4)
                {
                    pictureBox5.Show();
                    pictureBox5.Image = reinaImg;
                    label5.Text = fi.Name;
                    label5.Show();
                }
                i++;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (this.textBox3.Text == "C:/Users/Negra/Desktop/Archivos/" + label1.Text)
            {
                this.textBox3.Text = "C:/Users/Negra/Desktop/Archivos/";
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (this.textBox3.Text == "C:/Users/Negra/Desktop/Archivos/")
            {
                this.textBox3.Text = "C:/Users/Negra/Desktop/Archivos/" + label1.Text;
            }
        }

        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
        }

        private void TreeView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo(@"C:\Users\Negra\Desktop\Archivos_SO");
            int i = 0;
            if (treeView1.SelectedNode != null) //Sirve para que a la fuerza se seleccione un elemento si no, no entra
            {
                if (treeView1.SelectedNode.Text == "Archivos_SO")
                {
                    this.textBox3.Text = "C:/Users/Negra/Desktop/Archivos_SO";
                    foreach (var fi in di.GetFiles())
                    {
                        if (i == 0)
                        {
                            pictureBox1.Show();
                            pictureBox1.Image = reinaImg;
                            label1.Show();
                            label1.Text = fi.Name;
                        }
                        if (i == 1)
                        {
                            pictureBox2.Show();
                            pictureBox2.Image = reinaImg;
                            label2.Text = fi.Name;
                            label2.Show();
                        }
                        if (i == 2)
                        {
                            pictureBox3.Show();
                            pictureBox3.Image = reinaImg;
                            label3.Text = fi.Name;
                            label3.Show();
                        }
                        if (i == 3)
                        {
                            pictureBox4.Show();
                            pictureBox4.Image = reinaImg;
                            label4.Text = fi.Name;
                            label4.Show();
                        }
                        if (i == 4)
                        {
                            pictureBox5.Show();
                            pictureBox5.Image = reinaImg;
                            label5.Text = fi.Name;
                            label5.Show();
                        }
                        i++;
                    }
                }

                if (treeView1.SelectedNode.Text == "Descargas")
                {
                    DirectoryInfo ci = new DirectoryInfo(@"C:\Users\Negra\Downloads");
                    this.textBox3.Text = "C:/Users/Negra/Downloads";
                    foreach (var fi in ci.GetFiles())
                    {
                        if (i == 0)
                        {
                            pictureBox1.Show();
                            pictureBox1.Image = reinaImg;
                            label1.Show();
                            label1.Text = fi.Name;
                        }
                        if (i == 1)
                        {
                            pictureBox2.Show();
                            pictureBox2.Image = reinaImg;
                            label2.Text = fi.Name;
                            label2.Show();
                        }
                        if (i == 2)
                        {
                            pictureBox3.Show();
                            pictureBox3.Image = reinaImg;
                            label3.Text = fi.Name;
                            label3.Show();
                        }
                        if (i == 3)
                        {
                            pictureBox4.Show();
                            pictureBox4.Image = reinaImg;
                            label4.Text = fi.Name;
                            label4.Show();
                        }
                        if (i == 4)
                        {
                            pictureBox5.Show();
                            pictureBox5.Image = reinaImg;
                            label5.Text = fi.Name;
                            label5.Show();
                        }
                        i++;
                    }
                }

                if (treeView1.SelectedNode.Text == "Archivos")
                {
                    DirectoryInfo ci = new DirectoryInfo(@"C:\Users\Negra\Desktop\Archivos");
                    this.textBox3.Text = "C:/Users/Negra/Desktop/Archivos";
                    foreach (var fi in ci.GetFiles())
                    {
                        if (i == 0)
                        {
                            pictureBox1.Show();
                            pictureBox1.Image = reinaImg;
                            label1.Show();
                            label1.Text = fi.Name;
                        }
                        if (i == 1)
                        {
                            pictureBox2.Show();
                            pictureBox2.Image = reinaImg;
                            label2.Text = fi.Name;
                            label2.Show();
                        }
                        if (i == 2)
                        {
                            pictureBox3.Show();
                            pictureBox3.Image = reinaImg;
                            label3.Text = fi.Name;
                            label3.Show();
                        }
                        if (i == 3)
                        {
                            pictureBox4.Show();
                            pictureBox4.Image = reinaImg;
                            label4.Text = fi.Name;
                            label4.Show();
                        }
                        if (i == 4)
                        {
                            pictureBox5.Show();
                            pictureBox5.Image = reinaImg;
                            label5.Text = fi.Name;
                            label5.Show();
                        }
                        i++;
                    }
                }

            }
        }
    }
}
