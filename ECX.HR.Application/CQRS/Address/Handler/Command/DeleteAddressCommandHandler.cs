using AutoMapper;
using ECX.HR.Application.CQRS.Addresss.Request.Command;
using ECX.HR.Application.Exceptions;
using ECX.HR.Application.Contracts.Persistent;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECX.HR.Application.Contracts.Persistence;

namespace ECX.HR.Application.CQRS.Addresss.Handler.Command
{
    public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommand>
    {
        private IAdressRepository _AddressRepository;
        private IMapper _mapper;
        public DeleteAddressCommandHandler(IAdressRepository AddressRepository, IMapper mapper)
        {
            _AddressRepository = AddressRepository;
            _mapper = mapper;
        }


        public async Task<Unit> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
        {
            var address = await _AddressRepository.GetById(request.Id);

            if (address == null)
                throw new NotFoundException(nameof(address), request.Id);

            // Assuming '1' represents the 'Deleted' status
            address.Status = 1;

            await _AddressRepository.Update(address); // Update the address with new status

            return Unit.Value;
        }
        async Task IRequestHandler<DeleteAddressCommand>.Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
        {
            var address = await _AddressRepository.GetById(request.Id);
            if (address == null)
                throw new NotFoundException(nameof(address), request.Id);
            address.Status = 1;
            await _AddressRepository.Update(address);
        }
    }
}
