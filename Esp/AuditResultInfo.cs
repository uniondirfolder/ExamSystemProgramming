using System.Collections.Generic;
using System.IO;

namespace Esp
{
    public class AuditResultInfo
    {
        public string File { get; set; }
        public List<AuditInfo> FindWords { get; set; } = new List<AuditInfo>();

        public AuditResultInfo(string file)
        {
            File = file;
            FindWords = new List<AuditInfo>();
        }
        public AuditResultInfo(AuditResultInfo audit)
        {
            if (audit != null)
            {
                this.FindWords = new List<AuditInfo>();
                for (int i = 0; i < audit.FindWords.Count; i++)
                {
                    FindWords.Add(new AuditInfo(audit.FindWords[i]));
                }

                File = audit.File;
            }
        }
    }
}