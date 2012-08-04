using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MashGraph_lab6
{
    public partial class WaitDialog : Form
    {
        Timer timer;
        public WaitDialog()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Tick += new EventHandler((obj, e) => {progressBar1.Value = (progressBar1.Value + 10) % 100; });
            timer.Interval = 100;
        }

        new public void Close()
        {
            timer.Stop();
            base.Close();
        }
    }
}
