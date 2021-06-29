using CustomLogger.LogParser.Interfaces;
using System;

namespace CustomLogger.LogParser.Models
{
    public class LogParser : ILogParser
    {
        private bool isDone = false;
        public string DateAndTime { get; set; }
        public string Message { get; set; }
        public string Severity { get; set; }

        public bool IsDone()
        {
            return isDone;
        }

        public void Parse()
        {
            string[] inputArgs = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);

            if (inputArgs.Length < 3)
            {
                isDone = true;
            }
            else
            {
                Severity = inputArgs[0];
                DateAndTime = inputArgs[1];
                Message = inputArgs[2];
            }
        }
    }
}