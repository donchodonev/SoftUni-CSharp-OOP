using CustomLogger.Misc;
using Logger.Layouts.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logger.Appenders.Interfaces
{
    public interface IAppender
    {
        ILayout Layout { get; }
        public (string date, string msgType, string text) OutputText { get; set; }
        public ReportLevel ReportLevel { get; set; }

        public void Append();
    }
}