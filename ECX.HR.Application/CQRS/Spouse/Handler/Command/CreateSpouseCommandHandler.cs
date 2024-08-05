using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.CQRS.MedicalBalance.Request.Command;
using ECX.HR.Application.CQRS.Spouse.Request.Command;
using ECX.HR.Application.DTOs.MedicalBalance;
using ECX.HR.Application.DTOs.Spouses.Validator;
using ECX.HR.Application.Exceptions;

using ECX.HR.Application.Response;
using ECX.HR.Domain;
using MediatR;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Spouse.Handler.Command
{
    public class CreateSpouseCommandHandler : IRequestHandler<CreateSpouseCommand, BaseCommandResponse>
    {
        BaseCommandResponse response;
        private ISpouseRepository _SpouseRepository;
        private readonly IMedicalBalanceRepository _medicalBalanceRepository;
        private readonly IMediator _mediator;
        private IMapper _mapper;
        private readonly IEmployeeRepository _employeeRepository;

        public CreateSpouseCommandHandler(ISpouseRepository SpouseRepository, IMedicalBalanceRepository medicalBalanceRepository, IMediator mediator, IMapper mapper,
            IEmployeeRepository employeeRepository)
        {
            _SpouseRepository = SpouseRepository;
            _medicalBalanceRepository = medicalBalanceRepository;
            _mediator = mediator;
            _mapper = mapper;
          _employeeRepository = employeeRepository;
        }
        public async Task<BaseCommandResponse> Handle(CreateSpouseCommand request, CancellationToken cancellationToken)
        {
            response = new BaseCommandResponse();
            var validator =new SpouseValidator();
            var validationResult =await validator.ValidateAsync(request.SpouseDto);
            
            if(validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Faild";
                response.Errors= validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
            var spouse = _mapper.Map<Spouses>(request.SpouseDto);
            spouse.Id = Guid.NewGuid();
            var employee = await _employeeRepository.GetById(request.SpouseDto.EmpId);
            DateTime employmentStartDate = employee.JoinDate;
            int daysElapsed = 365;
            var ed = employmentStartDate.AddDays(daysElapsed);
            var medicalBalanceDto = new MedicalBalanceDto
            {
                EmpId = request.SpouseDto.EmpId,
                UpdatedDate=DateTime.Now,
                SelfBalance=0,
                FamilyBalance=5000,
                StartDate=employmentStartDate,
                EndDate=ed,
                SpouseId=spouse.Id// Set the employee's ID
                                                   // ... Set other properties relevant to the leave balance
            };

     




          

            var medical = _mapper.Map<MedicalBalances>(medicalBalanceDto);
            await _medicalBalanceRepository.Add(medical);

            var data =await _SpouseRepository.Add(spouse);
            response.Success = true;
            response.Message = "Creation Successfull";
            return response;
        }
    }
}
