using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quizzz.IRTUP.QuestionTypeStudentsPanels
{
    public partial class IdentificationStudent : UserControl
    {
        public int QuestionNo { get; set; }
        public string UserAnswer { get; private set; }
        public List<string> CorrectAnswers { get; private set; }
        public bool IsCorrect => CorrectAnswers.Any(c =>
            !string.IsNullOrWhiteSpace(c) &&
            string.Equals(UserAnswer?.Trim(), c?.Trim(), StringComparison.OrdinalIgnoreCase));

        public IdentificationStudent()
        {
            InitializeComponent();
        }

        public void LoadQuestion(string questionText, string correctAnswer, List<string> alternativeAnswers)
        {
            CorrectAnswers = new List<string> { correctAnswer };
            CorrectAnswers.AddRange(alternativeAnswers.Where(a => !string.IsNullOrWhiteSpace(a)));
            answerTextBox.Text = "";
            UserAnswer = "";

            // Set question text
            questionLabel.Text = questionText;
        }

        public void DisableControls()
        {
            answerTextBox.Enabled = false;
        }
        public event EventHandler AnswerSelected;
    }
}
