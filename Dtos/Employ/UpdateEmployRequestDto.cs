using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Dtos.Employ
{
    public class UpdateEmployRequestDto
    {
        public string Name { get; set; } = string.Empty;
        public int Age {get; set;}
    }
}