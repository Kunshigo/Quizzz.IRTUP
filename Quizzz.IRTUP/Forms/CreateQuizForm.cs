    using Quizzz.IRTUP.Panels;
    using Quizzz.IRTUP.QuestionTypePanels;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
using static Quizzz.IRTUP.Forms.CreateQuizForm;

    namespace Quizzz.IRTUP.Forms
{
    public partial class CreateQuizForm : Form
    {
        private Rectangle recPanel;

        public CreateQuizForm()
        {
            InitializeComponent();
            questionTypeComboBox.SelectedItem = "Multiple Choice";

            originalMiniPanelWidth = questionPanelSlides.Width;
            originalMiniPanelHeight = questionPanelSlides.Height;

            this.Resize += CreateQuizForm_Resize;
            this.questionsPanel.Resize += questionsPanel_Resize;
            questionPanelSlides.Resize += miniQuestionPanel_Resize;

            if (questionPanelSlides.Controls.Count > 0 && questionPanelSlides.Controls[0] is UserControl userControl)
            {
                originalUserControlWidth = userControl.Width;
                originalUserControlHeight = userControl.Height;
            }
        }

        private void maximizeBtn_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void miniPanel()
        {
            if (questionTypeComboBox.SelectedItem == "Multiple Choice")
            {
                miniMultipleChoice miniMultipleChoice = new miniMultipleChoice();
                questionPanelSlides.Controls.Clear();
                questionPanelSlides.Controls.Add(miniMultipleChoice);
            }
        }

        private void quizScreen()
        {
            if (questionTypeComboBox.SelectedItem == "Multiple Choice")
            {
                MultipleChoice multipleChoice = new MultipleChoice();
                selectedQuizPanel.Controls.Clear();
                selectedQuizPanel.Controls.Add(multipleChoice);
            }
        }

        private void questionTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            quizScreen();
            miniPanel();

            if (WindowState == FormWindowState.Maximized)
            {
                ResizeQuestionsPanel();
                ResizeSelectedQuizPanel();
            }

        }

        private void ResizeSelectedQuizPanel()
        {
            selectedQuizPanel.Width = this.ClientSize.Width - 20;
            selectedQuizPanel.Height = this.ClientSize.Height - 20;

            foreach (Control control in selectedQuizPanel.Controls)
            {
                if (control is MultipleChoice multipleChoice)
                {
                    multipleChoice.Width = selectedQuizPanel.ClientSize.Width - 10;
                    multipleChoice.Height = selectedQuizPanel.ClientSize.Height - 10;

                    multipleChoice.Refresh();
                }
            }

            selectedQuizPanel.Refresh();
        }

        private void selectedQuizPanel_Resize(object sender, EventArgs e)
        {
            selectedQuizPanel.Dock = DockStyle.Fill;

            foreach (Control control in selectedQuizPanel.Controls)
            {
                if (control is MultipleChoice multiplechoice)
                {
                    multiplechoice.Width = selectedQuizPanel.ClientSize.Width;
                    multiplechoice.Height = selectedQuizPanel.ClientSize.Height;

                    multiplechoice.Refresh();
                }
            }

            selectedQuizPanel.Refresh();
        }

        private void ResizeQuestionsPanel()
        {
            if (WindowState == FormWindowState.Maximized)
            {
                // Apply maximized panel size
                float panelHeightRatio = 0.15f;  // 15% of form height
                int newHeight = (int)(this.ClientSize.Height * panelHeightRatio);
                newHeight = Math.Max(100, Math.Min(300, newHeight));  // Constrain height
                questionsPanel.Height = newHeight;
            }
            else
            {
                // Keep the original size when not maximized
                questionsPanel.Height = 88;  // Original height
            }

            // Refresh the panel
            questionsPanel.Refresh();
        }

        private void CreateQuizForm_Resize(object sender, EventArgs e)
        {

            if (WindowState == FormWindowState.Maximized)
            {
                // Resize only when maximized
                float panelHeightRatio = 0.15f;  // 15% of form height
                int newHeight = (int)(this.ClientSize.Height * panelHeightRatio);
                newHeight = Math.Max(100, Math.Min(300, newHeight));  // Constrain height
                questionsPanel.Height = newHeight;
            }
            else
            {
                // Keep the original size when not maximized
                questionsPanel.Height = 88;  // Original height
            }


            // Refresh the panel to apply changes
            questionsPanel.Refresh();
        }

        private int originalMiniPanelWidth;
        private int originalMiniPanelHeight;

        private void questionsPanel_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                // Scale the miniQuestionPanel proportionally
                float panelWidthRatio = 0.33f;  // 33% for mini, 66% for main content
                int newWidth = (int)(questionsPanel.ClientSize.Width * panelWidthRatio);

                // Apply tighter constraints to avoid excessive stretching
                newWidth = Math.Max(150, Math.Min(250, newWidth));

                // Apply the scaled size
                questionPanelSlides.Width = newWidth;
                questionPanelSlides.Height = questionsPanel.ClientSize.Height;
            }
            else
            {
                // Restore to original size when unmaximized
                questionPanelSlides.Width = originalMiniPanelWidth;
                questionPanelSlides.Height = originalMiniPanelHeight;
            }

            // Refresh the panel
            questionPanelSlides.Refresh();
        }

        private int originalUserControlWidth;
        private int originalUserControlHeight;

        private void miniQuestionPanel_Resize(object sender, EventArgs e)
        {
            foreach (Control control in questionPanelSlides.Controls)
            {
                if (control is UserControl userControl)
                {
                    if (WindowState == FormWindowState.Maximized)
                    {
                        // Ensure the UserControl fits perfectly inside the panel
                        int padding = questionPanelSlides.Padding.Horizontal + questionPanelSlides.Margin.Horizontal;
                        int border = SystemInformation.BorderSize.Width * 2;

                        userControl.Width = Math.Min(questionPanelSlides.ClientSize.Width - padding - border, questionPanelSlides.Width);
                        userControl.Height = Math.Min(questionPanelSlides.ClientSize.Height - padding - border, questionPanelSlides.Height);
                    }
                    else
                    {
                        // Restore to original size when unmaximized
                        userControl.Width = originalUserControlWidth;
                        userControl.Height = originalUserControlHeight;
                    }

                    userControl.Refresh();
                }
            }

            questionPanelSlides.Refresh();

        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }
        private void addQuestionBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
