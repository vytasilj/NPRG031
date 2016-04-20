using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using System;

namespace Lonesure
{
    partial class Form1
    {
        private void ShuffleList(int t)
        {
            int randomIndex = this.r.Next(0, t);

            this.i.Add(this.i[randomIndex]);
            this.i.RemoveAt(randomIndex);

            if (t > 1)
                this.ShuffleList(t - 1);
        }

        private int Ran()
        {
            this.pol.Clear();
            this.Pol();

            int ou = this.pol[this.r.Next(this.pol.Count - 1)];

            if (this.s[0] != -5)
                this.k += "|" + this.s[0] + ";" + ou + "|";

            return ou;
        }

        private void Pol(int hf = 15)
        {
            if ((this.p[hf].Visible && ((this.s[0] == -5 && !this.za.Contains(hf)) || (this.s[0] != -5 && this.s[0] != hf && !k.Contains("|" + this.s[0] + ";" + hf + "|")))))
                this.pol.Add(hf);

            if (hf > 0)
                this.Pol(hf - 1);
        }

        private void Pv(bool f, int tol = 15)
        {
            this.p[tol].Enabled = f;

            if (tol > 0)
                this.Pv(f, tol - 1);
        }

        private void Pics(int pic, bool pc = false)
        {
            if (pc)
                this.Pv(false);

            this.p[pic].Image = this.l[this.i[pic]];

            if (this.s[0] == -5)
            {
                if (this.de.Contains(this.i[pic]))
                {
                    if (pc)
                        this.next = this.pe[this.de.IndexOf(this.i[pic])];
                }
                else
                {
                    this.de.Add(this.i[pic]);
                    this.pe.Add(pic);
                }

                this.s[0] = pic;
                this.s[1] = this.i[pic];

                if (!this.za.Contains(pic) && !this.go.Contains(this.i[pic]))
                {
                    this.za.Add(pic);
                    this.go.Add(this.i[pic]);
                }
            }
            else
            {
                if (this.s[0] != pic && this.s[1] == this.i[pic])
                {
                    this.Zr(pic);
                    this.Zr(this.s[0]);

                    if (!pc)
                        MessageBox.Show("Good job!");

                    int h1 = int.Parse(this.label1.Text.Substring(name1.Length + 2)), h2 = int.Parse(this.label2.Text.Substring(name2.Length + 2));

                    if (this.b)
                    {
                        h1 = h1 + 1;
                        this.label1.Text = this.name1 + ": " + h1.ToString();
                    }
                    else
                    {
                        h2 = h2 + 1;
                        this.label2.Text = this.name2 + ": " + h2.ToString();
                    }

                    if ((h1 + h2) == this.poc * 8)
                    {
                        this.timer1.Enabled = false;

                        string vit;

                        if (h1 > h2)
                            vit = this.name1 + ".";
                        else if (h1 < h2)
                            vit = this.name2 + ".";
                        else
                            vit = "Nikdo - remíza.";

                        if (MessageBox.Show("Konec hry! Zvítězil: " + vit + Environment.NewLine + "Chcete pokračovat ve hře? Pokud ne, bude program ukončen...", "Předzavírací dialog", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                        {
                            this.za.Clear();
                            this.de.Clear();
                            this.pe.Clear();
                            this.go.Clear();
                            this.k = "";
                            this.poc++;
                            this.Zr();

                            this.p[0].Visible = this.p[1].Visible = this.p[2].Visible = this.p[3].Visible = this.p[4].Visible = this.p[5].Visible = this.p[6].Visible = this.p[7].Visible = this.p[8].Visible = this.p[9].Visible = this.p[10].Visible = this.p[11].Visible = this.p[12].Visible = this.p[13].Visible = this.p[14].Visible = this.p[15].Visible = true;
                            this.ShuffleList(this.i.Count);
                            this.timer1.Enabled = true;
                        }
                        else
                            this.Close();
                    }
                }
                else
                {
                    this.Zr();

                    if (this.s[1] != this.i[pic])
                    {
                        this.b = !this.b;

                        if (this.b == true)
                        {
                            this.label1.ForeColor = Color.RoyalBlue;
                            this.label2.ForeColor = Color.Black;
                        }
                        else
                        {
                            this.label2.ForeColor = Color.RoyalBlue;
                            this.label1.ForeColor = Color.Black;
                        }
                    }
                }

                this.s[0] = -5;
            }
        }

        private void Zr(int co = -5)
        {
            if (co == -5)
                this.p[0].Image = this.p[1].Image = this.p[2].Image = this.p[3].Image = this.p[4].Image = this.p[5].Image = this.p[6].Image = this.p[7].Image = this.p[8].Image = this.p[9].Image = this.p[10].Image = this.p[11].Image = this.p[12].Image = this.p[13].Image = this.p[14].Image = this.p[15].Image = this.def;
            else
                this.p[co].Visible = false;
        }
    }
}
