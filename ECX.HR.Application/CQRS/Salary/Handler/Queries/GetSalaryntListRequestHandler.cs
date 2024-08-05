using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.CQRS.Salary.Request.Queries;
using ECX.HR.Application.DTOs.Salaries;
using ECX.HR.Application.DTOs.Salary;

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Salary.Handler.Queries
{
    public class GetSalaryListRequestHandler : IRequestHandler<GetSalaryListRequest, List<SalaryTypeDto>>
    {
        private ISalaryRepository _SalaryRepository;
        private IMapper _mapper;
        public GetSalaryListRequestHandler(ISalaryRepository SalaryRepository, IMapper mapper)
        {
            _SalaryRepository= SalaryRepository;
            _mapper = mapper;
        }
        public async Task<List<SalaryTypeDto>> Handle(GetSalaryListRequest request, CancellationToken cancellationToken)
        {
            var Salary =await _SalaryRepository.GetAll();
            return _mapper.Map<List<SalaryTypeDto>>(Salary);
        }
    }
}
