﻿
using ECX.HR.Application.DTOs.PromotionVacancy;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.PromotionVacancy.Request.Queries
{
    public class GetPromotionVacancyListRequest :IRequest<List<PromotionVacancyDto>>
    {
       
    }
}
