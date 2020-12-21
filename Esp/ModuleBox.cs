using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Esp
{
    public interface IBox { }
    public abstract class Box:IBox
    {
        public CodeId CodeId { get; set; }
    }
    public sealed class ModuleBox:Box
    {
        public Module.ModuleListener ModListener;
        public Module.MainFormListener MainFListener;
        public Module.ScanFormListener ScanFListener;
        public Scan.ScanListener ScanListener;
        public string StringBody { get; set; }
        public int IntBody { get; set; }
        public AuditResultInfo Ari {get; set; }
        public List<AuditResultInfo> ListReportAudit { get; set; }
        public ApplicationOptions ApplicationOptions { get; set; }
        public ModuleBox()
        {
           ApplicationOptions = LoadOptions();
           ListReportAudit=new List<AuditResultInfo>();
        }
        public ModuleBox(ModuleBox moduleBox)
        {
            if (moduleBox != null)
            {
                ScanListener = moduleBox.ScanListener;
                ModListener = moduleBox.ModListener;
                MainFListener = moduleBox.MainFListener;
                ScanFListener = moduleBox.ScanFListener;
                CodeId = moduleBox.CodeId;
                StringBody = moduleBox.StringBody;
                ApplicationOptions = new ApplicationOptions(moduleBox.ApplicationOptions);
                Ari = new AuditResultInfo(moduleBox.Ari);
                ListReportAudit = new List<AuditResultInfo>(moduleBox.ListReportAudit);
            }
        }
        public static void SaveOptions(ApplicationOptions appOptions, string path = "options.esp")
        {
            BinaryFormatter formatter = new BinaryFormatter();

            try
            {
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, appOptions);
                }
            }
            catch
            {
                //
            }
        }
        public static ApplicationOptions LoadOptions(string path = "options.esp")
        {
            ApplicationOptions appOptions = new ApplicationOptions();
            BinaryFormatter formatter = new BinaryFormatter();

            try
            {
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    ApplicationOptions de = (ApplicationOptions)formatter.Deserialize(fs);
                    appOptions = new ApplicationOptions(de);
                }
            }
            catch
            {
                //
            }

            return appOptions;
        }

    }

    [Serializable]
    public sealed class ApplicationOptions : Box
    {
        public int TimeoutThreadGetDirectories;
        public int CountTasksInThreadPoolGetDirectories;

        public int TimeoutThreadGetFiles;
        public int CountTasksInThreadPoolGetFiles;

        public int TimeoutThreadScanFiles;
        public int CountTasksInThreadPoolGetScanFiles;

        public long FileSizeIgnoreFrom;
        public long FileSizeIgnoreTo;

        public List<DirectoryInfo> DirectoriesForScanStart { get; set; }
        public List<DirectoryInfo> DirectoriesForScanIgnore { get; set; }
        public List<string> FileExtensionForExecute { get; set; }
        public List<string> FilePatterns { get; set; }

        public string PatternForReplaceWord;

        public string PathToCopyFile;

        public bool PauseScan = false;



        #region CONSTR
        public ApplicationOptions(List<DirectoryInfo> directoriesForScanStart,
            List<DirectoryInfo> directoriesForScanIgnore,
            List<string> fileExtensionForIgnore,
            List<string> filePatterns,
            string pathToCopyFile,
            long fileSizeIgnoreFrom = 1,
            long fileSizeIgnoreTo = 1024,
            int timeoutThreadGetDirectories = 50,
            int countTasksInThreadPoolGetDirectories = 50,
            int timeoutThreadGetFiles = 50,
            int timeoutThreadScanFiles = 50,
            int countTasksInThreadPoolGetFiles = 50,
            int countTasksInThreadPoolGetScanFiles = 50,
            string patternForReplaceWord = "*******")
        {
            PathToCopyFile = pathToCopyFile;
            FileSizeIgnoreFrom = fileSizeIgnoreFrom;
            FileSizeIgnoreTo = fileSizeIgnoreTo;
            TimeoutThreadGetDirectories = timeoutThreadGetDirectories;
            CountTasksInThreadPoolGetDirectories = countTasksInThreadPoolGetDirectories;
            TimeoutThreadGetFiles = timeoutThreadGetFiles;
            CountTasksInThreadPoolGetFiles = countTasksInThreadPoolGetFiles;
            TimeoutThreadScanFiles = timeoutThreadScanFiles;
            CountTasksInThreadPoolGetScanFiles = countTasksInThreadPoolGetScanFiles;
            PatternForReplaceWord = patternForReplaceWord;

            DirectoriesForScanStart = new List<DirectoryInfo>(directoriesForScanStart);
            DirectoriesForScanIgnore = new List<DirectoryInfo>(directoriesForScanIgnore);
            FileExtensionForExecute = new List<string>(fileExtensionForIgnore);
            FilePatterns = new List<string>(filePatterns);
        }

        public ApplicationOptions(ApplicationOptions applicationOptions)
        {
            PathToCopyFile = applicationOptions.PathToCopyFile;
            FileSizeIgnoreFrom = applicationOptions.FileSizeIgnoreFrom;
            FileSizeIgnoreTo = applicationOptions.FileSizeIgnoreTo;
            TimeoutThreadGetDirectories = applicationOptions.TimeoutThreadGetDirectories;
            CountTasksInThreadPoolGetDirectories = applicationOptions.CountTasksInThreadPoolGetDirectories;
            TimeoutThreadGetFiles = applicationOptions.TimeoutThreadGetFiles;
            CountTasksInThreadPoolGetFiles = applicationOptions.CountTasksInThreadPoolGetFiles;
            TimeoutThreadScanFiles = applicationOptions.TimeoutThreadScanFiles;
            CountTasksInThreadPoolGetScanFiles = applicationOptions.CountTasksInThreadPoolGetScanFiles;
            PatternForReplaceWord =  applicationOptions.PatternForReplaceWord;

            DirectoriesForScanStart = new List<DirectoryInfo>(applicationOptions.DirectoriesForScanStart);
            DirectoriesForScanIgnore = new List<DirectoryInfo>(applicationOptions.DirectoriesForScanIgnore);
            FileExtensionForExecute = new List<string>(applicationOptions.FileExtensionForExecute);
            FilePatterns = new List<string>(applicationOptions.FilePatterns);
        }

        public ApplicationOptions()
        {
            PathToCopyFile = Directory.GetCurrentDirectory();
            FileSizeIgnoreFrom = 1;
            FileSizeIgnoreTo = 1024;
            TimeoutThreadGetDirectories =50;
            CountTasksInThreadPoolGetDirectories =50;
            TimeoutThreadGetFiles = 50;
            CountTasksInThreadPoolGetFiles = 50;
            TimeoutThreadScanFiles = 50;
            CountTasksInThreadPoolGetScanFiles = 50;
            PatternForReplaceWord = "*******";

            DirectoriesForScanStart = new List<DirectoryInfo>();
            DirectoriesForScanIgnore = new List<DirectoryInfo>();
            FileExtensionForExecute = new List<string>();
            FilePatterns = new List<string>();
        }
        #endregion
    }
}