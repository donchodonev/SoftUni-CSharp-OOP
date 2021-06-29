using CustomLogger.Appenders.Models;
using CustomLogger.Engine.Models;
using CustomLogger.Appenders.Interfaces;
using CustomLogger.Layouts.Interfaces;
using CustomLogger.Layouts.Models;
using CustomLogger.Loggers.Interfaces;
using CustomLogger.Loggers.Models;
using CustomLogger.Misc;
using System;
using CustomLogger.Engine.Interfaces;

namespace CustomLogger
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ICommander commander = new BaseCommander();
            commander.Run();
        }
    }
}