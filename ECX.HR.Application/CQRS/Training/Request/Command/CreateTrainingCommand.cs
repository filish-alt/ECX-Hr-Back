
using ECX.HR.Application.DTOs.Trainings;
using ECX.HR.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Training.Request.Command
{
    public class CreateTrainingCommand : IRequest<BaseCommandResponse>
    {
        public TrainingDto TrainingDto { get; set; }
    }
}
