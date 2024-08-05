using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.Employee.Request.Command;
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
    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand, Unit>
    {
        private IEmployeeRepository _EmployeeRepository;
        private IMapper _mapper;
        public UpdateEmployeeCommandHandler(IEmployeeRepository EmployeeRepository, IMapper mapper)
        {
            _EmployeeRepository = EmployeeRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {

            var validator = new EmployeeDtoValidators();
            var validationResult = await validator.ValidateAsync(request.EmployeeDto);
            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var existingEmployee = await _EmployeeRepository.GetById(request.EmployeeDto.EmpId);


            var Updated_Employee = new Employees
            {
                EmpId = Guid.NewGuid(),
                EcxId = existingEmployee.EcxId,
                AdId = existingEmployee.AdId,
                FirstName = existingEmployee.FirstName,
                MiddleName = existingEmployee.MiddleName,
                LastName = existingEmployee.LastName,
                JoinDate = existingEmployee.JoinDate,
                sex = existingEmployee.sex,
                DateOfBityh = existingEmployee.DateOfBityh,
                PlaceOfBith = existingEmployee.PlaceOfBith,
                MartialStatus = existingEmployee.MartialStatus,
                salutation = existingEmployee.salutation,
                Nationality = existingEmployee.Nationality,
                PensionNo = existingEmployee.PensionNo,
                ImageData = existingEmployee.ImageData,
                crime = existingEmployee.crime,
                CrimeDescription = existingEmployee.CrimeDescription,
                Status = 1,
                CreatedBy = existingEmployee.CreatedBy,
                CreatedDate = existingEmployee.CreatedDate
            };

              await _EmployeeRepository.Add(Updated_Employee);

            _mapper.Map(request.EmployeeDto, existingEmployee);
            await _EmployeeRepository.Update(existingEmployee);


            return Unit.Value;
        }
    }
}
