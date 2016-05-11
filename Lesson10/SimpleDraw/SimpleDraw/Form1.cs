using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SimpleDraw
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //At this point, GraphicsImage is null. This will assign it a value of a new image that is the size of the DrawingPanel
            GraphicsImage = new Bitmap(DrawingPanel.Width, DrawingPanel.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            //Fills the image we just created with white
            Graphics.FromImage(GraphicsImage).Clear(Color.White);
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            //Fills the image with white
            Graphics.FromImage(GraphicsImage).Clear(Color.White);
            //Draw the GraphicsImage onto the DrawingPanel
            DrawingPanel.CreateGraphics().DrawImageUnscaled(GraphicsImage, new Point(0, 0));
        }

        /*The graphics object we use will draw on this image. This image will
        then be drawn on the drawing surface (DrawingPanel). If we drew directly
        on the DrawingPanel, there would be no way to save what we drew.
        */
        private Bitmap GraphicsImage;

        private void DrawingPanel_MouseMove(object sender, MouseEventArgs e)
        {
            //This sub fires whenever the mouse is moved over the DrawingPanel control
            if (e.Button == MouseButtons.Left) //See if the left mouse button is held down
            {
                //Draw a circle on the canvas
                System.Drawing.Graphics DrawingGraphics = Graphics.FromImage(GraphicsImage);
                if (AACheckBox.Checked)
                {
                    //AntiAliasing is to be used
                    DrawingGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                }
                switch (ShapeComboBox.SelectedIndex)
                {
                    case 0: //draw a filled circle
                        DrawingGraphics.FillEllipse(new SolidBrush(ColorButton.BackColor), new Rectangle(Convert.ToInt32(e.X - numericUpDown1.Value / 2), Convert.ToInt32(e.Y - numericUpDown1.Value / 2), Convert.ToInt32(numericUpDown1.Value), Convert.ToInt32(numericUpDown1.Value)));
                        break;
                    case 1: //draw an open circle
                        DrawingGraphics.DrawEllipse(new Pen(ColorButton.BackColor), new Rectangle(Convert.ToInt32(e.X - numericUpDown1.Value / 2), Convert.ToInt32(e.Y - numericUpDown1.Value / 2), Convert.ToInt32(numericUpDown1.Value), Convert.ToInt32(numericUpDown1.Value)));
                        break;
                    case 2: //draw a filled square
                        DrawingGraphics.FillRectangle(new SolidBrush(ColorButton.BackColor), new Rectangle(Convert.ToInt32(e.X - numericUpDown1.Value / 2), Convert.ToInt32(e.Y - numericUpDown1.Value / 2), Convert.ToInt32(numericUpDown1.Value), Convert.ToInt32(numericUpDown1.Value)));
                        break;
                    case 3: //draw an open square
                        DrawingGraphics.DrawRectangle(new Pen(ColorButton.BackColor), new Rectangle(Convert.ToInt32(e.X - numericUpDown1.Value / 2), Convert.ToInt32(e.Y - numericUpDown1.Value / 2), Convert.ToInt32(numericUpDown1.Value), Convert.ToInt32(numericUpDown1.Value)));
                        break;
                }
                //Draw the GraphicsImage onto the DrawingPanel
                DrawingPanel.CreateGraphics().DrawImageUnscaled(GraphicsImage, new Point(0, 0));
            }
        }

        private void DrawingPanel_MouseDown(object sender, MouseEventArgs e)
        {
            //This sub fires whenever the mouse is clicked on the DrawingPanel control. This makes it so a single click will draw as well
            if (e.Button == MouseButtons.Left) //See if the left mouse button is held down
            {
                //Draw a circle on the canvas
                System.Drawing.Graphics DrawingGraphics = Graphics.FromImage(GraphicsImage);
                if (AACheckBox.Checked)
                {
                    //AntiAliasing is to be used
                    DrawingGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                }
                switch (ShapeComboBox.SelectedIndex)
                {
                    case 0: //draw a filled circle
                        DrawingGraphics.FillEllipse(new SolidBrush(ColorButton.BackColor), new Rectangle(Convert.ToInt32(e.X - numericUpDown1.Value / 2), Convert.ToInt32(e.Y - numericUpDown1.Value / 2), Convert.ToInt32(numericUpDown1.Value), Convert.ToInt32(numericUpDown1.Value)));
                        break;
                    case 1: //draw an open circle
                        DrawingGraphics.DrawEllipse(new Pen(ColorButton.BackColor), new Rectangle(Convert.ToInt32(e.X - numericUpDown1.Value / 2), Convert.ToInt32(e.Y - numericUpDown1.Value / 2), Convert.ToInt32(numericUpDown1.Value), Convert.ToInt32(numericUpDown1.Value)));
                        break;
                    case 2: //draw a filled square
                        DrawingGraphics.FillRectangle(new SolidBrush(ColorButton.BackColor), new Rectangle(Convert.ToInt32(e.X - numericUpDown1.Value / 2), Convert.ToInt32(e.Y - numericUpDown1.Value / 2), Convert.ToInt32(numericUpDown1.Value), Convert.ToInt32(numericUpDown1.Value)));
                        break;
                    case 3: //draw an open square
                        DrawingGraphics.DrawRectangle(new Pen(ColorButton.BackColor), new Rectangle(Convert.ToInt32(e.X - numericUpDown1.Value / 2), Convert.ToInt32(e.Y - numericUpDown1.Value / 2), Convert.ToInt32(numericUpDown1.Value), Convert.ToInt32(numericUpDown1.Value)));
                        break;
                }
                //Draw the GraphicsImage onto the DrawingPanel
                DrawingPanel.CreateGraphics().DrawImageUnscaled(GraphicsImage, new Point(0, 0));
            }
        }

        private void DrawingPanel_Paint(object sender, PaintEventArgs e)
        {
            /*Draw the GraphicsImage onto the DrawingPanel. In this, instead
             * of using DrawingPanel.CreateGraphics(), we can use e.Graphics instead.
             * It will return the graphics used to paint DrawingPanel. This will do the 
             * same as DrawingPanel.CreateGraphics(), but i thought i should point
             * this out */
            e.Graphics.DrawImageUnscaled(GraphicsImage, new Point(0, 0));
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            //this event fires when the user clicks Save on the save dialog. It will save the image
            GraphicsImage.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Bmp);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Shows the save dialog
            saveFileDialog1.ShowDialog();
        }

        private void ColorButton_Click(object sender, EventArgs e)
        {
            //Shows the choose color dialog
            colorDialog1.ShowDialog();
            /*Set's the ColorButton's backcolor to the color chosen by
             * the user. When painting on the image, you will notice we
             * refer to this property to get the color to paint with. */
            ColorButton.BackColor = colorDialog1.Color;
        }
    }
}
