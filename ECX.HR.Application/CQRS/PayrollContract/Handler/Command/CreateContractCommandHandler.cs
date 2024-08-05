using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.ContractS.Persistence;
using ECX.HR.Application.CQRS.PayrollContract.Request.Command;

using ECX.HR.Application.DTOs.PayrollContract.ContacDtotValidator;
using ECX.HR.Application.Response;
using ECX.HR.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Contract.Handler.Command
{
    public class CreateContractCommandHandler : IRequestHandler<CreateContractCommand, BaseCommandResponse>
    {
        BaseCommandResponse response;
        private IPayrollContractRepository _ContractRepository;
        private readonly IContractEmployeesRegstration _contractEmployeesRegstration;
        private readonly IEmployeePositionRepository _employeePositionRepository;
        private readonly IDivisionRepository _divisionRepository;
        private readonly IStepRepository _stepRepository;
        private readonly IDepositAutorizationRepository _depositAutorizationRepository;
        private readonly ITaxRepository _taxRepository;
        private readonly IAllwoanceRepository _allwoanceRepository;
        private readonly IPayrollContractRepository _payrollContractRepository;
        private IMapper _mapper;
        public CreateContractCommandHandler(IPayrollContractRepository ContractRepository,
            IContractEmployeesRegstration contractEmployeesRegstration ,
            IEmployeePositionRepository employeePositionRepository,IDivisionRepository divisionRepository,
            IStepRepository stepRepository,IDepositAutorizationRepository depositAutorizationRepository
            ,ITaxRepository taxRepository,IAllwoanceRepository allwoanceRepository,IPayrollContractRepository payrollContractRepository,IMapper mapper)
        {
            _ContractRepository = ContractRepository;
            _contractEmployeesRegstration = contractEmployeesRegstration;
             _employeePositionRepository = employeePositionRepository;
            _divisionRepository = divisionRepository;
            _stepRepository = stepRepository;
           _depositAutorizationRepository = depositAutorizationRepository;
           _taxRepository = taxRepository;
            _allwoanceRepository = allwoanceRepository;
            _payrollContractRepository = payrollContractRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateContractCommand request, CancellationToken cancellationToken)
        {
            response = new BaseCommandResponse();
            var validator = new PayrollContractDtoValidator();
            var validationResult = await validator.ValidateAsync(request.PayrollContractDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Faild";
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }

    

            var Allemployee = await _contractEmployeesRegstration.GetAll();
            var Employee = Allemployee.Where(employee => employee.Status == 0);
            var pay = await _payrollContractRepository.GetAll();
            var allpayroll = pay.Select(d => d.PayRollEndDate).ToArray(); ;
            foreach (var employee in Employee)
            {
              ///  var EmpPosition = await _employeePositionRepository.GetByEmpId(employee.EmpId);

                if (employee != null)
                {
                    request.PayrollContractDto.EmpId = employee.EmpId;
                    request.PayrollContractDto.EcxId = employee.EcxId;
                    request.PayrollContractDto.DateOfEmployeement = employee.JoinDate;
                    //EmployeePositioon
                    request.PayrollContractDto.PositionID = employee.position;
                    request.PayrollContractDto.BranchID = employee.BranchId;
                    var Div = await _divisionRepository.GetById(employee.DivisionId);
                    request.PayrollContractDto.DepartmentID = Div.DepartmentId;
                    request.PayrollContractDto.StepID = employee.StepId;
                    var step = await _stepRepository.GetById(employee.StepId);
                    request.PayrollContractDto.GradeID = step.LevelId;
                    request.PayrollContractDto.BasicSalary = step.Salary;
                    //Bank
                   // var deposite = await _depositAutorizationRepository.GetByEmpId(employee.EmpId);
                    request.PayrollContractDto.TinNumber = employee.TinNumber;
                    request.PayrollContractDto.BankAccountNumber = employee.BankAccount;
                    request.PayrollContractDto.Bank = employee.BankId;
                    request.PayrollContractDto.BankBranch = employee.BankBranch;
                }

                request.PayrollContractDto.GrossEarnings = request.PayrollContractDto.BasicSalary;

                request.PayrollContractDto.TaxableAmount = request.PayrollContractDto.GrossEarnings;
                var Tax = await _taxRepository.GetAll();
                var t = Tax.FirstOrDefault(t => (t.SalaryStart <= request.PayrollContractDto.TaxableAmount) && (t.SalaryEnd >= request.PayrollContractDto.TaxableAmount));


                double roundIt = t.TaxRate * request.PayrollContractDto.TaxableAmount;
                request.PayrollContractDto.IncomeTax = Math.Round(roundIt, 2);

                double roundpe7 = (request.PayrollContractDto.BasicSalary * 7) / 100;
                request.PayrollContractDto.PensionContribution7 = Math.Round(roundpe7, 2);

                double roundpe11 = (request.PayrollContractDto.BasicSalary * 11) / 100;
                request.PayrollContractDto.PensionContribution11 = Math.Round(roundpe11, 2);
                double TotalDeduction = request.PayrollContractDto.PensionContribution7 +
                                     request.PayrollContractDto.IncomeTax;


              
                request.PayrollContractDto.ContratStartDate = employee.StartDate;
                request.PayrollContractDto.ContractEndDate = employee.EndDate;

  
          


                if (allpayroll.Length == 0)
                    {
                        request.PayrollContractDto.PayRollStartDate = DateTime.Parse("2023-12-16 00:00:00.000");
                    }
                    else
                    {

                        var startDate = (allpayroll.OrderByDescending(d => d));

                        var st = startDate.FirstOrDefault(d => d < DateTime.Now);
                        request.PayrollContractDto.PayRollStartDate = st.AddDays(1);

                    }
                var diff = request.PayrollContractDto.PayRollStartDate - request.PayrollContractDto.ContratStartDate;

                if (diff.Days>=1)
                {
                    TotalDeduction= TotalDeduction + (diff.Days * (request.PayrollContractDto.BasicSalary/192));
                } 
                request.PayrollContractDto.PayRollEndDate = request.PayrollContractDto.PayRollStartDate.AddDays(30);
                 request.PayrollContractDto.NetPay = request.PayrollContractDto.BasicSalary - TotalDeduction;

                var Contract = _mapper.Map<PayrollContracts>(request.PayrollContractDto);
                Contract.Id = Guid.NewGuid();
                var bra = Contract.Id;
                var data = await _ContractRepository.Add(Contract);

    
            }    
            response.Success = true;
                response.Message = "Creation Successfull";
                return response;
        }
    }
}
