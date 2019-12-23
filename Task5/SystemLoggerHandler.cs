using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
namespace Task5
{
    class SystemLoggerHandler
    {
        FileSystemWatcher watcher;
        bool enabled = true;
        private string _sourceDirectory;
        private string _logDirectory;
        public SystemLoggerHandler(string sourceDir, string logDir)
        {
            _sourceDirectory = sourceDir;
            _logDirectory = logDir;
        }
        public void Run()
        {
            using (watcher = new FileSystemWatcher(_sourceDirectory, "*.txt"))
            {
                watcher.NotifyFilter = NotifyFilters.LastAccess
                    | NotifyFilters.LastWrite
                    | NotifyFilters.DirectoryName
                    | NotifyFilters.FileName
                    | NotifyFilters.CreationTime;
                watcher.IncludeSubdirectories = true;
                watcher.Deleted += OnHandlerDT;
                watcher.Created += OnHandlerDT;
                watcher.Changed += OnHandlerDT;
                watcher.Renamed += OnHandlerDT;
                watcher.EnableRaisingEvents = true;
                while (enabled)
                    Thread.Sleep(1000);
            }
        }
        private void OnHandlerDT(object sender, FileSystemEventArgs e)
        {
            DateTime date = DateTime.Now;
            string newDir = _logDirectory + PrintDT(date);
            SystemRestorerHandler.DirectoryCopy(_sourceDirectory, newDir, true);
        }
        public static string PrintDT(DateTime date)
        {
            string res = date.Day + "." + date.Month + "." + date.Year + "_"
                + date.Hour + "h" + date.Minute + "m" + date.Second + "s";
            return res;
        }
    }
}
