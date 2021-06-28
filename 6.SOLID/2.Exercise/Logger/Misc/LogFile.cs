using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace CustomLogger.Misc
{
    public class LogFile
    {
        public StringBuilder Log { get; set; }

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