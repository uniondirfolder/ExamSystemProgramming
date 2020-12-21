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
    public partial class TestKeyBoardHook : Form
    {
        private readonly MonitorHookFactory _mhf;
        private readonly MonitorHookKeyboard _hook;
        public delegate void UPD(object o, KeyInputHookEventArgs e);
        private UPD _upd;
        public TestKeyBoardHook(MonitorHookFactory mhf)
        {
            InitializeComponent();
            _mhf = mhf;
            _upd = ToList;
            _hook = _mhf.GetKeyboardObserver();
            _hook.Start();
            _hook.OnKeyInput += UpDate;
            ShowDialog();
        }
        private void UpDate(object o, KeyInputHookEventArgs e)
        {
            ToList(o, e);
        }
        private void ToList(object o, KeyInputHookEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(_upd, o, e);
            }
            else
            {
                label1.Text = $"Type -{e.Key.EventType} - name:{e.Key.KeyName}";
            }

        }

        private void TestKeyBoardHook_FormClosing(object sender, FormClosingEventArgs e)
        {
            _hook.Stop();
           
        }
    }
}
