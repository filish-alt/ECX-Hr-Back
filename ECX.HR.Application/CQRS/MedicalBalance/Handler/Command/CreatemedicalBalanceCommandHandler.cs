using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.MedicalBalance.Request.Command;
using ECX.HR.Application.DTOs.MedicalBalance.Validator;
using ECX.HR.Application.Response;
using ECX.HR.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.MedicalBalance.Handler.Command
{
    public class CreatemedicalBalanceCommandHandler : IRequestHandler<CreateMedicalBalanceCommand, BaseCommandResponse>
    {
        BaseCommandResponse response;
        private readonly IMedicalBalanceRepository _medicalBalanceRepository;
        private readonly IEmployeeRepository _employeeRepositor;
        private readonly ISpouseRepository _spouseRepository;
        private readonly IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;

        public CreatemedicalBalanceCommandHandler(IMedicalBalanceRepository medicalBalanceRepository,
            IEmployeeRepository employeeRepositor, ISpouseRepository spouseRepository, IMapper Mapper)
        {

            _medicalBalanceRepository = medicalBalanceRepository;
            _employeeRepositor = employeeRepositor;
            _spouseRepository = spouseRepository;
            _mapper = Mapper;
      
        }
        public async Task<BaseCommandResponse> Handle(CreateMedicalBalanceCommand request, CancellationToken cancellationToken)
        {
            response = new BaseCommandResponse();
            var validator = new MedicalBalanceDtoValidators();
            var validationResult = await validator.ValidateAsync(request.MedicalBalanceDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Faild";
                response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }

            var Med = _mapper.Map<MedicalBalances>(request.MedicalBalanceDto);
            Med.MedicalRequestId = Guid.NewGuid();

            var employee = await _employeeRepositor.GetById(Med.EmpId);
            DateTime employmentStartDate = employee.JoinDate;
            int daysElapsed = 365;
            var ed = employmentStartDate.AddDays(daysElapsed);

            var medBal = await _medicalBalanceRepository.GetAll();
    
            //   List<DateTime?> charray = new List<DateTime?>();

            var spouse = await _spouseRepository.GetByEmpId(Med.EmpId);

     
            


            var emp = medBal.Where(m => m.EmpId != (request.MedicalBalanceDto.EmpId));
            if(emp!=null)
            {
             Med.SelfBalance = 5000;
            Med.FamilyBalance = 0;
            Med.UpdatedDate = DateTime.Now;
                Med.StartDate = employmentStartDate;
                Med.EndDate = ed;
            }
           

            var acct = Med.MedicalRequestId;
            var data = await _medicalBalanceRepository.Add(Med);
            response.Success = true;
            response.Message = "Creation Successfull";
            response.Id = (Guid)acct;
            return response;
        }
    }
}
