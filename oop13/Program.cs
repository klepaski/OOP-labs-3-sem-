using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace OOPLab13
{
    class Program
    {
        static void Main(string[] args)
        {
            // Демонстрация работы CJADiskInfo
            CJADiskInfo.FreeSpace("C:\\");
            CJADiskInfo.FileSystemInfo("C:\\");
            CJADiskInfo.DrivesFullInfo();

            // Демонстрация работы CJADirInfo
            CJADirInfo.FileCount(@"C:\1 УЧЕБА\ООТП");
            CJADirInfo.CreationTime(@"C:\1 УЧЕБА\ООТП");
            CJADirInfo.SubdirectoriesCount(@"C:\1 УЧЕБА\ООТП");
            CJADirInfo.ParentDirectory(@"C:\1 УЧЕБА\ООТП");

            // Демонстрация работы CJAFileInfo
            CJAFileInfo.FullPath(@"C:\Users\Shepard\Desktop\pics\phone.jpg");
            CJAFileInfo.BasicFileInfo(@"C:\Users\Shepard\Desktop\pics\phone.jpg");
            CJAFileInfo.CreationTime(@"C:\Users\Shepard\Desktop\pics\phone.jpg");

            // Демонстрация работы CJAFileManager
            CJAFileManager.InspectDrive(@"C:\1 УЧЕБА\ООТП");
            CJAFileManager.CopyFiles(@"FOLDER", ".txt");
            CJAFileManager.ArchiveUnarchive();
            
            // Удаление каталогов
            Console.WriteLine("Удалить каталоги? 1 - да");
            int key = int.Parse(Console.ReadLine());

            if (key == 1)
            {
                System.IO.Directory.Delete("CJAInspect", true);
                System.IO.Directory.Delete("Unzipped", true);
            }

            
            Console.ReadLine();
        }
    }
}
