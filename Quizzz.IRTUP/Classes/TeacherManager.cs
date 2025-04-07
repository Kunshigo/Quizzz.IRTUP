using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

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
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Invalid email format.");
                return false;
            }

            if (!IsPasswordStrong(password))
            {
                MessageBox.Show("Password must be at least 8 characters long and include uppercase, lowercase, number, and special character.");
                return false;
            }

            string checkQuery = "SELECT COUNT(*) FROM Teachers WHERE Username = @Username OR Email = @Email";
            DataTable dt = dbHelper.GetData(checkQuery,
                new OleDbParameter("@Username", username),
                new OleDbParameter("@Email", email));

            if (dt.Rows.Count > 0 && Convert.ToInt32(dt.Rows[0][0]) > 0)
            {
                MessageBox.Show("Username or Email already exists.");
                return false;
            }

            string hashedPassword = HashPassword(password);

            string insertQuery = "INSERT INTO Teachers (Username, Email, [Password], Subject, GradeLevel) VALUES (@Username, @Email, @Password, @Subject, @GradeLevel)";
            return dbHelper.ExecuteQuery(insertQuery,
                new OleDbParameter("@Username", username),
                new OleDbParameter("@Email", email),
                new OleDbParameter("@Password", hashedPassword),
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
            string query = "SELECT Username, Email, [Password], Subject, GradeLevel FROM Teachers WHERE TeacherID = @TeacherID";
            DataTable dt = dbHelper.GetData(query, new OleDbParameter("@TeacherID", teacherID));

            if (dt.Rows.Count > 0)
            {
                return new Dictionary<string, string>
        {
            { "Username", dt.Rows[0]["Username"].ToString() },
            { "Email", dt.Rows[0]["Email"].ToString() },
            { "Password", dt.Rows[0]["Password"].ToString() },  // ✅ add this
            { "Subject", dt.Rows[0]["Subject"].ToString() },
            { "GradeLevel", dt.Rows[0]["GradeLevel"].ToString() },
            { "TeacherID", teacherID.ToString() } // helpful for updates
        };
            }
            return null;
        }

        public string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private bool VerifyPassword(string enteredPassword, string storedHashedPassword)
        {
            string enteredHashed = HashPassword(enteredPassword);
            return enteredHashed.Equals(storedHashedPassword);
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool IsPasswordStrong(string password)
        {
            if (password.Length < 8) return false;
            bool hasUpper = false, hasLower = false, hasDigit = false, hasSpecial = false;
            foreach (char c in password)
            {
                if (char.IsUpper(c)) hasUpper = true;
                else if (char.IsLower(c)) hasLower = true;
                else if (char.IsDigit(c)) hasDigit = true;
                else hasSpecial = true;
            }
            return hasUpper && hasLower && hasDigit && hasSpecial;
        }

        public bool UpdateTeacherInfo(int teacherId, string username, string email, string password, string subject, string gradeLevel)
        {
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Invalid email format.");
                return false;
            }

            string hashedPassword = HashPassword(password);

            string query = @"UPDATE Teachers 
                             SET Username = @Username, Email = @Email, [Password] = @Password, 
                                 Subject = @Subject, GradeLevel = @GradeLevel 
                             WHERE TeacherID = @TeacherID";

            return dbHelper.ExecuteQuery(query,
                new OleDbParameter("@Username", username),
                new OleDbParameter("@Email", email),
                new OleDbParameter("@Password", hashedPassword),
                new OleDbParameter("@Subject", subject),
                new OleDbParameter("@GradeLevel", gradeLevel),
                new OleDbParameter("@TeacherID", teacherId)
            );
        }

        public bool DeleteTeacher(int teacherId)
        {
            string query = "DELETE FROM Teachers WHERE TeacherID = @TeacherID";
            return dbHelper.ExecuteQuery(query, new OleDbParameter("@TeacherID", teacherId));
        }
    }
}
