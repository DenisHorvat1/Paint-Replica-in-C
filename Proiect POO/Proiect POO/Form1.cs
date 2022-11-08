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
    public partial class Form1 : Form
    {
        Bitmap img;
        Graphics g;
        List<Figura> figuri = new List<Figura>();
        int l;
        bool apasat=false;

        public Form1()
        {
            InitializeComponent();
            nou();
            l = img.Width;
            figuriRandom.Items.Add("Linie");
            figuriRandom.Items.Add("Triunghi");
            figuriRandom.Items.Add("Dreptunghi");
            figuriRandom.Items.Add("Elipsa");
            figuriRandom.Items.Add("Curba Bezier");
            figuriRandom.SelectedIndex = 0;
            nrDeFiguri.SelectedIndex = 0;
            figuriRandom.DropDownStyle = ComboBoxStyle.DropDownList;
            g.Clear(Color.White);
            p.Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
      
        }

        //*****************FUNCTII************************

        void nou()
        {
            img = new Bitmap(p.Width, p.Height);
            g = Graphics.FromImage(img);
            g.Clear(Color.White);
        }


        void DeseneazaLiniiRandom(Graphics g, int n) //deseneaza n linii selectand 2 pucte random de pe laturi random
        {
            Random rd = new Random();
            int latura1 = rd.Next(1, 5);
            int latura2 = rd.Next(1, 5);
            
            int rand_num = rd.Next(0, l);
            int x1 = 0, x2 = 0, y2 = 0, y1 = 0;
            figuri = new List<Figura>();
            for (int j = 0; j < n; j++)
            {

                latura1 = rd.Next(1, 5);
                latura2 = rd.Next(1, 5);
                while (latura2 == latura1)
                {
                    latura2 = rd.Next(1, 5);
                }

                if (latura1 == 1)  //latura1
                {
                    x1 = rand_num; y1 = 0;
                    rand_num = rd.Next(0, l);
                }
                if (latura1 == 2)
                {
                    x1 = l; y1 = rand_num;
                    rand_num = rd.Next(0, l);
                }
                if (latura1 == 3)
                {
                    x1 = rand_num; y1 = l;
                    rand_num = rd.Next(0, l);
                }
                if (latura1 == 4)

                {
                    x1 = 0; y1 = rand_num;
                    rand_num = rd.Next(0, l);
                }
                if (latura2 == 1)  //latura 2
                {
                    x2 = rand_num; y2 = 0;
                    rand_num = rd.Next(0, l);
                }
                if (latura2 == 2)
                {
                    x2 = l; y2 = rand_num;
                    rand_num = rd.Next(0, l);
                }
                if (latura2 == 3)
                {
                    x2 = rand_num; y2 = l;
                    rand_num = rd.Next(0, l);
                }
                if (latura2 == 4)
                {
                    x2 = 0; y2 = rand_num;
                    rand_num = rd.Next(0, l);
                }
                // x1 y1 sunt P1, x2 si y2 sunt P2, traseaza linie de la p1 la p2
                figuri.Add(new Linie(x1,y1,x2-x1,y2-y1));
            }
            foreach (Figura temp in figuri)
            {
                temp.Deseneaza(g);
            }
            figuri = null;

        }

        void DeseneazaTriunghiRandom(Graphics g, int n)
        {
            Random rd = new Random();
            int rand_num = rd.Next(0, l);
            figuri = new List<Figura>();
            int x1, y1, x2, y2, x3, y3;
            for (int i = 0; i < n; i++)
            {
                x1 = rand_num;
                rand_num = rd.Next(0, l);
                y1 = rand_num;
                rand_num = rd.Next(0, l);
                x2 = rand_num;
                rand_num = rd.Next(0, l);
                y2 = rand_num;
                rand_num = rd.Next(0, l);
                x3 = rand_num;
                rand_num = rd.Next(0, l);
                y3 = rand_num;
                rand_num = rd.Next(0, l);
                figuri.Add(new Triunghi(x1, y1, x2, y2, x3, y3));
            }
            foreach (Figura temp in figuri)
            {
                temp.Deseneaza(g);
            }
            figuri = null;
        }

        void DeseneazaDreptunghiRandom(Graphics g, int n)
        {
            Random rd = new Random();
            int rand_num = rd.Next(0, l);
            figuri = new List<Figura>();
            int x ,y, w, h;
            for (int i = 0; i < n; i++)
            {
                rand_num = rd.Next(0, l);
                x = rand_num;
                rand_num = rd.Next(0, l);
                y = rand_num;
                rand_num = rd.Next(x, l);
                w = rand_num;
                rand_num = rd.Next(y, l);
                h = rand_num;
                figuri.Add(new Dreptunghi(x,y,w-x,h-y));
            }
            foreach (Figura temp in figuri)
            {
                temp.Deseneaza(g);
            }
            figuri = null;
        }

        void DeseneazaElipsaRandom(Graphics g, int n)
        {
            Random rd = new Random();
            int rand_num = rd.Next(0, l);
            figuri = new List<Figura>();
            //figuri = null;
            int x, y, w, h;
            for (int i = 0; i < n; i++)
            {
                rand_num = rd.Next(0, l);
                x = rand_num;
                rand_num = rd.Next(0, l);
                y = rand_num;
                rand_num = rd.Next(x, l);
                w = rand_num;
                rand_num = rd.Next(y, l);
                h = rand_num;
                figuri.Add(new Elipsa(x, y, w - x, h - y));
            }
            foreach (Figura temp in figuri)
            {
                temp.Deseneaza(g);
            }
            figuri = null;
        }

        void DeseneazaCurbaBezierRandom(Graphics g, int n)
        {
            Random rd = new Random();
            int rand_num = rd.Next(0, l);
            figuri = new List<Figura>();
            int x1, y1, x2, y2, x3, y3, x4, y4;
            for (int i = 0; i < n; i++)
            {
                x1 = rand_num;
                rand_num = rd.Next(0, l);
                y1 = rand_num;

                rand_num = rd.Next(0, l);
                x2 = rand_num;
                rand_num = rd.Next(0, l);
                y2 = rand_num;
                rand_num = rd.Next(0, l);
                x3 = rand_num;
                rand_num = rd.Next(0, l);
                y3 = rand_num;
                rand_num = rd.Next(0, l);
                x4 = rand_num;
                rand_num = rd.Next(0, l);
                y4 = rand_num;
                rand_num = rd.Next(0, l);
                figuri.Add(new CurbaBezier(x1, y1, x2, y2, x3, y3, x4, y4));
            }
            foreach (Figura temp in figuri)
            {
                temp.Deseneaza(g);
            }
            figuri = null;
        }

        private void FloodFill(Bitmap bmp, Point pt, Color targetColor, Color replacementColor)
        {
            targetColor = bmp.GetPixel(pt.X, pt.Y);
            if (targetColor.ToArgb().Equals(replacementColor.ToArgb()))
            {
                return;
            }

            Stack<Point> pixels = new Stack<Point>();

            pixels.Push(pt);
            while (pixels.Count != 0)
            {
                Point temp = pixels.Pop();
                int y1 = temp.Y;
                while (y1 >= 0 && bmp.GetPixel(temp.X, y1) == targetColor)
                {
                    y1--;
                }
                y1++;
                bool spanLeft = false;
                bool spanRight = false;
                while (y1 < bmp.Height && bmp.GetPixel(temp.X, y1) == targetColor)
                {
                    bmp.SetPixel(temp.X, y1, replacementColor);

                    if (!spanLeft && temp.X > 0 && bmp.GetPixel(temp.X - 1, y1) == targetColor)
                    {
                        pixels.Push(new Point(temp.X - 1, y1));
                        spanLeft = true;
                    }
                    else if (spanLeft && temp.X - 1 == 0 && bmp.GetPixel(temp.X - 1, y1) != targetColor)
                    {
                        spanLeft = false;
                    }
                    if (!spanRight && temp.X < bmp.Width - 1 && bmp.GetPixel(temp.X + 1, y1) == targetColor)
                    {
                        pixels.Push(new Point(temp.X + 1, y1));
                        spanRight = true;
                    }
                    else if (spanRight && temp.X < bmp.Width - 1 && bmp.GetPixel(temp.X + 1, y1) != targetColor)
                    {
                        spanRight = false;
                    }
                    y1++;
                }

            }
            p.Refresh();

        }

        /* void Umplere (int x, int y, Color culoareNoua, Color culoareActuala)
         {
             //culoareNoua = Culoare in care colorez
             //culoareActuala = Culoare pe care apas click
             //margine
             //Color culoareTemp = img.GetPixel(x, y);
             if ((x <= 0) || (x >= 450)) return;
             if ((y <= 0) || (y >= 440)) return;
             if (culoareNoua == culoareActuala) return;
             p.Refresh();
             img.SetPixel(x,y,culoareNoua);
             //g.DrawLine(pen, x, y, x,y);
             Umplere(x+1, y, culoareNoua, culoareActuala);
             Umplere(x, y+1, culoareNoua, culoareActuala);
             Umplere(x-1, y, culoareNoua, culoareActuala);
             Umplere(x, y-1, culoareNoua, culoareActuala);
             p.Refresh();
         }
         */


        void determinaCerneala(Form2 f2, int w, int h)
        {
            float S=0;
            float r=0, g=0, b=0,c=0,k=0,m=0,y=0,cT,cM,cC,cY,cK;
            cT = 2;
            for(int i = 0; i < l; i++)
            {
                for (int j = 0; j < l; j++)
                {
                    Color culoare = img.GetPixel(i, j);
                    r += culoare.R;
                    g += culoare.G;
                    b += culoare.B;
                    S++;
                }
            }
            r /= S;
            g /= S;
            b /= S;

            r /= 255;
            g /= 255;
            b /= 255;

            if (r >= g && r >= b)
            {
                k = 1 - r;
            }
            else if (g >= b && g >= r)
                k = 1 - g;
            else
                k = 1 - b;


            if (k == 1)
            {
                c = 0;
                m = 0;
                y = 0;
            }
            else
            {
                c = (1 - r - k) / (1 - k);
                m = (1 - g - k) / (1 - k);
                y = (1 - b - k) / (1 - k);
            }

            cC = cT * c / (c + m + y + k);
            cM = cT * m / (c + m + y + k);
            cY = cT * y / (c + m + y + k);
            cK = cT * k / (c + m + y + k);
            f2.labelK.Text = cK.ToString();
            f2.labelM.Text = cM.ToString();
            f2.labelY.Text = cY.ToString();
            f2.labelC.Text = cC.ToString();
        }
        //**********************EVENIMENTE***********************

        private void figuriRandom_DrawItem(object sender, DrawItemEventArgs e)
        {
            try
            {
                e.DrawBackground();
                Rectangle r = new Rectangle(e.Bounds.Height, e.Bounds.Top + 2, e.Bounds.Width - e.Bounds.Height - 2, e.Bounds.Height - 4);
                System.Drawing.Font font = new System.Drawing.Font("Arial", 7, FontStyle.Bold);
                StringFormat sf = new StringFormat();
                sf.LineAlignment = StringAlignment.Center;
                e.Graphics.DrawString(figuriRandom.Items[e.Index].ToString(), font, Brushes.Black, r, sf);
                e.DrawFocusRectangle();
            }
            catch (Exception) { }
        }


        private void figuriRandom_SelectedIndexChanged(object sender, EventArgs e)
        {
            int x = 0;
            Int32.TryParse(nrDeFiguri.Text, out x);
            if (figuriRandom.Text == "Linie")
            {
                DeseneazaLiniiRandom(g, x);
                p.Refresh();
            }
            else if (figuriRandom.Text == "Triunghi")
            {
                DeseneazaTriunghiRandom(g, x);
                p.Refresh();
            }
            else if (figuriRandom.Text == "Dreptunghi")
            {
                DeseneazaDreptunghiRandom(g, x);
                p.Refresh();
            }
            else if (figuriRandom.Text == "Elipsa")
            {
                DeseneazaElipsaRandom(g, x);
                p.Refresh();
            }
            else if (figuriRandom.Text == "Curba Bezier")
            {
                DeseneazaCurbaBezierRandom(g, x);
                p.Refresh();
            }

        }

        private void nrDeFiguri_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void p_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(img, 0, 0);
        }

        private void p_MouseDown(object sender, MouseEventArgs e)
        {

            Point p = new Point(e.X, e.Y);
            if (apasat)
            {
                Color culoareActuala = img.GetPixel(e.X, e.Y);
                FloodFill(img, p, culoareActuala, cd.Color);
            }
            //apasat = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Bitmap Image (.bmp)|*.bmp|Gif Image (.gif)|*.gif |JPEG Image (.jpeg)|*.jpeg |Png Image (.png)|*.png |Tiff Image (.tiff)|*.tiff |Wmf Image (.wmf)|*.wmf";
                sfd.FilterIndex = 4;
                sfd.ShowDialog();
                //teste nume sfd.textname 
                Image imgsave = new Bitmap(img.Width, img.Height);
                Graphics gsave = Graphics.FromImage(imgsave);
                gsave.DrawImage(img, 0, 0);
                imgsave.Save(sfd.FileName);
            }
            catch (Exception) { }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            try
            {
                if (pd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    print.Print();
                }
            }
            catch (Exception) { }
        }
        private void print_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            MessageBox.Show("Imprimare terminata.", "Imprimare");
        }

        private void print_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(img, 0, 0);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(this);
            int w, h;
            f2.textBox1.Text = "100";
            f2.textBox2.Text = "100";
            f2.textBox3.Text = "2";
            Int32.TryParse(f2.textBox1.Text, out w);
            Int32.TryParse(f2.textBox2.Text, out h);
            determinaCerneala(f2,w,h);
            f2.Show();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.DialogResult raspuns;
            raspuns = MessageBox.Show("Creati alt desen?", "Avertizare", MessageBoxButtons.YesNo);
            if (raspuns == System.Windows.Forms.DialogResult.Yes)
            {
                nou();
                p.Refresh();
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            figuriRandom_SelectedIndexChanged( sender,  e);
            p.Refresh();
        }
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            apasat = true;
            Point p = new Point(100, 100);
            Color culoareActuala = img.GetPixel(100, 100);
        }
        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            cd.ShowDialog();

        }
    }
}
