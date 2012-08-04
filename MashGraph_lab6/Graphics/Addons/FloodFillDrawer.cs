using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace MashGraph_lab6.Graphics
{
    class FloodFillDrawer
    {
        public event EventHandler FloodFillEnd;
        public event Threads.ExceptionHandler ExceptionCatched;
        public AbstractFloodFiller floodFillerStrategy { set; get; }
        public readonly List<AbstractFloodFiller> strategiesList = new List<AbstractFloodFiller>();
        public Bitmap LastBitmap = null;

        public bool EnableSlowing
        {
            get { return floodFillerStrategy.SlowMode; }
            set { _EnableSlowing = value; floodFillerStrategy.SlowMode = _EnableSlowing; }
        }

        private bool _EnableSlowing = false;
        private Threads.BackWorker worker = null;
        private PolygonsContainer data;
        private MethodInvoker ImageRefresher;

        public FloodFillDrawer(PolygonsContainer data, MethodInvoker ImageRefresher = null)
        {
            this.ImageRefresher = ImageRefresher;
            this.data = data;
            InitializeFloodFillStrategies();
            floodFillerStrategy = strategiesList[0];
        }

        private void InitializeFloodFillStrategies()
        {
            strategiesList.Add(new FloodFillers.SimpleFloodFiller());
            strategiesList.Add(new FloodFillers.LinewiseFloodfiller());
            strategiesList.Add(new FloodFillers.AELfloodfiller());
            strategiesList.Add(new FloodFillers.ListFloodFillerWithFlag());
            strategiesList.Add(new FloodFillers.FloodFillerWithEdges());
            strategiesList.Add(new FloodFillers.FloodFillerWithEdgesAndPartition());
        }

        public void FloodFill(Image currentImage, Color fillColor, Color polygonColor, Color backColor, Point fillStartPoint)
        {
            LastBitmap = currentImage.Clone() as Bitmap;
            FloodFillContext context = new FloodFillContext(currentImage as Bitmap, data, fillStartPoint, polygonColor, fillColor, backColor);
            CreateWorker(context.bitmap);
            floodFillerStrategy.SlowMode = _EnableSlowing;
            worker.RunWorkerAsync(context);                
        }

        public void CancelFloodFill()
        {
            worker.CancelAsync();
        }

        private void CreateWorker(Image image)
        {
            if (worker == null)
            {
                worker = new Threads.BackWorker(floodFillerStrategy.NEEDABLE_STACK_SIZE);
                worker.DoWork += new EventHandler((object obj, EventArgs e) => { if (floodFillerStrategy != null) floodFillerStrategy.FloodFill((FloodFillContext)obj); });
                if (FloodFillEnd != null)
                    worker.RunWorkerCompleted += new EventHandler(FloodFillEnd);
                worker.ProgressChanged += new EventHandler(delegate(Object sender, EventArgs e)
                {
                    lock (image)
                    {
                        if (ImageRefresher != null)
                            ImageRefresher();
                    }
                });
                if (ExceptionCatched != null)
                    worker.ExceptionCatched += new Threads.ExceptionHandler(ExceptionCatched);
            }
        }
    }
}
