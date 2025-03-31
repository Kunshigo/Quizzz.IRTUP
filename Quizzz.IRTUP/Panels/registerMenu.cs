using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quizzz.IRTUP
{
    public partial class registerMenu : UserControl
    {
        private Color hoverColor1 = Color.FromArgb(77, 161, 169);
        private Color hoverColor2 = Color.FromArgb(215, 232, 186);
        private Color defaultColor = Color.FromArgb(255, 255, 255);
        public registerMenu()
        {
            InitializeComponent();
            teacherBtn.MouseEnter += teacherBtn_MouseEnter;
            teacherBtn.MouseLeave += teacherBtn_MouseLeave;
            studentBtn.MouseEnter += studentBtn_MouseEnter;
            studentBtn.MouseLeave += studentBtn_MouseLeave;
        }

        private void teacherBtn_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                btn.BackColor = defaultColor;
            }
        }

        private void teacherBtn_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                btn.BackColor = hoverColor1;
            }
        }

        private void studentBtn_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                btn.BackColor = hoverColor2;
            }
        }

        private void studentBtn_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null)
            {
                btn.BackColor = defaultColor;
            }
        }

        private void loginBtn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form parentForm = this.FindForm();
            if (parentForm != null)
            {
                parentForm.Close();
            }
        }

        private void teacherBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
