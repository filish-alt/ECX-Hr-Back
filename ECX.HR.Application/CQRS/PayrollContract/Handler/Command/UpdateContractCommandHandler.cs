using AutoMapper;
using ECX.HR.Application.ContractS.Persistence;
using ECX.HR.Application.CQRS.PayrollContract.Request.Command;

using ECX.HR.Application.DTOs.PayrollContract.ContacDtotValidator;
using ECX.HR.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Contract.Handler.Command
{
    public class UpdateContractCommandHandler : IRequestHandler<UpdateContractCommand, Unit>
    {
        private IPayrollContractRepository _ContractRepository;
        private IMapper _mapper;
        public UpdateContractCommandHandler(IPayrollContractRepository ContractRepository, IMapper mapper)
        {
            _ContractRepository = ContractRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateContractCommand request, CancellationToken cancellationToken)
        {
            var validator = new PayrollContractDtoValidator();
            var validationResult = await validator.ValidateAsync(request.PayrollContractDto);
            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);
            var Contract = await _ContractRepository.GetById(request.PayrollContractDto.Id);
            _mapper.Map(request.PayrollContractDto, Contract);
            await _ContractRepository.Update(Contract);
            return Unit.Value;
        }
    }
}
