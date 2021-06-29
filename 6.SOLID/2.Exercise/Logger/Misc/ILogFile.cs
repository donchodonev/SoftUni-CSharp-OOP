using System.Text;

namespace CustomLogger.Misc
{
    public interface ILogFile
    {
        public StringBuilder Log { get; set; }

        public int Size { get; }

        public void Write(string stringToWrite);
    }
}