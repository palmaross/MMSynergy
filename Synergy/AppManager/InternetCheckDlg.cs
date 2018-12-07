using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SynManager
{
    public partial class InternetCheckDlg : Form
    {
        public InternetCheckDlg()
        {
            InitializeComponent();

            //timer = new Timer();
            //timer.Interval = 40;
            //timer.Tick += timer_Tick;

            this.Location = new System.Drawing.Point(MMUtils.MindManager.Left + 200, MMUtils.MindManager.Top + MMUtils.MindManager.Height - 22);
            lblInternet.Text = MMUtils.GetString("internet.check.text");
        }

        private void InternetCheckDlg_VisibleChanged(object sender, EventArgs e)
        {
            //if (this.Visible == true)
            //    timer.Start();
            //else
            //    timer.Stop();
        }

        //private void timer_Tick(object sender, EventArgs e)
        //{
        //    if (a < 30 && right || a == 0)
        //    {
        //        right = true;
        //        a++;
        //        label1.Left += 1;
        //    }
        //    else
        //    {
        //        right = false;
        //        a--;
        //        label1.Left -= 1;
        //    }
        //}

        //private Timer timer = null;
        //int a = 0;
        //bool right = true;
    }
}
