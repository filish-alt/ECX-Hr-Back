using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.CQRS.Step.Request.Queries;
using ECX.HR.Application.DTOs.Spouses;
using ECX.HR.Application.DTOs.Step;
using ECX.HR.Application.Exceptions;
using ECX.HR.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Step.Handler.Queries
{
    public class GetStepDetailRequestHandler : IRequestHandler<GetStepDetailRequest, StepDto>
    {
        private IStepRepository _StepRepository;
        private IMapper _mapper;
        public GetStepDetailRequestHandler(IStepRepository StepRepository, IMapper mapper)
        {
            _StepRepository = StepRepository;
            _mapper = mapper;
        }
        public async Task<StepDto> Handle(GetStepDetailRequest request, CancellationToken cancellationToken)
        {
            var step = await _StepRepository.GetById(request.Id);

            if (step == null || step.Status != 0)
                throw new NotFoundException(nameof(step), request.Id);

            else
                return _mapper.Map<StepDto>(step);
        }
    }
}