using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.MedicalBalance.Request.Queries;
using ECX.HR.Application.DTOs.MedicalBalance;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.MedicalFund.Handler.Queries
{
    public class GetMedicalBalanceListRequestHandler : IRequestHandler<GetMedicalBalanceListRequest, List<MedicalBalanceDto>>
    {
        private readonly IMedicalBalanceRepository _medicalBalanceRepository;
        private readonly IMapper _mapper;

        public GetMedicalBalanceListRequestHandler()
        {
        }

        public GetMedicalBalanceListRequestHandler(IMedicalBalanceRepository medicalBalanceRepository, IMapper Mapper)
        {
            _medicalBalanceRepository = medicalBalanceRepository;
            _mapper = Mapper;
        }
        public async Task<List<MedicalBalanceDto>> Handle(GetMedicalBalanceListRequest request, CancellationToken cancellationToken)
        {
            var med = await _medicalBalanceRepository.GetAll();

            var meds = med.Where(acting => acting.Status == 0).ToList();

            return _mapper.Map<List<MedicalBalanceDto>>(meds);
        }
    }
}
