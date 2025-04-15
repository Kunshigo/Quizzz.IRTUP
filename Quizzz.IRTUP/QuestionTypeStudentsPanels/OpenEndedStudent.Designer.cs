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
            submitButton = new Button();
            SuspendLayout();
            // 
            // questionLabel
            // 
            questionLabel.Dock = DockStyle.Fill;
            questionLabel.Font = new Font("Century Gothic", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            questionLabel.Location = new Point(0, 0);
            questionLabel.Name = "questionLabel";
            questionLabel.Size = new Size(1185, 544);
            questionLabel.TabIndex = 1;
            questionLabel.Text = "questionText";
            questionLabel.TextAlign = ContentAlignment.TopCenter;
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
            // submitButton
            // 
            submitButton.FlatStyle = FlatStyle.Flat;
            submitButton.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            submitButton.Location = new Point(1088, 122);
            submitButton.Name = "submitButton";
            submitButton.Size = new Size(75, 23);
            submitButton.TabIndex = 3;
            submitButton.Text = "Submit";
            submitButton.UseVisualStyleBackColor = true;
            // 
            // OpenEndedStudent
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(submitButton);
            Controls.Add(answerTxtBox);
            Controls.Add(questionLabel);
            Name = "OpenEndedStudent";
            Size = new Size(1185, 544);
            ResumeLayout(false);
        }

        #endregion

        private Label questionLabel;
        private RichTextBox answerTxtBox;
        private Button submitButton;
    }
}
