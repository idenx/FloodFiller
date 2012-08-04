namespace MashGraph_lab6
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picBox = new System.Windows.Forms.PictureBox();
            this.cmbBox = new System.Windows.Forms.ComboBox();
            this.btnFill = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.checkBoxSlow = new System.Windows.Forms.CheckBox();
            this.colorDlg = new System.Windows.Forms.ColorDialog();
            this.btnColor = new System.Windows.Forms.Button();
            this.checkBoxPartition = new System.Windows.Forms.CheckBox();
            this.txtBoxCircleX = new System.Windows.Forms.TextBox();
            this.lblCircleX = new System.Windows.Forms.Label();
            this.lblCircleY = new System.Windows.Forms.Label();
            this.txtBoxCircleY = new System.Windows.Forms.TextBox();
            this.lblCircleRadius = new System.Windows.Forms.Label();
            this.txtBoxCircleRadius = new System.Windows.Forms.TextBox();
            this.brnDrawCircle = new System.Windows.Forms.Button();
            this.grpBoxCircle = new System.Windows.Forms.GroupBox();
            this.grpBoxFloodFill = new System.Windows.Forms.GroupBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnRemovePartition = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.grpBoxCircle.SuspendLayout();
            this.grpBoxFloodFill.SuspendLayout();
            this.SuspendLayout();
            // 
            // picBox
            // 
            this.picBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.picBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.picBox.Location = new System.Drawing.Point(0, 2);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(799, 638);
            this.picBox.TabIndex = 0;
            this.picBox.TabStop = false;
            // 
            // cmbBox
            // 
            this.cmbBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBox.Location = new System.Drawing.Point(8, 19);
            this.cmbBox.Name = "cmbBox";
            this.cmbBox.Size = new System.Drawing.Size(226, 21);
            this.cmbBox.TabIndex = 1;
            // 
            // btnFill
            // 
            this.btnFill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFill.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnFill.Location = new System.Drawing.Point(8, 52);
            this.btnFill.Name = "btnFill";
            this.btnFill.Size = new System.Drawing.Size(226, 37);
            this.btnFill.TabIndex = 10;
            this.btnFill.Text = "Заполнить";
            this.btnFill.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(8, 199);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(226, 23);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Стереть";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // checkBoxSlow
            // 
            this.checkBoxSlow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxSlow.AutoSize = true;
            this.checkBoxSlow.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxSlow.Location = new System.Drawing.Point(113, 163);
            this.checkBoxSlow.Name = "checkBoxSlow";
            this.checkBoxSlow.Size = new System.Drawing.Size(91, 17);
            this.checkBoxSlow.TabIndex = 6;
            this.checkBoxSlow.Text = "Замедлить";
            this.checkBoxSlow.UseVisualStyleBackColor = true;
            // 
            // btnColor
            // 
            this.btnColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnColor.Location = new System.Drawing.Point(8, 102);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(75, 75);
            this.btnColor.TabIndex = 7;
            this.btnColor.UseVisualStyleBackColor = true;
            // 
            // checkBoxPartition
            // 
            this.checkBoxPartition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxPartition.AutoSize = true;
            this.checkBoxPartition.Location = new System.Drawing.Point(113, 111);
            this.checkBoxPartition.Name = "checkBoxPartition";
            this.checkBoxPartition.Size = new System.Drawing.Size(125, 17);
            this.checkBoxPartition.TabIndex = 8;
            this.checkBoxPartition.Text = "Рисую перегородку";
            this.checkBoxPartition.UseVisualStyleBackColor = true;
            // 
            // txtBoxCircleX
            // 
            this.txtBoxCircleX.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtBoxCircleX.Location = new System.Drawing.Point(6, 42);
            this.txtBoxCircleX.Name = "txtBoxCircleX";
            this.txtBoxCircleX.Size = new System.Drawing.Size(105, 29);
            this.txtBoxCircleX.TabIndex = 9;
            // 
            // lblCircleX
            // 
            this.lblCircleX.AutoSize = true;
            this.lblCircleX.Location = new System.Drawing.Point(6, 23);
            this.lblCircleX.Name = "lblCircleX";
            this.lblCircleX.Size = new System.Drawing.Size(21, 17);
            this.lblCircleX.TabIndex = 10;
            this.lblCircleX.Text = "X:";
            // 
            // lblCircleY
            // 
            this.lblCircleY.AutoSize = true;
            this.lblCircleY.Location = new System.Drawing.Point(133, 23);
            this.lblCircleY.Name = "lblCircleY";
            this.lblCircleY.Size = new System.Drawing.Size(21, 17);
            this.lblCircleY.TabIndex = 12;
            this.lblCircleY.Text = "Y:";
            // 
            // txtBoxCircleY
            // 
            this.txtBoxCircleY.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtBoxCircleY.Location = new System.Drawing.Point(133, 42);
            this.txtBoxCircleY.Name = "txtBoxCircleY";
            this.txtBoxCircleY.Size = new System.Drawing.Size(105, 29);
            this.txtBoxCircleY.TabIndex = 11;
            // 
            // lblCircleRadius
            // 
            this.lblCircleRadius.AutoSize = true;
            this.lblCircleRadius.Location = new System.Drawing.Point(76, 82);
            this.lblCircleRadius.Name = "lblCircleRadius";
            this.lblCircleRadius.Size = new System.Drawing.Size(59, 17);
            this.lblCircleRadius.TabIndex = 14;
            this.lblCircleRadius.Text = "Радиус:";
            // 
            // txtBoxCircleRadius
            // 
            this.txtBoxCircleRadius.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtBoxCircleRadius.Location = new System.Drawing.Point(76, 101);
            this.txtBoxCircleRadius.Name = "txtBoxCircleRadius";
            this.txtBoxCircleRadius.Size = new System.Drawing.Size(105, 29);
            this.txtBoxCircleRadius.TabIndex = 13;
            // 
            // brnDrawCircle
            // 
            this.brnDrawCircle.Location = new System.Drawing.Point(76, 138);
            this.brnDrawCircle.Name = "brnDrawCircle";
            this.brnDrawCircle.Size = new System.Drawing.Size(102, 40);
            this.brnDrawCircle.TabIndex = 15;
            this.brnDrawCircle.Text = "Рисовать";
            this.brnDrawCircle.UseVisualStyleBackColor = true;
            this.brnDrawCircle.Click += new System.EventHandler(this.brnDrawCircle_Click);
            // 
            // grpBoxCircle
            // 
            this.grpBoxCircle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBoxCircle.Controls.Add(this.txtBoxCircleX);
            this.grpBoxCircle.Controls.Add(this.brnDrawCircle);
            this.grpBoxCircle.Controls.Add(this.lblCircleX);
            this.grpBoxCircle.Controls.Add(this.lblCircleRadius);
            this.grpBoxCircle.Controls.Add(this.txtBoxCircleY);
            this.grpBoxCircle.Controls.Add(this.txtBoxCircleRadius);
            this.grpBoxCircle.Controls.Add(this.lblCircleY);
            this.grpBoxCircle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.grpBoxCircle.Location = new System.Drawing.Point(805, 259);
            this.grpBoxCircle.Name = "grpBoxCircle";
            this.grpBoxCircle.Size = new System.Drawing.Size(240, 187);
            this.grpBoxCircle.TabIndex = 16;
            this.grpBoxCircle.TabStop = false;
            this.grpBoxCircle.Text = "Рисование окружности";
            // 
            // grpBoxFloodFill
            // 
            this.grpBoxFloodFill.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBoxFloodFill.Controls.Add(this.btnRemovePartition);
            this.grpBoxFloodFill.Controls.Add(this.cmbBox);
            this.grpBoxFloodFill.Controls.Add(this.btnFill);
            this.grpBoxFloodFill.Controls.Add(this.btnClear);
            this.grpBoxFloodFill.Controls.Add(this.checkBoxPartition);
            this.grpBoxFloodFill.Controls.Add(this.btnColor);
            this.grpBoxFloodFill.Controls.Add(this.checkBoxSlow);
            this.grpBoxFloodFill.Location = new System.Drawing.Point(805, 12);
            this.grpBoxFloodFill.Name = "grpBoxFloodFill";
            this.grpBoxFloodFill.Size = new System.Drawing.Size(240, 241);
            this.grpBoxFloodFill.TabIndex = 17;
            this.grpBoxFloodFill.TabStop = false;
            this.grpBoxFloodFill.Text = "Заполнение многоугольников";
            // 
            // btnTest
            // 
            this.btnTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTest.Location = new System.Drawing.Point(811, 479);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(232, 39);
            this.btnTest.TabIndex = 18;
            this.btnTest.Text = "Сравнение производительности";
            this.btnTest.UseVisualStyleBackColor = true;
            // 
            // btnRemovePartition
            // 
            this.btnRemovePartition.Location = new System.Drawing.Point(157, 134);
            this.btnRemovePartition.Name = "btnRemovePartition";
            this.btnRemovePartition.Size = new System.Drawing.Size(77, 23);
            this.btnRemovePartition.TabIndex = 16;
            this.btnRemovePartition.Text = "Удалить ее";
            this.btnRemovePartition.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 639);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.grpBoxFloodFill);
            this.Controls.Add(this.grpBoxCircle);
            this.Controls.Add(this.picBox);
            this.Name = "MainForm";
            this.Text = "Лаба 6";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.grpBoxCircle.ResumeLayout(false);
            this.grpBoxCircle.PerformLayout();
            this.grpBoxFloodFill.ResumeLayout(false);
            this.grpBoxFloodFill.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picBox;
        private System.Windows.Forms.ComboBox cmbBox;
        private System.Windows.Forms.Button btnFill;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.CheckBox checkBoxSlow;
        private System.Windows.Forms.ColorDialog colorDlg;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.CheckBox checkBoxPartition;
        private System.Windows.Forms.TextBox txtBoxCircleX;
        private System.Windows.Forms.Label lblCircleX;
        private System.Windows.Forms.Label lblCircleY;
        private System.Windows.Forms.TextBox txtBoxCircleY;
        private System.Windows.Forms.Label lblCircleRadius;
        private System.Windows.Forms.TextBox txtBoxCircleRadius;
        private System.Windows.Forms.Button brnDrawCircle;
        private System.Windows.Forms.GroupBox grpBoxCircle;
        private System.Windows.Forms.GroupBox grpBoxFloodFill;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnRemovePartition;
    }
}

