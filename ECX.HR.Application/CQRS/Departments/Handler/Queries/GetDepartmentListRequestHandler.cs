using AutoMapper;
using ECX.HR.Application.Contracts.Persistent;
using ECX.HR.Application.CQRS.Departments.Request.Queries;
using ECX.HR.Application.DTOs.Department;

using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.Departments.Handler.Queries
{
    public class GetDepartmentListRequestHandler : IRequestHandler<GetDepartmentListRequest, List<DepartmentDto>>
    {
        private IDepartmentRepository _departmentRepository;
        private IMapper _mapper;
        public GetDepartmentListRequestHandler(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository= departmentRepository;
            _mapper = mapper;
        }
        public async Task<List<DepartmentDto>> Handle(GetDepartmentListRequest request, CancellationToken cancellationToken)
        {
            var department =await _departmentRepository.GetAll();
            var activeDepartment = department.Where(department => department.Status == 0).ToList();
            return _mapper.Map<List<DepartmentDto>>(activeDepartment);
        }
    }
}
