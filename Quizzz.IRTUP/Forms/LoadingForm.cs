using AntdUI;
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
    public partial class LoadingForm : Form
    {

        public LoadingForm(string message = "Authenticating...")
        {
            InitializeComponent();

        }

        public void UpdateMessage(string message)
        {
            lblMessage.Text = message;
        }
        
    }
}
