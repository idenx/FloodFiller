using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MashGraph_lab6.Graphics
{
    class FillStartDrawer
    {
        public const int FILL_START_POINT_RADIUS = 5;
        public System.Drawing.Brush FILL_START_POINT_COLOR = System.Drawing.Brushes.Red;
        public Graphics.NullablePoint FillStartPoint = null;


        public void DrawPoint(System.Drawing.Graphics graphics)
        {
            if (FillStartPoint != null)
            {
                graphics.FillEllipse(FILL_START_POINT_COLOR,
                   FillStartPoint.X - FILL_START_POINT_RADIUS,
                   FillStartPoint.Y - FILL_START_POINT_RADIUS,
                   FILL_START_POINT_RADIUS * 2, FILL_START_POINT_RADIUS * 2);
            }
        }
    }
}
