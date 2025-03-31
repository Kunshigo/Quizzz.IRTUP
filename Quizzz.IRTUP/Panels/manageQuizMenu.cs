using AntdUI.In;
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

        private void InitializeControls()
        {
            // Add sorting options
            cmbSort.Items.AddRange(new string[] { "Title", "Category", "Questions", "Date Created" });
            cmbSort.SelectedIndex = 0;  // Default sorting

            // Event handlers
            cmbSort.SelectedIndexChanged += (s, e) => LoadQuizzes();
            txtSearch.TextChanged += (s, e) => LoadQuizzes();
        }


        private void createQuizBtn_Click(object sender, EventArgs e)
        {
            Checker = 1;
            PanelSwitchRequested?.Invoke(this, Checker);
        }

        private void LoadQuizzes()
        {

        }

        private void btnAddQuiz_Click(object sender, EventArgs e)
        {
            using (CreateQuizForm quizForm = new CreateQuizForm())
            {
                quizForm.ShowDialog();

                //if (quizForm.ShowDialog() == DialogResult.OK)
                //{
                //    AddQuizCard(quizForm.QuizTitle, quizForm.Category, quizForm.Questions);
                //}
            }
        }
    }
}
