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

        public List<(int, string)> GetQuizzes(int teacherID)
        {
            List<(int, string)> quizzes = new List<(int, string)>();

            string query = "SELECT QuizID, QuizName FROM Quizzes WHERE TeacherID = @TeacherID";
            DataTable dt = GetData(query, new OleDbParameter("@TeacherID", teacherID));

            foreach (DataRow row in dt.Rows)
            {
                quizzes.Add((
                    Convert.ToInt32(row["QuizID"]),
                    row["QuizName"].ToString()
                ));
            }

            return quizzes;
        }

        public DataTable GetAllQuizzes(int teacherID)
        {
            
            string query = "SELECT QuizID, QuizName FROM Quizzes WHERE TeacherID = @TeacherID"; // Replace with your actual table and column names
            DataTable dt = new DataTable();

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                OleDbDataAdapter da = new OleDbDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@TeacherID", teacherID); // Add the teacherID parameter to the query
                da.Fill(dt);
            }

            return dt;
        }
    }
}
