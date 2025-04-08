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

            int insertedQuestionID = -1;

            // Step 1: Save question to Questions table (unchanged)
            string insertQuestionQuery = "INSERT INTO Questions (QuizID, QuestionText, QuestionType, QuestionNo) VALUES (@QuizID, @QuestionText, @QuestionType, @QuestionNo)";

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            using (OleDbCommand cmd = new OleDbCommand(insertQuestionQuery, conn))
            {
                cmd.Parameters.AddWithValue("@QuizID", quizID);
                cmd.Parameters.AddWithValue("@QuestionText", questionText);
                cmd.Parameters.AddWithValue("@QuestionType", question.QuestionType);
                cmd.Parameters.AddWithValue("@QuestionNo", questionNo);

                // ... rest of the code ...
            }


            // Step 2: Save choices to Choices table - add QuestionNo parameter
            string insertChoicesQuery = "INSERT INTO Choices (QuizID, QuestionNo, CorrectAnswer, Choice1, Choice2, Choice3, Choice4) " +
                                        "VALUES (?, ?, ?, ?, ?, ?, ?)";

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            using (OleDbCommand cmd = new OleDbCommand(insertChoicesQuery, conn))
            {
                cmd.Parameters.AddWithValue("?", quizID);
                cmd.Parameters.AddWithValue("?", questionNo); // Add question number
                cmd.Parameters.AddWithValue("?", correctAnswerIndex + 1); // +1 for Access
                cmd.Parameters.AddWithValue("?", choices[0]);
                cmd.Parameters.AddWithValue("?", choices[1]);
                cmd.Parameters.AddWithValue("?", choices[2]);
                cmd.Parameters.AddWithValue("?", choices[3]);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Question and choices saved successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error saving choices: " + ex.Message);
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
