using System;
using System.IO;

namespace lab1
{
    class Program
    {
        
        delegate void TaskDelegate();

        static void Main(string[] args)
        {
            int numberOfFiles = 0;
            Console.WriteLine("Введите исходный каталог");
            String sourcePath = Console.ReadLine();
            sourcePath = @"D:\Temp1";
            Console.WriteLine("Введите целевой каталог");
            String targetPath = Console.ReadLine();
            targetPath = @"D:\Temp2";

            TaskQueue task = new TaskQueue(3);

            DirectoryCopy(sourcePath, targetPath, task, ref numberOfFiles);

            task.Finish();

            Console.WriteLine("Numb of files {0}", numberOfFiles);
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }


        private static void DirectoryCopy(string sourceDirName, string destDirName, TaskQueue task, ref int numberOfFiles)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();
            // If the destination directory doesn't exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                //Console.WriteLine(file);
                string temppath = Path.Combine(destDirName, file.Name);
                if (!File.Exists(temppath))
                {
                    task.EnqueueTask(delegate () { file.CopyTo(temppath, false); });
                    numberOfFiles++;
                }
            }

            // If copying subdirectories, copy them and their contents to new location.
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, task, ref numberOfFiles);
                }
            
        }
        
    }
}

