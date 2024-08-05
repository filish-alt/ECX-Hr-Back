using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.AllowanceType.Request.Queries;
using ECX.HR.Application.DTOs.AllowanceType;
using ECX.HR.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.AllowanceType.Handler.Queries
{
    public class GetAllowanceTypeDetailRequestHandler : IRequestHandler<GetAllowanceTypeDetailRequest, AllowanceTypeDto>
    {
        private IAllowanceTypeRepository _AllowanceTypeRepository;
    private IMapper _mapper;
    public GetAllowanceTypeDetailRequestHandler(IAllowanceTypeRepository AllowanceTypeRepository, IMapper mapper)
    {
        _AllowanceTypeRepository = AllowanceTypeRepository;
        _mapper = mapper;
    }
    public async Task<AllowanceTypeDto> Handle(GetAllowanceTypeDetailRequest request, CancellationToken cancellationToken)
    {
        var AllowanceType = await _AllowanceTypeRepository.GetById(request.Id);
        if (AllowanceType == null)
            throw new NotFoundException(nameof(AllowanceType), request.Id);

        else
            return _mapper.Map<AllowanceTypeDto>(AllowanceType);

    }
}
}
