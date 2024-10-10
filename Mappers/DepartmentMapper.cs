using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Company.Dtos.Department;
using Company.Models;

namespace Company.Mappers
{
    public static class DepartmentMapper
    {
        public static DepartmentDto ToDepartmentDto(this Department departmentModel){
            return new DepartmentDto{
                Id = departmentModel.Id,
                Name = departmentModel.Name,
                Type = departmentModel.Type,
               // Departments = departmentModel.Departments.Select(c => c.ToDepartmentDto()).ToList()
            };
        }
        
    }
}