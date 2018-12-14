using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OOPLab13
{
    /// Содержит методы для вывода информации о диске.

    static class CJADiskInfo
    {
        public static void FreeSpace(string driveName)              ///своб место
        {
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.Name == driveName && drive.IsReady)
                    Console.WriteLine("Доступный объем на диске {0} : {1}", driveName.First(), drive.AvailableFreeSpace);

                CJALog.AddNote("CJADiskInfo", drive.Name, "Определено свободное место на диске.\n");
            }
            Console.WriteLine();
        }


        public static void FileSystemInfo(string driveName)         ///файловая система
        {
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.Name == driveName && drive.IsReady)
                    Console.WriteLine("Тип файловой системы и формат диска {0} : {1}, {2}",
                        driveName.First(), drive.DriveType, drive.DriveFormat);
                CJALog.AddNote("CJADiskInfo", drive.Name, "Определен ТФС и формат диска.\n");

            }
            Console.WriteLine();

        }


        public static void DrivesFullInfo()                         ///инфа о каждом доступном диске
        {
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady)
                {
                    Console.WriteLine("Имя: {0}", drive.Name);
                    Console.WriteLine("Объем: {0}", drive.TotalSize);
                    Console.WriteLine("Доступный объем: {0}", drive.AvailableFreeSpace);
                    Console.WriteLine("Метка тома: {0}", drive.VolumeLabel);
                    CJALog.AddNote("CJADiskInfo", drive.Name, "Выведена информация о диске.\n");

                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}