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
    public partial class MultipleChoiceStudent : UserControl
    {
        public int QuestionNo { get; set; }
        public string SelectedAnswer { get; private set; }
        public string CorrectAnswer { get; private set; } // Made private set
        public bool IsCorrect => SelectedAnswer?.Equals(CorrectAnswer, StringComparison.OrdinalIgnoreCase) ?? false;


        public MultipleChoiceStudent()
        {
            InitializeComponent();
            button1.Click += (s, e) => SelectAnswer(button1.Text);
            button2.Click += (s, e) => SelectAnswer(button2.Text);
            button3.Click += (s, e) => SelectAnswer(button3.Text);
            button4.Click += (s, e) => SelectAnswer(button4.Text);

        }

        public void DisableButtons()
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
        }

        public void LoadQuestion(string questionText, string[] choices, string correctAnswer, Image image = null)
        {
            questionLabel.Text = questionText;
            button1.Text = choices[0];
            button2.Text = choices[1];
            button3.Text = choices[2];
            button4.Text = choices[3];
            CorrectAnswer = correctAnswer;
        }
        public event EventHandler AnswerSelected;
        private void SelectAnswer(string answer)
        {
            // Store the previously selected button (if any)
            Button previouslySelected = null;
            if (SelectedAnswer != null)
            {
                previouslySelected = new[] { button1, button2, button3, button4 }
                    .FirstOrDefault(b => b.Text == SelectedAnswer);
            }

            // Update the selected answer
            SelectedAnswer = answer;
            Button currentlySelected = new[] { button1, button2, button3, button4 }
                .First(b => b.Text == answer);

            // Reset previous selection (if any)
            if (previouslySelected != null && previouslySelected != currentlySelected)
            {
                previouslySelected.FlatAppearance.BorderSize = 1;
                previouslySelected.FlatAppearance.BorderColor = Color.LightGray;
                previouslySelected.BackColor = Color.White;
            }

            // Highlight the new selection
            currentlySelected.FlatAppearance.BorderSize = 3;
            currentlySelected.FlatAppearance.BorderColor = Color.Green;
            currentlySelected.BackColor = Color.FromArgb(230, 255, 230); // Light green

            AnswerSelected?.Invoke(this, EventArgs.Empty);
        }
    }

}
