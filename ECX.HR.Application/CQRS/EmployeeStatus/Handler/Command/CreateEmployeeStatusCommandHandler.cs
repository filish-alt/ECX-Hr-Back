using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.CQRS.EmployeeStatus.Request.Command;
using ECX.HR.Application.DTOs.EmployeeStatus;
using ECX.HR.Application.DTOs.EmployeeStatus.Validator;
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

namespace ECX.HR.Application.CQRS.EmployeeStatus.Handler.Command
{
    public class CreateEmployeeStatusCommandHandler : IRequestHandler<CreateEmployeeStatusCommand, BaseCommandResponse>
    {
        BaseCommandResponse response;
        private IEmployeeStatusRepository _EmployeeStatusRepository;
        private IMapper _mapper;
        public CreateEmployeeStatusCommandHandler(IEmployeeStatusRepository EmployeeStatusRepository, IMapper mapper)
        {
            _EmployeeStatusRepository = EmployeeStatusRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateEmployeeStatusCommand request, CancellationToken cancellationToken)
        {
            response = new BaseCommandResponse();
            var validator =new EmployeeStatusDtoValidators();
            var validationResult =await validator.ValidateAsync(request.EmployeeStatusDto);
            
            if(validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Faild";
                response.Errors= validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
           
            var employeeStatus = _mapper.Map<EmployeeStatuss>(request.EmployeeStatusDto);
            employeeStatus.Id = Guid.NewGuid();
            var data =await _EmployeeStatusRepository.Add(employeeStatus);
            response.Success = true;
            response.Message = "Creation Successfull";
            return response;
        }
    }
}
