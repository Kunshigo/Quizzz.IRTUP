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
    public partial class TrueFalseStudent : UserControl
    {
        public event EventHandler AnswerSelected;

        public int QuestionNo { get; set; }
        public string SelectedAnswer { get; private set; }
        public string CorrectAnswer { get; private set; }
        public bool IsCorrect => SelectedAnswer?.Equals(CorrectAnswer, StringComparison.OrdinalIgnoreCase) ?? false;

        public TrueFalseStudent()
        {
            InitializeComponent();

            button1.Click += (s, e) => SelectAnswer("False");
            button4.Click += (s, e) => SelectAnswer("True");
        }

        public void LoadQuestion(string questionText, string correctAnswer)
        {
            label1.Text = questionText; // Show just the question text
            CorrectAnswer = correctAnswer;
            ResetButtons();
        }

        private void SelectAnswer(string answer)
        {
            SelectedAnswer = answer;

            // Highlight selected button
            if (answer == "True")
            {
                button4.FlatAppearance.BorderSize = 3;
                button4.FlatAppearance.BorderColor = Color.Green;
                button1.FlatAppearance.BorderSize = 1;
                button1.FlatAppearance.BorderColor = Color.LightGray;
            }
            else
            {
                button1.FlatAppearance.BorderSize = 3;
                button1.FlatAppearance.BorderColor = Color.Green;
                button4.FlatAppearance.BorderSize = 1;
                button4.FlatAppearance.BorderColor = Color.LightGray;
            }

            AnswerSelected?.Invoke(this, EventArgs.Empty);
        }

        public void DisableButtons()
        {
            button1.Enabled = false;
            button4.Enabled = false;
        }

        private void ResetButtons()
        {
            button1.Enabled = true;
            button4.Enabled = true;
            button1.FlatAppearance.BorderSize = 1;
            button4.FlatAppearance.BorderSize = 1;
            button1.FlatAppearance.BorderColor = Color.LightGray;
            button4.FlatAppearance.BorderColor = Color.LightGray;
            SelectedAnswer = null;
        }
    }
}
