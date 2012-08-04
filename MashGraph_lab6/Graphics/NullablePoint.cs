using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MashGraph_lab6.Graphics
{
    class NullablePoint
    {
        public int X;
        public int Y;

        public NullablePoint(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public static implicit operator System.Drawing.Point(NullablePoint point)
        {
            if (point != null)
                return new System.Drawing.Point(point.X, point.Y);
            else
                return new System.Drawing.Point();
        }

        public static implicit operator NullablePoint(System.Drawing.Point point)
        {
            return new NullablePoint(point.X, point.Y);
        }
    }
}
