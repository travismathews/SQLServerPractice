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



        }










    }
}
