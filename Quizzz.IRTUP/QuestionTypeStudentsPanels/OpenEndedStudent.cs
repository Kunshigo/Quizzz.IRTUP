using System;
using System.Drawing;
using System.Windows.Forms;

namespace Quizzz.IRTUP.QuestionTypeStudentsPanels
{
    public partial class OpenEndedStudent : UserControl
    {
        public int QuestionNo { get; set; }
        public string UserAnswer => answerTxtBox.Text.Trim();
        public int WordCount => CountWords(answerTxtBox.Text);
        public bool IsAnswered => !string.IsNullOrWhiteSpace(UserAnswer);

        private const int MaxWordCount = 250;
        private Label wordCountLabel;
        private Button nextButton;

        public OpenEndedStudent()
        {
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            // Main container
            this.BackColor = Color.White;
            this.Padding = new Padding(20);

            // Word count label
            wordCountLabel = new Label
            {
                Dock = DockStyle.Bottom,
                Text = $"Words: 0/{MaxWordCount}",
                TextAlign = ContentAlignment.MiddleRight,
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.Gray,
                Height = 25
            };
            this.Controls.Add(wordCountLabel);

            // Button panel
            var buttonPanel = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 50,
                Padding = new Padding(0, 10, 0, 0)
            };

            // Next Question button
            nextButton = new Button
            {
                Text = "Next Question",
                Font = new Font("Segoe UI", 10),
                Size = new Size(120, 35),
                Anchor = AnchorStyles.Right,
                BackColor = Color.FromArgb(0, 123, 255),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            nextButton.FlatAppearance.BorderSize = 0;
            nextButton.Click += (s, e) => NextQuestionRequested?.Invoke(this, EventArgs.Empty);


            buttonPanel.Controls.Add(nextButton);
            this.Controls.Add(buttonPanel);
        }

        public void LoadQuestion(string questionText)
        {
            questionLabel.Text = questionText;
            answerTxtBox.Clear();
            wordCountLabel.Text = $"Words: 0/{MaxWordCount}";
            wordCountLabel.ForeColor = Color.Gray;
        }

        public void DisableControls()
        {
            answerTxtBox.ReadOnly = true;
            answerTxtBox.BackColor = Color.FromArgb(245, 245, 245);
            nextButton.Enabled = false;
        }

        private void AnswerTxtBox_TextChanged(object sender, EventArgs e)
        {
            int currentWordCount = WordCount;
            wordCountLabel.Text = $"Words: {currentWordCount}/{MaxWordCount}";

            if (currentWordCount >= MaxWordCount)
            {
                wordCountLabel.ForeColor = Color.Red;
                if (currentWordCount > MaxWordCount)
                {
                    string limitedText = LimitWords(answerTxtBox.Text, MaxWordCount);
                    int cursorPos = answerTxtBox.SelectionStart;
                    answerTxtBox.Text = limitedText;
                    answerTxtBox.SelectionStart = cursorPos;
                }
            }
            else
            {
                wordCountLabel.ForeColor = currentWordCount > MaxWordCount * 0.8 ? Color.Orange : Color.Gray;
            }
        }

        private int CountWords(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return 0;
            return text.Split(new[] { ' ', '\n', '\r', '\t' },
                            StringSplitOptions.RemoveEmptyEntries).Length;
        }

        private string LimitWords(string text, int maxWords)
        {
            var words = text.Split(new[] { ' ', '\n', '\r', '\t' },
                                 StringSplitOptions.RemoveEmptyEntries);
            return string.Join(" ", words.Take(maxWords));
        }

        public event EventHandler AnswerSelected;
        public event EventHandler NextQuestionRequested;
    }
}