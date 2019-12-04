﻿
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Practica1_SemSO
{
    public partial class Tetris : Form
    {
        static Image blockImage;
        string copied;
        string name;
        
       
        bool paused;
        string fileRoute;
        List<PictureBox> casillas;
        int current, siguiente;
        int fig;
        int state;
        int acumm;
        enum figuras { I, J, L, O, Z1, Z2, T };
        bool jugando, perdiste;
        int[] pos;
        Thread crearFigura;
        int[] colD = { 9, 19, 29, 39, 49, 59, 69, 79, 89, 99, 109, 119, 129, 139, 149, 159, 169, 179, 189, 199 };
        int[] colI = { 0, 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 110, 120, 130, 140, 150, 160, 170, 180, 190 };
        int[] filaSup = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        int[] filaInf = { 190, 191, 192, 193, 194, 195, 196, 197, 198, 199 };
        Color colorActual;
        int _puntuacion;
        int puntuacion { get { return _puntuacion; } set { _puntuacion = value; puntuacionLabel.Text = value.ToString(); } }
        public Tetris()
        {
            InitializeComponent();
            copied = "$";
            paused = false;
            //wplayer.URL = "C:\\test\\sound.mp3";
            populateTetrisPanel();
            jugando = false;
            perdiste = false;
            this.KeyPreview = true;
            puntuacion = 0;
            acumm = 0;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (perdiste)
            {
                foreach (Control c in tetrisPanel.Controls)
                    c.BackColor = Color.Black;
                puntuacion = 0;
                perdiste = false;
            }
            jugando = true;
            acumm = 0;
            //Random rnd = new Random();
            //fig = rnd.Next(0, 6);
            fig = 3;
            siguiente = fig;
            jugando = true;
            sueltaFigura();
        }

        private void populateTetrisPanel()
        {
            casillas = new List<PictureBox>();
            for (int i = 0; i < 200; i++)
            {
                PictureBox pb = new PictureBox();
                pb.Size = new Size(23, 23);
                pb.BackColor = Color.Black;
                pb.Margin = new Padding(1, 1, 1, 1);
                tetrisPanel.Controls.Add(pb);
            }
        }

        private void dropFigure()
        {
            if (jugando)
            {
                int i = 1, d = 9;
                List<int> casillas = new List<int>();
                List<int> lineas = new List<int>();
                while (true)
                {
                    for (int j = i; j <= d; j++)
                    {
                        if (tetrisPanel.Controls[j].BackColor != Color.Black)
                        {
                            casillas.Add(1);
                        }
                    }
                    if (casillas.Count == 10)
                    {
                        lineas.Add(i);
                        lineas.Add(d);
                    }
                    i += 10;
                    d += 10;
                    if (i == 200)
                        break;
                    casillas.Clear();
                }
                if (lineas.Count != 0)
                {
                    while (lineas.Count != 0)
                    {
                        i = lineas[0];
                        lineas.RemoveAt(0);
                        d = lineas[0];
                        lineas.RemoveAt(0);
                        for (int inicio = d; inicio >= 10; inicio--)
                            tetrisPanel.Controls[inicio].BackColor = tetrisPanel.Controls[inicio - 10].BackColor;
                        for (int inicio = 0; inicio <= 9; inicio++)
                            tetrisPanel.Controls[inicio].BackColor = Color.Black;
                        puntuacion += 100;
                        acumm += 100;
                        if (acumm == 500)
                        {
                            tetrisTimer.Interval = tetrisTimer.Interval / 2;
                            acumm = 0;
                        }
                    }
                }

                fig = siguiente;
                switch (fig)
                {
                    case (int)figuras.I:
                        current = (int)figuras.I;
                        if (canBePlaced())
                        {
                            state = 0;
                            dropI();
                        }
                        else
                        {
                            puntuacionLabel.Text = "PERDISTE";
                            perdiste = true;
                            jugando = false;
                        }
                        break;
                    case (int)figuras.J:
                        current = (int)figuras.J;
                        if (canBePlaced())
                        {
                            state = 0;
                            dropJ();
                        }
                        else
                        {
                            puntuacionLabel.Text = "PERDISTE";
                            perdiste = true;
                            jugando = false;
                        }
                        break;
                    case (int)figuras.L:
                        current = (int)figuras.L;
                        if (canBePlaced())
                        {
                            state = 0;
                            dropL();
                        }
                        else
                        {
                            puntuacionLabel.Text = "PERDISTE";
                            perdiste = true;
                            jugando = false;
                        }
                        break;
                    case (int)figuras.O:
                        current = (int)figuras.O;
                        if (canBePlaced())
                        {
                            state = 0;
                            dropO();
                        }
                        else
                        {
                            puntuacionLabel.Text = "PERDISTE";
                            perdiste = true;
                            jugando = false;
                        }
                        break;
                    case (int)figuras.T:
                        current = (int)figuras.T;
                        if (canBePlaced())
                        {
                            state = 0;
                            dropT();
                        }
                        else
                        {
                            puntuacionLabel.Text = "PERDISTE";
                            perdiste = true;
                            jugando = false;
                        }
                        break;
                    case (int)figuras.Z1:
                        current = (int)figuras.Z1;
                        if (canBePlaced())
                        {
                            state = 0;
                            dropZ1();
                        }
                        else
                        {
                            puntuacionLabel.Text = "PERDISTE";
                            perdiste = true;
                            jugando = false;
                        }
                        break;
                    case (int)figuras.Z2:
                        current = (int)figuras.Z2;
                        if (canBePlaced())
                        {
                            state = 0;
                            dropZ2();
                        }
                        else
                        {
                            puntuacionLabel.Text = "PERDISTE";
                            perdiste = true;
                            jugando = false;
                        }
                        break;
                }
                //Random rnd = new Random();
                //siguiente = rnd.Next(0, 6);
                siguiente = 3;
                sigPictureBox.BackgroundImage = tetrisImagenes.Images[siguiente];
            }
        }

        private bool canBePlaced()
        {
            switch (current)
            {
                case (int)figuras.I:
                    if (tetrisPanel.Controls[4].BackColor == Color.Black && tetrisPanel.Controls[14].BackColor == Color.Black
                        && tetrisPanel.Controls[24].BackColor == Color.Black && tetrisPanel.Controls[34].BackColor == Color.Black)
                        return true;
                    return false;
                case (int)figuras.J:
                    if (tetrisPanel.Controls[4].BackColor == Color.Black && tetrisPanel.Controls[14].BackColor == Color.Black
                        && tetrisPanel.Controls[24].BackColor == Color.Black && tetrisPanel.Controls[23].BackColor == Color.Black)
                        return true;
                    return false;
                case (int)figuras.L:
                    if (tetrisPanel.Controls[4].BackColor == Color.Black && tetrisPanel.Controls[14].BackColor == Color.Black
                        && tetrisPanel.Controls[24].BackColor == Color.Black && tetrisPanel.Controls[25].BackColor == Color.Black)
                        return true;
                    return false;
                case (int)figuras.O:
                    if (tetrisPanel.Controls[4].BackColor == Color.Black && tetrisPanel.Controls[5].BackColor == Color.Black
                        && tetrisPanel.Controls[14].BackColor == Color.Black && tetrisPanel.Controls[15].BackColor == Color.Black)
                        return true;
                    return false;
                case (int)figuras.T:
                    if (tetrisPanel.Controls[4].BackColor == Color.Black && tetrisPanel.Controls[5].BackColor == Color.Black
                        && tetrisPanel.Controls[6].BackColor == Color.Black && tetrisPanel.Controls[15].BackColor == Color.Black)
                        return true;
                    return false;
                case (int)figuras.Z1:
                    if (tetrisPanel.Controls[4].BackColor == Color.Black && tetrisPanel.Controls[3].BackColor == Color.Black
                        && tetrisPanel.Controls[14].BackColor == Color.Black && tetrisPanel.Controls[15].BackColor == Color.Black)
                        return true;
                    return false;
                case (int)figuras.Z2:
                    if (tetrisPanel.Controls[4].BackColor == Color.Black && tetrisPanel.Controls[5].BackColor == Color.Black
                        && tetrisPanel.Controls[14].BackColor == Color.Black && tetrisPanel.Controls[13].BackColor == Color.Black)
                        return true;
                    return false;
            }
            return false;
        }

        #region Drop Figuras
        private void dropI()
        {
            pos[0] = 4;
            pos[1] = 14;
            pos[2] = 24;
            pos[3] = 34;
            colorActual = Color.Aqua;
            for (int i = 0; i < 4; i++)
            {
                tetrisPanel.Controls[pos[i]].BackColor = colorActual;
            }
        }
        private void dropJ()
        {
            pos[0] = 4;
            pos[1] = 14;
            pos[2] = 24;
            pos[3] = 23;
            colorActual = Color.Blue;
            for (int i = 0; i < 4; i++)
            {
                tetrisPanel.Controls[pos[i]].BackColor = colorActual;
            }
        }
        private void dropL()
        {
            pos[0] = 4;
            pos[1] = 14;
            pos[2] = 24;
            pos[3] = 25;
            colorActual = Color.Orange;
            tetrisPanel.Controls[pos[0]].BackColor = colorActual;
            tetrisPanel.Controls[pos[1]].BackColor = colorActual;
            tetrisPanel.Controls[pos[2]].BackColor = colorActual;
            tetrisPanel.Controls[pos[3]].BackColor = colorActual;
        }
        private void dropO()
        {
            pos[0] = 4;
            pos[1] = 5;
            pos[2] = 14;
            pos[3] = 15;
            colorActual = Color.Yellow;
            for (int i = 0; i < 4; i++)
            {
                tetrisPanel.Controls[pos[i]].BackColor = colorActual;
            }
        }
        private void dropT()
        {
            pos[1] = 4;
            pos[0] = 5;
            pos[2] = 6;
            pos[3] = 15;
            colorActual = Color.Purple;
            for (int i = 0; i < 4; i++)
            {
                tetrisPanel.Controls[pos[i]].BackColor = colorActual;
            }
        }
        private void dropZ1()
        {
            pos[0] = 4;
            pos[1] = 3;
            pos[2] = 14;
            pos[3] = 15;
            colorActual = Color.Red;
            for (int i = 0; i < 4; i++)
            {
                tetrisPanel.Controls[pos[i]].BackColor = colorActual;
            }
        }
        private void dropZ2()
        {
            pos[0] = 4;
            pos[1] = 5;
            pos[2] = 14;
            pos[3] = 13;
            colorActual = Color.Green;
            for (int i = 0; i < 4; i++)
            {
                tetrisPanel.Controls[pos[i]].BackColor = colorActual;
            }
        }
        #endregion

        private void playTetris_Click(object sender, EventArgs e)
        {
            if (perdiste)
            {
                foreach (Control c in tetrisPanel.Controls)
                    c.BackColor = Color.Black;
                puntuacion = 0;
                perdiste = false;
            }
            jugando = true;
            acumm = 0;
            //Random rnd = new Random();
            //fig = rnd.Next(0, 6);
            fig = 3;
            siguiente = fig;
            jugando = true;
            sueltaFigura();
        }

        private void sueltaFigura()
        {
            if (jugando)
            {
                crearFigura = new Thread(dropFigure);
                jugando = true;
                pos = new int[4];
                tetrisTimer.Enabled = true;
                crearFigura.Start();
            }
        }

        #region Girar figura I
        //--->
        private void arrowDerI()
        {
            tetrisPanel.Controls[pos[0]].BackColor = Color.Black;
            tetrisPanel.Controls[pos[1]].BackColor = Color.Black;
            tetrisPanel.Controls[pos[2]].BackColor = Color.Black;
            tetrisPanel.Controls[pos[3]].BackColor = Color.Black;
            pos[1] = pos[0] + 1;
            pos[2] = pos[0] + 2;
            pos[3] = pos[0] + 3;
            tetrisPanel.Controls[pos[0]].BackColor = colorActual;
            tetrisPanel.Controls[pos[1]].BackColor = colorActual;
            tetrisPanel.Controls[pos[2]].BackColor = colorActual;
            tetrisPanel.Controls[pos[3]].BackColor = colorActual;
        }
        //Abajo
        private void arrowDownI()
        {
            tetrisPanel.Controls[pos[0]].BackColor = Color.Black;
            tetrisPanel.Controls[pos[1]].BackColor = Color.Black;
            tetrisPanel.Controls[pos[2]].BackColor = Color.Black;
            tetrisPanel.Controls[pos[3]].BackColor = Color.Black;
            pos[1] = pos[0] + 10;
            pos[2] = pos[0] + 20;
            pos[3] = pos[0] + 30;
            tetrisPanel.Controls[pos[0]].BackColor = colorActual;
            tetrisPanel.Controls[pos[1]].BackColor = colorActual;
            tetrisPanel.Controls[pos[2]].BackColor = colorActual;
            tetrisPanel.Controls[pos[3]].BackColor = colorActual;
        }
        //<-----
        private void arrowIzqI()
        {
            tetrisPanel.Controls[pos[0]].BackColor = Color.Black;
            tetrisPanel.Controls[pos[1]].BackColor = Color.Black;
            tetrisPanel.Controls[pos[2]].BackColor = Color.Black;
            tetrisPanel.Controls[pos[3]].BackColor = Color.Black;
            pos[1] = pos[0] + 1;
            pos[2] = pos[0] + 2;
            pos[3] = pos[0] + 3;
            tetrisPanel.Controls[pos[0]].BackColor = colorActual;
            tetrisPanel.Controls[pos[1]].BackColor = colorActual;
            tetrisPanel.Controls[pos[2]].BackColor = colorActual;
            tetrisPanel.Controls[pos[3]].BackColor = colorActual;
        }
        private void arrowUpI()
        {
            tetrisPanel.Controls[pos[0]].BackColor = Color.Black;
            tetrisPanel.Controls[pos[1]].BackColor = Color.Black;
            tetrisPanel.Controls[pos[2]].BackColor = Color.Black;
            tetrisPanel.Controls[pos[3]].BackColor = Color.Black;
            pos[1] = pos[0] + 1;
            pos[2] = pos[0] + 2;
            pos[3] = pos[0] + 3;
            tetrisPanel.Controls[pos[0]].BackColor = colorActual;
            tetrisPanel.Controls[pos[1]].BackColor = colorActual;
            tetrisPanel.Controls[pos[2]].BackColor = colorActual;
            tetrisPanel.Controls[pos[3]].BackColor = colorActual;
        }
        #endregion

        #region Girar figura J
        //--->
        private void arrowDerJ()
        {
            //if (contains(colI, pos[3]))
            tetrisPanel.Controls[pos[0]].BackColor = Color.Black;
            pos[0] = pos[0] - 10;
            tetrisPanel.Controls[pos[0]].BackColor = colorActual;

            tetrisPanel.Controls[pos[0]].BackColor = Color.Black;
            tetrisPanel.Controls[pos[1]].BackColor = Color.Black;
            tetrisPanel.Controls[pos[2]].BackColor = Color.Black;
            tetrisPanel.Controls[pos[3]].BackColor = Color.Black;
            pos[1] = pos[0] - 1;
            pos[2] = pos[0] - 2;
            pos[3] = pos[0] - 12;
            tetrisPanel.Controls[pos[0]].BackColor = colorActual;
            tetrisPanel.Controls[pos[1]].BackColor = colorActual;
            tetrisPanel.Controls[pos[2]].BackColor = colorActual;
            tetrisPanel.Controls[pos[3]].BackColor = colorActual;
        }
        //Abajo
        private void arrowDownJ()
        {
            if (contains(filaSup, pos[0] - 10))
                pos[0] = pos[0] + 10;
            tetrisPanel.Controls[pos[0]].BackColor = Color.Black;
            tetrisPanel.Controls[pos[1]].BackColor = Color.Black;
            tetrisPanel.Controls[pos[2]].BackColor = Color.Black;
            tetrisPanel.Controls[pos[3]].BackColor = Color.Black;
            pos[1] = pos[0] - 10;
            pos[2] = pos[0] - 20;
            pos[3] = pos[0] - 19;
            tetrisPanel.Controls[pos[0]].BackColor = colorActual;
            tetrisPanel.Controls[pos[1]].BackColor = colorActual;
            tetrisPanel.Controls[pos[2]].BackColor = colorActual;
            tetrisPanel.Controls[pos[3]].BackColor = colorActual;
        }
        //<-----
        private void arrowIzqJ()
        {
            if (contains(colD, pos[3]))
                pos[0] = pos[0] - 2;
            tetrisPanel.Controls[pos[0]].BackColor = Color.Black;
            tetrisPanel.Controls[pos[1]].BackColor = Color.Black;
            tetrisPanel.Controls[pos[2]].BackColor = Color.Black;
            tetrisPanel.Controls[pos[3]].BackColor = Color.Black;
            pos[1] = pos[0] + 1;
            pos[2] = pos[0] + 2;
            pos[3] = pos[0] + 12;
            tetrisPanel.Controls[pos[0]].BackColor = colorActual;
            tetrisPanel.Controls[pos[1]].BackColor = colorActual;
            tetrisPanel.Controls[pos[2]].BackColor = colorActual;
            tetrisPanel.Controls[pos[3]].BackColor = colorActual;
        }
        private void arrowUpJ()
        {
            if (contains(filaInf, pos[3]))
                pos[0] = pos[0] - 10;
            tetrisPanel.Controls[pos[0]].BackColor = Color.Black;
            tetrisPanel.Controls[pos[1]].BackColor = Color.Black;
            tetrisPanel.Controls[pos[2]].BackColor = Color.Black;
            tetrisPanel.Controls[pos[3]].BackColor = Color.Black;
            pos[1] = pos[0] + 10;
            pos[2] = pos[0] + 20;
            pos[3] = pos[0] + 19;
            tetrisPanel.Controls[pos[0]].BackColor = colorActual;
            tetrisPanel.Controls[pos[1]].BackColor = colorActual;
            tetrisPanel.Controls[pos[2]].BackColor = colorActual;
            tetrisPanel.Controls[pos[3]].BackColor = colorActual;
        }
        #endregion

        #region Girar figura L
        private void arrowDerL()
        {
            tetrisPanel.Controls[pos[0]].BackColor = Color.Black;
            tetrisPanel.Controls[pos[1]].BackColor = Color.Black;
            tetrisPanel.Controls[pos[2]].BackColor = Color.Black;
            tetrisPanel.Controls[pos[3]].BackColor = Color.Black;
            pos[1] = pos[0] - 1;
            pos[2] = pos[0] - 2;
            pos[3] = pos[0] + 8;
            tetrisPanel.Controls[pos[0]].BackColor = colorActual;
            tetrisPanel.Controls[pos[1]].BackColor = colorActual;
            tetrisPanel.Controls[pos[2]].BackColor = colorActual;
            tetrisPanel.Controls[pos[3]].BackColor = colorActual;
        }
        //Abajo
        private void arrowDownL()
        {
            tetrisPanel.Controls[pos[0]].BackColor = Color.Black;
            pos[0] = pos[0] + 10;
            tetrisPanel.Controls[pos[0]].BackColor = colorActual;

            tetrisPanel.Controls[pos[0]].BackColor = Color.Black;
            tetrisPanel.Controls[pos[1]].BackColor = Color.Black;
            tetrisPanel.Controls[pos[2]].BackColor = Color.Black;
            tetrisPanel.Controls[pos[3]].BackColor = Color.Black;
            pos[1] = pos[0] - 10;
            pos[2] = pos[0] - 20;
            pos[3] = pos[0] - 21;
            tetrisPanel.Controls[pos[0]].BackColor = colorActual;
            tetrisPanel.Controls[pos[1]].BackColor = colorActual;
            tetrisPanel.Controls[pos[2]].BackColor = colorActual;
            tetrisPanel.Controls[pos[3]].BackColor = colorActual;
        }
        //<-----
        private void arrowIzqL()
        {
            tetrisPanel.Controls[pos[0]].BackColor = Color.Black;
            tetrisPanel.Controls[pos[1]].BackColor = Color.Black;
            tetrisPanel.Controls[pos[2]].BackColor = Color.Black;
            tetrisPanel.Controls[pos[3]].BackColor = Color.Black;
            pos[1] = pos[0] + 1;
            pos[2] = pos[0] + 2;
            pos[3] = pos[0] - 8;
            tetrisPanel.Controls[pos[0]].BackColor = colorActual;
            tetrisPanel.Controls[pos[1]].BackColor = colorActual;
            tetrisPanel.Controls[pos[2]].BackColor = colorActual;
            tetrisPanel.Controls[pos[3]].BackColor = colorActual;
        }
        private void arrowUpL()
        {
            tetrisPanel.Controls[pos[0]].BackColor = Color.Black;
            tetrisPanel.Controls[pos[1]].BackColor = Color.Black;
            tetrisPanel.Controls[pos[2]].BackColor = Color.Black;
            tetrisPanel.Controls[pos[3]].BackColor = Color.Black;
            pos[1] = pos[0] + 10;
            pos[2] = pos[0] + 20;
            pos[3] = pos[0] + 21;
            tetrisPanel.Controls[pos[0]].BackColor = colorActual;
            tetrisPanel.Controls[pos[1]].BackColor = colorActual;
            tetrisPanel.Controls[pos[2]].BackColor = colorActual;
            tetrisPanel.Controls[pos[3]].BackColor = colorActual;
        }
        #endregion

        #region Girar figura T
        private void arrowDerT()
        {
            tetrisPanel.Controls[pos[0]].BackColor = Color.Black;
            tetrisPanel.Controls[pos[1]].BackColor = Color.Black;
            tetrisPanel.Controls[pos[2]].BackColor = Color.Black;
            tetrisPanel.Controls[pos[3]].BackColor = Color.Black;
            pos[1] = pos[0] - 10;
            pos[2] = pos[0] + 10;
            pos[3] = pos[0] - 1;
            tetrisPanel.Controls[pos[0]].BackColor = colorActual;
            tetrisPanel.Controls[pos[1]].BackColor = colorActual;
            tetrisPanel.Controls[pos[2]].BackColor = colorActual;
            tetrisPanel.Controls[pos[3]].BackColor = colorActual;
        }
        //Abajo
        private void arrowDownT()
        {
            tetrisPanel.Controls[pos[0]].BackColor = Color.Black;
            tetrisPanel.Controls[pos[1]].BackColor = Color.Black;
            tetrisPanel.Controls[pos[2]].BackColor = Color.Black;
            tetrisPanel.Controls[pos[3]].BackColor = Color.Black;
            pos[1] = pos[0] - 1;
            pos[2] = pos[0] + 1;
            pos[3] = pos[0] - 10;
            tetrisPanel.Controls[pos[0]].BackColor = colorActual;
            tetrisPanel.Controls[pos[1]].BackColor = colorActual;
            tetrisPanel.Controls[pos[2]].BackColor = colorActual;
            tetrisPanel.Controls[pos[3]].BackColor = colorActual;
        }
        //<-----
        private void arrowIzqT()
        {
            tetrisPanel.Controls[pos[0]].BackColor = Color.Black;
            tetrisPanel.Controls[pos[1]].BackColor = Color.Black;
            tetrisPanel.Controls[pos[2]].BackColor = Color.Black;
            tetrisPanel.Controls[pos[3]].BackColor = Color.Black;
            pos[1] = pos[0] - 10;
            pos[2] = pos[0] + 10;
            pos[3] = pos[0] + 1;
            tetrisPanel.Controls[pos[0]].BackColor = colorActual;
            tetrisPanel.Controls[pos[1]].BackColor = colorActual;
            tetrisPanel.Controls[pos[2]].BackColor = colorActual;
            tetrisPanel.Controls[pos[3]].BackColor = colorActual;
        }
        private void arrowUpT()
        {
            tetrisPanel.Controls[pos[0]].BackColor = Color.Black;
            tetrisPanel.Controls[pos[1]].BackColor = Color.Black;
            tetrisPanel.Controls[pos[2]].BackColor = Color.Black;
            tetrisPanel.Controls[pos[3]].BackColor = Color.Black;
            pos[1] = pos[0] - 1;
            pos[2] = pos[0] + 1;
            pos[3] = pos[0] + 10;
            tetrisPanel.Controls[pos[0]].BackColor = colorActual;
            tetrisPanel.Controls[pos[1]].BackColor = colorActual;
            tetrisPanel.Controls[pos[2]].BackColor = colorActual;
            tetrisPanel.Controls[pos[3]].BackColor = colorActual;
        }
        #endregion

        #region Girar figura Z1
        private void arrowDerZ1()
        {
            tetrisPanel.Controls[pos[0]].BackColor = Color.Black;
            tetrisPanel.Controls[pos[1]].BackColor = Color.Black;
            tetrisPanel.Controls[pos[2]].BackColor = Color.Black;
            tetrisPanel.Controls[pos[3]].BackColor = Color.Black;
            pos[1] = pos[0] - 10;
            pos[2] = pos[0] - 1;
            pos[3] = pos[0] + 9;
            tetrisPanel.Controls[pos[0]].BackColor = colorActual;
            tetrisPanel.Controls[pos[1]].BackColor = colorActual;
            tetrisPanel.Controls[pos[2]].BackColor = colorActual;
            tetrisPanel.Controls[pos[3]].BackColor = colorActual;
        }
        //Abajo
        private void arrowDownZ1()
        {
            tetrisPanel.Controls[pos[0]].BackColor = Color.Black;
            tetrisPanel.Controls[pos[1]].BackColor = Color.Black;
            tetrisPanel.Controls[pos[2]].BackColor = Color.Black;
            tetrisPanel.Controls[pos[3]].BackColor = Color.Black;
            pos[1] = pos[0] - 1;
            pos[2] = pos[0] + 10;
            pos[3] = pos[0] + 11;
            tetrisPanel.Controls[pos[0]].BackColor = colorActual;
            tetrisPanel.Controls[pos[1]].BackColor = colorActual;
            tetrisPanel.Controls[pos[2]].BackColor = colorActual;
            tetrisPanel.Controls[pos[3]].BackColor = colorActual;
        }
        //<-----
        private void arrowIzqZ1()
        {
            tetrisPanel.Controls[pos[0]].BackColor = Color.Black;
            tetrisPanel.Controls[pos[1]].BackColor = Color.Black;
            tetrisPanel.Controls[pos[2]].BackColor = Color.Black;
            tetrisPanel.Controls[pos[3]].BackColor = Color.Black;
            pos[1] = pos[0] - 10;
            pos[2] = pos[0] - 1;
            pos[3] = pos[0] + 9;
            tetrisPanel.Controls[pos[0]].BackColor = colorActual;
            tetrisPanel.Controls[pos[1]].BackColor = colorActual;
            tetrisPanel.Controls[pos[2]].BackColor = colorActual;
            tetrisPanel.Controls[pos[3]].BackColor = colorActual;
        }
        private void arrowUpZ1()
        {
            tetrisPanel.Controls[pos[0]].BackColor = Color.Black;
            tetrisPanel.Controls[pos[1]].BackColor = Color.Black;
            tetrisPanel.Controls[pos[2]].BackColor = Color.Black;
            tetrisPanel.Controls[pos[3]].BackColor = Color.Black;
            pos[1] = pos[0] - 1;
            pos[2] = pos[0] + 10;
            pos[3] = pos[0] + 11;
            tetrisPanel.Controls[pos[0]].BackColor = colorActual;
            tetrisPanel.Controls[pos[1]].BackColor = colorActual;
            tetrisPanel.Controls[pos[2]].BackColor = colorActual;
            tetrisPanel.Controls[pos[3]].BackColor = colorActual;
        }
        #endregion

        #region Girar figura Z2
        private void arrowDerZ2()
        {
            tetrisPanel.Controls[pos[0]].BackColor = Color.Black;
            pos[0] = pos[0] + 10;
            tetrisPanel.Controls[pos[0]].BackColor = colorActual;

            tetrisPanel.Controls[pos[0]].BackColor = Color.Black;
            tetrisPanel.Controls[pos[1]].BackColor = Color.Black;
            tetrisPanel.Controls[pos[2]].BackColor = Color.Black;
            tetrisPanel.Controls[pos[3]].BackColor = Color.Black;
            pos[1] = pos[0] - 10;
            pos[2] = pos[0] + 1;
            pos[3] = pos[0] + 11;
            tetrisPanel.Controls[pos[0]].BackColor = colorActual;
            tetrisPanel.Controls[pos[1]].BackColor = colorActual;
            tetrisPanel.Controls[pos[2]].BackColor = colorActual;
            tetrisPanel.Controls[pos[3]].BackColor = colorActual;
        }
        //Abajo
        private void arrowDownZ2()
        {
            tetrisPanel.Controls[pos[0]].BackColor = Color.Black;
            tetrisPanel.Controls[pos[1]].BackColor = Color.Black;
            tetrisPanel.Controls[pos[2]].BackColor = Color.Black;
            tetrisPanel.Controls[pos[3]].BackColor = Color.Black;
            pos[1] = pos[0] + 1;
            pos[2] = pos[0] + 10;
            pos[3] = pos[0] + 9;
            tetrisPanel.Controls[pos[0]].BackColor = colorActual;
            tetrisPanel.Controls[pos[1]].BackColor = colorActual;
            tetrisPanel.Controls[pos[2]].BackColor = colorActual;
            tetrisPanel.Controls[pos[3]].BackColor = colorActual;
        }
        //<-----
        private void arrowIzqZ2()
        {
            tetrisPanel.Controls[pos[0]].BackColor = Color.Black;
            pos[0] = pos[0] + 10;
            tetrisPanel.Controls[pos[0]].BackColor = colorActual;

            tetrisPanel.Controls[pos[0]].BackColor = Color.Black;
            tetrisPanel.Controls[pos[1]].BackColor = Color.Black;
            tetrisPanel.Controls[pos[2]].BackColor = Color.Black;
            tetrisPanel.Controls[pos[3]].BackColor = Color.Black;
            pos[1] = pos[0] - 10;
            pos[2] = pos[0] + 1;
            pos[3] = pos[0] + 11;
            tetrisPanel.Controls[pos[0]].BackColor = colorActual;
            tetrisPanel.Controls[pos[1]].BackColor = colorActual;
            tetrisPanel.Controls[pos[2]].BackColor = colorActual;
            tetrisPanel.Controls[pos[3]].BackColor = colorActual;
        }
        private void arrowUpZ2()
        {
            tetrisPanel.Controls[pos[0]].BackColor = Color.Black;
            tetrisPanel.Controls[pos[1]].BackColor = Color.Black;
            tetrisPanel.Controls[pos[2]].BackColor = Color.Black;
            tetrisPanel.Controls[pos[3]].BackColor = Color.Black;
            pos[1] = pos[0] + 1;
            pos[2] = pos[0] + 10;
            pos[3] = pos[0] + 9;
            tetrisPanel.Controls[pos[0]].BackColor = colorActual;
            tetrisPanel.Controls[pos[1]].BackColor = colorActual;
            tetrisPanel.Controls[pos[2]].BackColor = colorActual;
            tetrisPanel.Controls[pos[3]].BackColor = colorActual;
        }
        #endregion



        private void girarFigura()
        {
            switch (current)
            {
                case (int)figuras.I:
                    switch (state)
                    {
                        case 0:
                            arrowDerI();
                            state = 1;
                            break;
                        case 1:
                            arrowDownI();
                            state = 2;
                            break;
                        case 2:
                            arrowIzqI();
                            state = 3;
                            break;
                        case 3:
                            arrowUpI();
                            state = 0;
                            break;
                    }
                    break;
                case (int)figuras.J:
                    switch (state)
                    {
                        case 0:
                            arrowDerJ();
                            state = 1;
                            break;
                        case 1:
                            arrowDownJ();
                            state = 2;
                            break;
                        case 2:
                            arrowIzqJ();
                            state = 3;
                            break;
                        case 3:
                            arrowUpJ();
                            state = 0;
                            break;
                    }
                    break;
                case (int)figuras.L:
                    switch (state)
                    {
                        case 0:
                            arrowDerL();
                            state = 1;
                            break;
                        case 1:
                            arrowDownL();
                            state = 2;
                            break;
                        case 2:
                            arrowIzqL();
                            state = 3;
                            break;
                        case 3:
                            arrowUpL();
                            state = 0;
                            break;
                    }
                    break;
                case (int)figuras.O:
                    state = 0;
                    break;
                case (int)figuras.T:
                    switch (state)
                    {
                        case 0:
                            arrowDerT();
                            state = 1;
                            break;
                        case 1:
                            arrowDownT();
                            state = 2;
                            break;
                        case 2:
                            arrowIzqT();
                            state = 3;
                            break;
                        case 3:
                            arrowUpT();
                            state = 0;
                            break;
                    }
                    break;
                case (int)figuras.Z1:
                    switch (state)
                    {
                        case 0:
                            arrowDerZ1();
                            state = 1;
                            break;
                        case 1:
                            arrowDownZ1();
                            state = 2;
                            break;
                        case 2:
                            arrowIzqZ1();
                            state = 3;
                            break;
                        case 3:
                            arrowUpZ1();
                            state = 0;
                            break;
                    }
                    break;
                case (int)figuras.Z2:
                    switch (state)
                    {
                        case 0:
                            arrowDerZ2();
                            state = 1;
                            break;
                        case 1:
                            arrowDownZ2();
                            state = 2;
                            break;
                        case 2:
                            arrowIzqZ2();
                            state = 3;
                            break;
                        case 3:
                            arrowUpZ2();
                            state = 0;
                            break;
                    }
                    break;
            }
        }

        private void tetrisTimer_Tick(object sender, EventArgs e)
        {
            checkBajar();
        }

        private void checkBajar()
        {
            bool col = false;
            foreach (int celda in pos)
            {
                if (celda >= 190 && celda <= 199)
                {
                    col = true;
                    dropFigure();
                    break;
                }

            }
            switch (fig)
            {
                case (int)figuras.I:
                    switch (state)
                    {
                        case 0:
                            if (tetrisPanel.Controls[pos[3] + 10].BackColor != Color.Black)
                            {
                                col = true;
                                dropFigure();
                            }
                            break;
                        case 1:
                            if (tetrisPanel.Controls[pos[0] + 10].BackColor != Color.Black || tetrisPanel.Controls[pos[1] + 10].BackColor != Color.Black || tetrisPanel.Controls[pos[2] + 10].BackColor != Color.Black || tetrisPanel.Controls[pos[3] + 10].BackColor != Color.Black)
                            {
                                col = true;
                                dropFigure();
                            }
                            break;
                        case 2:
                            if (tetrisPanel.Controls[pos[3] + 10].BackColor != Color.Black)
                            {
                                col = true;
                                dropFigure();
                            }
                            break;
                        case 3:
                            if (tetrisPanel.Controls[pos[0] + 10].BackColor != Color.Black || tetrisPanel.Controls[pos[1] + 10].BackColor != Color.Black || tetrisPanel.Controls[pos[2] + 10].BackColor != Color.Black || tetrisPanel.Controls[pos[3] + 10].BackColor != Color.Black)
                            {
                                col = true;
                                dropFigure();
                            }
                            break;
                    }
                    break;
                case (int)figuras.J:
                    switch (state)
                    {
                        case 0:
                            if (tetrisPanel.Controls[pos[2] + 10].BackColor != Color.Black || tetrisPanel.Controls[pos[3] + 10].BackColor != Color.Black)
                            {
                                col = true;
                                dropFigure();
                            }
                            break;
                        case 1:
                            if (tetrisPanel.Controls[pos[0] + 10].BackColor != Color.Black || tetrisPanel.Controls[pos[1] + 10].BackColor != Color.Black || tetrisPanel.Controls[pos[2] + 10].BackColor != Color.Black)
                            {
                                col = true;
                                dropFigure();
                            }
                            break;
                        case 2:
                            if (tetrisPanel.Controls[pos[0] + 10].BackColor != Color.Black)
                            {
                                col = true;
                                dropFigure();
                            }
                            break;
                        case 3:
                            if (tetrisPanel.Controls[pos[0] + 10].BackColor != Color.Black || tetrisPanel.Controls[pos[1] + 10].BackColor != Color.Black || tetrisPanel.Controls[pos[3] + 10].BackColor != Color.Black)
                            {
                                col = true;
                                dropFigure();
                            }
                            break;
                    }
                    break;
                case (int)figuras.L:
                    switch (state)
                    {
                        case 0:
                            if (tetrisPanel.Controls[pos[2] + 10].BackColor != Color.Black || tetrisPanel.Controls[pos[3] + 10].BackColor != Color.Black)
                            {
                                col = true;
                                dropFigure();
                            }
                            break;
                        case 1:
                            if (tetrisPanel.Controls[pos[0] + 10].BackColor != Color.Black || tetrisPanel.Controls[pos[1] + 10].BackColor != Color.Black || tetrisPanel.Controls[pos[3] + 10].BackColor != Color.Black)
                            {
                                col = true;
                                dropFigure();
                            }
                            break;
                        case 2:
                            if (tetrisPanel.Controls[pos[0] + 10].BackColor != Color.Black)
                            {
                                col = true;
                                dropFigure();
                            }
                            break;
                        case 3:
                            if (tetrisPanel.Controls[pos[0] + 10].BackColor != Color.Black || tetrisPanel.Controls[pos[1] + 10].BackColor != Color.Black || tetrisPanel.Controls[pos[2] + 10].BackColor != Color.Black)
                            {
                                col = true;
                                dropFigure();
                            }
                            break;
                    }
                    break;
                case (int)figuras.O:
                    if (tetrisPanel.Controls[pos[2] + 10].BackColor != Color.Black || tetrisPanel.Controls[pos[3] + 10].BackColor != Color.Black)
                    {
                        col = true;
                        dropFigure();
                    }
                    break;
                case (int)figuras.T:
                    switch (state)
                    {
                        case 0:
                            if (tetrisPanel.Controls[pos[3] + 10].BackColor != Color.Black)
                            {
                                col = true;
                                dropFigure();
                            }
                            break;
                        case 1:
                            if (tetrisPanel.Controls[pos[2] + 10].BackColor != Color.Black || tetrisPanel.Controls[pos[3] + 10].BackColor != Color.Black)
                            {
                                col = true;
                                dropFigure();
                            }
                            break;
                        case 2:
                            if (tetrisPanel.Controls[pos[0] + 10].BackColor != Color.Black || tetrisPanel.Controls[pos[1] + 10].BackColor != Color.Black || tetrisPanel.Controls[pos[2] + 10].BackColor != Color.Black)
                            {
                                col = true;
                                dropFigure();
                            }
                            break;
                        case 3:
                            if (tetrisPanel.Controls[pos[2] + 10].BackColor != Color.Black || tetrisPanel.Controls[pos[3] + 10].BackColor != Color.Black)
                            {
                                col = true;
                                dropFigure();
                            }
                            break;
                    }
                    break;
                case (int)figuras.Z1:
                    switch (state)
                    {
                        case 0:
                            if (tetrisPanel.Controls[pos[1] + 10].BackColor != Color.Black || tetrisPanel.Controls[pos[2] + 10].BackColor != Color.Black || tetrisPanel.Controls[pos[3] + 10].BackColor != Color.Black)
                            {
                                col = true;
                                dropFigure();
                            }
                            break;
                        case 1:
                            if (tetrisPanel.Controls[pos[0] + 10].BackColor != Color.Black || tetrisPanel.Controls[pos[3] + 10].BackColor != Color.Black)
                            {
                                col = true;
                                dropFigure();
                            }
                            break;
                        case 2:
                            if (tetrisPanel.Controls[pos[1] + 10].BackColor != Color.Black || tetrisPanel.Controls[pos[2] + 10].BackColor != Color.Black || tetrisPanel.Controls[pos[3] + 10].BackColor != Color.Black)
                            {
                                col = true;
                                dropFigure();
                            }
                            break;
                        case 3:
                            if (tetrisPanel.Controls[pos[0] + 10].BackColor != Color.Black || tetrisPanel.Controls[pos[3] + 10].BackColor != Color.Black)
                            {
                                col = true;
                                dropFigure();
                            }
                            break;
                    }
                    break;
                case (int)figuras.Z2:
                    switch (state)
                    {
                        case 0:
                            if (tetrisPanel.Controls[pos[1] + 10].BackColor != Color.Black || tetrisPanel.Controls[pos[2] + 10].BackColor != Color.Black || tetrisPanel.Controls[pos[3] + 10].BackColor != Color.Black)
                            {
                                col = true;
                                dropFigure();
                            }
                            break;
                        case 1:
                            if (tetrisPanel.Controls[pos[0] + 10].BackColor != Color.Black || tetrisPanel.Controls[pos[3] + 10].BackColor != Color.Black)
                            {
                                col = true;
                                dropFigure();
                            }
                            break;
                        case 2:
                            if (tetrisPanel.Controls[pos[1] + 10].BackColor != Color.Black || tetrisPanel.Controls[pos[2] + 10].BackColor != Color.Black || tetrisPanel.Controls[pos[3] + 10].BackColor != Color.Black)
                            {
                                col = true;
                                dropFigure();
                            }
                            break;
                        case 3:
                            if (tetrisPanel.Controls[pos[0] + 10].BackColor != Color.Black || tetrisPanel.Controls[pos[3] + 10].BackColor != Color.Black)
                            {
                                col = true;
                                dropFigure();
                            }
                            break;
                    }
                    break;
            }
            if (!col)
            {
                bajaFigura();
            }
        }

        private void bajaFigura()
        {
            tetrisPanel.Controls[pos[0]].BackColor = Color.Black;
            tetrisPanel.Controls[pos[1]].BackColor = Color.Black;
            tetrisPanel.Controls[pos[2]].BackColor = Color.Black;
            tetrisPanel.Controls[pos[3]].BackColor = Color.Black;
            pos[0] += 10;
            pos[1] += 10;
            pos[2] += 10;
            pos[3] += 10;
            tetrisPanel.Controls[pos[0]].BackColor = colorActual;
            tetrisPanel.Controls[pos[1]].BackColor = colorActual;
            tetrisPanel.Controls[pos[2]].BackColor = colorActual;
            tetrisPanel.Controls[pos[3]].BackColor = colorActual;
        }

        private void mueveDer()
        {
            bool der = false;
            switch (fig)
            {
                case (int)figuras.I:
                    switch (state)
                    {
                        case 0:
                        case 1:
                        case 2:
                        case 3:
                            if (!contains(colD, pos[3]) && tetrisPanel.Controls[pos[3] + 1].BackColor == Color.Black)
                                der = true;
                            break;
                    }
                    break;
                case (int)figuras.J:
                    switch (state)
                    {
                        case 0:
                            if (!contains(colD, pos[2]) && tetrisPanel.Controls[pos[2] + 1].BackColor == Color.Black)
                                der = true;
                            break;
                        case 1:
                            if (!contains(colD, pos[0]) && tetrisPanel.Controls[pos[0] + 1].BackColor == Color.Black)
                                der = true;
                            break;
                        case 2:
                        case 3:
                            if (!contains(colD, pos[3]) && tetrisPanel.Controls[pos[3] + 1].BackColor == Color.Black)
                                der = true;
                            break;
                    }
                    break;
                case (int)figuras.L:
                    switch (state)
                    {
                        case 3:
                        case 0:
                            if (!contains(colD, pos[3]) && tetrisPanel.Controls[pos[3] + 1].BackColor == Color.Black)
                                der = true;
                            break;
                        case 1:
                        case 2:
                            if (!contains(colD, pos[0]) && tetrisPanel.Controls[pos[0] + 1].BackColor == Color.Black)
                                der = true;
                            break;
                    }
                    break;
                case (int)figuras.O:
                    if (!contains(colD, pos[1]) && tetrisPanel.Controls[pos[1] + 1].BackColor == Color.Black)
                        der = true;
                    break;
                case (int)figuras.T:
                    switch (state)
                    {
                        case 0:
                        case 1:
                        case 2:
                            if (!contains(colD, pos[2]) && tetrisPanel.Controls[pos[2] + 1].BackColor == Color.Black)
                                der = true;
                            break;
                        case 3:
                            if (!contains(colD, pos[3]) && tetrisPanel.Controls[pos[3] + 1].BackColor == Color.Black)
                                der = true;
                            break;
                    }
                    break;
                case (int)figuras.Z1:
                    switch (state)
                    {
                        case 0:
                        case 2:
                            if (!contains(colD, pos[3]) && tetrisPanel.Controls[pos[3] + 1].BackColor == Color.Black)
                                der = true;
                            break;
                        case 1:
                        case 3:
                            if (!contains(colD, pos[0]) && tetrisPanel.Controls[pos[0] + 1].BackColor == Color.Black)
                                der = true;
                            break;
                    }
                    break;
                case (int)figuras.Z2:
                    switch (state)
                    {
                        case 0:
                        case 2:
                            if (!contains(colD, pos[1]) && tetrisPanel.Controls[pos[1] + 1].BackColor == Color.Black && tetrisPanel.Controls[pos[2] + 1].BackColor == Color.Black)
                                der = true;
                            break;
                        case 1:
                        case 3:
                            if (!contains(colD, pos[2]) && tetrisPanel.Controls[pos[2] + 1].BackColor == Color.Black)
                                der = true;
                            break;
                    }
                    break;
            }
            if (der)
            {
                tetrisPanel.Controls[pos[0]].BackColor = Color.Black;
                tetrisPanel.Controls[pos[1]].BackColor = Color.Black;
                tetrisPanel.Controls[pos[2]].BackColor = Color.Black;
                tetrisPanel.Controls[pos[3]].BackColor = Color.Black;
                pos[0] += 1;
                pos[1] += 1;
                pos[2] += 1;
                pos[3] += 1;
                tetrisPanel.Controls[pos[0]].BackColor = colorActual;
                tetrisPanel.Controls[pos[1]].BackColor = colorActual;
                tetrisPanel.Controls[pos[2]].BackColor = colorActual;
                tetrisPanel.Controls[pos[3]].BackColor = colorActual;
            }
        }

        private void mueveIzq()
        {
            bool der = false;
            switch (fig)
            {
                case (int)figuras.I:
                    switch (state)
                    {
                        case 0:
                        case 1:
                        case 2:
                        case 3:
                            if (!contains(colI, pos[0]) && tetrisPanel.Controls[pos[0] - 1].BackColor == Color.Black)
                                der = true;
                            break;
                    }
                    break;
                case (int)figuras.J:
                    switch (state)
                    {
                        case 0:
                        case 1:
                            if (!contains(colI, pos[3]) && tetrisPanel.Controls[pos[3] - 1].BackColor == Color.Black)
                                der = true;
                            break;
                        case 2:
                            if (!contains(colI, pos[2]) && tetrisPanel.Controls[pos[2] - 1].BackColor == Color.Black)
                                der = true;
                            break;
                        case 3:
                            if (!contains(colI, pos[0]) && tetrisPanel.Controls[pos[0] - 1].BackColor == Color.Black)
                                der = true;
                            break;
                    }
                    break;
                case (int)figuras.L:
                    switch (state)
                    {
                        case 0:
                        case 1:
                            if (!contains(colI, pos[2]) && tetrisPanel.Controls[pos[2] - 1].BackColor == Color.Black)
                                der = true;
                            break;
                        case 2:
                            if (!contains(colI, pos[3]) && tetrisPanel.Controls[pos[3] - 1].BackColor == Color.Black)
                                der = true;
                            break;
                        case 3:
                            if (!contains(colI, pos[0]) && tetrisPanel.Controls[pos[0] - 1].BackColor == Color.Black)
                                der = true;
                            break;
                    }
                    break;
                case (int)figuras.O:
                    if (!contains(colI, pos[0]) && tetrisPanel.Controls[pos[0] - 1].BackColor == Color.Black)
                        der = true;
                    break;
                case (int)figuras.T:
                    switch (state)
                    {
                        case 0:
                        case 2:
                        case 3:
                            if (!contains(colI, pos[1]) && tetrisPanel.Controls[pos[1] - 1].BackColor == Color.Black)
                                der = true;
                            break;
                        case 1:
                            if (!contains(colI, pos[3]) && tetrisPanel.Controls[pos[3] - 1].BackColor == Color.Black)
                                der = true;
                            break;
                    }
                    break;
                case (int)figuras.Z1:
                    switch (state)
                    {
                        case 0:
                        case 2:
                            if (!contains(colI, pos[1]) && tetrisPanel.Controls[pos[1] - 1].BackColor == Color.Black && tetrisPanel.Controls[pos[2] - 1].BackColor == Color.Black)
                                der = true;
                            break;
                        case 1:
                        case 3:
                            if (!contains(colI, pos[2]) && tetrisPanel.Controls[pos[2] - 1].BackColor == Color.Black)
                                der = true;
                            break;
                    }
                    break;
                case (int)figuras.Z2:
                    switch (state)
                    {
                        case 0:
                        case 2:
                            if (!contains(colI, pos[3]) && tetrisPanel.Controls[pos[3] - 1].BackColor == Color.Black)
                                der = true;
                            break;
                        case 1:
                        case 3:
                            if (!contains(colI, pos[0]) && tetrisPanel.Controls[pos[0] - 1].BackColor == Color.Black)
                                der = true;
                            break;
                    }
                    break;
            }
            if (der)
            {
                tetrisPanel.Controls[pos[0]].BackColor = Color.Black;
                tetrisPanel.Controls[pos[1]].BackColor = Color.Black;
                tetrisPanel.Controls[pos[2]].BackColor = Color.Black;
                tetrisPanel.Controls[pos[3]].BackColor = Color.Black;
                pos[0] -= 1;
                pos[1] -= 1;
                pos[2] -= 1;
                pos[3] -= 1;
                tetrisPanel.Controls[pos[0]].BackColor = colorActual;
                tetrisPanel.Controls[pos[1]].BackColor = colorActual;
                tetrisPanel.Controls[pos[2]].BackColor = colorActual;
                tetrisPanel.Controls[pos[3]].BackColor = colorActual;
            }
        }

        private bool contains(int[] arr, int val)
        {
            foreach (int v in arr)
                if (v == val)
                    return true;
            return false;
        }

        private bool figCol(int sum)
        {
            foreach (int i in pos)
            {
                if (tetrisPanel.Controls[i + sum].BackColor == Color.Black)
                    return true;
            }
            return false;
        }

        /*private void downloadPB_Click(object sender, EventArgs e)
        {
            if (downloadTC.Visible == true)
                downloadTC.Visible = false;
            else
                downloadTC.Visible = true;
        }*/

        private void tetrisPB_Click(object sender, EventArgs e)
        {
            if (tetrisTC.Visible == true)
                tetrisTC.Visible = false;
            else
                tetrisTC.Visible = true;
        }

        private void GUI_KeyDown(object sender, KeyEventArgs e)
        {
            if (jugando)
            {
                switch (e.KeyCode)
                {
                    case Keys.Up:
                        girarFigura();
                        break;
                    case Keys.Right:
                        mueveDer();
                        break;
                    case Keys.Left:
                        mueveIzq();
                        break;
                    case Keys.Down:
                        checkBajar();
                        break;
                }
            }
        }

        private void Tetris_KeyDown(object sender, KeyEventArgs e)
        {
            
        }
    }
}
