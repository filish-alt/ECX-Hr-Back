using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.Addresss.Request.Command;
using ECX.HR.Application.CQRS.MedicalFund.Request.Command;
using ECX.HR.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.MedicalFund.Handler.Command
{
    public class DeleteMedicalFundDtoCommandHandler : IRequestHandler<DeleteMedicalFund>
    {
        private readonly IMedicalFundRepository _medicalFundRepository;
        private readonly IMapper _mapper;

        public DeleteMedicalFundDtoCommandHandler(IMedicalFundRepository medicalFundRepository, IMapper mapper)
        {
            _medicalFundRepository = medicalFundRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteMedicalFund request, CancellationToken cancellationToken)
        {
            var act = await _medicalFundRepository.GetById(request.Id);

            if (act == null)
                throw new NotFoundException(nameof(act), request.Id);

            // Assuming '1' represents the 'Deleted' status
            act.Status = 1;

            await _medicalFundRepository.Update(act); // Update the address with new status

            return Unit.Value;
        }
        async Task IRequestHandler<DeleteMedicalFund>.Handle(DeleteMedicalFund request, CancellationToken cancellationToken)
        {
            var acting = await _medicalFundRepository.GetById(request.Id);
            if (acting == null)
                throw new NotFoundException(nameof(acting), request.Id);
            acting.Status = 1;
            await _medicalFundRepository.Update(acting);
        }
    }
}
