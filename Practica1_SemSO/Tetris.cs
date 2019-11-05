using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica1_SemSO
{
    public partial class Tetris : Form
    {
        public Tetris()
        {
            InitializeComponent();
            int xGrafico = pictureBox1.Location.X;
            int yGrafico = pictureBox1.Location.Y;
            Graphics g = this.CreateGraphics();
            Pen lapiz = new Pen(Color.Purple, 3);
            g.DrawRectangle(lapiz, new Rectangle(xGrafico, yGrafico, 5, 5));
        }
    }
}
