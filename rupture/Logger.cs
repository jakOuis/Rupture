using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace rupture
{
    internal static class Logger
    {
        private static StreamWriter writer;

        public static void Log(string message)
        {
            DateTime now = DateTime.Now;
            if( writer == null)
            {
                string logDirectory = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Rupture");
                if (!Directory.Exists(logDirectory))
                {
                    Directory.CreateDirectory(logDirectory);
                }
                string currentLogFile = Path.Combine(logDirectory, string.Format("Rupture Error Log - {0}.txt", now.ToString("MM-dd-yyyy")));
                if (!File.Exists(currentLogFile))
                {
                    writer = new StreamWriter(File.Create(currentLogFile));
                }
                else
                {
                    writer = new StreamWriter(File.Open(currentLogFile, FileMode.Append));
                }
            }
            string formattedMessage = string.Format("[Entry {0}]: {1}", now.ToString("MM-dd-yyyy hh:mm tt"), message);
            writer.WriteLine(formattedMessage );
            writer.Flush();
            Console.WriteLine(formattedMessage);
        }

        public static void Log(string message, params string[] values)
        {
            Log(string.Format(message, values));
        }
    }
}
