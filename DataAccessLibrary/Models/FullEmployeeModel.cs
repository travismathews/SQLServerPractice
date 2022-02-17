using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary.Models
{
    public class FullEmployeeModel
    {
        public BasicEmployeeModel BasicInfo { get; set; }
        public List<AddressModel> Addresses { get; set; }
        public List<EmployerModel> Employers { get; set; }
        
    }
}
