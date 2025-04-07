using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

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

        public void SaveMultipleChoiceQuestion(int quizID, QuestionData question)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();

                if (question.QuestionID > 0)  // Editing an existing question
                {
                    // Update the existing question
                    string updateQuestionSql = "UPDATE Questions SET QuestionText = ?, QuestionType = ? WHERE QuestionID = ?";
                    using (OleDbCommand updateCmd = new OleDbCommand(updateQuestionSql, conn))
                    {
                        updateCmd.Parameters.AddWithValue("?", question.QuestionText);
                        updateCmd.Parameters.AddWithValue("?", question.QuestionType);
                        updateCmd.Parameters.AddWithValue("?", question.QuestionID);  // Use existing QuestionID
                        updateCmd.ExecuteNonQuery();
                    }

                    // Now, update the Choices for the existing QuestionID
                    string updateAnswerSql = @"
            UPDATE Choices
            SET CorrectAnswer = ?, Choice1 = ?, Choice2 = ?, Choice3 = ?, Choice4 = ?
            WHERE QuestionID = ?";  // Ensure this WHERE condition is using the existing QuestionID

                    using (OleDbCommand updateAnsCmd = new OleDbCommand(updateAnswerSql, conn))
                    {
                        updateAnsCmd.Parameters.AddWithValue("?", question.Choices[question.CorrectAnswerIndex]);
                        updateAnsCmd.Parameters.AddWithValue("?", question.Choices[0]);
                        updateAnsCmd.Parameters.AddWithValue("?", question.Choices[1]);
                        updateAnsCmd.Parameters.AddWithValue("?", question.Choices[2]);
                        updateAnsCmd.Parameters.AddWithValue("?", question.Choices[3]);
                        updateAnsCmd.Parameters.AddWithValue("?", question.QuestionID);  // Use existing QuestionID
                        updateAnsCmd.ExecuteNonQuery();
                    }
                }
                else  // This means it's a new question
                {
                    // Insert new question into Questions table
                    string insertQuestionSql = "INSERT INTO Questions (QuizID, QuestionText, QuestionType) VALUES (?, ?, ?)";
                    using (OleDbCommand insertCmd = new OleDbCommand(insertQuestionSql, conn))
                    {
                        insertCmd.Parameters.AddWithValue("?", quizID);
                        insertCmd.Parameters.AddWithValue("?", question.QuestionText);
                        insertCmd.Parameters.AddWithValue("?", question.QuestionType);
                        insertCmd.ExecuteNonQuery();
                    }

                    // Get the new QuestionID (to link with Choices)
                    OleDbCommand getIdCmd = new OleDbCommand("SELECT @@IDENTITY", conn);
                    int newQuestionID = Convert.ToInt32(getIdCmd.ExecuteScalar());

                    // Insert the new choices into the Choices table
                    string insertAnswerSql = @"
            INSERT INTO Choices (QuestionID, CorrectAnswer, Choice1, Choice2, Choice3, Choice4)
            VALUES (?, ?, ?, ?, ?, ?)";
                    using (OleDbCommand insertAnsCmd = new OleDbCommand(insertAnswerSql, conn))
                    {
                        insertAnsCmd.Parameters.AddWithValue("?", newQuestionID);
                        insertAnsCmd.Parameters.AddWithValue("?", question.Choices[question.CorrectAnswerIndex]);
                        insertAnsCmd.Parameters.AddWithValue("?", question.Choices[0]);
                        insertAnsCmd.Parameters.AddWithValue("?", question.Choices[1]);
                        insertAnsCmd.Parameters.AddWithValue("?", question.Choices[2]);
                        insertAnsCmd.Parameters.AddWithValue("?", question.Choices[3]);
                        insertAnsCmd.ExecuteNonQuery();
                    }
                }
            }
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
