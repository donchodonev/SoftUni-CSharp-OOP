using CustomLogger.Layouts.Interfaces;
using CustomLogger.Misc;

namespace CustomLogger.Appenders.Interfaces
{
    public abstract class BaseAppender
    {
        protected BaseAppender(ILayout layout)
        {
            Layout = layout;
            LogFile = new LogFile();
        }

        public ILayout Layout { get; }
        public ILogFile LogFile { get; protected set; }
        public int MessagesAppended { get; protected set; }
        public (string date, ReportLevel msgType, string text) OutputText { get; set; }
        public ReportLevel ReportLevel { get; set; }

        public void Append()
        {
            if (OutputText.msgType >= ReportLevel)
            {
                LogFile.Write(string.Format(Layout.LayoutFormat, OutputText.date, OutputText.msgType, OutputText.text));
                MessagesAppended++;
            }
        }

        public abstract void DumpLoggedData();
    }
}