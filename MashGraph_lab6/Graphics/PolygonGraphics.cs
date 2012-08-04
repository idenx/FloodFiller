using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace MashGraph_lab6.Graphics
{
    class PolygonGraphics
    {
        #region class members
        protected PolygonsContainer data = new PolygonsContainer();
        protected DrawContext drawContext;
        protected bool isBitmapLocked = false;
        protected Image image;
        protected LinkDrawer linkDrawer = new LinkDrawer();

        public Color PolygonColor {get {return drawContext.polygonColor;} set {drawContext.polygonColor = value;}}
        public Color BackColor { get { return drawContext.backColor; } set { drawContext.backColor = value; } }

        public bool PerpendicularLinesByShiftEnabled = true;
        public bool VertexLinkingEnabled = true;

        public MouseEventHandler Click;
        public MouseEventHandler MouseMove;
        public MethodInvoker ImageRefresher;
        #endregion

        #region Initialization
        public PolygonGraphics(Image image)
        {
            this.image = image;
            drawContext = new DrawContext(image);
        }

        public void Resize(Image newImage)
        {
            Image savedImage = drawContext.LastBitmap.Clone() as Image;
            this.image = newImage;
            drawContext = new DrawContext(newImage);
            drawContext.graphics.DrawImage(savedImage, 0, 0);
            SaveImageState();
        }
        #endregion

        #region Main Form Events
        public void onClickEvent(MouseEventArgs e)
        {
            if (!isBitmapLocked)
            {
                Point point = new Point(e.X, e.Y);
                if (e.Button == MouseButtons.Left)
                {
                    HandleLeftButtonClick(ref point);
                }
                if (Click != null)
                {
                    Click(this, new MouseEventArgs(e.Button, e.Clicks, point.X, point.Y, e.Delta));
                }
            }
        }

        public void onMouseMoveEvent(MouseEventArgs e)
        {
            if (!isBitmapLocked)
            {
                Redraw();
                if (drawContext.PolygonIsNowDrawing)
                {
                    DrawTempDashLine(new Point(e.X, e.Y));
                }
                if (VertexLinkingEnabled)
                    linkDrawer.TryDrawLink(new Point(e.X, e.Y), drawContext.graphics, data);
                if (MouseMove != null)
                    MouseMove(this, e);
                RefreshImage();
            }
        }

        private void HandleLeftButtonClick(ref Point currentPoint)
        {
            Redraw();
            if (PerpendicularLinesByShiftEnabled)
                currentPoint = CheckForPerpendicularLine(currentPoint);

            bool endOfPolygonDrawing = false;
            if (VertexLinkingEnabled)
            {
                NullablePoint linkPoint = linkDrawer.GetLinkPoint(currentPoint, drawContext.graphics, data);
                if (linkPoint != null)
                {
                    currentPoint = linkPoint;
                    if (drawContext.PolygonIsNowDrawing)
                        endOfPolygonDrawing = true;
                }
            }

            if (!drawContext.PolygonIsNowDrawing)
            {
                drawContext.PolygonIsNowDrawing = true;
                data.NextPolygon();
            }
            else
            {
                if (endOfPolygonDrawing)
                    drawContext.PolygonIsNowDrawing = false;
                drawContext.graphics.DrawLine(drawContext.pen, drawContext.LastX, drawContext.LastY, currentPoint.X, currentPoint.Y);
            }
            data.AddPoint(currentPoint);
            RefreshImage();
            drawContext.LastX = currentPoint.X;
            drawContext.LastY = currentPoint.Y;
            SaveImageState();
        }

        public void Clear()
        {
            drawContext.graphics.Clear(drawContext.backColor);
            data.Clear();
            RefreshImage();
            SaveImageState();
        }
        #endregion

        #region Private Functions
        private Point CheckForPerpendicularLine(Point currentPoint)
        {
            if ((Control.ModifierKeys & Keys.Shift) != Keys.None)
            {
                if (Math.Abs(currentPoint.X - drawContext.LastX) > Math.Abs(currentPoint.Y - drawContext.LastY))
                    return new Point(currentPoint.X, drawContext.LastY);
                else
                    return new Point(drawContext.LastX, currentPoint.Y);
            }
            return currentPoint;
        }

        private void DrawTempDashLine(Point currentPoint)
        {
            if (PerpendicularLinesByShiftEnabled)
                currentPoint = CheckForPerpendicularLine(currentPoint);
            drawContext.graphics.DrawLine(drawContext.dashPen, drawContext.LastX, drawContext.LastY, currentPoint.X, currentPoint.Y);
        }
        #endregion

        #region Small Helpers
        protected void SaveImageState()
        {
            drawContext.LastBitmap = image.Clone() as Bitmap;
        }

        protected void Redraw()
        {
            drawContext.graphics.Clear(drawContext.backColor);
            drawContext.graphics.DrawImage(drawContext.LastBitmap, 0, 0);
        }

        protected void RefreshImage()
        {
            if (ImageRefresher != null)
                ImageRefresher();
        }
        #endregion
    }
}
