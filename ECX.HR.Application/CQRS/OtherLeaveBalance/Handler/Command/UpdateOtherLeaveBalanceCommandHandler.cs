using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.CQRS.OtherLeaveBalance.Request.Command;
using ECX.HR.Application.DTOs.LeaveBalance.Validator;
using ECX.HR.Application.Exceptions;

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.OtherLeaveBalance.Handler.Command
{
    public class UpdateOtherLeaveBalanceCommandHandler : IRequestHandler<UpdateOtherLeaveBalanceCommand, Unit>
    {
        private IOtherLeaveBalanceRepository _OtherLeaveBalanceRepository;
        private IMapper _mapper;

        public UpdateOtherLeaveBalanceCommandHandler(IOtherLeaveBalanceRepository OtherLeaveBalanceRepository, IMapper mapper)
        {
            _OtherLeaveBalanceRepository = OtherLeaveBalanceRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateOtherLeaveBalanceCommand request, CancellationToken cancellationToken)
        {
            var validator = new OtherLeaveBalanceDtoValidator();
            var validationResult = await validator.ValidateAsync(request.OtherLeaveBalanceDto);
            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            request.OtherLeaveBalanceDto.UpdatedDate = DateTime.Now;
            var OtherLeaveBalance = await _OtherLeaveBalanceRepository.GetById(request.OtherLeaveBalanceDto.Id);

           

            _mapper.Map(request.OtherLeaveBalanceDto, OtherLeaveBalance);

            await _OtherLeaveBalanceRepository.Update(OtherLeaveBalance);
            return Unit.Value;
        }
    }
}

