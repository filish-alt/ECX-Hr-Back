using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.TempPayroll.Request.Queries;
using ECX.HR.Application.DTOs.TempPayroll;
using ECX.HR.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.TempPayroll.Handler.Queries
{
    public class GetTempPayrollDetailRequestHandler : IRequestHandler<GetTempPayrollDetailRequest, TempPayRollDto>
    {
        private ITempPayrollRepository _TempPayrollRepository;
        private IMapper _mapper;
        public GetTempPayrollDetailRequestHandler(ITempPayrollRepository TempPayrollRepository, IMapper mapper)
        {
            _TempPayrollRepository = TempPayrollRepository;
            _mapper = mapper;
        }
        public async Task<TempPayRollDto> Handle(GetTempPayrollDetailRequest request, CancellationToken cancellationToken)
        {
            var TempPayroll = await _TempPayrollRepository.GetById(request.Id);

            if (TempPayroll == null || TempPayroll.Status != 0)
                throw new NotFoundException(nameof(TempPayroll), request.Id);

            else
                return _mapper.Map<TempPayRollDto>(TempPayroll);
        }
    }
}
