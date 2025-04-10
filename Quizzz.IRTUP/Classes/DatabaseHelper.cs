using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using Quizzz.IRTUP.QuestionTypePanels;

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
            string query = "SELECT QuizID, Title, CreatedDate FROM Quizzes WHERE TeacherID = @TeacherID";
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
                                    "UPDATE TrueFalseQuestion SET CorrectAnswer = @CorrectAnsewr " +
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




    }
}
