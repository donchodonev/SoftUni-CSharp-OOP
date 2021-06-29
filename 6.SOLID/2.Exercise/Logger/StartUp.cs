using CustomLogger.Engine.Interfaces;
using CustomLogger.Engine.Models;

namespace CustomLogger
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            ICommander commander = new BaseCommander();
            commander.Run();
        }
    }
}