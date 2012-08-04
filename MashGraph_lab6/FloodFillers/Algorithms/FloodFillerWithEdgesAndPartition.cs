using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MashGraph_lab6.FloodFillers
{
    class FloodFillerWithEdgesAndPartition : AbstractFloodFiller
    {
        private Point partitionBegin, partitionEnd;

        public override void FloodFill(FloodFillContext context)
        {
            Initialize(context);

            PointF currentPoint;
            int currentY;
            Rectangle bounds = data.GetPolygonBounds();
            int currentColor;
            int xMin = bounds.Left, xMax = bounds.Right;
            int yMin = bounds.Top, yMax = bounds.Bottom;
            float K = GetPartitionLineCoefK(), B = GetPartitionLineCoefB();
            int startX, endX;

            foreach (KeyValuePair<Point, Point> edge in data.GetAllEdges())
            {
                for (EdgePixelsIterator iterator = new EdgePixelsIterator(edge); !iterator.End(); iterator.Next())
                {
                    currentPoint = iterator.Current();
                    if (!currentPoint.IsEmpty)
                    {
                        currentY = (int)(currentPoint.Y - 0.5);
                        if (K != float.MaxValue)
                        {
                            if ((K * currentPoint.X + B - currentPoint.Y) * (K * xMin + B - yMin) > 0)
                            {
                                startX = (int)Math.Ceiling(currentPoint.X);
                                endX = (int)Math.Ceiling((currentPoint.Y - B) / K);
                            }
                            else
                            {
                                startX = (int)Math.Ceiling((currentPoint.Y - B) / K);
                                endX = (int)Math.Ceiling(currentPoint.X);
                            }
                        }
                        else
                        {
                            if (currentPoint.X < partitionBegin.X)
                            {
                                startX = (int)Math.Ceiling(currentPoint.X);
                                endX = partitionBegin.X;
                            }
                            else
                            {
                                startX = partitionBegin.X;
                                endX = (int)Math.Ceiling(currentPoint.X);
                            }
                        }
                        for (int currentX = startX; currentX < endX; ++currentX)
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
            System.Drawing.Graphics.FromImage(bmp).DrawLine(new Pen(fillColor), partitionBegin, partitionEnd);
        }

        private float GetPartitionLineCoefK()
        {
            if (partitionEnd.X == partitionBegin.X)
                return float.MaxValue;
            return (float)(partitionEnd.Y - partitionBegin.Y) / (partitionEnd.X - partitionBegin.X);
        }

        private float GetPartitionLineCoefB()
        {
            float K1 = GetPartitionLineCoefK();
            float B1 = partitionBegin.Y - partitionBegin.X * K1;
            float K2 = GetPartitionLineCoefK();
            float B2 = partitionEnd.Y - partitionEnd.X * K2;
            return B2;
        }

        public void SetPartition(Point partitionBegin, Point partitionEnd)
        {
            this.partitionBegin = partitionBegin;
            this.partitionEnd = partitionEnd;
        }

        public override string ToString()
        {
            return "По ребрам с перегородкой";
        }
    }
}
