using CustomLogger.Layouts.Interfaces;
using CustomLogger.Misc;

namespace CustomLogger.Appenders.Interfaces
{
    public interface IAppender
    {
        ILayout Layout { get; }
        public ILogFile LogFile { get; set; }
        public int MessagesAppended { get; set; }
        public (string date, ReportLevel msgType, string text) OutputText { get; set; }
        public ReportLevel ReportLevel { get; set; }

        public void Append()
        {
            if (OutputText.msgType >= ReportLevel)
            {
                LogFile.Write(string.Format(Layout.LayoutFormat, OutputText.date, OutputText.msgType, OutputText.text));
            }
        }

        public void DumpLoggedData();
    }
}