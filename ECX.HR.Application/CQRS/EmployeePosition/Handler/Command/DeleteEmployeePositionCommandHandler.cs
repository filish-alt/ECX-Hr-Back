using AutoMapper;
using ECX.HR.Application.CQRS.EmployeePosition.Request.Command;
using ECX.HR.Application.Exceptions;
using ECX.HR.Application.Contracts.Persistent;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECX.HR.Application.Contracts.Persistence;

namespace ECX.HR.Application.CQRS.EmployeePosition.Handler.Command
{
    public class DeleteEmployeePositionCommandHandler : IRequestHandler<DeleteEmployeePositionCommand>
    {
        private IEmployeePositionRepository _EmployeePositionRepository;
        private IMapper _mapper;
        public DeleteEmployeePositionCommandHandler(IEmployeePositionRepository EmployeePositionRepository, IMapper mapper)
        {
            _EmployeePositionRepository = EmployeePositionRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteEmployeePositionCommand request, CancellationToken cancellationToken)
        {
            var EmployeePosition = await _EmployeePositionRepository.GetById(request.Id);
            EmployeePosition.Status = 1;
            await _EmployeePositionRepository.Update(EmployeePosition);
            return Unit.Value;
        }

        async Task IRequestHandler<DeleteEmployeePositionCommand>.Handle(DeleteEmployeePositionCommand request, CancellationToken cancellationToken)
        {
            var EmployeePosition = await _EmployeePositionRepository.GetById(request.Id);
            if(EmployeePosition == null) 
                throw new NotFoundException(nameof(EmployeePosition), request.Id);
            EmployeePosition.Status = 1;
            await _EmployeePositionRepository.Update(EmployeePosition);
        }
    }
}
