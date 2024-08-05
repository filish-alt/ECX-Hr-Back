using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.Deduction.Request.Queries;
using ECX.HR.Application.CQRS.TempPayroll.Request.Command;
using ECX.HR.Application.DTOs.Payroll.validator;
using ECX.HR.Application.DTOs.TempPayroll.validator;
using ECX.HR.Application.Response;
using ECX.HR.Domain;
using MediatR;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.TempPayroll.Handler.Command
{
    public class CreateTempPayrollCommandHandler : IRequestHandler<CreateTempPayrollCommand, BaseCommandResponse>
    {
        BaseCommandResponse response;
        private ITempPayrollRepository _temPayrollRepository;
        private readonly IMediator _mediator;
        private IEmployeeRepository _employeeRepository;
        private readonly IDepositAutorizationRepository _depositAutorizationRepository;
        private readonly IAllwoanceRepository _allwoanceRepository;
        private readonly IAllowanceTypeRepository _allowanceTypeRepository;
        private readonly IDeductionRepository _deductionRepository;
        private readonly IDeductionTypeRepository _deductionTypeRepository;
        private readonly ITaxRepository _taxRepository;
        private readonly ITempPayrollRepository temPayrollRepository;
        private readonly IDivisionRepository _divisionRepository;
        private readonly IStepRepository _stepRepository;
        private readonly IPositionRepository _positionRepository;
        private IEmployeePositionRepository _employeePositionRepository;
        private IMapper _mapper;
        private readonly IOverTimeRepository _overTimeRepository;
        private readonly IAttendanceRepository _attendanceRepository;
        private readonly IPayrollRepository _payrollRepository;

        public CreateTempPayrollCommandHandler(ITempPayrollRepository temPayrollRepository, IMediator mediator,
            IDivisionRepository divisionRepository,IStepRepository stepRepository,
            IPositionRepository positionRepository,IEmployeePositionRepository employeePositionRepository,
            IEmployeeRepository employeeRepository ,IDepositAutorizationRepository depositAutorizationRepository,
            IAllwoanceRepository allwoanceRepository,IAllowanceTypeRepository allowanceTypeRepository,
            IDeductionRepository deductionRepository,IDeductionTypeRepository deductionTypeRepository,ITaxRepository taxRepository,
            IMapper mapper,IOverTimeRepository overTimeRepository,IAttendanceRepository attendanceRepository,IPayrollRepository payrollRepository)
        {
           
            _temPayrollRepository = temPayrollRepository;
           _mediator = mediator;
            _divisionRepository = divisionRepository;
            _stepRepository = stepRepository;
            _positionRepository = positionRepository;
            _employeePositionRepository = employeePositionRepository;
            _employeeRepository = employeeRepository;
           _depositAutorizationRepository = depositAutorizationRepository;
            _allwoanceRepository = allwoanceRepository;
            _allowanceTypeRepository = allowanceTypeRepository;
           _deductionRepository = deductionRepository;
            _deductionTypeRepository = deductionTypeRepository;
        _taxRepository = taxRepository;
            _mapper = mapper;
            _overTimeRepository = overTimeRepository;
            _attendanceRepository = attendanceRepository;
           _payrollRepository = payrollRepository;
        }

        public async Task<BaseCommandResponse> Handle(CreateTempPayrollCommand request, CancellationToken cancellationToken)
        {
            response = new BaseCommandResponse();
            var validator = new TempPayRollDtoValidator();
            var validationResult = await validator.ValidateAsync(request.TempPayRollDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Faild";
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
            var Employee = await _employeeRepository.GetAll();
            var activeEmployee = Employee.Where(employee => employee.Status == 0);


            var pp = await _temPayrollRepository.GetAll();
            foreach (var p in pp)
            {
                   await _temPayrollRepository.Delete(p
                       );
            }



            foreach (var employee in activeEmployee)
            {
                var EmpPosition = await _employeePositionRepository.GetByEmpId(employee.EmpId);
                var deduction = await _deductionRepository.GetByEmpId(employee.EmpId);


                if (EmpPosition != null)
                {
                    var allowance = await _allwoanceRepository.GetByPosId(EmpPosition.position, EmpPosition.StepId);

                    var over = await _overTimeRepository.GetByEmpId(employee.EmpId);
                    var attendance = await _attendanceRepository.GetByEmpId(employee.EmpId);



                    request.TempPayRollDto.EmpId = employee.EmpId;
                    request.TempPayRollDto.EcxId = employee.EcxId;
                    request.TempPayRollDto.DateOfEmployeement = employee.JoinDate;
                    //EmployeePositioon
                    request.TempPayRollDto.PositionID = EmpPosition.position;
                    request.TempPayRollDto.BranchID = EmpPosition.BranchId;
                    var Div = await _divisionRepository.GetById(EmpPosition.DivisionId);
                    request.TempPayRollDto.DepartmentID = Div.DepartmentId;
                    request.TempPayRollDto.StepID = EmpPosition.StepId;
                    var step = await _stepRepository.GetById(EmpPosition.StepId);
                    request.TempPayRollDto.GradeID = step.LevelId;
                    request.TempPayRollDto.BasicSalary = step.Salary;
                    //Bank
                    var deposite = await _depositAutorizationRepository.GetByEmpId(employee.EmpId);
                    request.TempPayRollDto.TinNumber = deposite.TinNumber;
                    request.TempPayRollDto.BankAccountNumber = deposite.BankAccount;
                    request.TempPayRollDto.Bank = deposite.BankId;
                    request.TempPayRollDto.BankBranch = deposite.BankBranch;


                    //Allowances
                    /* var Allowances=await _allwoanceRepository.GetAll();
                     var All = Allowances.Where(a => a.Position == EmpPosition.position && a.Step == EmpPosition.StepId && a.Grade == step.LevelId);
                  */

                    foreach (var a in allowance)
                    {
                        var AllType = await _allowanceTypeRepository.GetById(a.AllowanceType);
                        if (AllType != null && AllType.Name == "HardShip")
                        {
                            request.TempPayRollDto.HardShipA = a.Amount;

                        }
                        if (AllType != null && AllType.Name == "Transport")
                        {
                            request.TempPayRollDto.TransportA = a.Amount;
                        }
                        if (AllType != null && AllType.Name == "Telephone")
                        {
                            request.TempPayRollDto.TelephoneA = a.Amount;
                        }
                        if (AllType != null && AllType.Name == "Housing")
                        {
                            request.TempPayRollDto.HousingA = a.RatePercent * request.TempPayRollDto.BasicSalary;
                        }
                        if (AllType != null && AllType.Name == "Living")
                        {
                            request.TempPayRollDto.LivingA = a.RatePercent * request.TempPayRollDto.BasicSalary;
                        }

                        if (AllType != null && AllType.Name == "TaxExcemptedT")
                        {
                            request.TempPayRollDto.TaxExcemptedTA = a.Amount;
                        }
                        if (AllType != null && AllType.Name == "OtherTax")
                        {
                            request.TempPayRollDto.OtherTaxA = a.Amount;
                        }

                    }




                    var yearOfWork = DateTime.Now - employee.JoinDate;
                    //  request.TempPayRollDto.SalaryAdvance = yearOfWork;

                    request.TempPayRollDto.GrossEarnings = request.TempPayRollDto.OtherTaxA + request.TempPayRollDto.BasicSalary + request.TempPayRollDto.OverTime
                        + request.TempPayRollDto.LivingA + request.TempPayRollDto.HousingA +
                        request.TempPayRollDto.TransportA;

                    request.TempPayRollDto.TaxableAmount = request.TempPayRollDto.GrossEarnings - request.TempPayRollDto.TaxExcemptedTA;
                    var Tax = await _taxRepository.GetAll();
                    var t = Tax.FirstOrDefault(t => (t.SalaryStart <= request.TempPayRollDto.TaxableAmount) && (t.SalaryEnd >= request.TempPayRollDto.TaxableAmount));



                    //attendance

                    var pay = await _payrollRepository.GetAll();
                    var allpayroll = pay.Select(d => d.PayRollEndDate).ToArray(); ;


                    if (allpayroll.Length == 0)
                    {
                        request.TempPayRollDto.PayRollStartDate = DateTime.Parse("2023-11-16 00:00:00.000");
                    }
                    else
                    {

                        var startDate = (allpayroll.OrderByDescending(d => d));

                        var st = startDate.FirstOrDefault(d => d < DateTime.Now);
                        request.TempPayRollDto.PayRollStartDate = st.AddDays(1);

                    }

                    request.TempPayRollDto.AbsentD = 0;

                    request.TempPayRollDto.PayRollEndDate = request.TempPayRollDto.PayRollStartDate.AddMonths(1).AddDays(-1);

                    var selectedAttendance = attendance.Where(a => a.date >= request.TempPayRollDto.PayRollStartDate &&
                    a.date <= request.TempPayRollDto.PayRollEndDate);
                    double absent = 0;
                    TimeSpan late = TimeSpan.Parse("00:00:00");
                    TimeSpan early = TimeSpan.Parse("00:00:00");
                    TimeSpan total = TimeSpan.Parse("00:00:00");
                    double absentHour = 0;

                    foreach (var at in selectedAttendance)

                    {
                        if (at.Late != null)
                        {
                            late = late + at.Late.Value.TimeOfDay;
                        }
                        if (at.Early != null)
                        {

                            early = early + at.Early.Value.TimeOfDay;
                        }

                        total = late + early;


                        double pf = 0.5;
                        if (at.AbsentDays == pf)
                        {
                            absentHour += pf;
                            double round = (4 * (absentHour) / 0.5);
                            request.TempPayRollDto.AbsentD = Math.Round(round, 2);
                        }
                        double ptf = 0.25;
                        if (at.AbsentDays == ptf)
                        {

                            absent = absent + ptf;
                            if (absent >= 1.25)
                            {

                                absentHour = +ptf;
                                double round=2 * (absentHour) / 0.25;

                                request.TempPayRollDto.AbsentD = Math.Round(round,2);
                            }

                        }
                    }
                   //
                   //request.TempPayRollDto.AbsentD =;
                    if (total > TimeSpan.Parse("04:00:00"))
                    {
                        double round = request.TempPayRollDto.AbsentD + double.Parse(total.TotalHours.ToString());
                        request.TempPayRollDto.AbsentD = Math.Round(round, 2); 

                    }
                    //Deductions
                    double roundIt = t.TaxRate * request.TempPayRollDto.TaxableAmount;
                    request.TempPayRollDto.IncomeTax = Math.Round(roundIt, 2);

                    double roundpe7 = (request.TempPayRollDto.BasicSalary * 7) / 100;
                    request.TempPayRollDto.PensionContribution7 = Math.Round(roundpe7, 2);

                    double roundpe11 = (request.TempPayRollDto.BasicSalary * 11) / 100;
                    request.TempPayRollDto.PensionContribution11 = Math.Round(roundpe11, 2);

                    if (deduction != null)
                    {

                        request.TempPayRollDto.SavingForCreditAssD = 0;
                        request.TempPayRollDto.SavingForHousingD = 0;

                        request.TempPayRollDto.RegistrationD = 0;
                        request.TempPayRollDto.LoanRefund = 0;
                        request.TempPayRollDto.SalaryAdvance = 0;
                        request.TempPayRollDto.ShareD = 0;
                        request.TempPayRollDto.ForStreetChildrenD = 0;
                        request.TempPayRollDto.GebetaLehagerD = 0;
                        request.TempPayRollDto.Penality = 0;
                        request.TempPayRollDto.CourtAndOtherD = 0;
                        request.TempPayRollDto.CostShareD = 0;
                        request.TempPayRollDto.SavingForHousingD = 0;
                        request.TempPayRollDto.SavingForHousingD = 0;
                        foreach (var dd in deduction)
                        {
                            var deductiontypeName = await _deductionTypeRepository.GetById(dd.DeductionType);


                            if (deductiontypeName.Name == "SavingForCreditAssociation")
                            {
                                request.TempPayRollDto.SavingForCreditAssD = (request.TempPayRollDto.BasicSalary * 5) / 100;
                            }
                            if (deductiontypeName.Name == "SavingForHousing")
                            {
                                request.TempPayRollDto.SavingForHousingD = (request.TempPayRollDto.BasicSalary * 5) / 100;
                            }


                            if (deductiontypeName.Name == "Registration" && dd.Amount > 0)
                            {
                                request.TempPayRollDto.RegistrationD = dd.Amount;
                                /*          dd.Amount = 0;*/
                            }
                            if (deductiontypeName.Name == "CostSharing" && dd.Amount > 0)
                            {
                                request.TempPayRollDto.CostShareD = Math.Min(((request.TempPayRollDto.BasicSalary * 10) / 100), dd.Amount);
                                /*     dd.Amount = dd.Amount - request.TempPayRollDto.CostShareD;*/
                            }
                            if (deductiontypeName.Name == "LoanRefund" && dd.Amount > 0)
                            {
                                request.TempPayRollDto.LoanRefund = Math.Min(((request.TempPayRollDto.BasicSalary * 10) / 100), dd.Amount);
                                /*        dd.Amount = dd.Amount - request.TempPayRollDto.LoanRefund;*/
                            }
                            if (deductiontypeName.Name == "Penality" && dd.Amount > 0)
                            {
                                request.TempPayRollDto.Penality = dd.Amount;
                                /*    dd.Amount = dd.Amount - request.TempPayRollDto.Penality;*/

                            }
                            if (deductiontypeName.Name == "Share" && dd.Amount > 0)
                            {
                                request.TempPayRollDto.ShareD = dd.Amount;
                                /*    dd.Amount = 0;*/
                            }

                            if (deductiontypeName.Name == "CourtAndOther" && dd.Amount > 0)
                            {
                                request.TempPayRollDto.CourtAndOtherD = dd.Amount;
                            }
                            if (deductiontypeName.Name == "GebetaLehager")
                            {
                                double roundgebta = request.TempPayRollDto.BasicSalary * (10 / 600);
                              request.TempPayRollDto.GebetaLehagerD = Math.Round(roundgebta, 2);
                                
                            }


                            if (deductiontypeName.Name == "SalaryAdvance" && dd.Amount>0)
                            {
                                double roundsalary = dd.Amount / dd.Length;
                                request.TempPayRollDto.SalaryAdvance = Math.Round(roundsalary, 2);
        }



                            if (deductiontypeName.Name == "ForStreetChildren")
                            {
                                double roundstreet = (request.TempPayRollDto.BasicSalary * 1) / 100;
                                request.TempPayRollDto.ForStreetChildrenD = Math.Round(roundstreet, 2);

                            }
                            double roundcreadit = request.TempPayRollDto.SavingForHousingD + request.TempPayRollDto.SavingForCreditAssD
                                + request.TempPayRollDto.LoanRefund + request.TempPayRollDto.Penality + request.TempPayRollDto.RegistrationD + request.TempPayRollDto.ShareD;

                            request.TempPayRollDto.CreditAssociationD = Math.Round(roundcreadit, 2);


                            double rounddeduction = request.TempPayRollDto.CreditAssociationD + request.TempPayRollDto.ForStreetChildrenD +
                                  request.TempPayRollDto.GebetaLehagerD + request.TempPayRollDto.CourtAndOtherD + request.TempPayRollDto.PensionContribution7 +
                                  request.TempPayRollDto.IncomeTax + request.TempPayRollDto.SalaryAdvance + request.TempPayRollDto.CostShareD
                                ;

                            request.TempPayRollDto.TotalDeduction = Math.Round(rounddeduction, 2);
                            /*      */
                        }

                    }
                    else
                    {
                        request.TempPayRollDto.SavingForCreditAssD = 0;
                        request.TempPayRollDto.SavingForHousingD = 0;

                        request.TempPayRollDto.RegistrationD = 0;
                        request.TempPayRollDto.LoanRefund = 0;
                        request.TempPayRollDto.SalaryAdvance = 0;
                        request.TempPayRollDto.ShareD = 0;
                        request.TempPayRollDto.ForStreetChildrenD = 0;
                        request.TempPayRollDto.GebetaLehagerD = 0;
                        request.TempPayRollDto.Penality = 0;
                        request.TempPayRollDto.CourtAndOtherD = 0;
                        request.TempPayRollDto.CostShareD = 0;
                        request.TempPayRollDto.SavingForHousingD = 0;
                        request.TempPayRollDto.SavingForHousingD = 0;

                        request.TempPayRollDto.CreditAssociationD = request.TempPayRollDto.SavingForHousingD + request.TempPayRollDto.SavingForCreditAssD
                               + request.TempPayRollDto.LoanRefund + request.TempPayRollDto.Penality + request.TempPayRollDto.RegistrationD + request.TempPayRollDto.ShareD;

                        request.TempPayRollDto.TotalDeduction = request.TempPayRollDto.CreditAssociationD + request.TempPayRollDto.ForStreetChildrenD +
                              request.TempPayRollDto.GebetaLehagerD + request.TempPayRollDto.CourtAndOtherD + request.TempPayRollDto.PensionContribution7 +
                              request.TempPayRollDto.IncomeTax + request.TempPayRollDto.SalaryAdvance + request.TempPayRollDto.CostShareD+ 
                              (request.TempPayRollDto.BasicSalary * request.TempPayRollDto.AbsentD/192) - (request.TempPayRollDto.BasicSalary * request.TempPayRollDto.AbsentTolerance / 192)

                            ;



                    }


                    // OverTime

                    if (over != null)
                    {

                        request.TempPayRollDto.OTDay = Math.Round(over.OTDay* 1.25 * (request.TempPayRollDto.BasicSalary/192),2);
              
                        request.TempPayRollDto.OTNight = Math.Round(over.OTNight * 1.50 * ( request.TempPayRollDto.BasicSalary/192),2);

                        request.TempPayRollDto.OTWeekend = Math.Round( over.OTWeekend * 2 * (request.TempPayRollDto.BasicSalary / 192),2);

                        request.TempPayRollDto.OTHoliday = Math.Round(over.OTHoliday * 2.5 * (request.TempPayRollDto.BasicSalary / 192),2);

                        request.TempPayRollDto.OverTime = Math.Round((request.TempPayRollDto.OTDay + request.TempPayRollDto.OTNight + request.TempPayRollDto.OTWeekend 
                            + request.TempPayRollDto.OTHoliday),2);

                    }


                    //promotion
                    /*    request.TempPayRollDto.PreviousNet =;
                        request.TempPayRollDto.PromotionStatus =;
                        request.TempPayRollDto.ActingStatus =;
        */
                    double roundnet = request.TempPayRollDto.GrossEarnings - request.TempPayRollDto.TotalDeduction;
                  
                    request.TempPayRollDto.NetPay = Math.Round(roundnet, 2);
                    request.TempPayRollDto.AmtTransfer = request.TempPayRollDto.NetPay + request.TempPayRollDto.TelephoneA + request.TempPayRollDto.HardShipA;



                    var Payroll = _mapper.Map<TempPayrolls>(request.TempPayRollDto);
                    Payroll.Id = Guid.NewGuid();
                    var data = await _temPayrollRepository.Add(Payroll);
           


                }
            }
            response.Success = true;
            response.Message = "Creation Successfull";
            return response;
        }
    }
}
