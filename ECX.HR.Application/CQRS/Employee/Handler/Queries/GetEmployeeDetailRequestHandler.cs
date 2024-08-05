using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.CQRS.Employee.Request.Queries;

using ECX.HR.Application.DTOs.Employees;
using ECX.HR.Application.Exceptions;
using ECX.HR.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Employee.Handler.Queries
{
    public class GetEmployeeDetailRequestHandler : IRequestHandler<GetEmployeeDetailRequest, EmployeeDto>
    {
        private IEmployeeRepository _EmployeeRepository;
        private IMapper _mapper;
        public GetEmployeeDetailRequestHandler(IEmployeeRepository EmployeeRepository, IMapper mapper)
        {
            _EmployeeRepository = EmployeeRepository;
            _mapper = mapper;
        }
        public async Task<EmployeeDto> Handle(GetEmployeeDetailRequest request, CancellationToken cancellationToken)
        {
            var employee =await _EmployeeRepository.GetById(request.EmpId);
           
            if (employee == null || employee.Status != 0)
                throw new NotFoundException(nameof(employee), request.EmpId);

            else
                return _mapper.Map<EmployeeDto>(employee);
        }
    }
}
