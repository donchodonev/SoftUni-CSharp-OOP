using CustomLogger.Misc;
using Logger.Appenders.Interfaces;
using Logger.Layouts.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Appenders.Models
{
    public class ConsoleAppender : IAppender
    {
        public ConsoleAppender(ILayout layout)
        {
            Layout = layout;
        }

        public ILayout Layout { get; }
        public (string date, string msgType, string text) OutputText { get; set; }
        public ReportLevel ReportLevel { get; set; }

        public void Append()
        {
            Enum.TryParse(OutputText.msgType, true, out ReportLevel result);

            if (result >= ReportLevel)
            {
                Console.WriteLine(string.Format(Layout.LayoutFormat, OutputText.date, OutputText.msgType, OutputText.text));
            }
        }
    }
}