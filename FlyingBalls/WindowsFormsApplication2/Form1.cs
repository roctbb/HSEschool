using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public bool gameIsStarted = false;
        public Ball [] Vasias;

        public Form1()
        {
            Random rnd = new Random();
            Vasias = new Ball[10];
            for (int i = 0; i < 10; i++ )
                Vasias[i] = new Ball(ClientSize.Width, ClientSize.Height, rnd);
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Hide();
            button1.Hide();
            button2.Hide();
            this.Invalidate();
            this.timer1.Start();
            gameIsStarted = true;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (gameIsStarted == true)
            {
                for (int i = 0; i < 10; i++)
                    Vasias[i].draw(e.Graphics);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                Vasias[i].move();
                if (Vasias[i].getX() < 0 || Vasias[i].getX() > ClientSize.Width)
                    Vasias[i].inverseX();
                if (Vasias[i].getY() < 0 || Vasias[i].getY() > ClientSize.Height)
                    Vasias[i].inverseY();
                for (int j = i+1; j<10; j++)
                {
                    if (
                        Math.Sqrt(
                            (Vasias[i].getX() - Vasias[j].getX())*
                            (Vasias[i].getX() - Vasias[j].getX()) +
                            (Vasias[i].getY() - Vasias[j].getY())*
                            (Vasias[i].getY() - Vasias[j].getY())
                        ) 
                        < Vasias[i].getRadius() + Vasias[j].getRadius())
                    {
                        Vasias[i].inverseX();
                        Vasias[j].inverseX();
                        Vasias[i].inverseY();
                        Vasias[j].inverseY();
                    }
                }
            }
            Invalidate();
        }
    }
}
