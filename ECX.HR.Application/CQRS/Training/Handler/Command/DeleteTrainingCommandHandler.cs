using AutoMapper;
using ECX.HR.Application.CQRS.Training.Request.Command;
using ECX.HR.Application.Exceptions;
using ECX.HR.Application.Contracts.Persistent;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECX.HR.Application.Contracts.Persistence;

namespace ECX.HR.Application.CQRS.Training.Handler.Command
{
    public class DeleteTrainingCommandHandler : IRequestHandler<DeleteTrainingCommand>
    {
        private ITrainingRepository _TrainingRepository;
        private IMapper _mapper;
        public DeleteTrainingCommandHandler(ITrainingRepository TrainingRepository, IMapper mapper)
        {
            _TrainingRepository = TrainingRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteTrainingCommand request, CancellationToken cancellationToken)
        {
            var Training = await _TrainingRepository.GetById(request.Id);
            Training.Status = 1;
            await _TrainingRepository.Update(Training);
            return Unit.Value;
        }

        async Task IRequestHandler<DeleteTrainingCommand>.Handle(DeleteTrainingCommand request, CancellationToken cancellationToken)
        {
            var Training = await _TrainingRepository.GetById(request.Id);
            if(Training == null) 
                throw new NotFoundException(nameof(Training), request.Id);
            Training.Status = 1;
            await _TrainingRepository.Update(Training);
        }
    }
}
