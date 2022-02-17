using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class SqlCrud
    {
        private readonly string _connectionString;
        private SqlDataAccess db = new SqlDataAccess();

        public SqlCrud(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<BasicEmployeeModel> GetAllEmployees()
        {
            string sql = "select Id, FirstName, LastName from dbo.Employees;";
            return db.LoadData<BasicEmployeeModel, dynamic>(sql, new { }, _connectionString);

        }

        public FullEmployeeModel GetFullEmployeeById(int id)
        { 
            FullEmployeeModel output = new FullEmployeeModel();

            string sql = "select Id, FirstName, LastName from dbo.Employees where Id = @Id;";
            output.BasicInfo = db.LoadData<BasicEmployeeModel, dynamic>(sql, new { Id = id }, _connectionString).FirstOrDefault();

            if (output.BasicInfo == null)   
            {
                return null;
            }

            sql = @"select a.*
                    from dbo.Addresses a
                    inner join dbo.EmployeeAddresses ea on ea.AddressId = a.Id
                    where ea.EmployeeId = @Id;";


            output.Addresses = db.LoadData<AddressModel, dynamic>(sql, new { Id = id }, _connectionString);

            sql = @"select em.*
                    from dbo.Employers em
                    inner join dbo.EmployeeEmployer ee on ee.EmployerId = em.Id
                    where ee.EmployeeId = @Id;";

            output.Employers = db.LoadData<EmployerModel, dynamic>(sql, new { Id = id }, _connectionString);

            return output;

        }

        public void CreateEmployee(FullEmployeeModel employee)
        {
            // Dapper get identity id after insert
            //string sql = @"INSERT INTO [MyTable] ([Stuff]) VALUES (@Stuff);
            //            SELECT CAST(SCOPE_IDENTITY() as int)";

            //var id = connection.Query<int>(sql, new { Stuff = mystuff }).Single();

            // Save Basic employee information
            //string sql = "inser into dbo.Employees (FirstName, LastName) values (@FirstName, @LastName);";
            //db.SaveData(sql, new { employee.BasicInfo.FirstName, employee.BasicInfo.LastName }, _connectionString);
            // End original code

            // Get the id number of the employee
            //Manual lookup to get employeeID
            //sql = "select Id from dbo.Employees FirstName = @FirstName and LastName = @LastName;";
            //int employeetId = db.LoadData<IdLookupModel, dynamic>(sql, new { employee.BasicInfo.FirstName, employee.BasicInfo.LastName }, _connectionString).First().Id;
            string sql = @"select Id from dbo.Employees FirstName = @FirstName and LastName = @LastName;
                    select cast(scope_identity() as int);";
            var id = db.LoadData<int, dynamic>(sql, new { employee.BasicInfo.FirstName, employee.BasicInfo.LastName }, _connectionString).Single();


            // Identify if the Address exists
            // If address exists, insert into link table
            // else Insert new address and get the addressId
            // then do the link table insert


            // Do the same for Employers
        }










    }
}
