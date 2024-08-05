using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.CQRS.EmployeeStatus.Request.Queries;

using ECX.HR.Application.DTOs.EmployeeStatuss;
using ECX.HR.Application.Exceptions;
using ECX.HR.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.EmployeeStatus.Handler.Queries
{
    public class GetEmployeeStatusDetailRequestHandler : IRequestHandler<GetEmployeeStatusDetailRequest, EmployeeStatusDto>
    {
        private IEmployeeStatusRepository _EmployeeStatusRepository;
        private IMapper _mapper;
        public GetEmployeeStatusDetailRequestHandler(IEmployeeStatusRepository EmployeeStatusRepository, IMapper mapper)
        {
            _EmployeeStatusRepository = EmployeeStatusRepository;
            _mapper = mapper;
        }
        public async Task<EmployeeStatusDto> Handle(GetEmployeeStatusDetailRequest request, CancellationToken cancellationToken)
        {
            var employeeStatus =await _EmployeeStatusRepository.GetById(request.Id);
          
            if (employeeStatus == null)
                throw new NotFoundException(nameof(employeeStatus), request.Id);

            else
                return _mapper.Map<EmployeeStatusDto>(employeeStatus);
        }
    }
}
