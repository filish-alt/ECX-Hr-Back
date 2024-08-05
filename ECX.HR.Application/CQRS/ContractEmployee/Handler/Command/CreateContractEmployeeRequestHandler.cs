using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.ContractEmployee.Request.Command;
using ECX.HR.Application.CQRS.Employee.Request.Command;
using ECX.HR.Application.DTOs.Employees.Validator;
using ECX.HR.Application.DTOs.PayrollContract.ContacDtotValidator;
using ECX.HR.Application.Response;
using ECX.HR.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.ContractEmployee.Handler.Command
{
    public class CreateContractEmployeeRequestHandler : IRequestHandler<CreateContractEmployeeCommand, BaseCommandResponse>
    {
        BaseCommandResponse response;
      
        private IMapper _mapper;
        private readonly IContractEmployeesRegstration _contractEmployeesRegstrationRepository;
        private IMediator _mediator;
        public CreateContractEmployeeRequestHandler(IContractEmployeesRegstration contractEmployeesRegstrationRepository, IMediator mediator, IMapper mapper)
        {
   
            _mapper = mapper;
    _contractEmployeesRegstrationRepository = contractEmployeesRegstrationRepository;
            _mediator = mediator;
            var _employeeLists = new List<Employees>();
        }
        public async Task<BaseCommandResponse> Handle(CreateContractEmployeeCommand request, CancellationToken cancellationToken)
        {
            response = new BaseCommandResponse();
            var validator = new ContractRegistrationDtoValidator();
            var validationResult = await validator.ValidateAsync(request.ContractEmployeeDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Faild";
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }

            var Employee = _mapper.Map<ContractEmployees>(request.ContractEmployeeDto);
            Employee.EmpId = Guid.NewGuid();
            var emp = Employee.EmpId;

            var Empl = await _contractEmployeesRegstrationRepository.GetAll();
            var Emp_count = Empl.Count() + 1;
            int Digit_Length = (int)Emp_count.ToString().Length;
            string EcxId_number = Digit_Length >= 4 ? Emp_count.ToString() : Emp_count.ToString("D4");
            DateTime Today = DateTime.Now;
            var Emp_EcxId = "ECX/" + EcxId_number + "/" + Today.Year;
            Employee.EcxId = Emp_EcxId;
            var data = await _contractEmployeesRegstrationRepository.Add(Employee);

            response.Success = true;
            response.Message = "Creation Successfull";
            response.Id = (Guid)emp;
            return response;
        }

    }
}
