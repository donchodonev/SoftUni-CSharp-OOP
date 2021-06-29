using System;
using System.Collections.Generic;
using System.Text;

namespace CustomLogger.LogParser.Interfaces
{
    public interface ILogParser
    {
        public string DateAndTime { get; set; }
        public string Message { get; set; }
        public string Severity { get; set; }

        public bool IsDone();

        public void Parse();
    }
}