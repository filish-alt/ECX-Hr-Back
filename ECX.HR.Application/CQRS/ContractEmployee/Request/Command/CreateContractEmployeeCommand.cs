using AutoMapper;
using ECX.HR.Application.Contracts.Persistence;
using ECX.HR.Application.CQRS.Employee.Request.Command;
using ECX.HR.Application.DTOs.Employees;
using ECX.HR.Application.DTOs.Employees.Validator;
using ECX.HR.Application.DTOs.PayrollContract;
using ECX.HR.Application.Response;
using ECX.HR.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.ContractEmployee.Request.Command
{
    public class CreateContractEmployeeCommand : IRequest<BaseCommandResponse>
    {
        public ContractRegistrationDto ContractEmployeeDto { get; set; }


        public CreateContractEmployeeCommand(ContractRegistrationDto contractemployeeDto)
        {
            ContractEmployeeDto = contractemployeeDto;
        }

        public CreateContractEmployeeCommand()
        {
            // Empty constructor
        }
    }
}
