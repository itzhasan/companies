using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Company.Dtos.Employ;

namespace Company.Dtos.Department
{
    public class DepartmentDto
    {
        public int Id { get; set; }
        public int CompanyId {get; set;}
        public string Name { get; set; } = string.Empty;
        public string Type {get; set;} = string.Empty;
        public List<EmployDto> Employs { get; set; } = [];
    }
}