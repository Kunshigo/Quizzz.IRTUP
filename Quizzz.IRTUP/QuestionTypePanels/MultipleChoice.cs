using Quizzz.IRTUP.Classes;
using Quizzz.IRTUP.Panels;
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
    public partial class MultipleChoice : UserControl
    {
        private Size formOriginalSize;
        private Rectangle recTxt;
        public string QuestionText { get; set; }
        public int QuestionID { get; set; }
        public string QuestionType { get; set; } = "Multiple Choice";
        private int correctAnswerIndex = -1; // 0 = A, 1 = B, 2 = C, 3 = D


        public MultipleChoice()
        {
            InitializeComponent();

            button1.Click += (s, e) => SelectCorrectAnswer(0);
            button2.Click += (s, e) => SelectCorrectAnswer(1);
            button3.Click += (s, e) => SelectCorrectAnswer(2);
            button4.Click += (s, e) => SelectCorrectAnswer(3);
            this.Resize += MultipleChoice_Resize;
            formOriginalSize = this.Size;
            recTxt = new Rectangle(questionTxtBox.Location, questionTxtBox.Size);
        }

        private void SelectCorrectAnswer(int index)
        {
            correctAnswerIndex = index;

            // Reset all button borders
            button1.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.BorderSize = 0;
            button3.FlatAppearance.BorderSize = 0;
            button4.FlatAppearance.BorderSize = 0;

            // Highlight the selected one
            Button[] buttons = { button1, button2, button3, button4 };
            buttons[index].FlatAppearance.BorderSize = 3;
            buttons[index].FlatAppearance.BorderColor = Color.Green;

            MessageBox.Show($"CorrectAnswerIndex = {correctAnswerIndex}");
        }

        public QuestionData GetQuestionData()
        {
            return new QuestionData
            {
                QuestionID = this.QuestionID, // THIS LINE IS CRUCIAL
                QuestionText = questionTxtBox.Text,
                QuestionType = "Multiple Choice",
                Choices = new string[]
        {
            textBox1.Text,
            textBox2.Text,
            textBox3.Text,
            textBox4.Text
        },
                CorrectAnswerIndex = correctAnswerIndex
            };
        }

        private void MultipleChoice_Resize(object sender, EventArgs e)
        {
            resize_Control(questionTxtBox, recTxt);
        }

        private void resize_Control(Control c, Rectangle r)
        {
            float xRatio = (float)(this.Width) / (float)(formOriginalSize.Width);
            float yRatio = (float)(this.Height) / (float)(formOriginalSize.Height);
            int newX = (int)(r.X * xRatio);
            int newY = (int)(r.Y * yRatio);

            int newWidth = (int)(r.Width * xRatio);
            int newHeight = (int)(r.Height * yRatio);

            c.Location = new Point(newX, newY);
            c.Size = new Size(newWidth, newHeight);

        }

        protected override void WndProc(ref Message m)
        {
            const int WM_NCHITTEST = 0x0084;
            const int HTTRANSPARENT = -1;

            if (m.Msg == WM_NCHITTEST)
            {
                m.Result = (IntPtr)HTTRANSPARENT;
                return;
            }
            base.WndProc(ref m);
        }


    }
}
