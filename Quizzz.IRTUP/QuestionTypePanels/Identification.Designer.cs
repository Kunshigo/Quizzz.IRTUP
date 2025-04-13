namespace Quizzz.IRTUP.QuestionTypePanels
{
    partial class Identification
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
            answer1TxtBox = new TextBox();
            answer2TxtBox = new TextBox();
            answer3TxtBox = new TextBox();
            mainAnswerTxtBox = new TextBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
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
            questionTxtBox.TabIndex = 14;
            questionTxtBox.TextAlign = HorizontalAlignment.Center;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pictureBox1.Location = new Point(272, 85);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(448, 231);
            pictureBox1.TabIndex = 13;
            pictureBox1.TabStop = false;
            // 
            // answer1TxtBox
            // 
            answer1TxtBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            answer1TxtBox.Font = new Font("Century Gothic", 25F);
            answer1TxtBox.Location = new Point(32, 435);
            answer1TxtBox.Name = "answer1TxtBox";
            answer1TxtBox.PlaceholderText = "Type an answer";
            answer1TxtBox.Size = new Size(308, 48);
            answer1TxtBox.TabIndex = 14;
            answer1TxtBox.TextAlign = HorizontalAlignment.Center;
            // 
            // answer2TxtBox
            // 
            answer2TxtBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            answer2TxtBox.Font = new Font("Century Gothic", 25F);
            answer2TxtBox.Location = new Point(346, 435);
            answer2TxtBox.Name = "answer2TxtBox";
            answer2TxtBox.PlaceholderText = "Type an answer";
            answer2TxtBox.Size = new Size(308, 48);
            answer2TxtBox.TabIndex = 14;
            answer2TxtBox.TextAlign = HorizontalAlignment.Center;
            // 
            // answer3TxtBox
            // 
            answer3TxtBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            answer3TxtBox.Font = new Font("Century Gothic", 25F);
            answer3TxtBox.Location = new Point(660, 435);
            answer3TxtBox.Name = "answer3TxtBox";
            answer3TxtBox.PlaceholderText = "Type an answer";
            answer3TxtBox.Size = new Size(308, 48);
            answer3TxtBox.TabIndex = 14;
            answer3TxtBox.TextAlign = HorizontalAlignment.Center;
            // 
            // mainAnswerTxtBox
            // 
            mainAnswerTxtBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            mainAnswerTxtBox.Font = new Font("Century Gothic", 25F);
            mainAnswerTxtBox.Location = new Point(272, 333);
            mainAnswerTxtBox.Name = "mainAnswerTxtBox";
            mainAnswerTxtBox.PlaceholderText = "Type an answer";
            mainAnswerTxtBox.Size = new Size(448, 48);
            mainAnswerTxtBox.TabIndex = 14;
            mainAnswerTxtBox.TextAlign = HorizontalAlignment.Center;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(389, 399);
            label1.Name = "label1";
            label1.Size = new Size(241, 22);
            label1.TabIndex = 15;
            label1.Text = "Other accepted answers";
            // 
            // Identification
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(label1);
            Controls.Add(answer3TxtBox);
            Controls.Add(mainAnswerTxtBox);
            Controls.Add(answer2TxtBox);
            Controls.Add(answer1TxtBox);
            Controls.Add(questionTxtBox);
            Controls.Add(pictureBox1);
            Name = "Identification";
            Size = new Size(999, 513);
            Resize += Identification_Resize;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public TextBox questionTxtBox;
        private PictureBox pictureBox1;
        public TextBox answer1TxtBox;
        public TextBox answer2TxtBox;
        public TextBox answer3TxtBox;
        public TextBox mainAnswerTxtBox;
        private Label label1;
    }
}
