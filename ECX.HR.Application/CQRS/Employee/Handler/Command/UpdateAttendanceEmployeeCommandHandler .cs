using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.Employee.Request.Command;
using ECX.HR.Application.DTOs.EmployeePositions.Validator;
using ECX.HR.Application.DTOs.Employees.Validator;
using ECX.HR.Application.Exceptions;
using ECX.HR.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Employee.Handler.Command
{
    public class UpdateAttendanceEmployeeCommandHandler : IRequestHandler<UpdateAttendanceEmployeeCommand, Unit>
    {
        private IEmployeeRepository _EmployeeRepository;
        private IMapper _mapper;
 
        public UpdateAttendanceEmployeeCommandHandler(IEmployeeRepository EmployeeRepository, IMapper mapper)
        {
            _EmployeeRepository = EmployeeRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateAttendanceEmployeeCommand request, CancellationToken cancellationToken)
        {

            var validator = new EmployeeDtoValidators();
            var validationResult = await validator.ValidateAsync(request.EmployeeDto);
            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);
            var Employee = await _EmployeeRepository.GetById(request.EmployeeDto.EmpId);
            _mapper.Map(request.EmployeeDto, Employee);
            await _EmployeeRepository.Update(Employee);
            return Unit.Value;

        }
    }
}
