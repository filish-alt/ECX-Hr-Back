using AutoMapper;
using ECX.HR.Application.CQRS.EmployeeStatus.Request.Command;
using ECX.HR.Application.Exceptions;
using ECX.HR.Application.Contracts.Persistent;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECX.HR.Application.Contracts.Persistence;

namespace ECX.HR.Application.CQRS.EmployeeStatus.Handler.Command
{
    public class DeleteEmployeeStatusCommandHandler : IRequestHandler<DeleteEmployeeStatusCommand>
    {
        private IEmployeeStatusRepository _EmployeeStatusRepository;
        private IMapper _mapper;
        public DeleteEmployeeStatusCommandHandler(IEmployeeStatusRepository EmployeeStatusRepository, IMapper mapper)
        {
            _EmployeeStatusRepository = EmployeeStatusRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteEmployeeStatusCommand request, CancellationToken cancellationToken)
        {
            var EmployeeStatus = await _EmployeeStatusRepository.GetById(request.Id);
            await _EmployeeStatusRepository.Delete(EmployeeStatus);
            return Unit.Value;
        }

        async Task IRequestHandler<DeleteEmployeeStatusCommand>.Handle(DeleteEmployeeStatusCommand request, CancellationToken cancellationToken)
        {
            var EmployeeStatus = await _EmployeeStatusRepository.GetById(request.Id);
            if(EmployeeStatus == null) 
                throw new NotFoundException(nameof(EmployeeStatus), request.Id);
            await _EmployeeStatusRepository.Delete(EmployeeStatus);
        }
    }
}
