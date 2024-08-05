using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.CQRS.Attendance.Request.Command;
using ECX.HR.Application.DTOs.Attendance.Validator;

using ECX.HR.Application.Exceptions;

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Attendance.Handler.Command
{
    public class UpdateAttendanceCommandHandler : IRequestHandler<UpdateAttendanceCommand, Unit>
    {
        private IAttendanceRepository _AttendanceRepository;
        private IMapper _mapper;
        public UpdateAttendanceCommandHandler(IAttendanceRepository AttendanceRepository, IMapper mapper)
        {
            _AttendanceRepository = AttendanceRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateAttendanceCommand request, CancellationToken cancellationToken)
        {
            var validator = new AttendanceDtoValidator();
            var validationResult = await validator.ValidateAsync(request.AttendanceDto);
            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);
            
            var Attendance = await _AttendanceRepository.GetById(request.AttendanceDto.Id);




            _mapper.Map(request.AttendanceDto, Attendance);
            await _AttendanceRepository.Update(Attendance);
            return Unit.Value;
        }
    }
}
