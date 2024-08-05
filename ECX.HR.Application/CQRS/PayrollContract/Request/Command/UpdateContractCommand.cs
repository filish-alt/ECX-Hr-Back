﻿
using ECX.HR.Application.DTOs.PayrollContract;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.PayrollContract.Request.Command
{
    public class UpdateContractCommand: IRequest<Unit>
    {
        public PayrollContractDto PayrollContractDto { get; set; }
    }
}
