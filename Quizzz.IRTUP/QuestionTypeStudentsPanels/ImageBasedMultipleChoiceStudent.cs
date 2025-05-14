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
    public partial class ImageBasedMultipleChoiceStudent : UserControl
    {
        public int QuestionNo { get; set; }
        public int SelectedAnswerIndex { get; private set; } = -1;
        public int CorrectAnswerIndex { get; private set; }
        public bool IsCorrect => SelectedAnswerIndex == CorrectAnswerIndex;

        private PictureBox[] pictureBoxes;
        private string[] imagePaths;

        public ImageBasedMultipleChoiceStudent()
        {
            InitializeComponent();

            pictureBoxes = new PictureBox[] { pictureBox1, pictureBox2, pictureBox3, pictureBox4 };

            // Set up click events for each picture box
            for (int i = 0; i < pictureBoxes.Length; i++)
            {
                int index = i; // Capture the current index for the closure
                pictureBoxes[i].Click += (s, e) => SelectAnswer(index);
                pictureBoxes[i].Cursor = Cursors.Hand; // Show hand cursor on hover
            }
        }

        public void DisableSelection()
        {
            foreach (var pb in pictureBoxes)
            {
                pb.Enabled = false;
            }
        }

        public void LoadQuestion(string questionText, string[] imagePaths, int correctAnswerIndex)
        {
            questionLabel.Text = questionText;
            this.imagePaths = imagePaths;
            CorrectAnswerIndex = correctAnswerIndex;
            SelectedAnswerIndex = -1;

            // Load images into picture boxes
            for (int i = 0; i < imagePaths.Length; i++)
            {
                if (!string.IsNullOrEmpty(imagePaths[i]))
                {
                    try
                    {
                        pictureBoxes[i].Image = Image.FromFile(imagePaths[i]);
                        pictureBoxes[i].SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading image {i + 1}: {ex.Message}");
                        pictureBoxes[i].Image = null;
                    }
                }
                else
                {
                    pictureBoxes[i].Image = null;
                }

                // Reset appearance
                pictureBoxes[i].BorderStyle = BorderStyle.FixedSingle;
                pictureBoxes[i].BackColor = SystemColors.Control;
            }

            // Highlight correct answer if already selected
            if (SelectedAnswerIndex >= 0)
            {
                UpdateAnswerHighlight();
            }
        }

        public event EventHandler AnswerSelected;

        private void SelectAnswer(int answerIndex)
        {
            // Store previous selection
            int previousSelection = SelectedAnswerIndex;
            SelectedAnswerIndex = answerIndex;

            // Update visual appearance
            UpdateAnswerHighlight(previousSelection);

            AnswerSelected?.Invoke(this, EventArgs.Empty);
        }

        private void UpdateAnswerHighlight(int previousSelection = -1)
        {
            // Reset previous selection
            if (previousSelection >= 0 && previousSelection < pictureBoxes.Length)
            {
                pictureBoxes[previousSelection].BorderStyle = BorderStyle.FixedSingle;
                pictureBoxes[previousSelection].BackColor = SystemColors.Control;
            }

            // Highlight new selection
            if (SelectedAnswerIndex >= 0 && SelectedAnswerIndex < pictureBoxes.Length)
            {
                pictureBoxes[SelectedAnswerIndex].BorderStyle = BorderStyle.Fixed3D;
                pictureBoxes[SelectedAnswerIndex].BackColor = Color.FromArgb(230, 255, 230); // Light green
            }
        }

        public void ShowCorrectAnswer()
        {
            // Highlight the correct answer
            if (CorrectAnswerIndex >= 0 && CorrectAnswerIndex < pictureBoxes.Length)
            {
                pictureBoxes[CorrectAnswerIndex].BorderStyle = BorderStyle.Fixed3D;
                pictureBoxes[CorrectAnswerIndex].BackColor = Color.LightGreen;
            }

            // If user selected a wrong answer, highlight it in red
            if (SelectedAnswerIndex >= 0 && SelectedAnswerIndex != CorrectAnswerIndex)
            {
                pictureBoxes[SelectedAnswerIndex].BorderStyle = BorderStyle.Fixed3D;
                pictureBoxes[SelectedAnswerIndex].BackColor = Color.LightPink;
            }
        }
    }
}
