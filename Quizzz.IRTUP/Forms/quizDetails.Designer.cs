namespace Quizzz.IRTUP.Forms
{
    partial class quizDetails
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
            quizNameTextBox = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // quizNameTextBox
            // 
            quizNameTextBox.Font = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            quizNameTextBox.Location = new Point(12, 43);
            quizNameTextBox.Name = "quizNameTextBox";
            quizNameTextBox.Size = new Size(242, 26);
            quizNameTextBox.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 25);
            label1.Name = "label1";
            label1.Size = new Size(72, 17);
            label1.TabIndex = 1;
            label1.Text = "Quiz Name";
            // 
            // quizDetails
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(266, 354);
            Controls.Add(label1);
            Controls.Add(quizNameTextBox);
            FormBorderStyle = FormBorderStyle.None;
            Name = "quizDetails";
            StartPosition = FormStartPosition.CenterParent;
            Text = "quizDetails";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox quizNameTextBox;
        private Label label1;
    }
}