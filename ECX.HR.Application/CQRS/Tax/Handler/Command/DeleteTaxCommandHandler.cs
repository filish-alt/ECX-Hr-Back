using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.Tax.Request.Command;
using ECX.HR.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Tax.Handler.Command
{
    public class DeleteTaxCommandHandler : IRequestHandler<DeleteTaxCommand>
    {
        private ITaxRepository _TaxRepository;
        private IMapper _mapper;
        public DeleteTaxCommandHandler(ITaxRepository TaxRepository, IMapper mapper)
        {
            _TaxRepository = TaxRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteTaxCommand request, CancellationToken cancellationToken)
        {
            var Tax = await _TaxRepository.GetById(request.Id);
            await _TaxRepository.Delete(Tax);
            return Unit.Value;
        }

        async Task IRequestHandler<DeleteTaxCommand>.Handle(DeleteTaxCommand request, CancellationToken cancellationToken)
        {
            var Tax = await _TaxRepository.GetById(request.Id);
            if (Tax == null)
                throw new NotFoundException(nameof(Tax), request.Id);
            Tax.Status = 1;
            await _TaxRepository.Update(Tax);
        }
    }
}
