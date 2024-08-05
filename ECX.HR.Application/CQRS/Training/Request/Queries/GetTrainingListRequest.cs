﻿
using ECX.HR.Application.DTOs.Trainings;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Training.Request.Queries
{
    public class GetTrainingListRequest :IRequest<List<TrainingDto>>
    {
       
    }
}
