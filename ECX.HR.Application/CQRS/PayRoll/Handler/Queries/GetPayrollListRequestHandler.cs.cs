using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.PayRoll.Request.Queries;
using ECX.HR.Application.DTOs.Payroll;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.PayRoll.Handler.Queries
{
    public class GetPayrollListRequestHandler : IRequestHandler<GetPayrollListRequest, List<PayRollDto>>
    {
        private IPayrollRepository _PayrollRepository;
        private IMapper _mapper;
        public GetPayrollListRequestHandler(IPayrollRepository PayrollRepository, IMapper mapper)
        {
            _PayrollRepository = PayrollRepository;
            _mapper = mapper;
        }
        public async Task<List<PayRollDto>> Handle(GetPayrollListRequest request, CancellationToken cancellationToken)
        {
            var Payroll = await _PayrollRepository.GetAll();
            var PayrollLevel = Payroll.Where(Payroll => Payroll.Status == 0).ToList();
            return _mapper.Map<List<PayRollDto>>(PayrollLevel);
        }
    }
}
