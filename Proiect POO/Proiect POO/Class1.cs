using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect_POO
{
    public abstract class Figura
    {
        public int X { get { return x; } set { x = value; } }
        public int Y { get { return y; } set { y = value; } }
        protected Image img;
        protected int x, y, w, h;
        protected Pen pen = new Pen(Color.Black, 2); //grosimea de 2px
        public void daLungime(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public virtual void Deseneaza(Graphics g)
        {
            g.DrawLine(pen, x, y, x + w, y + h);
        }
    }

    public class Linie : Figura
    {
        public Linie( int x, int y, int w, int h)
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
        }
        override public void Deseneaza(Graphics g)
        {
            g.DrawLine(pen, x, y, x + w, y + h);
        }
    }
    public class Triunghi : Figura
    {
        private int x1, y1, x2, y2, x3, y3;
        public Triunghi(int x1,int y1, int x2, int y2, int x3, int y3)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
            this.x3 = x3;
            this.y3 = y3;

        }
        override public void Deseneaza(Graphics g)
        {
            g.DrawLine(pen, x1, y1, x2, y2);
            g.DrawLine(pen, x2, y2, x3, y3);
            g.DrawLine(pen, x3, y3, x1, y1);
        }
    }

    public class Elipsa : Figura
    {
        public Elipsa(int x, int y, int w, int h)
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
        }
        override public void Deseneaza(Graphics g)
        {
            g.DrawEllipse(pen, x, y, w, h);
        }
    }

    public class Dreptunghi : Figura
    {
        public Dreptunghi(int x, int y, int w, int h)
        {
            this.x = x;
            this.y = y;
            this.w = w;
            this.h = h;
        }
        override public void Deseneaza(Graphics g)
        {
            g.DrawRectangle(pen, x, y, w, h);
        }
    }

    public class CurbaBezier : Figura
    {
        private int x1, y1, x2, y2, x3, y3,x4,y4;
        public CurbaBezier(int x1, int y1, int x2, int y2, int x3, int y3,int x4, int y4)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
            this.x3 = x3;
            this.y3 = y3;
            this.x4 = x4;
            this.y4 = y4;

        }
        override public void Deseneaza(Graphics g)
        {
            g.DrawBezier(pen, x1, y1, x2, y2,x3,y3,x4,y4);
        }
    }

    public  class Manager
    {

    }
}

