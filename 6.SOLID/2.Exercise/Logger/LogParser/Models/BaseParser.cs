using CustomLogger.LogParser.Interfaces;
using System;

namespace CustomLogger.LogParser.Models
{
    public abstract class BaseParser
    {
        protected bool isDone = false;
        public string DateAndTime { get; protected set; }
        public string Message { get; protected set; }
        public string Severity { get; protected set; }

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