using Quizzz.IRTUP.Classes;
using Quizzz.IRTUP.Panels;
using Quizzz.IRTUP.QuestionTypePanels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Quizzz.IRTUP.Forms.CreateQuizForm;

namespace Quizzz.IRTUP.Forms
{
    public partial class CreateQuizForm : Form
    {
        private Rectangle recPanel;
        private int quizID;
        private int questionID;

        public CreateQuizForm(int quizID)
        {
            InitializeComponent();
            this.quizID = quizID;
            questionTypeComboBox.SelectedItem = "Multiple Choice";
            this.Resize += CreateQuizForm_Resize;

            if (quizID > 0)
            {
                LoadQuizQuestions(quizID);
            }
            else
            {
                CreateFlowLayoutPanels();
            }
        }

        private void LoadQuizQuestions(int quizID)
        {
            try
            {
                DatabaseHelper db = new DatabaseHelper();
                DataTable questions = db.GetQuizQuestions(quizID);

                questionsPanel.Controls.Clear();
                questionsPanel.Controls.Add(addQuestionBtn);
                slides.Clear();

                foreach (DataRow questionRow in questions.Rows)
                {
                    int questionNo = Convert.ToInt32(questionRow["QuestionNo"]);
                    string questionText = questionRow["QuestionText"].ToString();
                    string questionType = questionRow["QuestionType"].ToString();

                    // Create the question panel
                    FlowLayoutPanel slide = new FlowLayoutPanel
                    {
                        Size = new Size(131, 88),
                        BorderStyle = BorderStyle.FixedSingle,
                        BackColor = Color.White,
                        Cursor = Cursors.Hand,
                        WrapContents = false,
                        Dock = DockStyle.Left,
                        FlowDirection = FlowDirection.TopDown
                    };

                    // Create mini preview
                    miniMultipleChoice miniControl = new miniMultipleChoice();
                    miniControl.SetSlideNumber(questionNo);
                    miniControl.SlideClicked += (sender, e) => ChangePage(slide);
                    slide.Controls.Add(miniControl);

                    // Create the main question control
                    MultipleChoice quizPage = new MultipleChoice();
                    quizPage.QuestionID = Convert.ToInt32(questionRow["QuestionID"]);
                    quizPage.QuestionNo = questionNo;
                    quizPage.questionTxtBox.Text = questionText;

                    // Load choices - IMPORTANT FIXES HERE
                    DataTable choices = db.GetQuestionChoices(quizID, questionNo);
                    if (choices.Rows.Count > 0)
                    {
                        DataRow choiceRow = choices.Rows[0];

                        // Set choice texts
                        quizPage.textBox1.Text = choiceRow["Choice1"]?.ToString() ?? "";
                        quizPage.textBox2.Text = choiceRow["Choice2"]?.ToString() ?? "";
                        quizPage.textBox3.Text = choiceRow["Choice3"]?.ToString() ?? "";
                        quizPage.textBox4.Text = choiceRow["Choice4"]?.ToString() ?? "";

                        // Set correct answer (convert from 1-based to 0-based index)
                        int correctAnswer = Convert.ToInt32(choiceRow["CorrectAnswer"]);
                        quizPage.correctAnswerIndex = correctAnswer - 1;

                        // Highlight the correct answer button
                        Button[] buttons = { quizPage.button1, quizPage.button2,
                                   quizPage.button3, quizPage.button4 };

                        // Reset all buttons first
                        foreach (var btn in buttons)
                        {
                            btn.FlatAppearance.BorderSize = 0;
                        }

                        // Highlight correct answer if valid index
                        if (quizPage.correctAnswerIndex >= 0 && quizPage.correctAnswerIndex < buttons.Length)
                        {
                            buttons[quizPage.correctAnswerIndex].FlatAppearance.BorderSize = 3;
                            buttons[quizPage.correctAnswerIndex].FlatAppearance.BorderColor = Color.Green;
                        }
                    }

                    slides.Add(slide, (quizPage, quizPage.QuestionID));

                    // Add events
                    slide.Click += (s, args) => ChangePage(slide);
                    slide.MouseEnter += (s, args) => slide.BackColor = Color.LightGray;
                    slide.MouseLeave += (s, args) => slide.BackColor = Color.White;

                    questionsPanel.Controls.Add(slide);
                }

                if (questions.Rows.Count > 0)
                {
                    ChangePage(questionsPanel.Controls[0] as FlowLayoutPanel);
                }
            }
            catch (Exception ex)
            {
            }
        }


