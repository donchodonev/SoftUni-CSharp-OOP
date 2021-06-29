using CustomLogger.Misc;
using CustomLogger.Appenders.Interfaces;
using CustomLogger.Layouts.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomLogger.Appenders.Models
{
    public class ConsoleAppender : IAppender
    {
        public ConsoleAppender(ILayout layout)
        {
            Layout = layout;
        }

        public ILayout Layout { get; }
        public (string date, ReportLevel msgType, string text) OutputText { get; set; }
        public ReportLevel ReportLevel { get; set; }

        public void Append()
        {
            if (OutputText.msgType >= ReportLevel)
            {
                Console.WriteLine(string.Format(Layout.LayoutFormat, OutputText.date, OutputText.msgType, OutputText.text));
            }
        }
    }
}