using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Company.Dtos.TansfereDepartmentDto
{
    public class TransfereDepartmentDto
    {
        public int CompanyId {get; set;}
        public int DepartmentId {get; set;}
        public int TargetCompanyId {get; set;}
    }
}