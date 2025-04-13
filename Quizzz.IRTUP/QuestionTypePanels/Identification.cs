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
    public partial class Identification : UserControl
    {
        private Size formOriginalSize;
        private Rectangle recTxtQuestion;
        private Rectangle recTxtMainAnswer;
        private Rectangle recTxtAnswer1;
        private Rectangle recTxtAnswer2;
        private Rectangle recTxtAnswer3;

        public int QuestionID { get; set; }
        public string QuestionType { get; set; } = "Identification";
        public string QuestionText => questionTxtBox.Text;
        public string CorrectAnswer => mainAnswerTxtBox.Text;
        public List<string> AlternativeAnswers => new List<string>
        {
            answer1TxtBox.Text,
            answer2TxtBox.Text,
            answer3TxtBox.Text
        };
        public int QuestionNo { get; set; } = 0;

        public Identification()
        {
            InitializeComponent();
            this.Resize += Identification_Resize;
            formOriginalSize = this.Size;
            recTxtQuestion = new Rectangle(questionTxtBox.Location, questionTxtBox.Size);
            recTxtMainAnswer = new Rectangle(mainAnswerTxtBox.Location, mainAnswerTxtBox.Size);
            recTxtAnswer1 = new Rectangle(answer1TxtBox.Location, answer1TxtBox.Size);
            recTxtAnswer2 = new Rectangle(answer2TxtBox.Location, answer2TxtBox.Size);
            recTxtAnswer3 = new Rectangle(answer3TxtBox.Location, answer3TxtBox.Size);
        }

        public void LoadData(string questionText, string correctAnswer, List<string> alternativeAnswers = null)
        {
            questionTxtBox.Text = questionText;
            mainAnswerTxtBox.Text = correctAnswer ?? string.Empty;

            // Load alternative answers if provided
            if (alternativeAnswers != null && alternativeAnswers.Count >= 3)
            {
                answer1TxtBox.Text = alternativeAnswers[0] ?? string.Empty;
                answer2TxtBox.Text = alternativeAnswers[1] ?? string.Empty;
                answer3TxtBox.Text = alternativeAnswers[2] ?? string.Empty;
            }
        }

        private void Identification_Resize(object sender, EventArgs e)
        {
            resize_Control(questionTxtBox, recTxtQuestion);
            resize_Control(mainAnswerTxtBox, recTxtMainAnswer);
            resize_Control(answer1TxtBox, recTxtAnswer1);
            resize_Control(answer2TxtBox, recTxtAnswer2);
            resize_Control(answer3TxtBox, recTxtAnswer3);
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
    }
}