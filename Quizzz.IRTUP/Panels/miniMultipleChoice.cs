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
    public partial class miniMultipleChoice : UserControl
    {
        public event EventHandler SlideClicked;

        public Label QuestionNumberLabel { get; private set; }

        public miniMultipleChoice()
        {
            InitializeComponent();
            this.Click += miniMultipleChoice_Click;

            QuestionNumberLabel = new Label
            {
                Text = "",
                ForeColor = Color.DarkSlateGray,
                AutoSize = true,
            };

            this.Controls.Add(QuestionNumberLabel);
        }

        public void SetSlideNumber(int number)
        {
            slideNumberLabel.Text = "Slide " + number; // Assuming 'slideNumberLabel' is inside miniMultipleChoice
        }

        private void miniMultipleChoice_Click(object sender, EventArgs e)
        {
            if (this.Parent is FlowLayoutPanel parentPanel)
            {
                SlideClicked?.Invoke(parentPanel, EventArgs.Empty);
            }
        }
    }
}
