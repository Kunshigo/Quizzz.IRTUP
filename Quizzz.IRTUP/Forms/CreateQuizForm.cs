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

                    // Debug output
                    MessageBox.Show($"Loading question - Type: {questionType}, No: {questionNo}");

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

                    // Create the appropriate question control
                    if (questionType == "Multiple Choice")
                    {
                        MultipleChoice quizPage = new MultipleChoice();
                        quizPage.QuestionID = Convert.ToInt32(questionRow["QuestionID"]);
                        quizPage.QuestionNo = questionNo;
                        quizPage.questionTxtBox.Text = questionText;

                        // Load choices
                        DataTable choices = db.GetQuestionChoices(quizID, questionNo);
                        if (choices.Rows.Count > 0)
                        {
                            DataRow choiceRow = choices.Rows[0];
                            quizPage.textBox1.Text = choiceRow["Choice1"]?.ToString() ?? "";
                            quizPage.textBox2.Text = choiceRow["Choice2"]?.ToString() ?? "";
                            quizPage.textBox3.Text = choiceRow["Choice3"]?.ToString() ?? "";
                            quizPage.textBox4.Text = choiceRow["Choice4"]?.ToString() ?? "";

                            int correctAnswer = Convert.ToInt32(choiceRow["CorrectAnswer"]);
                            quizPage.SelectCorrectAnswer(correctAnswer - 1);
                        }

                        slides.Add(slide, (quizPage, quizPage.QuestionID, "Multiple Choice"));
                    }
                    else if (questionType == "True or False")
                    {
                        TrueFalse quizPage = new TrueFalse();
                        quizPage.QuestionID = Convert.ToInt32(questionRow["QuestionID"]);
                        quizPage.QuestionNo = questionNo;
                        quizPage.questionTxtBox.Text = questionText;

                        // Load correct answer with type handling
                        DataTable tfData = db.GetTrueFalseQuestion(quizID, questionNo);
                        if (tfData.Rows.Count > 0)
                        {
                            object answerValue = tfData.Rows[0]["CorrectAnswer"];
                            string correctAns = "False"; // Default value

                            if (answerValue != DBNull.Value)
                            {
                                // Handle different possible return types
                                if (answerValue is bool)
                                {
                                    correctAns = (bool)answerValue ? "True" : "False";
                                }
                                else
                                {
                                    correctAns = answerValue.ToString();
                                }
                            }

                            quizPage.CorrectAnswer = correctAns;
                            quizPage.SelectCorrectAnswer(correctAns == "True" ? 0 : 1);
                        }

                        slides.Add(slide, (quizPage, quizPage.QuestionID, "True or False"));
                    }


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
                MessageBox.Show("Error loading questions: " + ex.Message);
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
            if (selectedQuizPanel.Controls.Count == 0) return;

            var selectedSlide = slides.FirstOrDefault(x => x.Value.Control == selectedQuizPanel.Controls[0]).Key;
            if (selectedSlide == null) return;

            string newType = questionTypeComboBox.SelectedItem.ToString();
            var currentSlideData = slides[selectedSlide];

            // Don't change if same type
            if (currentSlideData.QuestionType == newType) return;

            // Get current question data
            string currentQuestionText = "";
            int questionNo = currentSlideData.Control is IQuestion q ? q.QuestionNo : 0;

            if (currentSlideData.Control is MultipleChoice mc)
            {
                currentQuestionText = mc.questionTxtBox.Text;
            }
            else if (currentSlideData.Control is TrueFalse tf)
            {
                currentQuestionText = tf.questionTxtBox.Text;
            }

            // Create new control of the selected type
            UserControl newControl = null;

            switch (newType)
            {
                case "Multiple Choice":
                    newControl = new MultipleChoice();
                    ((MultipleChoice)newControl).questionTxtBox.Text = currentQuestionText;
                    ((MultipleChoice)newControl).QuestionNo = questionNo;
                    break;
                case "True or False":
                    newControl = new TrueFalse();
                    ((TrueFalse)newControl).questionTxtBox.Text = currentQuestionText;
                    ((TrueFalse)newControl).QuestionNo = questionNo;
                    break;
            }

            if (newControl != null)
            {
                // Update the slide in our dictionary with the new type
                slides[selectedSlide] = (newControl, currentSlideData.QuestionID, newType);

                // Update the display
                selectedQuizPanel.Controls.Clear();
                selectedQuizPanel.Controls.Add(newControl);
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
        private Dictionary<FlowLayoutPanel, (UserControl Control, int QuestionID, string QuestionType)> slides =
    new Dictionary<FlowLayoutPanel, (UserControl, int, string)>();

        private void addQuestionBtn_Click(object sender, EventArgs e)
        {
            CreateFlowLayoutPanels();
        }

        private void CreateFlowLayoutPanels()
        {
            int slideNumber = slides.Count + 1;
            string questionType = questionTypeComboBox.Text;

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

            // Create appropriate control
            UserControl quizPage = null;

            switch (questionType)
            {
                case "Multiple Choice":
                    quizPage = new MultipleChoice();
                    ((MultipleChoice)quizPage).QuestionNo = slideNumber;
                    break;
                case "True or False":
                    quizPage = new TrueFalse();
                    ((TrueFalse)quizPage).QuestionNo = slideNumber;
                    break;
            }

            if (quizPage == null) return;

            // Create mini preview
            miniMultipleChoice miniControl = new miniMultipleChoice();
            miniControl.SetSlideNumber(slideNumber);
            miniControl.SlideClicked += (sender, e) => ChangePage(slide);
            slide.Controls.Add(miniControl);

            // Add to dictionary with the correct initial type
            slides.Add(slide, (quizPage, 0, questionType));

            // Add events
            slide.Click += (s, args) => ChangePage(slide);
            slide.MouseEnter += (s, args) => slide.BackColor = Color.LightGray;
            slide.MouseLeave += (s, args) => slide.BackColor = Color.White;

            questionsPanel.Controls.Add(slide);
            ChangePage(slide);
        }

        private void ChangePage(FlowLayoutPanel selectedSlide)
        {
            if (slides.ContainsKey(selectedSlide))
            {
                // Freeze the combobox event handler temporarily
                questionTypeComboBox.SelectedIndexChanged -= questionTypeComboBox_SelectedIndexChanged;

                // Update combobox to match current slide type
                questionTypeComboBox.SelectedItem = slides[selectedSlide].QuestionType;

                // Reattach the event handler
                questionTypeComboBox.SelectedIndexChanged += questionTypeComboBox_SelectedIndexChanged;

                // Show the control
                selectedQuizPanel.Controls.Clear();
                selectedQuizPanel.Controls.Add(slides[selectedSlide].Control);

                // Highlight current slide
                foreach (var slide in slides.Keys)
                {
                    slide.BackColor = slide == selectedSlide ? Color.LightBlue : Color.White;
                }
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
                int questionNo = 0;
                string questionText = "";
                string questionType = entry.Value.QuestionType;

                if (entry.Value.Control is MultipleChoice mc)
                {
                    questionNo = mc.QuestionNo;
                    questionText = mc.questionTxtBox.Text;

                    QuestionData question = new QuestionData
                    {
                        QuizID = quizID,
                        QuestionType = "Multiple Choice",
                        QuestionText = questionText,
                        Choices = new List<string> {
                    mc.textBox1.Text,
                    mc.textBox2.Text,
                    mc.textBox3.Text,
                    mc.textBox4.Text
                },
                        CorrectAnswerIndex = mc.correctAnswerIndex,
                        QuestionNo = questionNo
                    };
                    db.SaveMultipleChoiceQuestion(question, quizID);
                }
                else if (entry.Value.Control is TrueFalse tf)
                {
                    // Ensure QuestionNo is properly set
                    questionNo = tf.QuestionNo;
                    questionText = tf.questionTxtBox.Text;

                    // Debug output to check values before saving
                    MessageBox.Show($"Saving True/False - QNo: {questionNo}, Text: {questionText}, Ans: {tf.CorrectAnswer}");

                    db.SaveTrueFalseQuestion(quizID, questionNo, questionText, tf.CorrectAnswer);
                }
            }

            MessageBox.Show("Quiz Saved Successfully!");
        }

        private void delQuestionBtn_Click(object sender, EventArgs e)
        {
            if (selectedQuizPanel.Controls.Count > 0)
            {
                var control = selectedQuizPanel.Controls[0];

                int qNo = 0, qID = 0;

                if (control is MultipleChoice mc && mc.QuestionID > 0)
                {
                    qNo = mc.QuestionNo;
                    qID = mc.QuestionID;
                }
                else if (control is TrueFalse tf && tf.QuestionID > 0)
                {
                    qNo = tf.QuestionNo;
                    qID = tf.QuestionID;
                }

                if (qID > 0)
                {
                    var confirm = MessageBox.Show("Are you sure you want to delete this question?", "Confirm", MessageBoxButtons.YesNo);
                    if (confirm == DialogResult.Yes)
                    {
                        DatabaseHelper db = new DatabaseHelper();
                        bool deleted = db.DeleteQuestion(quizID, qNo, qID);
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
}

