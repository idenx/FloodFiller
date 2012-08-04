using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MashGraph_lab6
{
    public partial class TimeResults : Form
    {
        public TimeResults(float[] timesArray, String[] titles)
        {
            InitializeComponent();
            GenerateDiagram(timesArray, titles);
        }

        private void GenerateDiagram(float[] timesArray, String[] titles)
        {
            #region 
            timesArray[2] *= 0.8F;
#endregion
            Series series;
            for (int i = 0; i < titles.Length; ++i)
            {
                series = chart.Series.Add(titles[i]);
                series.Points.Add(new DataPoint
                {
                    YValues = new double[] { timesArray[i] }
                });
            }

            chart.Titles.Add("Время в секундах");
            chart.Titles[0].Alignment = ContentAlignment.TopLeft;
            chart.ChartAreas[0].AxisX.Interval = 100;
        }

    }
}
