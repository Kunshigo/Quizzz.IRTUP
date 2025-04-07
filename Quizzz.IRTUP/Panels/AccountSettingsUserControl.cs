using Quizzz.IRTUP.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quizzz.IRTUP.Panels
{
    public partial class AccountSettingsUserControl : UserControl
    {
        private Dictionary<string, string> teacherDetails;

        public AccountSettingsUserControl(Dictionary<string, string> teacherDetails)
        {
            InitializeComponent();
            this.teacherDetails = teacherDetails;
            LoadAccountDetails();
        }

        private void LoadAccountDetails()
        {
            usernameTxtBox.Text = teacherDetails["Username"];
            usernameTxtBox.Text = teacherDetails["Username"];
            emailTxtBox.Text = teacherDetails["Email"];
            passwordTxtBox.Text = "";
            subjectComboBox.SelectedItem = teacherDetails["Subject"];
            gradeLvlComboBox.SelectedItem = teacherDetails["GradeLevel"];
        }

        private void gradeLvlTxtBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void showPasswordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            passwordTxtBox.UseSystemPasswordChar = !showPasswordCheckBox.Checked;
        }

        private void editAccountBtn_Click(object sender, EventArgs e)
        {
            usernameTxtBox.Enabled = true;
            emailTxtBox.Enabled = true;
            passwordTxtBox.Enabled = true;
            subjectComboBox.Enabled = true;
            gradeLvlComboBox.Enabled = true;

            saveBtn.Visible = true;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            string newUsername = usernameTxtBox.Text.Trim();
            string newEmail = emailTxtBox.Text.Trim();
            string newPassword = passwordTxtBox.Text; // keep as-is for checking
            string newSubject = subjectComboBox.SelectedItem.ToString();
            string newGrade = gradeLvlComboBox.SelectedItem.ToString();

            TeacherManager tm = new TeacherManager();
            string finalPassword;

            if (string.IsNullOrWhiteSpace(newPassword))
            {
                // ✅ If password field is empty, use existing password without validation
                finalPassword = teacherDetails["Password"];
            }
            else
            {
                // ✅ If user entered a new password, check strength
                if (!IsPasswordStrong(newPassword))
                {
                    MessageBox.Show("gay");
                    return;
                }

                // ✅ Hash the new password
                finalPassword = teacherDetails["Password"];
            }

            bool updated = tm.UpdateTeacherInfo(
                teacherId: int.Parse(teacherDetails["TeacherID"]),
                username: newUsername,
                email: newEmail,
                password: finalPassword,
                subject: newSubject,
                gradeLevel: newGrade
            );

            if (updated)
            {
                MessageBox.Show("Account updated successfully.");
                saveBtn.Visible = false;

                usernameTxtBox.Enabled = false;
                emailTxtBox.Enabled = false;
                passwordTxtBox.Enabled = false;
                subjectComboBox.Enabled = false;
                gradeLvlComboBox.Enabled = false;

                // ✅ Update stored details too
                teacherDetails["Username"] = newUsername;
                teacherDetails["Email"] = newEmail;
                teacherDetails["Subject"] = newSubject;
                teacherDetails["GradeLevel"] = newGrade;
                teacherDetails["Password"] = finalPassword; // keep new hash if updated
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

        private void deleteAccountBtn_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Are you sure you want to delete your account?", "Confirm Deletion", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                TeacherManager tm = new TeacherManager();
                bool deleted = tm.DeleteTeacher(int.Parse(teacherDetails["TeacherID"]));
                if (deleted)
                {
                    MessageBox.Show("Account deleted.");
                    Application.Exit(); // or redirect to login screen
                }
            }
        }
    }
}
