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
    public partial class QuizCard : UserControl
    {
        public int QuizID { get; private set; }

        public event EventHandler<int> OpenQuizRequested;

        public QuizCard(string quizName, int quizID, DateTime createdDate)
        {
            InitializeComponent();
            this.QuizID = quizID;

            lblQuizName.Text = quizName;
            createdDateLabel.Text = $"Created: {createdDate.ToShortDateString()}";
        }

        private void openBtn_Click(object sender, EventArgs e)
        {
            OpenQuizRequested?.Invoke(this, QuizID);
        }
    }
}
