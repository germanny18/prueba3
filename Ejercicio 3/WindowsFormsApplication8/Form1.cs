using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication8
{
    public partial class Form1 : Form
    {
        Bitmap bmp;
        int x, y;
        int mR = 0, mG = 0, mB = 0;

        int p = 0;
        int []vecX = new int[3];
        int []vecY = new int[3];

        int [] r = new int[3];
        int [] g = new int[3];
        int [] b = new int[3];

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Todos|*.*|Archivos JPEG|*.jpg|Archivos GIF|*.gif";
            openFileDialog1.FileName = "";
            openFileDialog1.ShowDialog();
            bmp = new Bitmap(openFileDialog1.FileName);
            pictureBox1.Image = bmp;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Color c = new Color();
            c = bmp.GetPixel(10, 10);
            //textBox1.Text = c.R.ToString();
            //textBox2.Text = c.G.ToString();
            //textBox3.Text = c.B.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();
            for(int i=0;i<bmp.Width;i++)
                for (int j = 0; j < bmp.Height; j++)
                {
                    c = bmp.GetPixel(i, j);
                    bmp2.SetPixel(i,j, Color.FromArgb(c.R,0,0));
                }
            pictureBox1.Image = bmp2;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();
            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {
                    c = bmp.GetPixel(i, j);
                    bmp2.SetPixel(i, j, Color.FromArgb(0, 0, c.B));
                }
            pictureBox1.Image = bmp2;
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e){
            if (p == 3)
                p = 0;
            x = e.X;
            y = e.Y;
            //textBox4.Text = x.ToString();
            //textBox5.Text = y.ToString();
            vecX[p] = x;
            vecY[p] = y;
           
            textBox4.Text = vecX[0].ToString();
            textBox5.Text = vecY[0].ToString();

            textBox6.Text = vecX[1].ToString();
            textBox7.Text = vecY[1].ToString();

            textBox8.Text = vecX[2].ToString();
            textBox9.Text = vecY[2].ToString();

            Color c = new Color();
            mR = 0; mG = 0; mB = 0;
            for (int i=x; i<x+10; i++)
                for (int j = y; j < y + 10; j++){
                    c = bmp.GetPixel(i, j);
                    mR = mR + c.R;
                    mG = mG + c.G;
                    mB = mB + c.B;
                }

            mR = mR / 100;
            mG = mG / 100;
            mB = mB / 100;
            r[p] = mR;
            g[p] = mG;
            b[p] = mB;
            //textBox1.Text = mR.ToString() + " " +  bmp.Height;
            //textBox2.Text = mG.ToString() + " " + bmp.Width;
            //textBox3.Text = mB.ToString() + " " + c.B;
            textBox1.Text = r[0].ToString();
            textBox2.Text = g[0].ToString();
            textBox3.Text = b[0].ToString();

            textBox10.Text = r[1].ToString();
            textBox11.Text = g[1].ToString();
            textBox12.Text = b[1].ToString();

            textBox13.Text = r[2].ToString();
            textBox14.Text = g[2].ToString();
            textBox15.Text = b[2].ToString();
            p++;
        }

        private void button6_Click(object sender, EventArgs e){
            Color cleido = new Color();
            cleido = bmp.GetPixel(vecX[0], vecY[0]);

            Color cleido2 = new Color();
            cleido2 = bmp.GetPixel(vecX[1], vecY[1]);

            Color cleido3 = new Color();
            cleido3 = bmp.GetPixel(vecX[2], vecY[2]);

            Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();
            int q = 0;
            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++){
                    c = bmp.GetPixel(i, j);
                    q = 0;
                    if (((cleido.R - 10 <= c.R) && (c.R <= cleido.R + 10)) &&
                        ((cleido.G - 10 <= c.G) && (c.G <= cleido.G + 10)) &&
                        ((cleido.B - 10 <= c.B) && (c.B <= cleido.B + 10))){
                        bmp2.SetPixel(i, j, Color.Orange);
                        q = 1;
                    }
                    if (((cleido2.R - 10 <= c.R) && (c.R <= cleido2.R + 10)) &&
                        ((cleido2.G - 10 <= c.G) && (c.G <= cleido2.G + 10)) &&
                        ((cleido2.B - 10 <= c.B) && (c.B <= cleido2.B + 10))){
                        bmp2.SetPixel(i, j, Color.Green);
                        q = 1;
                    }
                    if (((cleido3.R - 10 <= c.R) && (c.R <= cleido3.R + 10)) &&
                        ((cleido3.G - 10 <= c.G) && (c.G <= cleido3.G + 10)) &&
                        ((cleido3.B - 10 <= c.B) && (c.B <= cleido3.B + 10))){
                        bmp2.SetPixel(i, j, Color.Red);
                        q = 1;
                    }
                    if(q == 0)
                       bmp2.SetPixel(i, j, Color.FromArgb(c.R, c.G, c.B));
                    
                    
                }
            
            pictureBox1.Image = bmp2;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            int mRn = 0, mGn = 0, mBn = 0;
            Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();
            for (int i = 0; i < bmp.Width-10; i=i+10)
                for (int j = 0; j < bmp.Height-10; j=j+10)
                {

                    for (int i2 = i; i2 < i + 10; i2++)
                        for (int j2 = j; j2 < j + 10; j2++)
                        {
                            c = bmp.GetPixel(i2, j2);
                            mRn = mRn + c.R;
                            mGn = mGn + c.G;
                            mBn = mBn + c.B;
                        }
                    mRn = mRn/100;
                    mGn = mGn/100;
                    mBn = mBn/100;

                    if (((mR - 10 <= mRn) && (mRn <= mR + 10)) &&
                        ((mG - 10 <= mGn) && (mGn <= mG + 10)) &&
                        ((mB - 10 <= mBn) && (mBn <= mB + 10)))
                    {
                        for (int i2 = i; i2 < i + 10; i2++)
                            for (int j2 = j; j2 < j + 10; j2++)
                            {
                                bmp2.SetPixel(i2, j2, Color.Fuchsia);
                            }
                    }
                    else
                    {
                        for (int i2 = i; i2 < i + 10; i2++)
                            for (int j2 = j; j2 < j + 10; j2++)
                            {
                                c = bmp.GetPixel(i2, j2);
                                bmp2.SetPixel(i2, j2, Color.FromArgb(c.R, c.G, c.B));
                            }
                    }
                    

                }
            pictureBox1.Image = bmp2;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Bitmap bmp2 = new Bitmap(bmp.Width, bmp.Height);
            Color c = new Color();
            for (int i = 0; i < bmp.Width; i++)
                for (int j = 0; j < bmp.Height; j++)
                {
                    c = bmp.GetPixel(i, j);
                    bmp2.SetPixel(i, j, Color.FromArgb(0, 0, c.B));
                }
            pictureBox1.Image = bmp2;

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
