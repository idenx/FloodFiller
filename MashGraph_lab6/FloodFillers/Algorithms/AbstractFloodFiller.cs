using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MashGraph_lab6
{
    abstract class AbstractFloodFiller
    {
        public int NEEDABLE_STACK_SIZE { get {return 250000000;} }
        public bool SlowMode { get; set; }
        public int WorkSpeed = 15;
        public bool notWait = false;
        private const int DEFAULT_WAIT_TIME = 1;
        private int slowCounter = 0;

        protected Bitmap bmp;
        protected PolygonsContainer data;
        protected int aBorderColor, aFillColor, aBackColor;
        protected Color fillColor, backColor, borderColor;

        abstract public void FloodFill(FloodFillContext context);

        protected void Initialize(FloodFillContext context)
        {
            this.bmp = context.bitmap;
            this.data = context.data;
            this.aBorderColor = context.borderColor.ToArgb();
            this.aFillColor = context.fillColor.ToArgb();
            this.aBackColor = context.backColor.ToArgb();
            this.fillColor = context.fillColor;
            this.backColor = context.backColor;
            this.borderColor = context.borderColor;
        }

        protected int GetPixel(int X, int Y)
        {
            int aCurrentColor;
            lock (bmp)
            {
                aCurrentColor = bmp.GetPixel(X, Y).ToArgb();
            }
            return aCurrentColor;
        }

        protected void SetPixel(int X, int Y)
        {
            SetPixel(X, Y, this.fillColor);
        }

        protected void SetPixel(int X, int Y, Color fillColor)
        {
            if (SlowMode && (slowCounter++ % WorkSpeed == 0))
            {
                if (!notWait)
                    System.Threading.Thread.Sleep(DEFAULT_WAIT_TIME);
            }
            lock (bmp)
            {
                bmp.SetPixel(X, Y, fillColor);
            }
        }
    }
}
