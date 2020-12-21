
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;
using Esp.UI;
using LibWinApi;

namespace Esp
{
    public class Module : IDisposable
    {
        #region MEMBERS
        private readonly object _locker = new object();
        private bool _isUiActive = false;
        public ModuleBox MBox;
        public ModuleListener ModListener;
        public MainFormListener MainFListener;
        public ScanFormListener ScanFListener;
        public static List<string> FilesTypeInSystem { get; set; }
        public static DriveInfo[] CurrentDriveInfo { get; set; }
        public List<AuditResultInfo> AuditResult { get; set; }= new List<AuditResultInfo>();
        public ApplicationOptions AppOptions { get; set; }
        private Thread _scanTask;
        private readonly MonitorHookFactory _mhf= new MonitorHookFactory();
        #endregion
        public Module(object obj)
        {
            if (obj != null)
            {
                MBox = (ModuleBox) obj;
                FilesTypeInSystem = RegisteredFileType.GetFileType();
                UpdateDriveInfo();
                ModListener = UnpackBox;
                AuditResult = new List<AuditResultInfo>();
                if (MBox.ApplicationOptions == null)
                {
                    AppOptions = ModuleBox.LoadOptions();
                }
            }
            
        }


        #region METHODS
        public static void UpdateDriveInfo()
        {
            CurrentDriveInfo = DriveInfo.GetDrives();
        }
        public static List<string> GetDrivesName()
        {
            UpdateDriveInfo();
            List<string> stringList = new List<string>();
            foreach (DriveInfo driveInfo in CurrentDriveInfo)
                stringList.Add(driveInfo.Name);
            return stringList;
        }
        public static List<string> GetListDriveState(string name)
        {
            List<string> stringList1 = new List<string>();
            if (!string.IsNullOrEmpty(name))
            {
                UpdateDriveInfo();
                if (name == "../")
                {
                    long num1 = 0;
                    long num2 = 0;
                    foreach (DriveInfo driveInfo in CurrentDriveInfo)
                    {
                        if (driveInfo.IsReady)
                        {
                            try
                            {
                                num1 += driveInfo.AvailableFreeSpace;
                                num2 += driveInfo.TotalSize;
                            }
                            catch (Exception ex)
                            {
                                stringList1.Add(ex.Message);
                            }
                        }
                    }
                    List<string> stringList2 = stringList1;
                    long num3 = num1 / 1073741824L;
                    string str1 = "Доступний простір: " + num3.ToString() + string.Format(" {0}\r\n", (object)ByteTo.GB);
                    stringList2.Add(str1);
                    List<string> stringList3 = stringList1;
                    num3 = num2 / 1099511627776L;
                    string str2 = "Загальний розмір: " + num3.ToString() + string.Format(" {0}\r\n", (object)ByteTo.TB);
                    stringList3.Add(str2);
                }
                else
                {
                    foreach (DriveInfo driveInfo in CurrentDriveInfo)
                    {
                        if (driveInfo.Name == name && driveInfo.IsReady)
                        {
                            try
                            {
                                stringList1.Add("Мітка: " + driveInfo.VolumeLabel + "\r\n");
                                stringList1.Add("Тип файлової системи: " + driveInfo.DriveFormat + "\r\n");
                                stringList1.Add("Доступний простір: " + (driveInfo.AvailableFreeSpace / 1048576L).ToString() + string.Format(" {0}\r\n", (object)ByteTo.MB));
                                stringList1.Add("Загальний розмір: " + (driveInfo.TotalSize / 1073741824L).ToString() + string.Format(" {0}\r\n", (object)ByteTo.GB));
                            }
                            catch (Exception ex)
                            {
                                stringList1.Add(ex.Message);
                            }
                        }
                    }
                }
            }
            return stringList1;
        }
        public static string GetStringDriveState(string name)
        {
            string str1 = "";
            if (!string.IsNullOrEmpty(name))
            {
                foreach (string str2 in GetListDriveState(name).ToArray())
                    str1 += str2;
            }
            return str1;
        }
        public static List<string> GetWordsFromString(string text)
        {
            List<string> stringList = new List<string>();
            if (text == null)
                return stringList;
            for (int index = 0; index < text.Length; ++index)
            {
                string str = "";
                for (; index < text.Length && (char.IsLetterOrDigit(text[index]) && !char.IsWhiteSpace(text[index])); ++index)
                    str += text[index].ToString();
                if (str.Length > 0)
                    stringList.Add(str);
            }
            return stringList;
        }
        public static string ItemToStringFromListBox(ListBox list)
        {
            string str1 = "";
            foreach (string str2 in list.Items)
                str1 = str1 + str2 + "\r\n";
            return str1;
        }
        public static List<string> ItemToListStringsFromListBox(ListBox list)
        {
            List<string> listR = new List<string>();
            foreach (string str in list.Items)
                listR.Add(str);
            return listR;
        }
        public static List<string> ItemToListStringsFromComboBox(ComboBox item)
        {
            List<string> listR = new List<string>();
            foreach (string str in item.Items)
                listR.Add(str);
            return listR;
        }
        public static List<DirectoryInfo> ItemToListDirInfoFromListBox(ListBox item)
        {
            List<DirectoryInfo> list = new List<DirectoryInfo>();
            foreach (var value in item.Items)
            {
                try
                {
                    list.Add(new DirectoryInfo(value.ToString()));
                }
                catch
                {
                    //
                }
            }

            return list;
        }
        
