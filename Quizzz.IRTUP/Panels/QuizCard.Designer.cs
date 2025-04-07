namespace Quizzz.IRTUP.Panels
{
    partial class QuizCard
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
            lblQuizName = new Label();
            openBtn = new AntdUI.Button();
            createdDateLabel = new Label();
            SuspendLayout();
            // 
            // lblQuizName
            // 
            lblQuizName.AutoSize = true;
            lblQuizName.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblQuizName.ImageAlign = ContentAlignment.TopLeft;
            lblQuizName.Location = new Point(46, 21);
            lblQuizName.Name = "lblQuizName";
            lblQuizName.RightToLeft = RightToLeft.No;
            lblQuizName.Size = new Size(89, 21);
            lblQuizName.TabIndex = 1;
            lblQuizName.Text = "quizName";
            lblQuizName.TextAlign = ContentAlignment.TopCenter;
            // 
            // openBtn
            // 
            openBtn.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            openBtn.Location = new Point(17, 120);
            openBtn.Name = "openBtn";
            openBtn.Size = new Size(145, 42);
            openBtn.TabIndex = 2;
            openBtn.Text = "Open Quiz";
            openBtn.Click += openBtn_Click;
            // 
            // createdDateLabel
            // 
            createdDateLabel.AutoSize = true;
            createdDateLabel.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            createdDateLabel.ImageAlign = ContentAlignment.TopLeft;
            createdDateLabel.Location = new Point(46, 51);
            createdDateLabel.Name = "createdDateLabel";
            createdDateLabel.RightToLeft = RightToLeft.No;
            createdDateLabel.Size = new Size(89, 21);
            createdDateLabel.TabIndex = 1;
            createdDateLabel.Text = "quizName";
            createdDateLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // QuizCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(255, 192, 192);
            Controls.Add(openBtn);
            Controls.Add(createdDateLabel);
            Controls.Add(lblQuizName);
            Name = "QuizCard";
            Size = new Size(180, 180);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblQuizName;
        private AntdUI.Button openBtn;
        private Label createdDateLabel;
    }
}
