using CustomLogger.Appenders.Interfaces;
using CustomLogger.Layouts.Interfaces;
using CustomLogger.Misc;
using System;

namespace CustomLogger.Appenders.Models
{
    public class ConsoleAppender : BaseAppender
    {
        public ConsoleAppender(ILayout layout)
            : base(layout)
        {
        }

        public override void DumpLoggedData()
        {
            Console.Write(LogFile.Log);
        }
    }
}