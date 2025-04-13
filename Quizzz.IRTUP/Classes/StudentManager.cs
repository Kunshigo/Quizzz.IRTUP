using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Quizzz.IRTUP.Classes
{
    public class StudentManager
    {
        private readonly DatabaseHelper dbHelper;

        public StudentManager()
        {
            dbHelper = new DatabaseHelper();
        }

        public bool RegisterStudent(string username, string email, string password, DateTime birthDate, string gradeLevel)
        {
            // Input validation
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Invalid email format.");
                return false;
            }

            if (!IsPasswordStrong(password))
            {
                MessageBox.Show("Password must be at least 8 characters long with uppercase, lowercase, number, and special character.");
                return false;
            }

            if (!IsValidGradeLevel(gradeLevel))
            {
                MessageBox.Show("Please select a valid grade level (1-6).");
                return false;
            }

            // Check for existing user
            string checkQuery = "SELECT COUNT(*) FROM Students WHERE Username = @Username OR Email = @Email";
            DataTable dt = dbHelper.GetData(checkQuery,
                new OleDbParameter("@Username", username),
                new OleDbParameter("@Email", email));

            if (dt.Rows.Count > 0 && Convert.ToInt32(dt.Rows[0][0]) > 0)
            {
                MessageBox.Show("Username or Email already exists.");
                return false;
            }

            // Hash password and format date
            string hashedPassword = HashPassword(password);
            string formattedDate = birthDate.ToString("yyyy-MM-dd");

            // Insert new student
            string insertQuery = @"INSERT INTO Students 
                                (Username, Email, [Password], BirthDate, GradeLevel) 
                                VALUES (@Username, @Email, @Password, @BirthDate, @GradeLevel)";

            return dbHelper.ExecuteQuery(insertQuery,
                new OleDbParameter("@Username", username),
                new OleDbParameter("@Email", email),
                new OleDbParameter("@Password", hashedPassword),
                new OleDbParameter("@BirthDate", formattedDate),
                new OleDbParameter("@GradeLevel", gradeLevel));
        }

        private bool IsValidGradeLevel(string gradeLevel)
        {
            // Validate grade level is between 1-6
            return !string.IsNullOrWhiteSpace(gradeLevel) &&
                   gradeLevel.Length == 1 &&
                   char.IsDigit(gradeLevel[0]) &&
                   int.Parse(gradeLevel) >= 1 &&
                   int.Parse(gradeLevel) <= 6;
        }


        public int LoginStudent(string usernameOrEmail, string password)
        {
            string query = "SELECT StudentID, [Password] FROM Students WHERE Username = @UsernameOrEmail OR Email = @UsernameOrEmail";
            DataTable dt = dbHelper.GetData(query,
                new OleDbParameter("@UsernameOrEmail", usernameOrEmail));

            if (dt.Rows.Count > 0)
            {
                string storedHash = dt.Rows[0]["Password"].ToString();
                string enteredHash = HashPassword(password);

                if (enteredHash.Equals(storedHash))
                {
                    return Convert.ToInt32(dt.Rows[0]["StudentID"]);
                }
            }

            return -1;
        }

        public Dictionary<string, string> GetStudentDetails(int studentID)
        {
            string query = "SELECT Username, Email, [Password], BirthDate, GradeLevel FROM Students WHERE StudentID = @StudentID";
            DataTable dt = dbHelper.GetData(query, new OleDbParameter("@StudentID", studentID));

            if (dt.Rows.Count > 0)
            {
                return new Dictionary<string, string>
                {
                    { "Username", dt.Rows[0]["Username"].ToString() },
                    { "Email", dt.Rows[0]["Email"].ToString() },
                    { "Password", dt.Rows[0]["Password"].ToString() },
                    { "BirthDate", dt.Rows[0]["BirthDate"].ToString() },
                    { "GradeLevel", dt.Rows[0]["GradeLevel"].ToString() },
                    { "StudentID", studentID.ToString() }
                };
            }
            return null;
        }

        public bool UpdateStudentInfo(int studentId, string username, string email, string password, DateTime birthDate, string gradeLevel)
        {
            if (!IsValidEmail(email))
            {
                MessageBox.Show("Invalid email format.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(gradeLevel))
            {
                MessageBox.Show("Please select a grade level.");
                return false;
            }

            string hashedPassword = HashPassword(password);
            string formattedDate = birthDate.ToString("yyyy-MM-dd");

            string query = @"UPDATE Students 
                         SET Username = @Username, Email = @Email, 
                             [Password] = @Password, BirthDate = @BirthDate,
                             GradeLevel = @GradeLevel
                         WHERE StudentID = @StudentID";

            return dbHelper.ExecuteQuery(query,
                new OleDbParameter("@Username", username),
                new OleDbParameter("@Email", email),
                new OleDbParameter("@Password", hashedPassword),
                new OleDbParameter("@BirthDate", formattedDate),
                new OleDbParameter("@GradeLevel", gradeLevel),
                new OleDbParameter("@StudentID", studentId));
        }

        public bool DeleteStudent(int studentId)
        {
            string query = "DELETE FROM Students WHERE StudentID = @StudentID";
            return dbHelper.ExecuteQuery(query, new OleDbParameter("@StudentID", studentId));
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
    }
}