using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Company.Dtos.Employ;
using Company.Models;

namespace Company.Mappers
{
    public static class EmployMapper
    {
        public static EmployDto ToEmployDto(this Employ employModel){
            return new EmployDto{
                Id = employModel.Id,
                Name = employModel.Name,
                Age = employModel.Age,
            };
        }

        public static Employ ToEmployFormCreateDTO(this CreateEmployRequestDto employDto){
            return new Employ{
                DepartmentId = employDto.DepartmentId,
                Name = employDto.Name,
                Age = employDto.Age,
            };
        }
    }
}