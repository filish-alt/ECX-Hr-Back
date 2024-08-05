﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.PromotionVacancy.Request.Command
{
    public class DeletePromotionVacancyCommand : IRequest
    {
        public Guid VacancyId { get; set; }
    }
}
