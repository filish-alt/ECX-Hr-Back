using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.AllowanceType.Request.Queries;
using ECX.HR.Application.DTOs.AllowanceType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.AllowanceType.Handler.Queries
{
    public class GetAllowanceTypeListRequestHandler : IRequestHandler<GetAllowanceTypeListRequest, List<AllowanceTypeDto>>
    {
       
        private readonly IAllowanceTypeRepository _allowanceTypeRepository;
        private IMapper _mapper;
        public GetAllowanceTypeListRequestHandler(IAllowanceTypeRepository AllowanceTypeRepository, IMapper mapper)
        {
            _allowanceTypeRepository = AllowanceTypeRepository;
            _mapper = mapper;
        }
        public async Task<List<AllowanceTypeDto>> Handle(GetAllowanceTypeListRequest request, CancellationToken cancellationToken)
        {
            var AllowanceType = await _allowanceTypeRepository.GetAll();
            var activeallowance = AllowanceType.Where(branch => branch.Status == 0).ToList();
            return _mapper.Map<List<AllowanceTypeDto>>(activeallowance);
        }
    }
}
