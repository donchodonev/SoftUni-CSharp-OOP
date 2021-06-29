using System.Linq;
using System.Text;

namespace CustomLogger.Misc
{
    public class LogFile : ILogFile
    {
        public StringBuilder Log { get; set; } = new StringBuilder();

        public int Size
        {
            get => Log.ToString()
                .Where(char.IsLetter)
                .Sum(c => c);
        }

        public void Write(string stringToWrite)
        {
            Log.AppendLine(stringToWrite);
        }
    }
}