using Quizzz.IRTUP.Classes;
using Quizzz.IRTUP.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Quizzz.IRTUP.Panels
{
    public partial class ViewQuizzes : UserControl
    {
        private int _studentID;
        private string _studentGradeLevel;
        private Dictionary<string, string> _studentDetails;

        public ViewQuizzes(Dictionary<string, string> studentDetails)
        {
            InitializeComponent();
            this._studentDetails = studentDetails;
            this._studentID = int.Parse(studentDetails["StudentID"]);
            this._studentGradeLevel = studentDetails.ContainsKey("GradeLevel") ? studentDetails["GradeLevel"] : "1";
            InitializeQuizPanels();
            LoadQuizzes();
        }

        private void InitializeQuizPanels()
        {
            // Panel for available quizzes
            //availableQuizzesPanel.FlowDirection = FlowDirection.LeftToRight;
            //availableQuizzesPanel.WrapContents = true;
            //availableQuizzesPanel.BackColor = Color.FromArgb(240, 248, 255);

            // Panel for completed quizzes
            //completedQuizzesPanel.FlowDirection = FlowDirection.LeftToRight;
            //completedQuizzesPanel.WrapContents = true;
            //completedQuizzesPanel.BackColor = Color.FromArgb(240, 255, 240);

            // Initialize filter controls
            InitializeFilterControls();
        }

        private void InitializeFilterControls()
        {
            subjectFilterComboBox.Items.Add("All Subjects");

            DatabaseHelper db = new DatabaseHelper();
            DataTable subjects = db.GetData("SELECT DISTINCT Subject FROM Teachers WHERE Subject IS NOT NULL");

            foreach (DataRow row in subjects.Rows)
            {
                subjectFilterComboBox.Items.Add(row["Subject"].ToString());
            }
            subjectFilterComboBox.SelectedIndex = 0;
            subjectFilterComboBox.SelectedIndexChanged += (s, e) => LoadQuizzes();

            // Difficulty Filter (unchanged)
            difficultyFilterComboBox.Items.Add("All Difficulties");
            difficultyFilterComboBox.Items.AddRange(new[] { "Easy", "Medium", "Hard" });
            difficultyFilterComboBox.SelectedIndex = 0;
            difficultyFilterComboBox.SelectedIndexChanged += (s, e) => LoadQuizzes();
        }

        private void LoadQuizzes()
        {
            availableQuizzesPanel.Controls.Clear();
            completedQuizzesPanel.Controls.Clear();

            string subjectFilter = subjectFilterComboBox.SelectedItem?.ToString();
            string difficultyFilter = difficultyFilterComboBox.SelectedItem?.ToString();

            DatabaseHelper db = new DatabaseHelper();

            // Build the query dynamically based on filters
            string query = @"SELECT q.QuizID, q.Title, q.Subject, q.Difficulty, q.CreatedDate, t.Username AS TeacherName
                    FROM Quizzes q
                    INNER JOIN Teachers t ON q.TeacherID = t.TeacherID
                    WHERE q.GradeLevel = ?";

            List<OleDbParameter> parameters = new List<OleDbParameter>
    {
        new OleDbParameter("@GradeLevel", OleDbType.VarChar) { Value = _studentGradeLevel }
    };

            // Add subject filter if not "All Subjects"
            if (subjectFilter != "All Subjects")
            {
                query += " AND q.Subject = ?";
                parameters.Add(new OleDbParameter("@Subject", OleDbType.VarChar) { Value = subjectFilter });
            }

            // Add difficulty filter if not "All Difficulties"
            if (difficultyFilter != "All Difficulties")
            {
                query += " AND q.Difficulty = ?";
                parameters.Add(new OleDbParameter("@Difficulty", OleDbType.VarChar) { Value = difficultyFilter });
            }

            query += " ORDER BY q.CreatedDate DESC";

            DataTable quizzes = db.GetData(query, parameters.ToArray());

            // Rest of the method remains the same...
            DataTable completedQuizzes = db.GetData(
                "SELECT QuizID, CompletedDate FROM CompletedQuizzes WHERE StudentID = ?",
                new OleDbParameter("@StudentID", _studentID));

            foreach (DataRow quiz in quizzes.Rows)
            {
                int quizID = Convert.ToInt32(quiz["QuizID"]);
                string title = quiz["Title"].ToString();
                string subject = quiz["Subject"].ToString();
                string difficulty = quiz["Difficulty"].ToString();
                DateTime createdDate = SafeDate(quiz["CreatedDate"]);

                bool isCompleted = completedQuizzes.AsEnumerable()
                    .Any(row => Convert.ToInt32(row["QuizID"]) == quizID);
                DateTime? completedDate = isCompleted ?
                    SafeDate(completedQuizzes.AsEnumerable()
                        .First(row => Convert.ToInt32(row["QuizID"]) == quizID)["CompletedDate"])
                    : (DateTime?)null;

                CreateQuizCard(quizID, title, subject, difficulty, createdDate, isCompleted, completedDate);
            }
        }


        private void CreateQuizCard(int quizID, string title, string subject, string difficulty, DateTime createdDate, bool isCompleted, DateTime? completedDate = null)
        {
            Panel quizPanel = new Panel
            {
                Width = 200,
                Height = 200, // Increased height to accommodate extra label
                Padding = new Padding(10),
                Margin = new Padding(10),
                BackColor = isCompleted ? Color.FromArgb(230, 255, 230) : Color.FromArgb(230, 240, 255),
                BorderStyle = BorderStyle.FixedSingle,
                Tag = quizID
            };

            Label titleLabel = new Label
            {
                Text = title,
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Century Gothic", 11, FontStyle.Bold),
                ForeColor = Color.DarkSlateBlue,
                Height = 40
            };

            Label subjectLabel = new Label
            {
                Text = $"Subject: {subject}",
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = new Font("Century Gothic", 9),
                ForeColor = Color.DimGray,
                Height = 20
            };

            Label difficultyLabel = new Label
            {
                Text = $"Difficulty: {difficulty}",
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = new Font("Century Gothic", 9),
                ForeColor = Color.DimGray,
                Height = 20
            };

            Label dateLabel = new Label
            {
                Text = $"Created: {createdDate:MMM dd, yyyy}",
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleLeft,
                Font = new Font("Century Gothic", 8, FontStyle.Italic),
                ForeColor = Color.Gray,
                Height = 20
            };

            // Add completed date label if the quiz is completed
            if (isCompleted && completedDate.HasValue)
            {
                Label completedDateLabel = new Label
                {
                    Text = $"Completed: {completedDate.Value:MMM dd, yyyy}",
                    Dock = DockStyle.Top,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Font = new Font("Century Gothic", 8, FontStyle.Italic),
                    ForeColor = Color.Green,
                    Height = 20
                };
                quizPanel.Controls.Add(completedDateLabel);
            }

            Button actionButton = new Button
            {
                Text = isCompleted ? "View Results" : "Take Quiz",
                Dock = DockStyle.Bottom,
                Tag = quizID,
                BackColor = isCompleted ? Color.MediumSeaGreen : Color.RoyalBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Height = 35,
                Cursor = Cursors.Hand
            };
            actionButton.FlatAppearance.BorderSize = 0;
            actionButton.Click += (s, e) => QuizButton_Click(quizID, isCompleted);

            quizPanel.Controls.Add(actionButton);
            quizPanel.Controls.Add(dateLabel);
            quizPanel.Controls.Add(difficultyLabel);
            quizPanel.Controls.Add(subjectLabel);
            quizPanel.Controls.Add(titleLabel);

            if (isCompleted)
                completedQuizzesPanel.Controls.Add(quizPanel);
            else
                availableQuizzesPanel.Controls.Add(quizPanel);
        }

        private void QuizButton_Click(int quizID, bool isCompleted)
        {
            if (isCompleted)
            {
                // Show quiz results
                MessageBox.Show($"Showing results for quiz ID: {quizID}");
            }
            else
            {
                // Start the quiz
                TakeQuizForm takeQuiz = new TakeQuizForm(quizID, _studentID);
                if (takeQuiz.ShowDialog() == DialogResult.OK)
                {
                    LoadQuizzes();
                }
            }
        }

        private DateTime SafeDate(object value)
        {
            return value != DBNull.Value ? Convert.ToDateTime(value) : DateTime.MinValue;
        }
    }
}
