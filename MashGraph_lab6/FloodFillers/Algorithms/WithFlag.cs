using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MashGraph_lab6.FloodFillers
{
    class WithFlag : AbstractFloodFiller
    {
        public override void FloodFill(FloodFillContext context)
        {
            Initialize(context);
            var graphics = System.Drawing.Graphics.FromImage(bmp);
            foreach (KeyValuePair<Point, Point> edge in data.GetAllEdges())
            {
                graphics.DrawLine(new Pen(backColor), edge.Key, edge.Value);
                DrawLineDDA(edge.Key, edge.Value);
            }
            Fill();
        }

        private void Fill()
        {
            var bounds = data.GetPolygonBounds();
            int yMin = bounds.Top, yMax = bounds.Bottom;
            int xMin = bounds.Left, xMax = bounds.Right;
            bool insideFlag;
            int currentColor;
            for (int currentY = yMin; currentY < yMax; ++currentY)
            {
                insideFlag = false;
                for (int currentX = xMin; currentX < xMax; ++currentX)
                {
                    currentColor = GetPixel(currentX, currentY);
                    if (currentColor == aBorderColor)
                    {
                        insideFlag = !insideFlag;
                        continue;
                    }
                    if (insideFlag)
                        SetPixel(currentX, currentY);
                    else
                        SetPixel(currentX, currentY, backColor);

                }
            }
        }

         private void DrawLineDDA(Point from, Point to)
        {
            int deltaX = to.X - from.X, deltaY = to.Y - from.Y;
            float dx = (float)deltaX / Math.Abs(deltaY);
            int dy = Math.Sign(deltaY);
            float X = from.X;
            int Y = from.Y;
            int currentX;
            for (int i = 1; i <= Math.Abs(deltaY) + 1; ++i)
            {
                currentX = (int)Math.Ceiling(X);
                if (GetPixel(currentX, Y) == aBorderColor)
                    ++currentX;
                SetPixel(currentX, Y, borderColor);
                X += dx;
                Y += dy;
            }
        }

        public override string ToString()
        {
            return "Со списком ребер и флагом";
        }
    }
}
