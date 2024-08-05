using AutoMapper;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.CQRS.Departments.Request.Command;
using ECX.HR.Application.DTOs.Department.Validators;
using ECX.HR.Application.Exceptions;

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Departments.Handler.Command
{
    public class UpdateDepartmentCommandHandler : IRequestHandler<UpdateDepartmentCommand, Unit>
    {
        private IDepartmentRepository _departmentRepository;
        private IMapper _mapper;
        public UpdateDepartmentCommandHandler(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var validator = new DepartmentDtoValidator();
            var validationResult = await validator.ValidateAsync(request.DepartmentDto);
            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);
            var department = await _departmentRepository.GetById(request.DepartmentDto.DepartmentId);
            _mapper.Map(request.DepartmentDto, department);
            await _departmentRepository.Update(department);
            return Unit.Value;
        }
    }
}
