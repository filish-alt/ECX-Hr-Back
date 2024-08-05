using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.Addresss.Request.Command;
using ECX.HR.Application.CQRS.MedicalBalance.Request.Command;
using ECX.HR.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.MedicalBalance.Handler.Command
{
    public class DeleteMedicalBalanceDtoCommandHandler : IRequestHandler<DeleteMedicalBalance>
    {
        private readonly IMedicalBalanceRepository _medicalBalanceRepository;
        private readonly IMapper _mapper;

        public DeleteMedicalBalanceDtoCommandHandler(IMedicalBalanceRepository medicalBalanceRepository, IMapper mapper)
        {
            _medicalBalanceRepository = medicalBalanceRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
        {
            var act = await _medicalBalanceRepository.GetById(request.Id);

            if (act == null)
                throw new NotFoundException(nameof(act), request.Id);

            // Assuming '1' represents the 'Deleted' status
            act.Status = 1;

            await _medicalBalanceRepository.Update(act); // Update the address with new status

            return Unit.Value;
        }
        async Task IRequestHandler<DeleteMedicalBalance>.Handle(DeleteMedicalBalance request, CancellationToken cancellationToken)
        {
            var med = await _medicalBalanceRepository.GetById(request.Id);
            if (med == null)
                throw new NotFoundException(nameof(med), request.Id);
            med.Status = 1;
            await _medicalBalanceRepository.Update(med);
        }
    }
}
