using System.Collections.Generic;
using Microsoft.VisualBasic;
using System.Windows.Forms;
using System.Drawing;
using System;

namespace Lonesure
{
    public partial class Form1 : Form
    {
        #region Initialization

        private PictureBox[] p = new PictureBox[16] { new PictureBox(), new PictureBox(), new PictureBox(), new PictureBox(), new PictureBox(), new PictureBox(), new PictureBox(), new PictureBox(), new PictureBox(), new PictureBox(), new PictureBox(), new PictureBox(), new PictureBox(), new PictureBox(), new PictureBox(), new PictureBox() };
        private List<Image> l = new List<Image>() { Image.FromFile(@"Images\1.png"), Image.FromFile(@"Images\2.png"), Image.FromFile(@"Images\3.png"), Image.FromFile(@"Images\4.png"), Image.FromFile(@"Images\5.png"), Image.FromFile(@"Images\6.png"), Image.FromFile(@"Images\7.png"), Image.FromFile(@"Images\8.png") };
        private List<int> i = new List<int>() { 0, 0, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7, 7 }, pol = new List<int>(), de = new List<int>(), pe = new List<int>(), za = new List<int>(), go = new List<int>();
        private string name1 = "Hráč1", name2 = "Hráč2", k = "";
        private Image def = Image.FromFile(@"Images\0.png");
        private int[] s = new int[2] { -5, -5 };
        private Random r = new Random();
        private int poc = 1, next = -5;
        private bool b = true;
        
        public Form1()
        {
            this.InitializeComponent();

            this.p[0].BackColor = Color.Transparent;
            this.p[0].Cursor = Cursors.Hand;
            this.p[0].Size = new Size(64, 64);
            this.p[0].TabStop = false;
            this.p[0].Click += new EventHandler(this.pictureBox1_Click);
            this.p[0].Location = new Point(12, 39);
            this.p[0].Name = "pictureBox1";
            this.p[0].TabIndex = 0;

            this.p[1].BackColor = Color.Transparent;
            this.p[1].Cursor = Cursors.Hand;
            this.p[1].Size = new Size(64, 64);
            this.p[1].Click += new EventHandler(this.pictureBox2_Click);
            this.p[1].Location = new Point(98, 39);
            this.p[1].Name = "pictureBox2";
            this.p[1].TabIndex = 1;

            this.p[2].BackColor = Color.Transparent;
            this.p[2].Cursor = Cursors.Hand;
            this.p[2].Size = new Size(64, 64);
            this.p[2].Click += new EventHandler(this.pictureBox3_Click);
            this.p[2].Location = new Point(183, 39);
            this.p[2].Name = "pictureBox3";
            this.p[2].TabIndex = 2;

            this.p[3].BackColor = Color.Transparent;
            this.p[3].Cursor = Cursors.Hand;
            this.p[3].Size = new Size(64, 64);
            this.p[3].Click += new EventHandler(this.pictureBox4_Click);
            this.p[3].Location = new Point(267, 39);
            this.p[3].Name = "pictureBox4";
            this.p[3].TabIndex = 3;

            this.p[4].BackColor = Color.Transparent;
            this.p[4].Cursor = Cursors.Hand;
            this.p[4].Size = new Size(64, 64);
            this.p[4].Click += new EventHandler(this.pictureBox5_Click);
            this.p[4].Location = new Point(267, 123);
            this.p[4].Name = "pictureBox5";
            this.p[4].TabIndex = 4;

            this.p[5].BackColor = Color.Transparent;
            this.p[5].Cursor = Cursors.Hand;
            this.p[5].Size = new Size(64, 64);
            this.p[5].Click += new EventHandler(this.pictureBox6_Click);
            this.p[5].Location = new Point(183, 123);
            this.p[5].Name = "pictureBox6";
            this.p[5].TabIndex = 5;

            this.p[6].BackColor = Color.Transparent;
            this.p[6].Cursor = Cursors.Hand;
            this.p[6].Size = new Size(64, 64);
            this.p[6].Click += new EventHandler(this.pictureBox7_Click);
            this.p[6].Location = new Point(98, 123);
            this.p[6].Name = "pictureBox7";
            this.p[6].TabIndex = 6;

            this.p[7].BackColor = Color.Transparent;
            this.p[7].Cursor = Cursors.Hand;
            this.p[7].Size = new Size(64, 64);
            this.p[7].Click += new EventHandler(this.pictureBox8_Click);
            this.p[7].Location = new Point(12, 123);
            this.p[7].Name = "pictureBox8";
            this.p[7].TabIndex = 7;

            this.p[8].BackColor = Color.Transparent;
            this.p[8].Cursor = Cursors.Hand;
            this.p[8].Size = new Size(64, 64);
            this.p[8].Click += new EventHandler(this.pictureBox9_Click);
            this.p[8].Location = new Point(267, 287);
            this.p[8].Name = "pictureBox9";
            this.p[8].TabIndex = 8;

            this.p[9].BackColor = Color.Transparent;
            this.p[9].Cursor = Cursors.Hand;
            this.p[9].Size = new Size(64, 64);
            this.p[9].Click += new EventHandler(this.pictureBox10_Click);
            this.p[9].Location = new Point(183, 287);
            this.p[9].Name = "pictureBox10";
            this.p[9].TabIndex = 9;

            this.p[10].BackColor = Color.Transparent;
            this.p[10].Cursor = Cursors.Hand;
            this.p[10].Size = new Size(64, 64);
            this.p[10].Click += new EventHandler(this.pictureBox11_Click);
            this.p[10].Location = new Point(98, 287);
            this.p[10].Name = "pictureBox11";
            this.p[10].TabIndex = 10;

            this.p[11].BackColor = Color.Transparent;
            this.p[11].Cursor = Cursors.Hand;
            this.p[11].Size = new Size(64, 64);
            this.p[11].Click += new EventHandler(this.pictureBox12_Click);
            this.p[11].Location = new Point(12, 287);
            this.p[11].Name = "pictureBox12";
            this.p[11].TabIndex = 11;

            this.p[12].BackColor = Color.Transparent;
            this.p[12].Cursor = Cursors.Hand;
            this.p[12].Size = new Size(64, 64);
            this.p[12].Click += new EventHandler(this.pictureBox13_Click);
            this.p[12].Location = new Point(267, 205);
            this.p[12].Name = "pictureBox13";
            this.p[12].TabIndex = 12;

            this.p[13].BackColor = Color.Transparent;
            this.p[13].Cursor = Cursors.Hand;
            this.p[13].Size = new Size(64, 64);
            this.p[13].Click += new EventHandler(this.pictureBox14_Click);
            this.p[13].Location = new Point(183, 205);
            this.p[13].Name = "pictureBox14";
            this.p[13].TabIndex = 13;

            this.p[14].BackColor = Color.Transparent;
            this.p[14].Cursor = Cursors.Hand;
            this.p[14].Size = new Size(64, 64);
            this.p[14].Click += new EventHandler(this.pictureBox15_Click);
            this.p[14].Location = new Point(98, 205);
            this.p[14].Name = "pictureBox15";
            this.p[14].TabIndex = 14;

            this.p[15].BackColor = Color.Transparent;
            this.p[15].Cursor = Cursors.Hand;
            this.p[15].Size = new Size(64, 64);
            this.p[15].Click += new EventHandler(this.pictureBox16_Click);
            this.p[15].Location = new Point(12, 205);
            this.p[15].Name = "pictureBox16";
            this.p[15].TabIndex = 15;

            this.Controls.Add(this.p[0]);
            this.Controls.Add(this.p[1]);
            this.Controls.Add(this.p[2]);
            this.Controls.Add(this.p[3]);
            this.Controls.Add(this.p[4]);
            this.Controls.Add(this.p[5]);
            this.Controls.Add(this.p[6]);
            this.Controls.Add(this.p[7]);
            this.Controls.Add(this.p[8]);
            this.Controls.Add(this.p[9]);
            this.Controls.Add(this.p[10]);
            this.Controls.Add(this.p[11]);
            this.Controls.Add(this.p[12]);
            this.Controls.Add(this.p[13]);
            this.Controls.Add(this.p[14]);
            this.Controls.Add(this.p[15]);

            this.ShuffleList(this.i.Count);
            this.Zr();
        }

