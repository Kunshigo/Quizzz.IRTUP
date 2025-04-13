using Quizzz.IRTUP.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quizzz.IRTUP.Panels
{
    public partial class StudentPanel1 : UserControl
    {
        public event EventHandler goBackBtn;

        public StudentPanel1()
        {
            InitializeComponent();
            birthDatePicker.Value = DateTime.Now.AddYears(-18);
            birthDatePicker.MaxDate = DateTime.Now;
            birthDatePicker.Format = DateTimePickerFormat.Custom;
            birthDatePicker.CustomFormat = "MMMM dd yyyy"; // Display format
            gradeLvlComboBox.SelectedIndex = 1;
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            goBackBtn?.Invoke(this, EventArgs.Empty);
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            string username = usernameTxtBox.Text.Trim();
            string email = emailTxtBox.Text.Trim();
            string password = passwordTxtBox.Text.Trim();
            string confirmPassword = cPassTxtBox.Text.Trim();
            DateTime birthDate = birthDatePicker.Value;
            string gradeLevel = gradeLvlComboBox.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(password) || string.IsNullOrWhiteSpace(gradeLevel))
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
                MessageBox.Show("Password must be at least 8 characters long and include uppercase, lowercase, number, and special character.");
                return;
            }

            if (!IsValidEmail(email))
            {
                MessageBox.Show("Invalid email format. Please enter a valid email.");
                return;
            }

            if (birthDate > DateTime.Now)
            {
                MessageBox.Show("Birth date cannot be in the future.");
                return;
            }

            StudentManager studentManager = new StudentManager();
            bool isRegistered = studentManager.RegisterStudent(
                username, email, password, birthDate, gradeLevel);

            if (isRegistered)
            {
                MessageBox.Show("Registration successful!");
                var parentForm = this.FindForm();
                parentForm?.Close();
            }
            else
            {
                MessageBox.Show("Registration failed. Try again.");
            }
        }

        private bool IsValidPassword(string password)
        {
            return password.Length >= 8 &&
                   Regex.IsMatch(password, @"[A-Z]") &&
                   Regex.IsMatch(password, @"[a-z]") &&
                   Regex.IsMatch(password, @"[0-9]") &&
                   Regex.IsMatch(password, @"[^a-zA-Z0-9]");
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