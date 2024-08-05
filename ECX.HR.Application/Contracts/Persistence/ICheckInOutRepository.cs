﻿using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.Contracts.Persistence
{
    public interface ICheckInOutRepository : IGenericRepository<CheckInOut> {
        Task<List<CheckInOut>> GetCheckInOut(int user, DateTime? checkin, DateTime? checkout);
    }
}