        private void maximizeBtn_Click(object sender, EventArgs e)
        {
            //hey
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void miniPanel()
        {

        }

        private void quizScreen()
        {
            if (questionTypeComboBox.SelectedItem == "Multiple Choice")
            {
                MultipleChoice multipleChoice = new MultipleChoice();
                selectedQuizPanel.Controls.Clear();
                selectedQuizPanel.Controls.Add(multipleChoice);
            }
        }

        private void questionTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            quizScreen();
            miniPanel();

            if (WindowState == FormWindowState.Maximized)
            {
                ResizeQuestionsPanel();
                ResizeSelectedQuizPanel();
            }

        }

        private void ResizeSelectedQuizPanel()
        {
            selectedQuizPanel.Width = this.ClientSize.Width - 20;
            selectedQuizPanel.Height = this.ClientSize.Height - 20;

            foreach (Control control in selectedQuizPanel.Controls)
            {
                if (control is MultipleChoice multipleChoice)
                {
                    multipleChoice.Width = selectedQuizPanel.ClientSize.Width - 10;
                    multipleChoice.Height = selectedQuizPanel.ClientSize.Height - 10;

                    multipleChoice.Refresh();
                }
            }

            selectedQuizPanel.Refresh();
        }

        private void selectedQuizPanel_Resize(object sender, EventArgs e)
        {
            selectedQuizPanel.Dock = DockStyle.Fill;

            foreach (Control control in selectedQuizPanel.Controls)
            {
                if (control is MultipleChoice multiplechoice)
                {
                    multiplechoice.Width = selectedQuizPanel.ClientSize.Width;
                    multiplechoice.Height = selectedQuizPanel.ClientSize.Height;

                    multiplechoice.Refresh();
                }
            }

            selectedQuizPanel.Refresh();
        }

        private void ResizeQuestionsPanel()
        {
            if (WindowState == FormWindowState.Maximized)
            {
                // Apply maximized panel size
                float panelHeightRatio = 0.15f;  // 15% of form height
                int newHeight = (int)(this.ClientSize.Height * panelHeightRatio);
                newHeight = Math.Max(100, Math.Min(300, newHeight));  // Constrain height
                questionsPanel.Height = newHeight;
            }
            else
            {
                // Keep the original size when not maximized
                questionsPanel.Height = 88;  // Original height
            }

            // Refresh the panel
            questionsPanel.Refresh();
        }

        private void CreateQuizForm_Resize(object sender, EventArgs e)
        {

            if (WindowState == FormWindowState.Maximized)
            {
                // Resize only when maximized
                float panelHeightRatio = 0.15f;  // 15% of form height
                int newHeight = (int)(this.ClientSize.Height * panelHeightRatio);
                newHeight = Math.Max(100, Math.Min(300, newHeight));  // Constrain height
                questionsPanel.Height = newHeight;
            }
            else
            {
                // Keep the original size when not maximized
                questionsPanel.Height = 88;  // Original height
            }


            // Refresh the panel to apply changes
            questionsPanel.Refresh();
        }

        private int originalMiniPanelWidth;
        private int originalMiniPanelHeight;

        private void questionsPanel_Resize(object sender, EventArgs e)
        {

        }

        private int originalUserControlWidth;
        private int originalUserControlHeight;

