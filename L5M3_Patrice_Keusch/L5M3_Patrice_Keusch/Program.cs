using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L5M3_Patrice_Keusch
{
    class Program
    {
        static void Main(string[] args)
        {
            DirectoryInfo di = new DirectoryInfo(@"C:\test\");
            var selectedFiles = from FileInfo f in di.GetFiles("*.*",
                                    SearchOption.AllDirectories)
                                where f.Name.StartsWith("a")
                                select new { MyName = f.Name, MyCreationTime = f.CreationTime, MyLength = f.Length };
            
            
            foreach (var i in selectedFiles)
            {
                Console.WriteLine("{0} {1} {2}", i.MyName, i.MyCreationTime, i.MyLength);
            }
            
            Console.WriteLine();
            Console.ReadLine();
            
        }
    }
}
