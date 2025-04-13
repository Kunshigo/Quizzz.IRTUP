using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quizzz.IRTUP.QuestionTypePanels
{
    public partial class FillInTheBlanks : UserControl
    {
        private Size formOriginalSize;
        private Rectangle recTxtQuestion;
        private Rectangle recTxtAnswer;
        private Rectangle recPreview;

        public int QuestionID { get; set; }
        public string QuestionType { get; set; } = "Fill in the blanks";
        public string QuestionText => questionTxtBox.Text;
        public string Answers => answerTxtBox.Text;
        public int QuestionNo { get; set; } = 0;

        public FillInTheBlanks()
        {
            InitializeComponent();
            this.Resize += FillInTheBlanks_Resize;
            formOriginalSize = this.Size;
            recTxtQuestion = new Rectangle(questionTxtBox.Location, questionTxtBox.Size);
            recTxtAnswer = new Rectangle(answerTxtBox.Location, answerTxtBox.Size);
            recPreview = new Rectangle(lblPreviewOutput.Location, lblPreviewOutput.Size);
        }

        public void LoadData(string questionText, string answers)
        {
            questionTxtBox.Text = questionText;
            answerTxtBox.Text = answers;
            previewBtn_Click(null, null); // Auto-generate preview
        }

        private void FillInTheBlanks_Resize(object sender, EventArgs e)
        {
            resize_Control(questionTxtBox, recTxtQuestion);
            resize_Control(answerTxtBox, recTxtAnswer);
            resize_Control(lblPreviewOutput, recPreview);
        }

        private void resize_Control(Control c, Rectangle r)
        {
            float xRatio = (float)this.Width / formOriginalSize.Width;
            float yRatio = (float)this.Height / formOriginalSize.Height;

            int newX = (int)(r.X * xRatio);
            int newY = (int)(r.Y * yRatio);
            int newWidth = (int)(r.Width * xRatio);
            int newHeight = (int)(r.Height * yRatio);

            c.Location = new Point(newX, newY);
            c.Size = new Size(newWidth, newHeight);
        }

        private void previewBtn_Click(object sender, EventArgs e)
        {
            var blanks = answerTxtBox.Text.Split(',').Select(a => a.Trim()).ToList();
            string[] parts = questionTxtBox.Text.Split(new string[] { "__" }, StringSplitOptions.None);
            StringBuilder preview = new StringBuilder();

            for (int i = 0; i < parts.Length; i++)
            {
                preview.Append(parts[i]);
                if (i < blanks.Count && !string.IsNullOrWhiteSpace(blanks[i]))
                    preview.Append($"[{blanks[i]}]");
                else if (i < parts.Length - 1)
                    preview.Append("[___]");
            }

            lblPreviewOutput.Text = preview.ToString();
        }
    }
}
