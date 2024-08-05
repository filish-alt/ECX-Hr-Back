using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.ContractEmployee.Request.Command;
using ECX.HR.Application.CQRS.EmployeePosition.Request.Command;
using ECX.HR.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.ContractEmployee.Handler.Command
{
    public class DeleteContractEmployeeRegstrationRequestHandler : IRequestHandler<DeleteContractEmployeeCommand>
    {
   
        private readonly IContractEmployeesRegstration _contractEmployeenRepository;
        private IMapper _mapper;
        public DeleteContractEmployeeRegstrationRequestHandler(IContractEmployeesRegstration contractEmployeenRepository, IMapper mapper)
        {
            
           _contractEmployeenRepository = contractEmployeenRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteEmployeePositionCommand request, CancellationToken cancellationToken)
        {
            var EmployeePosition = await _contractEmployeenRepository.GetById(request.Id);
            EmployeePosition.Status = 1;
            await _contractEmployeenRepository.Update(EmployeePosition);
            return Unit.Value;
        }

        async Task IRequestHandler<DeleteContractEmployeeCommand>.Handle(DeleteContractEmployeeCommand request, CancellationToken cancellationToken)
        {
            var contractemp = await _contractEmployeenRepository.GetById(request.EmpId);
            if (contractemp == null)
                throw new NotFoundException(nameof(EmployeePosition), request.EmpId);
            contractemp.Status = 1;
            await _contractEmployeenRepository.Update(contractemp);
        }
    }
}
