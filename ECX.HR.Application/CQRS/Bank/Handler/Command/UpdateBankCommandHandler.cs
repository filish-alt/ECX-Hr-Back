using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.Bank.Request.Command;
using ECX.HR.Application.DTOs.Bank.validator;
using ECX.HR.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Bank.Handler.Command
{
    public class UpdateBankCommandHandler : IRequestHandler<UpdateBankCommand, Unit>
    {
        private IBankRepository _BankRepository;
        private IMapper _mapper;
        public UpdateBankCommandHandler(IBankRepository BankRepository, IMapper mapper)
        {
            _BankRepository = BankRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateBankCommand request, CancellationToken cancellationToken)
        {
            var validator = new BankDtoValidator();
            var validationResult = await validator.ValidateAsync(request.BankDto);
            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);
            var Bank = await _BankRepository.GetById(request.BankDto.Id);
            _mapper.Map(request.BankDto, Bank);
            await _BankRepository.Update(Bank);
            return Unit.Value;
        }
    }
}
