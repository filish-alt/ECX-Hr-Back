using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;

using ECX.HR.Application.CQRS.PayRoll.Request.Command;
using ECX.HR.Application.DTOs.Payroll.validator;

using ECX.HR.Application.Response;
using ECX.HR.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.PayRoll.Handler.Command
{
    public class CreatePayrollCommandHandler : IRequestHandler<CreatePayrollCommand, BaseCommandResponse>
    {
        BaseCommandResponse response;
        private IPayrollRepository _PayrollRepository;
        private readonly ITempPayrollRepository _tempPayrollrepository;
        private readonly IEmployeeRepository _employeerepository;
        private readonly IOverTimeRepository _overTimeRepository;
        private readonly IDeductionRepository _deductionRepository;
        private readonly IDeductionTypeRepository _deductionTypeRepository;

        public CreatePayrollCommandHandler(IPayrollRepository PayrollRepository,ITempPayrollRepository tempPayrollrepository,IEmployeeRepository employeerepository
            ,IMapper mapper,IOverTimeRepository overTimeRepository,IDeductionRepository deductionRepository,IDeductionTypeRepository deductionTypeRepository)
        {
         _PayrollRepository = PayrollRepository;
           _tempPayrollrepository = tempPayrollrepository;
            _employeerepository = employeerepository;
           _overTimeRepository = overTimeRepository;
            _deductionRepository = deductionRepository;
           _deductionTypeRepository = deductionTypeRepository;
        }

        public IPayrollRepository PayrollRepository { get => _PayrollRepository; set => _PayrollRepository = value; }
        public IEmployeePositionRepository EmployeePositionRepository { get; }
        public IEmployeeRepository EmployeeRepository { get; }

        public async Task<BaseCommandResponse> Handle(CreatePayrollCommand request, CancellationToken cancellationToken)
        {
            response = new BaseCommandResponse();
            var validator = new PayRollDtoValidator();
            var validationResult = await validator.ValidateAsync(request.PayRollDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Faild";
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
            //var temppayroll = _tempPayrollrepository.GetAll();
            var Allemployee = await _employeerepository.GetAll();
            var Employee = Allemployee.Where(employee => employee.Status == 0);

            var pp = await _PayrollRepository.GetAll();
            var allpayroll = pp.Select(d => d.PayRollEndDate).ToArray(); ;


            if (allpayroll.Length == 0)
            {
                request.PayRollDto.PayRollStartDate = DateTime.Parse("2023-11-16 00:00:00.000");
            }
            else
            {

                 var startDate = (allpayroll.OrderByDescending(d => d));

                var st = startDate.FirstOrDefault(d => d < DateTime.Now);
                request.PayRollDto.PayRollStartDate = st.AddDays(1);

            }
           

            request.PayRollDto.PayRollEndDate = request.PayRollDto.PayRollStartDate.AddMonths(1).AddDays(-1);


            foreach (var employee in Employee)
            {
                var temppayroll = await _tempPayrollrepository.GetByEmpId(employee.EmpId);
                var deduction = await _deductionRepository.GetByEmpId(employee.EmpId);

                var over = await _overTimeRepository.GetByEmpId(employee.EmpId);


                foreach (var tpay in temppayroll)
                {
                    var payroll = new Payrolls
                    {
                        EmpId = tpay.EmpId,
                        EcxId = tpay.EcxId,
                        DateOfEmployeement = tpay.DateOfEmployeement,
                        PositionID = tpay.PositionID,
                        BranchID = tpay.BranchID,
                        DepartmentID = tpay.DepartmentID,
                        StepID = tpay.StepID,
                        GradeID = tpay.GradeID,
                        BasicSalary = tpay.BasicSalary,

                        TinNumber = tpay.TinNumber,
                        Bank = tpay.Bank,
                        BankAccountNumber = tpay.BankAccountNumber,
                        BankBranch = tpay.BankBranch,
                        //allowance
                        HardShipA = tpay.HardShipA,
                        TransportA = tpay.TransportA,
                        TelephoneA = tpay.TelephoneA,
                        HousingA = tpay.HousingA,
                        LivingA = tpay.LivingA,
                        TaxExcemptedTA = tpay.TaxExcemptedTA,
                        OtherTaxA = tpay.OtherTaxA,
                        PayRollStartDate = request.PayRollDto.PayRollStartDate,
                        PayRollEndDate = request.PayRollDto.PayRollEndDate,


                        OTDay = tpay.OTDay,
                        OTNight = tpay.OTNight,
                        OTWeekend = tpay.OTWeekend,
                        OTHoliday = tpay.OTHoliday,
                        OverTime = tpay.OverTime,

                        SalaryAdvance = tpay.SalaryAdvance,
                        GrossEarnings = tpay.GrossEarnings,
                        TaxableAmount = tpay.TaxableAmount,
                        IncomeTax = tpay.IncomeTax,
                        //deduction
                        PensionContribution7 = tpay.PensionContribution7,
                        PensionContribution11 = tpay.PensionContribution11,
                        RegistrationD = tpay.RegistrationD,
                        ShareD = tpay.ShareD,
                        Penality = tpay.Penality,
                        CostShareD = tpay.CostShareD,
                        CourtAndOtherD = tpay.CourtAndOtherD,
                        GebetaLehagerD = tpay.GebetaLehagerD,
                        ForStreetChildrenD = tpay.ForStreetChildrenD,
                        LoanRefund = tpay.LoanRefund,
                        SavingForHousingD = tpay.SavingForHousingD,
                        SavingForCreditAssD = tpay.SavingForCreditAssD,
                        CreditAssociationD = tpay.CreditAssociationD,
                        AbsentD = tpay.AbsentD,
                        TotalDeduction = tpay.TotalDeduction,
                        NetPay = tpay.NetPay,
                        AmtTransfer = tpay.AmtTransfer,
                        PromotionStatus = tpay.PromotionStatus,
                        ActingStatus = tpay.ActingStatus,
                        PreviousNet = tpay.PreviousNet,


                    };
                    payroll.Id = Guid.NewGuid();
                    await _PayrollRepository.Add(payroll);
                    await _tempPayrollrepository.Delete(tpay);



                    foreach (var dd in deduction)
                    {
                        var deductiontypeName = await _deductionTypeRepository.GetById(dd.DeductionType);

                        if (deductiontypeName.Name == "Registration" && dd.Amount > 0)
                        {
                          
                                    dd.Amount = 0;
                        }
                        if (deductiontypeName.Name == "CostSharing" && dd.Amount > 0)
                        {
                            dd.Amount = dd.Amount - tpay.CostShareD;
                        }
                        if (deductiontypeName.Name == "LoanRefund" && dd.Amount > 0)
                        {
                                  dd.Amount = dd.Amount - tpay.LoanRefund;
                        }
                        if (deductiontypeName.Name == "Penality" && dd.Amount > 0)
                        {
                                dd.Amount = dd.Amount - tpay.Penality;

                        }
                        if (deductiontypeName.Name == "Share" && dd.Amount > 0)
                        {
                                dd.Amount = 0;
                        }

                        if (deductiontypeName.Name == "SalaryAdvance" && dd.Amount > 0)
                        {
                           
                             dd.Amount= Math.Round(dd.Amount - tpay.SalaryAdvance);

                
                        }

                        await _deductionRepository.Update(dd);
                    }
                }

                
                             over.OTDay = 0;
                             over.OTNight = 0;
                             over.OTWeekend = 0;
                             over.OTHoliday = 0;

                                await _overTimeRepository.Update(over);
            }

            response.Success = true;
            response.Message = "Creation Successfull";
            return response;
        }
    }
}
