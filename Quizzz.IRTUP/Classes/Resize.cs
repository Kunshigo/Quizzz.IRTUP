using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizzz.IRTUP.Classes
{
    internal class Resize
    {
        public void ResizePanel(Control panel, Form form)
        {
            if (form.WindowState == FormWindowState.Maximized)
            {
                panel.Width = form.ClientSize.Width - 20;
                panel.Height = form.ClientSize.Height - 20;
            }
            else
            {
                panel.Width = 800;
                panel.Height = 600;
            }
        }
    }
}
