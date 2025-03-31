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
        public string QuizTitle { get; set; }
        public string Category { get; set; }
        public int Questions { get; set; }
        public string DateCreated { get; set; }

        public QuizCard()
        {
            InitializeComponent();
            this.Size = new Size(250, 180);
            this.BackColor = Color.FromArgb(60, 60, 60);
            this.Margin = new Padding(15);
            this.Cursor = Cursors.Hand;

            this.Paint += QuizCard_Paint;
            this.MouseEnter += QuizCard_MouseEnter;
            this.MouseLeave += QuizCard_MouseLeave;
        }

        private void QuizCard_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(90, 90, 90);
        }

        private void QuizCard_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(60, 60, 60);
        }

        private void QuizCard_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // Draw Title
            using (Font titleFont = new Font("Segoe UI", 12, FontStyle.Bold))
            {
                g.DrawString(QuizTitle, titleFont, Brushes.White, new PointF(10, 10));
            }

            // Draw Questions
            using (Font descFont = new Font("Segoe UI", 10))
            {
                g.DrawString($"{Questions} Questions", descFont, Brushes.LightGray, new PointF(10, 40));
            }

            // Draw Category
            using (Font catFont = new Font("Segoe UI", 9, FontStyle.Italic))
            {
                g.DrawString($"Category: {Category}", catFont, Brushes.Cyan, new PointF(10, 70));
            }

            // Draw Date Created
            using (Font dateFont = new Font("Segoe UI", 9, FontStyle.Italic))
            {
                g.DrawString($"Date: {DateCreated}", dateFont, Brushes.LightGreen, new PointF(10, 100));
            }
        }
    }
}
