using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.DductionType.Request.Command;
using ECX.HR.Application.CQRS.Deduction.Request.Command;
using ECX.HR.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Deduction.Handler.Command
{
    public class DeleteDeductionCommandHandler : IRequestHandler<DeleteDeductionCommand>
    {
      
        private readonly IDeductionRepository _deductionRepository;
        private IMapper _mapper;
        public DeleteDeductionCommandHandler(IDeductionRepository DeductionRepository, IMapper mapper)
        {

          
           _deductionRepository = DeductionRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteDeductionCommand request, CancellationToken cancellationToken)
        {
            var Deduction = await _deductionRepository.GetById(request.Id);
            await _deductionRepository.Delete(Deduction);
            return Unit.Value;
        }

        async Task IRequestHandler<DeleteDeductionCommand>.Handle(DeleteDeductionCommand request, CancellationToken cancellationToken)
        {
            var Deduction = await _deductionRepository.GetById(request.Id);
            if (Deduction == null)
                throw new NotFoundException(nameof(Deduction), request.Id);
            Deduction.Status = 1;
            await _deductionRepository.Update(Deduction);
        }
    }
}