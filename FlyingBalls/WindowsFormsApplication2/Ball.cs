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
    public class Ball
    {
        private int x, y;
        private int radius;
        private int speed_x, speed_y;
        private Brush brush;

        public Ball(int width, int height, Random rnd)
        {
            x = rnd.Next(width);
            y = rnd.Next(height);
            radius = rnd.Next(20) + 10;
            speed_x = rnd.Next(20);
            speed_y = rnd.Next(20);
            brush = new SolidBrush(Color.FromArgb(
                rnd.Next(255),rnd.Next(255),rnd.Next(255)
                ));
                
        }
        public int getX()
        {
            return x;
        }
        public int getY()
        {
            return y;
        }
        public int getRadius()
        {
            return radius;
        }
        public void inverseX()
        {
            speed_x *=-1;
        }
        public void inverseY()
        {
            speed_y *= -1;
        }
        public void move()
        {
            x += speed_x;
            y += speed_y;
        }
        public void draw(Graphics gr)
        {
            gr.FillEllipse(brush, x-radius, y-radius, 
                2*radius, 2*radius);
        }
    }
}
