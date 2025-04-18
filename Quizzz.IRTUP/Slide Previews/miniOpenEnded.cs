using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quizzz.IRTUP.Slide_Previews
{
    public partial class miniOpenEnded : UserControl, IMiniSlide
    {
        public event EventHandler SlideClicked;
        public Label QuestionNumberLabel { get; private set; }
        private Label slideTypeLabel;

        public miniOpenEnded()
        {
            InitializeComponent();
            this.Click += MiniOpenEnded_Click;

            QuestionNumberLabel = new Label
            {
                Text = "",
                ForeColor = Color.DarkSlateGray,
                Location = new Point(10, 10),
                AutoSize = true,
                Font = new Font("Segoe UI", 9, FontStyle.Bold)
            };


            this.Controls.Add(QuestionNumberLabel);
        }

        public void SetSlideNumber(int number)
        {
            slideNumberLabel.Text = "Slide " + number;
        }

        private void MiniOpenEnded_Click(object sender, EventArgs e)
        {
            if (this.Parent is FlowLayoutPanel parentPanel)
            {
                SlideClicked?.Invoke(parentPanel, EventArgs.Empty);
            }
        }
    }
}
