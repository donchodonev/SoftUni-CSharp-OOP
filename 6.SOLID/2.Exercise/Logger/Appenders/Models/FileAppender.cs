using CustomLogger.Misc;
using Logger.Appenders.Interfaces;
using Logger.Layouts.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CustomLogger.Appenders.Models
{
    public class FileAppender : IAppender
    {
        private string path;
        private string separator = System.IO.Path.DirectorySeparatorChar.ToString();

        public FileAppender(ILayout layout)
        {
            Layout = layout;
            path = string.Format("Misc{0}log.txt", separator);
        }

        public ILayout Layout { get; }
        public (string date, string msgType, string text) OutputText { get; set; }

        public string Path
        {
            get => path;
            set { path = value; }
        }

        public ReportLevel ReportLevel { get; set; }

        public void Append()
        {
            Enum.TryParse(OutputText.msgType, true, out ReportLevel result);

            if (result >= ReportLevel)
            {
                File.AppendAllText(Path, string.Format(Layout.LayoutFormat, OutputText.date, OutputText.msgType, OutputText.text) + Environment.NewLine);
            }
        }
    }
}