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
    public partial class ImageMultipleChoice : UserControl
    {
        public int QuestionID { get; set; }
        public int QuestionNo { get; set; }
        public string QuestionType => "ImageMultipleChoice";
        public string QuestionText => questionTxtBox.Text;
        public int CorrectAnswerIndex { get; private set; } = -1;
        public string[] ImagePaths { get; private set; } = new string[4];

        private PictureBox[] choices;

        public ImageMultipleChoice()
        {
            InitializeComponent();

            choices = new[] { pictureBox1, pictureBox2, pictureBox3, pictureBox4 };

            for (int i = 0; i < choices.Length; i++)
            {
                int index = i;
                choices[i].Click += (s, e) =>
                {
                    SelectAnswer(index);
                    SelectImageFromFile(index);
                };
            }
        }

        public void SetImages(string[] imagePaths, int correctIndex)
        {
            ImagePaths = imagePaths;
            CorrectAnswerIndex = correctIndex;

            for (int i = 0; i < 4; i++)
            {
                if (System.IO.File.Exists(imagePaths[i]))
                {
                    choices[i].Image = Image.FromFile(imagePaths[i]);
                }
            }

            HighlightCorrect(correctIndex);
        }

        private void SelectAnswer(int index)
        {
            CorrectAnswerIndex = index;
            HighlightCorrect(index);
        }

        private void HighlightCorrect(int selectedIndex)
        {
            for (int i = 0; i < choices.Length; i++)
            {
                choices[i].BorderStyle = i == selectedIndex ? BorderStyle.Fixed3D : BorderStyle.FixedSingle;
            }
        }

        private void SelectImageFromFile(int index)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    ImagePaths[index] = ofd.FileName;
                    choices[index].Image = Image.FromFile(ofd.FileName);
                }
            }
        }

    }
}
