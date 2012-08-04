using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MashGraph_lab6
{
    sealed class DrawContext
    {
        public int LastX, LastY;

        public System.Drawing.Bitmap LastBitmap;

        public bool PolygonIsNowDrawing = false;

        public System.Drawing.Graphics graphics;
        public System.Drawing.Pen pen, dashPen;
        public System.Drawing.Color polygonColor = System.Drawing.Color.Black;
        public System.Drawing.Color backColor = System.Drawing.Color.White;

        public DrawContext(System.Drawing.Image image)
        {
            this.LastBitmap = image as System.Drawing.Bitmap;
            this.graphics = System.Drawing.Graphics.FromImage(image);
            this.pen = new System.Drawing.Pen(this.polygonColor);
            this.dashPen = new System.Drawing.Pen(this.polygonColor);
            this.dashPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
        }
    }
}
