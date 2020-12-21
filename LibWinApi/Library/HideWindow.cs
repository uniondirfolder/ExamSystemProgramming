using System;
using System.Runtime.InteropServices;

namespace LibWinApi.Library
{
    public class HideWindow
    {
        private const int SW_HIDE = 0;
        private const int SW_Show = 5;

        [DllImport("kernel32.dll")]
        static extern IntPtr GetWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
    }
}