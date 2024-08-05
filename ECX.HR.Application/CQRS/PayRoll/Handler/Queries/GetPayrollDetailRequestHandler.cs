using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.PayRoll.Request.Queries;
using ECX.HR.Application.DTOs.Payroll;
using ECX.HR.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.PayRoll.Handler.Queries
{
    public class GetPayrollDetailRequestHandler : IRequestHandler<GetPayrollDetailRequest, PayRollDto>
    {
        private IPayrollRepository _PayrollRepository;
        private IMapper _mapper;
        public GetPayrollDetailRequestHandler(IPayrollRepository PayrollRepository, IMapper mapper)
        {
            _PayrollRepository = PayrollRepository;
            _mapper = mapper;
        }
        public async Task<PayRollDto> Handle(GetPayrollDetailRequest request, CancellationToken cancellationToken)
        {
            var Payroll = await _PayrollRepository.GetById(request.Id);

            if (Payroll == null || Payroll.Status != 0)
                throw new NotFoundException(nameof(Payroll), request.Id);

            else
                return _mapper.Map<PayRollDto>(Payroll);
        }
    }
}
