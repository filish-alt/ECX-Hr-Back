using AutoMapper;
using ECX.HR.Application.CQRS.EducationLevel.Request.Command;
using ECX.HR.Application.Exceptions;
using ECX.HR.Application.Contracts.Persistent;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECX.HR.Application.Contracts.Persistence;

namespace ECX.HR.Application.CQRS.EducationLevel.Handler.Command
{
    public class DeleteEducationLevelCommandHandler : IRequestHandler<DeleteEducationLevelCommand>
    {
        private IEducationLevelRepository _EducationLevelRepository;
        private IMapper _mapper;
        public DeleteEducationLevelCommandHandler(IEducationLevelRepository EducationLevelRepository, IMapper mapper)
        {
            _EducationLevelRepository = EducationLevelRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteEducationLevelCommand request, CancellationToken cancellationToken)
        {
            var EducationLevel = await _EducationLevelRepository.GetById(request.Id);
            await _EducationLevelRepository.Delete(EducationLevel);
            return Unit.Value;
        }

        async Task IRequestHandler<DeleteEducationLevelCommand>.Handle(DeleteEducationLevelCommand request, CancellationToken cancellationToken)
        {
            var EducationLevel = await _EducationLevelRepository.GetById(request.Id);
            if(EducationLevel == null) 
                throw new NotFoundException(nameof(EducationLevel), request.Id);
            EducationLevel.Status = 1;
            await _EducationLevelRepository.Update(EducationLevel);
        }
    }
}
