using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.CQRS.Branch.Request.Queries;

using ECX.HR.Application.DTOs.Branchs;
using ECX.HR.Application.Exceptions;
using ECX.HR.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Branch.Handler.Queries
{
    public class GetBranchDetailRequestHandler : IRequestHandler<GetBranchDetailRequest, BranchDto>
    {
        private IBranchRepository _BranchRepository;
        private IMapper _mapper;
        public GetBranchDetailRequestHandler(IBranchRepository BranchRepository, IMapper mapper)
        {
            _BranchRepository = BranchRepository;
            _mapper = mapper;
        }
        public async Task<BranchDto> Handle(GetBranchDetailRequest request, CancellationToken cancellationToken)
        {
            var branch =await _BranchRepository.GetById(request.Id);
            if (branch == null || branch.Status != 0)
                throw new NotFoundException(nameof(branch), request.Id);

            else
                return _mapper.Map<BranchDto>(branch);
        }
    }
}
