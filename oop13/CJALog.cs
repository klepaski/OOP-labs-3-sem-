using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace OOPLab13
{
    /// Содержит методы для работы с текстовым файлом CJAlog.txt, 
    /// в который записываются все действия пользователя

    static class CJALog
    {
        public static void AddNote(string utility, string path, string message)
        {
            using (StreamWriter sw = new StreamWriter("CJAlogfile.txt", true))
            {
                sw.WriteLine($"{utility}:  {path}");
                sw.WriteLine($"\t:{message}:   {DateTime.Now}");
            }
        }
    }
}