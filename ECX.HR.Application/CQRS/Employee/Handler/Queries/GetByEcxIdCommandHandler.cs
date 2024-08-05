using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.Employee.Request.Queries;
using ECX.HR.Application.DTOs.Employees;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Employee.Handler.Queries
{
    public class GetByEcxIdCommandHandler : IRequestHandler<GetByEcxIdRequest, List<EmployeeDto>>
    {
        private IEmployeeRepository _EmployeeRepository;
        private IMapper _mapper;
        public GetByEcxIdCommandHandler(IEmployeeRepository EmployeeRepository, IMapper mapper)
        {
            _EmployeeRepository = EmployeeRepository;
            _mapper = mapper;
        }
        public async Task<List<EmployeeDto>> Handle(GetByEcxIdRequest request, CancellationToken cancellationToken)
        {


            var employees = await _EmployeeRepository.GetByEcxId(request.EcxId);

            /*var employeeDtos = employees.Select(employee => new EmployeeDto
            {
                
            }).ToList();*/
    

            return   _mapper.Map<List<EmployeeDto>>(employees); ;
        }
    }
}
    

