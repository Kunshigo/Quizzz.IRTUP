using AntdUI.In;
using Quizzz.IRTUP.Classes;
using Quizzz.IRTUP.Forms;
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

namespace Quizzz.IRTUP.Panels
{
    public partial class resultsViewer : UserControl
    {
        private Dictionary<string, string> _teacherDetails;
        public resultsViewer(Dictionary<string, string> teacherDetails)
        {
            InitializeComponent();
            this._teacherDetails = teacherDetails;
            txtSearch.TextChanged += (s, e) => LoadTeacherQuizzes();
            cmbSort.SelectedIndexChanged += (s, e) => LoadTeacherQuizzes();
            LoadTeacherQuizzes();
        }

        // Modified LoadTeacherQuizzes method with filtering and sorting
        private void LoadTeacherQuizzes()
        {
            answersPanel.Controls.Clear();

            int teacherID = int.Parse(_teacherDetails["TeacherID"]);
            DatabaseHelper db = new DatabaseHelper();

            // Get filter values
            string searchText = txtSearch?.Text?.Trim() ?? string.Empty;
            string sortOption = cmbSort?.SelectedItem?.ToString() ?? "Newest First";

            // Build the base query
            string query = @"SELECT q.QuizID, q.Title, q.Subject, q.CreatedDate
                    FROM Quizzes q
                    WHERE q.TeacherID = @TeacherID";

            // Add search filter
            if (!string.IsNullOrEmpty(searchText))
            {
                query += " AND q.Title LIKE @SearchText";
            }

            // Add sorting
            switch (sortOption)
            {
                case "Title A-Z":
                    query += " ORDER BY q.Title ASC";
                    break;
                case "Title Z-A":
                    query += " ORDER BY q.Title DESC";
                    break;
                case "Newest First":
                    query += " ORDER BY q.CreatedDate DESC";
                    break;
                case "Oldest First":
                    query += " ORDER BY q.CreatedDate ASC";
                    break;
            }

            // Prepare parameters
            List<OleDbParameter> parameters = new List<OleDbParameter>
    {
        new OleDbParameter("@TeacherID", teacherID)
    };

            if (!string.IsNullOrEmpty(searchText))
            {
                parameters.Add(new OleDbParameter("@SearchText", "%" + searchText + "%"));
            }

            DataTable quizzes = db.GetData(query, parameters.ToArray());

            foreach (DataRow row in quizzes.Rows)
            {
                int quizID = Convert.ToInt32(row["QuizID"]);
                string title = row["Title"].ToString();
                string subject = row["Subject"].ToString();

                Panel quizCard = new Panel
                {
                    Width = 250,
                    Height = 100,
                    Margin = new Padding(10),
                    BackColor = Color.White,
                    BorderStyle = BorderStyle.FixedSingle,
                    Tag = quizID
                };

                Label titleLabel = new Label
                {
                    Text = title,
                    Font = new Font("Century Gothic", 10, FontStyle.Bold),
                    Location = new Point(10, 10),
                    AutoSize = true
                };

                Label subjectLabel = new Label
                {
                    Text = "Subject: " + subject,
                    Font = new Font("Century Gothic", 9),
                    Location = new Point(10, 35),
                    AutoSize = true
                };

                Button viewBtn = new Button
                {
                    Text = "View Students",
                    Width = 110,
                    Height = 30,
                    Location = new Point(10, 60),
                    BackColor = Color.MediumSlateBlue,
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Cursor = Cursors.Hand
                };
                viewBtn.Click += (s, e) => ShowStudentResults(quizID, title);

                quizCard.Controls.Add(titleLabel);
                quizCard.Controls.Add(subjectLabel);
                quizCard.Controls.Add(viewBtn);

                answersPanel.Controls.Add(quizCard);
            }
        }

        private void ShowStudentResults(int quizID, string quizTitle)
        {
            answersPanel.Controls.Clear();

            DatabaseHelper db = new DatabaseHelper();
            DataTable attempts = db.GetCompletedAttemptsForQuiz(quizID);

            Label header = new Label
            {
                Text = $"Results for: {quizTitle}",
                Font = new Font("Century Gothic", 12, FontStyle.Bold),
                ForeColor = Color.DarkSlateBlue,
                AutoSize = true,
                Location = new Point(10, 10)
            };
            answersPanel.Controls.Add(header);

            int y = 50;

            foreach (DataRow row in attempts.Rows)
            {
                string studentName = row["Username"].ToString();
                int score = Convert.ToInt32(row["Score"]);
                DateTime date = Convert.ToDateTime(row["CompletedDate"]);

                Panel studentCard = new Panel
                {
                    Width = 450,
                    Height = 60,
                    Location = new Point(10, y),
                    BackColor = Color.WhiteSmoke,
                    BorderStyle = BorderStyle.FixedSingle
                };

                Label nameLbl = new Label
                {
                    Text = $"Student: {studentName}",
                    Font = new Font("Century Gothic", 9, FontStyle.Bold),
                    Location = new Point(10, 10),
                    AutoSize = true
                };

                Label scoreLbl = new Label
                {
                    Text = $"Score: {score}",
                    Font = new Font("Century Gothic", 9),
                    Location = new Point(10, 30),
                    AutoSize = true
                };

                Label dateLbl = new Label
                {
                    Text = $"Completed: {date:MMM dd, yyyy hh:mm tt}",
                    Font = new Font("Century Gothic", 9, FontStyle.Italic),
                    Location = new Point(200, 30),
                    AutoSize = true
                };

                studentCard.Controls.Add(nameLbl);
                studentCard.Controls.Add(scoreLbl);
                studentCard.Controls.Add(dateLbl);

                answersPanel.Controls.Add(studentCard);
                y += 70;
            }

            // Back button
            Button backBtn = new Button
            {
                Text = "Back",
                Width = 80,
                Height = 30,
                Location = new Point(10, y + 10),
                BackColor = Color.SlateGray,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            backBtn.Click += (s, e) => LoadTeacherQuizzes();
            answersPanel.Controls.Add(backBtn);
        }
    }
}
