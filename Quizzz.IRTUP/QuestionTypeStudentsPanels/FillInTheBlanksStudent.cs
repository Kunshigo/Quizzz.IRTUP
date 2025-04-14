using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Quizzz.IRTUP.QuestionTypeStudentsPanels
{
    public partial class FillInTheBlanksStudent : UserControl
    {
        public int QuestionNo { get; set; }
        public List<string> UserAnswers { get; private set; } = new List<string>();
        public List<string> CorrectAnswers { get; private set; }
        public bool IsCorrect => UserAnswers.SequenceEqual(CorrectAnswers, StringComparer.OrdinalIgnoreCase);

        private FlowLayoutPanel flowContainer = new FlowLayoutPanel();
        private List<TextBox> answerTextBoxes = new List<TextBox>();
        private Label feedbackLabel = new Label();

        public FillInTheBlanksStudent()
        {
            InitializeComponent();
            SetupLayout();
        }

        private void SetupLayout()
        {
            this.BackColor = Color.White;
            this.Padding = new Padding(20);

            // Flow panel
            flowContainer.Dock = DockStyle.Fill;
            flowContainer.FlowDirection = FlowDirection.LeftToRight;
            flowContainer.WrapContents = true;
            flowContainer.AutoScroll = true;
            flowContainer.AutoSize = true;
            flowContainer.Padding = new Padding(10);
            flowContainer.Margin = new Padding(0);
            this.Controls.Add(flowContainer);

            // Feedback label
            feedbackLabel.Dock = DockStyle.Bottom;
            feedbackLabel.Font = new Font("Century Gothic", 12, FontStyle.Bold);
            feedbackLabel.ForeColor = Color.Gray;
            feedbackLabel.Padding = new Padding(10, 15, 10, 10);
            feedbackLabel.TextAlign = ContentAlignment.MiddleLeft;
            feedbackLabel.Visible = false;
            this.Controls.Add(feedbackLabel);
        }

        public void LoadQuestion(string questionText, string answers)
        {
            flowContainer.Controls.Clear();
            answerTextBoxes.Clear();
            UserAnswers = new List<string>();
            CorrectAnswers = answers.Split(',').Select(a => a.Trim()).ToList();
            feedbackLabel.Visible = false;

            var parts = questionText.Split(new[] { "__" }, StringSplitOptions.None);

            for (int i = 0; i < parts.Length; i++)
            {
                // Add text before blank
                if (!string.IsNullOrWhiteSpace(parts[i]))
                {
                    var textLabel = new Label
                    {
                        Text = parts[i],
                        Font = new Font("Century Gothic", 13, FontStyle.Regular),
                        AutoSize = true,
                        Margin = new Padding(0, 12, 0, 0)
                    };
                    flowContainer.Controls.Add(textLabel);
                }

                // Add answer box
                if (i < parts.Length - 1)
                {
                    var textBox = new TextBox
                    {
                        Width = 180,
                        Font = new Font("Century Gothic", 12, FontStyle.Regular),
                        BorderStyle = BorderStyle.FixedSingle,
                        Margin = new Padding(5, 10, 5, 10),
                        BackColor = Color.FromArgb(245, 245, 250),
                        ForeColor = Color.Black,
                        Tag = i
                    };

                    textBox.TextChanged += (s, e) =>
                    {
                        var tb = s as TextBox;
                        int idx = (int)tb.Tag;

                        while (UserAnswers.Count <= idx)
                            UserAnswers.Add(string.Empty);

                        UserAnswers[idx] = tb.Text.Trim();
                    };

                    answerTextBoxes.Add(textBox);
                    flowContainer.Controls.Add(textBox);
                }
            }
        }

        public void DisableControls()
        {
            for (int i = 0; i < answerTextBoxes.Count; i++)
            {
                var textBox = answerTextBoxes[i];
                textBox.Enabled = false;

                bool correct = i < CorrectAnswers.Count &&
                               string.Equals(textBox.Text.Trim(), CorrectAnswers[i], StringComparison.OrdinalIgnoreCase);

                textBox.BackColor = correct
                    ? Color.FromArgb(220, 255, 230)   // Light green
                    : Color.FromArgb(255, 230, 230);  // Light red

                if (!correct)
                {
                    var correction = new Label
                    {
                        Text = $" ({CorrectAnswers[i]})",
                        ForeColor = Color.SeaGreen,
                        Font = new Font("Century Gothic", 11, FontStyle.Italic),
                        AutoSize = true,
                        Margin = new Padding(0, 14, 0, 0)
                    };
                    flowContainer.Controls.Add(correction);
                }
            }

            feedbackLabel.Visible = true;
            feedbackLabel.ForeColor = IsCorrect ? Color.SeaGreen : Color.IndianRed;
            feedbackLabel.Text = IsCorrect
                ? "✓ Perfect! All answers correct."
                : "✗ Some answers were incorrect.";
        }

        public event EventHandler AnswerSelected;
    }
}
