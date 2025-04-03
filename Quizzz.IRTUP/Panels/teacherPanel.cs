using Quizzz.IRTUP.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Syncfusion.WinForms.Core.Enums;

namespace Quizzz.IRTUP
{
    public partial class teacherPanel : UserControl
    {
        private signupWindow mainForm;
        public teacherPanel()
        {
            InitializeComponent();
        }

        public event EventHandler goBackBtn;
        private void backBtn_Click(object sender, EventArgs e)
        {
            goBackBtn?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler RegistrationSuccessful;
        private void registerBtn_Click(object sender, EventArgs e)
        {
            string username = usernameTxtBox.Text.Trim();
            string email = emailTxtBox.Text.Trim();
            string password = passwordTxtBox.Text.Trim();
            string confirmPassword = cPassTxtBox.Text.Trim();
            string subject = subjectComboBox.SelectedItem?.ToString();
            string gradeLevel = gradeLvlComboBox.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(subject) ||
                string.IsNullOrWhiteSpace(gradeLevel))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            if (!SamePassword(password, confirmPassword))
            {
                MessageBox.Show("Passwords do not match!");
                return;
            }

            if (!IsValidPassword(password))
            {
                MessageBox.Show("Weak password! Your password must be at least 8 characters long and include at least one uppercase letter, one lowercase letter, one number, and one special character.");
                return;
            }

            if (!IsValidEmail(email))
            {
                MessageBox.Show("Invalid email format. Please enter a valid email.");
                return;
            }

            TeacherManager teacherManager = new TeacherManager();
            bool isRegistered = teacherManager.RegisterTeacher(username, email, password, subject, gradeLevel);

            if (isRegistered)
            {
                MessageBox.Show("Registration successful!");
                var parentForm = this.FindForm(); // Get the parent form
                parentForm?.Close();
            }
            else
            {
                MessageBox.Show("Registration failed. Try again.");
            }


        }

        private bool IsValidPassword(string password)
        {
            string passwordPattern = @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";
            return Regex.IsMatch(password, passwordPattern);
        }

        private bool IsValidEmail(string email)
        {
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }

        private bool SamePassword(string password, string cPassword)
        {
            return password == cPassword;
        }

        private void showPasswordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            passwordTxtBox.PasswordChar = showPasswordCheckBox.Checked ? '\0' : '•';
            passwordTxtBox.UseSystemPasswordChar = !showPasswordCheckBox.Checked;
            cPassTxtBox.PasswordChar = showPasswordCheckBox.Checked ? '\0' : '•';
            cPassTxtBox.UseSystemPasswordChar = !showPasswordCheckBox.Checked;

            // Optional: Force focus back to the textbox
            passwordTxtBox.Focus();
            cPassTxtBox.Focus();
        }
    }
}
