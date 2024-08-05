using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.LeaveType.Request.Queries;
using ECX.HR.Application.DTOs.Employees;
using ECX.HR.Application.DTOs.Leave;
using ECX.HR.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.LeaveType.Handler.Queries
{
    public class GetLeaveTypeByIdRequestHandler : IRequestHandler<GetLeaveTypeByIdRequest, LeaveTypeDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IMapper _mapper;

        public GetLeaveTypeByIdRequestHandler(ILeaveTypeRepository LeaveTypeRepository, IMapper Mapper)
        {
            _leaveTypeRepository = LeaveTypeRepository;
            _mapper = Mapper;
        }
        public async Task<LeaveTypeDto> Handle(GetLeaveTypeByIdRequest request, CancellationToken cancellationToken)
        {
            var leavetype = await _leaveTypeRepository.GetById(request.LeaveTypeid);

            if (leavetype == null || leavetype.Status != 0)
                throw new NotFoundException(nameof(leavetype), request.LeaveTypeid);

            else
                return _mapper.Map<LeaveTypeDto>(leavetype);
        }
    }
}
