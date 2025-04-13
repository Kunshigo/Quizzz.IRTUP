using Quizzz.IRTUP.Classes;
using Quizzz.IRTUP.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Quizzz.IRTUP
{
    public partial class loginWindow : Form
    {

        public loginWindow()
        {
            InitializeComponent();
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NMaF1cXGJCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdmWXxfd3RSRGReVkxxXkU=");
        }

        private void minimizeBtn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private void signUpLbl_Click(object sender, EventArgs e)
        {
            this.Hide();

            signupWindow signupWindow = new signupWindow();
            signupWindow.ShowDialog();

            signupWindow = null;
            this.Show();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            string username = usernameTxtBox.Text.Trim();
            string password = passwordTxtBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            bool loginSuccessful = false;

            // Try teacher login first
            TeacherManager teacherManager = new TeacherManager();
            int teacherId = teacherManager.LoginTeacher(username, password);

            if (teacherId > 0)
            {
                var teacherDetails = teacherManager.GetTeacherDetails(teacherId);
                if (teacherDetails != null)
                {
                    new MainMenuTeacher(teacherDetails).Show();
                    this.Hide();
                    return;
                }
            }

            // If not a teacher, try student login
            StudentManager studentManager = new StudentManager();
            int studentId = studentManager.LoginStudent(username, password);

            if (studentId > 0)
            {
                var studentDetails = studentManager.GetStudentDetails(studentId);
                if (studentDetails != null)
                {
                    new MainMenuStudent(studentDetails).Show();
                    this.Hide();
                    return;
                }
            }

            // If neither worked
            passwordTxtBox.Clear();
            passwordTxtBox.Focus();
            MessageBox.Show("Invalid username/email or password.");
        }

        private void showPasswordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            passwordTxtBox.PasswordChar = showPasswordCheckBox.Checked ? '\0' : '•';
            passwordTxtBox.UseSystemPasswordChar = !showPasswordCheckBox.Checked;

            passwordTxtBox.Focus();
        }
    }
}
