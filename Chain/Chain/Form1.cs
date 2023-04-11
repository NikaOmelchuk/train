using System;
using System.Drawing;
using System.Windows.Forms;
using ChainLib;

namespace Chain
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            g = this.CreateGraphics();
        }

        loco L = new loco();
        loco l1 = null;
        loco l2 = null;

        Graphics g;

        int X = 0;
        Bitmap picL = new Bitmap(@"C:\Users\Саша\Desktop\Визуалка\лаби арітектура\Келементи\loco.png");
        Bitmap pic1 = new Bitmap(@"C:\Users\Саша\Desktop\Визуалка\лаби арітектура\Келементи\vag1.png");
        Bitmap pic2 = new Bitmap(@"C:\Users\Саша\Desktop\Визуалка\лаби арітектура\Келементи\vag2.png");
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            X += 100;
            l1.Req(new TrainSob(1, X,pic1));
            g.DrawImage(pic1, new Rectangle(X, 100, 100, 100));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button5.Enabled = true;
            button3.Enabled = true;
            button4.Enabled = true;

            l1 = new vagon1();
            l2 = new vagon2();
            l1.NextTo(l2);

            X = 100;
            g.DrawImage(picL, new Rectangle(X, 100, 100, 100));

            button2.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            X += 100;
            l1.Req(new TrainSob(2, X, pic2));
            g.DrawImage(pic2, new Rectangle(X, 100, 100, 100));
        }

        int Xl = 100;
        private void timer1_Tick(object sender, EventArgs e)
        {
            g.FillRectangle(new SolidBrush(Color.LightGray), new Rectangle(Xl, 100, 100, 100));
            Xl -= 5;
            g.DrawImage(picL, new Rectangle(Xl, 100, 100, 100));

            for (int i = 0; i < l1.tts.Count; i++)
                g.FillRectangle(new SolidBrush(Color.LightGray), new Rectangle(l1.tts[i].x, 100, 100, 100));
            for (int i = 0; i < l2.tts.Count; i++)
                g.FillRectangle(new SolidBrush(Color.LightGray), new Rectangle(l2.tts[i].x, 100, 100, 100));

            for (int i = 0; i < l1.tts.Count; i++)
                l1.tts[i].move();
            for (int i = 0; i < l2.tts.Count; i++)
                l2.tts[i].move();

            for (int i = 0; i < l1.tts.Count; i++)
                g.DrawImage(l1.tts[i].pic, new Rectangle(l1.tts[i].x, 100, 100, 100));
            for (int i = 0; i < l2.tts.Count; i++)
                g.DrawImage(l2.tts[i].pic, new Rectangle(l2.tts[i].x, 100, 100, 100));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }
    }
}
