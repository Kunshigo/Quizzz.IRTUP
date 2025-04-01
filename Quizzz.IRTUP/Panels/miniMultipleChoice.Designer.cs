namespace Quizzz.IRTUP.Panels
{
    partial class miniMultipleChoice
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
            panel1 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            yellow = new Panel();
            blue = new Panel();
            green = new Panel();
            red = new Panel();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Dock = DockStyle.Fill;
            panel1.Enabled = false;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(131, 88);
            panel1.TabIndex = 0;
            panel1.Click += miniMultipleChoice_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(yellow, 1, 1);
            tableLayoutPanel1.Controls.Add(blue, 0, 1);
            tableLayoutPanel1.Controls.Add(green, 1, 0);
            tableLayoutPanel1.Controls.Add(red, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Enabled = false;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(131, 88);
            tableLayoutPanel1.TabIndex = 0;
            tableLayoutPanel1.Click += miniMultipleChoice_Click;
            // 
            // yellow
            // 
            yellow.BackColor = Color.FromArgb(249, 199, 132);
            yellow.Dock = DockStyle.Fill;
            yellow.Enabled = false;
            yellow.Location = new Point(68, 47);
            yellow.Name = "yellow";
            yellow.Size = new Size(60, 38);
            yellow.TabIndex = 3;
            yellow.Click += miniMultipleChoice_Click;
            // 
            // blue
            // 
            blue.BackColor = Color.FromArgb(113, 137, 255);
            blue.Dock = DockStyle.Fill;
            blue.Enabled = false;
            blue.Location = new Point(3, 47);
            blue.Name = "blue";
            blue.Size = new Size(59, 38);
            blue.TabIndex = 2;
            blue.Click += miniMultipleChoice_Click;
            // 
            // green
            // 
            green.BackColor = Color.FromArgb(112, 193, 179);
            green.Dock = DockStyle.Fill;
            green.Enabled = false;
            green.Location = new Point(68, 3);
            green.Name = "green";
            green.Size = new Size(60, 38);
            green.TabIndex = 1;
            green.Click += miniMultipleChoice_Click;
            // 
            // red
            // 
            red.BackColor = Color.FromArgb(249, 112, 104);
            red.Dock = DockStyle.Fill;
            red.Enabled = false;
            red.Location = new Point(3, 3);
            red.Name = "red";
            red.Size = new Size(59, 38);
            red.TabIndex = 0;
            red.Click += miniMultipleChoice_Click;
            // 
            // miniMultipleChoice
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Margin = new Padding(0);
            Name = "miniMultipleChoice";
            Size = new Size(131, 88);
            panel1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel red;
        private Panel yellow;
        private Panel blue;
        private Panel green;
    }
}
