using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OOPLab13
{
    /// Содержит методы для вывода информации о конкретном файле.

    static class CJAFileInfo
    {
        public static void FullPath(string path)                ///полный путь
        {
            FileInfo fileInfo = new FileInfo(path);

            Console.WriteLine("Полный путь к файлу {0}: {1}", fileInfo.Name, fileInfo.FullName);
            Console.WriteLine();
            CJALog.AddNote("CJAFileInfo", fileInfo.Name, "Определен полный путь к файлу.\n");
        }


        public static void BasicFileInfo(string path)             ///размер, расширение, имя
        {
            FileInfo fileInfo = new FileInfo(path);

            Console.WriteLine("Имя файла: {0}", fileInfo.Name);
            Console.WriteLine("Расширение файла: {0}", fileInfo.Extension);
            Console.WriteLine("Размер файла: {0}", fileInfo.Length);
            Console.WriteLine();
            CJALog.AddNote("CJAFileInfo", fileInfo.Name, "Выведена базовая информация о файле.\n");
        }


        public static void CreationTime(string path)                ///время создания
        {
            FileInfo fileInfo = new FileInfo(path);

            Console.WriteLine("Время создания файла {0}: {1}", fileInfo.Name, fileInfo.CreationTime);
            Console.WriteLine();
            CJALog.AddNote("CJAFileInfo", fileInfo.FullName, "Определено время создания файла.\n");
        }
    }
}
