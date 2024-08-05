using AutoMapper;
using ECX.HR.Application.CQRS.Branch.Request.Command;
using ECX.HR.Application.Exceptions;
using ECX.HR.Application.Contracts.Persistent;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECX.HR.Application.Contracts.Persistence;

namespace ECX.HR.Application.CQRS.Branch.Handler.Command
{
    public class DeleteBranchCommandHandler : IRequestHandler<DeleteBranchCommand>
    {
        private IBranchRepository _BranchRepository;
        private IMapper _mapper;
        public DeleteBranchCommandHandler(IBranchRepository BranchRepository, IMapper mapper)
        {
            _BranchRepository = BranchRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteBranchCommand request, CancellationToken cancellationToken)
        {
            var branch = await _BranchRepository.GetById(request.Id);
            await _BranchRepository.Delete(branch);
            return Unit.Value;
        }

        async Task IRequestHandler<DeleteBranchCommand>.Handle(DeleteBranchCommand request, CancellationToken cancellationToken)
        {
            var branch = await _BranchRepository.GetById(request.Id);
            if(branch == null) 
                throw new NotFoundException(nameof(branch), request.Id);
            branch.Status = 1;
            await _BranchRepository.Update(branch);
        }
    }
}
