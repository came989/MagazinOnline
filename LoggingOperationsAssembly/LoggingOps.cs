using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Runtime.Remoting.Channels;

namespace LoggingOperationsAssembly
{
    public class LoggingOps
    {
        public static string filePath = null;
        /// <summary>
        ///  <para> A method that creates the log file for the project. The input is <paramref name="FileName"/>, the expected outputs are: </para>
        /// <para>If the file doesn't exist, the method will return the path of the file. </para>
        /// <para>If the file already exists, it only saves the path to the file. </para>
        /// <para>If the file doesn't exist, then the return value is null. </para>
        /// </summary>
        /// <param name="FileName"></param>
        /// <returns></returns>
        public static string CreateLogFile(string FileName)
        {
            string fPath = null;
            if (!File.Exists(FileName))
            {
                File.Create(FileName);
                fPath = Path.GetDirectoryName(FileName);
                return fPath; //the file has been created with success
            }
            else if (File.Exists(FileName) && fPath == null)
            {
                fPath = Path.GetDirectoryName(FileName);
                return fPath;
            }
            else
            {
                Console.WriteLine("WARNING: The file already exists. No actions must be taken, all good.");
                return null; //the file already exists
            }
        }

        /// <summary>
        /// This method writes a log activity inside the log file.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static bool WriteLog(string filePath, string message)
        {
            if (File.Exists(filePath))
            {
                using (FileStream logFile = new FileStream(filePath, FileMode.Open))
                {
                    TextWriterTraceListener txtTrace = new TextWriterTraceListener(logFile);
                    Trace.Listeners.Add(txtTrace);
                    Trace.WriteLine($"{DateTime.UtcNow} : {message}");
                    Trace.Flush();
                    return true; //the file exists, everything is good :)
                }
            }
            else
            {
                Console.WriteLine("ERROR: The logging file does not exist.");
                return false; //if the file doesn't exist
            }
        }
    }
}