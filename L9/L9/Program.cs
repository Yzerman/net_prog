using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using L9.Properties;

namespace L9
{
    class Program
    {
        static void Main(string[] args)
        {

            var factory = DbProviderFactories.GetFactory("System.Data.SqlClient");
            using (DbConnection myCn = factory.CreateConnection())
            {
                myCn.ConnectionString = Settings.Default.connstr;
                    myCn.Open();

                using (var cmd = myCn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT CourseID,Title,Credits,DepartmentID FROM course";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("{0}, {1}, {2}, {3}", reader["CourseID"], reader["Title"], reader["Credits"], reader["DepartmentID"]);
                            
                        }

                        Console.ReadLine();
                    }
                }
                using (var cmd = myCn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT Name,Budget,StartDate,Administrator FROM Department";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("{0}, {1}, {2}, {3}", reader["Name"], reader["Budget"], reader["StartDate"], reader["Administrator"]);

                        }

                        Console.ReadLine();
                    }
                }
            }
        }
    }
}
