using System;
using LibWinApi.AppEngine;
using LibWinApi.Library.Classes;
using LibWinApi.Library.Hooks;

namespace LibWinApi
{
    public class MonitorHookFactory:IDisposable
    {
        private readonly SyncHookFactory _syncHookFactory = new SyncHookFactory();

        public void Dispose()
        {
            _syncHookFactory.Dispose();
        }

        public MonitorHookApplication GetApplicationObserver()
        {
            return new MonitorHookApplication(_syncHookFactory);
        }

        public MonitorHookKeyboard GetKeyboardObserver()
        {
            return new MonitorHookKeyboard(_syncHookFactory);
        }

        public MonitorHookMouse GetMouseObserver()
        {
            return new MonitorHookMouse(_syncHookFactory);
        }

        public MonitorHookClipboard GetClipboardObserver()
        {
            return new MonitorHookClipboard(_syncHookFactory);
        }

        public MonitorHookPrinter GetPrintObserver()
        {
            return new MonitorHookPrinter(_syncHookFactory);
        }
    }
}