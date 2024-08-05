using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.CQRS.Training.Request.Queries;

using ECX.HR.Application.DTOs.Trainings;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Training.Handler.Queries
{
    public class GetTrainingListRequestHandler : IRequestHandler<GetTrainingListRequest, List<TrainingDto>>
    {
        private ITrainingRepository _TrainingRepository;
        private IMapper _mapper;
        public GetTrainingListRequestHandler(ITrainingRepository TrainingRepository, IMapper mapper)
        {
            _TrainingRepository= TrainingRepository;
            _mapper = mapper;
        }
        public async Task<List<TrainingDto>> Handle(GetTrainingListRequest request, CancellationToken cancellationToken)
        {
            var Training =await _TrainingRepository.GetAll();
            var activeTraining = Training.Where(training => training.Status == 0).ToList();
            return _mapper.Map<List<TrainingDto>>(activeTraining);
        }
    }
}
