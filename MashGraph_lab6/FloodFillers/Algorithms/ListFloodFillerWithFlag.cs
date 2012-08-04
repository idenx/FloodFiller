using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MashGraph_lab6.FloodFillers
{
    class ListFloodFillerWithFlag : AbstractFloodFiller
    {
        public override void FloodFill(FloodFillContext context)
        {
            Initialize(context);
            MakeContur();
            Fill();
            RedrawPolygon();
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

        private void DrawLineByModifiedDDA(Point from, Point to)
        {
            int deltaX = to.X - from.X, deltaY = to.Y - from.Y;
            float dx = (float)deltaX / Math.Abs(deltaY);
            int dy = Math.Sign(deltaY);
            float X = from.X;
            int Y = from.Y;
            int currentX;

            // отбрасываем первую точку
            X += dx;
            Y += dy;
            //------------------------
            for (int i = 1; i <= Math.Abs(deltaY); ++i)
            {
                currentX = (int)Math.Round(X);
                if (GetPixel(currentX, Y) == aBorderColor)
                    ++currentX;
                SetPixel(currentX, Y, borderColor);
                X += dx;
                Y += dy;
            }
        }

        private void RedrawPolygon()
        {
            var graphics = System.Drawing.Graphics.FromImage(bmp);
            foreach (KeyValuePair<Point, Point> edge in data.GetAllEdges())
            {
                graphics.DrawLine(new Pen(borderColor), edge.Key, edge.Value);
            }
        }

        private void MakeContur()
        {
            var graphics = System.Drawing.Graphics.FromImage(bmp);
            foreach (KeyValuePair<Point, Point> edge in data.GetAllEdges())
            {
                graphics.DrawLine(new Pen(backColor), edge.Key, edge.Value);
            }
            foreach (KeyValuePair<Point, Point> edge in data.GetAllEdges())
            {
                if (edge.Key.Y < edge.Value.Y)
                    DrawLineByModifiedDDA(edge.Key, edge.Value);
                else
                    DrawLineByModifiedDDA(edge.Value, edge.Key);
            }
        }

        public override string ToString()
        {
            return "Со списком ребер и флагом";
        }
    }
}
