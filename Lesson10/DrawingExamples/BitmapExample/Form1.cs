using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BitmapExample
{
    public partial class Form1 : Form
    {
        private readonly Bitmap _bm;
        private Color _color;


        public Form1()
        {
            InitializeComponent();

            _bm = new Bitmap("image.png");
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawImage(_bm, 0, 0);

            base.OnPaint(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    _color = _bm.GetPixel(e.X, e.Y);
                    break;
                case MouseButtons.Right:
                    for (int i = -10; i < 11; i++)
                    {
                        int newX = e.X + i;
                        if (newX < 0 || newX > _bm.Width)
                            continue;
                        for (int j = -10; j < 11; j++)
                        {
                            int newY = e.Y + j;
                            if (newY < 0 || newY > _bm.Height)
                                continue;
                            _bm.SetPixel(newX, newY, _color);
                        }
                    }
                    Refresh();
                    break;
            }
        }
    }
}
