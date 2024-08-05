using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.Outsource.Request.Queries;
using ECX.HR.Application.DTOs.Outsource;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Outsource.Handler.Queries
{
    public class GetOutsoueceListRequestHandler : IRequestHandler<GetOutsoueceListRequest, List<OutsourceDto>>
    {
        private IOutsourceRepository _OutsourceRepository;
        private IMapper _mapper;
        public GetOutsoueceListRequestHandler(IOutsourceRepository OutsourcelRepository, IMapper mapper)
        {
            _OutsourceRepository = OutsourcelRepository;
            _mapper = mapper;
        }
        public async Task<List<OutsourceDto>> Handle(GetOutsoueceListRequest request, CancellationToken cancellationToken)
        {
            var Outsourcel = await _OutsourceRepository.GetAll();
            var activeOutsourcel = Outsourcel.Where(Outsourcel => Outsourcel.Status == 0).ToList();
            return _mapper.Map<List<OutsourceDto>>(activeOutsourcel);
        }
    }
}
