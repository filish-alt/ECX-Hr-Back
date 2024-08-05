using AutoMapper;
using ECX.HR.Application.CQRS.OrganizationalProfile.Request.Command;
using ECX.HR.Application.Exceptions;
using ECX.HR.Application.Contracts.Persistent;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECX.HR.Application.Contracts.Persistence;

namespace ECX.HR.Application.CQRS.OrganizationalProfile.Handler.Command
{
    public class DeleteOrganizationalProfileCommandHandler : IRequestHandler<DeleteOrganizationalProfileCommand>
    {
        private IOrganizationalProfileRepository _OrganizationalProfileRepository;
        private IMapper _mapper;
        public DeleteOrganizationalProfileCommandHandler(IOrganizationalProfileRepository OrganizationalProfileRepository, IMapper mapper)
        {
            _OrganizationalProfileRepository = OrganizationalProfileRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteOrganizationalProfileCommand request, CancellationToken cancellationToken)
        {
            var OrganizationalProfile = await _OrganizationalProfileRepository.GetById(request.Id);
            await _OrganizationalProfileRepository.Delete(OrganizationalProfile);
            return Unit.Value;
        }

        async Task IRequestHandler<DeleteOrganizationalProfileCommand>.Handle(DeleteOrganizationalProfileCommand request, CancellationToken cancellationToken)
        {
            var OrganizationalProfile = await _OrganizationalProfileRepository.GetById(request.Id);
            if(OrganizationalProfile == null) 
                throw new NotFoundException(nameof(OrganizationalProfile), request.Id);
            await _OrganizationalProfileRepository.Delete(OrganizationalProfile);
        }
    }
}
