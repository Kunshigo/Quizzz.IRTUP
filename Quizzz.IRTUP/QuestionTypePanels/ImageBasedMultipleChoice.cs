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
    public partial class ImageBasedMultipleChoice : UserControl
    {
        public int QuestionNo { get; set; }
        public int QuestionID { get; set; }
        public string QuestionType => "ImageBasedMultipleChoice";
        public string QuestionText => questionTxtBox.Text;

        private int correctAnswerIndex = -1;
        public int CorrectAnswerIndex
        {
            get => correctAnswerIndex;
            set
            {
                correctAnswerIndex = value;
                UpdateCorrectAnswerHighlight();
            }
        }

        private string[] imagePaths = new string[4];
        private PictureBox[] pictureBoxes;
        private Button[] correctButtons;

        public ImageBasedMultipleChoice()
        {
            InitializeComponent();

            // Initialize arrays for easy access
            pictureBoxes = new PictureBox[] { pictureBox1, pictureBox2, pictureBox3, pictureBox4 };
            correctButtons = new Button[] { correctBtn1, correctBtn2, correctBtn3, correctBtn4 };

            selectBtn1.Click += (s, e) => LoadImage(0);
            selectBtn2.Click += (s, e) => LoadImage(1);
            selectBtn3.Click += (s, e) => LoadImage(2);
            selectBtn4.Click += (s, e) => LoadImage(3);

            correctBtn1.Click += (s, e) => SetCorrectAnswer(0);
            correctBtn2.Click += (s, e) => SetCorrectAnswer(1);
            correctBtn3.Click += (s, e) => SetCorrectAnswer(2);
            correctBtn4.Click += (s, e) => SetCorrectAnswer(3);
        }

        private void LoadImage(int index)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    imagePaths[index] = ofd.FileName;
                    try
                    {
                        pictureBoxes[index].Image = Image.FromFile(ofd.FileName);
                        correctButtons[index].Enabled = true; // Enable correct button only when image is loaded
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading image: {ex.Message}");
                    }
                }
            }
        }

        private void SetCorrectAnswer(int index)
        {
            if (pictureBoxes[index].Image == null)
            {
                MessageBox.Show("Please select an image first before marking it as correct.");
                return;
            }

            CorrectAnswerIndex = index;
        }

        private void UpdateCorrectAnswerHighlight()
        {
            // Reset all borders
            for (int i = 0; i < pictureBoxes.Length; i++)
            {
                pictureBoxes[i].BorderStyle = BorderStyle.FixedSingle;
                pictureBoxes[i].BackColor = SystemColors.Control;
            }

            // Highlight correct answer
            if (CorrectAnswerIndex >= 0 && CorrectAnswerIndex < pictureBoxes.Length)
            {
                pictureBoxes[CorrectAnswerIndex].BorderStyle = BorderStyle.Fixed3D;
                pictureBoxes[CorrectAnswerIndex].BackColor = Color.LightGreen;
            }
        }

        public string[] GetImagePaths() => imagePaths;

        public void LoadQuestion(string[] imagePaths, int correctAnswerIndex)
        {
            for (int i = 0; i < imagePaths.Length; i++)
            {
                if (!string.IsNullOrEmpty(imagePaths[i]))
                {
                    try
                    {
                        this.imagePaths[i] = imagePaths[i];
                        pictureBoxes[i].Image = Image.FromFile(imagePaths[i]);
                        correctButtons[i].Enabled = true;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading image {i + 1}: {ex.Message}");
                    }
                }
            }
            CorrectAnswerIndex = correctAnswerIndex;
        }
    }
}