using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Company.Dtos.Employ;
using Company.Models;

namespace Company.Mappers
{
    public static class EmployMapper //use record instead of class ( google class vs record)
    {
        public static EmployDto ToEmployDto(this Employ employModel){
            return new EmployDto{
                Id = employModel.Id,
                Name = employModel.Name,
                Age = employModel.Age,
            };
        }

        public static Employ ToEmployFormCreateDTO(this CreateEmployRequestDto employDto , int departmentId){
            return new Employ{
                DepartmentId = departmentId,
                Name = employDto.Name,
                Age = employDto.Age,
            };
        }
    }
}