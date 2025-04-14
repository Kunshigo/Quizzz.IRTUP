using AntdUI.In;
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

namespace Quizzz.IRTUP.Panels
{
    public partial class resultsViewer : UserControl
    {
        private Dictionary<string, string> _teacherDetails;
        public resultsViewer(Dictionary<string, string> teacherDetails)
        {
            InitializeComponent();
            _teacherDetails = teacherDetails;
            cmbStatus.SelectedIndex = 0;
            cmbSort.SelectedIndex = 0;
            LoadQuizzesIntoPanels();
            txtSearch.TextChanged += (s, e) => LoadQuizzesIntoPanels();
            cmbStatus.SelectedIndexChanged += (s, e) => LoadQuizzesIntoPanels();
            cmbSort.SelectedIndexChanged += (s, e) => LoadQuizzesIntoPanels();
        }

        private void LoadQuizzesIntoPanels()
        {
            answersPanel.Controls.Clear();
            resultsPanel.Controls.Clear();

            int teacherID = int.Parse(_teacherDetails["TeacherID"]);
            DatabaseHelper db = new DatabaseHelper();
            DataTable quizzes = db.GetTeacherQuizzes(teacherID);

            string searchTerm = txtSearch.Text.Trim().ToLower();
            string statusFilter = cmbStatus.SelectedItem?.ToString();
            string sortOption = cmbSort.SelectedItem?.ToString();

            // Filter
            var filtered = quizzes.AsEnumerable().Where(row =>
            {
                string title = row["Title"].ToString().ToLower();
                bool titleMatches = title.Contains(searchTerm);

                if (!titleMatches)
                    return false;

                // Status filtering will be applied later
                return true;
            });

            // Sort
            switch (sortOption)
            {
                case "Title A-Z":
                    filtered = filtered.OrderBy(r => r["Title"].ToString());
                    break;
                case "Title Z-A":
                    filtered = filtered.OrderByDescending(r => r["Title"].ToString());
                    break;
                case "Newest First":
                    filtered = filtered.OrderByDescending(r => Convert.ToDateTime(r["CreatedDate"]));
                    break;
                case "Oldest First":
                    filtered = filtered.OrderBy(r => Convert.ToDateTime(r["CreatedDate"]));
                    break;
            }

            foreach (var row in filtered)
            {
                int quizID = Convert.ToInt32(row["QuizID"]);
                string title = row["Title"].ToString();
                string subject = row["Subject"].ToString();

                DataTable results = db.GetQuizResults(quizID);
                bool hasUngraded = results.AsEnumerable().Any(r => Convert.ToInt32(r["UngradedCount"]) > 0);

                // Apply status filter now
                if (statusFilter == "Needs Grading" && !hasUngraded) continue;
                if (statusFilter == "Graded" && hasUngraded) continue;

                var quizCard = CreateQuizCard(quizID, title, subject, hasUngraded);

                if (hasUngraded)
                    answersPanel.Controls.Add(quizCard);
                else
                    resultsPanel.Controls.Add(quizCard);
            }
        }

        private Panel CreateQuizCard(int quizID, string title, string subject, bool hasUngraded)
        {
            var card = new Panel
            {
                Width = 200,
                Height = 160,
                Margin = new Padding(10),
                BackColor = Color.FromArgb(240, 250, 240),
                BorderStyle = BorderStyle.FixedSingle,
                Tag = quizID
            };

            var lblTitle = new Label
            {
                Text = title,
                Font = new Font("Century Gothic", 11, FontStyle.Bold),
                Dock = DockStyle.Top,
                Height = 40,
                TextAlign = ContentAlignment.MiddleCenter
            };

            var lblSubject = new Label
            {
                Text = $"Subject: {subject}",
                Font = new Font("Century Gothic", 9),
                Dock = DockStyle.Top,
                Height = 20,
                TextAlign = ContentAlignment.MiddleCenter
            };

            var lblStatus = new Label
            {
                Text = hasUngraded ? "⚠ Needs Grading" : "✔ Fully Graded",
                ForeColor = hasUngraded ? Color.IndianRed : Color.SeaGreen,
                Font = new Font("Century Gothic", 9, FontStyle.Italic),
                Dock = DockStyle.Top,
                Height = 20,
                TextAlign = ContentAlignment.MiddleCenter
            };

            var btnView = new Button
            {
                Text = "View Results",
                Dock = DockStyle.Bottom,
                Height = 30,
                BackColor = Color.MediumSeaGreen,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Tag = quizID
            };

            ToolTip tip = new ToolTip();
            tip.SetToolTip(card, $"{title}\nUngraded: {(hasUngraded ? "Yes" : "No")}");

            btnView.FlatAppearance.BorderSize = 0;
            btnView.Click += (s, e) => ShowStudentResults((int)((Button)s).Tag);

            card.Controls.Add(btnView);
            card.Controls.Add(lblStatus);
            card.Controls.Add(lblSubject);
            card.Controls.Add(lblTitle);
            return card;
        }

        private class StudentResultTag
        {
            public int StudentID { get; set; }
            public bool HasUngraded { get; set; }
        }

        private void ShowStudentResults(int quizID)
        {
            DatabaseHelper db = new DatabaseHelper();
            DataTable studentResults = db.GetQuizResults(quizID);

            Form resultsForm = new Form
            {
                Text = "Student Results",
                Size = new Size(500, 400),
                StartPosition = FormStartPosition.CenterScreen,
                BackColor = Color.White
            };

            ListView list = new ListView
            {
                Dock = DockStyle.Fill,
                View = View.Details,
                FullRowSelect = true,
                Font = new Font("Century Gothic", 10),
            };
            list.Columns.Add("Student", 150);
            list.Columns.Add("Score", 80);
            list.Columns.Add("Date", 150);
            list.Columns.Add("Rated", 80);

            foreach (DataRow row in studentResults.Rows)
            {
                var item = new ListViewItem(row["Username"].ToString());
                item.SubItems.Add(row["Score"].ToString());
                item.SubItems.Add(Convert.ToDateTime(row["CompletedDate"]).ToString("MMM dd yyyy"));
                int ungraded = row["UngradedCount"] != DBNull.Value ? Convert.ToInt32(row["UngradedCount"]) : 0;
                item.SubItems.Add(ungraded > 0 ? "⚠" : "✔");
                item.ForeColor = ungraded > 0 ? Color.IndianRed : Color.SeaGreen;

                item.Tag = new StudentResultTag
                {
                    StudentID = Convert.ToInt32(row["StudentID"]),
                    HasUngraded = ungraded > 0
                };

                list.Items.Add(item);
            }
            list.DoubleClick += (s, e) =>
            {
                if (list.SelectedItems.Count > 0)
                {
                    var selectedItem = list.SelectedItems[0];
                    var tagInfo = (dynamic)selectedItem.Tag;

                    if (tagInfo.HasUngraded)
                    {
                        OpenGradingForm(quizID, tagInfo.StudentID);
                    }
                    else
                    {
                        MessageBox.Show("All questions for this student have already been graded.");
                    }
                }
            };

            resultsForm.Controls.Add(list);
            resultsForm.ShowDialog();
        }

        private void OpenGradingForm(int quizID, int studentID)
        {
            // Create and show the form in a way that maintains scope
            using (var gradingForm = new GradingForm(quizID, studentID))
            {
                // Subscribe to the FormClosed event
                gradingForm.FormClosed += (sender, e) =>
                {
                    // This will execute after the form is closed
                    LoadQuizzesIntoPanels();
                };

                gradingForm.ShowDialog();
            }

            // No need to call LoadQuizzesIntoPanels() here anymore
        }
    }
}
