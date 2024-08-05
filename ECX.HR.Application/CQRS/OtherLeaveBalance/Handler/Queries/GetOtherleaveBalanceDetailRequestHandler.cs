using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using Dapper;
using System.Data.SqlClient;
using ECX.HR.Application.CQRS.OtherLeaveBalance.Request.Queries;
using ECX.HR.Application.DTOs.LeaveBalance;
using ECX.HR.Application.Exceptions;
using ECX.HR.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.OtherLeaveBalance.Handler.Queries
{
    public class GetOtherleaveBalanceDetailRequestHandler : IRequestHandler<GetOtherLeaveBalanceDetailRequest, List<OtherLeaveBalanceDto>>
    {
        private IOtherLeaveBalanceRepository _OtherLeaveBalanceRepository;
  /*      private readonly string _connectionString;*/

        private IMapper _mapper;
        public GetOtherleaveBalanceDetailRequestHandler(IOtherLeaveBalanceRepository OtherLeaveBalanceRepository, IMapper mapper )
        {
            _OtherLeaveBalanceRepository = OtherLeaveBalanceRepository;
    /*        _connectionString = connectionString;*/

            _mapper = mapper;
        }
        public async Task<List<OtherLeaveBalanceDto>> Handle(GetOtherLeaveBalanceDetailRequest request, CancellationToken cancellationToken)
        {
            var otherLeaveBalance = await _OtherLeaveBalanceRepository.GetByEmpId(request.EmpId);

            if (otherLeaveBalance == null || !otherLeaveBalance.Any(we => we.Status == 0))
                throw new NotFoundException(nameof(otherLeaveBalance), request.EmpId);

          /*  using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync(cancellationToken);

                var query = @"
                    SELECT 
                        o.*, 
                        l.*
                    FROM 
                        OtherLeaveBalances o
                        JOIN AnnualLeaveBalances l ON o.EmpId = l.EmpId
                    WHERE 
                        o.EmpId = @EmpId";

                var parameters = new
                {
                    EmpId = request.EmpId
                };

                var result = await connection.QueryAsync<OtherLeaveBalanceDto, AnnualLeaveBalanceDto, OtherLeaveBalanceDto>(
                    query,
                    (otherLeaveBalanceDto, annualLeaveBalanceDto) =>
                    {
                     *//*   otherLeaveBalanceDto.AnnualLeaveBalance = annualLeaveBalanceDto;*//*
                        return otherLeaveBalanceDto;
                    },
                    parameters,
                    splitOn: "EmpId");

                *//*
                                return result.ToList();*/

                return _mapper.Map<List<OtherLeaveBalanceDto>>(otherLeaveBalance);

            }

        }
    }

