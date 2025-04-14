using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using Quizzz.IRTUP.QuestionTypePanels;
using System.Text.RegularExpressions;

namespace Quizzz.IRTUP.Classes
{
    internal class DatabaseHelper
    {
        private readonly string connectionString;

        public DatabaseHelper()
        {
            string dbPath = @"C:\Users\LOQ\Documents\QUIZZ.IRUTP.accdb";
            connectionString = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={dbPath};Persist Security Info=False;";
        }

        public bool TestConnection()
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    MessageBox.Show("Connection Successful!");
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Connection Failed: " + ex.Message);
                return false;
            }
        }

        public bool ExecuteQuery(string query, params OleDbParameter[] parameters)
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddRange(parameters);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message);
                return false;
            }
        }

        public DataTable GetData(string query, params OleDbParameter[] parameters)
        {
            DataTable dt = new DataTable();
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddRange(parameters);
                        using (OleDbDataAdapter adapter = new OleDbDataAdapter(cmd))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error retrieving data: " + ex.Message);
            }
            return dt;
        }

        public void SaveMultipleChoiceQuestion(QuestionData question, int quizID)
        {
            string questionText = question.QuestionText;
            List<string> choices = question.Choices;
            int correctAnswerIndex = question.CorrectAnswerIndex;
            int questionNo = question.QuestionNo;

            if (string.IsNullOrWhiteSpace(questionText) || choices.Any(c => string.IsNullOrWhiteSpace(c)))
            {
                MessageBox.Show("Please fill in the question and all choices.");
                return;
            }

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                using (OleDbTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // First, check if question exists
                        int existingQuestionId = -1;
                        using (OleDbCommand checkCmd = new OleDbCommand(
                            "SELECT QuestionID FROM Questions WHERE QuizID = @QuizID AND QuestionNo = @QuestionNo", conn, transaction))
                        {
                            checkCmd.Parameters.AddWithValue("@QuizID", quizID);
                            checkCmd.Parameters.AddWithValue("@QuestionNo", questionNo);
                            object result = checkCmd.ExecuteScalar();
                            if (result != null)
                                existingQuestionId = Convert.ToInt32(result);
                        }

                        if (existingQuestionId > 0)
                        {
                            // UPDATE Questions
                            using (OleDbCommand updateQ = new OleDbCommand(
                                "UPDATE Questions SET QuestionText = @QuestionText, QuestionType = @QuestionType WHERE QuestionID = @QuestionID", conn, transaction))
                            {
                                updateQ.Parameters.AddWithValue("@QuestionText", questionText);
                                updateQ.Parameters.AddWithValue("@QuestionType", question.QuestionType);
                                updateQ.Parameters.AddWithValue("@QuestionID", existingQuestionId);
                                updateQ.ExecuteNonQuery();
                            }

                            // UPDATE Choices
                            bool hasChoices = false;
                            using (OleDbCommand checkChoices = new OleDbCommand(
                                "SELECT COUNT(*) FROM Choices WHERE QuizID = @QuizID AND QuestionNo = @QuestionNo", conn, transaction))
                            {
                                checkChoices.Parameters.AddWithValue("@QuizID", quizID);
                                checkChoices.Parameters.AddWithValue("@QuestionNo", questionNo);
                                int count = Convert.ToInt32(checkChoices.ExecuteScalar());
                                hasChoices = count > 0;
                            }
                            if (hasChoices)
                            {
                                // Perform UPDATE
                                using (OleDbCommand updateC = new OleDbCommand(
                                    "UPDATE Choices SET CorrectAnswer = @CorrectAnswer, Choice1 = @Choice1, Choice2 = @Choice2, Choice3 = @Choice3, Choice4 = @Choice4 WHERE QuizID = @QuizID AND QuestionNo = @QuestionNo", conn, transaction))
                                {
                                    updateC.Parameters.AddWithValue("@CorrectAnswer", correctAnswerIndex + 1);
                                    updateC.Parameters.AddWithValue("@Choice1", choices[0]);
                                    updateC.Parameters.AddWithValue("@Choice2", choices[1]);
                                    updateC.Parameters.AddWithValue("@Choice3", choices[2]);
                                    updateC.Parameters.AddWithValue("@Choice4", choices[3]);
                                    updateC.Parameters.AddWithValue("@QuizID", quizID);
                                    updateC.Parameters.AddWithValue("@QuestionNo", questionNo);
                                    updateC.ExecuteNonQuery();
                                }
                            }
                            else
                            {
                                // Perform INSERT
                                using (OleDbCommand insertC = new OleDbCommand(
                                    "INSERT INTO Choices (QuizID, QuestionNo, CorrectAnswer, Choice1, Choice2, Choice3, Choice4) VALUES (@QuizID, @QuestionNo, @CorrectAnswer, @Choice1, @Choice2, @Choice3, @Choice4)", conn, transaction))
                                {
                                    insertC.Parameters.AddWithValue("@QuizID", quizID);
                                    insertC.Parameters.AddWithValue("@QuestionNo", questionNo);
                                    insertC.Parameters.AddWithValue("@CorrectAnswer", correctAnswerIndex + 1);
                                    insertC.Parameters.AddWithValue("@Choice1", choices[0]);
                                    insertC.Parameters.AddWithValue("@Choice2", choices[1]);
                                    insertC.Parameters.AddWithValue("@Choice3", choices[2]);
                                    insertC.Parameters.AddWithValue("@Choice4", choices[3]);
                                    insertC.ExecuteNonQuery();
                                }
                            }

                            question.QuestionID = existingQuestionId; // Optional
                        }
                        else
                        {
                            // INSERT into Questions
                            using (OleDbCommand insertQ = new OleDbCommand(
                                "INSERT INTO Questions (QuizID, QuestionText, QuestionType, QuestionNo) VALUES (@QuizID, @QuestionText, @QuestionType, @QuestionNo)", conn, transaction))
                            {
                                insertQ.Parameters.AddWithValue("@QuizID", quizID);
                                insertQ.Parameters.AddWithValue("@QuestionText", questionText);
                                insertQ.Parameters.AddWithValue("@QuestionType", question.QuestionType);
                                insertQ.Parameters.AddWithValue("@QuestionNo", questionNo);
                                insertQ.ExecuteNonQuery();

                                insertQ.CommandText = "SELECT @@IDENTITY";
                                question.QuestionID = Convert.ToInt32(insertQ.ExecuteScalar());
                            }

                            // INSERT into Choices
                            using (OleDbCommand insertC = new OleDbCommand(
                                "INSERT INTO Choices (QuizID, QuestionNo, CorrectAnswer, Choice1, Choice2, Choice3, Choice4) VALUES (@QuizID, @QuestionNo, @CorrectAnswer, @Choice1, @Choice2, @Choice3, @Choice4)", conn, transaction))
                            {
                                insertC.Parameters.AddWithValue("@QuizID", quizID);
                                insertC.Parameters.AddWithValue("@QuestionNo", questionNo);
                                insertC.Parameters.AddWithValue("@CorrectAnswer", correctAnswerIndex + 1);
                                insertC.Parameters.AddWithValue("@Choice1", choices[0]);
                                insertC.Parameters.AddWithValue("@Choice2", choices[1]);
                                insertC.Parameters.AddWithValue("@Choice3", choices[2]);
                                insertC.Parameters.AddWithValue("@Choice4", choices[3]);
                                insertC.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Error saving question: " + ex.Message);
                    }
                }
            }
        }

        public DataTable GetQuizQuestions(int quizID)
        {
            string query = "SELECT * FROM Questions WHERE QuizID = @QuizID ORDER BY QuestionNo";
            OleDbParameter[] parameters = new OleDbParameter[]
            {
        new OleDbParameter("@QuizID", quizID)
            };
            return GetData(query, parameters);
        }

        public DataTable GetQuestionChoices(int quizID, int questionNo)
        {
            string query = "SELECT * FROM Choices WHERE QuizID = @QuizID AND QuestionNo = @QuestionNo";
            OleDbParameter[] parameters = new OleDbParameter[]
            {
        new OleDbParameter("@QuizID", quizID),
        new OleDbParameter("@QuestionNo", questionNo)
            };

            DataTable result = GetData(query, parameters);

            // Debug output - remove after testing
            if (result.Rows.Count == 0)
            {
                MessageBox.Show($"No choices found for QuizID: {quizID}, QuestionNo: {questionNo}");
            }

            return result;
        }

        public DataTable GetAllQuizzes(int teacherID)
        {
            string query = "SELECT QuizID, Title, CreatedDate, Subject, Difficulty FROM Quizzes WHERE TeacherID = @TeacherID";
            OleDbParameter[] parameters = new OleDbParameter[]
            {
        new OleDbParameter("@TeacherID", teacherID)
            };

            return GetData(query, parameters);
        }

        public bool DeleteQuestion(int quizID, int questionNo, int questionID)
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();

                    // Delete choices using QuizID + QuestionNo
                    string deleteChoices = "DELETE FROM Choices WHERE QuizID = @QuizID AND QuestionNo = @QuestionNo";
                    using (OleDbCommand cmdChoices = new OleDbCommand(deleteChoices, conn))
                    {
                        cmdChoices.Parameters.AddWithValue("@QuizID", quizID);
                        cmdChoices.Parameters.AddWithValue("@QuestionNo", questionNo);
                        cmdChoices.ExecuteNonQuery();
                    }

                    // Delete question using QuestionID
                    string deleteQuestion = "DELETE FROM Questions WHERE QuestionID = @QuestionID";
                    using (OleDbCommand cmdQuestion = new OleDbCommand(deleteQuestion, conn))
                    {
                        cmdQuestion.Parameters.AddWithValue("@QuestionID", questionID);
                        cmdQuestion.ExecuteNonQuery();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to delete question: " + ex.Message);
                return false;
            }
        }

        public bool DeleteQuiz(int quizID)
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();

                    // Delete choices linked to this quiz
                    string deleteChoices = "DELETE FROM Choices WHERE QuizID = @QuizID";
                    using (OleDbCommand cmd1 = new OleDbCommand(deleteChoices, conn))
                    {
                        cmd1.Parameters.AddWithValue("@QuizID", quizID);
                        cmd1.ExecuteNonQuery();
                    }

                    // Delete questions first
                    string deleteQuestions = "DELETE FROM Questions WHERE QuizID = @QuizID";
                    using (OleDbCommand cmd2 = new OleDbCommand(deleteQuestions, conn))
                    {
                        cmd2.Parameters.AddWithValue("@QuizID", quizID);
                        cmd2.ExecuteNonQuery();
                    }

                    // Then delete the quiz
                    string deleteQuiz = "DELETE FROM Quizzes WHERE QuizID = @QuizID";
                    using (OleDbCommand cmd3 = new OleDbCommand(deleteQuiz, conn))
                    {
                        cmd3.Parameters.AddWithValue("@QuizID", quizID);
                        cmd3.ExecuteNonQuery();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to delete quiz: " + ex.Message);
                return false;
            }
        }

        public void SaveTrueFalseQuestion(int quizID, int questionNo, string questionText, string correctAnswer)
        {
            if (string.IsNullOrWhiteSpace(questionText) || string.IsNullOrWhiteSpace(correctAnswer))
            {
                MessageBox.Show("Please fill in the question and select an answer.");
                return;
            }

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                using (OleDbTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // First, check if question exists
                        int existingQuestionId = -1;
                        using (OleDbCommand checkCmd = new OleDbCommand(
                            "SELECT QuestionID FROM Questions WHERE QuizID = @QuizID AND QuestionNo = @QuestionNo", conn, transaction))
                        {
                            checkCmd.Parameters.AddWithValue("@QuizID", quizID);
                            checkCmd.Parameters.AddWithValue("@QuestionNo", questionNo);
                            object result = checkCmd.ExecuteScalar();
                            if (result != null)
                                existingQuestionId = Convert.ToInt32(result);
                        }

                        if (existingQuestionId > 0)
                        {
                            // UPDATE Questions table
                            using (OleDbCommand updateQ = new OleDbCommand(
                                "UPDATE Questions SET QuestionText = @QuestionText, QuestionType = @QuestionType " +
                                "WHERE QuestionID = @QuestionID", conn, transaction))
                            {
                                updateQ.Parameters.AddWithValue("@QuestionText", questionText);
                                updateQ.Parameters.AddWithValue("@QuestionType", "True or False");
                                updateQ.Parameters.AddWithValue("@QuestionID", existingQuestionId);
                                updateQ.ExecuteNonQuery();
                            }

                            // Check if TrueFalse entry exists
                            bool hasTrueFalseEntry = false;
                            using (OleDbCommand checkTF = new OleDbCommand(
                                "SELECT COUNT(*) FROM TrueFalseQuestion WHERE QuizID = @QuizID AND QuestionNo = @QuestionNo", conn, transaction))
                            {
                                checkTF.Parameters.AddWithValue("@QuizID", quizID);
                                checkTF.Parameters.AddWithValue("@QuestionNo", questionNo);
                                int count = Convert.ToInt32(checkTF.ExecuteScalar());
                                hasTrueFalseEntry = count > 0;
                            }

                            if (hasTrueFalseEntry)
                            {
                                // UPDATE TrueFalseQuestion
                                using (OleDbCommand updateTF = new OleDbCommand(
                                    "UPDATE TrueFalseQuestion SET CorrectAnswer = @CorrectAnswer " +
                                    "WHERE QuizID = @QuizID AND QuestionNo = @QuestionNo", conn, transaction))
                                {
                                    updateTF.Parameters.AddWithValue("@CorrectAnswer", correctAnswer);
                                    updateTF.Parameters.AddWithValue("@QuizID", quizID);
                                    updateTF.Parameters.AddWithValue("@QuestionNo", questionNo);
                                    updateTF.ExecuteNonQuery();
                                }
                            }
                            else
                            {
                                // INSERT into TrueFalseQuestion
                                using (OleDbCommand insertTF = new OleDbCommand(
                                    "INSERT INTO TrueFalseQuestion (QuizID, QuestionNo, CorrectAnswer) " +
                                    "VALUES (@QuizID, @QuestionNo, @CorrectAnswer)", conn, transaction))
                                {
                                    insertTF.Parameters.AddWithValue("@QuizID", quizID);
                                    insertTF.Parameters.AddWithValue("@QuestionNo", questionNo);
                                    insertTF.Parameters.AddWithValue("@CorrectAnswer", correctAnswer);
                                    insertTF.ExecuteNonQuery();
                                }
                            }
                        }
                        else
                        {
                            // INSERT into Questions
                            int newQuestionId;
                            using (OleDbCommand insertQ = new OleDbCommand(
                                "INSERT INTO Questions (QuizID, QuestionText, QuestionType, QuestionNo) " +
                                "VALUES (@QuizID, @QuestionText, @QuestionType, @QuestionNo)", conn, transaction))
                            {
                                insertQ.Parameters.AddWithValue("@QuizID", quizID);
                                insertQ.Parameters.AddWithValue("@QuestionText", questionText);
                                insertQ.Parameters.AddWithValue("@QuestionType", "True or False");
                                insertQ.Parameters.AddWithValue("@QuestionNo", questionNo);
                                insertQ.ExecuteNonQuery();

                                // Get the new QuestionID
                                insertQ.CommandText = "SELECT @@IDENTITY";
                                newQuestionId = Convert.ToInt32(insertQ.ExecuteScalar());
                            }

                            // INSERT into TrueFalseQuestion
                            using (OleDbCommand insertTF = new OleDbCommand(
                                "INSERT INTO TrueFalseQuestion (QuizID, QuestionNo, CorrectAnswer) " +
                                "VALUES (@QuizID, @QuestionNo, @CorrectAnswer)", conn, transaction))
                            {
                                insertTF.Parameters.AddWithValue("@QuizID", quizID);
                                insertTF.Parameters.AddWithValue("@QuestionNo", questionNo);
                                insertTF.Parameters.AddWithValue("@CorrectAnswer", correctAnswer);
                                insertTF.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Error saving True/False question: " + ex.Message);
                        // Add debug output to see parameter values
                        MessageBox.Show($"Debug values - QuizID: {quizID}, QNo: {questionNo}, Text: {questionText}, Ans: {correctAnswer}");
                    }
                }
            }
        }
        public DataTable GetTrueFalseQuestion(int quizID, int questionNo)
        {
            string query = "SELECT * FROM TrueFalseQuestion WHERE QuizID = @QuizID AND QuestionNo = @QuestionNo";

            // Debug output to verify parameters
            MessageBox.Show($"Executing query with: QuizID={quizID}, QuestionNo={questionNo}");

            OleDbParameter[] parameters = new OleDbParameter[]
            {
        new OleDbParameter("@QuizID", OleDbType.Integer) { Value = quizID },
        new OleDbParameter("@QuestionNo", OleDbType.Integer) { Value = questionNo }
            };

            try
            {
                DataTable result = GetData(query, parameters);

                if (result.Rows.Count > 0)
                {
                    var row = result.Rows[0];
                    MessageBox.Show($"✅ Loaded: QuestionNo = {row["QuestionNo"]}, CorrectAnswer = {row["CorrectAnswer"]}");
                }
                else
                {
                    MessageBox.Show("⚠️ No rows returned - check if data exists for these parameters");
                }

                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ Error loading True/False question: {ex.Message}\nQuery: {query}");
                return new DataTable();
            }
        }

        // Add to DatabaseHelper class
        public void SaveIdentificationQuestion(int quizID, int questionNo, string questionText, string correctAnswer, List<string> alternativeAnswers)
        {
            if (string.IsNullOrWhiteSpace(questionText) || string.IsNullOrWhiteSpace(correctAnswer))
            {
                MessageBox.Show("Please fill in the question and main answer.");
                return;
            }

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                using (OleDbTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // First, check if question exists
                        int existingQuestionId = -1;
                        using (OleDbCommand checkCmd = new OleDbCommand(
                            "SELECT QuestionID FROM Questions WHERE QuizID = @QuizID AND QuestionNo = @QuestionNo", conn, transaction))
                        {
                            checkCmd.Parameters.AddWithValue("@QuizID", quizID);
                            checkCmd.Parameters.AddWithValue("@QuestionNo", questionNo);
                            object result = checkCmd.ExecuteScalar();
                            if (result != null)
                                existingQuestionId = Convert.ToInt32(result);
                        }

                        if (existingQuestionId > 0)
                        {
                            // UPDATE Questions table
                            using (OleDbCommand updateQ = new OleDbCommand(
                                "UPDATE Questions SET QuestionText = @QuestionText, QuestionType = @QuestionType " +
                                "WHERE QuestionID = @QuestionID", conn, transaction))
                            {
                                updateQ.Parameters.AddWithValue("@QuestionText", questionText);
                                updateQ.Parameters.AddWithValue("@QuestionType", "Identification");
                                updateQ.Parameters.AddWithValue("@QuestionID", existingQuestionId);
                                updateQ.ExecuteNonQuery();
                            }

                            // Check if Identification entry exists
                            bool hasEntry = false;
                            using (OleDbCommand checkCmd = new OleDbCommand(
                                "SELECT COUNT(*) FROM IdentificationQuestion WHERE QuizID = @QuizID AND QuestionNo = @QuestionNo", conn, transaction))
                            {
                                checkCmd.Parameters.AddWithValue("@QuizID", quizID);
                                checkCmd.Parameters.AddWithValue("@QuestionNo", questionNo);
                                int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                                hasEntry = count > 0;
                            }

                            if (hasEntry)
                            {
                                // UPDATE IdentificationQuestions
                                using (OleDbCommand updateCmd = new OleDbCommand(
                                    "UPDATE IdentificationQuestion SET CorrectAnswer = @CorrectAnswer, " +
                                    "AlternativeAnswer1 = @Alt1, AlternativeAnswer2 = @Alt2, AlternativeAnswer3 = @Alt3 " +
                                    "WHERE QuizID = @QuizID AND QuestionNo = @QuestionNo", conn, transaction))
                                {
                                    updateCmd.Parameters.AddWithValue("@CorrectAnswer", correctAnswer);
                                    updateCmd.Parameters.AddWithValue("@Alt1", alternativeAnswers[0] ?? "");
                                    updateCmd.Parameters.AddWithValue("@Alt2", alternativeAnswers[1] ?? "");
                                    updateCmd.Parameters.AddWithValue("@Alt3", alternativeAnswers[2] ?? "");
                                    updateCmd.Parameters.AddWithValue("@QuizID", quizID);
                                    updateCmd.Parameters.AddWithValue("@QuestionNo", questionNo);
                                    updateCmd.ExecuteNonQuery();
                                }
                            }
                            else
                            {
                                // INSERT into IdentificationQuestions
                                using (OleDbCommand insertCmd = new OleDbCommand(
                                    "INSERT INTO IdentificationQuestion (QuizID, QuestionNo, CorrectAnswer, " +
                                    "AlternativeAnswer1, AlternativeAnswer2, AlternativeAnswer3) " +
                                    "VALUES (@QuizID, @QuestionNo, @CorrectAnswer, @Alt1, @Alt2, @Alt3)", conn, transaction))
                                {
                                    insertCmd.Parameters.AddWithValue("@QuizID", quizID);
                                    insertCmd.Parameters.AddWithValue("@QuestionNo", questionNo);
                                    insertCmd.Parameters.AddWithValue("@CorrectAnswer", correctAnswer);
                                    insertCmd.Parameters.AddWithValue("@Alt1", alternativeAnswers[0] ?? "");
                                    insertCmd.Parameters.AddWithValue("@Alt2", alternativeAnswers[1] ?? "");
                                    insertCmd.Parameters.AddWithValue("@Alt3", alternativeAnswers[2] ?? "");
                                    insertCmd.ExecuteNonQuery();
                                }
                            }
                        }
                        else
                        {
                            // INSERT into Questions
                            int newQuestionId;
                            using (OleDbCommand insertQ = new OleDbCommand(
                                "INSERT INTO Questions (QuizID, QuestionText, QuestionType, QuestionNo) " +
                                "VALUES (@QuizID, @QuestionText, @QuestionType, @QuestionNo)", conn, transaction))
                            {
                                insertQ.Parameters.AddWithValue("@QuizID", quizID);
                                insertQ.Parameters.AddWithValue("@QuestionText", questionText);
                                insertQ.Parameters.AddWithValue("@QuestionType", "Identification");
                                insertQ.Parameters.AddWithValue("@QuestionNo", questionNo);
                                insertQ.ExecuteNonQuery();

                                // Get the new QuestionID
                                insertQ.CommandText = "SELECT @@IDENTITY";
                                newQuestionId = Convert.ToInt32(insertQ.ExecuteScalar());
                            }

                            // INSERT into IdentificationQuestions
                            using (OleDbCommand insertCmd = new OleDbCommand(
                                "INSERT INTO IdentificationQuestion (QuizID, QuestionNo, CorrectAnswer, " +
                                "AlternativeAnswer1, AlternativeAnswer2, AlternativeAnswer3) " +
                                "VALUES (@QuizID, @QuestionNo, @CorrectAnswer, @Alt1, @Alt2, @Alt3)", conn, transaction))
                            {
                                insertCmd.Parameters.AddWithValue("@QuizID", quizID);
                                insertCmd.Parameters.AddWithValue("@QuestionNo", questionNo);
                                insertCmd.Parameters.AddWithValue("@CorrectAnswer", correctAnswer);
                                insertCmd.Parameters.AddWithValue("@Alt1", alternativeAnswers[0] ?? "");
                                insertCmd.Parameters.AddWithValue("@Alt2", alternativeAnswers[1] ?? "");
                                insertCmd.Parameters.AddWithValue("@Alt3", alternativeAnswers[2] ?? "");
                                insertCmd.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Error saving Identification question: " + ex.Message);
                    }
                }
            }
        }


        public DataTable GetIdentificationQuestion(int quizID, int questionNo)
        {
            string query = "SELECT * FROM IdentificationQuestion WHERE QuizID = @QuizID AND QuestionNo = @QuestionNo";
            OleDbParameter[] parameters = new OleDbParameter[]
            {
        new OleDbParameter("@QuizID", quizID),
        new OleDbParameter("@QuestionNo", questionNo)
            };
            return GetData(query, parameters);
        }

        public void SaveFillInTheBlanksQuestion(int quizID, int questionNo, string questionText, string answers)
        {
            if (string.IsNullOrWhiteSpace(questionText) || string.IsNullOrWhiteSpace(answers))
            {
                MessageBox.Show("Please fill in the question and at least one answer.");
                return;
            }

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                using (OleDbTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // Check if question exists
                        int existingQuestionId = -1;
                        using (OleDbCommand checkCmd = new OleDbCommand(
                            "SELECT QuestionID FROM Questions WHERE QuizID = @QuizID AND QuestionNo = @QuestionNo", conn, transaction))
                        {
                            checkCmd.Parameters.AddWithValue("@QuizID", quizID);
                            checkCmd.Parameters.AddWithValue("@QuestionNo", questionNo);
                            object result = checkCmd.ExecuteScalar();
                            if (result != null) existingQuestionId = Convert.ToInt32(result);
                        }

                        if (existingQuestionId > 0)
                        {
                            // UPDATE Questions
                            using (OleDbCommand updateQ = new OleDbCommand(
                                "UPDATE Questions SET QuestionText = @QuestionText, QuestionType = @QuestionType " +
                                "WHERE QuestionID = @QuestionID", conn, transaction))
                            {
                                updateQ.Parameters.AddWithValue("@QuestionText", questionText);
                                updateQ.Parameters.AddWithValue("@QuestionType", "Fill in the blanks");
                                updateQ.Parameters.AddWithValue("@QuestionID", existingQuestionId);
                                updateQ.ExecuteNonQuery();
                            }

                            // UPDATE FillInTheBlanks
                            using (OleDbCommand updateF = new OleDbCommand(
                                "UPDATE FillInTheBlanks SET Answers = @Answers " +
                                "WHERE QuizID = @QuizID AND QuestionNo = @QuestionNo", conn, transaction))
                            {
                                updateF.Parameters.AddWithValue("@Answers", answers);
                                updateF.Parameters.AddWithValue("@QuizID", quizID);
                                updateF.Parameters.AddWithValue("@QuestionNo", questionNo);
                                updateF.ExecuteNonQuery();
                            }
                        }
                        else
                        {
                            // INSERT into Questions
                            int newQuestionId;
                            using (OleDbCommand insertQ = new OleDbCommand(
                                "INSERT INTO Questions (QuizID, QuestionText, QuestionType, QuestionNo) " +
                                "VALUES (@QuizID, @QuestionText, @QuestionType, @QuestionNo)", conn, transaction))
                            {
                                insertQ.Parameters.AddWithValue("@QuizID", quizID);
                                insertQ.Parameters.AddWithValue("@QuestionText", questionText);
                                insertQ.Parameters.AddWithValue("@QuestionType", "Fill in the blanks");
                                insertQ.Parameters.AddWithValue("@QuestionNo", questionNo);
                                insertQ.ExecuteNonQuery();
                                insertQ.CommandText = "SELECT @@IDENTITY";
                                newQuestionId = Convert.ToInt32(insertQ.ExecuteScalar());
                            }

                            // INSERT into FillInTheBlanks
                            using (OleDbCommand insertF = new OleDbCommand(
                                "INSERT INTO FillInTheBlanks (QuizID, QuestionNo, Answers) " +
                                "VALUES (@QuizID, @QuestionNo, @Answers)", conn, transaction))
                            {
                                insertF.Parameters.AddWithValue("@QuizID", quizID);
                                insertF.Parameters.AddWithValue("@QuestionNo", questionNo);
                                insertF.Parameters.AddWithValue("@Answers", answers);
                                insertF.ExecuteNonQuery();
                            }
                        }
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Error saving Fill in the blanks question: " + ex.Message);
                    }
                }
            }
        }

        public DataTable GetFillInTheBlanksQuestion(int quizID, int questionNo)
        {
            string query = "SELECT * FROM FillInTheBlanks WHERE QuizID = @QuizID AND QuestionNo = @QuestionNo";
            OleDbParameter[] parameters = new OleDbParameter[]
            {
        new OleDbParameter("@QuizID", quizID),
        new OleDbParameter("@QuestionNo", questionNo)
            };
            return GetData(query, parameters);
        }

        public void SaveOpenEndedQuestion(int quizID, int questionNo, string questionText)
        {
            if (string.IsNullOrWhiteSpace(questionText))
            {
                MessageBox.Show("Please fill in the question text.");
                return;
            }

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                using (OleDbTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // First, check if question exists
                        int existingQuestionId = -1;
                        using (OleDbCommand checkCmd = new OleDbCommand(
                            "SELECT QuestionID FROM Questions WHERE QuizID = @QuizID AND QuestionNo = @QuestionNo", conn, transaction))
                        {
                            checkCmd.Parameters.AddWithValue("@QuizID", quizID);
                            checkCmd.Parameters.AddWithValue("@QuestionNo", questionNo);
                            object result = checkCmd.ExecuteScalar();
                            if (result != null)
                                existingQuestionId = Convert.ToInt32(result);
                        }

                        if (existingQuestionId > 0)
                        {
                            // UPDATE Questions table
                            using (OleDbCommand updateQ = new OleDbCommand(
                                "UPDATE Questions SET QuestionText = @QuestionText, QuestionType = @QuestionType " +
                                "WHERE QuestionID = @QuestionID", conn, transaction))
                            {
                                updateQ.Parameters.AddWithValue("@QuestionText", questionText);
                                updateQ.Parameters.AddWithValue("@QuestionType", "Open-Ended");
                                updateQ.Parameters.AddWithValue("@QuestionID", existingQuestionId);
                                updateQ.ExecuteNonQuery();
                            }

                            // Check if OpenEnded entry exists
                            bool hasEntry = false;
                            using (OleDbCommand checkCmd = new OleDbCommand(
                                "SELECT COUNT(*) FROM OpenEndedQuestions WHERE QuizID = @QuizID AND QuestionNo = @QuestionNo", conn, transaction))
                            {
                                checkCmd.Parameters.AddWithValue("@QuizID", quizID);
                                checkCmd.Parameters.AddWithValue("@QuestionNo", questionNo);
                                int count = Convert.ToInt32(checkCmd.ExecuteScalar());
                                hasEntry = count > 0;
                            }

                            if (!hasEntry)
                            {
                                // INSERT into OpenEndedQuestions (just a placeholder table)
                                using (OleDbCommand insertCmd = new OleDbCommand(
                                    "INSERT INTO OpenEndedQuestions (QuizID, QuestionNo) " +
                                    "VALUES (@QuizID, @QuestionNo)", conn, transaction))
                                {
                                    insertCmd.Parameters.AddWithValue("@QuizID", quizID);
                                    insertCmd.Parameters.AddWithValue("@QuestionNo", questionNo);
                                    insertCmd.ExecuteNonQuery();
                                }
                            }
                        }
                        else
                        {
                            // INSERT into Questions
                            int newQuestionId;
                            using (OleDbCommand insertQ = new OleDbCommand(
                                "INSERT INTO Questions (QuizID, QuestionText, QuestionType, QuestionNo) " +
                                "VALUES (@QuizID, @QuestionText, @QuestionType, @QuestionNo)", conn, transaction))
                            {
                                insertQ.Parameters.AddWithValue("@QuizID", quizID);
                                insertQ.Parameters.AddWithValue("@QuestionText", questionText);
                                insertQ.Parameters.AddWithValue("@QuestionType", "Open-Ended");
                                insertQ.Parameters.AddWithValue("@QuestionNo", questionNo);
                                insertQ.ExecuteNonQuery();
                                insertQ.CommandText = "SELECT @@IDENTITY";
                                newQuestionId = Convert.ToInt32(insertQ.ExecuteScalar());
                            }

                            // INSERT into OpenEndedQuestions
                            using (OleDbCommand insertCmd = new OleDbCommand(
                                "INSERT INTO OpenEndedQuestions (QuizID, QuestionNo) " +
                                "VALUES (@QuizID, @QuestionNo)", conn, transaction))
                            {
                                insertCmd.Parameters.AddWithValue("@QuizID", quizID);
                                insertCmd.Parameters.AddWithValue("@QuestionNo", questionNo);
                                insertCmd.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show("Error saving Open-Ended question: " + ex.Message);
                    }
                }
            }
        }

        public DataTable GetOpenEndedQuestion(int quizID, int questionNo)
        {
            string query = "SELECT * FROM OpenEndedQuestions WHERE QuizID = @QuizID AND QuestionNo = @QuestionNo";
            OleDbParameter[] parameters = new OleDbParameter[]
            {
        new OleDbParameter("@QuizID", quizID),
        new OleDbParameter("@QuestionNo", questionNo)
            };
            return GetData(query, parameters);
        }

        public DataTable GetFilteredQuizzesForStudent(string subject = null, string difficulty = null)
        {
            string query = @"SELECT q.QuizID, q.Title, q.Difficulty, q.CreatedDate, t.Username AS TeacherName, t.Subject
                    FROM (Quizzes q INNER JOIN Teachers t ON q.TeacherID = t.TeacherID)
                    WHERE 1=1";

            var parameters = new List<OleDbParameter>();

            if (!string.IsNullOrEmpty(subject))
            {
                query += " AND t.Subject = @Subject";
                parameters.Add(new OleDbParameter("@Subject", subject));
            }

            if (!string.IsNullOrEmpty(difficulty))
            {
                query += " AND q.Difficulty = @Difficulty";
                parameters.Add(new OleDbParameter("@Difficulty", difficulty));
            }

            query += " ORDER BY q.CreatedDate DESC";

            return GetData(query, parameters.ToArray());
        }

        public int GetQuizDuration(int quizID)
        {
            string query = "SELECT DurationMinutes FROM Quizzes WHERE QuizID = @QuizID";
            OleDbParameter[] parameters = new OleDbParameter[]
            {
        new OleDbParameter("@QuizID", quizID)
            };

            DataTable dt = GetData(query, parameters);
            return dt.Rows.Count > 0 ? Convert.ToInt32(dt.Rows[0]["DurationMinutes"]) : 30; // Default 30 mins
        }

        public bool SaveStudentQuizAttempt(int studentID, int quizID, int score, DateTime completedDate)
        {
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();

                    string insertQuery = "INSERT INTO CompletedQuizzes " +
                                       "(StudentID, QuizID, Score, CompletedDate) " +
                                       "VALUES (?, ?, ?, ?)";

                    using (OleDbCommand cmd = new OleDbCommand(insertQuery, conn))
                    {
                        cmd.Parameters.Add("@StudentID", OleDbType.Integer).Value = studentID;
                        cmd.Parameters.Add("@QuizID", OleDbType.Integer).Value = quizID;
                        cmd.Parameters.Add("@Score", OleDbType.Integer).Value = score;
                        cmd.Parameters.Add("@CompletedDate", OleDbType.Date).Value = completedDate;

                        cmd.ExecuteNonQuery();
                    }

                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving quiz result: " + ex.Message);
                return false;
            }
        }

        public void UpdateQuizTimeLimit(int quizID, int timeLimitSeconds)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE Quizzes SET TimeLimit = @TimeLimit WHERE QuizID = @QuizID";

                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TimeLimit", timeLimitSeconds);
                    cmd.Parameters.AddWithValue("@QuizID", quizID);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public int GetQuizTimeLimit(int quizID)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT TimeLimit FROM Quizzes WHERE QuizID = @QuizID";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@QuizID", quizID);
                    object result = cmd.ExecuteScalar();
                    return result != DBNull.Value ? Convert.ToInt32(result) : 60;
                }
            }
        }

        public bool HasStudentCompletedQuiz(int studentID, int quizID)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM CompletedQuizzes WHERE StudentID = @StudentID AND QuizID = @QuizID";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@StudentID", studentID);
                    cmd.Parameters.AddWithValue("@QuizID", quizID);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        public DataTable GetCompletedQuizzes(int studentID)
        {
            string query = "SELECT QuizID FROM CompletedQuizzes WHERE StudentID = @StudentID";
            OleDbParameter[] parameters = new OleDbParameter[]
            {
        new OleDbParameter("@StudentID", studentID)
            };

            return GetData(query, parameters);
        }
    }
}
