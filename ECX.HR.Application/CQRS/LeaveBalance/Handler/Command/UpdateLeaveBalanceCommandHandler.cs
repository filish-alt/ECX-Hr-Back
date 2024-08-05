using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;

using ECX.HR.Application.CQRS.LeaveBalance.Request.Command;
using ECX.HR.Application.DTOs.LeaveBalance;
using ECX.HR.Application.DTOs.LeaveBalance.Validator;
using ECX.HR.Application.Exceptions;

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.LeaveBalance.Handler.Command
{
    public class UpdateLeaveBalanceCommandHandler : IRequestHandler<UpdateLeaveBalanceCommand, Unit>
    {
        private ILeaveBalanceRepository _LeaveBalanceRepository;
        private IMapper _mapper;

        public UpdateLeaveBalanceCommandHandler(ILeaveBalanceRepository LeaveBalanceRepository, IMapper mapper)
        {
            _LeaveBalanceRepository = LeaveBalanceRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateLeaveBalanceCommand request, CancellationToken cancellationToken)
        {
            var validator = new LeaveBalanceDtoValidator();
            var validationResult = await validator.ValidateAsync(request.LeaveBalanceDto);
            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            request.LeaveBalanceDto.UpdatedDate = DateTime.Now;
          
            request.LeaveBalanceDto.AnnualRemainingBalance += request.LeaveBalanceDto.UnusedDays
                ;


         var LeaveBalance = await _LeaveBalanceRepository.GetById(request.LeaveBalanceDto.Id);

            LeaveBalance.UnusedDays += request.LeaveBalanceDto.UnusedDays;
           var leave= _mapper.Map(request.LeaveBalanceDto, LeaveBalance);

            await _LeaveBalanceRepository.Update(leave);
            return Unit.Value;
        }
    }
}

