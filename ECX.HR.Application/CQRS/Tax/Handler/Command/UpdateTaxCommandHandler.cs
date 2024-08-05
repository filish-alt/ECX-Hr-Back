using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.Tax.Request.Command;
using ECX.HR.Application.DTOs.Tax.validator;
using ECX.HR.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Tax.Handler.Command
{
    public class UpdateTaxCommandHandler : IRequestHandler<UpdateTaxCommand, Unit>
    {
        private ITaxRepository _TaxRepository;
        private IMapper _mapper;
        public UpdateTaxCommandHandler(ITaxRepository TaxRepository, IMapper mapper)
        {
            _TaxRepository = TaxRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateTaxCommand request, CancellationToken cancellationToken)
        {
            var validator = new TaxDtoValidator();
            var validationResult = await validator.ValidateAsync(request.TaxDto);
            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);
            var Tax = await _TaxRepository.GetById(request.TaxDto.Id);
            _mapper.Map(request.TaxDto, Tax);
            await _TaxRepository.Update(Tax);
            return Unit.Value;
        }
    }
}
