using AutoMapper;
using ECX.HR.Application.CQRS.Education.Request.Command;
using ECX.HR.Application.Exceptions;
using ECX.HR.Application.Contracts.Persistent;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECX.HR.Application.Contracts.Persistence;

namespace ECX.HR.Application.CQRS.Education.Handler.Command
{
    public class DeleteEducationCommandHandler : IRequestHandler<DeleteEducationCommand>
    {
        private IEducationRepository _EducationRepository;
        private IMapper _mapper;
        public DeleteEducationCommandHandler(IEducationRepository EducationRepository, IMapper mapper)
        {
            _EducationRepository = EducationRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteEducationCommand request, CancellationToken cancellationToken)
        {
            var Education = await _EducationRepository.GetById(request.Id);
            Education.Status = 1;
            await _EducationRepository.Update(Education);
            return Unit.Value;
        }

        async Task IRequestHandler<DeleteEducationCommand>.Handle(DeleteEducationCommand request, CancellationToken cancellationToken)
        {
            var Education = await _EducationRepository.GetById(request.Id);
            if(Education == null) 
                throw new NotFoundException(nameof(Education), request.Id);
            Education.Status = 1;
            await _EducationRepository.Update(Education);
        }
    }
}
