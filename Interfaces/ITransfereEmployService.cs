using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Company.Dtos.TransfereEmployDto;

namespace Company.Interfaces
{
    public interface ITransfereEmployService
    {
        Task MoveEmployToAnotherDepartmentAsync(TransferEmployDto transferEmployDto);
    }
}