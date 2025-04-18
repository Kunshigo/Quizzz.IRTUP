namespace Quizzz.IRTUP.QuestionTypePanels
{
    partial class TrueFalse
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
            tableLayoutPanel1 = new TableLayoutPanel();
            trueBtn = new Button();
            falseBtn = new Button();
            tableLayoutPanel1.SuspendLayout();
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
            questionTxtBox.TabIndex = 12;
            questionTxtBox.TextAlign = HorizontalAlignment.Center;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(trueBtn, 1, 0);
            tableLayoutPanel1.Controls.Add(falseBtn, 0, 0);
            tableLayoutPanel1.Location = new Point(32, 250);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(935, 240);
            tableLayoutPanel1.TabIndex = 13;
            // 
            // trueBtn
            // 
            trueBtn.BackColor = Color.FromArgb(113, 137, 255);
            trueBtn.Dock = DockStyle.Fill;
            trueBtn.FlatStyle = FlatStyle.Flat;
            trueBtn.Font = new Font("Century Gothic", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            trueBtn.Location = new Point(470, 3);
            trueBtn.Name = "trueBtn";
            trueBtn.Padding = new Padding(5);
            trueBtn.Size = new Size(462, 234);
            trueBtn.TabIndex = 2;
            trueBtn.Text = "True";
            trueBtn.UseVisualStyleBackColor = false;
            trueBtn.Click += trueBtn_Click;
            // 
            // falseBtn
            // 
            falseBtn.BackColor = Color.FromArgb(249, 112, 104);
            falseBtn.Dock = DockStyle.Fill;
            falseBtn.FlatStyle = FlatStyle.Flat;
            falseBtn.Font = new Font("Century Gothic", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            falseBtn.Location = new Point(3, 3);
            falseBtn.Name = "falseBtn";
            falseBtn.Padding = new Padding(5);
            falseBtn.Size = new Size(461, 234);
            falseBtn.TabIndex = 1;
            falseBtn.Text = "False";
            falseBtn.UseVisualStyleBackColor = false;
            falseBtn.Click += falseBtn_Click;
            // 
            // TrueFalse
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Controls.Add(questionTxtBox);
            Name = "TrueFalse";
            Size = new Size(999, 513);
            Resize += TrueFalse_Resize;
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public TextBox questionTxtBox;
        private TableLayoutPanel tableLayoutPanel1;
        public Button trueBtn;
        public Button falseBtn;
    }
}
