using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Models
{
    public class Employ
    {
        public int Id { get; set; }
        public int DepartmentId {get; set;}
        public Department? Department { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age {get; set;}
    }
}