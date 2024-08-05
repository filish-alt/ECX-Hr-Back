﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Allowances.Request.Command
{
    public class DeleteAllowanceCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
