using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.ContractEmployee.Request.Command;
using ECX.HR.Application.CQRS.EmployeePosition.Request.Command;
using ECX.HR.Application.CQRS.PayrollContract.Request.Command;
using ECX.HR.Application.DTOs.EmployeePositions.Validator;
using ECX.HR.Application.DTOs.PayrollContract.ContacDtotValidator;
using ECX.HR.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.ContractEmployee.Handler.Command
{
    public class UpdateContractEmployeeRegstrationRequestHandler : IRequestHandler<UpdateContractEmployee, Unit>
    {
      
        private readonly IContractEmployeesRegstration _contractEmpRepository;
        private IMapper _mapper;
        public UpdateContractEmployeeRegstrationRequestHandler(IContractEmployeesRegstration ContractEmpRepository, IMapper mapper)
        {
            
            _contractEmpRepository = ContractEmpRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateContractEmployee request, CancellationToken cancellationToken)
        {
            var validator = new ContractRegistrationDtoValidator();
            var validationResult = await validator.ValidateAsync(request.ContractEmpDto);
            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var EmployeePosition = await _contractEmpRepository.GetById(request.ContractEmpDto.EmpId);
            _mapper.Map(request.ContractEmpDto, EmployeePosition);
            await _contractEmpRepository.Update(EmployeePosition);
            return Unit.Value;
        }
    }
}
