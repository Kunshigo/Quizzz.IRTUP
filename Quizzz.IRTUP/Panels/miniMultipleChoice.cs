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
    public partial class miniMultipleChoice : UserControl
    {
        public event EventHandler SlideClicked;

        public miniMultipleChoice()
        {
            InitializeComponent();
            this.Click += miniMultipleChoice_Click;
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_NCHITTEST = 0x0084;
            const int HTTRANSPARENT = (-1);

            if (m.Msg == WM_NCHITTEST)
            {
                m.Result = (IntPtr)HTTRANSPARENT;
                return;
            }

            base.WndProc(ref m);
        }

        private void miniMultipleChoice_Click(object sender, EventArgs e)
        {
            SlideClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
