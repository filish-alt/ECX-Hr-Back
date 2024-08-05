using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.Outsource.Request.Queries;
using ECX.HR.Application.DTOs.Outsource;
using ECX.HR.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Outsource.Handler.Queries
{
    public class GetOutsoueceDetailRequestHandler : IRequestHandler<GetOutsoueceDetailRequest, OutsourceDto>
    {
        private IOutsourceRepository _OutsourceRepository;
        private IMapper _mapper;
        public GetOutsoueceDetailRequestHandler(IOutsourceRepository OutsourceRepository, IMapper mapper)
        {
            _OutsourceRepository = OutsourceRepository;
            _mapper = mapper;
        }
        public async Task<OutsourceDto> Handle(GetOutsoueceDetailRequest request, CancellationToken cancellationToken)
        {
            var Outsource = await _OutsourceRepository.GetById(request.Id);

            if (Outsource == null || Outsource.Status != 0)
                throw new NotFoundException(nameof(Outsource), request.Id);

            else
                return _mapper.Map<OutsourceDto>(Outsource);
        }
    }
}
