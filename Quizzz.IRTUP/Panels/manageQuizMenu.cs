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
    public partial class manageQuizMenu : UserControl
    {
        public int Checker { get; private set; }
        public event EventHandler<int> PanelSwitchRequested;

        public manageQuizMenu()
        {
            InitializeComponent();
        }

        private void CreateQuizCard(string quizName, int quizID)
        {
            Panel quizPanel = new Panel
            {
                Width = 180,
                Height = 180,
                Dock = DockStyle.Top,
                Padding = new Padding(10),
                Margin = new Padding(13),
                BackColor = Color.LightBlue,
            };

            Label quizTitle = new Label
            {
                Text = quizName,
                Dock = DockStyle.Top,
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Century Gothic", 12, FontStyle.Bold),
                Height = 40
            };

            Button quizButton = new Button
            {
                Text = "Open Quiz",
                Dock = DockStyle.Fill,
                Tag = quizId,
                BackColor = Color.DarkSlateBlue,
                FlatStyle = FlatStyle.Flat
            };

            quizButton.Click += QuizButton_Click;

            // Add controls to the panel
            quizPanel.Controls.Add(quizButton);
            quizPanel.Controls.Add(quizTitle);


            quizzesPanel.Controls.Add(quizPanel);
        }

        private void btnAddQuiz_Click(object sender, EventArgs e)
        {

        }

        private void LoadQuizzes(int teacherID)
        {
            DatabaseHelper db = new DatabaseHelper();
            DataTable quizData = db.GetAllQuizzes(teacherID); // Fetch quizzes for the specific teacher

            // Clear existing quizzes before adding new ones
            quizzesPanel.Controls.Clear();

            foreach (DataRow row in quizData.Rows)
            {
                string quizName = row["QuizName"].ToString();
                int quizID = (int)row["QuizID"];

                // Create the quiz card and add it to the panel
                CreateQuizCard(quizName, quizID);
            }
        }


        private void QuizButton_Click(object sender, EventArgs e)
        {
            Button clickedQuiz = sender as Button;
            int quizID = (int)clickedQuiz.Tag;

            MessageBox.Show($"Opening Quiz ID: {quizID}");
            // Open the quiz editor form and pass quizID
        }

        private void manageQuizMenu_Load(object sender, EventArgs e)
        {
            int teacherID = Convert.ToInt32((this.FindForm() as MainMenu)?.teacherDetails["teacherID"]);
            LoadQuizzes(teacherID);
        }
    }
}
