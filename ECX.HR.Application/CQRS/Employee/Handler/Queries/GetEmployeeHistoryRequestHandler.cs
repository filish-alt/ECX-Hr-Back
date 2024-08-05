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
    public class GetEmployeeHistoryRequestHandler : IRequestHandler<GetEmployeeHistoryRequest, List<EmployeeDto>>
    {
        private IEmployeeRepository _EmployeeRepository;
        private IMapper _mapper;
        public GetEmployeeHistoryRequestHandler(IEmployeeRepository EmployeeRepository, IMapper mapper)
        {
            _EmployeeRepository = EmployeeRepository;
            _mapper = mapper;
        }
        public async Task<List<EmployeeDto>> Handle(GetEmployeeHistoryRequest request, CancellationToken cancellationToken)

        {
            string decodedEcxId = Uri.UnescapeDataString(request.EcxId);
          var employee =await _EmployeeRepository.GetByEcxId(decodedEcxId);
           
            if (employee == null || !employee.Any(we => we.Status == 1))
                throw new NotFoundException(nameof(employee), request.EcxId);

            else
                return _mapper.Map<List<EmployeeDto>>(employee);
        }

      
    }
}
