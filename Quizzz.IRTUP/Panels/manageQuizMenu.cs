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
    public partial class manageQuizMenu : UserControl
    {
        public int Checker { get; private set; }
        public event EventHandler<int> PanelSwitchRequested;
        private int _teacherID;
        private Dictionary<string, string> teacherDetails;

        public manageQuizMenu(Dictionary<string, string> teacherDetails)
        {
            InitializeComponent();
            this.teacherDetails = teacherDetails;

            _teacherID = int.Parse(teacherDetails["TeacherID"]);
            InitializeQuizzesPanelLayout();
            LoadQuizzes(_teacherID);
        }

        private void InitializeQuizzesPanelLayout()
        {
            quizzesPanel.FlowDirection = FlowDirection.LeftToRight;
            quizzesPanel.WrapContents = true;
            quizzesPanel.AutoScroll = true;
        }

        public void Initialize(int teacherID)
        {
            _teacherID = teacherID;
            LoadQuizzes(teacherID);
        }

        private void CreateQuizCard(string quizName, int quizID, DateTime dateCreated)
        {
            DatabaseHelper db = new DatabaseHelper();
            DataTable quizData = db.GetData(
                @"SELECT q.Difficulty, t.Subject 
          FROM Quizzes q
          INNER JOIN Teachers t ON q.TeacherID = t.TeacherID
          WHERE q.QuizID = @QuizID",
                new OleDbParameter("@QuizID", quizID));

            string subject = "", difficulty = "";


            if (quizData.Rows.Count > 0)
            {
                subject = quizData.Rows[0]["Subject"].ToString();
                difficulty = quizData.Rows[0]["Difficulty"].ToString();
            }

            Panel quizPanel = new Panel
            {
                Width = 180,
                Height = 200, // Increased to fit more info
                Padding = new Padding(10),
                Margin = new Padding(3),
                BackColor = isDeleteMode ? Color.FromArgb(255, 210, 210) : Color.FromArgb(230, 250, 230),
                BorderStyle = isDeleteMode ? BorderStyle.FixedSingle : BorderStyle.None,
                Tag = quizID
            };

            Label quizTitle = new Label
            {
                Text = quizName,
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Century Gothic", 11, FontStyle.Bold),
                ForeColor = Color.DarkOliveGreen,
                Height = 35
            };

            Label dateLabel = new Label
            {
                Text = $"Created: {dateCreated:MMM dd, yyyy}",
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Century Gothic", 9, FontStyle.Italic),
                ForeColor = Color.SeaGreen,
                Height = 25
            };

            Label subjectLabel = new Label
            {
                Text = $"Grade Level: {subject}",
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Century Gothic", 9),
                ForeColor = Color.SeaGreen,
                Height = 20
            };

            Label difficultyLabel = new Label
            {
                Text = $"Difficulty: {difficulty}",
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Century Gothic", 9),
                ForeColor = Color.SeaGreen,
                Height = 20
            };

            Button quizButton = new Button
            {
                Text = isDeleteMode ? "🗑 Click to Delete" : "Open Quiz",
                Dock = DockStyle.Bottom,
                Tag = quizID,
                BackColor = isDeleteMode ? Color.IndianRed : Color.MediumSeaGreen,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Height = 35
            };
            quizButton.FlatAppearance.BorderSize = 0;
            quizButton.Click += QuizButton_Click;

            quizPanel.MouseEnter += (s, e) =>
            {
                if (isDeleteMode) quizPanel.BackColor = Color.FromArgb(255, 150, 150);
            };
            quizPanel.MouseLeave += (s, e) =>
            {
                if (isDeleteMode) quizPanel.BackColor = Color.FromArgb(255, 180, 180);
            };

            // Add context menu for editing
            ContextMenuStrip menu = new ContextMenuStrip();
            menu.Items.Add("Edit Quiz Info").Click += (s, e) => ShowEditQuizDialog(quizID);
            quizPanel.ContextMenuStrip = menu;

            // Add controls to the panel
            quizPanel.Controls.Add(quizButton);
            quizPanel.Controls.Add(difficultyLabel);
            quizPanel.Controls.Add(subjectLabel);
            quizPanel.Controls.Add(dateLabel);
            quizPanel.Controls.Add(quizTitle);
            quizzesPanel.Controls.Add(quizPanel);
        }

        private void ShowEditQuizDialog(int quizID)
        {
            DatabaseHelper db = new DatabaseHelper();
            DataTable quizData = db.GetData("SELECT * FROM Quizzes WHERE QuizID = @QuizID", new OleDbParameter("@QuizID", quizID));
            if (quizData.Rows.Count == 0) return;

            DataRow quiz = quizData.Rows[0];
            string title = quiz["Title"].ToString();
            string grade = quiz["Subject"].ToString();
            string difficulty = quiz["Difficulty"].ToString();

            Form editForm = new Form
            {
                Text = "Edit Quiz Info",
                Size = new Size(350, 300),
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterScreen,
                BackColor = Color.FromArgb(240, 248, 255),
            };

            Label lblTitle = new Label { Text = "Quiz Title", Left = 20, Top = 20, Width = 100, Font = new Font("Century Gothic", 10) };
            TextBox txtTitle = new TextBox { Text = title, Left = 20, Top = 45, Width = 280, Font = new Font("Century Gothic", 10) };

            Label lblSubject = new Label
            {
                Text = $"Subject: {teacherDetails["Subject"]}",
                Left = 20,
                Top = 85,
                Width = 280,
                Font = new Font("Century Gothic", 10)
            };

            Label lblDifficulty = new Label { Text = "Difficulty", Left = 20, Top = 150, Width = 100, Font = new Font("Century Gothic", 10) };
            ComboBox cboDifficulty = new ComboBox { Left = 20, Top = 175, Width = 280, DropDownStyle = ComboBoxStyle.DropDownList };
            cboDifficulty.Items.AddRange(new string[] { "Easy", "Medium", "Hard" });
            cboDifficulty.SelectedItem = difficulty;

            Button btnSave = new Button
            {
                Text = "Save Changes",
                Left = 90,
                Top = 220,
                Width = 150,
                BackColor = Color.MediumSeaGreen,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnSave.FlatAppearance.BorderSize = 0;

            btnSave.Click += (s, ev) =>
            {
                string updatedTitle = txtTitle.Text.Trim();
                string updatedGrade = lblSubject.Text.ToString() ?? "";
                string updatedDiff = cboDifficulty.SelectedItem?.ToString() ?? "";

                if (string.IsNullOrWhiteSpace(updatedTitle)) return;

                string updateQuery = "UPDATE Quizzes SET Title = @Title, Subject = @Subject, Difficulty = @Difficulty WHERE QuizID = @QuizID";
                OleDbParameter[] parameters = new OleDbParameter[]
                {
            new OleDbParameter("@Title", updatedTitle),
            new OleDbParameter("@Subject", updatedGrade),
            new OleDbParameter("@Difficulty", updatedDiff),
            new OleDbParameter("@QuizID", quizID)
                };

                if (db.ExecuteQuery(updateQuery, parameters))
                {
                    MessageBox.Show("Quiz updated!");
                    editForm.Close();
                    LoadQuizzes(_teacherID);
                }
            };

            editForm.Controls.AddRange(new Control[] { lblTitle, txtTitle, lblSubject, lblDifficulty, cboDifficulty, btnSave });
            editForm.ShowDialog();
        }


        private void btnAddQuiz_Click(object sender, EventArgs e)
        {
            Form newQuizForm = new Form
            {
                Text = "Create New Quiz",
                Size = new Size(350, 300),
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterScreen,
                BackColor = Color.FromArgb(245, 245, 255)
            };

            Label lblTitle = new Label { Text = "Quiz Title", Left = 20, Top = 20, Width = 100, Font = new Font("Century Gothic", 10) };
            TextBox txtTitle = new TextBox { Left = 20, Top = 45, Width = 280, Font = new Font("Century Gothic", 10) };

            Label lblSubject = new Label
            {
                Text = $"Subject: {teacherDetails["Subject"]}",
                Left = 20,
                Top = 85,
                Width = 280,
                Font = new Font("Century Gothic", 10)
            };

            Label lblDifficulty = new Label { Text = "Difficulty", Left = 20, Top = 150, Width = 100, Font = new Font("Century Gothic", 10) };
            ComboBox cboDifficulty = new ComboBox { Left = 20, Top = 175, Width = 280, DropDownStyle = ComboBoxStyle.DropDownList };
            cboDifficulty.Items.AddRange(new string[] { "Easy", "Medium", "Hard" });

            Button btnCreate = new Button
            {
                Text = "Create Quiz",
                Left = 90,
                Top = 220,
                Width = 150,
                BackColor = Color.MediumSlateBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnCreate.FlatAppearance.BorderSize = 0;

            btnCreate.Click += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtTitle.Text)) return;

                DatabaseHelper db = new DatabaseHelper();
                string insertQuery = @"INSERT INTO Quizzes 
                             (Title, TeacherID, CreatedDate, Difficulty) 
                             VALUES (@Title, @TeacherID, @CreatedDate, @Difficulty)";
                OleDbParameter[] parameters = new OleDbParameter[]
                {
            new OleDbParameter("@Title", txtTitle.Text.Trim()),
            new OleDbParameter("@TeacherID", _teacherID),
            new OleDbParameter("@CreatedDate", DateTime.Now.ToString("yyyy-MM-dd")),
            new OleDbParameter("@Difficulty", cboDifficulty.SelectedItem?.ToString() ?? "")
                };

                if (db.ExecuteQuery(insertQuery, parameters))
                {
                    MessageBox.Show("Quiz created!");
                    newQuizForm.Close();
                    LoadQuizzes(_teacherID);
                }
            };

            newQuizForm.Controls.Add(txtTitle);
            newQuizForm.Controls.Add(lblSubject);
            newQuizForm.Controls.Add(cboDifficulty);
            newQuizForm.Controls.Add(btnCreate);
            newQuizForm.ShowDialog();
        }

        private void LoadQuizzes(int teacherID)
        {
            DatabaseHelper db = new DatabaseHelper();
            DataTable quizData = db.GetAllQuizzes(teacherID); // You must define this in DatabaseHelper

            // Clear existing quiz cards before adding new ones
            quizzesPanel.Controls.Clear();

            foreach (DataRow row in quizData.Rows)
            {
                string quizName = row["Title"].ToString();
                int quizID = Convert.ToInt32(row["QuizID"]);
                DateTime dateCreated = SafeDate(row["CreatedDate"]);

                CreateQuizCard(quizName, quizID, dateCreated);
            }
        }

        private DateTime SafeDate(object value)
        {
            return value != DBNull.Value ? Convert.ToDateTime(value) : DateTime.MinValue;
        }


        private void QuizButton_Click(object sender, EventArgs e)
        {
            Button clickedQuiz = sender as Button;
            int quizID = (int)clickedQuiz.Tag;

            if (isDeleteMode)
            {
                var confirm = MessageBox.Show("Are you sure you want to delete this quiz?", "Confirm", MessageBoxButtons.YesNo);
                if (confirm == DialogResult.Yes)
                {
                    DatabaseHelper db = new DatabaseHelper();
                    if (db.DeleteQuiz(quizID))
                    {
                        MessageBox.Show("Quiz deleted.");
                        LoadQuizzes(_teacherID);
                    }
                }
                isDeleteMode = false;
            }
            else
            {
                CreateQuizForm cQF = new CreateQuizForm(quizID);
                cQF.ShowDialog();
                LoadQuizzes(_teacherID);
            }
        }

        private void manageQuizMenu_Load(object sender, EventArgs e)
        {
            ////int teacherID = Convert.ToInt32((this.FindForm() as MainMenu)?.teacherDetails["teacherID"]);
            //LoadQuizzes(teacherID);
        }

        private bool isDeleteMode = false;

        private void deleteQuizBtn_Click(object sender, EventArgs e)
        {
            isDeleteMode = !isDeleteMode;

            if (isDeleteMode)
            {
                MessageBox.Show("⚠ Delete Mode Enabled\nClick a quiz card to delete it.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                foreach (Control ctrl in quizzesPanel.Controls)
                {
                    if (ctrl is Panel panel) FlashControl(panel);
                }
            }
            else
                MessageBox.Show("Delete Mode Disabled.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LoadQuizzes(_teacherID); // Refresh UI to reflect mode
        }

        private async void FlashControl(Control control)
        {
            Color originalColor = control.BackColor;
            control.BackColor = Color.Red;
            await Task.Delay(100);
            control.BackColor = originalColor;
        }

    }
}
