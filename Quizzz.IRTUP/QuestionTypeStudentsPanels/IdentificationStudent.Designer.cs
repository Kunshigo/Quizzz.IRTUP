namespace Quizzz.IRTUP.QuestionTypeStudentsPanels
{
    partial class IdentificationStudent
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
            questionLabel = new Label();
            answerTextBox = new TextBox();
            SuspendLayout();
            // 
            // questionLabel
            // 
            questionLabel.AutoSize = true;
            questionLabel.Font = new Font("Century Gothic", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            questionLabel.Location = new Point(469, 62);
            questionLabel.Name = "questionLabel";
            questionLabel.Size = new Size(230, 42);
            questionLabel.TabIndex = 1;
            questionLabel.Text = "questionText";
            // 
            // answerTextBox
            // 
            answerTextBox.Font = new Font("Century Gothic", 48F, FontStyle.Regular, GraphicsUnit.Point, 0);
            answerTextBox.Location = new Point(18, 418);
            answerTextBox.Name = "answerTextBox";
            answerTextBox.Size = new Size(1144, 86);
            answerTextBox.TabIndex = 2;
            answerTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // IdentificationStudent
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(answerTextBox);
            Controls.Add(questionLabel);
            Name = "IdentificationStudent";
            Size = new Size(1185, 544);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label questionLabel;
        private TextBox answerTextBox;
    }
}
