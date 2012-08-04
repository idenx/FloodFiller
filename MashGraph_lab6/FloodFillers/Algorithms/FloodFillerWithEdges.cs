using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MashGraph_lab6.FloodFillers
{
    class FloodFillerWithEdges : AbstractFloodFiller
    {
        public override void FloodFill(FloodFillContext context)
        {
            Initialize(context);

            PointF currentPoint;
            int currentY;
            Rectangle bounds = data.GetPolygonBounds();
            int currentColor;
            int xMin = bounds.Left, xMax = bounds.Right;
            foreach (KeyValuePair<Point, Point> edge in data.GetAllEdges())
            {
                for (EdgePixelsIterator iterator = new EdgePixelsIterator(edge); !iterator.End(); iterator.Next())
                {
                    currentPoint = iterator.Current();
                    if (!currentPoint.IsEmpty)
                    {
                        currentY = (int)(currentPoint.Y - 0.5);
                        for (int currentX = (int)Math.Ceiling(currentPoint.X); currentX < xMax; ++currentX)
                        {
                            currentColor = GetPixel(currentX, currentY);
                            if (currentColor != aBorderColor)
                            {
                                if (currentColor == aBackColor)
                                    SetPixel(currentX, currentY, fillColor);
                                else
                                    SetPixel(currentX, currentY, backColor);
                            }
                        }
                    }
                }
            }

        }

        public override string ToString()
        {
            return "По ребрам";
        }
    }
}
