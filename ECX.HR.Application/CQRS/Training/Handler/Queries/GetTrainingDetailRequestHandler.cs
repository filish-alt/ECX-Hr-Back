using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.CQRS.Training.Request.Queries;

using ECX.HR.Application.DTOs.Trainings;
using ECX.HR.Application.Exceptions;
using ECX.HR.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Training.Handler.Queries
{
    public class GetTrainingDetailRequestHandler : IRequestHandler<GetTrainingDetailRequest, List<TrainingDto>>
    {
        private ITrainingRepository _TrainingRepository;
        private IMapper _mapper;
        public GetTrainingDetailRequestHandler(ITrainingRepository TrainingRepository, IMapper mapper)
        {
            _TrainingRepository = TrainingRepository;
            _mapper = mapper;
        }
        public async Task<List<TrainingDto>> Handle(GetTrainingDetailRequest request, CancellationToken cancellationToken)
        {
            var training =await _TrainingRepository.GetByEmpId(request.EmpId);
            
            if (training == null || !training.Any(we => we.Status == 0))
                throw new NotFoundException(nameof(training), request.EmpId);

            else
                return _mapper.Map<List<TrainingDto>>(training);
        }
    }
}