        private void miniQuestionPanel_Resize(object sender, EventArgs e)
        {

        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private int slideIndex = 0;
        private Dictionary<FlowLayoutPanel, (UserControl Control, int QuestionID)> slides = new Dictionary<FlowLayoutPanel, (UserControl, int)>();

        private void addQuestionBtn_Click(object sender, EventArgs e)
        {
            CreateFlowLayoutPanels();
        }



        private void CreateFlowLayoutPanels()
        {
            int slideNumber = questionsPanel.Controls.Count; // Determine the slide number

            FlowLayoutPanel slide = new FlowLayoutPanel
            {
                Size = new Size(131, 88),
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White,
                Cursor = Cursors.Hand,
                WrapContents = false,
                Dock = DockStyle.Left,
                FlowDirection = FlowDirection.TopDown
            };

            // Create the mini preview UserControl
            miniMultipleChoice miniControl = new miniMultipleChoice();
            miniControl.SetSlideNumber(slideNumber); // Ensure the UserControl updates its number

            miniControl.SlideClicked += (sender, e) => ChangePage(slide);

            // Add the mini preview to the slide
            slide.Controls.Add(miniControl);
            string questionType = questionTypeComboBox.Text;
            // Create a unique UserControl for this slide
            MultipleChoice quizPage = new MultipleChoice();
            quizPage.QuestionID = 0;
            quizPage.QuestionNo = slideNumber;


            slides.Add(slide, (quizPage, 0));

            // Add click event to select slide
            slide.Click += (s, args) =>
            {
                ChangePage(slide);
            };

            // Add hover effect
            slide.MouseEnter += (s, args) =>
            {
                if (slide.BackColor != Color.LightBlue)
                {
                    slide.BackColor = Color.LightGray; // Highlight when hovering
                }
            };

            slide.MouseLeave += (s, args) =>
            {
                if (slide.BackColor != Color.LightBlue)
                {
                    slide.BackColor = Color.White; // Restore when not hovering
                }
            };

            // Add the slide to the main panel
            questionsPanel.Controls.Add(slide);

            ResizeQuestionsPanel();
            ScrollToLastSlide();
        }

        private void ChangePage(FlowLayoutPanel selectedSlide)
        {
            if (slides.ContainsKey(selectedSlide))
            {
                selectedQuizPanel.Controls.Clear();
                selectedQuizPanel.Controls.Add(slides[selectedSlide].Control);
            }
        }

        private void Slide_Click(object sender, EventArgs e)
        {
            if (sender is FlowLayoutPanel clickedSlide)
            {
                // Scroll to the clicked slide
                questionsPanel.AutoScrollPosition = new Point(clickedSlide.Left, 0);
            }
        }

        private void ScrollToLastSlide()
        {
            if (questionsPanel.Controls.Count > 0)
            {
                Control lastSlide = questionsPanel.Controls[questionsPanel.Controls.Count - 1];
                questionsPanel.AutoScrollPosition = new Point(lastSlide.Left, 0);
            }
        }

        private void saveQuizBtn_Click(object sender, EventArgs e)
        {
            DatabaseHelper db = new DatabaseHelper();

            foreach (var entry in slides)
            {
                if (entry.Value.Control is MultipleChoice mcControl)
                {
                    // Create a data object
                    QuestionData question = new QuestionData
                    {
                        QuizID = quizID,
                        QuestionType = mcControl.QuestionType,
                        QuestionText = mcControl.QuestionText,
                        Choices = mcControl.GetChoices().ToList(),
                        CorrectAnswerIndex = mcControl.CorrectAnswerIndex,
                        QuestionNo = mcControl.QuestionNo // Add question number
                    };

                    db.SaveMultipleChoiceQuestion(question, quizID);
                }

            }

            MessageBox.Show("Quiz Saved Successfully!");
        }

        private void delQuestionBtn_Click(object sender, EventArgs e)
        {
            if (selectedQuizPanel.Controls.Count > 0 &&
                selectedQuizPanel.Controls[0] is MultipleChoice mc &&
                mc.QuestionID > 0)
            {
                var confirm = MessageBox.Show("Are you sure you want to delete this question?", "Confirm", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    DatabaseHelper db = new DatabaseHelper();
                    bool deleted = db.DeleteQuestion(quizID, mc.QuestionNo, mc.QuestionID);
                    if (deleted)
                    {
                        MessageBox.Show("Question deleted.");
                        LoadQuizQuestions(quizID);
                    }
                }
            }
        }
    }
}

