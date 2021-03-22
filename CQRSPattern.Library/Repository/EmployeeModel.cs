using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSPattern.Library.Repository
{
    public class EmployeeModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
    }
}
