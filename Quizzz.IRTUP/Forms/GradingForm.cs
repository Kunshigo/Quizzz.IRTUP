using AntdUI.In;
using Quizzz.IRTUP.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quizzz.IRTUP.Forms
{
    public partial class GradingForm : Form
    {
        private int _quizID;
        private int _studentID;
        private DatabaseHelper _dbHelper;
        private DataTable _ungradedQuestions;

        public GradingForm(int quizID, int studentID)
        {
            InitializeComponent();
            _quizID = quizID;
            _studentID = studentID;
            _dbHelper = new DatabaseHelper();

            InitializeForm();
            LoadUngradedQuestions();
        }

        private void InitializeForm()
        {
            this.Text = $"Grade Student Answers - Quiz ID: {_quizID}";
            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            // Add controls
            var lblTitle = new Label
            {
                Text = $"Grading Answers for Student ID: {_studentID}",
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 12, FontStyle.Bold),
                Height = 40
            };

            var questionsList = new ListView
            {
                Dock = DockStyle.Left,
                Width = 300,
                View = View.Details,
                FullRowSelect = true,
                MultiSelect = false
            };
            questionsList.Columns.Add("Question", 280);
            questionsList.SelectedIndexChanged += QuestionsList_SelectedIndexChanged;

            var pnlQuestion = new Panel
            {
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.FixedSingle,
                Padding = new Padding(10)
            };

            var splitContainer = new SplitContainer
            {
                Dock = DockStyle.Fill,
                Orientation = Orientation.Horizontal
            };

            var lblQuestionText = new Label
            {
                Dock = DockStyle.Top,
                AutoSize = true,
                Font = new Font("Arial", 10, FontStyle.Bold)
            };

            var txtStudentAnswer = new TextBox
            {
                Dock = DockStyle.Top,
                Multiline = true,
                Height = 150,
                ScrollBars = ScrollBars.Vertical,
                ReadOnly = true
            };

            var lblScore = new Label
            {
                Text = "Score:",
                Dock = DockStyle.Top,
                Margin = new Padding(0, 10, 0, 0)
            };

            var numScore = new NumericUpDown
            {
                Dock = DockStyle.Top,
                Minimum = 0,
                Maximum = 100,
                Value = 0
            };

            var btnSave = new Button
            {
                Text = "Save Grade",
                Dock = DockStyle.Bottom,
                Height = 40
            };
            btnSave.Click += btnSave_Click;

            splitContainer.Panel1.Controls.Add(lblQuestionText);
            splitContainer.Panel1.Controls.Add(txtStudentAnswer);
            splitContainer.Panel2.Controls.Add(lblScore);
            splitContainer.Panel2.Controls.Add(numScore);
            splitContainer.Panel2.Controls.Add(btnSave);

            pnlQuestion.Controls.Add(splitContainer);

            var mainSplit = new SplitContainer
            {
                Dock = DockStyle.Fill
            };
            mainSplit.Panel1.Controls.Add(questionsList);
            mainSplit.Panel2.Controls.Add(pnlQuestion);

            this.Controls.Add(mainSplit);
            this.Controls.Add(lblTitle);

            // Store controls for later use
            this.Tag = new
            {
                QuestionsList = questionsList,
                QuestionTextLabel = lblQuestionText,
                StudentAnswerTextBox = txtStudentAnswer,
                ScoreNumeric = numScore,
                SaveButton = btnSave
            };
        }

        private void LoadUngradedQuestions()
        {
            var answers = _dbHelper.GetStudentAnswers(_quizID, _studentID);
            var ungradedRows = answers.AsEnumerable()
                .Where(row => row["IsGraded"] == DBNull.Value || Convert.ToInt32(row["IsGraded"]) == 0)
                .ToList(); // Convert to List first to check count

            var controls = (dynamic)this.Tag;
            controls.QuestionsList.Items.Clear();

            if (ungradedRows.Count == 0)
            {
                MessageBox.Show("No ungraded questions found for this student.");
                this.Close(); // Close the grading form if no questions need grading
                return;
            }

            // Now we can safely create a DataTable since we know we have rows
            _ungradedQuestions = ungradedRows.CopyToDataTable();

            foreach (DataRow row in _ungradedQuestions.Rows)
            {
                controls.QuestionsList.Items.Add(new ListViewItem($"Question {row["QuestionNo"]}"));
            }

            if (controls.QuestionsList.Items.Count > 0)
            {
                controls.QuestionsList.Items[0].Selected = true;
            }
        }

        private void QuestionsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var controls = (dynamic)this.Tag;
            if (controls.QuestionsList.SelectedItems.Count == 0) return;

            int selectedIndex = controls.QuestionsList.SelectedIndices[0];
            DataRow question = _ungradedQuestions.Rows[selectedIndex];

            controls.QuestionTextLabel.Text = question["QuestionText"].ToString();
            controls.StudentAnswerTextBox.Text = question["StudentAnswer"].ToString();
            controls.ScoreNumeric.Value = 0; // Reset score when changing questions
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var controls = (dynamic)this.Tag;
            if (controls.QuestionsList.SelectedItems.Count == 0) return;

            int selectedIndex = controls.QuestionsList.SelectedIndices[0];
            DataRow question = _ungradedQuestions.Rows[selectedIndex];

            int questionNo = Convert.ToInt32(question["QuestionNo"]);
            int score = (int)controls.ScoreNumeric.Value;

            // Update the score in the database
            bool success = _dbHelper.ExecuteQuery(
                "UPDATE OpenEndedAnswers SET Score = @Score, IsGraded = -1 " +
                "WHERE QuizID = @QuizID AND QuestionNo = @QuestionNo AND StudentID = @StudentID",
                new OleDbParameter("@Score", score),
                new OleDbParameter("@QuizID", _quizID),
                new OleDbParameter("@QuestionNo", questionNo),
                new OleDbParameter("@StudentID", _studentID));

            if (success)
            {
                MessageBox.Show("Score saved successfully!");
                LoadUngradedQuestions(); // Refresh the list
            }
            else
            {
                MessageBox.Show("Failed to save score. Please try again.");
            }
        }

    }
}
