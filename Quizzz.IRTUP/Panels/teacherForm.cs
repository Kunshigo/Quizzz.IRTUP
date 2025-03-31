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
    public partial class teacherForm : UserControl
    {

        private signupWindow mainForm;
        public teacherForm()
        {
            InitializeComponent();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Form parentForm = this.FindForm();

            if (parentForm is signupWindow mainForm)
            {
                mainForm.Controls.Clear();
                Control mainPanel = mainForm.Controls.Find("mainPanel", true).FirstOrDefault();

                if (mainPanel != null)
                {
                    mainForm.Controls.Add(mainPanel);
                }
                else
                {
                    MessageBox.Show("Main panel not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
