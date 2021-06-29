using CustomLogger.Appenders.Interfaces;
using CustomLogger.Layouts.Interfaces;
using CustomLogger.Misc;
using System;
using System.IO;

namespace CustomLogger.Appenders.Models
{
    public class FileAppender : BaseAppender
    {
        private string path;
        private string separator = System.IO.Path.DirectorySeparatorChar.ToString();

        public FileAppender(ILayout layout)
            : base(layout)
        {
            Path = string.Format("Misc{0}log.txt", separator);
        }

        private string Path
        {
            get => path;
            set { path = value; }
        }

        public void ChangeLogfilePath(string newPath)
        {
            Path = newPath;
        }

        public override void DumpLoggedData()
        {
            File.AppendAllText(Path, LogFile.Log.ToString());
        }
    }
}