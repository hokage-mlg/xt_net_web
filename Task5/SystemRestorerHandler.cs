using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5
{
    class SystemRestorerHandler
    {
        private string _sourceDirectory;
        private string _logDirectory;
        public SystemRestorerHandler(string SourceDir, string LogDir)
        {
            _sourceDirectory = SourceDir;
            _logDirectory = LogDir;
        }
        public void Run()
        {
            Console.WriteLine("Please, choose at what point in time you want to return.\n" +
                "Write in format day.month.year_hours:minutes:seconds\n" +
                "(for example 23.12.2019_12h13m4s)");
            var logDirectory = new DirectoryInfo(_logDirectory + Console.ReadLine());
            if (logDirectory.Exists)
            {
                var workDirectory = new DirectoryInfo(_sourceDirectory);
                foreach (var file in workDirectory.GetFiles())
                {
                    try
                    {
                        file.Delete();
                    }
                    catch (IOException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                foreach (var dir in workDirectory.GetDirectories())
                {
                    try
                    {
                        dir.Delete(true);
                    }
                    catch (IOException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
                DirectoryCopy(logDirectory.ToString(), _sourceDirectory, true);
            }
            else
                Console.WriteLine("There is no backup for this time!");
        }
        public static void DirectoryCopy(string sourceDir, string targetDir, bool copySubDirs)
        {
            var dir = new DirectoryInfo(sourceDir);
            if (!dir.Exists)
                throw new DirectoryNotFoundException("Error, check your source directory!");
            var dirs = dir.GetDirectories();
            if (!Directory.Exists(targetDir))
                Directory.CreateDirectory(targetDir);
            var files = dir.GetFiles();
            foreach (var file in files)
            {
                var tempPath = Path.Combine(targetDir, file.Name);
                try
                {
                    file.CopyTo(tempPath, true);
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            if (copySubDirs)
            {
                foreach (var subDir in dirs)
                {
                    var tempPath = Path.Combine(targetDir, subDir.Name);
                    DirectoryCopy(subDir.FullName, tempPath, copySubDirs);
                }
            }
        }
    }
}
