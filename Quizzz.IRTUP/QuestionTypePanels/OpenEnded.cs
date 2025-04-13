using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quizzz.IRTUP.QuestionTypePanels
{
    public partial class OpenEnded : UserControl
    {
        public OpenEnded()
        {
            InitializeComponent();
        }

        public string QuestionText
        {
            get => questionTxtBox.Text;
            set => questionTxtBox.Text = value;
        }

        public int QuestionID { get; set; }
        public int QuestionNo { get; set; }

        public string PlaceholderText
        {
            get => questionTxtBox.PlaceholderText;
            set => questionTxtBox.PlaceholderText = value;
        }

        // Method to clear the question
        public void Clear()
        {
            questionTxtBox.Text = string.Empty;
        }
    }
}
