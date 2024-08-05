using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.Outsource.Request.Command;
using ECX.HR.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Outsource.Handler.Command
{
    public class DeleteOutsourceCommandHandler : IRequestHandler<DeleteOutsourceCommand>
    {
        private IOutsourceRepository _OutsourceRepository;
        private IMapper _mapper;
        public DeleteOutsourceCommandHandler(IOutsourceRepository OutsourceRepository, IMapper mapper)
        {
            _OutsourceRepository = OutsourceRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteOutsourceCommand request, CancellationToken cancellationToken)
        {
            var Outsource = await _OutsourceRepository.GetById(request.Id);
            await _OutsourceRepository.Delete(Outsource);
            return Unit.Value;
        }

        async Task IRequestHandler<DeleteOutsourceCommand>.Handle(DeleteOutsourceCommand request, CancellationToken cancellationToken)
        {
            var Outsource = await _OutsourceRepository.GetById(request.Id);
            if (Outsource == null)
                throw new NotFoundException(nameof(Outsource), request.Id);
            Outsource.Status = 1;
            await _OutsourceRepository.Update(Outsource);
        }
    }
}
