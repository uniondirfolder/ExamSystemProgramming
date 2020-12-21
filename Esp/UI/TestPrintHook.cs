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
using LibWinApi.Library.Hooks;

namespace Esp.UI
{
    public partial class TestPrintHook : Form
    {
        private readonly MonitorHookFactory _mhf;
        private readonly MonitorHookPrinter _hook;
        public delegate void UPD(object o, PrintHookEventArgs e);
        private UPD _upd;
        public TestPrintHook(MonitorHookFactory mhf)
        {
            InitializeComponent();
            _mhf = mhf;
            _upd = ToList;
            _hook = _mhf.GetPrintObserver();
            _hook.Start();
            _hook.OnPrintEvent += UpDate;
            ShowDialog();
        }
        private void UpDate(object o, PrintHookEventArgs e)
        {
            ToList(o, e);
        }
        private void ToList(object o, PrintHookEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(_upd, o, e);
            }
            else
            {
                richTextBox1.Text = $"Printer -{e.EventData.PrinterName.ToString()}\r\nJob name:{e.EventData.JobName}\r\n  Pages:{e.EventData.Pages}\r\n Job size:{e.EventData.JobSize}";
            }

        }

        private void TestPrintHook_FormClosing(object sender, FormClosingEventArgs e)
        {
            _hook.Stop();
        }
    }
}
