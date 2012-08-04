using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace MashGraph_lab6.FloodFillers
{
    class LinewiseFloodfiller : AbstractFloodFiller
    {
        private Stack<Point> stack = new Stack<Point>();

        public override void FloodFill(FloodFillContext context)
        {
            Initialize(context);
            stack.Push(context.FillStartPoint);
            FloodFillHelper();
        }

        private void FloodFillHelper()
        {
            Point currentPixel;
            int aCurrentColor;
            int X, Y;
            int tempX;
            int xRight, xLeft;
            bool Flag;

            while (stack.Count != 0)
            {
                currentPixel = stack.Pop();
                tempX = X = currentPixel.X;
                Y = currentPixel.Y;

                do
                {
                    SetPixel(X, Y);
                    ++X;
                    aCurrentColor = GetPixel(X, Y);
                } while (aCurrentColor != aBorderColor);
                xRight = X - 1;

                X = tempX;
                do
                {
                    SetPixel(X, Y);
                    --X;
                    aCurrentColor = GetPixel(X, Y);
                } while (aCurrentColor != aBorderColor);
                xLeft = ++X;

                ++Y;
                for (int i = 0; i < 2; ++i)
                {
                    X = xLeft;
                    if (i == 1)
                        Y -= 2;
                    while (X <= xRight)
                    {
                        Flag = false;
                        aCurrentColor = GetPixel(X, Y);
                        while (aCurrentColor != aBorderColor && aCurrentColor != aFillColor && X <= xRight)
                        {
                            Flag = true;
                            ++X;
                            aCurrentColor = GetPixel(X, Y);
                        }

                        if (Flag)
                        {
                            if (X == xRight && aCurrentColor != aBorderColor && aBorderColor != aFillColor)
                                stack.Push(new Point(X, Y));
                            else
                                stack.Push(new Point(X - 1, Y));
                            Flag = false;
                        }

                        tempX = X;
                        aCurrentColor = GetPixel(X, Y);
                        while ((aCurrentColor == aBorderColor || aCurrentColor == aFillColor) && X <= xRight)
                        {
                            ++X;
                            aCurrentColor = GetPixel(X, Y);
                        }

                        if (X == tempX)
                            ++X;
                    }
                }           
            }
        }

        public override string ToString()
        {
            return "Построчный затравочный";
        }
    }
}