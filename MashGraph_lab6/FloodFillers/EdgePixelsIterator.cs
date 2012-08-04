using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MashGraph_lab6.FloodFillers
{
    class EdgePixelsIterator
    {
        private KeyValuePair<Point, Point> edge;
        private KeyValuePair<PointF, PointF> newEdge;
        private int DeltaY;
        private float dx, dy;
        private float currentX, currentY;
        private bool isEnd = false;

        public EdgePixelsIterator()
        {
        }

        public EdgePixelsIterator(KeyValuePair<Point, Point> edge)
        {
            this.edge = edge;
            Intialize();
        }

        public void SetEdge(KeyValuePair<Point, Point> edge)
        {
            this.edge = edge;
            Intialize();
        }

        private void Intialize()
        {
            dx = edge.Value.X - edge.Key.X;
            dy = Math.Sign(edge.Value.Y - edge.Key.Y);
            DeltaY = edge.Value.Y - edge.Key.Y;
            if (DeltaY == 0)
            {
                isEnd = true;
                return;
            }
            if (dx != 0)
            {
                float k = DeltaY / dx;
                float b = edge.Key.Y - k * edge.Key.X;
                newEdge = new KeyValuePair<PointF, PointF>(new PointF((edge.Key.Y + 0.5F - b) / k, edge.Key.Y + 0.5F),
                    new PointF((edge.Value.Y + 0.5F - b) / k, edge.Value.Y + 0.5F));
                DeltaY = (int)(newEdge.Value.Y - newEdge.Key.Y);
                dx = newEdge.Value.X - newEdge.Key.X;
                dx /= Math.Abs(DeltaY);
            }
            else
            {
                newEdge = new KeyValuePair<PointF, PointF>(new PointF(edge.Key.X, edge.Key.Y + 0.5F),
                    new PointF(edge.Value.X, edge.Value.Y + 0.5F));
            }
            currentX = newEdge.Key.X;
            currentY = newEdge.Key.Y;
        }

        public bool End()
        {
            if (isEnd)
                return true;
            else
                return Math.Abs(currentY - newEdge.Key.Y) > Math.Abs(DeltaY);
        }

        public void Next()
        {
            currentY += dy;
            currentX += dx;
        }

        public PointF Current()
        {
            if ((currentY > edge.Key.Y && currentY < edge.Value.Y) || (currentY < edge.Key.Y && currentY > edge.Value.Y))
                return new PointF(currentX, currentY);
            else
                return new PointF();
        }
    }
}
