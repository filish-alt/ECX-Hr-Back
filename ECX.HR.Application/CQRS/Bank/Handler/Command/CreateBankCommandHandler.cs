using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.Bank.Request.Command;
using ECX.HR.Application.DTOs.Bank.validator;
using ECX.HR.Application.Response;
using ECX.HR.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Bank.Handler.Command
{
    public class CreateBankCommandHandler : IRequestHandler<CreateBankCommand, BaseCommandResponse>
    {
        BaseCommandResponse response;
        private IBankRepository _BankRepository;
        private IMapper _mapper;
        public CreateBankCommandHandler(IBankRepository BankRepository, IMapper mapper)
        {
            _BankRepository = BankRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateBankCommand request, CancellationToken cancellationToken)
        {
            response = new BaseCommandResponse();
            var validator = new BankDtoValidator();
            var validationResult = await validator.ValidateAsync(request.BankDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Faild";
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }

            var Bank = _mapper.Map<Banks>(request.BankDto);
            Bank.Id = Guid.NewGuid();
            var bra = Bank.Id;
            var data = await _BankRepository.Add(Bank);
            response.Success = true;
            response.Message = "Creation Successfull";
            response.Id = (Guid)bra;
            return response;

        }
    }
}
