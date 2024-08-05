﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Departments.Request.Command
{
    public class DeleteDepartmentCommand : IRequest
    {
        public Guid DepartmentId { get; set; }
    }
}
