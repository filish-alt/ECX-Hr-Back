using ECX.HR.Application.DTOs.ActingAssigment;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECX.HR.Application.CQRS.MedicalFund.Request.Command
{
    public class DeleteMedicalFund : IRequest
    { 
      public Guid Id { get; set; }  
    }
}
