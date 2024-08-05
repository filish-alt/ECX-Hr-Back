using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.Holiday.Request.Queries;
using ECX.HR.Application.DTOs.Holiday;
using ECX.HR.Application.Exceptions;
using ECX.HR.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Holiday.Handler.Queries
{
    public class GetHolidayDetailRequestHandler : IRequestHandler<GetHolidayDetailRequest, HolidayDto>
    {
        private IHolidayRepository _HolidayRepository;
        private IMapper _mapper;
        public GetHolidayDetailRequestHandler(IHolidayRepository HolidayRepository, IMapper mapper)
        {
            _HolidayRepository = HolidayRepository;
            _mapper = mapper;
        }
        public async Task<HolidayDto> Handle(GetHolidayDetailRequest request, CancellationToken cancellationToken)
        {
            var Holiday = await _HolidayRepository.GetById(request.Id);

            if (Holiday == null || Holiday.Status != 0)
                throw new NotFoundException(nameof(Holiday), request.Id);

            else
                return _mapper.Map<HolidayDto>(Holiday);
        }
    }
}