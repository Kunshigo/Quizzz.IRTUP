using Quizzz.IRTUP.Panels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quizzz.IRTUP.Forms
{
    public partial class MainMenuStudent : Form
    {
        public Dictionary<string, string> studentDetails;

        public MainMenuStudent(Dictionary<string, string> studentDetails)
        {
            InitializeComponent();
            this.studentDetails = studentDetails;
            InitializeStudentUI();
        }

        private void InitializeStudentUI()
        {
            welcomeLbl.Text = $"Welcome, {studentDetails["Username"]}!";

            mainMenuPanel.Controls.Clear();
            mainMenuPanel.Controls.Add(new ViewQuizzes(studentDetails));

        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void maximizeBtn_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void minimizeBtn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        bool sideBarExpand = false;
        private void sideBarTransition_Tick(object sender, EventArgs e)
        {
            if (sideBarExpand == false)
            {
                sideBar.Width += 10;
                if (sideBar.Width >= 199)
                {
                    sideBarExpand = true;
                    sideBarTransition.Stop();
                }
            }
            else
            {

                sideBar.Width -= 10;
                if (sideBar.Width <= 58)
                {
                    sideBarExpand = false;
                    sideBarTransition.Stop();
                }
            }
        }

        private void menuPanelBtn_Click(object sender, EventArgs e)
        {
            sideBarTransition.Start();
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

        private void notificationBtn_Click(object sender, EventArgs e)
        {

        }

        private void viewQuizBtn_Click(object sender, EventArgs e)
        {
            mainMenuPanel.Controls.Clear();
            mainMenuPanel.Controls.Add(new ViewQuizzes(studentDetails));
        }

        private void menuBtn_Click(object sender, EventArgs e)
        {
            menuTransition.Start();
        }

        bool menuExpand = false;
        private void menuTransition_Tick(object sender, EventArgs e)
        {
            if (menuExpand == false)
            {
                menuContainer1.Height += 10;
                if (menuContainer1.Height >= 175)
                {
                    menuTransition.Stop();
                    menuExpand = true;
                }
            }
            else
            {
                menuContainer1.Height -= 10;
                if (menuContainer1.Height <= 58)
                {
                    menuTransition.Stop();
                    menuExpand = false;
                }
            }
        }

        private void settingsBtn_Click(object sender, EventArgs e)
        {
            menuTransition2.Start();
        }

        bool menuExpand2 = false;
        private void menuTransition2_Tick(object sender, EventArgs e)
        {
            if (menuExpand2 == false)
            {
                menuContainer2.Height += 10;
                if (menuContainer2.Height >= 175)
                {
                    menuTransition2.Stop();
                    menuExpand2 = true;
                }
            }
            else
            {
                menuContainer2.Height -= 10;
                if (menuContainer2.Height <= 58)
                {
                    menuTransition2.Stop();
                    menuExpand2 = false;
                }
            }
        }

        private void generalSettingsBtn_Click(object sender, EventArgs e)
        {

        }

        private void accountSettingsBtn_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            loginWindow loginWindow = new loginWindow();
            loginWindow.Show();
            this.Close();
        }
    }
}
