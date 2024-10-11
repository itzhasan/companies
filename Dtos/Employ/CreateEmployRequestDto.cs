using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Dtos.Employ
{
    public class CreateEmployRequestDto
    {
        public int DepartmentId {get; set;} 
        public string Name { get; set; } = string.Empty;
        public int Age {get; set;}
    }
}