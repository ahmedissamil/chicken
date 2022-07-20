using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fr5a2
{
    public partial class Form1 : Form
    {
        Bitmap off;
        public int f = 0;
        public int f2 = 0;
        public int f3 = 0;
        List<chi> c = new List<chi>();
        List<ho> h = new List<ho>();
        List<egg> eggg = new List<egg>();
        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.Paint += Form1_paint;
            this.KeyDown += Form1_KeyDown;
            this.MouseDown += Form1_MouseDown;
            this.MouseMove += Form1_MouseMove;
            this.MouseUp += Form1_MouseUp;
            this.Load += Form1_loade;
            Timer t = new Timer();
            t.Start();
            t.Tick += T_Tick;
            t.Interval = 100;
        }
        private void T_Tick(object sender, EventArgs e)
        {
            
            for (int i = 0; i < eggg.Count; i++)
            {
                if (h[0].hox <= eggg[i].egx && h[0].hox + 80 >= eggg[i].egx)
                {
                    if (h[0].hoy <= eggg[i].egy && h[0].hoy + 50 >= eggg[i].egy)
                    {
                        eggg[i].egy = h[0].hoy;
                        eggg[i].egx = h[0].hox;
                    }
                }
            }
            for (int i2 = 0; i2 < eggg.Count; i2++)
            {
                eggg[i2].egy = eggg[i2].egy + 5;
            }
            Dubblebuffer(this.CreateGraphics());
        }
        private void Form1_loade(object sender, EventArgs e)
        {
            chi pnn = new chi();
            pnn.chix = ClientSize.Width / 2;
            pnn.chiy = ClientSize.Height / 4;
            pnn.imgch= new Bitmap("1.bmp");
            c.Add(pnn);
            for (int i = 0; i < 3; i++)
            {
                ho pnn2 = new ho();
                pnn2.hox = 100*i*5;
                pnn2.hoy = ClientSize.Height * 3 / 4;
                pnn2.imgho = new Bitmap("2.bmp");
                h.Add(pnn2);
            }
            off = new Bitmap(ClientSize.Width, ClientSize.Height);
        }
        void Dubblebuffer(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(off);
            Drowscene(g2);
            g.DrawImage(off, 0, 0);
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            f = 0;
            f2 = 0;
            f3 = 0;
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (f == 1)
            {
                h[0].hox = e.X;
                h[0].hoy = e.Y;
            }
            if (f2 == 1)
            {
                h[1].hox = e.X;
                h[1].hoy = e.Y;
            }
            if (f3 == 1)
            {
                h[2].hox = e.X;
                h[2].hoy = e.Y;
            }
        }
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button==MouseButtons.Left)
            {
                if (h[0].hox <= e.X && h[0].hox + 80 >= e.X)
                {
                    if (h[0].hoy <= e.Y && h[0].hoy + 50 >= e.Y)
                    {
                        f = 1;
                    }
                }
                if (h[1].hox <= e.X && h[1].hox + 80 >= e.X)
                {
                    if (h[1].hoy <= e.Y && h[1].hoy + 50 >= e.Y)
                    {
                        f2 = 1;
                    }
                }
                if (h[2].hox <= e.X && h[2].hox + 80 >= e.X)
                {
                    if (h[2].hoy <= e.Y && h[2].hoy + 50 >= e.Y)
                    {
                        f3 = 1;
                    }
                }
            }
            
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Right)
            {
                c[0].chix= c[0].chix+5;
            }
            if (e.KeyCode == Keys.Left)
            {
                c[0].chix= c[0].chix-5;
            }
            if (e.KeyCode == Keys.Space)
            {
                egg pnn3 = new egg();
                pnn3.egx = c[0].chix + 10;
                pnn3.egy = c[0].chiy+70;
                pnn3.imgeg = new Bitmap("3.bmp");
                eggg.Add(pnn3);
            }
            
        }
        private void Form1_paint(object sender, PaintEventArgs e)
        {
            Dubblebuffer(e.Graphics);
        }
        void Drowscene(Graphics g)
        {
            g.Clear(Color.Black);
            c[0].imgch.MakeTransparent();
            g.DrawImage(c[0].imgch,c[0].chix,c[0].chiy);
            for(int i=0;i<3;i++)
            {
                g.DrawImage(h[i].imgho, h[i].hox, h[i].hoy);
            }

            for (int i = 0; i < eggg.Count; i++)
            {
                g.DrawImage(eggg[i].imgeg, eggg[i].egx, eggg[i].egy);
            }
        }
    }
    class chi
    {
        public int chix;
        public int chiy;
        public Bitmap imgch;
    }
    class ho
    {
        public int hox;
        public int hoy;
        public Bitmap imgho;
    }
    class egg
    {
        public int egx;
        public int egy;
        public Bitmap imgeg;
    }
}
