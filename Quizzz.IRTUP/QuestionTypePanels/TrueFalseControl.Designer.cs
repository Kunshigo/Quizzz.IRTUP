namespace Quizzz.IRTUP.QuestionTypePanels
{
    partial class TrueFalseControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            questionTxtBox = new TextBox();
            pictureBox1 = new PictureBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel2 = new Panel();
            trueBtn = new Button();
            panel1 = new Panel();
            falseBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // questionTxtBox
            // 
            questionTxtBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            questionTxtBox.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            questionTxtBox.Location = new Point(32, 14);
            questionTxtBox.Multiline = true;
            questionTxtBox.Name = "questionTxtBox";
            questionTxtBox.Size = new Size(935, 46);
            questionTxtBox.TabIndex = 11;
            questionTxtBox.TextAlign = HorizontalAlignment.Center;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.Location = new Point(358, 70);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(285, 150);
            pictureBox1.TabIndex = 12;
            pictureBox1.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 470F));
            tableLayoutPanel1.Controls.Add(panel2, 1, 0);
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Location = new Point(32, 250);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(935, 241);
            tableLayoutPanel1.TabIndex = 13;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(trueBtn);
            panel2.Location = new Point(468, 3);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(10);
            panel2.Size = new Size(459, 235);
            panel2.TabIndex = 17;
            // 
            // trueBtn
            // 
            trueBtn.BackColor = Color.FromArgb(113, 137, 255);
            trueBtn.Dock = DockStyle.Left;
            trueBtn.FlatStyle = FlatStyle.Flat;
            trueBtn.Font = new Font("Century Gothic", 14.25F, FontStyle.Bold);
            trueBtn.Location = new Point(10, 10);
            trueBtn.Name = "trueBtn";
            trueBtn.Padding = new Padding(5);
            trueBtn.Size = new Size(436, 215);
            trueBtn.TabIndex = 0;
            trueBtn.Text = "True";
            trueBtn.UseVisualStyleBackColor = false;
            trueBtn.Click += trueBtn_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(falseBtn);
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(10);
            panel1.Size = new Size(459, 235);
            panel1.TabIndex = 16;
            // 
            // falseBtn
            // 
            falseBtn.BackColor = Color.FromArgb(249, 112, 104);
            falseBtn.Dock = DockStyle.Left;
            falseBtn.FlatStyle = FlatStyle.Flat;
            falseBtn.Font = new Font("Century Gothic", 14.25F, FontStyle.Bold);
            falseBtn.Location = new Point(10, 10);
            falseBtn.Name = "falseBtn";
            falseBtn.Padding = new Padding(5);
            falseBtn.Size = new Size(436, 215);
            falseBtn.TabIndex = 0;
            falseBtn.Text = "False";
            falseBtn.UseVisualStyleBackColor = false;
            falseBtn.Click += falseBtn_Click;
            // 
            // TrueFalseControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Controls.Add(pictureBox1);
            Controls.Add(questionTxtBox);
            Name = "TrueFalseControl";
            Size = new Size(999, 513);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public TextBox questionTxtBox;
        private PictureBox pictureBox1;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel2;
        public Button trueBtn;
        private Panel panel1;
        public Button falseBtn;
    }
}
