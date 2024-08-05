using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.DductionType.Request.Command;
using ECX.HR.Application.DTOs.DeductionType.Validator;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECX.HR.Application.Exceptions;

namespace ECX.HR.Application.CQRS.DductionType.Handler.Command
{

    public class UpdateDeductionTypeCommandHandler : IRequestHandler<UpdateDeductionTypeCommand, Unit>
    {
        
        private readonly IDeductionTypeRepository _deductionTypeRepository;
        private IMapper _mapper;
        public UpdateDeductionTypeCommandHandler(IDeductionTypeRepository DeductionTypeRepository, IMapper mapper)
        {
            
           _deductionTypeRepository = DeductionTypeRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateDeductionTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new DeductionTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.DeductionTypeDto);
            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);
            var DeductionType = await _deductionTypeRepository.GetById(request.DeductionTypeDto.Id);
            _mapper.Map(request.DeductionTypeDto, DeductionType);
            await _deductionTypeRepository.Update(DeductionType);
            return Unit.Value;
        }
    }
} 