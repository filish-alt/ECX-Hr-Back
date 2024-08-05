using AutoMapper;

using ECX.HR.Application.Exceptions;
using ECX.HR.Application.Contracts.Persistent;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.Holiday.Request.Command;

namespace ECX.HR.Application.CQRS.Holiday.Handler.Command
{
    public class DeleteHolidayCommandHandler : IRequestHandler<DeleteHolidayCommand>
    {
        private IHolidayRepository _HolidayRepository;
        private IMapper _mapper;
        public DeleteHolidayCommandHandler(IHolidayRepository HolidayRepository, IMapper mapper)
        {
            _HolidayRepository = HolidayRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteHolidayCommand request, CancellationToken cancellationToken)
        {
            var Holiday = await _HolidayRepository.GetById(request.Id);
            await _HolidayRepository.Delete(Holiday);
            return Unit.Value;
        }

        async Task IRequestHandler<DeleteHolidayCommand>.Handle(DeleteHolidayCommand request, CancellationToken cancellationToken)
        {
            var Holiday = await _HolidayRepository.GetById(request.Id);
            if (Holiday == null)
                throw new NotFoundException(nameof(Holiday), request.Id);
            Holiday.Status = 1;
            await _HolidayRepository.Update(Holiday);
        }
    }
}
