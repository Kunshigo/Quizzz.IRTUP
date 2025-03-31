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
            panel1 = new Panel();
            lblDate = new Label();
            lblCategory = new Label();
            lblQuestions = new Label();
            lblTitle = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(lblDate);
            panel1.Controls.Add(lblCategory);
            panel1.Controls.Add(lblQuestions);
            panel1.Controls.Add(lblTitle);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(250, 180);
            panel1.TabIndex = 0;
            panel1.Paint += QuizCard_Paint;
            panel1.MouseEnter += QuizCard_MouseEnter;
            panel1.MouseLeave += QuizCard_MouseLeave;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Location = new Point(12, 81);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(69, 15);
            lblDate.TabIndex = 0;
            lblDate.Text = "datecreated";
            // 
            // lblCategory
            // 
            lblCategory.AutoSize = true;
            lblCategory.Location = new Point(12, 59);
            lblCategory.Name = "lblCategory";
            lblCategory.Size = new Size(53, 15);
            lblCategory.TabIndex = 0;
            lblCategory.Text = "category";
            // 
            // lblQuestions
            // 
            lblQuestions.AutoSize = true;
            lblQuestions.Location = new Point(12, 37);
            lblQuestions.Name = "lblQuestions";
            lblQuestions.Size = new Size(92, 15);
            lblQuestions.TabIndex = 0;
            lblQuestions.Text = "no. of questions";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(12, 17);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(61, 15);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "quizName";
            // 
            // QuizCard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Name = "QuizCard";
            Size = new Size(250, 180);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lblDate;
        private Label lblCategory;
        private Label lblQuestions;
        private Label lblTitle;
    }
}
