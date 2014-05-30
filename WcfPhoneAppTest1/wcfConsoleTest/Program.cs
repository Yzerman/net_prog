using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management.Automation;
using System.Collections.ObjectModel;

namespace wcfConsoleTest
{
    class Program
    {
        
        static void Main(string[] args)
        {


            PowerShell ps = PowerShell.Create();
            string path = "C:\\";

            string rcommand = "dir";
            ps.AddScript("cd " + path);
                ps.Invoke();
                ps.AddScript(rcommand + "| ConvertTo-Html");
            Collection<PSObject> results = ps.Invoke();
            //Console.WriteLine(ps.HadErrors);

            Collection<System.Management.Automation.ErrorRecord> results2 = ps.Streams.Error.ReadAll();

            StringBuilder sb2 = new StringBuilder();

            foreach (var s in results2)
            {
                sb2.Append(s);
            }

            Console.WriteLine(sb2.ToString());
            
            StringBuilder sb = new StringBuilder();

            foreach (var s in results)
            {
                sb.Append(s);
            }

            var bytes = Encoding.UTF8.GetBytes(sb.ToString());
            var base64 = Convert.ToBase64String(bytes);
            //Console.WriteLine(base64);

            var data = Convert.FromBase64String(base64);
            var str = Encoding.UTF8.GetString(data);
            Console.WriteLine(str);

            //Console.WriteLine(sb.ToString());
            
            
            /*
            var proxy = new ServiceReference1.Service1Client();
            int result = proxy.malZwei(2);
            Console.WriteLine(result);
            Console.ReadLine();
             * */

            //ps.AddScript("Get-Service WSearch");
            //string rcommand = "dir C:\\";
            //string rcommand = "Get-Service WSearch | Format-Table -Property Name";
            //string rcommand = "Get-Service";
            //string rcommand = "hostname";
            //string rcommand = "dir C:\\";
           // ps.AddScript(rcommand +"| out-string");
            //ps.AddScript("hostname");
            //ps.AddScript("dir C:\\");
           // Collection<PSObject> results = ps.Invoke();
           // StringBuilder sb = new StringBuilder();
            /*
            foreach (var s in results)
            {
                sb.Append(s);
            }
            System.Console.WriteLine(sb.ToString()) ;*/
            /*
            foreach (PSObject item in results)
            {
                foreach (var t in item.Properties)
                {
                    //Console.WriteLine(mi.MemberType);
                    string s = String.Format("{0}: {1}\r\n", t.Name, t.Value);
                    
                    Console.WriteLine(s);
                    // Console.WriteLine(mi.TypeNameOfValue);
                    // Console.WriteLine(mi.Value);

                    //Console.WriteLine(mi.MemberType);
                }
            }*/

            /**
            foreach (PSObject item in results)
            {
                /*
                foreach (PSMemberInfo mi in item.Members)
                {
                    //Console.WriteLine(mi.MemberType);
                    Console.WriteLine(mi.Name);
                   // Console.WriteLine(mi.TypeNameOfValue);
                   // Console.WriteLine(mi.Value);
                    
                    //Console.WriteLine(mi.MemberType);
                }
                 

                foreach (var t in item.Properties)
                {
                    //Console.WriteLine(mi.MemberType);
                    Console.WriteLine(t.Name);
                    Console.WriteLine(t.Value);
                    Console.WriteLine("-");
                    // Console.WriteLine(mi.TypeNameOfValue);
                    // Console.WriteLine(mi.Value);

                    //Console.WriteLine(mi.MemberType);
                }
                
                //Console.WriteLine(item.Members["ProcessName"].Value);
                
            }
            */
            

            /*
            foreach (string s in ps.Invoke<string>())
            {
                System.Console.WriteLine(s);
            }*/

            /*
            foreach (PSObject pso in ps.Invoke())
            {
                foreach (PSNoteProperty p in pso.Properties)
                {
                    string s = String.Format("Name:{0}\t\t\tValue:{1}\r\n", p.Name, p.Value);
                    Console.WriteLine(s);
                }
            }
             * */


            /*
            foreach (PSObject item in results)
            {
                item.ps
                //Console.WriteLine(item.Members["ProcessName"].Value);
                //sb.AppendLine(item.Members["ProcessName"].Value.ToString());
                Console.WriteLine(item.ToString());
            }
             * */

            //Console.WriteLine(sb);
           
            


            /*
            foreach (PSObject result in ps.Invoke())
            {
                Console.WriteLine("{0,-20}{1}",
                        result);
            }
             * */

            Console.ReadLine();

        }

    }
}
