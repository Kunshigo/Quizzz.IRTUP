namespace Quizzz.IRTUP.Slide_Previews
{
    partial class miniFillInTheBlanks
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
            slideNumberLabel = new AntdUI.Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Dock = DockStyle.Fill;
            label1.Enabled = false;
            label1.Font = new Font("Century Gothic", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(131, 88);
            label1.TabIndex = 0;
            label1.Text = "Abc ___";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // slideNumberLabel
            // 
            slideNumberLabel.AutoSizeMode = AntdUI.TAutoSize.Auto;
            slideNumberLabel.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            slideNumberLabel.Location = new Point(0, 0);
            slideNumberLabel.Margin = new Padding(0);
            slideNumberLabel.Name = "slideNumberLabel";
            slideNumberLabel.Size = new Size(45, 18);
            slideNumberLabel.TabIndex = 3;
            slideNumberLabel.Text = "label1";
            // 
            // miniFillInTheBlanks
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(slideNumberLabel);
            Controls.Add(label1);
            Margin = new Padding(0);
            Name = "miniFillInTheBlanks";
            Size = new Size(131, 88);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private AntdUI.Label slideNumberLabel;
    }
}
