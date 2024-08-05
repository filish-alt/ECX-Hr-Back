using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.LeaveType.Request.Queries;
using ECX.HR.Application.DTOs.Addresss;
using ECX.HR.Application.DTOs.Employees;
using ECX.HR.Application.DTOs.Leave;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.LeaveType.Handler.Queries
{
    public class GetLeaveTypeListRequestHandler : IRequestHandler<GetLeaveTypeListRequest, List<LeaveTypeDto>>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public GetLeaveTypeListRequestHandler(ILeaveTypeRepository LeaveTypeRepository, IMapper Mapper)
        {
            _leaveTypeRepository = LeaveTypeRepository;
            _mapper = Mapper;
        }
        public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypeListRequest request, CancellationToken cancellationToken)
        {
            var leaveType = await _leaveTypeRepository.GetAll();
        
            var activeLeaveType = leaveType.Where(leavetype => leavetype.Status == 0).ToList();

            return _mapper.Map<List<LeaveTypeDto>>(activeLeaveType);
           
        }
    }
}
