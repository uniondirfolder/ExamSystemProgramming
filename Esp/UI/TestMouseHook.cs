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
    public partial class TestMouseHook : Form
    {
        private readonly MonitorHookFactory _mhf;
        private readonly MonitorHookMouse _hook;
        private UPD _upd;
        public TestMouseHook(MonitorHookFactory mhf)
        {
            InitializeComponent();
            _mhf = mhf;
            _hook = _mhf.GetMouseObserver();
            _hook.Start();
            _hook.OnMouseInput += UpDate;
            _upd = ToList;
            ShowDialog();
        }

        private void TestMouseHook_FormClosing(object sender, FormClosingEventArgs e)
        {
            _hook.Stop();
           
        }

        private void UpDate(object o, MouseHookEventArgs e)
        {
            ToList(o,e);
        }
        private void ToList(object o, MouseHookEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(_upd, o, e); }
            else
            {
                label1.Text = $"{e.MouseMessage.ToString()} - X:{e.Point.x} Y:{e.Point.y}";
            }
           
        }

        public delegate void UPD(object o, MouseHookEventArgs e);

        

    }

}
