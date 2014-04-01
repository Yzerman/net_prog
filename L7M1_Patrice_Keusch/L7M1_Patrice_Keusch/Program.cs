﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L7M1_Patrice_Keusch
{
    class Program
    {
        static void Main(string[] args)
        {

            FileInfo myFile = new FileInfo(@"C:\Users\Patrice\test.txt");
            if (!myFile.Exists)
            {
                myFile.Create();
            }
            //Create a file to write to. 
            using (StreamWriter sw = myFile.CreateText())
            {
                sw.WriteLine(Process.GetCurrentProcess().Id);
                sw.WriteLine(Process.GetCurrentProcess().ProcessName);
                sw.WriteLine(Process.GetCurrentProcess().Modules.Count);
                sw.WriteLine(Process.GetCurrentProcess().Threads.Count);
                sw.WriteLine(Process.GetCurrentProcess().StartTime.ToString());
                var modules = Process.GetCurrentProcess().Modules;

                int count = 0;

                foreach (var item in modules)
                {
                    if (++count == 6) break;
                    sw.WriteLine(item.ToString());
                }
            }
            using (StreamReader sr = myFile.OpenText())
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    Console.WriteLine(s);
                }
            }

          

            Console.ReadLine();
        }
    }
}
