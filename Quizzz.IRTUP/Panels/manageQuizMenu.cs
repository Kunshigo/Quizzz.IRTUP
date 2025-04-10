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
            Panel quizPanel = new Panel
            {
                Width = 180,
                Height = 180,
                Dock = DockStyle.Top,
                Padding = new Padding(10),
                Margin = new Padding(3),
                BackColor = Color.FromArgb(255, 192, 192),
            };

            Label quizTitle = new Label
            {
                Text = quizName,
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Century Gothic", 12, FontStyle.Bold),
                Height = 40
            };

            Label dateLabel = new Label
            {
                Text = $"Created: {dateCreated:MMM dd, yyyy}",
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 9, FontStyle.Italic),
                ForeColor = Color.Gray,
                Height = 30
            };

            Button quizButton = new Button
            {
                Text = "Open Quiz",
                Dock = DockStyle.Bottom,
                Tag = quizID, // ✅ Pass the QuizID here
                BackColor = Color.DarkSlateBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            quizButton.FlatAppearance.BorderSize = 0;
            quizButton.Click += QuizButton_Click;

            // Add controls to the panel
            quizPanel.Controls.Add(quizButton);
            quizPanel.Controls.Add(quizTitle);


            quizzesPanel.Controls.Add(quizPanel);
        }



        private void btnAddQuiz_Click(object sender, EventArgs e)
        {
            string quizName = Microsoft.VisualBasic.Interaction.InputBox("Enter Quiz Name:", "Add New Quiz");

            if (!string.IsNullOrWhiteSpace(quizName))
            {
                DatabaseHelper db = new DatabaseHelper();

                string insertQuery = "INSERT INTO Quizzes (Title, TeacherID, CreatedDate) VALUES (@Title, @TeacherID, @CreatedDate);";
                OleDbParameter[] parameters = new OleDbParameter[]
                {
            new OleDbParameter("@Title", quizName),
            new OleDbParameter("@TeacherID", _teacherID),
            new OleDbParameter("@CreatedDate", DateTime.Now.ToString("yyyy-MM-dd"))
                };

                bool success = db.ExecuteQuery(insertQuery, parameters);

                if (success)
                {
                    LoadQuizzes(_teacherID); // Refresh list of quizzes
                }
                else
                {
                    MessageBox.Show("Failed to add quiz.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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

            CreateQuizForm cQF = new CreateQuizForm(quizID);
            cQF.ShowDialog();

            // Optional: Refresh the quiz list after editing
            LoadQuizzes(_teacherID);
        }

        private void manageQuizMenu_Load(object sender, EventArgs e)
        {
            ////int teacherID = Convert.ToInt32((this.FindForm() as MainMenu)?.teacherDetails["teacherID"]);
            //LoadQuizzes(teacherID);
        }
    }
}
