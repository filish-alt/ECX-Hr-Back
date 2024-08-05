using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.AllowanceType.Request.Command;
using ECX.HR.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.AllowanceType.Handler.Command
{
    public class DeleteAllowanceTypeCommandHandler : IRequestHandler<DeleteAllowanceTypeCommand>
    {
        private IAllowanceTypeRepository _AllowanceTypeRepository;
        private IMapper _mapper;
        public DeleteAllowanceTypeCommandHandler(IAllowanceTypeRepository AllowanceTypeRepository, IMapper mapper)
        {
            _AllowanceTypeRepository = AllowanceTypeRepository;
            _mapper = mapper;
        }


        public async Task<Unit> Handle(DeleteAllowanceTypeCommand request, CancellationToken cancellationToken)
        {
            var AllowanceType = await _AllowanceTypeRepository.GetById(request.Id);

            if (AllowanceType == null)
                throw new NotFoundException(nameof(AllowanceType), request.Id);

            // Assuming '1' represents the 'Deleted' status
            AllowanceType.Status = 1;

            await _AllowanceTypeRepository.Update(AllowanceType); // Update the AllowanceType with new status

            return Unit.Value;
        }
        async Task IRequestHandler<DeleteAllowanceTypeCommand>.Handle(DeleteAllowanceTypeCommand request, CancellationToken cancellationToken)
        {
            var AllowanceType = await _AllowanceTypeRepository.GetById(request.Id);
            if (AllowanceType == null)
                throw new NotFoundException(nameof(AllowanceType), request.Id);
            AllowanceType.Status = 1;
            await _AllowanceTypeRepository.Update(AllowanceType);
        }
    }
}
