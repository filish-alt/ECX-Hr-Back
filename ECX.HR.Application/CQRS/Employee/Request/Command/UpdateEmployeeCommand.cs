﻿
using ECX.HR.Application.DTOs.Employees;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Employee.Request.Command
{
    public class UpdateEmployeeCommand :IRequest<Unit>
    {
        public EmployeeDto EmployeeDto { get; set; }
    }
}
