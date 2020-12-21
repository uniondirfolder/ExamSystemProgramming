using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace Esp
{
    public interface IScan
    {
        void UnpackMessage(object obj);
    }
    public abstract class Scan:IScan
    {
        public delegate void ScanListener(object obj);

        public ScanListener ScanDelegate;
        public virtual void UnpackMessage(object obj)
        {
            throw new NotImplementedException();
        }
    }
    public class FileSystemScan:Scan
    {
        private object _barrier = new object(); 
        private  ModuleBox _mBox;//for cooperate with module
        private List<DirectoryInfo> _workBodyDi;
        private List<FileInfo> _workBodyFi;
        private bool _pauseTask = false;
        public FileSystemScan(ModuleBox mBox)
        {
            _mBox = new ModuleBox(mBox);
            _workBodyDi= new List<DirectoryInfo>();
            _workBodyFi=new List<FileInfo>();
            this.ScanDelegate = UnpackMessage;
            _mBox.ModListener(new ModuleBox() { CodeId = CodeId.BindwithScan, ScanListener = ScanDelegate});
            _mBox.ScanFListener(new ModuleBox() { CodeId = CodeId.BindwithScan, ScanListener = ScanDelegate });
            try
            {
                foreach (var dirs in _mBox.ApplicationOptions.DirectoriesForScanStart)
                {
                    _workBodyDi.Add(dirs);
                }
                _mBox.ScanFListener(new ModuleBox(){CodeId = CodeId.UpdateLblDirectories, StringBody = _workBodyDi[0].FullName});
            }
            catch (Exception e)
            {
                throw new Exception("Init FileSysScan |"+ e.Message);
            }
        }

        #region METHODS_FOR_SYS_THREAD_POOL
        private void AddRangeToListDirInfo(object obj)
        {
            var index = obj is int i ? i : -1;
            lock (_barrier)
            {
                if (index > -1 && index < _workBodyDi.Count)
                {
                    try
                    {
                        _workBodyDi.AddRange(_workBodyDi[index].EnumerateDirectories());
                    }
                    catch
                    {
                        // :)
                    }
                }
            }
        }
        private void AddRAngeToListFilesInfo(object obj)
        {
            var index = obj is int i ? i : -1;
            lock (_barrier)
            {
                if (index > -1 && index < _workBodyDi.Count)
                {
                    try
                    {
                        _workBodyFi.AddRange(_workBodyDi[index].EnumerateFiles());
                    }
                    catch
                    {
                        // :)
                    }
                }
            }
        }
        #endregion

        #region SCAN_TASK_CORE
        private bool _endTasksWithFiles = false;
        public void GetAllDirectoryInfo(object obj)
        {
            var mBox = new ModuleBox(obj as ModuleBox);
            //---------------------------------------------
            int lowIndexDirInfo = 0;//lower index list dir_info
            int lowIndexFileInfo = 0;//lower index list files_info
            int lowIndexFileScan = 0;//lower index list files_info
            int thPool = 50;//count task in sys_thread pool
            int timeout = 100;//timeout for tasks - add to list dir_info
            string str = "";//info for scan_form - current directory added to list_info
            int counEmptyJobDirInfo = 5;//FUSE,breaker
            int counEmptyJobFileInfo = 5;//FUSE,breaker
            int counEmptyJobFileScan = 5;//FUSE,breaker
            bool endGetFolders = false;
            bool endGetFiles = false;
            
            //---------------------------------------------
            //---------------------------------------------
            while (!_endTasksWithFiles)
            {
                lock (_barrier)
                {

                    if (!_pauseTask && !endGetFolders)
                    {
                        if (lowIndexDirInfo < _workBodyDi.Count)
                        {
                            int count = _workBodyDi.Count - lowIndexDirInfo;
                            if (thPool < count) count = thPool;
                            while (count != 0)
                            {
                                ThreadPool.QueueUserWorkItem(AddRangeToListDirInfo, lowIndexDirInfo);
                                count--;
                                lowIndexDirInfo++;
                            }

                            str = $"{lowIndexDirInfo} : " + _workBodyDi[lowIndexDirInfo - 1].FullName;
                            mBox.ScanFListener(new ModuleBox()
                                {CodeId = CodeId.UpdateLblDirectories, StringBody = str});
                        }
                        else
                        {
                            if (counEmptyJobDirInfo != 0)
                            {
                                counEmptyJobDirInfo--;
                            }
                            else
                            {
                                endGetFolders = true;
                                mBox.ScanFListener(new ModuleBox()
                                    {CodeId = CodeId.UpdateLblDirectories, StringBody = @"Завершено."});
                            }
                        }
                    }

                    if (!_pauseTask && endGetFolders && !endGetFiles)
                    {
                        if (lowIndexFileInfo < _workBodyDi.Count)
                        {
                            int count = _workBodyDi.Count - lowIndexFileInfo;
                            if (thPool < count) count = thPool;
                            while (count != 0)
                            {
                                ThreadPool.QueueUserWorkItem(AddRAngeToListFilesInfo, lowIndexFileInfo);
                                count--;
                                lowIndexFileInfo++;
                            }

                            if (lowIndexFileInfo < _workBodyDi.Count)
                            {
                                str = $"{lowIndexFileInfo} : " + _workBodyDi[lowIndexFileInfo].FullName;
                                mBox.ScanFListener(
                                    new ModuleBox() {CodeId = CodeId.UpdateLblDirFiles, StringBody = str});
                            }
                        }
                        else
                        {
                            if (counEmptyJobFileInfo != 0)
                            {
                                counEmptyJobFileInfo--;
                            }
                            else
                            {
                                endGetFiles = true;
                                mBox.ScanFListener(new ModuleBox()
                                    {CodeId = CodeId.UpdateLblDirFiles, StringBody = @"Завершено."});
                            }
                        }
                    }

                    if (!_pauseTask && endGetFolders && endGetFiles)
                    {
                        if (lowIndexFileScan < _workBodyFi.Count)
                        {
                            int i = _workBodyFi.Count - lowIndexFileScan > thPool
                                ? thPool
                                : _workBodyFi.Count - lowIndexFileScan;
                            while (i != 0)
                            {
                                if (_workBodyFi[lowIndexFileScan].Length <= _mBox.ApplicationOptions.FileSizeIgnoreTo &&
                                    _workBodyFi[lowIndexFileScan].Length >=
                                    _mBox.ApplicationOptions.FileSizeIgnoreFrom &&
                                    _mBox.ApplicationOptions.FileExtensionForExecute.Contains(
                                        Path.GetExtension(_workBodyFi[lowIndexFileScan].FullName)))
                                {
                                    ThreadPool.QueueUserWorkItem(AuditValid,
                                        new ModuleBox(_mBox) {StringBody = _workBodyFi[lowIndexFileScan].FullName});
                                }

                                i--;
                                lowIndexFileScan++;
                            }
                            mBox.ScanFListener(new ModuleBox()
                                { CodeId = CodeId.ProgresBarMax, IntBody = _workBodyFi.Count });
                            mBox.ScanFListener(new ModuleBox()
                                { CodeId = CodeId.ProgresBarStep, IntBody = lowIndexFileScan });
                        }
                        else
                        {
                            if (counEmptyJobFileScan != 0)
                            {
                                counEmptyJobFileScan--;
                            }
                            else
                            {
                                _endTasksWithFiles = true;
                                mBox.ScanFListener(new ModuleBox() {CodeId = CodeId.ProgresBarStep, IntBody = 0});
                                Thread.Sleep(5000);
                                mBox.ModListener(new ModuleBox()
                                    { CodeId = CodeId.ListReportAudit, StringBody = @"Завершено." });
                                mBox.ScanFListener(new ModuleBox()
                                    {CodeId = CodeId.UpdateLblCurFile, StringBody = @"Завершено."});
                                

                            }
                        }
                    }

                }

                Thread.Sleep(timeout);
            }
        }
        #endregion
        public override void UnpackMessage(object obj)
        {

            lock (_barrier)
            {
                var m = obj as ModuleBox;
                if (m.CodeId == CodeId.StopScan)
                {
                    _endTasksWithFiles = true;

                }
                if (m.CodeId == CodeId.PauseScan)
                {
                    _pauseTask = !_pauseTask;

                }
            }
        }



        #region STATIC METHOD
        static readonly object FileLocker = new object();
        public static void AuditValid(object obj)
        {
            lock (FileLocker)//if not lock exp out of mem
            {
                var param = obj as ModuleBox;
                bool tryDo = true;

                byte[] file = null;
                if (param != null)
                {
                    byte[] pattern = Encoding.Default.GetBytes(param.ApplicationOptions.PatternForReplaceWord)
                        .ToArray();
                    List<byte[]> listB = new List<byte[]>();
                    byte[] fileWrite = null;
                    AuditResultInfo result = new AuditResultInfo(param.StringBody);
                    try
                    {
                        file = File.ReadAllBytes(param.StringBody).ToArray();

                    }
                    catch 
                    {
                        tryDo = false;
                    }

                    if (tryDo)
                    {
                        param.ScanFListener?.Invoke(new ModuleBox()
                            {CodeId = CodeId.UpdateLblCurFile, StringBody = Path.GetFileName(param.StringBody)});

                        for (int i = 0; i < param.ApplicationOptions.FilePatterns.Count; i++)
                        {
                            listB.Add(Encoding.Default.GetBytes(param.ApplicationOptions.FilePatterns[i]).ToArray());
                        }

                        for (int i = 0; i < listB.Count; i++)
                        {
                            var l = new ReplaceOccurrenceArr1WithArr2(file, listB[i], pattern);
                            if (l.CountReplace > 0)
                            {
                                result.FindWords.Add(new AuditInfo() {CountInFile = l.CountReplace, WordIndexArr = i});
                                fileWrite = l.Result.ToArray();
                            }
                        }

                        if (result.FindWords.Count > 0)
                        {
                           
                            
                            try
                            {
                                File.WriteAllBytes(
                                    param.ApplicationOptions.PathToCopyFile + @"\" + Path.GetFileName(param.StringBody),
                                    fileWrite ?? throw new InvalidOperationException());
                            }
                            catch
                            {
                                //
                            }

                            string write = "\r\n<" + DateTime.UtcNow.ToLongDateString();
                            write += "\r\nФайл : " + param.StringBody;
                            param.ModListener(new ModuleBox() { CodeId = CodeId.AddToAuditResult, Ari = new AuditResultInfo(result) });
                            foreach (var t in result.FindWords)
                            {
                                write += "\r\nСлово: " +
                                         param.ApplicationOptions.FilePatterns[t.WordIndexArr] +
                                         "[ " + t.CountInFile.ToString() + " ]";
                            }

                            write += "\r\n>";

                            File.AppendAllText(param.ApplicationOptions.PathToCopyFile + @"\Report.txt", write);


                            param.MainFListener?.Invoke(
                                new ModuleBox() {CodeId = CodeId.UpdateAuditMonitor, StringBody = write});
                        }


                    }
                }
            }
        }

        #endregion
    }

}

