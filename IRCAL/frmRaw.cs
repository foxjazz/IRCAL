using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace myIRC
{
    public partial class frmRaw : Form
    {
        private IRCCore icore;
        public frmRaw(IRCCore irccore)
        {
            InitializeComponent();
            icore = irccore;
        }

        private void frmRaw_Load(object sender, EventArgs e)
        {
            rtb.SuspendLayout();
            if (icore.RawLog != null)
            {
                if (icore.RawLog.Count > 500)
                {
                    for (int i = 0; i < 500; i++)
                    {
                        rtb.AppendText(icore.RawLog[i]);
                    }
                }
                else
                {
                    for (int i = 0; i < icore.RawLog.Count; i++)
                    {
                        rtb.AppendText(icore.RawLog[i]);
                    }

                }
            }
            rtb.ResumeLayout();
            page = 1;
        }
        int page;
        private void RefreshAtStart_Click(object sender, EventArgs e)
        {
            rtb.SuspendLayout();
            rtb.Clear();
            if (icore.RawLog.Count > 500)
            {
                for (int i = 0; i < 500; i++)
                {
                    rtb.AppendText(icore.RawLog[i]);
                }
            }
            else
            {
                for (int i = 0; i < icore.RawLog.Count; i++)
                {
                    rtb.AppendText(icore.RawLog[i]);
                }

            }
            rtb.ResumeLayout();
            page = 1;
            
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            page++;
            int istart,iend;
            rtb.Clear();
            rtb.SuspendLayout();
            if (500 * page > icore.RawLog.Count)
            {
                iend = (500 * page);
                istart = icore.RawLog.Count;
                for (int i = istart; i < iend; i++)
                {
                    rtb.AppendText(icore.RawLog[i]);
                }
            }
            else
            {
                iend = (500 * page);
                istart = iend - 500;
                
                for (int i = istart; i < iend; i++)
                {
                    rtb.AppendText(icore.RawLog[i]);
                }

            }
            rtb.ResumeLayout();
        }
    }
}
