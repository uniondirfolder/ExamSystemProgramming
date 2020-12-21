using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibWinApi;
using LibWinApi.AppEngine;
using LibWinApi.Library.Classes;

namespace Esp.UI
{
    public partial class TestClipBordHook : Form
    {
        private readonly MonitorHookFactory _mhf;
        private readonly MonitorHookClipboard _hook;
        public delegate void UPD(object o, ClipboardHookEventArgs e);
        private UPD _upd;
        public TestClipBordHook(MonitorHookFactory mhf)
        {
            InitializeComponent();
            _mhf = mhf;
            _upd = ToList;
            _hook = _mhf.GetClipboardObserver();
            _hook.Start();
            _hook.OnClipboardModified += UpDate;
            ShowDialog();
        }
        private void UpDate(object o, ClipboardHookEventArgs e)
        {
            ToList(o, e);
        }
        private void ToList(object o, ClipboardHookEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(_upd, o, e);
            }
            else
            {
                richTextBox1.Text = $"Type -{e.DataFormat.ToString()}\r\n:{e.Data}";
            }

        }

        private void TestClipBordHook_FormClosing(object sender, FormClosingEventArgs e)
        {
            _hook.Stop();
           
        }
    }
}
