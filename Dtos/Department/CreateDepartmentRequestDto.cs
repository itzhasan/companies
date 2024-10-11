using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Dtos.Department
{
    public class CreateDepartmentRequestDto
    {
        public int CompanyId {get; set;}
        public string Name { get; set; } = string.Empty;
        public string Type {get; set;} = string.Empty;
    }
}