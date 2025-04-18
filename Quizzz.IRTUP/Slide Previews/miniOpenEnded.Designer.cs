namespace Quizzz.IRTUP.Slide_Previews
{
    partial class miniOpenEnded
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
            label1 = new Label();
            richTextBox1 = new RichTextBox();
            slideNumberLabel = new AntdUI.Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Dock = DockStyle.Top;
            label1.Enabled = false;
            label1.Font = new Font("Century Gothic", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(131, 23);
            label1.TabIndex = 0;
            label1.Text = "Abc";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = SystemColors.InactiveCaption;
            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox1.Dock = DockStyle.Bottom;
            richTextBox1.Enabled = false;
            richTextBox1.Location = new Point(0, 29);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(131, 59);
            richTextBox1.TabIndex = 1;
            richTextBox1.Text = "";
            // 
            // slideNumberLabel
            // 
            slideNumberLabel.AutoSizeMode = AntdUI.TAutoSize.Auto;
            slideNumberLabel.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            slideNumberLabel.Location = new Point(0, 0);
            slideNumberLabel.Margin = new Padding(0);
            slideNumberLabel.Name = "slideNumberLabel";
            slideNumberLabel.Size = new Size(45, 18);
            slideNumberLabel.TabIndex = 4;
            slideNumberLabel.Text = "label1";
            // 
            // miniOpenEnded
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(slideNumberLabel);
            Controls.Add(richTextBox1);
            Controls.Add(label1);
            Margin = new Padding(0);
            Name = "miniOpenEnded";
            Size = new Size(131, 88);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private RichTextBox richTextBox1;
        private AntdUI.Label slideNumberLabel;
    }
}
