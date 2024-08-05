﻿using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.ContractS.Persistence
{
    public interface IPayrollContractRepository : IGenericRepository<PayrollContracts> 
    {
        Task<PayrollContracts> GetByEmpId(Guid id);
    }
}
