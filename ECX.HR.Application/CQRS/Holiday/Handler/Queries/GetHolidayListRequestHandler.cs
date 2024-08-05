using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.Holiday.Request.Queries;
using ECX.HR.Application.DTOs.Holiday;


using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Holiday.Handler.Queries
{
    public class GetHolidayListRequestHandler : IRequestHandler<GetHolidayListRequest, List<HolidayDto>>
    {
        private IHolidayRepository _HolidayRepository;
        private IMapper _mapper;
        public GetHolidayListRequestHandler(IHolidayRepository HolidayRepository, IMapper mapper)
        {
            _HolidayRepository= HolidayRepository;
            _mapper = mapper;
        }
        public async Task<List<HolidayDto>> Handle(GetHolidayListRequest request, CancellationToken cancellationToken)
        {
            var Holiday =await _HolidayRepository.GetAll();
            var activeHoliday = Holiday.Where(Holiday => Holiday.Status == 0).ToList();
            return _mapper.Map<List<HolidayDto>>(activeHoliday);
        }
    }
}
