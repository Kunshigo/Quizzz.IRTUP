namespace Quizzz.IRTUP.QuestionTypePanels
{
    partial class FillInTheBlanks
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
            questionTxtBox = new TextBox();
            label2 = new Label();
            answerTxtBox = new TextBox();
            previewBtn = new Button();
            lblPreviewOutput = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 12.25F, FontStyle.Bold);
            label1.Location = new Point(13, 48);
            label1.Name = "label1";
            label1.Size = new Size(372, 19);
            label1.TabIndex = 0;
            label1.Text = "Type the question and place blanks using __";
            // 
            // questionTxtBox
            // 
            questionTxtBox.Font = new Font("Century Gothic", 9F);
            questionTxtBox.Location = new Point(23, 78);
            questionTxtBox.Multiline = true;
            questionTxtBox.Name = "questionTxtBox";
            questionTxtBox.Size = new Size(950, 120);
            questionTxtBox.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Century Gothic", 12.25F, FontStyle.Bold);
            label2.Location = new Point(23, 228);
            label2.Name = "label2";
            label2.Size = new Size(444, 19);
            label2.TabIndex = 0;
            label2.Text = "Specify answers for each blank (comma-separated):";
            // 
            // answerTxtBox
            // 
            answerTxtBox.Font = new Font("Century Gothic", 9F);
            answerTxtBox.Location = new Point(23, 258);
            answerTxtBox.Multiline = true;
            answerTxtBox.Name = "answerTxtBox";
            answerTxtBox.Size = new Size(950, 60);
            answerTxtBox.TabIndex = 2;
            // 
            // previewBtn
            // 
            previewBtn.Font = new Font("Century Gothic", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            previewBtn.Location = new Point(23, 336);
            previewBtn.Name = "previewBtn";
            previewBtn.Size = new Size(100, 30);
            previewBtn.TabIndex = 3;
            previewBtn.Text = "Preview";
            previewBtn.UseVisualStyleBackColor = true;
            previewBtn.Click += previewBtn_Click;
            // 
            // lblPreviewOutput
            // 
            lblPreviewOutput.AutoSize = true;
            lblPreviewOutput.BorderStyle = BorderStyle.FixedSingle;
            lblPreviewOutput.Font = new Font("Century Gothic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPreviewOutput.Location = new Point(20, 379);
            lblPreviewOutput.Name = "lblPreviewOutput";
            lblPreviewOutput.Size = new Size(113, 23);
            lblPreviewOutput.TabIndex = 4;
            lblPreviewOutput.Text = "Preview Here";
            // 
            // FillInTheBlanks
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblPreviewOutput);
            Controls.Add(previewBtn);
            Controls.Add(answerTxtBox);
            Controls.Add(questionTxtBox);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FillInTheBlanks";
            Size = new Size(999, 513);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        public TextBox questionTxtBox;
        private Label label2;
        private TextBox answerTxtBox;
        private Button previewBtn;
        private Label lblPreviewOutput;
    }
}
