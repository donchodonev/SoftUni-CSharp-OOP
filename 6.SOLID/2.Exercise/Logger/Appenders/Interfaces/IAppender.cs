using CustomLogger.Layouts.Interfaces;
using CustomLogger.Misc;

namespace CustomLogger.Appenders.Interfaces
{
    public interface IAppender
    {
        ILayout Layout { get; }
        public (string date, ReportLevel msgType, string text) OutputText { get; set; }
        public ReportLevel ReportLevel { get; set; }

        public void Append();
    }
}