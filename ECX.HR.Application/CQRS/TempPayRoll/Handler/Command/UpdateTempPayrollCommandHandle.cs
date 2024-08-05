using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.PayRoll.Request.Command;
using ECX.HR.Application.CQRS.TempPayroll.Request.Command;
using ECX.HR.Application.DTOs.Payroll.validator;
using ECX.HR.Application.DTOs.TempPayroll.validator;
using ECX.HR.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.TempPayroll.Handler.Command
{
    public class UpdateTempPayrollCommandHandle : IRequestHandler<UpdateTempPayrollCommand, Unit>
    {
        private ITempPayrollRepository _PayrollRepository;
        private IMapper _mapper;
        public UpdateTempPayrollCommandHandle(ITempPayrollRepository PayrollRepository, IMapper mapper)
        {
            _PayrollRepository = PayrollRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateTempPayrollCommand request, CancellationToken cancellationToken)
        {
            var validator = new TempPayRollDtoValidator();
            var validationResult = await validator.ValidateAsync(request.TempPayRollDto);
            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);
            var Payroll = await _PayrollRepository.GetById(request.TempPayRollDto.Id);
            _mapper.Map(request.TempPayRollDto, Payroll);
            await _PayrollRepository.Update(Payroll);
            return Unit.Value;
        }
    }
}
