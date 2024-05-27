using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App.Controls
{
    public partial class ImageDisplay : UserControl
    {
        public Image? Image;
        public bool   ReadyToDraw = true;

        public ImageDisplay()
        {
            this.InitializeComponent();
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.UserPaint |
              ControlStyles.AllPaintingInWmPaint |
              ControlStyles.OptimizedDoubleBuffer
              , true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            this.ReadyToDraw = false;
            base.OnPaint(e);
            e.Graphics.Clear(Color.Black);

            if (this.Image == null) {
                this.ReadyToDraw = true;
                return;
            }
            
            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            e.Graphics.CompositingMode   = CompositingMode.SourceCopy;
            e.Graphics.DrawImage(this.Image, 0, 0);
            e.Graphics.CompositingMode   = CompositingMode.SourceOver;
//            this.Image.Dispose();
            this.ReadyToDraw = true;
        }

    }
}
