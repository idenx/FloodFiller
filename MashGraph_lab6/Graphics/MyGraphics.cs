using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace MashGraph_lab6
{
    class MyGraphics : Graphics.PolygonGraphics
    {
        #region Class Members
        public event EventHandler FloodFillEndEvent;
        public event EventHandler TestsEndEvent;

        private Tests.CurrentTester tester = null;
        private Graphics.FillStartDrawer fillStartDrawer = new Graphics.FillStartDrawer();
        private Graphics.FloodFillDrawer floodFillDrawer = null;
        private Graphics.PartitionDrawer partitionDrawer = new Graphics.PartitionDrawer();
        public bool IsNowPartitionDrawing { 
            get { return partitionDrawer.IsNowPartitionDrawing; }
            set { partitionDrawer.IsNowPartitionDrawing = value; if (value) data.LockAdding(); else data.UnlockAdding(); } 
        }

        public bool EnableSlowing {
            get { if (floodFillDrawer == null) CreateFloodFiller(); return floodFillDrawer.EnableSlowing; }
            set { floodFillDrawer.EnableSlowing = value; if (floodFillDrawer == null) CreateFloodFiller(); }
        }
        #endregion

        #region Constructor
        public MyGraphics(Image image)
            : base(image)
        {
            Click += new MouseEventHandler(MouseEventsHandler);
            MouseMove += new MouseEventHandler((obj, e) => { fillStartDrawer.DrawPoint(drawContext.graphics);});
        }
        #endregion

        #region Events
        private void MouseEventsHandler(object obj, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Right:
                    if ((Control.ModifierKeys & Keys.Alt) != Keys.None)
                        RemoveLastFloodFill(e);
                    else
                        DrawFloodFillStartPoint(e);
                    break;
                case MouseButtons.Middle:
                    RemoveLastFloodFill(e);
                    break;
                case MouseButtons.Left:
                    TryDrawPartition(e);
                    break;
            }   
        }
        #endregion

        #region FloodFill
        private void RemoveLastFloodFill(MouseEventArgs e)
        {
            if (drawContext.LastBitmap != null && floodFillDrawer.LastBitmap != null)
            {
                int currentPixel = drawContext.LastBitmap.GetPixel(e.X, e.Y).ToArgb();
                if (currentPixel != Color.White.ToArgb() && currentPixel != drawContext.polygonColor.ToArgb()
                    && floodFillDrawer.LastBitmap.GetPixel(e.X, e.Y).ToArgb() != currentPixel)
                {
                    drawContext.LastBitmap = floodFillDrawer.LastBitmap.Clone() as Bitmap;
                    RefreshImage();
                }
            }
        }

        private void CreateFloodFiller()
        {
            floodFillDrawer = new Graphics.FloodFillDrawer(data, ImageRefresher);
            floodFillDrawer.FloodFillEnd += new EventHandler(OnFloodFillEnd);
            floodFillDrawer.FloodFillEnd += FloodFillEndEvent;
            floodFillDrawer.ExceptionCatched += new Threads.ExceptionHandler(MainForm.HandleExceptions);
        }

        public void FloodFill(Color fillColor)
        {
            isBitmapLocked = true;
            if (floodFillDrawer == null)
                CreateFloodFiller();
            Redraw();
            floodFillDrawer.LastBitmap = drawContext.LastBitmap.Clone() as Bitmap;
            if (floodFillDrawer.floodFillerStrategy is FloodFillers.FloodFillerWithEdgesAndPartition)
                (floodFillDrawer.floodFillerStrategy as FloodFillers.FloodFillerWithEdgesAndPartition).SetPartition(
                    partitionDrawer.partitionBegin, partitionDrawer.partitionEnd);
            floodFillDrawer.FloodFill(image, fillColor, PolygonColor, BackColor, fillStartDrawer.FillStartPoint);
        }

        public void CancelFloodFill()
        {
            floodFillDrawer.CancelFloodFill();
        }

        private void OnFloodFillEnd(Object sender, EventArgs e)
        {
            if (ImageRefresher != null)
                ImageRefresher();
            SaveImageState();
            isBitmapLocked = false;
        }
        #endregion

        #region Addons
        private void DrawFloodFillStartPoint(MouseEventArgs e)
        {
            Redraw();
            fillStartDrawer.FillStartPoint = new Graphics.NullablePoint(e.X, e.Y);
            fillStartDrawer.DrawPoint(drawContext.graphics);
            if (ImageRefresher != null)
                ImageRefresher();
        }

        private void TryDrawPartition(MouseEventArgs e)
        {
            if (floodFillDrawer == null)
                CreateFloodFiller();
            if (partitionDrawer.HandlePoint(new Point(e.X, e.Y),
                System.Drawing.Graphics.FromImage(drawContext.LastBitmap), drawContext.LastBitmap))
            {
                drawContext.PolygonIsNowDrawing = false;
            }
        }

        public void RemovePartition()
        {
            Bitmap lastImage = partitionDrawer.LoadLastImage() as Bitmap;
            if (lastImage != null)
            {
                drawContext.LastBitmap = lastImage.Clone() as Bitmap;
                Redraw();
                RefreshImage();
            }
        }

        #endregion

        #region Tests
        public void BeginTest(Color testColorToFill)
        {
            Bitmap bmp = partitionDrawer.LoadLastImage() as Bitmap;
            if (bmp == null)
                bmp = drawContext.LastBitmap;
            FloodFillContext context = new FloodFillContext(bmp as Bitmap, data,
                    fillStartDrawer.FillStartPoint, drawContext.polygonColor, testColorToFill, drawContext.backColor);
            if (tester == null)
            {
                tester = new Tests.CurrentTester(context, partitionDrawer);
                if (TestsEndEvent != null)
                    tester.TestsEnded += new EventHandler(TestsEndEvent);
            }
            else
                tester.RefreshData(context, partitionDrawer);

            tester.BeginTest();
        }

        public float[] GetTestResults()
        {
            return tester.Results;
        }

        #endregion

        #region Other
        public String[] GetAlgorithmsNames()
        {
            if (floodFillDrawer == null)
                CreateFloodFiller();
            String[] names = new String[floodFillDrawer.strategiesList.Count];
            for (int i = 0; i < floodFillDrawer.strategiesList.Count; ++i)
                names[i] = floodFillDrawer.strategiesList[i].ToString();
            return names;
        }

        public void SetAlgorithm(int index)
        {
            floodFillDrawer.floodFillerStrategy = floodFillDrawer.strategiesList[index];
        }

        public void DrawCircle(int x, int y, int radius)
        {
            Redraw();
            drawContext.graphics.DrawEllipse(drawContext.pen, x - radius, y - radius, radius * 2, radius * 2);
            SaveImageState();
            RefreshImage();
        }

        new public void Resize(Image newImage)
        {
            base.Resize(newImage);
            Bitmap bmp = new Bitmap(newImage.Width, newImage.Height);
            System.Drawing.Graphics.FromImage(bmp).DrawImage(floodFillDrawer.LastBitmap, 0, 0);
            floodFillDrawer.LastBitmap = bmp;
        }

        new public void Clear()
        {
            base.Clear();
            partitionDrawer.Clear();
        }
        #endregion
    }
}
