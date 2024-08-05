using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;

using ECX.HR.Application.CQRS.MedicalBalance.Request.Queries;

using ECX.HR.Application.DTOs.MedicalBalance;

using ECX.HR.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.MedicalBalance.Handler.Queries
{
    public class GetMedicalBalanceDetailRequestHandler : IRequestHandler<GetMedicalBalanceDetailRequest, List<MedicalBalanceDto>>
    {
        private readonly IMedicalBalanceRepository _medicalBalanceRepository;
        private readonly IMapper _mapper;

        public GetMedicalBalanceDetailRequestHandler(IMedicalBalanceRepository medicalBalanceRepository, IMapper Mapper)
        {
            _medicalBalanceRepository = medicalBalanceRepository;
            _mapper = Mapper;
        }
        public async Task<List<MedicalBalanceDto>> Handle(GetMedicalBalanceDetailRequest request, CancellationToken cancellationToken)
        {
            var med = await _medicalBalanceRepository.GetByEmpId(request.Id);

            if (med == null || med.Any(we => we.Status != 0))
                throw new NotFoundException(nameof(med), request.Id);

            return _mapper.Map<List<MedicalBalanceDto>>(med);
        }
    }
}
