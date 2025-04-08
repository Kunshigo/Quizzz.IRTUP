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


    }
}
