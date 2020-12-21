namespace Esp
{
    public class AuditInfo
    {
        public int WordIndexArr { get; set; }
        public int CountInFile { get; set; }

        public AuditInfo(AuditInfo audit)
        {
            WordIndexArr = audit.WordIndexArr;
            CountInFile = audit.CountInFile;
        }

        public AuditInfo()
        {
            
        }
    }
}