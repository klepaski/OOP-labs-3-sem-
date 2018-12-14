using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OOPLab13
{
    /// Содержит методы для вывода информации о конкретном директории.

    static class CJADirInfo
    {
        public static void FileCount(string path)                       ///кол-во файлов
        {
            Console.WriteLine("Количество файлов в каталоге {0}: {1}",
                path, Directory.GetFiles(path).Length);
            Console.WriteLine();

            CJALog.AddNote("CJADirInfo", path, "Определено кол-во файлов в каталоге.\n");
        }


        public static void CreationTime(string path)                    ///время созд. дир
        {
            Console.WriteLine("Время создания каталога {0}: {1}",
                path, Directory.GetCreationTime(path));
            Console.WriteLine();
            CJALog.AddNote("CJADirInfo", path, "Определено время создания каталога.\n");

        }


        public static void SubdirectoriesCount(string path)             ///кол-во поддирект
        {
            Console.WriteLine("Количество подкаталогов в каталоге {0}: {1}",
                path, Directory.GetDirectories(path).Length);
            Console.WriteLine();
            CJALog.AddNote("CJADirInfo", path, "Определено кол-во подпапок в каталоге.\n");

        }


        public static void ParentDirectory(string path)                 ///родительские директории
        {
            Console.WriteLine("Родительский каталог каталога {0}: {1}",
                path, Directory.GetParent(path));
            Console.WriteLine();
            CJALog.AddNote("CJADirInfo", path, "Определен родительский файл каталога.\n");

        }
    }
}