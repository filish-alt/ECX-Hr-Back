using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.DductionType.Request.Command;
using ECX.HR.Application.CQRS.Deduction.Request.Command;
using ECX.HR.Application.DTOs.Deduction.Validator;
using ECX.HR.Application.DTOs.Deduction.Validator;
using ECX.HR.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Deduction.Handler.Command
{
    public class UpdateDeductionCommandHandler : IRequestHandler<UpdateDeductionCommand, Unit>
    {

        private readonly IDeductionRepository _deductionRepository;
        private IMapper _mapper;
        public UpdateDeductionCommandHandler(IDeductionRepository DeductionRepository, IMapper mapper)
        {

          
           _deductionRepository = DeductionRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateDeductionCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeductionDtoValidator();
            var validationResult = await validator.ValidateAsync(request.deductionDto);
            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);
            var Deduction = await _deductionRepository.GetById(request.deductionDto.Id);
            _mapper.Map(request.deductionDto, Deduction);
            await _deductionRepository.Update(Deduction);
            return Unit.Value;
        }
    }
}