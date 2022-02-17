using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using DataAccessLibrary;
using DataAccessLibrary.Models;

namespace SQLServerHomework
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Console.WriteLine(GetConnectionString());

            SqlCrud sql = new SqlCrud(GetConnectionString());


            //ReadAllEmployees(sql);





            Console.WriteLine("Finished Running");

            Console.ReadLine();


        }

        private static void ReadAllEmployees(SqlCrud sql)
        {
            var rows = sql.GetAllEmployees();
            foreach (var row in rows)
            {
                Console.WriteLine($"{ row.Id }: { row.FirstName } { row.LastName }");
            }
        }

        private static string GetConnectionString(string connectionStringName = "Default")
        {
            string output = "";

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var config = builder.Build();

            output = config.GetConnectionString(connectionStringName);

            return output;
        }
    }
}
