namespace Quizzz.IRTUP.QuestionTypePanels
{
    partial class miniToF
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
            tableLayoutPanel1 = new TableLayoutPanel();
            blue = new Panel();
            red = new Panel();
            slideNumberLabel = new AntdUI.Label();
            tableLayoutPanel1.SuspendLayout();
            red.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(blue, 1, 0);
            tableLayoutPanel1.Controls.Add(red, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Enabled = false;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 48.863636F));
            tableLayoutPanel1.Size = new Size(131, 88);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // blue
            // 
            blue.BackColor = Color.FromArgb(113, 137, 255);
            blue.Dock = DockStyle.Fill;
            blue.Enabled = false;
            blue.Location = new Point(68, 3);
            blue.Name = "blue";
            blue.Size = new Size(60, 82);
            blue.TabIndex = 3;
            // 
            // red
            // 
            red.BackColor = Color.FromArgb(249, 112, 104);
            red.Controls.Add(slideNumberLabel);
            red.Dock = DockStyle.Fill;
            red.Enabled = false;
            red.Location = new Point(3, 3);
            red.Name = "red";
            red.Size = new Size(59, 82);
            red.TabIndex = 1;
            // 
            // slideNumberLabel
            // 
            slideNumberLabel.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            slideNumberLabel.Location = new Point(0, 0);
            slideNumberLabel.Name = "slideNumberLabel";
            slideNumberLabel.Size = new Size(75, 23);
            slideNumberLabel.TabIndex = 0;
            slideNumberLabel.Text = "label1";
            // 
            // miniToF
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "miniToF";
            Size = new Size(131, 88);
            Click += miniToF_Click;
            tableLayoutPanel1.ResumeLayout(false);
            red.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Panel red;
        private AntdUI.Label slideNumberLabel;
        private Panel blue;
    }
}
