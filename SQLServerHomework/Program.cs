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

            //ReadEmployee(sql, 1);


            //ReadAllEmployees(sql);





            Console.WriteLine("Finished Running");

            Console.ReadLine();


        }

        private static void ReadEmployee(SqlCrud sql, int contactId)
        {
            var employee = sql.GetFullEmployeeById(contactId);

            Console.WriteLine($"{ employee.BasicInfo.Id }: { employee.BasicInfo.FirstName } { employee.BasicInfo.LastName }");

            Console.WriteLine("-------------------------------------");
            Console.WriteLine($"Addresses on file:                  ");
            Console.WriteLine("-------------------------------------");

            foreach (var address in employee.Addresses)
            {
                Console.WriteLine($"{ address.StreetAddress} { address.City}, { address.State}  { address.ZipCode}");
            }

            Console.WriteLine("-------------------------------------");
            Console.WriteLine($"Employers on file:                  ");
            Console.WriteLine("-------------------------------------");

            foreach (var employer in employee.Employers)
            {
                Console.WriteLine($"{ employer.EmployerName }");
            }
            Console.WriteLine();

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
