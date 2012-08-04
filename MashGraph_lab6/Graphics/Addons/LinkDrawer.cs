using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MashGraph_lab6.Graphics
{
    class LinkDrawer
    {
        public int POINT_SEARCH_RADIUS = 5;
        public int POINT_LINK_LINE_WIDTH = 3;
        public int POINT_LINK_RECT_WIDTH = 10;
        public System.Drawing.Color POINT_LINK_COLOR = System.Drawing.Color.Red;

        public LinkDrawer() { }

        public void TryDrawLink(System.Drawing.Point currentPoint, System.Drawing.Graphics graphics, PolygonsContainer data)
        {
            NullablePoint linkPoint = isNearVertex(currentPoint, data.GetAllPoints());
            if (linkPoint != null)
            {
                graphics.DrawRectangle(new System.Drawing.Pen(POINT_LINK_COLOR, POINT_LINK_LINE_WIDTH),
                    linkPoint.X - POINT_LINK_RECT_WIDTH / 2,
                    linkPoint.Y - POINT_LINK_RECT_WIDTH / 2,
                    POINT_LINK_RECT_WIDTH, POINT_LINK_RECT_WIDTH);
            }
        }

        public NullablePoint GetLinkPoint(System.Drawing.Point currentPoint, System.Drawing.Graphics graphics, PolygonsContainer data)
        {
            return isNearVertex(currentPoint, data.GetAllPoints());
        }

        private Graphics.NullablePoint isNearVertex(System.Drawing.Point point, List<System.Drawing.Point> pointsList)
        {
            if (pointsList.Count == 0)
                return null;
            int minDistance = int.MaxValue, currentDistance;
            System.Drawing.Point nearestPoint = pointsList[0];
            foreach (System.Drawing.Point currentPoint in pointsList)
            {
                currentDistance = (point.X - currentPoint.X) * (point.X - currentPoint.X)
                 + (point.Y - currentPoint.Y) * (point.Y - currentPoint.Y);
                if (currentDistance < minDistance)
                {
                    minDistance = currentDistance;
                    nearestPoint = currentPoint;
                }
            }

            if (minDistance <= POINT_SEARCH_RADIUS * POINT_SEARCH_RADIUS)
                return nearestPoint;
            else
                return null;
        }
    }
}
