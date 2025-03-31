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
using MaterialSkin;
using MaterialSkin.Controls;
using Quizzz.IRTUP.Classes;
using AntdUI.In;

namespace Quizzz.IRTUP
{
    public partial class MainMenu : Form
    {


        public MainMenu()
        {
            InitializeComponent();
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NMaF1cXGJCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdmWXxfd3RSRGReVkxxXkU=");
        }


        private void closeBtn_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void minimizeBtn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
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

        private void settingsBtn_Click(object sender, EventArgs e)
        {
            menuTransition2.Start();
        }

        private void menuBtn_Click(object sender, EventArgs e)
        {
            menuTransition.Start();
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


        bool isMaximized = false;
        private void manageQuizBtn_Click(object sender, EventArgs e)
        {
            manageQuizMenu ManageQuizMenu = new manageQuizMenu();
            mainMenuPanel.Controls.Clear();
            switch (WindowState)
            {
                case FormWindowState.Normal:
                    isMaximized = false;
                    break;
                case FormWindowState.Maximized:
                    isMaximized = true;
                    break;
            }
            if (isMaximized == true)
            {
                mainMenuPanel.Controls.Add(ManageQuizMenu);
                MainMenu_Resize(this, EventArgs.Empty);
            }
            else if (isMaximized == false)
            {
                mainMenuPanel.Controls.Add(ManageQuizMenu);
            }
        }

        private void MainMenu_Resize(object sender, EventArgs e)
        {
            manageQuizMenu ManageQuizMenu = new manageQuizMenu();
            mainMenuPanel.Width = this.ClientSize.Width - 20;
            mainMenuPanel.Height = this.ClientSize.Height - 20;

            // Resize the UserControl
            foreach (Control control in mainMenuPanel.Controls)
            {
                if (control is manageQuizMenu quizMenu)
                {
                    quizMenu.Width = mainMenuPanel.ClientSize.Width;
                    quizMenu.Height = mainMenuPanel.ClientSize.Height;

                    // Force refresh to apply new size
                    quizMenu.Refresh();
                }
            }

            mainMenuPanel.Refresh();
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

        private void mainMenuPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
