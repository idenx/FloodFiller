using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MashGraph_lab6.FloodFillers
{
    class AELfloodfiller : AbstractFloodFiller
    {
        int monitorHeight = System.Windows.Forms.SystemInformation.PrimaryMonitorSize.Height;
        List<float>[] yRows;
        public override void FloodFill(FloodFillContext context)
        {
            Initialize(context);
            yRows = new List<float>[monitorHeight];
            MakeAndSortAEL(yRows);
            Draw();
        }

        private void Draw()
        {
            List<float> currentList;
            for (int currentY = 0; currentY < monitorHeight; ++currentY)
            {
                currentList = yRows[currentY];
                if (currentList != null)
                {
                    for (int i = 0; i < currentList.Count - 1; i += 2)
                    {
                        int startX = (int)Math.Ceiling(currentList[i]);

                        for (int currentX = startX; currentX <= Math.Floor(currentList[i + 1]); ++currentX)
                        {
                            if (GetPixel(currentX, currentY) != aBorderColor)
                                SetPixel(currentX, currentY);
                        }
                    }
                }
            }
        }

        private void MakeAndSortAEL(List<float>[] yRows)
        {
            PointF currentPoint;
            int currentY;

            foreach (KeyValuePair<Point, Point> edge in data.GetAllEdges())
            {
                for (EdgePixelsIterator iterator = new EdgePixelsIterator(edge); !iterator.End(); iterator.Next())
                {
                    currentPoint = iterator.Current();
                    if (!currentPoint.IsEmpty)
                    {
                        currentY = (int)(currentPoint.Y - 0.5);
                        if (yRows[currentY] == null)
                            yRows[currentY] = new List<float>();
                        yRows[currentY].Add(currentPoint.X);
                    }
                }
            }

            foreach (List<float> currentList in yRows)
            {
                if (currentList != null)
                    currentList.Sort(new Comparison<float>((float first, float second) =>
                    {
                        if (first > second)
                            return 1;
                        else
                            if (first == second)
                                return 0;
                            else
                                return -1;
                    }));
            }
        }

        public override string ToString()
        {
            return "С упорядоченным списком ребер";
        }
    }
}
