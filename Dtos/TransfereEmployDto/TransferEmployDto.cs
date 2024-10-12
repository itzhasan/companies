using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Dtos.TransfereEmployDto
{
    public class TransferEmployDto
    {
        public int DepartmentId {get; set;}
        public int EmployId {get; set;}
        public int TargetDepartmentId {get; set;}
    }
}