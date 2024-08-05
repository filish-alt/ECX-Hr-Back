using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.CQRS.Step.Request.Queries;
using ECX.HR.Application.DTOs.Step;

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Step.Handler.Queries
{
    public class GetStepListRequestHandler : IRequestHandler<GetStepListRequest, List<StepDto>>
    {
        private IStepRepository _StepRepository;
        private IMapper _mapper;
        public GetStepListRequestHandler(IStepRepository StepRepository, IMapper mapper)
        {
            _StepRepository= StepRepository;
            _mapper = mapper;
        }
        public async Task<List<StepDto>> Handle(GetStepListRequest request, CancellationToken cancellationToken)
        {
            var Step =await _StepRepository.GetAll();
            var activeStep = Step.Where(step => step.Status == 0).ToList();
            return _mapper.Map<List<StepDto>>(activeStep);
        }
    }
}
