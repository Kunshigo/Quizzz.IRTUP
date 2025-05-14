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
            subjectComboBox.SelectedItem = teacherDetails["Subject"];
        }

        private void editAccountBtn_Click(object sender, EventArgs e)
        {
            usernameTxtBox.Enabled = true;
            emailTxtBox.Enabled = true;
            subjectComboBox.Enabled = true;
            saveBtn.Visible = true;
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            string newUsername = usernameTxtBox.Text.Trim();
            string newEmail = emailTxtBox.Text.Trim();
            string newSubject = subjectComboBox.SelectedItem.ToString();

            TeacherManager tm = new TeacherManager();

            bool updated = tm.UpdateTeacherInfo(
                teacherId: int.Parse(teacherDetails["TeacherID"]),
                username: newUsername,
                email: newEmail,
                password: teacherDetails["Password"],
                subject: newSubject
            );

            if (updated)
            {
                MessageBox.Show("Account updated successfully.");
                saveBtn.Visible = false;

                usernameTxtBox.Enabled = false;
                emailTxtBox.Enabled = false;
                subjectComboBox.Enabled = false;

                // Update stored details
                teacherDetails["Username"] = newUsername;
                teacherDetails["Email"] = newEmail;
                teacherDetails["Subject"] = newSubject;
            }
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