using Quizzz.IRTUP.Classes;
using Quizzz.IRTUP.QuestionTypePanels;
using Quizzz.IRTUP.QuestionTypeStudentsPanels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Quizzz.IRTUP.Forms
{
    public partial class TakeQuizForm : Form
    {
        private int totalTimeLeft; // Total quiz time in seconds
        private System.Windows.Forms.Timer quizTimer;

        private List<MultipleChoiceStudent> mcQuestions = new List<MultipleChoiceStudent>();
        private int currentQuestionIndex = 0;
        private int totalScore = 0;
        private int quizDuration = 60; // seconds per question
        private int currentStudentID;
        private int currentQuizID;
        private int timeLeft = 10;
        private const int QuestionDuration = 10;
        private System.Windows.Forms.Timer questionTimer;
        private List<(int QuestionNo, string SelectedAnswer, string CorrectAnswer)> studentAnswers = new List<(int, string, string)>();

        private Dictionary<UserControl, (int QuestionNo, string SelectedAnswer, string CorrectAnswer, string QuestionType)> questions =
            new Dictionary<UserControl, (int, string, string, string)>();

        public TakeQuizForm(int quizID, int studentID)
        {
            InitializeComponent();
            DatabaseHelper db = new DatabaseHelper();
            int timeLimitPerQuestionInSeconds = db.GetQuizTimeLimit(quizID);
            quizDuration = timeLimitPerQuestionInSeconds > 0 ? timeLimitPerQuestionInSeconds : 10;
            currentStudentID = studentID;
            currentQuizID = quizID;

            questionTimer = new System.Windows.Forms.Timer();
            questionTimer.Interval = 1000;
            questionTimer.Tick += QuestionTimer_Tick;

            answerDelayTimer.Tick += (s, e) => { answerDelayTimer.Stop(); GoToNextQuestion(); };
            LoadQuiz();
        }
        

        private void QuizTimer_Tick(object sender, EventArgs e)
        {
            totalTimeLeft--;
            lblTimer.Text = $"Time Left: {totalTimeLeft}s";
            if (totalTimeLeft <= 0)
            {
                quizTimer.Stop();
                MessageBox.Show("Time's up!");
                CompleteQuiz();
            }
        }

        private void LoadQuiz()
        {
            DatabaseHelper db = new DatabaseHelper();
            DataTable quizQuestions = db.GetQuizQuestions(currentQuizID);
            //totalTimeLeft = quizDuration;
            //quizTimer = new System.Windows.Forms.Timer();
            //quizTimer.Interval = 1000;
            //quizTimer.Tick += QuizTimer_Tick;
            //quizTimer.Start();


            // Clear both collections
            mcQuestions.Clear();
            questions.Clear();

            foreach (DataRow row in quizQuestions.Rows)
            {
                int qNo = Convert.ToInt32(row["QuestionNo"]);
                string questionText = row["QuestionText"].ToString();
                string questionType = row["QuestionType"].ToString();

                UserControl questionControl = null;
                string correctAnswer = "";

                switch (questionType)
                {
                    case "Multiple Choice":
                        questionControl = LoadMultipleChoiceQuestion(qNo, questionText);
                        if (questionControl is MultipleChoiceStudent mc)
                        {
                            mcQuestions.Add(mc); // Add to mcQuestions list
                        }
                        break;
                    case "Multiple Choice (Image)":
                        questionControl = LoadImageBasedMultipleChoiceQuestion(qNo, questionText);
                        break;
                    case "True or False":
                        questionControl = LoadTrueFalseQuestion(qNo, questionText);
                        break;
                    case "Fill in the blanks":
                        questionControl = LoadFillInTheBlanksQuestion(qNo, questionText);
                        break;
                    case "Identification":
                        questionControl = LoadIdentificationQuestion(qNo, questionText);
                        break;
                    case "Open-Ended":
                        questionControl = LoadOpenEndedQuestion(qNo, questionText);
                        break;
                }

                if (questionControl != null)
                {
                    questions.Add(questionControl, (qNo, null, correctAnswer, questionType));
                }
            }

            if (questions.Count > 0)
            {
                questions = questions.OrderBy(q => q.Value.QuestionNo)
                                   .ToDictionary(q => q.Key, q => q.Value);
                ShowCurrentQuestion();
            }
            else
            {
                MessageBox.Show("No questions found in this quiz.");
                this.Close();
            }
        }

        private UserControl LoadOpenEndedQuestion(int qNo, string questionText)
        {
            var control = new OpenEndedStudent();
            control.LoadQuestion(questionText);
            control.QuestionNo = qNo;
            control.NextQuestionRequested += (s, e) =>
            {
                HandleAnswerSelection();
            };
            return control;
        }

        private UserControl LoadImageBasedMultipleChoiceQuestion(int qNo, string questionText)
        {
            DatabaseHelper db = new DatabaseHelper();
            DataTable imageData = db.GetImageBasedQuestion(currentQuizID, qNo);
            if (imageData.Rows.Count == 0) return null;

            DataRow imageRow = imageData.Rows[0];
            string[] imagePaths = {
        imageRow["ImagePath1"].ToString(),
        imageRow["ImagePath2"].ToString(),
        imageRow["ImagePath3"].ToString(),
        imageRow["ImagePath4"].ToString()
    };

            int correctIndex = Convert.ToInt32(imageRow["CorrectAnswer"]) - 1;
            if (correctIndex < 0 || correctIndex >= imagePaths.Length)
            {
                MessageBox.Show($"Invalid correct answer index ({correctIndex + 1}) for question {qNo}. Using first image as fallback.");
                correctIndex = 0;
            }

            var control = new ImageBasedMultipleChoiceStudent();
            control.LoadQuestion(questionText, imagePaths, correctIndex);
            control.QuestionNo = qNo;
            control.AnswerSelected += (s, e) => HandleAnswerSelection();

            return control;
        }

        private UserControl LoadMultipleChoiceQuestion(int qNo, string questionText)
        {
            DatabaseHelper db = new DatabaseHelper();
            DataTable choicesTable = db.GetQuestionChoices(currentQuizID, qNo);
            if (choicesTable.Rows.Count == 0) return null;

            DataRow choiceRow = choicesTable.Rows[0];
            string[] choices = {
        choiceRow["Choice1"].ToString(),
        choiceRow["Choice2"].ToString(),
        choiceRow["Choice3"].ToString(),
        choiceRow["Choice4"].ToString()
    };

            // Add validation
            int correctIndex = Convert.ToInt32(choiceRow["CorrectAnswer"]) - 1;
            if (correctIndex < 0 || correctIndex >= choices.Length)
            {
                MessageBox.Show($"Invalid correct answer index ({correctIndex + 1}) for question {qNo}. Using first choice as fallback.");
                correctIndex = 0; // Fallback to first choice
            }

            string correctAnswer = choices[correctIndex];

            var control = new MultipleChoiceStudent();
            control.LoadQuestion(questionText, choices, correctAnswer);
            control.QuestionNo = qNo;
            control.AnswerSelected += (s, e) => HandleAnswerSelection();

            return control;
        }

        private UserControl LoadTrueFalseQuestion(int qNo, string questionText)
        {
            DatabaseHelper db = new DatabaseHelper();
            DataTable tfTable = db.GetTrueFalseQuestion(currentQuizID, qNo);
            if (tfTable.Rows.Count == 0) return null;

            string correctAnswer = tfTable.Rows[0]["CorrectAnswer"].ToString();

            var control = new TrueFalseStudent();
            control.LoadQuestion(questionText, correctAnswer);
            control.QuestionNo = qNo;
            control.AnswerSelected += (s, e) => HandleAnswerSelection();

            return control;
        }

        private UserControl LoadFillInTheBlanksQuestion(int qNo, string questionText)
        {
            DatabaseHelper db = new DatabaseHelper();
            DataTable fibTable = db.GetFillInTheBlanksQuestion(currentQuizID, qNo);
            if (fibTable.Rows.Count == 0) return null;

            string correctAnswer = fibTable.Rows[0]["Answers"].ToString();

            var control = new FillInTheBlanksStudent();
            control.LoadQuestion(questionText, correctAnswer);
            control.QuestionNo = qNo;
            control.AnswerSelected += (s, e) => HandleAnswerSelection();

            return control;
        }

        private UserControl LoadIdentificationQuestion(int qNo, string questionText)
        {
            DatabaseHelper db = new DatabaseHelper();
            DataTable idData = db.GetIdentificationQuestion(currentQuizID, qNo);
            if (idData.Rows.Count == 0) return null;

            DataRow row = idData.Rows[0];
            string correctAnswer = row["CorrectAnswer"].ToString();
            List<string> alternatives = new List<string>
    {
        row["AlternativeAnswer1"]?.ToString() ?? "",
        row["AlternativeAnswer2"]?.ToString() ?? "",
        row["AlternativeAnswer3"]?.ToString() ?? ""
    };

            var control = new IdentificationStudent();
            control.LoadQuestion(questionText, correctAnswer, alternatives);
            control.QuestionNo = qNo;
            control.AnswerSelected += (s, e) => HandleAnswerSelection();

            return control;
        }

        private void ShowCurrentQuestion()
        {
            quizTakingPanel.Controls.Clear();
            var currentQuestion = questions.ElementAt(currentQuestionIndex);

            // Pause timer only for open-ended questions
            if (currentQuestion.Value.QuestionType == "Open-Ended")
            {
                StopTimer();
                lblTimer.Text = "Open-Ended (No Time Limit)";
                lblTimer.ForeColor = Color.Blue;
            }
            else
            {
                StartTimer();
            }

            quizTakingPanel.Controls.Add(currentQuestion.Key);
            lblQuestionCount.Text = $"Question {currentQuestionIndex + 1} of {questions.Count}";
        }


        private void HandleAnswerSelection()
        {
            StopTimer();

            // Get current question and update selected answer
            var currentQuestion = questions.ElementAt(currentQuestionIndex);
            string selectedAnswer = "";
            string correctAnswer = currentQuestion.Value.CorrectAnswer;
            bool isCorrect = false;

            if (currentQuestion.Key is MultipleChoiceStudent mc)
            {
                selectedAnswer = mc.SelectedAnswer;
                isCorrect = mc.IsCorrect;
            }
            else if (currentQuestion.Key is ImageBasedMultipleChoiceStudent ibmc)
            {
                selectedAnswer = $"Image {ibmc.SelectedAnswerIndex + 1}";
                correctAnswer = $"Image {ibmc.CorrectAnswerIndex + 1}";
                isCorrect = ibmc.IsCorrect;
            }
            else if (currentQuestion.Key is TrueFalseStudent tf)
            {
                selectedAnswer = tf.SelectedAnswer;
                isCorrect = tf.IsCorrect;
            }
            else if (currentQuestion.Key is FillInTheBlanksStudent fib)
            {
                selectedAnswer = string.Join(",", fib.UserAnswers);
                isCorrect = fib.IsCorrect;
            }
            else if (currentQuestion.Key is IdentificationStudent id)
            {
                selectedAnswer = id.UserAnswer;
                isCorrect = id.IsCorrect;
            }
            if (currentQuestion.Key is OpenEndedStudent oe)
            {
                selectedAnswer = oe.UserAnswer;
                isCorrect = true;
            }

            ShowAnswerFeedback(isCorrect, correctAnswer);
            // Update the dictionary with the selected answer
            questions[currentQuestion.Key] = (
                currentQuestion.Value.QuestionNo,
                selectedAnswer,
                correctAnswer,
                currentQuestion.Value.QuestionType
            );

            // Disable controls
            foreach (Control ctrl in quizTakingPanel.Controls)
            {
                if (ctrl is MultipleChoiceStudent mcCtrl)
                {
                    mcCtrl.DisableButtons();
                }
                if (ctrl is ImageBasedMultipleChoiceStudent ibmcCtrl)
                {
                    ibmcCtrl.DisableSelection();
                }
                else if (ctrl is TrueFalseStudent tfCtrl)
                {
                    tfCtrl.DisableButtons();
                }
                else if (ctrl is FillInTheBlanksStudent fibCtrl)
                {
                    fibCtrl.DisableControls();
                }
                else if (ctrl is  IdentificationStudent idCtrl)
                {
                    idCtrl.DisableControls();
                }
                else if (ctrl is OpenEndedStudent oeCtrl)
                {
                    oeCtrl.DisableControls();
                }
            }

            answerDelayTimer.Start();
        }

        private void ShowAnswerFeedback(bool isCorrect, string correctAnswer)
        {
            // Create a feedback panel
            Panel feedbackPanel = new Panel();
            feedbackPanel.Dock = DockStyle.Bottom;
            feedbackPanel.Height = 50;
            feedbackPanel.BackColor = isCorrect ? Color.LightGreen : Color.LightPink;

            // Create feedback label
            Label feedbackLabel = new Label();
            feedbackLabel.Dock = DockStyle.Fill;
            feedbackLabel.TextAlign = ContentAlignment.MiddleCenter;
            feedbackLabel.Font = new Font(feedbackLabel.Font, FontStyle.Bold);
            feedbackLabel.Text = isCorrect
                ? "✓ Correct!"
                : $"✗ Incorrect. Correct answer: {correctAnswer}";

            // Add label to panel and panel to quizTakingPanel
            feedbackPanel.Controls.Add(feedbackLabel);
            quizTakingPanel.Controls.Add(feedbackPanel);

            // Bring feedback to front
            feedbackPanel.BringToFront();
        }

        private void StartTimer()
        {
            timeLeft = quizDuration;
            UpdateTimerDisplay();
            questionTimer.Start();
        }

        private void StopTimer()
        {
            questionTimer.Stop();
        }

        private void QuestionTimer_Tick(object sender, EventArgs e)
        {
            timeLeft--;
            UpdateTimerDisplay();

            if (timeLeft <= 0)
            {
                StopTimer();
                GoToNextQuestion();
            }
        }

        private void UpdateTimerDisplay()
        {
            lblTimer.Text = $"Time left: {timeLeft}s";
            lblTimer.ForeColor = timeLeft <= 5 ? Color.Red : Color.Black;
        }

        private void GoToNextQuestion()
        {
            currentQuestionIndex++;

            if (currentQuestionIndex >= questions.Count)
            {
                CompleteQuiz(); // Only if it's the LAST question
            }
            else
            {
                ShowCurrentQuestion(); // ⬅️ Show the next question normally
            }
        }


        private void CompleteQuiz()
        {
            questionTimer.Stop();

            // Get current date/time
            DateTime completedDate = DateTime.Now;

            // Calculate score from ALL questions
            totalScore = questions.Count(q => {
                if (q.Key is MultipleChoiceStudent mc)
                {
                    return mc.IsCorrect;
                }
                else if (q.Key is ImageBasedMultipleChoiceStudent ibmc)
                {
                    return ibmc.IsCorrect;
                }
                else if (q.Key is TrueFalseStudent tf)
                {
                    return tf.IsCorrect;
                }
                else if (q.Key is FillInTheBlanksStudent fib)
                {
                    return fib.IsCorrect;
                }
                else if (q.Key is IdentificationStudent id)
                {
                    return id.IsCorrect;
                }
                else if (q.Key is OpenEndedStudent oe)
                {
                    return true;
                }
                return false;
            });

            // Save results with completion date
            DatabaseHelper db = new DatabaseHelper();
            bool saved = db.SaveStudentQuizAttempt(currentStudentID, currentQuizID, totalScore, completedDate);

            if (saved)
            {
                string resultMessage = $"Quiz Completed!\n\n" +
                                     $"Date: {completedDate:MMM dd, yyyy HH:mm}\n" +
                                     $"Score: {totalScore} out of {questions.Count}\n" +
                                     $"Percentage: {(double)totalScore / questions.Count * 100:0.0}%";

                MessageBox.Show(resultMessage, "Quiz Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Failed to save quiz results.", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void nextBtn_Click(object sender, EventArgs e)
        {
            questionTimer.Stop();
        }
    }
}
