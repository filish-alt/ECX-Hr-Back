using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.Addresss.Request.Command;
using ECX.HR.Application.CQRS.LeaveType.Request.Command;
using ECX.HR.Application.DTOs.Address.Validator;
using ECX.HR.Application.DTOs.LeaveType.validator;
using ECX.HR.Application.Exceptions;
using MediatR;
using System;

namespace ECX.HR.Application.CQRS.LeaveType.Handler.Command
{
    
    }
    public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, Unit>
    {
    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IMapper _maapper;

    public UpdateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository, IMapper maapper)
    {
        _leaveTypeRepository = leaveTypeRepository;
        _maapper = maapper;
    }
    public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        var validator = new LeaveTypeeDtoValidator();
        var validationResult = await validator.ValidateAsync(request.LeaveTypeDto);
        if (validationResult.IsValid == false)
            throw new ValidationException(validationResult);

        request.LeaveTypeDto.UpdatedDate = DateTime.Now;
            var leaveType = await _leaveTypeRepository.GetById(request.LeaveTypeDto.leaveTypeId);



        _maapper.Map(request.LeaveTypeDto, leaveType);

            await _leaveTypeRepository.Update(leaveType);
            return Unit.Value;
        }

   

}
