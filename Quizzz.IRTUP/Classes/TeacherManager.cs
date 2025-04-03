using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;
using System.Security.Cryptography;

namespace Quizzz.IRTUP.Classes
{
    internal class TeacherManager
    {
        private readonly DatabaseHelper dbHelper;
        public TeacherManager()
        {
            dbHelper = new DatabaseHelper();
        }

        public bool RegisterTeacher(string username, string email, string password, string subject, string gradeLevel)
        {
            // Check if username or email already exists
            string checkQuery = "SELECT COUNT(*) FROM Teachers WHERE Username = @Username OR Email = @Email";
            DataTable dt = dbHelper.GetData(checkQuery,
                new OleDbParameter("@Username", username),
                new OleDbParameter("@Email", email));

            if (dt.Rows.Count > 0 && Convert.ToInt32(dt.Rows[0][0]) > 0)
            {
                MessageBox.Show("Username or Email already exists.");
                return false;
            }

            // Hash the password before storing
            string hashedPassword = HashPassword(password);

            // Insert new teacher with hashed password
            string insertQuery = "INSERT INTO Teachers (Username, Email, [Password], Subject, GradeLevel) VALUES (@Username, @Email, @Password, @Subject, @GradeLevel)";
            return dbHelper.ExecuteQuery(insertQuery,
                new OleDbParameter("@Username", username),
                new OleDbParameter("@Email", email),
                new OleDbParameter("@Password", hashedPassword), // Store hashed password
                new OleDbParameter("@Subject", subject),
                new OleDbParameter("@GradeLevel", gradeLevel));
        }

        public int LoginTeacher(string usernameOrEmail, string password)
        {
            string query = "SELECT TeacherID, [Password] FROM Teachers WHERE Username = @UsernameOrEmail OR Email = @UsernameOrEmail";
            DataTable dt = dbHelper.GetData(query,
                new OleDbParameter("@UsernameOrEmail", usernameOrEmail));

            if (dt.Rows.Count > 0)
            {
                string storedHash = dt.Rows[0]["Password"].ToString();
                string enteredHash = HashPassword(password);

                // Compare hashes
                if (enteredHash.Equals(storedHash))
                {
                    return Convert.ToInt32(dt.Rows[0]["TeacherID"]);
                }
            }

            MessageBox.Show("Invalid username/email or password.");
            return -1;
        }

        public Dictionary<string, string> GetTeacherDetails(int teacherID)
        {
            string query = "SELECT Username, Email, Subject, GradeLevel FROM Teachers WHERE TeacherID = @TeacherID";
            DataTable dt = dbHelper.GetData(query, new OleDbParameter("@TeacherID", teacherID));

            if (dt.Rows.Count > 0)
            {
                return new Dictionary<string, string>
                {
                    { "Username", dt.Rows[0]["Username"].ToString() },
                    { "Email", dt.Rows[0]["Email"].ToString() },
                    { "Subject", dt.Rows[0]["Subject"].ToString() },
                    { "GradeLevel", dt.Rows[0]["GradeLevel"].ToString() }
                };
            }
            return null;
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2")); // Convert to hexadecimal
                }
                return builder.ToString();
            }
        }

        // Verify hashed password
        private bool VerifyPassword(string enteredPassword, string storedHashedPassword)
        {
            string enteredHashed = HashPassword(enteredPassword);
            return enteredHashed.Equals(storedHashedPassword);
        }
    }
}
