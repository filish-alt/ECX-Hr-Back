using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;

using ECX.HR.Application.CQRS.MedicalFund.Request.Command;
using ECX.HR.Application.DTOs.MedicalFunds.Validator;
using ECX.HR.Application.Response;
using ECX.HR.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.MedicalFund.Handler.Command
{
    public class CreatemedicalFundCommandHandler : IRequestHandler<CreateMedicalFundCommand, BaseCommandResponse>
    {
        BaseCommandResponse response;
        private readonly IMedicalFundRepository _medicalFundRepository;
        private readonly IMapper _mapper;
        private readonly IMedicalBalanceRepository _medicalBalanceRepository;

        public CreatemedicalFundCommandHandler(IMedicalFundRepository medicalFundRepository, IMapper Mapper, IMedicalBalanceRepository medicalBalanceRepository)
        {
           
            _medicalFundRepository = medicalFundRepository;
            _mapper = Mapper;
            _medicalBalanceRepository = medicalBalanceRepository;
        }
        public async Task<BaseCommandResponse> Handle(CreateMedicalFundCommand request, CancellationToken cancellationToken)
        {
            response = new BaseCommandResponse();
            var validator = new MedicalFundDtoValidators();
            var validationResult = await validator.ValidateAsync(request.MedicalFundDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Faild";
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
            var medbalnce = await _medicalBalanceRepository.GetByEmpId(request.MedicalFundDto.EmpId);

            var med = _mapper.Map<MedicalFunds>(request.MedicalFundDto);
            med.MedicalRequestId = Guid.NewGuid();
            var m = med.MedicalRequestId;
            med.Total =med.HospitalBed + med.Laboratory + med.MedicalExamination +med.Medicine + med.OtherRelated;
           // var total = request.MedicalFundDto.Total;
            if (request.MedicalFundDto.SpouseId == null)
            {
                Guid dd = Guid.Empty;
                var medb = medbalnce.Find(m => m.SpouseId == dd);
                med.TotalFund = Math.Min(((95.00/ 100.00) * (med.Total)),medb.SelfBalance);
            }
            else
            {
                var medb = medbalnce.Find(m => m.SpouseId == med.SpouseId );
                med.TotalFund = Math.Min(((95.00 / 100.00) * (med.Total)), medb.FamilyBalance);
            
        }
            var data = await _medicalFundRepository.Add(med);
            response.Success = true;
            response.Message = "Creation Successfull";
            response.Id = (Guid)m;
            return response;
        }
    }
}
