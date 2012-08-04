using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MashGraph_lab6
{
    class PolygonsContainer
    {
        private List<Point> points = new List<Point>();
        private List<KeyValuePair<Point, Point>> edges = new List<KeyValuePair<Point, Point>>();
        private bool isAddingLocked = false;
        private bool _NextPolygon = false;

        public PolygonsContainer() { }

        public void AddPoint(Point point)
        {
            if (!isAddingLocked)
            {
                points.Add(point);
                int pointsCount = points.Count;
                if (!_NextPolygon)
                {
                    if (pointsCount > 1)
                        edges.Add(new KeyValuePair<Point, Point>(points[pointsCount - 1], points[pointsCount - 2]));
                }
                else
                {
                    _NextPolygon = false;
                }
            }
        }

        public void NextPolygon()
        {
            _NextPolygon = true;
        }

        public void Clear()
        {
            points.Clear();
            edges.Clear();
        }

        public void LockAdding()
        {
            isAddingLocked = true;
        }

        public void UnlockAdding()
        {
            isAddingLocked = false;
        }

        public List<Point> GetAllPoints()
        {
            return points;
        }

        public List<KeyValuePair<Point, Point>> GetAllEdges()
        {
            return edges;
        }

        public Rectangle GetPolygonBounds()
        {
            if (points.Count == 0)
                return new Rectangle();
            int minX = int.MaxValue, maxX = -1;
            int minY = int.MaxValue, maxY = -1;
            foreach (Point point in points)
            {
                if (point.X < minX)
                    minX = point.X;
                if (point.X > maxX)
                    maxX = point.X;
                if (point.Y < minY)
                    minY = point.Y;
                if (point.Y > maxY)
                    maxY = point.Y;
            }
            return new Rectangle(minX, minY, maxX - minX, maxY - minY);
        }
    }
}
