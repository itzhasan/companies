using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Company.Dtos.TansfereDepartmentDto;

namespace Company.Interfaces
{
    public interface ITransfereDepartmentService
    {
        Task MoveDepartmentToAnotherCompanyAsync(TransfereDepartmentDto transfereDepartmentDto);
    }
}