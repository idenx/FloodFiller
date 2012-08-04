
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MashGraph_lab6
{
    struct FloodFillContext
    {
        public System.Drawing.Bitmap bitmap;
        public PolygonsContainer data;
        public System.Drawing.Color borderColor, fillColor, backColor;
        public Graphics.NullablePoint FillStartPoint;

        public FloodFillContext(System.Drawing.Bitmap bitmap, PolygonsContainer data, Graphics.NullablePoint FillStartPoint,
            System.Drawing.Color borderColor, System.Drawing.Color fillColor, System.Drawing.Color backColor)
        {
            this.bitmap = bitmap;
            this.data = data;
            this.FillStartPoint = FillStartPoint;
            this.borderColor = borderColor;
            this.fillColor = fillColor;
            this.backColor = backColor;
        }
    }
}
