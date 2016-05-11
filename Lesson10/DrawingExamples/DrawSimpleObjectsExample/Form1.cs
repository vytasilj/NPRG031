using System;
using System.Drawing;
using System.Windows.Forms;

namespace DrawSimpleObjectsExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            ReDraw();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            Refresh();
        }

        private void ReDraw()
        {
            Graphics graphics = CreateGraphics();
            graphics.Clear(Color.LightGray);

            DrawLine(graphics);
            DrawCircle(graphics);
            DrawRectangle(graphics);

            FillCircle(graphics);

            DrawText(graphics);
        }

        private void DrawLine(Graphics graphics)
        {
            Pen myPen = new Pen(Color.Red, 5);
            graphics.DrawLine(myPen, 20, 20, 200, 210);
        }

        private void DrawCircle(Graphics graphics)
        {
            Pen pen = new Pen(Color.Green, 10);
            int width = Width / 4;
            int height = Height / 4;
            graphics.DrawEllipse(pen, Width/2 - width/2, Height/2 - height/2, width, height);
        }

        private void DrawRectangle(Graphics graphics)
        {
            graphics.DrawRectangle(Pens.Aqua, Width - 120, Height - 90, 100, 50);
        }

        private void FillCircle(Graphics graphics)
        {
            int width = Width / 8;
            int height = Height / 8;
            graphics.FillEllipse(Brushes.Yellow, Width / 2 - width / 2, Height / 2 - height / 2, width, height);
        }

        private void DrawText(Graphics graphics)
        {
            Font font = new Font("Helvetica", 40, FontStyle.Bold | FontStyle.Italic);
            graphics.DrawString("Hello World!", font, Brushes.DarkBlue, 0, (float) Height/2 - 40);
            
            Font arialFont = new Font("Arial", 100);
            graphics.DrawString("ABCD", arialFont, Brushes.Black, 14, 14);
            graphics.DrawString("ABCD", arialFont, Brushes.Green, 10, 10);
        }
    }
}
