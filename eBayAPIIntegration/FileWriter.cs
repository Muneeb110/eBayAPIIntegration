using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eBayAPIIntegration
{
    public static class FileWriter
    {
        private static string DirectoryLocation = "C:\\APILogs";
        private static object _lock = new object();
        public static void WriteError(string msg)
        {
            
            if (!Directory.Exists(DirectoryLocation))
                Directory.CreateDirectory(DirectoryLocation);

            string fileName = string.Format("ERRORS_{0}.txt", DateTime.Now.ToString("dd-MMM-yyyy"));
            string fileLocation = DirectoryLocation + "\\" + fileName;
            if (!File.Exists(fileLocation))
                File.Create(fileLocation).Close();
            lock (_lock)
            {
                File.AppendAllLines(fileLocation, new List<string> { DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt") + Environment.NewLine, msg, "----------------------------------------------------------------------------" });
            }
        }

        public static void WriteResponse(string msg)
        {
            if (!Directory.Exists(DirectoryLocation))
                Directory.CreateDirectory(DirectoryLocation);

            string fileName = string.Format("RESPONSE_{0}.txt", DateTime.Now.ToString("dd-MMM-yyyy"));
            string fileLocation = DirectoryLocation + "\\" + fileName;

            if (!File.Exists(fileLocation))
                File.Create(fileLocation).Close();
            lock (_lock)
            {
                File.AppendAllLines(fileLocation, new List<string> { DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt") + Environment.NewLine, msg, "----------------------------------------------------------------------------" + Environment.NewLine });
            }
        }
    }
}
