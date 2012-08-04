using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using MashGraph_lab6.Graphics;

namespace MashGraph_lab6.Tests
{
    class CurrentTester
    {
        public event EventHandler TestsEnded;

        private Graphics.FloodFillDrawer floodFiller = null;
        private FloodFillContext context;
        private PartitionDrawer partitioner;

        private int currentAlgorithm;
        private int algorithmsCount;
        private PerfCounter perfCounter = new PerfCounter();
        private float[] testResults;
        public float[] Results { get { return testResults; } }

        public CurrentTester(FloodFillContext context, PartitionDrawer partitioner)
        {
            Initialize(context, partitioner);
            CreateFloodFiller();
            algorithmsCount = floodFiller.strategiesList.Count;
            testResults = new float[algorithmsCount];
        }

        public void RefreshData(FloodFillContext context, PartitionDrawer partitioner)
        {
            Initialize(context, partitioner);
        }

        private void Initialize(FloodFillContext context, PartitionDrawer partitioner)
        {
            this.context = context;
            this.context.bitmap = context.bitmap.Clone() as Bitmap;
            this.partitioner = partitioner;
        }

        public void BeginTest()
        {
            currentAlgorithm = 0;
            TestCurrentAlgorithm();
        }

        private void TestCurrentAlgorithm()
        {
            floodFiller.floodFillerStrategy = floodFiller.strategiesList[currentAlgorithm];
            if (floodFiller.floodFillerStrategy is FloodFillers.FloodFillerWithEdgesAndPartition)
                (floodFiller.floodFillerStrategy as FloodFillers.FloodFillerWithEdgesAndPartition).SetPartition(
                    partitioner.partitionBegin, partitioner.partitionEnd);
            Bitmap NotFilledBitmap = context.bitmap.Clone() as Bitmap;
            perfCounter.Start();
            floodFiller.FloodFill(NotFilledBitmap, context.fillColor, context.borderColor, context.backColor, context.FillStartPoint);
        }

        private void NextAlgorithm(object obj, EventArgs e)
        {
            perfCounter.Stop();
            testResults[currentAlgorithm++] = perfCounter.TotalSeconds;
            perfCounter.Reset();
            if (currentAlgorithm == algorithmsCount)
            {
                if (TestsEnded != null)
                    TestsEnded(this, null);
            }
            else
            {
                TestCurrentAlgorithm();
            }

        }

        private void CreateFloodFiller()
        {
            floodFiller = new Graphics.FloodFillDrawer(context.data);
            floodFiller.FloodFillEnd += new EventHandler(NextAlgorithm);
            floodFiller.ExceptionCatched += new Threads.ExceptionHandler(MainForm.HandleExceptions);
            floodFiller.EnableSlowing = false;
        }
    }
}
