namespace Quizzz.IRTUP.QuestionTypeStudentsPanels
{
    partial class OpenEndedStudent
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
            answerTxtBox = new RichTextBox();
            SuspendLayout();
            // 
            // questionLabel
            // 
            questionLabel.AutoSize = true;
            questionLabel.Font = new Font("Century Gothic", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            questionLabel.Location = new Point(458, 33);
            questionLabel.Name = "questionLabel";
            questionLabel.Size = new Size(230, 42);
            questionLabel.TabIndex = 1;
            questionLabel.Text = "questionText";
            // 
            // answerTxtBox
            // 
            answerTxtBox.BackColor = SystemColors.ControlLight;
            answerTxtBox.BorderStyle = BorderStyle.None;
            answerTxtBox.Font = new Font("Century Gothic", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            answerTxtBox.Location = new Point(19, 151);
            answerTxtBox.Name = "answerTxtBox";
            answerTxtBox.Size = new Size(1144, 371);
            answerTxtBox.TabIndex = 2;
            answerTxtBox.Text = "";
            // 
            // OpenEndedStudent
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(answerTxtBox);
            Controls.Add(questionLabel);
            Name = "OpenEndedStudent";
            Size = new Size(1185, 544);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label questionLabel;
        private RichTextBox answerTxtBox;
    }
}
