using AutoMapper;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.CQRS.Departments.Request.Command;
using ECX.HR.Application.DTOs.Department;
using ECX.HR.Application.DTOs.Department.Validators;
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

namespace ECX.HR.Application.CQRS.Departments.Handler.Command
{
    public class CreateDepartmentCommandHandler : IRequestHandler<CreateDepartmentCommand, BaseCommandResponse>
    {
        BaseCommandResponse response;
        private IDepartmentRepository _departmentRepository;
        private IMapper _mapper;
        public CreateDepartmentCommandHandler(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateDepartmentCommand request, CancellationToken cancellationToken)
        {
            response = new BaseCommandResponse();
            var validator =new DepartmentDtoValidator();
            var validationResult =await validator.ValidateAsync(request.DepartmentDto);
            
            if(validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Faild";
                response.Errors= validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
           
            var department = _mapper.Map<Department>(request.DepartmentDto);
            department.DepartmentId = Guid.NewGuid();
            var data =await _departmentRepository.Add(department);
            response.Success = true;
            response.Message = "Creation Successfull";
            return response;
        }
    }
}
