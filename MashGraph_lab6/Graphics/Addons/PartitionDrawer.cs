using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MashGraph_lab6.Graphics
{
    class PartitionDrawer
    {
        public Point partitionBegin, partitionEnd;
        public Color partitionColor;
        public bool IsNowPartitionDrawing = false;

        private bool isBeginPointSet = false;
        private Bitmap LastBitmap = null;
        private bool isPartitionExists = false;

        public PartitionDrawer()
        {
            partitionColor = Color.Green;
        }

        public bool HandlePoint(Point point, System.Drawing.Graphics graphics, Image image)
        {
            if (IsNowPartitionDrawing)
            {
                if (!isPartitionExists)
                {
                    isPartitionExists = true;
                    LastBitmap = image.Clone() as Bitmap;
                }

                if (!isBeginPointSet)
                {
                    partitionBegin.X = point.X;
                    partitionBegin.Y = point.Y;
                    isBeginPointSet = true;
                }
                else
                {
                    partitionEnd.X = point.X;
                    partitionEnd.Y = point.Y;
                    graphics.DrawLine(new Pen(partitionColor), partitionBegin, partitionEnd);
                    isBeginPointSet = false;
                    return true;
                }
            }
            return false;
        }

        public Image LoadLastImage()
        {
            isBeginPointSet = false;
            isPartitionExists = false;
            return LastBitmap;
        }

        public void Clear()
        {
            isBeginPointSet = false;
            isPartitionExists = false;
        }
    }
}
