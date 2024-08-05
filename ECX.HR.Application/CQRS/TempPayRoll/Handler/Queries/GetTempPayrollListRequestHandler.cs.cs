using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.TempPayroll.Request.Queries;
using ECX.HR.Application.DTOs.TempPayroll;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.TempPayroll.Handler.Queries
{
    public class GetTempPayrollListRequestHandler : IRequestHandler<GetTempPayrollListRequest, List<TempPayRollDto>>
    {
        private ITempPayrollRepository _TempPayrollRepository;
    private IMapper _mapper;
    public GetTempPayrollListRequestHandler(ITempPayrollRepository TempPayrollRepository, IMapper mapper)
    {
        _TempPayrollRepository = TempPayrollRepository;
        _mapper = mapper;
    }
    public async Task<List<TempPayRollDto>> Handle(GetTempPayrollListRequest request, CancellationToken cancellationToken)
    {
        var TempPayroll = await _TempPayrollRepository.GetAll();
        var TempPayrollLevel = TempPayroll.Where(TempPayroll => TempPayroll.Status == 0).ToList();
        return _mapper.Map<List<TempPayRollDto>>(TempPayrollLevel);
    }
}
}
