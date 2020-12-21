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
    public partial class TestAppHook : Form
    {
        private readonly MonitorHookFactory _mhf;
        private readonly MonitorHookApplication _hook;
        public delegate void UPD(object o, ApplicationHookEvenArgs e);
        private UPD _upd;
        public TestAppHook(MonitorHookFactory mhf)
        {
            InitializeComponent();
            _mhf = mhf;
            _upd = ToList;
            _hook = _mhf.GetApplicationObserver();
            _hook.Start();
            _hook.OnAppWindowChange += UpDate;
            ShowDialog();
        }

        private void TestAppHook_FormClosing(object sender, FormClosingEventArgs e)
        {
            _hook.Stop();
            
        }
        private void UpDate(object o, ApplicationHookEvenArgs e)
        {
            ToList(o, e);
        }
        private void ToList(object o, ApplicationHookEvenArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(_upd, o, e);
            }
            else
            {
                richTextBox1.Text = $"App name -{e.WindowInfo.AppName}\r\n path - {e.WindowInfo.AppPath}\r\ntitle- {e.WindowInfo.AppTitle}\r\n {e.Events.ToString()}\r\n";
            }

        }
    }
}
