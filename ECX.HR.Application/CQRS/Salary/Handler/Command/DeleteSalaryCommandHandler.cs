using AutoMapper;
using ECX.HR.Application.CQRS.Salary.Request.Command;
using ECX.HR.Application.Exceptions;
using ECX.HR.Application.Contracts.Persistent;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECX.HR.Application.Contracts.Persistence;

namespace ECX.HR.Application.CQRS.Salary.Handler.Command
{
    public class DeleteSalaryCommandHandler : IRequestHandler<DeleteSalaryCommand>
    {
        private ISalaryRepository _SalaryRepository;
        private IMapper _mapper;
        public DeleteSalaryCommandHandler(ISalaryRepository SalaryRepository, IMapper mapper)
        {
            _SalaryRepository = SalaryRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteSalaryCommand request, CancellationToken cancellationToken)
        {
            var Salary = await _SalaryRepository.GetById(request.Id);
            await _SalaryRepository.Delete(Salary);
            return Unit.Value;
        }

        async Task IRequestHandler<DeleteSalaryCommand>.Handle(DeleteSalaryCommand request, CancellationToken cancellationToken)
        {
            var Salary = await _SalaryRepository.GetById(request.Id);
            if(Salary == null) 
                throw new NotFoundException(nameof(Salary), request.Id);
            await _SalaryRepository.Delete(Salary);
        }
    }
}
