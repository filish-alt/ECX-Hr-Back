using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;

using ECX.HR.Application.CQRS.LeaveBalance.Request.Queries;
using ECX.HR.Application.DTOs.LeaveBalance;
using ECX.HR.Application.Exceptions;
using ECX.HR.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.LeaveBalance.Handler.Queries
{
    public class GetleaveBalanceDetailRequestHandler : IRequestHandler<GetLeaveBalanceDetailRequest, List<AnnualLeaveBalanceDto>>
    {
        private ILeaveBalanceRepository _LeaveBalanceRepository;
     
        private IMapper _mapper;
        public GetleaveBalanceDetailRequestHandler(ILeaveBalanceRepository LeaveBalanceRepository, IMapper mapper)
        {
           _LeaveBalanceRepository = LeaveBalanceRepository;
        
            _mapper = mapper;
        }
        public async Task<List<AnnualLeaveBalanceDto>> Handle(GetLeaveBalanceDetailRequest request, CancellationToken cancellationToken)
        {
            var leaveBalance = await _LeaveBalanceRepository.GetByEmpId(request.EmpId);

            if (leaveBalance == null || !leaveBalance.Any(we => we.Status == 0))
                throw new NotFoundException(nameof(LeaveBalance), request.EmpId);

            return _mapper.Map<List<AnnualLeaveBalanceDto>>(leaveBalance);
        }

    }
}
