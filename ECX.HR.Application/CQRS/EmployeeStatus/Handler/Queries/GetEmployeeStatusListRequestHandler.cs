using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.CQRS.EmployeeStatus.Request.Queries;


using ECX.HR.Application.DTOs.EmployeeStatuss;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.EmployeeStatus.Handler.Queries
{
    public class GetEmployeeStatusListRequestHandler : IRequestHandler<GetEmployeeStatusListRequest, List<EmployeeStatusDto>>
    {
        private IEmployeeStatusRepository _EmployeeStatusRepository;
        private IMapper _mapper;
        public GetEmployeeStatusListRequestHandler(IEmployeeStatusRepository EmployeeStatusRepository, IMapper mapper)
        {
            _EmployeeStatusRepository= EmployeeStatusRepository;
            _mapper = mapper;
        }
        public async Task<List<EmployeeStatusDto>> Handle(GetEmployeeStatusListRequest request, CancellationToken cancellationToken)
        {
            var EmployeeStatus =await _EmployeeStatusRepository.GetAll();
            return _mapper.Map<List<EmployeeStatusDto>>(EmployeeStatus);
        }
    }
}
