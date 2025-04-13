using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Syncfusion;
using Quizzz.IRTUP.Panels;

namespace Quizzz.IRTUP
{
    public partial class signupWindow : Form
    {
        public signupWindow()
        {
            InitializeComponent();
            LoadRegisterMenu();
            registerMenu registerMenu = new registerMenu();
            registerMenu.RegisterTeacher += changeUserControlToTeacher;
            registerMenu.RegisterStudent += changeUserControlToStudent;
            teacherPanel teacherForm = new teacherPanel();
            teacherForm.goBackBtn += BackBtn;

        }
        private registerMenu _registerMenu;
        private void LoadRegisterMenu()
        {
            _registerMenu = new registerMenu(); // Assign to the field
            _registerMenu.RegisterTeacher += changeUserControlToTeacher; // Subscribe to its event
            _registerMenu.RegisterStudent += changeUserControlToStudent;
            signUpPanel.Controls.Add(_registerMenu);
        }

        private void BackBtn(object sender, EventArgs e)
        {
            backBtn();
        }

        private void backBtn()
        {
            signUpPanel.Controls.Clear();
            // Reattach the event in case it was lost
            _registerMenu.RegisterTeacher += changeUserControlToTeacher;
            signUpPanel.Controls.Add(_registerMenu);
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        private teacherPanel _teacherForm;
        private void changeToTeacher()
        {
            if (_teacherForm == null) // Create only once
            {
                _teacherForm = new teacherPanel();
                _teacherForm.goBackBtn += BackBtn;
            }
            signUpPanel.Controls.Clear();
            signUpPanel.Controls.Add(_teacherForm);
        }

        private StudentPanel1 _studentForm1;
        private void changeToStudent()
        {
            if (_studentForm1 == null)
            {
                _studentForm1 = new StudentPanel1();
                _studentForm1.goBackBtn += BackBtn;
            }
            signUpPanel.Controls.Clear();
            signUpPanel.Controls.Add(_studentForm1);
        }
        
        private void changeUserControlToTeacher(object sender, EventArgs e)
        {
            changeToTeacher();
        }

        private void changeUserControlToStudent(object sender, EventArgs e)
        {
            changeToStudent();
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        [DllImport("User32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

    }
}