        #endregion

        #region Main

        private void timer1_Tick(object sender, EventArgs e)
        {
            if ((((this.name1 == "PC" || this.name1 == "pc" || this.name1 == "Pc") && this.b == true) || ((this.name2 == "PC" || this.name2 == "pc" || this.name2 == "Pc") && this.b == false)))
                if (this.next == -5)
                    this.Pics(this.Ran(), true);
                else
                {
                    this.Pics(this.next, true);
                    this.next = -5;
                }
            else
                this.Pv(true);
        }

        #region PictureBoxes

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Pics(0);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Pics(1);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Pics(2);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Pics(3);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Pics(4);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            this.Pics(5);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Pics(6);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            this.Pics(7);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            this.Pics(8);
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            this.Pics(9);
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            this.Pics(10);
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            this.Pics(11);
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            this.Pics(12);
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            this.Pics(13);
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            this.Pics(14);
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            this.Pics(15);
        }

        #endregion

        #region Labels

        private void label1_Click(object sender, EventArgs e)
        {
            int doc = name1.Length;

            if ((this.name1 = Interaction.InputBox("Zadejte jméno hráče1.", "Nastavení jména hráče1", this.name1, Screen.PrimaryScreen.Bounds.Width / 2 - 180, Screen.PrimaryScreen.Bounds.Height / 2 - 100)) == "")
                this.name1 = "Hráč1";

            this.label1.Text = this.name1  + ": " + this.label1.Text.Substring(doc + 2);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            int doc = name2.Length;

            if ((this.name2 = Interaction.InputBox("Zadejte jméno hráče2.", "Nastavení jména hráče2", this.name2, Screen.PrimaryScreen.Bounds.Width / 2 - 180, Screen.PrimaryScreen.Bounds.Height / 2 - 100)) == "")
                this.name2 = "Hráč2";

            this.label2.Text = this.name2 + ": " + this.label2.Text.Substring(doc + 2);
        }

        #endregion

        #endregion
    }
}
