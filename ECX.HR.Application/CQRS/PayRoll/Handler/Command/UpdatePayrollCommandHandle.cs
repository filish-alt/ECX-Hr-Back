using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.PayRoll.Request.Command;
using ECX.HR.Application.DTOs.Payroll.validator;
using ECX.HR.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.PayRoll.Handler.Command
{
    public class UpdatePayrollCommandHandle : IRequestHandler<UpdatePayrollCommand, Unit>
    {
        private IPayrollRepository _PayrollRepository;
        private IMapper _mapper;
        public UpdatePayrollCommandHandle(IPayrollRepository PayrollRepository, IMapper mapper)
        {
            _PayrollRepository = PayrollRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdatePayrollCommand request, CancellationToken cancellationToken)
        {
            var validator = new PayRollDtoValidator();
            var validationResult = await validator.ValidateAsync(request.PayRollDto);
            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);
            var Payroll = await _PayrollRepository.GetById(request.PayRollDto.Id);
            _mapper.Map(request.PayRollDto, Payroll);
            await _PayrollRepository.Update(Payroll);
            return Unit.Value;
        }
    }
}
