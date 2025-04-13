using AntdUI;
using Quizzz.IRTUP.Classes;
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
    public partial class TrueFalse : UserControl
    {
        private Size formOriginalSize;
        private Rectangle recTxt;

        public int QuestionID { get; set; }
        public string QuestionType { get; set; } = "True or False";
        public string CorrectAnswer { get; set; } = null;
        public string QuestionText => questionTxtBox.Text;
        public int QuestionNo { get; set; }
        public byte[] ImageData { get; private set; }

        public TrueFalse()
        {
            InitializeComponent();
            trueBtn.Click += (s, e) => SelectCorrectAnswer(0);
            falseBtn.Click += (s, e) => SelectCorrectAnswer(1);

            this.Resize += TrueFalse_Resize;
            formOriginalSize = this.Size;
            recTxt = new Rectangle(questionTxtBox.Location, questionTxtBox.Size);

            QuestionImageHelper.InitializeImageHandling(
            pictureBox1,
            btnAddImage,
            btnRemoveImage,
            data => ImageData = data);
        }

        public void SelectCorrectAnswer(int index)
        {
            if (index == 0)
            {
                CorrectAnswer = "True";
                trueBtn.FlatAppearance.BorderSize = 3;
                trueBtn.FlatAppearance.BorderColor = Color.Green;
                falseBtn.FlatAppearance.BorderSize = 0;
            }
            else
            {
                CorrectAnswer = "False";
                falseBtn.FlatAppearance.BorderSize = 3;
                falseBtn.FlatAppearance.BorderColor = Color.Green;
                trueBtn.FlatAppearance.BorderSize = 0;
            }
        }

        public void LoadData(string questionText, string correctAnswer, byte[] imageData = null)
        {
            questionTxtBox.Text = questionText;
            if (correctAnswer == "True")
                SelectCorrectAnswer(0);
            else if (correctAnswer == "False")
                SelectCorrectAnswer(1);
            ImageData = imageData;
            QuestionImageHelper.LoadImage(pictureBox1, imageData);
        }
        public Image GetImage()
        {
            return QuestionImageHelper.BytesToImage(ImageData);
        }

        public void SetImage(Image image)
        {
            ImageData = QuestionImageHelper.GetImageBytes(image);
            QuestionImageHelper.LoadImage(pictureBox1, ImageData);
        }

        private void trueBtn_Click(object sender, EventArgs e)
        {

        }

        private void falseBtn_Click(object sender, EventArgs e)
        {

        }

        private void TrueFalse_Resize(object sender, EventArgs e)
        {
            resize_Control(questionTxtBox, recTxt); 
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
