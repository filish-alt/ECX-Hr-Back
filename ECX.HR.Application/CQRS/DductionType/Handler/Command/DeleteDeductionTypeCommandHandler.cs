using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.DductionType.Request.Command;
using ECX.HR.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace ECX.HR.Application.CQRS.DductionType.Handler.Command
{
    public class DeleteDeductionTypeCommandHandler:IRequestHandler<DeleteDeductionTypeCommand>
    {
        private IDeductionTypeRepository _DeductionTypeRepository;
        private readonly IDeductionTypeRepository _deductionTypeRepository;
        private IMapper _mapper;
    public DeleteDeductionTypeCommandHandler(IDeductionTypeRepository DeductionTypeRepository, IMapper mapper)
    {
      
           _deductionTypeRepository = DeductionTypeRepository;
            _mapper = mapper;
    }

    public async Task<Unit> Handle(DeleteDeductionTypeCommand request, CancellationToken cancellationToken)
    {
        var DeductionType = await _DeductionTypeRepository.GetById(request.Id);
        await _deductionTypeRepository.Delete(DeductionType);
        return Unit.Value;
    }

    async Task IRequestHandler<DeleteDeductionTypeCommand>.Handle(DeleteDeductionTypeCommand request, CancellationToken cancellationToken)
    {
        var DeductionType = await _deductionTypeRepository.GetById(request.Id);
        if (DeductionType == null)
            throw new NotFoundException(nameof(DeductionType), request.Id);
        DeductionType.Status = 1;
        await _deductionTypeRepository.Update(DeductionType);
    }
}
}