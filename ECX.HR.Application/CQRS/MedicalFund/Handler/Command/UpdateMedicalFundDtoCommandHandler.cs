using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;

using ECX.HR.Application.CQRS.MedicalFund.Request.Command;
using ECX.HR.Application.DTOs.MedicalFunds.Validator;
using ECX.HR.Application.Exceptions;
using ECX.HR.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.MedicalFund.Handler.Command
{
    public class UpdateMedicalFundDtoCommandHandler : IRequestHandler<UpdateMedicalFund, Unit>
    {
        private readonly IMedicalFundRepository _medicalFundRepository;
        private readonly IMedicalBalanceRepository _medicalBalanceRepository;
        private readonly IMapper _mapper;

        public UpdateMedicalFundDtoCommandHandler(IMedicalFundRepository medicalFundRepository,
            IMedicalBalanceRepository medicalBalanceRepository  ,IMapper mapper)
        {
            _medicalFundRepository = medicalFundRepository;
            _medicalBalanceRepository = medicalBalanceRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateMedicalFund request, CancellationToken cancellationToken)
        {
            var validator = new MedicalFundDtoValidators();
            var validationResult = await validator.ValidateAsync(request.MedicalFundDto);
            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            request.MedicalFundDto.UpdatedDate = DateTime.Now;
            var act = await _medicalFundRepository.GetById(request.MedicalFundDto.MedicalRequestId);
            var employeeId = request.MedicalFundDto.EmpId;
            if (request.MedicalFundDto.ApprovalStatus == "Admin-Approved")
            {
                var medicalBalances = await _medicalBalanceRepository.GetByEmpId(employeeId);
                foreach (var medicalBalance in medicalBalances.OrderBy(lb => lb.StartDate))
                {
                    Guid dd = Guid.Empty;
                    if (request.MedicalFundDto.SpouseId == null && medicalBalance.SpouseId == dd)

                    {
                        medicalBalance.SelfBalance = Math.Round(medicalBalance.SelfBalance -request.MedicalFundDto.TotalFund ,  2);
                      medicalBalance.FamilyBalance = 0;
                    }
              if(request.MedicalFundDto.SpouseId != null && medicalBalance.SpouseId==act.SpouseId)
                    {
                        
                        medicalBalance.FamilyBalance = Math.Round(medicalBalance.FamilyBalance-request.MedicalFundDto.Total , 2);
                        medicalBalance.SelfBalance = 0;
            

                    }
                    await _medicalBalanceRepository.Update(medicalBalance);

                }
            }
                _mapper.Map(request.MedicalFundDto, act);

            await _medicalFundRepository.Update(act);
          
            return Unit.Value;
        }
    }
}
