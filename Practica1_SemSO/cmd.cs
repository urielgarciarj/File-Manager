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
using System.Diagnostics;
using System.Threading;

namespace Practica1_SemSO
{
    public partial class cmd : Form
    {
        public cmd()
        {
            InitializeComponent();
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            ExploradorArchivos explorador = new ExploradorArchivos();
            //METODO PARA EL COPY CON: CREAR ARCHIVO
            if (e.KeyData == Keys.Enter){ //Al momento de presionar enter en el textbox se entrara aquí

                //METODO PARA EL COPY CON: CREAR ARCHIVO
                string copyCon1 = this.textBox1.Text;
                string copyCon2 = "COPY CON";
                bool c = copyCon1.Contains(copyCon2); //bool c de crear
                if(c){
                    string nombreArchivo1 = this.textBox1.Text; //Metodo para pasar la cadena al texto a un string 
                    string nombreArchivo2 = nombreArchivo1.Substring(9); //El string nuevo se igualara al que tendra el archivo
                    MessageBox.Show(nombreArchivo2);
                    string rutaCompleta = @"C:\Users\Negra\Desktop\Archivos\" + nombreArchivo2.ToString();//Ruta en la que se guardara el archivo, además de agregarle el nombre
                    using (StreamWriter mylogs = File.AppendText(rutaCompleta)) ; //Creación del archivo en la ruta que se le indico
                    explorador.Show();
                }

                //METODO PARA erase: ELIMINAR ARCHIVOS
                string erase1 = this.textBox1.Text;
                string erase2 = "erase";
                bool flag = erase1.Contains(erase2); //bool flag para saber si la cadena contiene "erase"
                if (flag)
                {
                    string nombreArchivo1 = this.textBox1.Text; //Metodo para pasar la cadena al texto a un string 
                    string nombreArchivo2 = nombreArchivo1.Substring(6); //El string nuevo se igualara al que tendra el nombre del archivo
                    if (System.IO.File.Exists(@"C:\Users\Negra\Desktop\Archivos\" + nombreArchivo2.ToString()));
                    {
                        try
                        {
                            System.IO.File.Delete(@"C:\Users\Negra\Desktop\Archivos\" + nombreArchivo2.ToString());
                        }
                        catch (System.IO.IOException d)
                        {
                            MessageBox.Show(d.Message);
                            return;
                        }
                    }
                }

                //METODO PARA rename: RENOMBRAR ARCHIVOS
                string rename1 = this.textBox1.Text;
                string rename2 = "rename";
                bool bandera = rename1.Contains(rename2);
                if (bandera)
                {
                    //Metodo que sirve para pasar lo que tiene el textBox a un string y poder manipularlo mas facilmente
                    string nombreArchivo1 = this.textBox1.Text; //Metodo para pasar la cadena al texto a un string
                    string nombreArchivo2 = nombreArchivo1.Substring(7); //El string nuevo se igualara al que tendra el nombre del archivo
                    string nombreArchivo4 = nombreArchivo2; //agarrar lo del primer archivo y lo del segundo archivo
                   
                    //Me indica donde esta el primer espacio, para saber cual es el nombre del primer archivo(el que se va a renombrar)
                    string finarchivo1 = nombreArchivo2.IndexOf(" ").ToString();
                    
                    //Agarra el nombre del archivo a renombrar
                    nombreArchivo2 = nombreArchivo1.Substring(7, Convert.ToInt32(finarchivo1));
                   

                    //Agarra el nombre por que el que se va a renombrar al archivo
                    string nombreArchivo3 = nombreArchivo4.Substring(Convert.ToInt32(finarchivo1)+1);
                    

                    if (System.IO.File.Exists(@"C:\Users\Negra\Desktop\Archivos\" + nombreArchivo2.ToString()))
                    {
                        System.IO.File.Delete(@"C:\Users\Negra\Desktop\Archivos\" + nombreArchivo2.ToString());
                        string rutaCompleta = @"C:\Users\Negra\Desktop\Archivos\" + nombreArchivo3.ToString();//Ruta en la que se guardara el archivo, además de agregarle el nombre
                        using (StreamWriter mylogs = File.AppendText(rutaCompleta)) ; //Creación del archivo en la ruta que se le indico
                        MessageBox.Show("Archivo renombrado con exito");
                    }
                    else
                    {
                        MessageBox.Show("No existe el archivo a renombrar");
                    }

                }

                //METODO PARA copy: COPIAR ARCHIVO
                string copy1 = this.textBox1.Text;
                string copy2 = "copy";
                bool copy = copy1.Contains(copy2);

                if (copy)
                {
                    string nombreArchivo1 = this.textBox1.Text; //Metodo para pasar la cadena al texto a un string
                    string nombreArchivo2 = nombreArchivo1.Substring(5); //El string nuevo se igualara al que tendra el nombre del archivo
                    if (System.IO.File.Exists(@"C:\Users\Negra\Desktop\Archivos\" + nombreArchivo2.ToString()))
                    {
                        int n=2;
                        nombreArchivo2 = nombreArchivo2 + "(" + n + ")";
                        string rutaCompleta = @"C:\Users\Negra\Desktop\Archivos\" + nombreArchivo2.ToString();//Ruta en la que se guardara el archivo, además de agregarle el nombre
                        using (StreamWriter mylogs = File.AppendText(rutaCompleta)) ; //Creación del archivo en la ruta que se le indico
                        MessageBox.Show("Archivo copiado con exito");
                        n++;
                    }
                    else
                    {
                        MessageBox.Show("No existe el archivo a copiar");
                    }
                }

            }
        }
    }
}
