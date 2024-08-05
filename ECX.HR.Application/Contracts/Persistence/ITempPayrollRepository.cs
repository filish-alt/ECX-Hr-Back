﻿using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.DTOs.Payroll;
using ECX.HR.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.Contracts.Persistence
{
    public interface ITempPayrollRepository : IGenericRepository<TempPayrolls>
    {
        Task<List<TempPayrolls>> GetByEmpId(Guid id);
  

    }
}
