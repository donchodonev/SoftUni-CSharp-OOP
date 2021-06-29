using CustomLogger.Appenders.Interfaces;
using CustomLogger.Appenders.Models;
using CustomLogger.Layouts.Interfaces;
using CustomLogger.Layouts.Models;
using CustomLogger.Misc;

namespace CustomLogger.Engine.Factories
{
    public class AppenderFactory
    {
        public AppenderFactory(string layout, string appenderName, ReportLevel reportLevel)
        {
            Layout = layout;
            AppenderName = appenderName;
            ReportLevel = reportLevel;
        }

        private string AppenderName { get; }
        private string Layout { get; }
        private ReportLevel ReportLevel { get; }

        public BaseAppender GetAppender()
        {
            BaseAppender appender = null;

            switch (AppenderName)
            {
                case "ConsoleAppender":
                    appender = new ConsoleAppender(GetLayout());
                    appender.ReportLevel = ReportLevel;
                    break;

                case "FileAppender":
                    appender = new FileAppender(GetLayout());
                    appender.ReportLevel = ReportLevel;
                    break;
            }

            return appender;
        }

        private ILayout GetLayout()
        {
            ILayout layout = null;

            switch (Layout)
            {
                case "SimpleLayout":
                    layout = new SimpleLayout();
                    break;

                case "XMLLayout":
                    layout = new XMLLayout();
                    break;
            }

            return layout;
        }
    }
}