using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;

using ECX.HR.Application.CQRS.EmployeePosition.Request.Queries;
using ECX.HR.Application.DTOs.EmployeePositions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.EmployeePosition.Handler.Queries
{
    public class GetEmployeePositionListRequestHandler : IRequestHandler<GetEmployeePositionListRequest, List<EmployeePositionDto>>
    {
        private IEmployeePositionRepository _EmployeePositionRepository;
        private IMapper _mapper;
        public GetEmployeePositionListRequestHandler(IEmployeePositionRepository EmployeePositionRepository, IMapper mapper)
        {
            _EmployeePositionRepository= EmployeePositionRepository;
            _mapper = mapper;
        }
        public async Task<List<EmployeePositionDto>> Handle(GetEmployeePositionListRequest request, CancellationToken cancellationToken)
        {
            var EmployeePosition =await _EmployeePositionRepository.GetAll();
            var activeEmployeePosition = EmployeePosition.Where(employeePosition => employeePosition.Status == 0).ToList();
            return _mapper.Map<List<EmployeePositionDto>>(activeEmployeePosition);
        }
    }
}
