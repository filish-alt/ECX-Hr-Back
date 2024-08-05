using AutoMapper;
using ECX.HR.Application.CQRS.Step.Request.Command;
using ECX.HR.Application.Exceptions;
using ECX.HR.Application.Contracts.Persistent;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECX.HR.Application.Contracts.Persistence;

namespace ECX.HR.Application.CQRS.Step.Handler.Command
{
    public class DeleteStepCommandHandler : IRequestHandler<DeleteStepCommand>
    {
        private IStepRepository _StepRepository;
        private IMapper _mapper;
        public DeleteStepCommandHandler(IStepRepository StepRepository, IMapper mapper)
        {
            _StepRepository = StepRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteStepCommand request, CancellationToken cancellationToken)
        {
            var Step = await _StepRepository.GetById(request.Id);
            await _StepRepository.Delete(Step);
            return Unit.Value;
        }

        async Task IRequestHandler<DeleteStepCommand>.Handle(DeleteStepCommand request, CancellationToken cancellationToken)
        {
            var Step = await _StepRepository.GetById(request.Id);
            if (Step == null)
                throw new NotFoundException(nameof(Step), request.Id);
            Step.Status = 1;
            await _StepRepository.Update(Step);
        }
    }
}
