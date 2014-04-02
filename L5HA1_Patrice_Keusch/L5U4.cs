using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace L5U4_4
{
    class Program
    {
        static void Main(string[] args)
        {

            DirectoryInfo di = new DirectoryInfo(@"C:\test\a\");
            DirectoryInfo di2 = new DirectoryInfo(@"C:\test\b\");

            var selectedFiles = from FileInfo f in di.GetFiles("*.*",
                                    SearchOption.AllDirectories)
                                                 select new { FullName = f.FullName, LastAccessTime = f.LastAccessTime};

            var selectedFile2 = from FileInfo f in di2.GetFiles("*.*",
                                    SearchOption.AllDirectories)
                                select new { FullName = f.FullName, LastAccessTime = f.LastAccessTime };

            var Result = selectedFiles.Union(selectedFile2);
            Result = Result.Select(c => c).OrderBy(c => c.LastAccessTime);

            foreach (var i in Result)
            {
                Console.WriteLine("{0} {1}", i.FullName, i.LastAccessTime);
            }

            Console.WriteLine();
            Console.ReadLine();
            
        }
    }
}
