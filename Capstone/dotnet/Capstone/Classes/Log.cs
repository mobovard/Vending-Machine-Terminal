using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Capstone.Classes
{
    public class Log
    {
        public string FilePath { get; private set; }
        public Log(string filePath)
        {
            FilePath = filePath;
        }

        public void WriteMessage(string logMessage)
        {
            using (StreamWriter sw = File.AppendText(FilePath))
            {
                sw.WriteLine(logMessage);
            }
        }
    }
}
