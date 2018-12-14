using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace OOPLab13
{
    /// Содержит методы для работы с файлами и директориями.

    static class CJAFileManager
    {
        /// прочит список файлов и папок из driveName
        /// созд дир CJAInspect
        /// созд CJAdirinfo.txt, сохр. туда инфу
        /// созд копию файла, переимен его, удалить исх

        public static void InspectDrive(string driveName)
        {
            DirectoryInfo dir = new DirectoryInfo(driveName);
            FileInfo[] file = dir.GetFiles();
            Directory.CreateDirectory(@"CJAInspect");

            using (StreamWriter sw = new StreamWriter(@"CJAInspect\CJAdirinfo.txt"))
            {
                foreach (DirectoryInfo d in dir.GetDirectories())
                    sw.WriteLine(d.Name);

                foreach (FileInfo f in file)
                    sw.WriteLine(f.Name);
            }
            File.Copy(@"CJAInspect\CJAdirinfo.txt", @"CJAInspect\CJAdirinfo_renamed.txt");
            File.Delete(@"CJAInspect\CJAdirinfo.txt");
        }

        /// Созд. еще дир CJAFiles
        /// скопир в него все файлвы с зад. расширением из path
        /// переместить CJAFiles в CJAInspect

        public static void CopyFiles(string path, string ext)
        {
            string dirpath = @"CJAFiles";
            Directory.CreateDirectory(dirpath);
            DirectoryInfo di = new DirectoryInfo(path);
            FileInfo[] files = di.GetFiles();

            foreach (FileInfo file in files)
            {
                if (file.Extension == ext)
                    file.CopyTo($@"{dirpath}\{file.Name}");
            }
            Directory.Move(@"CJAFiles", @"CJAInspect\CJAFiles");
        }


        /// архив из файлов дирректория CJAFiles
        /// разархив. в другой дирректорий

        public static void ArchiveUnarchive()
        {
            string dirpath = @"CJAInspect\CJAFiles";
            string zippath = @"CJAInspect\CJAFiles.zip";
            string unzippath = @"Unzipped";

            ZipFile.CreateFromDirectory(dirpath, zippath);
            ZipFile.ExtractToDirectory(zippath, unzippath);
        }
    }
}