﻿using ECX.HR.Application.DTOs.Allowances.cs;
using ECX.HR.Application.DTOs.AllowanceType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.AllowanceType.Request.Command
{
    public class UpdateAllowanceTypeCommand : IRequest<Unit>
    {
        public AllowanceTypeDto AllowanceTypeDto { get; set; }
    }
}