        #region LISEN
        private Queue<CodeId> MustDo = new Queue<CodeId>();
        private Queue<ModuleBox> MBoxs = new Queue<ModuleBox>();
        private void UnpackBox(object obj)
        {
            lock (_locker)
            {
                if (obj is ModuleBox pin)
                {
                    MustDo.Enqueue(pin.CodeId);
                    MBoxs.Enqueue(new ModuleBox(pin));
                }
            }
        }
        #endregion

        #region LOOP
        private void LoopModule(object obj)
        {
            if (obj != null)
            {
                ModuleBox moduleBox = obj as ModuleBox;
                MBox = new ModuleBox(moduleBox) {ModListener = UnpackBox};

                if (MBox.MainFListener != null)
                {
                    _isUiActive = true;
                    MBox.MainFListener = moduleBox.MainFListener;
                    MBox.MainFListener(new ModuleBox()
                    {
                        CodeId = CodeId.BindWithModule,
                        ModListener = MBox.ModListener
                    });
                }

                bool flag = true;
                while (flag)
                {
                    Thread.Sleep(100);
                    lock (_locker)
                    {
                        if (MustDo.Count > 0 && MBoxs.Count>0)
                        {
                            
                            switch (MustDo.Peek())
                            {
                                case CodeId.ListReportAudit:
                                    MustDo.Dequeue();
                                    if (_isUiActive)
                                    {
                                        ModuleBox m = new ModuleBox(){ CodeId = CodeId.ListReportAudit };
                                        for (int i = 0; i < AuditResult.Count; i++)
                                        {
                                            m.ListReportAudit.Add(AuditResult[i]);
                                            File.AppendAllText("TTX.txt", $"\r\n{AuditResult[i].FindWords.Count}");
                                        }
                                        MBox.MainFListener(m);
                                    }
                                    MBoxs.Dequeue();
                                    break;
                                case CodeId.AddToAuditResult:
                                    MustDo.Dequeue();
                                    var ari = MBoxs.Peek();
                                    this.AuditResult.Add(new AuditResultInfo(ari.Ari));
                                    MBoxs.Dequeue();
                                    break;
                                case CodeId.BindWithScanF:
                                    MustDo.Dequeue();
                                    var bwsf = MBoxs.Peek();
                                    MBox.ScanFListener = bwsf.ScanFListener;
                                    MBoxs.Dequeue();
                                    break;
                                case CodeId.BindwithScan:
                                    MustDo.Dequeue();
                                    var bws = MBoxs.Peek();
                                    MBox.ScanListener = bws.ScanListener;
                                    MBoxs.Dequeue();
                                    break;
                                case CodeId.UnBindWithScanF:
                                    moduleBox.ScanFListener = null;
                                    MustDo.Dequeue();
                                    MBoxs.Dequeue();
                                    break;
                                case CodeId.DisposeModule:
                                    flag = false;
                                    if (_scanTask != null)
                                    {
                                        if (_scanTask.IsAlive)
                                        {
                                            _scanTask.Abort();
                                        }
                                    }
                                    MustDo.Clear();
                                    MBoxs.Clear();
                                    break;
                                case CodeId.RunScanForm:
                                    AuditResult.Clear();
                                    MustDo.Dequeue();
                                    _scanTask = new Thread(RunScanFormExternalTrigger);
                                    ModuleBox t = new ModuleBox(MBoxs.Dequeue());
                                    _scanTask.Start(t);
                                    break;
                                case CodeId.TestHookApp:
                                    MustDo.Dequeue();
                                    MBoxs.Dequeue();
                                    new Thread(new TestAppHook(_mhf).Show).Start();
                                    break;
                                case CodeId.TestHookKeyboard:
                                    MustDo.Dequeue();
                                    MBoxs.Dequeue();
                                    new Thread(new TestKeyBoardHook(_mhf).Show).Start();
                                    break;
                                case CodeId.TestHookMouse:
                                    MustDo.Dequeue();
                                    MBoxs.Dequeue();
                                    
                                    new Thread(new TestMouseHook(_mhf).Show).Start();
                                    break;
                                case CodeId.TestHookClipboard:
                                    MustDo.Dequeue();
                                    MBoxs.Dequeue();
                                    new Thread(new TestClipBordHook(_mhf).Show).Start();
                                    break;
                                case CodeId.TestHookPrint:
                                    MustDo.Dequeue();
                                    MBoxs.Dequeue();
                                    new Thread(new TestPrintHook(_mhf).Show).Start();
                                    break;
                                case CodeId.TestCameraSpy:
                                    MustDo.Dequeue();
                                    MBoxs.Dequeue();
                                    new Thread(new ClientSpy.ClientSpy().TestRun);
                                    new Thread(new ServerSpy.TestVideo().Show).Start();
                                    break;
                            }
                        }
                    }

                }

                Dispose();
            }
        }

        public void RunScanFormExternalTrigger(object obj)//if this is instantiated in UI 
        {
            int num = (int)new ScanF(obj).ShowDialog();
        }

        public void RunScanFormInternalStart(object obj)
        {
            new Thread(new ScanF(obj).Show).Start();
        }
        public void RunModule(object obj)
        {
            new Module(obj).LoopModule(obj);
        }
        #endregion

        #endregion

        #region DISPOUSE
       

        private void ReleaseUnmanagedResources()
        {
        }

        public void Dispose()
        {
            ModuleBox.SaveOptions(AppOptions);

            FilesTypeInSystem.Clear();
            AuditResult.Clear();
            ReleaseUnmanagedResources();
            GC.SuppressFinalize((object)this);
        }

        ~Module()
        {
            ReleaseUnmanagedResources();
        }
        #endregion

        #region DELGS

        public delegate void ModuleListener(object obj);

        public delegate void MainFormListener(object obj);

        public delegate void ScanFormListener(object obj);

        #endregion
        
    }
}
