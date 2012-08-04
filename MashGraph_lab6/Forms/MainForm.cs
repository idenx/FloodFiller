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
    public partial class MainForm : Form
    {
        MyGraphics myGraphics;
        KeyValuePair<String, String> FillButtonTexts;
        
        public MainForm()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            #region Mygraphics
            picBox.Image = new Bitmap(picBox.Width, picBox.Height);
            myGraphics = new MyGraphics(picBox.Image);
            myGraphics.ImageRefresher += new MethodInvoker(() => picBox.Refresh());
            myGraphics.FloodFillEndEvent += new EventHandler((obj, e) =>
            { 
                btnFill.Text = FillButtonTexts.Key;
                btnClear.Enabled = true;
                cmbBox.Enabled = true;
            });
            String[] Algorithms = myGraphics.GetAlgorithmsNames();
            WaitDialog waitDlg = new WaitDialog();
            myGraphics.TestsEndEvent += new EventHandler((obj, e) =>
            {
                waitDlg.Close();
                new TimeResults(myGraphics.GetTestResults(), Algorithms).ShowDialog();
            });
            #endregion

            #region Buttons And ColorDialog
            FillButtonTexts = new KeyValuePair<String, String>("Заполнить", "Отмена");
            btnFill.Text = FillButtonTexts.Key;
            colorDlg.Color = Color.Red;
            btnColor.BackColor = colorDlg.Color;
            btnFill.Click += new EventHandler(btnFill_Click);
            btnColor.Click += new EventHandler((obj, e) => {colorDlg.ShowDialog(); btnColor.BackColor = colorDlg.Color;});
            btnClear.Click += new EventHandler((obj, e) => myGraphics.Clear());
            btnTest.Click += new EventHandler((obj, e) => { myGraphics.BeginTest(colorDlg.Color); waitDlg.ShowDialog(); });
            btnRemovePartition.Click += new EventHandler((obj, e) => myGraphics.RemovePartition());
            #endregion

            #region PictureBox
            picBox.MouseClick += new MouseEventHandler((obj, e) => myGraphics.onClickEvent(e));
            picBox.MouseMove += new MouseEventHandler((obj, e) => myGraphics.onMouseMoveEvent(e));
            #endregion

            #region CheckBoxes
            checkBoxSlow.CheckedChanged += new EventHandler((obj, e) => myGraphics.EnableSlowing = checkBoxSlow.Checked);
            checkBoxPartition.CheckedChanged += new EventHandler((obj, e) => myGraphics.IsNowPartitionDrawing = checkBoxPartition.Checked);
            #endregion

            #region ComboBox
            cmbBox.Items.AddRange(myGraphics.GetAlgorithmsNames());
            cmbBox.SelectedIndex = 0;
            cmbBox.SelectedIndexChanged += new EventHandler((obj, e) => myGraphics.SetAlgorithm(cmbBox.SelectedIndex));
            #endregion

            #region Form
            this.SizeChanged += new EventHandler((obj, e) =>
                { picBox.Image = new Bitmap(picBox.Width, picBox.Height); 
                  myGraphics.Resize(picBox.Image); });
            #endregion

            #region TextBoxes
            txtBoxCircleX.Text = "500";
            txtBoxCircleY.Text = "350";
            txtBoxCircleRadius.Text = "300";
            #endregion
        }

        private void btnFill_Click(object sender, EventArgs e)
        {
            if (btnFill.Text == FillButtonTexts.Key)
            {
                btnFill.Enabled = false;
                btnClear.Enabled = false;
                cmbBox.Enabled = false;
                myGraphics.FloodFill(colorDlg.Color);
                btnFill.Text = FillButtonTexts.Value;
                btnFill.Enabled = true;
            }
            else
            {
                btnFill.Enabled = false;
                myGraphics.CancelFloodFill();
                btnFill.Text = FillButtonTexts.Key;
                btnFill.Enabled = true;
            }
        }

        private void brnDrawCircle_Click(object sender, EventArgs e)
        {
            int X, Y, Radius;
            bool correctInput = int.TryParse(txtBoxCircleX.Text, out X);
            correctInput &= int.TryParse(txtBoxCircleY.Text, out Y);
            correctInput &= int.TryParse(txtBoxCircleRadius.Text, out Radius);
            if (correctInput)
            {
                myGraphics.DrawCircle(X, Y, Radius);
            }
            else
            {
                MessageBox.Show("Некорректный ввод данных для рисования окружности!");
            }
        }

        public static void HandleExceptions(Exception e)
        {
            // включать только при дебагах и вырубать при сдаче:)
            //MessageBox.Show("Произошла непредвиденная ошибка!\n" + e.Message);
        }
    }
}
