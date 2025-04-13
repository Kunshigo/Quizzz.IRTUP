namespace Quizzz.IRTUP.QuestionTypePanels
{
    partial class OpenEnded
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
            panel1 = new Panel();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
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
            questionTxtBox.PlaceholderText = "Start typing your question";
            questionTxtBox.Size = new Size(935, 46);
            questionTxtBox.TabIndex = 15;
            questionTxtBox.TextAlign = HorizontalAlignment.Center;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.Location = new Point(284, 82);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(448, 231);
            pictureBox1.TabIndex = 16;
            pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Gainsboro;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(340, 365);
            panel1.Name = "panel1";
            panel1.Size = new Size(368, 100);
            panel1.TabIndex = 17;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(156, 19);
            label1.Name = "label1";
            label1.Size = new Size(209, 68);
            label1.TabIndex = 0;
            label1.Text = "Students can submit up to 250\r\ncharacters. Their responses will\r\nbe displayed after they answer.\r\n\r\n";
            // 
            // OpenEnded
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Controls.Add(pictureBox1);
            Controls.Add(questionTxtBox);
            Name = "OpenEnded";
            Size = new Size(999, 513);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public TextBox questionTxtBox;
        private PictureBox pictureBox1;
        private Panel panel1;
        private Label label1;
    }
}
