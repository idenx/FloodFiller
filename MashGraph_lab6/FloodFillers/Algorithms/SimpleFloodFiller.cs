using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MashGraph_lab6.FloodFillers
{
    class SimpleFloodFiller : AbstractFloodFiller
    {
        public override void FloodFill(FloodFillContext context)
        {
            Initialize(context);
            FloodFillHelper(context.FillStartPoint.X, context.FillStartPoint.Y);
        }

        private void FloodFillHelper(int x, int y)
        {
            int CurrentPixel = GetPixel(x, y);
            if (CurrentPixel != aBorderColor && CurrentPixel != aFillColor)
            {
                SetPixel(x, y);
                FloodFillHelper(x - 1, y);
                FloodFillHelper(x + 1, y);
                FloodFillHelper(x, y - 1);
                FloodFillHelper(x, y + 1);
            }
        }

        public override string ToString()
        {
            return "Простой затравочный";
        }
    }
}
