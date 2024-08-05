﻿
using ECX.HR.Application.DTOs.MedicalBalance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.MedicalBalance.Request.Queries
{
    public class GetMedicalBalanceDetailRequest : IRequest<List<MedicalBalanceDto>>
    {
        public Guid Id { get; set; }
    }
}
